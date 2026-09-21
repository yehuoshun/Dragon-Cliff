using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006C4 RID: 1732
public class GhostlySmoke : ActiveSkillLogicBase
{
	// Token: 0x06002E7F RID: 11903 RVA: 0x00138B0B File Offset: 0x00136F0B
	public GhostlySmoke()
	{
	}

	// Token: 0x06002E80 RID: 11904 RVA: 0x00138B40 File Offset: 0x00136F40
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new GhostlySmokeConfusionTalent(SkillType.GhostlySmoke, 1),
			new TacticTargetAttributeDebuffTalent(SkillType.GhostlySmoke, 2),
			new TacticTargetAttributeDebuffTalent(SkillType.GhostlySmoke, 3)
		};
	}

	// Token: 0x170005FA RID: 1530
	// (get) Token: 0x06002E81 RID: 11905 RVA: 0x00138B87 File Offset: 0x00136F87
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005FB RID: 1531
	// (get) Token: 0x06002E82 RID: 11906 RVA: 0x00138B8F File Offset: 0x00136F8F
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005FC RID: 1532
	// (get) Token: 0x06002E83 RID: 11907 RVA: 0x00138B97 File Offset: 0x00136F97
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005FD RID: 1533
	// (get) Token: 0x06002E84 RID: 11908 RVA: 0x00138B9F File Offset: 0x00136F9F
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002E85 RID: 11909 RVA: 0x00138BA7 File Offset: 0x00136FA7
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<HostileAllStrategy>();
	}

	// Token: 0x06002E86 RID: 11910 RVA: 0x00138BAE File Offset: 0x00136FAE
	public override double GetGaugeCost(Skill skill)
	{
		return 55.0;
	}

	// Token: 0x06002E87 RID: 11911 RVA: 0x00138BB9 File Offset: 0x00136FB9
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(2f);
	}

	// Token: 0x06002E88 RID: 11912 RVA: 0x00138BC5 File Offset: 0x00136FC5
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new HostileAllStrategy(skill);
	}

	// Token: 0x06002E89 RID: 11913 RVA: 0x00138BCD File Offset: 0x00136FCD
	private double SpeedDecreaseRate(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06002E8A RID: 11914 RVA: 0x00138BEC File Offset: 0x00136FEC
	private double ConfusionRate(Skill skill)
	{
		return 0.7;
	}

	// Token: 0x06002E8B RID: 11915 RVA: 0x00138BF7 File Offset: 0x00136FF7
	private double PassiveChance(Skill skill)
	{
		return 0.05 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06002E8C RID: 11916 RVA: 0x00138C18 File Offset: 0x00137018
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.DecreaseRateKey, this.SpeedDecreaseRate(skill).ToExpressionMultiply100()).Replace(this.PossibilityKey, this.ConfusionRate(skill).ToExpressionMultiply100()).ToString();
		description.Details2 = description.Details2.Replace(this.PossibilityKey, this.PassiveChance(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002E8D RID: 11917 RVA: 0x00138C88 File Offset: 0x00137088
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		List<IBattleUnit> selectedConfusionTargets = new List<IBattleUnit>();
		GhostlySmokeConfusionEnhancementData enhancement = skill.SourceUnit.SpecialEffects.OfType<GhostlySmokeConfusionEnhancementData>().FirstOrDefault<GhostlySmokeConfusionEnhancementData>();
		GhostSmokeBoostData resilienceDebuff = skill.SourceUnit.SpecialEffects.OfType<GhostSmokeBoostData>().FirstOrDefault<GhostSmokeBoostData>();
		foreach (IBattleUnit strategySelection in strategy.Selections)
		{
			List<AttributeModifier> modifiers = new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Agility,
					ModificationType = ModificationType.Multiplication,
					Value = -this.SpeedDecreaseRate(skill.Skill),
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			};
			if (resilienceDebuff != null)
			{
				modifiers.Add(new AttributeModifier
				{
					AttributeType = AttributeType.Resilience,
					ModificationType = ModificationType.Multiplication,
					Value = -resilienceDebuff.Rate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				});
			}
			IEnumerator enumerator2 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, modifiers, "ghostlysmoke", new int?(1), new float?(5f), null, true, true), false).GetEnumerator();
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
			if (enhancement != null)
			{
				if ((double)UnityEngine.Random.value <= enhancement.Chance)
				{
					selectedConfusionTargets.Add(strategySelection);
				}
			}
			else if ((double)UnityEngine.Random.value <= this.ConfusionRate(skill.Skill))
			{
				selectedConfusionTargets.Add(strategySelection);
			}
		}
		foreach (IBattleUnit battleUnit in from t in selectedConfusionTargets
		where t.Status == BattleUnitStatus.Active
		select t)
		{
			if (battleUnit.BattleEffects.OfType<LockTimeEffect>().Any<LockTimeEffect>())
			{
				IEnumerator enumerator4 = UnitStyleConfigurationBase.DispelPositiveEffects(battleUnit, new int?(3)).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _2 = enumerator4.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator4 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			else
			{
				IEnumerator enumerator5 = LockTimeEffect.AddStunSeconds(battleUnit, (enhancement == null) ? 2f : ((float)enhancement.Time), skill, false).GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						object _3 = enumerator5.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator5 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06002E8E RID: 11918 RVA: 0x00138CBC File Offset: 0x001370BC
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.DamageReleased
		};
	}

	// Token: 0x06002E8F RID: 11919 RVA: 0x00138CD8 File Offset: 0x001370D8
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.DamageReleased && data is ReleaseableDamage && eventTriggerUnit == skillOwner)
		{
			ReleaseableDamage damage = data as ReleaseableDamage;
			if (damage.Dealer == processingSkill.SourceUnit)
			{
				foreach (BattleDamage battleDamage in damage.BattleDamages)
				{
					if (battleDamage.Target.IsAliveInBattle())
					{
						bool canStun = false;
						foreach (DamageComponent damageComponent in battleDamage.Damages)
						{
							if (!canStun && (double)UnityEngine.Random.value <= this.PassiveChance(processingSkill.Skill))
							{
								canStun = true;
							}
						}
						if (canStun)
						{
							IEnumerator enumerator3 = LockTimeEffect.AddStunSeconds(battleDamage.Target, 2f, processingSkill, false).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x04002710 RID: 10000
	private SkillCategory _skillCategory = SkillCategory.Offensive;

	// Token: 0x04002711 RID: 10001
	private OutputType _skillOutputType = OutputType.Physical;

	// Token: 0x04002712 RID: 10002
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x04002713 RID: 10003
	private SkillType _skillType = SkillType.GhostlySmoke;

	// Token: 0x04002714 RID: 10004
	private readonly string _GhostSmokeActiveCastKey = "GhostSmokeActiveCast";

	// Token: 0x02000E14 RID: 3604
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005AA0 RID: 23200 RVA: 0x00138D20 File Offset: 0x00137120
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005AA1 RID: 23201 RVA: 0x00138D28 File Offset: 0x00137128
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				selectedConfusionTargets = new List<IBattleUnit>();
				enhancement = skill.SourceUnit.SpecialEffects.OfType<GhostlySmokeConfusionEnhancementData>().FirstOrDefault<GhostlySmokeConfusionEnhancementData>();
				resilienceDebuff = skill.SourceUnit.SpecialEffects.OfType<GhostSmokeBoostData>().FirstOrDefault<GhostSmokeBoostData>();
				enumerator = strategy.Selections.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
			case 3u:
				goto IL_2FA;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_7:
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
					if (enhancement != null)
					{
						if ((double)UnityEngine.Random.value <= enhancement.Chance)
						{
							selectedConfusionTargets.Add(strategySelection);
						}
					}
					else if ((double)UnityEngine.Random.value <= base.ConfusionRate(skill.Skill))
					{
						selectedConfusionTargets.Add(strategySelection);
					}
					break;
				}
				if (enumerator.MoveNext())
				{
					strategySelection = enumerator.Current;
					modifiers = new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.Agility,
							ModificationType = ModificationType.Multiplication,
							Value = -base.SpeedDecreaseRate(skill.Skill),
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					};
					if (resilienceDebuff != null)
					{
						modifiers.Add(new AttributeModifier
						{
							AttributeType = AttributeType.Resilience,
							ModificationType = ModificationType.Multiplication,
							Value = -resilienceDebuff.Rate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						});
					}
					enumerator2 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, modifiers, "ghostlysmoke", new int?(1), new float?(5f), null, true, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_7;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			enumerator3 = (from t in selectedConfusionTargets
			where t.Status == BattleUnitStatus.Active
			select t).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_2FA:
				switch (num)
				{
				case 2u:
					Block_22:
					try
					{
						switch (num)
						{
						}
						if (enumerator4.MoveNext())
						{
							_2 = enumerator4.Current;
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
							if ((disposable2 = (enumerator4 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					break;
				case 3u:
					Block_24:
					try
					{
						switch (num)
						{
						}
						if (enumerator5.MoveNext())
						{
							_3 = enumerator5.Current;
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
							if ((disposable3 = (enumerator5 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
					break;
				}
				if (enumerator3.MoveNext())
				{
					battleUnit = enumerator3.Current;
					if (battleUnit.BattleEffects.OfType<LockTimeEffect>().Any<LockTimeEffect>())
					{
						enumerator4 = UnitStyleConfigurationBase.DispelPositiveEffects(battleUnit, new int?(3)).GetEnumerator();
						num = 4294967293u;
						goto Block_22;
					}
					enumerator5 = LockTimeEffect.AddStunSeconds(battleUnit, (enhancement == null) ? 2f : ((float)enhancement.Time), skill, false).GetEnumerator();
					num = 4294967293u;
					goto Block_24;
				}
			}
			finally
			{
				if (!flag)
				{
					if (enumerator3 != null)
					{
						enumerator3.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012E8 RID: 4840
		// (get) Token: 0x06005AA2 RID: 23202 RVA: 0x00139294 File Offset: 0x00137694
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012E9 RID: 4841
		// (get) Token: 0x06005AA3 RID: 23203 RVA: 0x0013929C File Offset: 0x0013769C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005AA4 RID: 23204 RVA: 0x001392A4 File Offset: 0x001376A4
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
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
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
						}
						finally
						{
							if ((disposable2 = (enumerator4 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
						break;
					case 3u:
						try
						{
						}
						finally
						{
							if ((disposable3 = (enumerator5 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					if (enumerator3 != null)
					{
						enumerator3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005AA5 RID: 23205 RVA: 0x001393F4 File Offset: 0x001377F4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005AA6 RID: 23206 RVA: 0x001393FB File Offset: 0x001377FB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005AA7 RID: 23207 RVA: 0x00139404 File Offset: 0x00137804
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GhostlySmoke.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new GhostlySmoke.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x06005AA8 RID: 23208 RVA: 0x00139450 File Offset: 0x00137850
		private static bool <>m__0(IBattleUnit t)
		{
			return t.Status == BattleUnitStatus.Active;
		}

		// Token: 0x04004B7A RID: 19322
		internal List<IBattleUnit> <selectedConfusionTargets>__0;

		// Token: 0x04004B7B RID: 19323
		internal AdventureUnitSkill skill;

		// Token: 0x04004B7C RID: 19324
		internal GhostlySmokeConfusionEnhancementData <enhancement>__0;

		// Token: 0x04004B7D RID: 19325
		internal GhostSmokeBoostData <resilienceDebuff>__0;

		// Token: 0x04004B7E RID: 19326
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004B7F RID: 19327
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004B80 RID: 19328
		internal IBattleUnit <strategySelection>__1;

		// Token: 0x04004B81 RID: 19329
		internal List<AttributeModifier> <modifiers>__2;

		// Token: 0x04004B82 RID: 19330
		internal IEnumerator $locvar1;

		// Token: 0x04004B83 RID: 19331
		internal object <_>__3;

		// Token: 0x04004B84 RID: 19332
		internal IDisposable $locvar2;

		// Token: 0x04004B85 RID: 19333
		internal IEnumerator<IBattleUnit> $locvar3;

		// Token: 0x04004B86 RID: 19334
		internal IBattleUnit <battleUnit>__4;

		// Token: 0x04004B87 RID: 19335
		internal IEnumerator $locvar4;

		// Token: 0x04004B88 RID: 19336
		internal object <_>__5;

		// Token: 0x04004B89 RID: 19337
		internal IDisposable $locvar5;

		// Token: 0x04004B8A RID: 19338
		internal IEnumerator $locvar6;

		// Token: 0x04004B8B RID: 19339
		internal object <_>__6;

		// Token: 0x04004B8C RID: 19340
		internal IDisposable $locvar7;

		// Token: 0x04004B8D RID: 19341
		internal GhostlySmoke $this;

		// Token: 0x04004B8E RID: 19342
		internal object $current;

		// Token: 0x04004B8F RID: 19343
		internal bool $disposing;

		// Token: 0x04004B90 RID: 19344
		internal int $PC;

		// Token: 0x04004B91 RID: 19345
		private static Func<IBattleUnit, bool> <>f__am$cache0;
	}

	// Token: 0x02000E15 RID: 3605
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005AA9 RID: 23209 RVA: 0x0013945B File Offset: 0x0013785B
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator1()
		{
		}

		// Token: 0x06005AAA RID: 23210 RVA: 0x00139464 File Offset: 0x00137864
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.DamageReleased || !(data is ReleaseableDamage) || eventTriggerUnit != skillOwner)
				{
					goto IL_237;
				}
				damage = (data as ReleaseableDamage);
				if (damage.Dealer != processingSkill.SourceUnit)
				{
					goto IL_237;
				}
				enumerator = damage.BattleDamages.GetEnumerator();
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
				case 1u:
					Block_11:
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
					break;
				}
				while (enumerator.MoveNext())
				{
					battleDamage = enumerator.Current;
					if (battleDamage.Target.IsAliveInBattle())
					{
						canStun = false;
						enumerator2 = battleDamage.Damages.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								DamageComponent damageComponent = enumerator2.Current;
								if (!canStun && (double)UnityEngine.Random.value <= base.PassiveChance(processingSkill.Skill))
								{
									canStun = true;
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2).Dispose();
						}
						if (canStun)
						{
							enumerator3 = LockTimeEffect.AddStunSeconds(battleDamage.Target, 2f, processingSkill, false).GetEnumerator();
							num = 4294967293u;
							goto Block_11;
						}
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_237:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012EA RID: 4842
		// (get) Token: 0x06005AAB RID: 23211 RVA: 0x00139700 File Offset: 0x00137B00
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012EB RID: 4843
		// (get) Token: 0x06005AAC RID: 23212 RVA: 0x00139708 File Offset: 0x00137B08
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005AAD RID: 23213 RVA: 0x00139710 File Offset: 0x00137B10
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
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005AAE RID: 23214 RVA: 0x001397A4 File Offset: 0x00137BA4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005AAF RID: 23215 RVA: 0x001397AB File Offset: 0x00137BAB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005AB0 RID: 23216 RVA: 0x001397B4 File Offset: 0x00137BB4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GhostlySmoke.<PassiveBeingActiveEventProcess>c__Iterator1 <PassiveBeingActiveEventProcess>c__Iterator = new GhostlySmoke.<PassiveBeingActiveEventProcess>c__Iterator1();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.data = data;
			<PassiveBeingActiveEventProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<PassiveBeingActiveEventProcess>c__Iterator.skillOwner = skillOwner;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x04004B92 RID: 19346
		internal AdventureEventType eventType;

		// Token: 0x04004B93 RID: 19347
		internal object data;

		// Token: 0x04004B94 RID: 19348
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004B95 RID: 19349
		internal IBattleUnit skillOwner;

		// Token: 0x04004B96 RID: 19350
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04004B97 RID: 19351
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004B98 RID: 19352
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04004B99 RID: 19353
		internal BattleDamage <battleDamage>__2;

		// Token: 0x04004B9A RID: 19354
		internal bool <canStun>__3;

		// Token: 0x04004B9B RID: 19355
		internal List<DamageComponent>.Enumerator $locvar1;

		// Token: 0x04004B9C RID: 19356
		internal IEnumerator $locvar2;

		// Token: 0x04004B9D RID: 19357
		internal object <_>__4;

		// Token: 0x04004B9E RID: 19358
		internal IDisposable $locvar3;

		// Token: 0x04004B9F RID: 19359
		internal GhostlySmoke $this;

		// Token: 0x04004BA0 RID: 19360
		internal object $current;

		// Token: 0x04004BA1 RID: 19361
		internal bool $disposing;

		// Token: 0x04004BA2 RID: 19362
		internal int $PC;
	}
}
