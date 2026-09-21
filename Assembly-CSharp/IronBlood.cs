using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x020006C7 RID: 1735
public class IronBlood : ActiveSkillLogicBase
{
	// Token: 0x06002EB1 RID: 11953 RVA: 0x0013ADAC File Offset: 0x001391AC
	public IronBlood()
	{
	}

	// Token: 0x06002EB2 RID: 11954 RVA: 0x0013ADD0 File Offset: 0x001391D0
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new TargetSelectionBuffTalent(SkillType.IronBlood, 1),
			new TargetSelectionBuffTalent(SkillType.IronBlood, 2),
			new TargetSelectionBuffTalent(SkillType.IronBlood, 3)
		};
	}

	// Token: 0x17000606 RID: 1542
	// (get) Token: 0x06002EB3 RID: 11955 RVA: 0x0013AE17 File Offset: 0x00139217
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x17000607 RID: 1543
	// (get) Token: 0x06002EB4 RID: 11956 RVA: 0x0013AE1F File Offset: 0x0013921F
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x17000608 RID: 1544
	// (get) Token: 0x06002EB5 RID: 11957 RVA: 0x0013AE27 File Offset: 0x00139227
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x17000609 RID: 1545
	// (get) Token: 0x06002EB6 RID: 11958 RVA: 0x0013AE2F File Offset: 0x0013922F
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002EB7 RID: 11959 RVA: 0x0013AE37 File Offset: 0x00139237
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<FriendlyAllStrategy>();
	}

	// Token: 0x06002EB8 RID: 11960 RVA: 0x0013AE3E File Offset: 0x0013923E
	public override double GetGaugeCost(Skill skill)
	{
		return 65.0;
	}

	// Token: 0x06002EB9 RID: 11961 RVA: 0x0013AE49 File Offset: 0x00139249
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002EBA RID: 11962 RVA: 0x0013AE55 File Offset: 0x00139255
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new FriendlyAllStrategy(skill);
	}

	// Token: 0x06002EBB RID: 11963 RVA: 0x0013AE5D File Offset: 0x0013925D
	private float ActiveReductionRate(Skill skill)
	{
		return Convert.ToSingle(0.34 + (double)(skill.Level - 1) * 0.1);
	}

	// Token: 0x06002EBC RID: 11964 RVA: 0x0013AE84 File Offset: 0x00139284
	private float PassiveReductionRate(Skill skill)
	{
		return Convert.ToSingle(0.1 + (double)(skill.Level - 1) * 0.05);
	}

	// Token: 0x06002EBD RID: 11965 RVA: 0x0013AEB8 File Offset: 0x001392B8
	public override Description ParseLogic(Description description, Skill skill)
	{
		double value = Convert.ToDouble(this.PassiveReductionRate(skill));
		description.Details1 = description.Details1.ReplaceToBuilder(this.DamageReceivedReductionRateKey, Convert.ToDouble(this.ActiveReductionRate(skill)).ToExpressionMultiply100()).Replace(this.LastingSecondsKey, ((int)this.LastingSeconds(skill)).ToString()).ToString();
		description.Details2 = description.Details2.ReplaceToBuilder(this.PossibilityKey, this.PassiveChance(skill).ToExpressionMultiply100()).Replace(this.LastingSecondsKey, ((int)this.LastingSeconds(skill)).ToString()).Replace(this.DamageReceivedReductionRateKey, value.ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06002EBE RID: 11966 RVA: 0x0013AF7B File Offset: 0x0013937B
	private float LastingSeconds(Skill skill)
	{
		return 4f;
	}

	// Token: 0x06002EBF RID: 11967 RVA: 0x0013AF82 File Offset: 0x00139382
	private double PassiveChance(Skill skill)
	{
		return 0.6;
	}

	// Token: 0x06002EC0 RID: 11968 RVA: 0x0013AF90 File Offset: 0x00139390
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		DuelistIronBloodBoostData duelistBoost = skill.SourceUnit.SpecialEffects.OfType<DuelistIronBloodBoostData>().FirstOrDefault<DuelistIronBloodBoostData>();
		double resilienceBoost = 0.0;
		if (duelistBoost != null)
		{
			resilienceBoost = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Resilience, AttributeRetrievalLevel.Skill) * duelistBoost.ResilienceRate;
		}
		float additionalRate = Convert.ToSingle(skill.SourceUnit.SpecialEffects.OfType<DuelistStarSkillBoostData>().Sum((DuelistStarSkillBoostData s) => s.Rate));
		foreach (IBattleUnit strategySelection in strategy.Selections)
		{
			DamageReductionEffect damageReduction = new DamageReductionEffect(base.GetType().FullName + "active", UnitExtensions.GetAllDamageElements(), this.ActiveReductionRate(skill.Skill) + additionalRate, this.LastingSeconds(skill.Skill), skill);
			IEnumerator enumerator2 = strategySelection.ApplySkillEffect(damageReduction, false).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object _ = enumerator2.Current;
					yield return _;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator2 as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			if (duelistBoost != null)
			{
				IEnumerator enumerator3 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Resilience,
						ModificationType = ModificationType.Addition,
						Value = resilienceBoost,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					},
					new AttributeModifier
					{
						AttributeType = AttributeType.ReflectiveDamage,
						ModificationType = ModificationType.Addition,
						Value = duelistBoost.DamageReflectionRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "uniqueduelistexclusive", new int?(1), new float?(this.LastingSeconds(skill.Skill)), null, false, true, false), false).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _2 = enumerator3.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator3 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06002EC1 RID: 11969 RVA: 0x0013AFC4 File Offset: 0x001393C4
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitRegularTurnStarts
		};
	}

	// Token: 0x06002EC2 RID: 11970 RVA: 0x0013AFE0 File Offset: 0x001393E0
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitRegularTurnStarts && processingSkill.SourceUnit.IsPlayer == eventTriggerUnit.IsPlayer && (double)UnityEngine.Random.value <= this.PassiveChance(processingSkill.Skill))
		{
			float additional = Convert.ToSingle(processingSkill.SourceUnit.SpecialEffects.OfType<DuelistStarSkillBoostData>().Sum((DuelistStarSkillBoostData s) => s.Rate));
			DamageReductionEffect damageReduction = new DamageReductionEffect(base.GetType().FullName + "passive", UnitExtensions.GetAllDamageElements(), this.PassiveReductionRate(processingSkill.Skill) + additional, this.LastingSeconds(processingSkill.Skill), processingSkill);
			IEnumerator enumerator = eventTriggerUnit.ApplySkillEffect(damageReduction, false).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object _ = enumerator.Current;
					yield return _;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x0400271D RID: 10013
	private SkillCategory _skillCategory = SkillCategory.Defensive;

	// Token: 0x0400271E RID: 10014
	private OutputType _skillOutputType;

	// Token: 0x0400271F RID: 10015
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x04002720 RID: 10016
	private SkillType _skillType = SkillType.IronBlood;

	// Token: 0x02000E1C RID: 3612
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005ADD RID: 23261 RVA: 0x0013B019 File Offset: 0x00139419
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005ADE RID: 23262 RVA: 0x0013B024 File Offset: 0x00139424
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				duelistBoost = skill.SourceUnit.SpecialEffects.OfType<DuelistIronBloodBoostData>().FirstOrDefault<DuelistIronBloodBoostData>();
				resilienceBoost = 0.0;
				if (duelistBoost != null)
				{
					resilienceBoost = skill.SourceUnit.GetAttributeValue_Final(AttributeType.Resilience, AttributeRetrievalLevel.Skill) * duelistBoost.ResilienceRate;
				}
				additionalRate = Convert.ToSingle(skill.SourceUnit.SpecialEffects.OfType<DuelistStarSkillBoostData>().Sum((DuelistStarSkillBoostData s) => s.Rate));
				enumerator = strategy.Selections.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_6:
					try
					{
						switch (num)
						{
						}
						if (enumerator2.MoveNext())
						{
							_ = enumerator2.Current;
							this.$current = _;
							if (!this.$disposing)
							{
								this.$PC = 1;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					if (duelistBoost == null)
					{
						goto IL_38D;
					}
					enumerator3 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.Resilience,
							ModificationType = ModificationType.Addition,
							Value = resilienceBoost,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						},
						new AttributeModifier
						{
							AttributeType = AttributeType.ReflectiveDamage,
							ModificationType = ModificationType.Addition,
							Value = duelistBoost.DamageReflectionRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "uniqueduelistexclusive", new int?(1), new float?(base.LastingSeconds(skill.Skill)), null, false, true, false), false).GetEnumerator();
					num = 4294967293u;
					break;
				case 2u:
					break;
				default:
					goto IL_38D;
				}
				try
				{
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_2 = enumerator3.Current;
						this.$current = _2;
						if (!this.$disposing)
						{
							this.$PC = 2;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				IL_38D:
				if (enumerator.MoveNext())
				{
					strategySelection = enumerator.Current;
					damageReduction = new DamageReductionEffect(base.GetType().FullName + "active", UnitExtensions.GetAllDamageElements(), base.ActiveReductionRate(skill.Skill) + additionalRate, base.LastingSeconds(skill.Skill), skill);
					enumerator2 = strategySelection.ApplySkillEffect(damageReduction, false).GetEnumerator();
					num = 4294967293u;
					goto Block_6;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012F6 RID: 4854
		// (get) Token: 0x06005ADF RID: 23263 RVA: 0x0013B440 File Offset: 0x00139840
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012F7 RID: 4855
		// (get) Token: 0x06005AE0 RID: 23264 RVA: 0x0013B448 File Offset: 0x00139848
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005AE1 RID: 23265 RVA: 0x0013B450 File Offset: 0x00139850
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						try
						{
						}
						finally
						{
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
						break;
					case 2u:
						try
						{
						}
						finally
						{
							if ((disposable2 = (enumerator3 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005AE2 RID: 23266 RVA: 0x0013B538 File Offset: 0x00139938
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005AE3 RID: 23267 RVA: 0x0013B53F File Offset: 0x0013993F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005AE4 RID: 23268 RVA: 0x0013B548 File Offset: 0x00139948
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			IronBlood.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new IronBlood.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x06005AE5 RID: 23269 RVA: 0x0013B594 File Offset: 0x00139994
		private static double <>m__0(DuelistStarSkillBoostData s)
		{
			return s.Rate;
		}

		// Token: 0x04004BEF RID: 19439
		internal AdventureUnitSkill skill;

		// Token: 0x04004BF0 RID: 19440
		internal DuelistIronBloodBoostData <duelistBoost>__0;

		// Token: 0x04004BF1 RID: 19441
		internal double <resilienceBoost>__0;

		// Token: 0x04004BF2 RID: 19442
		internal float <additionalRate>__0;

		// Token: 0x04004BF3 RID: 19443
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004BF4 RID: 19444
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004BF5 RID: 19445
		internal IBattleUnit <strategySelection>__1;

		// Token: 0x04004BF6 RID: 19446
		internal DamageReductionEffect <damageReduction>__2;

		// Token: 0x04004BF7 RID: 19447
		internal IEnumerator $locvar1;

		// Token: 0x04004BF8 RID: 19448
		internal object <_>__3;

		// Token: 0x04004BF9 RID: 19449
		internal IDisposable $locvar2;

		// Token: 0x04004BFA RID: 19450
		internal IEnumerator $locvar3;

		// Token: 0x04004BFB RID: 19451
		internal object <_>__4;

		// Token: 0x04004BFC RID: 19452
		internal IDisposable $locvar4;

		// Token: 0x04004BFD RID: 19453
		internal IronBlood $this;

		// Token: 0x04004BFE RID: 19454
		internal object $current;

		// Token: 0x04004BFF RID: 19455
		internal bool $disposing;

		// Token: 0x04004C00 RID: 19456
		internal int $PC;

		// Token: 0x04004C01 RID: 19457
		private static Func<DuelistStarSkillBoostData, double> <>f__am$cache0;
	}

	// Token: 0x02000E1D RID: 3613
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005AE6 RID: 23270 RVA: 0x0013B59C File Offset: 0x0013999C
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator1()
		{
		}

		// Token: 0x06005AE7 RID: 23271 RVA: 0x0013B5A4 File Offset: 0x001399A4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitRegularTurnStarts || processingSkill.SourceUnit.IsPlayer != eventTriggerUnit.IsPlayer || (double)UnityEngine.Random.value > base.PassiveChance(processingSkill.Skill))
				{
					goto IL_1B7;
				}
				additional = Convert.ToSingle(processingSkill.SourceUnit.SpecialEffects.OfType<DuelistStarSkillBoostData>().Sum((DuelistStarSkillBoostData s) => s.Rate));
				damageReduction = new DamageReductionEffect(base.GetType().FullName + "passive", UnitExtensions.GetAllDamageElements(), base.PassiveReductionRate(processingSkill.Skill) + additional, base.LastingSeconds(processingSkill.Skill), processingSkill);
				enumerator = eventTriggerUnit.ApplySkillEffect(damageReduction, false).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			IL_1B7:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012F8 RID: 4856
		// (get) Token: 0x06005AE8 RID: 23272 RVA: 0x0013B784 File Offset: 0x00139B84
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012F9 RID: 4857
		// (get) Token: 0x06005AE9 RID: 23273 RVA: 0x0013B78C File Offset: 0x00139B8C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005AEA RID: 23274 RVA: 0x0013B794 File Offset: 0x00139B94
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005AEB RID: 23275 RVA: 0x0013B804 File Offset: 0x00139C04
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005AEC RID: 23276 RVA: 0x0013B80B File Offset: 0x00139C0B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005AED RID: 23277 RVA: 0x0013B814 File Offset: 0x00139C14
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			IronBlood.<PassiveBeingActiveEventProcess>c__Iterator1 <PassiveBeingActiveEventProcess>c__Iterator = new IronBlood.<PassiveBeingActiveEventProcess>c__Iterator1();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			<PassiveBeingActiveEventProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x06005AEE RID: 23278 RVA: 0x0013B86C File Offset: 0x00139C6C
		private static double <>m__0(DuelistStarSkillBoostData s)
		{
			return s.Rate;
		}

		// Token: 0x04004C02 RID: 19458
		internal AdventureEventType eventType;

		// Token: 0x04004C03 RID: 19459
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004C04 RID: 19460
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004C05 RID: 19461
		internal float <additional>__1;

		// Token: 0x04004C06 RID: 19462
		internal DamageReductionEffect <damageReduction>__1;

		// Token: 0x04004C07 RID: 19463
		internal IEnumerator $locvar0;

		// Token: 0x04004C08 RID: 19464
		internal object <_>__2;

		// Token: 0x04004C09 RID: 19465
		internal IDisposable $locvar1;

		// Token: 0x04004C0A RID: 19466
		internal IronBlood $this;

		// Token: 0x04004C0B RID: 19467
		internal object $current;

		// Token: 0x04004C0C RID: 19468
		internal bool $disposing;

		// Token: 0x04004C0D RID: 19469
		internal int $PC;

		// Token: 0x04004C0E RID: 19470
		private static Func<DuelistStarSkillBoostData, double> <>f__am$cache0;
	}
}
