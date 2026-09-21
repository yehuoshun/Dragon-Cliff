using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x020006CA RID: 1738
public class Rotation : ActiveSkillLogicBase
{
	// Token: 0x06002EE5 RID: 12005 RVA: 0x0013D450 File Offset: 0x0013B850
	public Rotation()
	{
	}

	// Token: 0x06002EE6 RID: 12006 RVA: 0x0013D484 File Offset: 0x0013B884
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new RotationShieldTalent(SkillType.Rotation, 1),
			new RotationDispelTalent(SkillType.Rotation, 2),
			new RotationDecayTalent(SkillType.Rotation, 3)
		};
	}

	// Token: 0x17000612 RID: 1554
	// (get) Token: 0x06002EE7 RID: 12007 RVA: 0x0013D4CB File Offset: 0x0013B8CB
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x17000613 RID: 1555
	// (get) Token: 0x06002EE8 RID: 12008 RVA: 0x0013D4D3 File Offset: 0x0013B8D3
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x17000614 RID: 1556
	// (get) Token: 0x06002EE9 RID: 12009 RVA: 0x0013D4DB File Offset: 0x0013B8DB
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x17000615 RID: 1557
	// (get) Token: 0x06002EEA RID: 12010 RVA: 0x0013D4E3 File Offset: 0x0013B8E3
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002EEB RID: 12011 RVA: 0x0013D4EB File Offset: 0x0013B8EB
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<HostileSingleStrategy>();
	}

	// Token: 0x06002EEC RID: 12012 RVA: 0x0013D4F2 File Offset: 0x0013B8F2
	public override double GetGaugeCost(Skill skill)
	{
		return 50.0;
	}

	// Token: 0x06002EED RID: 12013 RVA: 0x0013D4FD File Offset: 0x0013B8FD
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002EEE RID: 12014 RVA: 0x0013D509 File Offset: 0x0013B909
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new HostileSingleStrategy(skill);
	}

	// Token: 0x06002EEF RID: 12015 RVA: 0x0013D514 File Offset: 0x0013B914
	private double ActiveDamage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06002EF0 RID: 12016 RVA: 0x0013D540 File Offset: 0x0013B940
	private double CasterActiveDamageRate(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.25;
	}

	// Token: 0x06002EF1 RID: 12017 RVA: 0x0013D56C File Offset: 0x0013B96C
	private double ActiveRecoveryRate(Skill skill)
	{
		return 0.3;
	}

	// Token: 0x06002EF2 RID: 12018 RVA: 0x0013D577 File Offset: 0x0013B977
	private double PassiveRecoveryRate(Skill skill)
	{
		return 0.3;
	}

	// Token: 0x06002EF3 RID: 12019 RVA: 0x0013D582 File Offset: 0x0013B982
	private double PassiveChance(Skill skill)
	{
		return 0.1 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x06002EF4 RID: 12020 RVA: 0x0013D5A4 File Offset: 0x0013B9A4
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.ActiveDamage(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.CasterActiveDamageRate(skill).ToExpressionMultiply100()).Replace(this.HealRateKey, this.ActiveRecoveryRate(skill).ToExpressionMultiply100()).ToString();
		description.Details2 = description.Details2.ReplaceToBuilder(this.PossibilityKey, this.PassiveChance(skill).ToExpressionMultiply100()).Replace(this.HealRateKey, this.PassiveRecoveryRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06002EF5 RID: 12021 RVA: 0x0013D648 File Offset: 0x0013BA48
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.DamageReleased
		};
	}

	// Token: 0x06002EF6 RID: 12022 RVA: 0x0013D664 File Offset: 0x0013BA64
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.DamageReleased && data is ReleaseableDamage && eventTriggerUnit == skillOwner)
		{
			ReleaseableDamage damage = data as ReleaseableDamage;
			if (damage.Dealer == skillOwner)
			{
				double totalHeal = 0.0;
				foreach (BattleDamage battleDamage in damage.BattleDamages)
				{
					foreach (DamageComponent damageComponent in battleDamage.Damages)
					{
						if (!damageComponent.IsMissed && (double)UnityEngine.Random.value <= this.PassiveChance(processingSkill.Skill))
						{
							totalHeal += damageComponent.GetTotalDamageSoFar() * this.PassiveRecoveryRate(processingSkill.Skill);
						}
					}
				}
				if (totalHeal > 0.0)
				{
					List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(skillOwner);
					ReleaseableHeal releaseableHeal = new ReleaseableHeal((from t in targets
					select new BattleHeal(t, processingSkill, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = totalHeal,
							HealType = OutputType.RealHeal,
							IsDirectHeal = skillOwner.SpecialEffects.OfType<ChubbyLadyStarHealerEnhanceData>().Any<ChubbyLadyStarHealerEnhanceData>()
						}
					}, false)).ToList<BattleHeal>(), skillOwner);
					IEnumerator enumerator3 = releaseableHeal.Release().GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _ = enumerator3.Current;
							yield return _;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator3 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06002EF7 RID: 12023 RVA: 0x0013D6AC File Offset: 0x0013BAAC
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		List<BattleDamage> damages = new List<BattleDamage>();
		double damageRate = this.ActiveDamage(skill.Skill);
		EnhancedChubbyLadyData enhancement = skill.SourceUnit.SpecialEffects.OfType<EnhancedChubbyLadyData>().FirstOrDefault<EnhancedChubbyLadyData>();
		if (enhancement != null)
		{
			damageRate += enhancement.DamageRate;
		}
		foreach (IBattleUnit target in strategy.Selections)
		{
			damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(skill.SourceUnit, target, OutputType.Physical, damageRate),
					new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), damageRate)
				}, target, skill.SourceUnit, true, false).AddCode(this._rotationActiveKey),
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(skill.SourceUnit, target, OutputType.Physical, damageRate),
					new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), damageRate)
				}, target, skill.SourceUnit, true, false).AddCode(this._rotationActiveKey),
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(skill.SourceUnit, target, OutputType.Physical, damageRate),
					new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), damageRate)
				}, target, skill.SourceUnit, true, false).AddCode(this._rotationActiveKey)
			}));
		}
		ReleaseableDamage releaseable = new ReleaseableDamage(damages, skill.SourceUnit);
		IEnumerator enumerator2 = releaseable.Release().GetEnumerator();
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
		double totalHealValue = 0.0;
		RotationShieldEnhancementData shieldEnhancement = skill.SourceUnit.SpecialEffects.OfType<RotationShieldEnhancementData>().FirstOrDefault<RotationShieldEnhancementData>();
		RotationDispelEnhancementData dispelEnhancement = skill.SourceUnit.SpecialEffects.OfType<RotationDispelEnhancementData>().FirstOrDefault<RotationDispelEnhancementData>();
		RotationAttributeDecayData attributeDecay = skill.SourceUnit.SpecialEffects.OfType<RotationAttributeDecayData>().FirstOrDefault<RotationAttributeDecayData>();
		double shieldValue = 0.0;
		foreach (BattleDamage battleDamage in releaseable.BattleDamages)
		{
			int totalDispels = 0;
			foreach (DamageComponent damage in from d in battleDamage.Damages
			where d.IsCrit
			select d)
			{
				totalHealValue += damage.GetTotalDamageSoFar() * this.ActiveRecoveryRate(skill.Skill);
				if (shieldEnhancement != null)
				{
					shieldValue += damage.GetTotalDamageSoFar() * shieldEnhancement.ShieldRate;
				}
				if (dispelEnhancement != null)
				{
					totalDispels += dispelEnhancement.NumberOfDispels;
				}
				if (attributeDecay != null)
				{
					IEnumerator enumerator5 = battleDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = attributeDecay.Type,
							ModificationType = attributeDecay.ModificationType,
							Value = -attributeDecay.Value,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "rotationdecay", new int?(10), new float?((float)attributeDecay.Seconds), null, true, true), false).GetEnumerator();
					try
					{
						while (enumerator5.MoveNext())
						{
							object _2 = enumerator5.Current;
							yield return _2;
						}
					}
					finally
					{
						IDisposable disposable2;
						if ((disposable2 = (enumerator5 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
			if (totalDispels > 0)
			{
				IEnumerator enumerator6 = UnitStyleConfigurationBase.DispelPositiveEffects(battleDamage.Target, new int?(totalDispels)).GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						object _3 = enumerator6.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator6 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		if (shieldEnhancement != null && shieldValue > 0.0)
		{
			List<IBattleUnit> targets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(skill.SourceUnit);
			foreach (IBattleUnit battleUnit in targets)
			{
				IEnumerator enumerator8 = DamageAbsorbShieldEffect.AddAborbShieldToTarget(battleUnit, skill, shieldValue).GetEnumerator();
				try
				{
					while (enumerator8.MoveNext())
					{
						object _4 = enumerator8.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator8 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
		}
		if (totalHealValue > 0.0)
		{
			List<IBattleUnit> targets2 = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(skill.SourceUnit);
			ReleaseableHeal releaseableHeal = new ReleaseableHeal((from t in targets2
			select new BattleHeal(t, skill, new List<HealComponentValue>
			{
				new HealComponentValue
				{
					RawHeal = totalHealValue,
					HealType = OutputType.RealDamage,
					IsDirectHeal = skill.SourceUnit.SpecialEffects.OfType<ChubbyLadyStarHealerEnhanceData>().Any<ChubbyLadyStarHealerEnhanceData>()
				}
			}, false)).ToList<BattleHeal>(), skill.SourceUnit);
			IEnumerator enumerator9 = releaseableHeal.Release().GetEnumerator();
			try
			{
				while (enumerator9.MoveNext())
				{
					object _5 = enumerator9.Current;
					yield return _5;
				}
			}
			finally
			{
				IDisposable disposable5;
				if ((disposable5 = (enumerator9 as IDisposable)) != null)
				{
					disposable5.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x04002729 RID: 10025
	private SkillCategory _skillCategory = SkillCategory.Offensive;

	// Token: 0x0400272A RID: 10026
	private OutputType _skillOutputType = OutputType.Physical;

	// Token: 0x0400272B RID: 10027
	private TargetingType _targetingType = TargetingType.Single;

	// Token: 0x0400272C RID: 10028
	private SkillType _skillType = SkillType.Rotation;

	// Token: 0x0400272D RID: 10029
	private readonly string _rotationActiveKey = "RotationActiveKey";

	// Token: 0x02000E23 RID: 3619
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B19 RID: 23321 RVA: 0x0013D6DD File Offset: 0x0013BADD
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator0()
		{
		}

		// Token: 0x06005B1A RID: 23322 RVA: 0x0013D6E8 File Offset: 0x0013BAE8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				<PassiveBeingActiveEventProcess>c__AnonStorey = new Rotation.<PassiveBeingActiveEventProcess>c__Iterator0.<PassiveBeingActiveEventProcess>c__AnonStorey2();
				<PassiveBeingActiveEventProcess>c__AnonStorey.<>f__ref$0 = this;
				<PassiveBeingActiveEventProcess>c__AnonStorey.processingSkill = processingSkill;
				<PassiveBeingActiveEventProcess>c__AnonStorey.skillOwner = skillOwner;
				if (eventType != AdventureEventType.DamageReleased || !(data is ReleaseableDamage) || eventTriggerUnit != <PassiveBeingActiveEventProcess>c__AnonStorey.skillOwner)
				{
					goto IL_2FD;
				}
				damage = (data as ReleaseableDamage);
				if (damage.Dealer != <PassiveBeingActiveEventProcess>c__AnonStorey.skillOwner)
				{
					goto IL_2FD;
				}
				double totalHeal = 0.0;
				enumerator = damage.BattleDamages.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						BattleDamage battleDamage = enumerator.Current;
						foreach (DamageComponent damageComponent in battleDamage.Damages)
						{
							if (!damageComponent.IsMissed && (double)UnityEngine.Random.value <= base.PassiveChance(<PassiveBeingActiveEventProcess>c__AnonStorey.processingSkill.Skill))
							{
								totalHeal += damageComponent.GetTotalDamageSoFar() * base.PassiveRecoveryRate(<PassiveBeingActiveEventProcess>c__AnonStorey.processingSkill.Skill);
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				if (totalHeal <= 0.0)
				{
					goto IL_2FD;
				}
				targets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(<PassiveBeingActiveEventProcess>c__AnonStorey.skillOwner);
				releaseableHeal = new ReleaseableHeal((from t in targets
				select new BattleHeal(t, <PassiveBeingActiveEventProcess>c__AnonStorey.processingSkill, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = totalHeal,
						HealType = OutputType.RealHeal,
						IsDirectHeal = <PassiveBeingActiveEventProcess>c__AnonStorey.skillOwner.SpecialEffects.OfType<ChubbyLadyStarHealerEnhanceData>().Any<ChubbyLadyStarHealerEnhanceData>()
					}
				}, false)).ToList<BattleHeal>(), <PassiveBeingActiveEventProcess>c__AnonStorey.skillOwner);
				enumerator3 = releaseableHeal.Release().GetEnumerator();
				num = 4294967293u;
				break;
			}
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
				if (enumerator3.MoveNext())
				{
					_ = enumerator3.Current;
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
					if ((disposable = (enumerator3 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			IL_2FD:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001304 RID: 4868
		// (get) Token: 0x06005B1B RID: 23323 RVA: 0x0013DA24 File Offset: 0x0013BE24
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001305 RID: 4869
		// (get) Token: 0x06005B1C RID: 23324 RVA: 0x0013DA2C File Offset: 0x0013BE2C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B1D RID: 23325 RVA: 0x0013DA34 File Offset: 0x0013BE34
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
					if ((disposable = (enumerator3 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005B1E RID: 23326 RVA: 0x0013DAA4 File Offset: 0x0013BEA4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B1F RID: 23327 RVA: 0x0013DAAB File Offset: 0x0013BEAB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B20 RID: 23328 RVA: 0x0013DAB4 File Offset: 0x0013BEB4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Rotation.<PassiveBeingActiveEventProcess>c__Iterator0 <PassiveBeingActiveEventProcess>c__Iterator = new Rotation.<PassiveBeingActiveEventProcess>c__Iterator0();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.data = data;
			<PassiveBeingActiveEventProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<PassiveBeingActiveEventProcess>c__Iterator.skillOwner = skillOwner;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x04004C66 RID: 19558
		internal AdventureEventType eventType;

		// Token: 0x04004C67 RID: 19559
		internal object data;

		// Token: 0x04004C68 RID: 19560
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004C69 RID: 19561
		internal IBattleUnit skillOwner;

		// Token: 0x04004C6A RID: 19562
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04004C6B RID: 19563
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004C6C RID: 19564
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004C6D RID: 19565
		internal List<IBattleUnit> <targets>__3;

		// Token: 0x04004C6E RID: 19566
		internal ReleaseableHeal <releaseableHeal>__3;

		// Token: 0x04004C6F RID: 19567
		internal IEnumerator $locvar2;

		// Token: 0x04004C70 RID: 19568
		internal object <_>__4;

		// Token: 0x04004C71 RID: 19569
		internal IDisposable $locvar3;

		// Token: 0x04004C72 RID: 19570
		internal Rotation $this;

		// Token: 0x04004C73 RID: 19571
		internal object $current;

		// Token: 0x04004C74 RID: 19572
		internal bool $disposing;

		// Token: 0x04004C75 RID: 19573
		internal int $PC;

		// Token: 0x04004C76 RID: 19574
		private Rotation.<PassiveBeingActiveEventProcess>c__Iterator0.<PassiveBeingActiveEventProcess>c__AnonStorey2 $locvar4;

		// Token: 0x04004C77 RID: 19575
		private Rotation.<PassiveBeingActiveEventProcess>c__Iterator0.<PassiveBeingActiveEventProcess>c__AnonStorey3 $locvar5;

		// Token: 0x02000E25 RID: 3621
		private sealed class <PassiveBeingActiveEventProcess>c__AnonStorey2
		{
			// Token: 0x06005B2A RID: 23338 RVA: 0x0013DB24 File Offset: 0x0013BF24
			public <PassiveBeingActiveEventProcess>c__AnonStorey2()
			{
			}

			// Token: 0x04004CA2 RID: 19618
			internal AdventureUnitSkill processingSkill;

			// Token: 0x04004CA3 RID: 19619
			internal IBattleUnit skillOwner;

			// Token: 0x04004CA4 RID: 19620
			internal Rotation.<PassiveBeingActiveEventProcess>c__Iterator0 <>f__ref$0;
		}

		// Token: 0x02000E26 RID: 3622
		private sealed class <PassiveBeingActiveEventProcess>c__AnonStorey3
		{
			// Token: 0x06005B2B RID: 23339 RVA: 0x0013DB2C File Offset: 0x0013BF2C
			public <PassiveBeingActiveEventProcess>c__AnonStorey3()
			{
			}

			// Token: 0x06005B2C RID: 23340 RVA: 0x0013DB34 File Offset: 0x0013BF34
			internal BattleHeal <>m__0(IBattleUnit t)
			{
				return new BattleHeal(t, this.<>f__ref$2.processingSkill, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = this.totalHeal,
						HealType = OutputType.RealHeal,
						IsDirectHeal = this.<>f__ref$2.skillOwner.SpecialEffects.OfType<ChubbyLadyStarHealerEnhanceData>().Any<ChubbyLadyStarHealerEnhanceData>()
					}
				}, false);
			}

			// Token: 0x04004CA5 RID: 19621
			internal double totalHeal;

			// Token: 0x04004CA6 RID: 19622
			internal Rotation.<PassiveBeingActiveEventProcess>c__Iterator0 <>f__ref$0;

			// Token: 0x04004CA7 RID: 19623
			internal Rotation.<PassiveBeingActiveEventProcess>c__Iterator0.<PassiveBeingActiveEventProcess>c__AnonStorey2 <>f__ref$2;
		}
	}

	// Token: 0x02000E24 RID: 3620
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B21 RID: 23329 RVA: 0x0013DB9B File Offset: 0x0013BF9B
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator1()
		{
		}

		// Token: 0x06005B22 RID: 23330 RVA: 0x0013DBA4 File Offset: 0x0013BFA4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damages = new List<BattleDamage>();
				damageRate = base.ActiveDamage(skill.Skill);
				enhancement = skill.SourceUnit.SpecialEffects.OfType<EnhancedChubbyLadyData>().FirstOrDefault<EnhancedChubbyLadyData>();
				if (enhancement != null)
				{
					damageRate += enhancement.DamageRate;
				}
				enumerator = strategy.Selections.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						IBattleUnit target = enumerator.Current;
						damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
						{
							new DamageComponentValue(new List<DamagePotionValue>
							{
								new DamagePotionValue(skill.SourceUnit, target, OutputType.Physical, damageRate),
								new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), damageRate)
							}, target, skill.SourceUnit, true, false).AddCode(this._rotationActiveKey),
							new DamageComponentValue(new List<DamagePotionValue>
							{
								new DamagePotionValue(skill.SourceUnit, target, OutputType.Physical, damageRate),
								new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), damageRate)
							}, target, skill.SourceUnit, true, false).AddCode(this._rotationActiveKey),
							new DamageComponentValue(new List<DamagePotionValue>
							{
								new DamagePotionValue(skill.SourceUnit, target, OutputType.Physical, damageRate),
								new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), damageRate)
							}, target, skill.SourceUnit, true, false).AddCode(this._rotationActiveKey)
						}));
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				releaseable = new ReleaseableDamage(damages, skill.SourceUnit);
				enumerator2 = releaseable.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
			case 3u:
				goto IL_462;
			case 4u:
				goto IL_840;
			case 5u:
				Block_10:
				try
				{
					switch (num)
					{
					}
					if (enumerator9.MoveNext())
					{
						_5 = enumerator9.Current;
						this.$current = _5;
						if (!this.$disposing)
						{
							this.$PC = 5;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable5 = (enumerator9 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				goto IL_A5A;
			default:
				return false;
			}
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
			<CastSkillLogic>c__AnonStorey.totalHealValue = 0.0;
			shieldEnhancement = <CastSkillLogic>c__AnonStorey.skill.SourceUnit.SpecialEffects.OfType<RotationShieldEnhancementData>().FirstOrDefault<RotationShieldEnhancementData>();
			dispelEnhancement = <CastSkillLogic>c__AnonStorey.skill.SourceUnit.SpecialEffects.OfType<RotationDispelEnhancementData>().FirstOrDefault<RotationDispelEnhancementData>();
			attributeDecay = <CastSkillLogic>c__AnonStorey.skill.SourceUnit.SpecialEffects.OfType<RotationAttributeDecayData>().FirstOrDefault<RotationAttributeDecayData>();
			shieldValue = 0.0;
			enumerator3 = releaseable.BattleDamages.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_462:
				switch (num)
				{
				case 2u:
					Block_22:
					try
					{
						switch (num)
						{
						case 2u:
							Block_30:
							try
							{
								switch (num)
								{
								}
								if (enumerator5.MoveNext())
								{
									_2 = enumerator5.Current;
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
									if ((disposable2 = (enumerator5 as IDisposable)) != null)
									{
										disposable2.Dispose();
									}
								}
							}
							break;
						}
						while (enumerator4.MoveNext())
						{
							damage = enumerator4.Current;
							<CastSkillLogic>c__AnonStorey.totalHealValue += damage.GetTotalDamageSoFar() * base.ActiveRecoveryRate(<CastSkillLogic>c__AnonStorey.skill.Skill);
							if (shieldEnhancement != null)
							{
								shieldValue += damage.GetTotalDamageSoFar() * shieldEnhancement.ShieldRate;
							}
							if (dispelEnhancement != null)
							{
								totalDispels += dispelEnhancement.NumberOfDispels;
							}
							if (attributeDecay != null)
							{
								enumerator5 = battleDamage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(<CastSkillLogic>c__AnonStorey.skill.SourceUnit, new List<AttributeModifier>
								{
									new AttributeModifier
									{
										AttributeType = attributeDecay.Type,
										ModificationType = attributeDecay.ModificationType,
										Value = -attributeDecay.Value,
										Key = string.Empty,
										AttributeModifierType = AttributeModifierType.Skill
									}
								}, "rotationdecay", new int?(10), new float?((float)attributeDecay.Seconds), null, true, true), false).GetEnumerator();
								num = 4294967293u;
								goto Block_30;
							}
						}
					}
					finally
					{
						if (!flag)
						{
							if (enumerator4 != null)
							{
								enumerator4.Dispose();
							}
						}
					}
					if (totalDispels <= 0)
					{
						goto IL_7B5;
					}
					enumerator6 = UnitStyleConfigurationBase.DispelPositiveEffects(battleDamage.Target, new int?(totalDispels)).GetEnumerator();
					num = 4294967293u;
					break;
				case 3u:
					break;
				default:
					goto IL_7B5;
				}
				try
				{
					switch (num)
					{
					}
					if (enumerator6.MoveNext())
					{
						_3 = enumerator6.Current;
						this.$current = _3;
						if (!this.$disposing)
						{
							this.$PC = 3;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable3 = (enumerator6 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				IL_7B5:
				if (enumerator3.MoveNext())
				{
					battleDamage = enumerator3.Current;
					totalDispels = 0;
					enumerator4 = (from d in battleDamage.Damages
					where d.IsCrit
					select d).GetEnumerator();
					num = 4294967293u;
					goto Block_22;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			if (shieldEnhancement == null || shieldValue <= 0.0)
			{
				goto IL_93B;
			}
			targets = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(<CastSkillLogic>c__AnonStorey.skill.SourceUnit);
			enumerator7 = targets.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_840:
				switch (num)
				{
				case 4u:
					Block_50:
					try
					{
						switch (num)
						{
						}
						if (enumerator8.MoveNext())
						{
							_4 = enumerator8.Current;
							this.$current = _4;
							if (!this.$disposing)
							{
								this.$PC = 4;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable4 = (enumerator8 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator7.MoveNext())
				{
					battleUnit = enumerator7.Current;
					enumerator8 = DamageAbsorbShieldEffect.AddAborbShieldToTarget(battleUnit, <CastSkillLogic>c__AnonStorey.skill, shieldValue).GetEnumerator();
					num = 4294967293u;
					goto Block_50;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator7).Dispose();
				}
			}
			IL_93B:
			if (<CastSkillLogic>c__AnonStorey.totalHealValue > 0.0)
			{
				targets2 = new TargetDefinition(TargetCandidateType.FriendlyAlive, CandidateOrderringMetric.Random, OrderingType.Nature, null).GetTargets(<CastSkillLogic>c__AnonStorey.skill.SourceUnit);
				releaseableHeal = new ReleaseableHeal((from t in targets2
				select new BattleHeal(t, <CastSkillLogic>c__AnonStorey.skill, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = <CastSkillLogic>c__AnonStorey.totalHealValue,
						HealType = OutputType.RealDamage,
						IsDirectHeal = <CastSkillLogic>c__AnonStorey.skill.SourceUnit.SpecialEffects.OfType<ChubbyLadyStarHealerEnhanceData>().Any<ChubbyLadyStarHealerEnhanceData>()
					}
				}, false)).ToList<BattleHeal>(), <CastSkillLogic>c__AnonStorey.skill.SourceUnit);
				enumerator9 = releaseableHeal.Release().GetEnumerator();
				num = 4294967293u;
				goto Block_10;
			}
			IL_A5A:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001306 RID: 4870
		// (get) Token: 0x06005B23 RID: 23331 RVA: 0x0013E6F4 File Offset: 0x0013CAF4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001307 RID: 4871
		// (get) Token: 0x06005B24 RID: 23332 RVA: 0x0013E6FC File Offset: 0x0013CAFC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B25 RID: 23333 RVA: 0x0013E704 File Offset: 0x0013CB04
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
					if ((disposable = (enumerator2 as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			case 2u:
			case 3u:
				try
				{
					switch (num)
					{
					case 2u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable2 = (enumerator5 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
						finally
						{
							if (enumerator4 != null)
							{
								enumerator4.Dispose();
							}
						}
						break;
					case 3u:
						try
						{
						}
						finally
						{
							if ((disposable3 = (enumerator6 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
				break;
			case 4u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable4 = (enumerator8 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator7).Dispose();
				}
				break;
			case 5u:
				try
				{
				}
				finally
				{
					if ((disposable5 = (enumerator9 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005B26 RID: 23334 RVA: 0x0013E8F4 File Offset: 0x0013CCF4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B27 RID: 23335 RVA: 0x0013E8FB File Offset: 0x0013CCFB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B28 RID: 23336 RVA: 0x0013E904 File Offset: 0x0013CD04
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Rotation.<CastSkillLogic>c__Iterator1 <CastSkillLogic>c__Iterator = new Rotation.<CastSkillLogic>c__Iterator1();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x06005B29 RID: 23337 RVA: 0x0013E950 File Offset: 0x0013CD50
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsCrit;
		}

		// Token: 0x04004C78 RID: 19576
		internal List<BattleDamage> <damages>__0;

		// Token: 0x04004C79 RID: 19577
		internal AdventureUnitSkill skill;

		// Token: 0x04004C7A RID: 19578
		internal double <damageRate>__0;

		// Token: 0x04004C7B RID: 19579
		internal EnhancedChubbyLadyData <enhancement>__0;

		// Token: 0x04004C7C RID: 19580
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004C7D RID: 19581
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004C7E RID: 19582
		internal ReleaseableDamage <releaseable>__0;

		// Token: 0x04004C7F RID: 19583
		internal IEnumerator $locvar1;

		// Token: 0x04004C80 RID: 19584
		internal object <_>__1;

		// Token: 0x04004C81 RID: 19585
		internal IDisposable $locvar2;

		// Token: 0x04004C82 RID: 19586
		internal RotationShieldEnhancementData <shieldEnhancement>__0;

		// Token: 0x04004C83 RID: 19587
		internal RotationDispelEnhancementData <dispelEnhancement>__0;

		// Token: 0x04004C84 RID: 19588
		internal RotationAttributeDecayData <attributeDecay>__0;

		// Token: 0x04004C85 RID: 19589
		internal double <shieldValue>__0;

		// Token: 0x04004C86 RID: 19590
		internal List<BattleDamage>.Enumerator $locvar3;

		// Token: 0x04004C87 RID: 19591
		internal BattleDamage <battleDamage>__2;

		// Token: 0x04004C88 RID: 19592
		internal int <totalDispels>__3;

		// Token: 0x04004C89 RID: 19593
		internal IEnumerator<DamageComponent> $locvar4;

		// Token: 0x04004C8A RID: 19594
		internal DamageComponent <damage>__4;

		// Token: 0x04004C8B RID: 19595
		internal IEnumerator $locvar5;

		// Token: 0x04004C8C RID: 19596
		internal object <_>__5;

		// Token: 0x04004C8D RID: 19597
		internal IDisposable $locvar6;

		// Token: 0x04004C8E RID: 19598
		internal IEnumerator $locvar7;

		// Token: 0x04004C8F RID: 19599
		internal object <_>__6;

		// Token: 0x04004C90 RID: 19600
		internal IDisposable $locvar8;

		// Token: 0x04004C91 RID: 19601
		internal List<IBattleUnit> <targets>__7;

		// Token: 0x04004C92 RID: 19602
		internal List<IBattleUnit>.Enumerator $locvar9;

		// Token: 0x04004C93 RID: 19603
		internal IBattleUnit <battleUnit>__8;

		// Token: 0x04004C94 RID: 19604
		internal IEnumerator $locvarA;

		// Token: 0x04004C95 RID: 19605
		internal object <_>__9;

		// Token: 0x04004C96 RID: 19606
		internal IDisposable $locvarB;

		// Token: 0x04004C97 RID: 19607
		internal List<IBattleUnit> <targets>__10;

		// Token: 0x04004C98 RID: 19608
		internal ReleaseableHeal <releaseableHeal>__10;

		// Token: 0x04004C99 RID: 19609
		internal IEnumerator $locvarC;

		// Token: 0x04004C9A RID: 19610
		internal object <_>__11;

		// Token: 0x04004C9B RID: 19611
		internal IDisposable $locvarD;

		// Token: 0x04004C9C RID: 19612
		internal Rotation $this;

		// Token: 0x04004C9D RID: 19613
		internal object $current;

		// Token: 0x04004C9E RID: 19614
		internal bool $disposing;

		// Token: 0x04004C9F RID: 19615
		internal int $PC;

		// Token: 0x04004CA0 RID: 19616
		private Rotation.<CastSkillLogic>c__Iterator1.<CastSkillLogic>c__AnonStorey4 $locvarE;

		// Token: 0x04004CA1 RID: 19617
		private static Func<DamageComponent, bool> <>f__am$cache0;

		// Token: 0x02000E27 RID: 3623
		private sealed class <CastSkillLogic>c__AnonStorey4
		{
			// Token: 0x06005B2D RID: 23341 RVA: 0x0013E958 File Offset: 0x0013CD58
			public <CastSkillLogic>c__AnonStorey4()
			{
			}

			// Token: 0x06005B2E RID: 23342 RVA: 0x0013E960 File Offset: 0x0013CD60
			internal BattleHeal <>m__0(IBattleUnit t)
			{
				return new BattleHeal(t, this.skill, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = this.totalHealValue,
						HealType = OutputType.RealDamage,
						IsDirectHeal = this.skill.SourceUnit.SpecialEffects.OfType<ChubbyLadyStarHealerEnhanceData>().Any<ChubbyLadyStarHealerEnhanceData>()
					}
				}, false);
			}

			// Token: 0x04004CA8 RID: 19624
			internal AdventureUnitSkill skill;

			// Token: 0x04004CA9 RID: 19625
			internal double totalHealValue;

			// Token: 0x04004CAA RID: 19626
			internal Rotation.<CastSkillLogic>c__Iterator1 <>f__ref$1;
		}
	}
}
