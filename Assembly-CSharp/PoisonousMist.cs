using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;

// Token: 0x020006C8 RID: 1736
public class PoisonousMist : ActiveSkillLogicBase
{
	// Token: 0x06002EC3 RID: 11971 RVA: 0x0013B874 File Offset: 0x00139C74
	public PoisonousMist()
	{
	}

	// Token: 0x06002EC4 RID: 11972 RVA: 0x0013B898 File Offset: 0x00139C98
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new PoisonMistDispelEnhancementTalent(SkillType.PoisonousMist, 1),
			new TacticTargetAttributeDebuffTalent(SkillType.PoisonousMist, 2),
			new TacticTargetAttributeDebuffTalent(SkillType.PoisonousMist, 3)
		};
	}

	// Token: 0x1700060A RID: 1546
	// (get) Token: 0x06002EC5 RID: 11973 RVA: 0x0013B8DF File Offset: 0x00139CDF
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x1700060B RID: 1547
	// (get) Token: 0x06002EC6 RID: 11974 RVA: 0x0013B8E7 File Offset: 0x00139CE7
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x1700060C RID: 1548
	// (get) Token: 0x06002EC7 RID: 11975 RVA: 0x0013B8EF File Offset: 0x00139CEF
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x1700060D RID: 1549
	// (get) Token: 0x06002EC8 RID: 11976 RVA: 0x0013B8F7 File Offset: 0x00139CF7
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002EC9 RID: 11977 RVA: 0x0013B8FF File Offset: 0x00139CFF
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<HostileAllStrategy>();
	}

	// Token: 0x06002ECA RID: 11978 RVA: 0x0013B906 File Offset: 0x00139D06
	public override double GetGaugeCost(Skill skill)
	{
		return 50.0;
	}

	// Token: 0x06002ECB RID: 11979 RVA: 0x0013B911 File Offset: 0x00139D11
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002ECC RID: 11980 RVA: 0x0013B91D File Offset: 0x00139D1D
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new HostileAllStrategy(skill);
	}

	// Token: 0x06002ECD RID: 11981 RVA: 0x0013B925 File Offset: 0x00139D25
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002ECE RID: 11982 RVA: 0x0013B92C File Offset: 0x00139D2C
	private double ActiveReductionRate(Skill skill)
	{
		return 0.6 + (double)(skill.Level - 1) * 0.2;
	}

	// Token: 0x06002ECF RID: 11983 RVA: 0x0013B94B File Offset: 0x00139D4B
	private double PassiveReduction(Skill skill)
	{
		return 0.1 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x06002ED0 RID: 11984 RVA: 0x0013B96C File Offset: 0x00139D6C
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.HealReceivedReductionRateKey, this.ActiveReductionRate(skill).ToExpressionMultiply100()).Replace(this.MainDamageRateKey, this.ActiveDamageRate(skill).ToExpressionMultiply100());
		description.Details2 = description.Details2.Replace(this.HealReceivedReductionRateKey, this.PassiveReduction(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002ED1 RID: 11985 RVA: 0x0013B9D7 File Offset: 0x00139DD7
	private double ActiveDamageRate(Skill skill)
	{
		return 0.5 + (double)(skill.Level - 1) * 0.3;
	}

	// Token: 0x06002ED2 RID: 11986 RVA: 0x0013B9F8 File Offset: 0x00139DF8
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		List<BattleDamage> damages = new List<BattleDamage>();
		PoisonMistDispelEnhancementData dispel = skill.SourceUnit.SpecialEffects.OfType<PoisonMistDispelEnhancementData>().FirstOrDefault<PoisonMistDispelEnhancementData>();
		PoisonMistBoostData poisonMistBoostData = skill.SourceUnit.SpecialEffects.OfType<PoisonMistBoostData>().FirstOrDefault<PoisonMistBoostData>();
		bool isStar = skill.SourceUnit.SpecialEffects.OfType<NightBladeStarHealReductionBoostData>().Any<NightBladeStarHealReductionBoostData>();
		double damageRate = this.ActiveDamageRate(skill.Skill);
		if (poisonMistBoostData != null)
		{
			damageRate += poisonMistBoostData.DamageBoost;
		}
		NightBladeEnhancementData enhancedBlade = skill.SourceUnit.SpecialEffects.OfType<NightBladeEnhancementData>().FirstOrDefault<NightBladeEnhancementData>();
		foreach (IBattleUnit strategySelection in strategy.Selections)
		{
			if (dispel != null)
			{
				List<BattleEffectBase> shields = (from ef in strategySelection.BattleEffects
				where ef is DamageNeutralizationEffect || ef is DamageImmuneEffect || ef is ReflectiveShieldEffect
				select ef).Take(dispel.NumberOfDispelShields).ToList<BattleEffectBase>();
				foreach (BattleEffectBase shield in shields)
				{
					IEnumerator enumerator3 = strategySelection.LooseSkillEffect(shield, EffectWearsOffType.Dispersed).GetEnumerator();
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
			IEnumerator enumerator4 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateHealingReductionEffect(base.GetType().FullName, null, new float?(6f), this.ActiveReductionRate(skill.Skill), skill, !isStar), false).GetEnumerator();
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
			if (enhancedBlade != null)
			{
				IEnumerator enumerator5 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.EffectHitRating,
						ModificationType = ModificationType.Multiplication,
						Value = -enhancedBlade.EffectHitDecayRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "uniquebladeeffectdecay", new int?(1), new float?(6f), null, !isStar, true), false).GetEnumerator();
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
			if (poisonMistBoostData != null)
			{
				IEnumerator enumerator6 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.DodgeRateAdjustment,
						ModificationType = ModificationType.Addition,
						Value = -poisonMistBoostData.DodgeDeductionRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "uniquepoisonmist", new int?(1), new float?(8f), null, !isStar, true), false).GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						object _4 = enumerator6.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator6 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			damages.Add(new BattleDamage(strategySelection, skill, new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(skill.SourceUnit, strategySelection, OutputType.Poison, damageRate)
				}, strategySelection, skill.SourceUnit, true, false)
			}));
		}
		ReleaseableDamage rs = new ReleaseableDamage(damages, skill.SourceUnit);
		IEnumerator enumerator7 = rs.Release().GetEnumerator();
		try
		{
			while (enumerator7.MoveNext())
			{
				object _5 = enumerator7.Current;
				yield return _5;
			}
		}
		finally
		{
			IDisposable disposable5;
			if ((disposable5 = (enumerator7 as IDisposable)) != null)
			{
				disposable5.Dispose();
			}
		}
		yield break;
	}

	// Token: 0x06002ED3 RID: 11987 RVA: 0x0013BA2C File Offset: 0x00139E2C
	public override IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		List<IBattleUnit> targets = skill.SourceUnit.GetLiveEnemyTargets(false, true);
		bool isStar = skill.SourceUnit.SpecialEffects.OfType<NightBladeStarHealReductionBoostData>().Any<NightBladeStarHealReductionBoostData>();
		foreach (IBattleUnit battleUnit in targets)
		{
			IEnumerator enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateHealingReductionEffect(base.GetType().FullName + "passive", null, null, this.PassiveReduction(skill.Skill), skill, !isStar), false).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x06002ED4 RID: 11988 RVA: 0x0013BA58 File Offset: 0x00139E58
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		List<IBattleUnit> targets = skill.SourceUnit.GetLiveEnemyTargets(false, true);
		foreach (IBattleUnit battleUnit in targets)
		{
			List<AttributeModificationEffect> tobeRemoved = (from ef in battleUnit.BattleEffects.OfType<AttributeModificationEffect>()
			where ef.EffectSourceIdentityCode == base.GetType().FullName + "passive"
			select ef).ToList<AttributeModificationEffect>();
			foreach (AttributeModificationEffect healingReductionEffect in tobeRemoved)
			{
				IEnumerator enumerator3 = battleUnit.LooseSkillEffect(healingReductionEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
		yield break;
	}

	// Token: 0x04002721 RID: 10017
	private SkillCategory _skillCategory = SkillCategory.Supportive;

	// Token: 0x04002722 RID: 10018
	private OutputType _skillOutputType;

	// Token: 0x04002723 RID: 10019
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x04002724 RID: 10020
	private SkillType _skillType = SkillType.PoisonousMist;

	// Token: 0x02000E1E RID: 3614
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005AEF RID: 23279 RVA: 0x0013BA82 File Offset: 0x00139E82
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005AF0 RID: 23280 RVA: 0x0013BA8C File Offset: 0x00139E8C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damages = new List<BattleDamage>();
				dispel = skill.SourceUnit.SpecialEffects.OfType<PoisonMistDispelEnhancementData>().FirstOrDefault<PoisonMistDispelEnhancementData>();
				poisonMistBoostData = skill.SourceUnit.SpecialEffects.OfType<PoisonMistBoostData>().FirstOrDefault<PoisonMistBoostData>();
				isStar = skill.SourceUnit.SpecialEffects.OfType<NightBladeStarHealReductionBoostData>().Any<NightBladeStarHealReductionBoostData>();
				damageRate = base.ActiveDamageRate(skill.Skill);
				if (poisonMistBoostData != null)
				{
					damageRate += poisonMistBoostData.DamageBoost;
				}
				enhancedBlade = skill.SourceUnit.SpecialEffects.OfType<NightBladeEnhancementData>().FirstOrDefault<NightBladeEnhancementData>();
				enumerator = strategy.Selections.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
			case 3u:
			case 4u:
				break;
			case 5u:
				goto IL_6BA;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_8:
					try
					{
						switch (num)
						{
						case 1u:
							Block_16:
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
						if (enumerator2.MoveNext())
						{
							shield = enumerator2.Current;
							enumerator3 = strategySelection.LooseSkillEffect(shield, EffectWearsOffType.Dispersed).GetEnumerator();
							num = 4294967293u;
							goto Block_16;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					break;
				case 2u:
					Block_9:
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
					if (enhancedBlade != null)
					{
						enumerator5 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = AttributeType.EffectHitRating,
								ModificationType = ModificationType.Multiplication,
								Value = -enhancedBlade.EffectHitDecayRate,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}
						}, "uniquebladeeffectdecay", new int?(1), new float?(6f), null, !isStar, true), false).GetEnumerator();
						num = 4294967293u;
						goto Block_11;
					}
					goto IL_4B6;
				case 3u:
					goto IL_434;
				case 4u:
					Block_13:
					try
					{
						switch (num)
						{
						}
						if (enumerator6.MoveNext())
						{
							_4 = enumerator6.Current;
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
							if ((disposable4 = (enumerator6 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
					}
					goto IL_5E9;
				default:
					goto IL_65A;
				}
				IL_29A:
				enumerator4 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateHealingReductionEffect(base.GetType().FullName, null, new float?(6f), base.ActiveReductionRate(skill.Skill), skill, !isStar), false).GetEnumerator();
				num = 4294967293u;
				goto Block_9;
				Block_11:
				try
				{
					IL_434:
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
				IL_4B6:
				if (poisonMistBoostData != null)
				{
					enumerator6 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.DodgeRateAdjustment,
							ModificationType = ModificationType.Addition,
							Value = -poisonMistBoostData.DodgeDeductionRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "uniquepoisonmist", new int?(1), new float?(8f), null, !isStar, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_13;
				}
				IL_5E9:
				damages.Add(new BattleDamage(strategySelection, skill, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(skill.SourceUnit, strategySelection, OutputType.Poison, damageRate)
					}, strategySelection, skill.SourceUnit, true, false)
				}));
				IL_65A:
				if (enumerator.MoveNext())
				{
					strategySelection = enumerator.Current;
					if (dispel != null)
					{
						shields = (from ef in strategySelection.BattleEffects
						where ef is DamageNeutralizationEffect || ef is DamageImmuneEffect || ef is ReflectiveShieldEffect
						select ef).Take(dispel.NumberOfDispelShields).ToList<BattleEffectBase>();
						enumerator2 = shields.GetEnumerator();
						num = 4294967293u;
						goto Block_8;
					}
					goto IL_29A;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			rs = new ReleaseableDamage(damages, skill.SourceUnit);
			enumerator7 = rs.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_6BA:
				switch (num)
				{
				}
				if (enumerator7.MoveNext())
				{
					_5 = enumerator7.Current;
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
					if ((disposable5 = (enumerator7 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012FA RID: 4858
		// (get) Token: 0x06005AF1 RID: 23281 RVA: 0x0013C28C File Offset: 0x0013A68C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012FB RID: 4859
		// (get) Token: 0x06005AF2 RID: 23282 RVA: 0x0013C294 File Offset: 0x0013A694
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005AF3 RID: 23283 RVA: 0x0013C29C File Offset: 0x0013A69C
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
			case 3u:
			case 4u:
				try
				{
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
							((IDisposable)enumerator2).Dispose();
						}
						break;
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
					case 4u:
						try
						{
						}
						finally
						{
							if ((disposable4 = (enumerator6 as IDisposable)) != null)
							{
								disposable4.Dispose();
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
			case 5u:
				try
				{
				}
				finally
				{
					if ((disposable5 = (enumerator7 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005AF4 RID: 23284 RVA: 0x0013C46C File Offset: 0x0013A86C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005AF5 RID: 23285 RVA: 0x0013C473 File Offset: 0x0013A873
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005AF6 RID: 23286 RVA: 0x0013C47C File Offset: 0x0013A87C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PoisonousMist.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new PoisonousMist.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x06005AF7 RID: 23287 RVA: 0x0013C4C8 File Offset: 0x0013A8C8
		private static bool <>m__0(BattleEffectBase ef)
		{
			return ef is DamageNeutralizationEffect || ef is DamageImmuneEffect || ef is ReflectiveShieldEffect;
		}

		// Token: 0x04004C0F RID: 19471
		internal List<BattleDamage> <damages>__0;

		// Token: 0x04004C10 RID: 19472
		internal AdventureUnitSkill skill;

		// Token: 0x04004C11 RID: 19473
		internal PoisonMistDispelEnhancementData <dispel>__0;

		// Token: 0x04004C12 RID: 19474
		internal PoisonMistBoostData <poisonMistBoostData>__0;

		// Token: 0x04004C13 RID: 19475
		internal bool <isStar>__0;

		// Token: 0x04004C14 RID: 19476
		internal double <damageRate>__0;

		// Token: 0x04004C15 RID: 19477
		internal NightBladeEnhancementData <enhancedBlade>__0;

		// Token: 0x04004C16 RID: 19478
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004C17 RID: 19479
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004C18 RID: 19480
		internal IBattleUnit <strategySelection>__1;

		// Token: 0x04004C19 RID: 19481
		internal List<BattleEffectBase> <shields>__2;

		// Token: 0x04004C1A RID: 19482
		internal List<BattleEffectBase>.Enumerator $locvar1;

		// Token: 0x04004C1B RID: 19483
		internal BattleEffectBase <shield>__3;

		// Token: 0x04004C1C RID: 19484
		internal IEnumerator $locvar2;

		// Token: 0x04004C1D RID: 19485
		internal object <_>__4;

		// Token: 0x04004C1E RID: 19486
		internal IDisposable $locvar3;

		// Token: 0x04004C1F RID: 19487
		internal IEnumerator $locvar4;

		// Token: 0x04004C20 RID: 19488
		internal object <_>__5;

		// Token: 0x04004C21 RID: 19489
		internal IDisposable $locvar5;

		// Token: 0x04004C22 RID: 19490
		internal IEnumerator $locvar6;

		// Token: 0x04004C23 RID: 19491
		internal object <_>__6;

		// Token: 0x04004C24 RID: 19492
		internal IDisposable $locvar7;

		// Token: 0x04004C25 RID: 19493
		internal IEnumerator $locvar8;

		// Token: 0x04004C26 RID: 19494
		internal object <_>__7;

		// Token: 0x04004C27 RID: 19495
		internal IDisposable $locvar9;

		// Token: 0x04004C28 RID: 19496
		internal ReleaseableDamage <rs>__0;

		// Token: 0x04004C29 RID: 19497
		internal IEnumerator $locvarA;

		// Token: 0x04004C2A RID: 19498
		internal object <_>__8;

		// Token: 0x04004C2B RID: 19499
		internal IDisposable $locvarB;

		// Token: 0x04004C2C RID: 19500
		internal PoisonousMist $this;

		// Token: 0x04004C2D RID: 19501
		internal object $current;

		// Token: 0x04004C2E RID: 19502
		internal bool $disposing;

		// Token: 0x04004C2F RID: 19503
		internal int $PC;

		// Token: 0x04004C30 RID: 19504
		private static Func<BattleEffectBase, bool> <>f__am$cache0;
	}

	// Token: 0x02000E1F RID: 3615
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005AF8 RID: 23288 RVA: 0x0013C4EC File Offset: 0x0013A8EC
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator1()
		{
		}

		// Token: 0x06005AF9 RID: 23289 RVA: 0x0013C4F4 File Offset: 0x0013A8F4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targets = skill.SourceUnit.GetLiveEnemyTargets(false, true);
				isStar = skill.SourceUnit.SpecialEffects.OfType<NightBladeStarHealReductionBoostData>().Any<NightBladeStarHealReductionBoostData>();
				enumerator = targets.GetEnumerator();
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
					Block_4:
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
					break;
				}
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					enumerator2 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateHealingReductionEffect(base.GetType().FullName + "passive", null, null, base.PassiveReduction(skill.Skill), skill, !isStar), false).GetEnumerator();
					num = 4294967293u;
					goto Block_4;
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

		// Token: 0x170012FC RID: 4860
		// (get) Token: 0x06005AFA RID: 23290 RVA: 0x0013C6F0 File Offset: 0x0013AAF0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012FD RID: 4861
		// (get) Token: 0x06005AFB RID: 23291 RVA: 0x0013C6F8 File Offset: 0x0013AAF8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005AFC RID: 23292 RVA: 0x0013C700 File Offset: 0x0013AB00
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
			}
		}

		// Token: 0x06005AFD RID: 23293 RVA: 0x0013C794 File Offset: 0x0013AB94
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005AFE RID: 23294 RVA: 0x0013C79B File Offset: 0x0013AB9B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005AFF RID: 23295 RVA: 0x0013C7A4 File Offset: 0x0013ABA4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PoisonousMist.<PassiveEffectApplies>c__Iterator1 <PassiveEffectApplies>c__Iterator = new PoisonousMist.<PassiveEffectApplies>c__Iterator1();
			<PassiveEffectApplies>c__Iterator.$this = this;
			<PassiveEffectApplies>c__Iterator.skill = skill;
			return <PassiveEffectApplies>c__Iterator;
		}

		// Token: 0x04004C31 RID: 19505
		internal AdventureUnitSkill skill;

		// Token: 0x04004C32 RID: 19506
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x04004C33 RID: 19507
		internal bool <isStar>__0;

		// Token: 0x04004C34 RID: 19508
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004C35 RID: 19509
		internal IBattleUnit <battleUnit>__1;

		// Token: 0x04004C36 RID: 19510
		internal IEnumerator $locvar1;

		// Token: 0x04004C37 RID: 19511
		internal object <_>__2;

		// Token: 0x04004C38 RID: 19512
		internal IDisposable $locvar2;

		// Token: 0x04004C39 RID: 19513
		internal PoisonousMist $this;

		// Token: 0x04004C3A RID: 19514
		internal object $current;

		// Token: 0x04004C3B RID: 19515
		internal bool $disposing;

		// Token: 0x04004C3C RID: 19516
		internal int $PC;
	}

	// Token: 0x02000E20 RID: 3616
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B00 RID: 23296 RVA: 0x0013C7E4 File Offset: 0x0013ABE4
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator2()
		{
		}

		// Token: 0x06005B01 RID: 23297 RVA: 0x0013C7EC File Offset: 0x0013ABEC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				targets = skill.SourceUnit.GetLiveEnemyTargets(false, true);
				enumerator = targets.GetEnumerator();
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
					Block_4:
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
						if (enumerator2.MoveNext())
						{
							healingReductionEffect = enumerator2.Current;
							enumerator3 = battleUnit.LooseSkillEffect(healingReductionEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
							num = 4294967293u;
							goto Block_7;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					break;
				}
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					tobeRemoved = (from ef in battleUnit.BattleEffects.OfType<AttributeModificationEffect>()
					where ef.EffectSourceIdentityCode == base.GetType().FullName + "passive"
					select ef).ToList<AttributeModificationEffect>();
					enumerator2 = tobeRemoved.GetEnumerator();
					num = 4294967293u;
					goto Block_4;
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

		// Token: 0x170012FE RID: 4862
		// (get) Token: 0x06005B02 RID: 23298 RVA: 0x0013CA1C File Offset: 0x0013AE1C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012FF RID: 4863
		// (get) Token: 0x06005B03 RID: 23299 RVA: 0x0013CA24 File Offset: 0x0013AE24
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B04 RID: 23300 RVA: 0x0013CA2C File Offset: 0x0013AE2C
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
						((IDisposable)enumerator2).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005B05 RID: 23301 RVA: 0x0013CAE4 File Offset: 0x0013AEE4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B06 RID: 23302 RVA: 0x0013CAEB File Offset: 0x0013AEEB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B07 RID: 23303 RVA: 0x0013CAF4 File Offset: 0x0013AEF4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PoisonousMist.<PassiveEffectLooses>c__Iterator2 <PassiveEffectLooses>c__Iterator = new PoisonousMist.<PassiveEffectLooses>c__Iterator2();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x06005B08 RID: 23304 RVA: 0x0013CB34 File Offset: 0x0013AF34
		internal bool <>m__0(AttributeModificationEffect ef)
		{
			return ef.EffectSourceIdentityCode == base.GetType().FullName + "passive";
		}

		// Token: 0x04004C3D RID: 19517
		internal AdventureUnitSkill skill;

		// Token: 0x04004C3E RID: 19518
		internal List<IBattleUnit> <targets>__0;

		// Token: 0x04004C3F RID: 19519
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004C40 RID: 19520
		internal IBattleUnit <battleUnit>__1;

		// Token: 0x04004C41 RID: 19521
		internal List<AttributeModificationEffect> <tobeRemoved>__2;

		// Token: 0x04004C42 RID: 19522
		internal List<AttributeModificationEffect>.Enumerator $locvar1;

		// Token: 0x04004C43 RID: 19523
		internal AttributeModificationEffect <healingReductionEffect>__3;

		// Token: 0x04004C44 RID: 19524
		internal IEnumerator $locvar2;

		// Token: 0x04004C45 RID: 19525
		internal object <_>__4;

		// Token: 0x04004C46 RID: 19526
		internal IDisposable $locvar3;

		// Token: 0x04004C47 RID: 19527
		internal PoisonousMist $this;

		// Token: 0x04004C48 RID: 19528
		internal object $current;

		// Token: 0x04004C49 RID: 19529
		internal bool $disposing;

		// Token: 0x04004C4A RID: 19530
		internal int $PC;
	}
}
