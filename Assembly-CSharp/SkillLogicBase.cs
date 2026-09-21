using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200077A RID: 1914
public abstract class SkillLogicBase
{
	// Token: 0x06003873 RID: 14451 RVA: 0x00129230 File Offset: 0x00127630
	protected SkillLogicBase()
	{
	}

	// Token: 0x17000ACC RID: 2764
	// (get) Token: 0x06003874 RID: 14452
	public abstract CastingStyle CastingStyle { get; }

	// Token: 0x17000ACD RID: 2765
	// (get) Token: 0x06003875 RID: 14453
	public abstract SkillCategory SkillCategory { get; }

	// Token: 0x17000ACE RID: 2766
	// (get) Token: 0x06003876 RID: 14454
	public abstract OutputType SkillOutputType { get; }

	// Token: 0x17000ACF RID: 2767
	// (get) Token: 0x06003877 RID: 14455
	public abstract TargetingType TargetingType { get; }

	// Token: 0x06003878 RID: 14456 RVA: 0x0012947F File Offset: 0x0012787F
	public virtual IDamageDefinition GetDamageDefinition(AdventureUnitSkill skill)
	{
		return null;
	}

	// Token: 0x06003879 RID: 14457 RVA: 0x00129482 File Offset: 0x00127882
	public virtual IHealDefinition GetHealDefinition(AdventureUnitSkill skill)
	{
		return null;
	}

	// Token: 0x0600387A RID: 14458 RVA: 0x00129485 File Offset: 0x00127885
	public int GetMaxLevel()
	{
		if (this.SkillCommandType == SkillCommandType.Main)
		{
			return 9;
		}
		if (this.SkillCommandType == SkillCommandType.Active)
		{
			return 3;
		}
		if (this.SkillCommandType == SkillCommandType.Secondary)
		{
			return 9;
		}
		return 0;
	}

	// Token: 0x0600387B RID: 14459 RVA: 0x001294B3 File Offset: 0x001278B3
	public virtual bool HasMoreLevelToUpgrade(int currentLevel)
	{
		return currentLevel < this.GetMaxLevel();
	}

	// Token: 0x0600387C RID: 14460 RVA: 0x001294C0 File Offset: 0x001278C0
	public List<AdventureEventType> CorrespondingEvents()
	{
		List<AdventureEventType> list = new List<AdventureEventType>
		{
			AdventureEventType.UnitReadyInBattle
		};
		list.AddRange(this.AdditionalRelatedEvents());
		return list.Distinct<AdventureEventType>().ToList<AdventureEventType>();
	}

	// Token: 0x0600387D RID: 14461
	public abstract List<AdventureEventType> AdditionalRelatedEvents();

	// Token: 0x0600387E RID: 14462 RVA: 0x001294F8 File Offset: 0x001278F8
	public virtual List<ResourceConsumptionRequirement> GetLevelUpgradeCost(int currentLevel)
	{
		if (!this.HasMoreLevelToUpgrade(currentLevel))
		{
			return new List<ResourceConsumptionRequirement>();
		}
		if (this.SkillCommandType != SkillCommandType.Main)
		{
			if (this.SkillCommandType == SkillCommandType.Active)
			{
				if (currentLevel == 1)
				{
					return new List<ResourceConsumptionRequirement>
					{
						new ResourceConsumptionRequirement
						{
							ResourceType = ResourceType.Money,
							AmountRequired = 3000
						}
					};
				}
				if (currentLevel == 2)
				{
					return new List<ResourceConsumptionRequirement>
					{
						new ResourceConsumptionRequirement
						{
							ResourceType = ResourceType.Money,
							AmountRequired = 15000
						},
						new ResourceConsumptionRequirement
						{
							ResourceType = ResourceType.PracticePoints,
							AmountRequired = 20000
						},
						new ResourceConsumptionRequirement
						{
							ResourceType = ResourceType.BookFragments,
							AmountRequired = 25
						}
					};
				}
			}
			else if (this.SkillCommandType == SkillCommandType.Secondary)
			{
				if (currentLevel < 3)
				{
					return new List<ResourceConsumptionRequirement>
					{
						new ResourceConsumptionRequirement
						{
							ResourceType = ResourceType.Money,
							AmountRequired = currentLevel * 2000
						}
					};
				}
				if (currentLevel < 6)
				{
					return new List<ResourceConsumptionRequirement>
					{
						new ResourceConsumptionRequirement
						{
							ResourceType = ResourceType.Money,
							AmountRequired = (currentLevel - 2) * 4000
						}
					};
				}
				return new List<ResourceConsumptionRequirement>
				{
					new ResourceConsumptionRequirement
					{
						ResourceType = ResourceType.Money,
						AmountRequired = (currentLevel - 5) * 10000
					},
					new ResourceConsumptionRequirement
					{
						ResourceType = ResourceType.PracticePoints,
						AmountRequired = (currentLevel - 5) * 10000
					},
					new ResourceConsumptionRequirement
					{
						ResourceType = ResourceType.BookFragments,
						AmountRequired = (currentLevel - 5) * 5
					}
				};
			}
			return new List<ResourceConsumptionRequirement>();
		}
		if (currentLevel < 3)
		{
			return new List<ResourceConsumptionRequirement>
			{
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.Money,
					AmountRequired = currentLevel * 2500
				}
			};
		}
		if (currentLevel < 6)
		{
			return new List<ResourceConsumptionRequirement>
			{
				new ResourceConsumptionRequirement
				{
					ResourceType = ResourceType.Money,
					AmountRequired = (currentLevel - 2) * 5000
				}
			};
		}
		return new List<ResourceConsumptionRequirement>
		{
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.Money,
				AmountRequired = (currentLevel - 5) * 12000
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.PracticePoints,
				AmountRequired = (currentLevel - 5) * 10000
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.BookFragments,
				AmountRequired = (currentLevel - 5) * 5
			}
		};
	}

	// Token: 0x0600387F RID: 14463 RVA: 0x001297B4 File Offset: 0x00127BB4
	public virtual IEnumerable Cast(AdventureUnitSkill skill)
	{
		IDamageDefinition damageDefinition = this.GetDamageDefinition(skill);
		if (damageDefinition != null)
		{
			int seed = UnityEngine.Random.Range(0, int.MaxValue);
			UnityEngine.Random.InitState(seed);
			IEnumerator enumerator = this.PriorDamageFormationProcess(damageDefinition.TargetDefinition, skill).GetEnumerator();
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
			UnityEngine.Random.InitState(seed);
			ReleaseableDamage releaseableDamage = damageDefinition.GetReleaseableDamage(skill.SourceUnit, skill);
			IEnumerator enumerator2 = this.PriorDamageProcess(releaseableDamage, skill).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object _2 = enumerator2.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
			IEnumerator enumerator3 = releaseableDamage.Release().GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					object _3 = enumerator3.Current;
					yield return _3;
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator3 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
			double pushRate = skill.GetActiveTalents().OfType<PushOnHitTalent>().Sum((PushOnHitTalent t) => t.GetRate());
			int refreshCounts = (!skill.GetActiveTalents().OfType<NegativeEffectsRefreshTalent>().Any<NegativeEffectsRefreshTalent>()) ? 0 : NegativeEffectsRefreshTalent.Counts;
			List<DispelPositiveEffectOnHitTalent> dispelPositives = skill.GetActiveTalents().OfType<DispelPositiveEffectOnHitTalent>().ToList<DispelPositiveEffectOnHitTalent>();
			List<AttributeDebuffByRateOnHitTalent> debuffOnHitByRate = skill.GetActiveTalents().OfType<AttributeDebuffByRateOnHitTalent>().ToList<AttributeDebuffByRateOnHitTalent>();
			List<AttributeDebuffByValueOnHitTalent> debuffOnHitByValue = skill.GetActiveTalents().OfType<AttributeDebuffByValueOnHitTalent>().ToList<AttributeDebuffByValueOnHitTalent>();
			double selfHealRate = skill.GetActiveTalents().OfType<SelfHealOnKillTalent>().Sum((SelfHealOnKillTalent t) => t.GetHealrate());
			int totalStun = skill.GetActiveTalents().OfType<StunOnDamageTalent>().Sum((StunOnDamageTalent t) => t.GetStunSeconds());
			int dispelOnNotKill = (!skill.GetActiveTalents().OfType<AssassinDispelEnhancementTalent>().Any<AssassinDispelEnhancementTalent>()) ? 0 : AssassinDispelEnhancementTalent.NumberOfDispel;
			int totalKillShields = skill.GetActiveTalents().OfType<ShieldOnKillTalent>().Sum((ShieldOnKillTalent k) => k.GetNumberOfShields());
			List<AttributeBoostMemberOnKillBasedOnSelfRateTalent> memberBoostsByRate = skill.GetActiveTalents().OfType<AttributeBoostMemberOnKillBasedOnSelfRateTalent>().ToList<AttributeBoostMemberOnKillBasedOnSelfRateTalent>();
			List<EmbraceShieldMemberOnKillTalent> memberShields = skill.GetActiveTalents().OfType<EmbraceShieldMemberOnKillTalent>().ToList<EmbraceShieldMemberOnKillTalent>();
			foreach (BattleDamage damage in releaseableDamage.BattleDamages)
			{
				if (damage.Target.IsAliveInBattle())
				{
					if (pushRate > 0.0)
					{
						double topush = pushRate * (double)damage.Damages.Count((DamageComponent d) => d.IsDirectDamage && !d.IsMissed);
						IEnumerator enumerator5 = UnitStyleConfigurationBase.PushTargetProgress(damage.Target, skill.SourceUnit, -topush).GetEnumerator();
						try
						{
							while (enumerator5.MoveNext())
							{
								object _4 = enumerator5.Current;
								yield return _4;
							}
						}
						finally
						{
							IDisposable disposable4;
							if ((disposable4 = (enumerator5 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
					}
					if (refreshCounts > 0)
					{
						int count = refreshCounts * damage.Damages.Count((DamageComponent d) => d.IsDirectDamage && !d.IsMissed);
						List<BattleEffectBase> list = (from ef in damage.Target.BattleEffects
						where ef.BattleEffectNatureForWearer == BattleEffectNature.Negative && (ef.MaxNumberOfLastingSeconds != null || ef.NumberOfLastingTurns != null)
						select ef).ToList<BattleEffectBase>();
						list.Shuffle<BattleEffectBase>();
						List<BattleEffectBase> list2 = list.Take(count).ToList<BattleEffectBase>();
						foreach (BattleEffectBase battleEffectBase in list2)
						{
							battleEffectBase.Refresh();
						}
					}
					foreach (DispelPositiveEffectOnHitTalent dispel in dispelPositives)
					{
						int numberOfEffectiveDamages = damage.Damages.Count((DamageComponent c) => c.IsDirectDamage && !c.IsMissed);
						for (int i = 0; i < numberOfEffectiveDamages; i++)
						{
							if ((double)UnityEngine.Random.value <= dispel.GetChance())
							{
								IEnumerator enumerator8 = UnitStyleConfigurationBase.DispelPositiveEffects(damage.Target, new int?(dispel.GetNumberOfDispels())).GetEnumerator();
								try
								{
									while (enumerator8.MoveNext())
									{
										object _5 = enumerator8.Current;
										yield return _5;
									}
								}
								finally
								{
									IDisposable disposable5;
									if ((disposable5 = (enumerator8 as IDisposable)) != null)
									{
										disposable5.Dispose();
									}
								}
							}
						}
					}
					if (debuffOnHitByRate.Any<AttributeDebuffByRateOnHitTalent>())
					{
						foreach (AttributeDebuffByRateOnHitTalent debuff in debuffOnHitByRate)
						{
							IEnumerator enumerator10 = damage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, (from d in debuff.GetDebuffs()
							select new AttributeModifier
							{
								AttributeType = d.BoostAttribute,
								ModificationType = ModificationType.Multiplication,
								Value = -d.BoostValue,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}).ToList<AttributeModifier>(), skill.Skill.SkillType.ToString() + "talentonhitdebuffbyrate", new int?(debuff.GetMaxStack()), new float?((float)debuff.GetLastingSeconds()), null, true, true), false).GetEnumerator();
							try
							{
								while (enumerator10.MoveNext())
								{
									object _6 = enumerator10.Current;
									yield return _6;
								}
							}
							finally
							{
								IDisposable disposable6;
								if ((disposable6 = (enumerator10 as IDisposable)) != null)
								{
									disposable6.Dispose();
								}
							}
						}
					}
					if (debuffOnHitByValue.Any<AttributeDebuffByValueOnHitTalent>())
					{
						foreach (AttributeDebuffByValueOnHitTalent debuff2 in debuffOnHitByValue)
						{
							IEnumerator enumerator12 = damage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, (from d in debuff2.GetDebuffs()
							select new AttributeModifier
							{
								AttributeType = d.BoostAttribute,
								ModificationType = ModificationType.Addition,
								Value = -d.BoostValue,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}).ToList<AttributeModifier>(), skill.Skill.SkillType.ToString() + "talentonhitdebuffbyvalue", new int?(debuff2.GetMaxStack()), new float?((float)debuff2.GetLastingSeconds()), null, true, true), false).GetEnumerator();
							try
							{
								while (enumerator12.MoveNext())
								{
									object _7 = enumerator12.Current;
									yield return _7;
								}
							}
							finally
							{
								IDisposable disposable7;
								if ((disposable7 = (enumerator12 as IDisposable)) != null)
								{
									disposable7.Dispose();
								}
							}
						}
					}
					if (totalStun > 0)
					{
						IEnumerator enumerator13 = LockTimeEffect.AddStunSeconds(damage.Target, (float)totalStun, skill.SourceUnit, false).GetEnumerator();
						try
						{
							while (enumerator13.MoveNext())
							{
								object _8 = enumerator13.Current;
								yield return _8;
							}
						}
						finally
						{
							IDisposable disposable8;
							if ((disposable8 = (enumerator13 as IDisposable)) != null)
							{
								disposable8.Dispose();
							}
						}
					}
				}
				if (damage.Damages.Any((DamageComponent d) => d.IsFatal != null && d.IsFatal.Value))
				{
					if (skill.GetActiveTalents().OfType<AttributeBoostOnKillTalentByRate>().Any<AttributeBoostOnKillTalentByRate>())
					{
						foreach (AttributeBoostOnKillTalentByRate talent in skill.GetActiveTalents().OfType<AttributeBoostOnKillTalentByRate>())
						{
							IEnumerator enumerator15 = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, (from b in talent.GetBoosts()
							select new AttributeModifier
							{
								AttributeType = b.BoostAttribute,
								ModificationType = ModificationType.Multiplication,
								Value = b.BoostValue,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}).ToList<AttributeModifier>(), "onkillboostskilltalent" + skill.Skill.SkillType, new int?(talent.GetMaxStack()), null, new int?(2), false, true, false), false).GetEnumerator();
							try
							{
								while (enumerator15.MoveNext())
								{
									object _9 = enumerator15.Current;
									yield return _9;
								}
							}
							finally
							{
								IDisposable disposable9;
								if ((disposable9 = (enumerator15 as IDisposable)) != null)
								{
									disposable9.Dispose();
								}
							}
						}
					}
					if (selfHealRate > 0.0)
					{
						ReleaseableHeal selfReleaseable = new ReleaseableHeal(new List<BattleHeal>
						{
							new BattleHeal(skill.SourceUnit, skill.SourceUnit, new List<HealComponentValue>
							{
								new HealComponentValue
								{
									RawHeal = selfHealRate * skill.SourceUnit.GetMaxLife(AttributeRetrievalLevel.Skill),
									HealType = OutputType.RealHeal,
									IsDirectHeal = false
								}
							}, false)
						}, skill.SourceUnit);
						IEnumerator enumerator16 = selfReleaseable.Release().GetEnumerator();
						try
						{
							while (enumerator16.MoveNext())
							{
								object _10 = enumerator16.Current;
								yield return _10;
							}
						}
						finally
						{
							IDisposable disposable10;
							if ((disposable10 = (enumerator16 as IDisposable)) != null)
							{
								disposable10.Dispose();
							}
						}
					}
					if (totalKillShields > 0)
					{
						for (int j = 0; j < totalKillShields; j++)
						{
							IEnumerator enumerator17 = skill.SourceUnit.ApplySkillEffect(new DamageNeutralizationEffect(new int?(1), skill.SourceUnit, true), false).GetEnumerator();
							try
							{
								while (enumerator17.MoveNext())
								{
									object _11 = enumerator17.Current;
									yield return _11;
								}
							}
							finally
							{
								IDisposable disposable11;
								if ((disposable11 = (enumerator17 as IDisposable)) != null)
								{
									disposable11.Dispose();
								}
							}
						}
					}
					if (memberBoostsByRate.Any<AttributeBoostMemberOnKillBasedOnSelfRateTalent>())
					{
						List<IBattleUnit> targets = (from e in skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true)
						where e != skill.SourceUnit
						select e).ToList<IBattleUnit>();
						foreach (IBattleUnit battleUnit in targets)
						{
							IEnumerator enumerator19 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, (from b in memberBoostsByRate
							select new AttributeModifier
							{
								AttributeType = b.GetBoostType(),
								ModificationType = ModificationType.Addition,
								Value = b.GetBoostRate() * skill.SourceUnit.GetAttributeValue_Final(b.GetBoostType(), AttributeRetrievalLevel.Skill),
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}).ToList<AttributeModifier>(), "onkillboostmember" + skill.Skill.SkillType, new int?(3), null, new int?(2), false, true, false), false).GetEnumerator();
							try
							{
								while (enumerator19.MoveNext())
								{
									object _12 = enumerator19.Current;
									yield return _12;
								}
							}
							finally
							{
								IDisposable disposable12;
								if ((disposable12 = (enumerator19 as IDisposable)) != null)
								{
									disposable12.Dispose();
								}
							}
						}
					}
					if (memberShields.Any<EmbraceShieldMemberOnKillTalent>())
					{
						int totalShields = EmbraceShieldMemberOnKillTalent.NumberOfShields;
						IBattleUnit target = (from o in skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true)
						orderby o.HealthPoints / o.GetMaxLife(AttributeRetrievalLevel.Skill)
						select o).FirstOrDefault<IBattleUnit>();
						if (target != null)
						{
							for (int l = 0; l < totalShields; l++)
							{
								IEnumerator enumerator20 = target.ApplySkillEffect(new ReflectiveShieldEffect("shieldonkill", new int?(2), skill.SourceUnit), false).GetEnumerator();
								try
								{
									while (enumerator20.MoveNext())
									{
										object _13 = enumerator20.Current;
										yield return _13;
									}
								}
								finally
								{
									IDisposable disposable13;
									if ((disposable13 = (enumerator20 as IDisposable)) != null)
									{
										disposable13.Dispose();
									}
								}
							}
						}
					}
				}
				else if (dispelOnNotKill > 0)
				{
					IEnumerator enumerator21 = UnitStyleConfigurationBase.DispelPositiveEffects(damage.Target, new int?(dispelOnNotKill)).GetEnumerator();
					try
					{
						while (enumerator21.MoveNext())
						{
							object _14 = enumerator21.Current;
							yield return _14;
						}
					}
					finally
					{
						IDisposable disposable14;
						if ((disposable14 = (enumerator21 as IDisposable)) != null)
						{
							disposable14.Dispose();
						}
					}
				}
			}
			IEnumerator enumerator22 = this.PostDamageProcess(releaseableDamage, skill).GetEnumerator();
			try
			{
				while (enumerator22.MoveNext())
				{
					object _15 = enumerator22.Current;
					yield return _15;
				}
			}
			finally
			{
				IDisposable disposable15;
				if ((disposable15 = (enumerator22 as IDisposable)) != null)
				{
					disposable15.Dispose();
				}
			}
		}
		IHealDefinition healDefinition = this.GetHealDefinition(skill);
		if (healDefinition != null)
		{
			ReleaseableHeal releaseableHeal = healDefinition.GetReleaseableHeal(skill.SourceUnit, skill, skill.GetSkillLogic().SkillOutputType);
			IEnumerator enumerator23 = this.PriorHealProcess(releaseableHeal, skill).GetEnumerator();
			try
			{
				while (enumerator23.MoveNext())
				{
					object _16 = enumerator23.Current;
					yield return _16;
				}
			}
			finally
			{
				IDisposable disposable16;
				if ((disposable16 = (enumerator23 as IDisposable)) != null)
				{
					disposable16.Dispose();
				}
			}
			IEnumerator enumerator24 = releaseableHeal.Release().GetEnumerator();
			try
			{
				while (enumerator24.MoveNext())
				{
					object _17 = enumerator24.Current;
					yield return _17;
				}
			}
			finally
			{
				IDisposable disposable17;
				if ((disposable17 = (enumerator24 as IDisposable)) != null)
				{
					disposable17.Dispose();
				}
			}
			List<AttributeBoostOnHealByRateTalent> attributeBoostOnHealByRate = skill.GetActiveTalents().OfType<AttributeBoostOnHealByRateTalent>().ToList<AttributeBoostOnHealByRateTalent>();
			foreach (BattleHeal releaseableHealBattleHeal in releaseableHeal.BattleHeals)
			{
				if (attributeBoostOnHealByRate.Any<AttributeBoostOnHealByRateTalent>())
				{
					foreach (AttributeBoostOnHealByRateTalent attributeBoostOnHealByRateTalent in attributeBoostOnHealByRate)
					{
						IEnumerator enumerator27 = releaseableHealBattleHeal.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(releaseableHealBattleHeal.Target, (from b in attributeBoostOnHealByRateTalent.GetBoosts()
						select new AttributeModifier
						{
							AttributeType = b.BoostAttribute,
							ModificationType = ModificationType.Multiplication,
							Value = b.BoostValue,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}).ToList<AttributeModifier>(), skill.Skill.SkillType.ToString() + "attributeboostonheal", new int?(attributeBoostOnHealByRateTalent.GetMaxStack()), null, new int?(2), false, true, false), false).GetEnumerator();
						try
						{
							while (enumerator27.MoveNext())
							{
								object _18 = enumerator27.Current;
								yield return _18;
							}
						}
						finally
						{
							IDisposable disposable18;
							if ((disposable18 = (enumerator27 as IDisposable)) != null)
							{
								disposable18.Dispose();
							}
						}
					}
				}
			}
			IEnumerator enumerator28 = this.PostHealProcess(releaseableHeal, skill).GetEnumerator();
			try
			{
				while (enumerator28.MoveNext())
				{
					object _19 = enumerator28.Current;
					yield return _19;
				}
			}
			finally
			{
				IDisposable disposable19;
				if ((disposable19 = (enumerator28 as IDisposable)) != null)
				{
					disposable19.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x06003880 RID: 14464 RVA: 0x001297E0 File Offset: 0x00127BE0
	public virtual IEnumerable PostDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		yield break;
	}

	// Token: 0x06003881 RID: 14465 RVA: 0x001297FC File Offset: 0x00127BFC
	public virtual IEnumerable PriorDamageFormationProcess(TargetDefinition targetDefinition, AdventureUnitSkill skill)
	{
		yield break;
	}

	// Token: 0x06003882 RID: 14466 RVA: 0x00129818 File Offset: 0x00127C18
	public virtual IEnumerable PriorDamageProcess(ReleaseableDamage damage, AdventureUnitSkill skill)
	{
		yield break;
	}

	// Token: 0x06003883 RID: 14467 RVA: 0x00129834 File Offset: 0x00127C34
	public virtual IEnumerable PostHealProcess(ReleaseableHeal heal, AdventureUnitSkill skill)
	{
		yield break;
	}

	// Token: 0x06003884 RID: 14468 RVA: 0x00129850 File Offset: 0x00127C50
	public virtual IEnumerable PriorHealProcess(ReleaseableHeal heal, AdventureUnitSkill skill)
	{
		yield break;
	}

	// Token: 0x06003885 RID: 14469 RVA: 0x0012986C File Offset: 0x00127C6C
	public virtual List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>();
	}

	// Token: 0x06003886 RID: 14470 RVA: 0x00129874 File Offset: 0x00127C74
	public IEnumerable ProcessEvent(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReadyInBattle && eventTriggerUnit == skillOwner)
		{
			processingSkill.Timer = 0f;
		}
		if (skillOwner.IsAliveInBattle())
		{
			IEnumerator enumerator = this.ProcessEvent_ExtraLogic_ActiveUnit(processingSkill, eventTriggerUnit, skillOwner, eventType, data).GetEnumerator();
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
		else
		{
			IEnumerator enumerator2 = this.ProcessEvent_ExtraLogic_InactiveUnit(processingSkill, eventTriggerUnit, skillOwner, eventType, data).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object _2 = enumerator2.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x06003887 RID: 14471 RVA: 0x001298BC File Offset: 0x00127CBC
	public virtual IEnumerable PerSecondLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit skillOwner)
	{
		yield break;
	}

	// Token: 0x06003888 RID: 14472 RVA: 0x001298D8 File Offset: 0x00127CD8
	public virtual IEnumerable PerSecondLogic_InactiveUnit(AdventureUnitSkill processingSkill, IBattleUnit skillOwner)
	{
		yield break;
	}

	// Token: 0x06003889 RID: 14473 RVA: 0x001298F4 File Offset: 0x00127CF4
	public virtual IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		yield break;
	}

	// Token: 0x0600388A RID: 14474 RVA: 0x00129910 File Offset: 0x00127D10
	public virtual IEnumerable ProcessEvent_ExtraLogic_InactiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		yield break;
	}

	// Token: 0x17000AD0 RID: 2768
	// (get) Token: 0x0600388B RID: 14475
	public abstract SkillType SkillType { get; }

	// Token: 0x17000AD1 RID: 2769
	// (get) Token: 0x0600388C RID: 14476
	public abstract SkillCommandType SkillCommandType { get; }

	// Token: 0x0600388D RID: 14477 RVA: 0x0012992C File Offset: 0x00127D2C
	public double CalculateDamageRaw(double percentage, AdventureUnitSkill skill)
	{
		UnitOutputCapacity outputCapacity = skill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill);
		if (outputCapacity == null)
		{
			return 0.0;
		}
		return outputCapacity.Value * percentage;
	}

	// Token: 0x0600388E RID: 14478 RVA: 0x00129960 File Offset: 0x00127D60
	public double CalculateHeal(double percentage, AdventureUnitSkill skill)
	{
		UnitOutputCapacity outputCapacity = skill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill);
		if (outputCapacity == null)
		{
			return 0.0;
		}
		return outputCapacity.Value * percentage;
	}

	// Token: 0x0600388F RID: 14479 RVA: 0x00129994 File Offset: 0x00127D94
	public Description ParseDescription(Skill skill)
	{
		Description description = skill.SkillType.GetDescription();
		return this.ParseLogic(description, skill);
	}

	// Token: 0x06003890 RID: 14480 RVA: 0x001299B5 File Offset: 0x00127DB5
	public virtual Description ParseLogic(Description description, Skill skill)
	{
		return description;
	}

	// Token: 0x04002B9F RID: 11167
	protected readonly string MainDamageRateKey = "{maindamagerate}";

	// Token: 0x04002BA0 RID: 11168
	protected readonly string MainOvertimeDamageRatekey = "{mainovertimedamagerate}";

	// Token: 0x04002BA1 RID: 11169
	protected readonly string MainDamagePerLayer = "{maindamageperlayer}";

	// Token: 0x04002BA2 RID: 11170
	protected readonly string CasterDamageRateKey = "{casterdamagerate}";

	// Token: 0x04002BA3 RID: 11171
	protected readonly string CasterDamageRatePerLayer = "{casterdamagerateperlayer}";

	// Token: 0x04002BA4 RID: 11172
	protected readonly string CasterOvertimeDamageRatekey = "{casterovertimedamagerate}";

	// Token: 0x04002BA5 RID: 11173
	protected readonly string AdditionalMainDamageRateKey = "{additionalmaindamagerate}";

	// Token: 0x04002BA6 RID: 11174
	protected readonly string AdditionalCasterDamageRateKey = "{additionalcasterdamagerate}";

	// Token: 0x04002BA7 RID: 11175
	protected readonly string BaseBoostValue = "{baseboostvalue}";

	// Token: 0x04002BA8 RID: 11176
	protected readonly string AdditionalBoostRate = "{additionalrate}";

	// Token: 0x04002BA9 RID: 11177
	protected readonly string BoostRateKey = "{boostrate}";

	// Token: 0x04002BAA RID: 11178
	protected readonly string BoostValueKey = "{boostvalue}";

	// Token: 0x04002BAB RID: 11179
	protected readonly string DecreaseRateKey = "{decreaserate}";

	// Token: 0x04002BAC RID: 11180
	protected readonly string HealRateKey = "{healrate}";

	// Token: 0x04002BAD RID: 11181
	protected readonly string HealValueKey = "{healvalue}";

	// Token: 0x04002BAE RID: 11182
	protected readonly string PossibilityKey = "{chance}";

	// Token: 0x04002BAF RID: 11183
	protected readonly string ArmorIncreaseRateKey = "{armorincreaserate}";

	// Token: 0x04002BB0 RID: 11184
	protected readonly string ArmorIncreaseValueKey = "{armorincreasevalue}";

	// Token: 0x04002BB1 RID: 11185
	protected readonly string SpellResistanceRateKey = "{magicresistancerate}";

	// Token: 0x04002BB2 RID: 11186
	protected readonly string SpellResistanceValueKey = "{magicresistancevalue}";

	// Token: 0x04002BB3 RID: 11187
	protected readonly string StrengthincreaseRateKey = "{strengthincreaserate}";

	// Token: 0x04002BB4 RID: 11188
	protected readonly string ArmorDecreaseValueKey = "{armordecreasevalue}";

	// Token: 0x04002BB5 RID: 11189
	protected readonly string StrengthDecreaseRateKey = "{strengthdecreaserate}";

	// Token: 0x04002BB6 RID: 11190
	protected readonly string SinSeedRevengeDamageRateKey = "{sinseedrevengedamagerate}";

	// Token: 0x04002BB7 RID: 11191
	protected readonly string SinSeedRevengeDamageValueKey = "{sinseedrevengedamagevalue}";

	// Token: 0x04002BB8 RID: 11192
	protected readonly string OverTimeHealRateKey = "{overtimehealrate}";

	// Token: 0x04002BB9 RID: 11193
	protected readonly string OverTimeHealValuekey = "{overtimehealvalue}";

	// Token: 0x04002BBA RID: 11194
	protected readonly string ExplosiveDamageRateKey = "{explosivedamagerate}";

	// Token: 0x04002BBB RID: 11195
	protected readonly string ExplosiveDamageValueKey = "{explosivedamagevalue}";

	// Token: 0x04002BBC RID: 11196
	protected readonly string ProgressChangeRateKey = "{progresschangerate}";

	// Token: 0x04002BBD RID: 11197
	protected readonly string ReceivedSpellDamageIncreaseRateKey = "{receivedspelldamageincreaserate}";

	// Token: 0x04002BBE RID: 11198
	protected readonly string ReceivedPhysicalDamageIncreaserateKey = "{receivedphysicaldamageincreaserate}";

	// Token: 0x04002BBF RID: 11199
	protected readonly string SpeedReductionRateKey = "{speedreductionrate}";

	// Token: 0x04002BC0 RID: 11200
	protected readonly string SpeedIncreaseRateKey = "{speedincreaserate}";

	// Token: 0x04002BC1 RID: 11201
	protected readonly string SpeedIncreaseValueKey = "{speedincreasevalue}";

	// Token: 0x04002BC2 RID: 11202
	protected readonly string LifeOnHitIncreaseKey = "{lifeonhitincreaserate}";

	// Token: 0x04002BC3 RID: 11203
	protected readonly string DamageReceivedReductionRateKey = "{damagereductionrate}";

	// Token: 0x04002BC4 RID: 11204
	protected readonly string GrandStrategyAdditionalNoLayers = "{grandstrategyadditionallayersnumber}";

	// Token: 0x04002BC5 RID: 11205
	protected readonly string CritBoostValueKey = "{critrateboostrate}";

	// Token: 0x04002BC6 RID: 11206
	protected readonly string IntelligenceIncreaseRateKey = "{intelligienceincreaserate}";

	// Token: 0x04002BC7 RID: 11207
	protected readonly string LeastNumberOfTargetsKey = "{leastnumberoftargets}";

	// Token: 0x04002BC8 RID: 11208
	protected readonly string MaxNumberOfTargetsKey = "{maxnumberoftargets}";

	// Token: 0x04002BC9 RID: 11209
	protected readonly string NumberOfActiveTriggers = "{numberofactivetriggers}";

	// Token: 0x04002BCA RID: 11210
	protected readonly string NumberOfPassiveTriggersKey = "{numberofpassivetriggers}";

	// Token: 0x04002BCB RID: 11211
	protected readonly string NumberOfActiveShields = "{numberofactiveshields}";

	// Token: 0x04002BCC RID: 11212
	protected readonly string PhysicalPenetrationKey = "{physicalpenetration}";

	// Token: 0x04002BCD RID: 11213
	protected readonly string NumberOfAdditionalTargets = "{numberofadditionaltargets}";

	// Token: 0x04002BCE RID: 11214
	protected readonly string LastingSecondsKey = "{lastingseconds}";

	// Token: 0x04002BCF RID: 11215
	protected readonly string AdditionalDamageRateKey = "{additionaldamagerate}";

	// Token: 0x04002BD0 RID: 11216
	protected readonly string DamageRateKey = "{damagerate}";

	// Token: 0x04002BD1 RID: 11217
	protected readonly string HealReceivedReductionRateKey = "{healreceivedreductionrate}";

	// Token: 0x04002BD2 RID: 11218
	protected readonly string OutputBoostRateKey = "{outputboostrate}";

	// Token: 0x02000EDA RID: 3802
	[CompilerGenerated]
	private sealed class <Cast>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005FDB RID: 24539 RVA: 0x001299B8 File Offset: 0x00127DB8
		[DebuggerHidden]
		public <Cast>c__Iterator0()
		{
		}

		// Token: 0x06005FDC RID: 24540 RVA: 0x001299C0 File Offset: 0x00127DC0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damageDefinition = this.GetDamageDefinition(skill);
				if (damageDefinition == null)
				{
					goto IL_15D8;
				}
				seed = UnityEngine.Random.Range(0, int.MaxValue);
				UnityEngine.Random.InitState(seed);
				enumerator = this.PriorDamageFormationProcess(damageDefinition.TargetDefinition, skill).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1E8;
			case 3u:
				goto IL_283;
			case 4u:
			case 5u:
			case 6u:
			case 7u:
			case 8u:
			case 9u:
			case 10u:
			case 11u:
			case 12u:
			case 13u:
			case 14u:
				goto IL_512;
			case 15u:
				goto IL_1554;
			case 16u:
				Block_15:
				try
				{
					switch (num)
					{
					}
					if (enumerator23.MoveNext())
					{
						_16 = enumerator23.Current;
						this.$current = _16;
						if (!this.$disposing)
						{
							this.$PC = 16;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable16 = (enumerator23 as IDisposable)) != null)
						{
							disposable16.Dispose();
						}
					}
				}
				enumerator24 = releaseableHeal.Release().GetEnumerator();
				num = 4294967293u;
				goto Block_16;
			case 17u:
				goto IL_1707;
			case 18u:
				goto IL_17C4;
			case 19u:
				goto IL_19E0;
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
			UnityEngine.Random.InitState(seed);
			releaseableDamage = damageDefinition.GetReleaseableDamage(<Cast>c__AnonStoreyB.skill.SourceUnit, <Cast>c__AnonStoreyB.skill);
			enumerator2 = this.PriorDamageProcess(releaseableDamage, <Cast>c__AnonStoreyB.skill).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1E8:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			enumerator3 = releaseableDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_283:
				switch (num)
				{
				}
				if (enumerator3.MoveNext())
				{
					_3 = enumerator3.Current;
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
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			pushRate = <Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<PushOnHitTalent>().Sum((PushOnHitTalent t) => t.GetRate());
			refreshCounts = ((!<Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<NegativeEffectsRefreshTalent>().Any<NegativeEffectsRefreshTalent>()) ? 0 : NegativeEffectsRefreshTalent.Counts);
			dispelPositives = <Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<DispelPositiveEffectOnHitTalent>().ToList<DispelPositiveEffectOnHitTalent>();
			debuffOnHitByRate = <Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<AttributeDebuffByRateOnHitTalent>().ToList<AttributeDebuffByRateOnHitTalent>();
			debuffOnHitByValue = <Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<AttributeDebuffByValueOnHitTalent>().ToList<AttributeDebuffByValueOnHitTalent>();
			selfHealRate = <Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<SelfHealOnKillTalent>().Sum((SelfHealOnKillTalent t) => t.GetHealrate());
			totalStun = <Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<StunOnDamageTalent>().Sum((StunOnDamageTalent t) => t.GetStunSeconds());
			dispelOnNotKill = ((!<Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<AssassinDispelEnhancementTalent>().Any<AssassinDispelEnhancementTalent>()) ? 0 : AssassinDispelEnhancementTalent.NumberOfDispel);
			totalKillShields = <Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<ShieldOnKillTalent>().Sum((ShieldOnKillTalent k) => k.GetNumberOfShields());
			memberBoostsByRate = <Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<AttributeBoostMemberOnKillBasedOnSelfRateTalent>().ToList<AttributeBoostMemberOnKillBasedOnSelfRateTalent>();
			memberShields = <Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<EmbraceShieldMemberOnKillTalent>().ToList<EmbraceShieldMemberOnKillTalent>();
			enumerator4 = releaseableDamage.BattleDamages.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_512:
				switch (num)
				{
				case 4u:
					Block_41:
					try
					{
						switch (num)
						{
						}
						if (enumerator5.MoveNext())
						{
							_4 = enumerator5.Current;
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
							if ((disposable4 = (enumerator5 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
					}
					break;
				case 5u:
					Block_46:
					try
					{
						switch (num)
						{
						case 5u:
							Block_82:
							try
							{
								switch (num)
								{
								}
								if (enumerator8.MoveNext())
								{
									_5 = enumerator8.Current;
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
									if ((disposable5 = (enumerator8 as IDisposable)) != null)
									{
										disposable5.Dispose();
									}
								}
							}
							break;
						default:
							goto IL_89E;
						}
						IL_87F:
						i++;
						IL_88D:
						if (i < numberOfEffectiveDamages)
						{
							if ((double)UnityEngine.Random.value <= dispel.GetChance())
							{
								enumerator8 = UnitStyleConfigurationBase.DispelPositiveEffects(damage.Target, new int?(dispel.GetNumberOfDispels())).GetEnumerator();
								num = 4294967293u;
								goto Block_82;
							}
							goto IL_87F;
						}
						IL_89E:
						if (enumerator7.MoveNext())
						{
							dispel = enumerator7.Current;
							numberOfEffectiveDamages = damage.Damages.Count((DamageComponent c) => c.IsDirectDamage && !c.IsMissed);
							i = 0;
							goto IL_88D;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator7).Dispose();
						}
					}
					if (debuffOnHitByRate.Any<AttributeDebuffByRateOnHitTalent>())
					{
						enumerator9 = debuffOnHitByRate.GetEnumerator();
						num = 4294967293u;
						goto Block_48;
					}
					goto IL_A79;
				case 6u:
					goto IL_8ED;
				case 7u:
					Block_50:
					try
					{
						switch (num)
						{
						case 7u:
							Block_106:
							try
							{
								switch (num)
								{
								}
								if (enumerator12.MoveNext())
								{
									_7 = enumerator12.Current;
									this.$current = _7;
									if (!this.$disposing)
									{
										this.$PC = 7;
									}
									flag = true;
									return true;
								}
							}
							finally
							{
								if (!flag)
								{
									if ((disposable7 = (enumerator12 as IDisposable)) != null)
									{
										disposable7.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator11.MoveNext())
						{
							debuff2 = enumerator11.Current;
							enumerator12 = damage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(<Cast>c__AnonStoreyB.skill.SourceUnit, (from d in debuff2.GetDebuffs()
							select new AttributeModifier
							{
								AttributeType = d.BoostAttribute,
								ModificationType = ModificationType.Addition,
								Value = -d.BoostValue,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}).ToList<AttributeModifier>(), <Cast>c__AnonStoreyB.skill.Skill.SkillType.ToString() + "talentonhitdebuffbyvalue", new int?(debuff2.GetMaxStack()), new float?((float)debuff2.GetLastingSeconds()), null, true, true), false).GetEnumerator();
							num = 4294967293u;
							goto Block_106;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator11).Dispose();
						}
					}
					goto IL_C29;
				case 8u:
					Block_52:
					try
					{
						switch (num)
						{
						}
						if (enumerator13.MoveNext())
						{
							_8 = enumerator13.Current;
							this.$current = _8;
							if (!this.$disposing)
							{
								this.$PC = 8;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable8 = (enumerator13 as IDisposable)) != null)
							{
								disposable8.Dispose();
							}
						}
					}
					goto IL_CED;
				case 9u:
					Block_56:
					try
					{
						switch (num)
						{
						case 9u:
							Block_124:
							try
							{
								switch (num)
								{
								}
								if (enumerator15.MoveNext())
								{
									_9 = enumerator15.Current;
									this.$current = _9;
									if (!this.$disposing)
									{
										this.$PC = 9;
									}
									flag = true;
									return true;
								}
							}
							finally
							{
								if (!flag)
								{
									if ((disposable9 = (enumerator15 as IDisposable)) != null)
									{
										disposable9.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator14.MoveNext())
						{
							talent = enumerator14.Current;
							enumerator15 = <Cast>c__AnonStoreyB.skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(<Cast>c__AnonStoreyB.skill.SourceUnit, (from b in talent.GetBoosts()
							select new AttributeModifier
							{
								AttributeType = b.BoostAttribute,
								ModificationType = ModificationType.Multiplication,
								Value = b.BoostValue,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}).ToList<AttributeModifier>(), "onkillboostskilltalent" + <Cast>c__AnonStoreyB.skill.Skill.SkillType, new int?(talent.GetMaxStack()), null, new int?(2), false, true, false), false).GetEnumerator();
							num = 4294967293u;
							goto Block_124;
						}
					}
					finally
					{
						if (!flag)
						{
							if (enumerator14 != null)
							{
								enumerator14.Dispose();
							}
						}
					}
					goto IL_EEA;
				case 10u:
					Block_58:
					try
					{
						switch (num)
						{
						}
						if (enumerator16.MoveNext())
						{
							_10 = enumerator16.Current;
							this.$current = _10;
							if (!this.$disposing)
							{
								this.$PC = 10;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable10 = (enumerator16 as IDisposable)) != null)
							{
								disposable10.Dispose();
							}
						}
					}
					goto IL_103A;
				case 11u:
					Block_60:
					try
					{
						switch (num)
						{
						}
						if (enumerator17.MoveNext())
						{
							_11 = enumerator17.Current;
							this.$current = _11;
							if (!this.$disposing)
							{
								this.$PC = 11;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable11 = (enumerator17 as IDisposable)) != null)
							{
								disposable11.Dispose();
							}
						}
					}
					j++;
					goto IL_1124;
				case 12u:
					Block_62:
					try
					{
						switch (num)
						{
						case 12u:
							Block_148:
							try
							{
								switch (num)
								{
								}
								if (enumerator19.MoveNext())
								{
									_12 = enumerator19.Current;
									this.$current = _12;
									if (!this.$disposing)
									{
										this.$PC = 12;
									}
									flag = true;
									return true;
								}
							}
							finally
							{
								if (!flag)
								{
									if ((disposable12 = (enumerator19 as IDisposable)) != null)
									{
										disposable12.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator18.MoveNext())
						{
							battleUnit = enumerator18.Current;
							enumerator19 = battleUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(<Cast>c__AnonStoreyB.skill.SourceUnit, (from b in memberBoostsByRate
							select new AttributeModifier
							{
								AttributeType = b.GetBoostType(),
								ModificationType = ModificationType.Addition,
								Value = b.GetBoostRate() * <Cast>c__AnonStoreyB.skill.SourceUnit.GetAttributeValue_Final(b.GetBoostType(), AttributeRetrievalLevel.Skill),
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}).ToList<AttributeModifier>(), "onkillboostmember" + <Cast>c__AnonStoreyB.skill.Skill.SkillType, new int?(3), null, new int?(2), false, true, false), false).GetEnumerator();
							num = 4294967293u;
							goto Block_148;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator18).Dispose();
						}
					}
					goto IL_12EF;
				case 13u:
					Block_66:
					try
					{
						switch (num)
						{
						}
						if (enumerator20.MoveNext())
						{
							_13 = enumerator20.Current;
							this.$current = _13;
							if (!this.$disposing)
							{
								this.$PC = 13;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable13 = (enumerator20 as IDisposable)) != null)
							{
								disposable13.Dispose();
							}
						}
					}
					k++;
					goto IL_1430;
				case 14u:
					Block_68:
					try
					{
						switch (num)
						{
						}
						if (enumerator21.MoveNext())
						{
							_14 = enumerator21.Current;
							this.$current = _14;
							if (!this.$disposing)
							{
								this.$PC = 14;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable14 = (enumerator21 as IDisposable)) != null)
							{
								disposable14.Dispose();
							}
						}
					}
					goto IL_14FF;
				default:
					goto IL_14FF;
				}
				IL_677:
				if (refreshCounts > 0)
				{
					int count = refreshCounts * damage.Damages.Count((DamageComponent d) => d.IsDirectDamage && !d.IsMissed);
					List<BattleEffectBase> list = (from ef in damage.Target.BattleEffects
					where ef.BattleEffectNatureForWearer == BattleEffectNature.Negative && (ef.MaxNumberOfLastingSeconds != null || ef.NumberOfLastingTurns != null)
					select ef).ToList<BattleEffectBase>();
					list.Shuffle<BattleEffectBase>();
					List<BattleEffectBase> list2 = list.Take(count).ToList<BattleEffectBase>();
					foreach (BattleEffectBase battleEffectBase in list2)
					{
						battleEffectBase.Refresh();
					}
				}
				enumerator7 = dispelPositives.GetEnumerator();
				num = 4294967293u;
				goto Block_46;
				Block_48:
				try
				{
					IL_8ED:
					switch (num)
					{
					case 6u:
						Block_94:
						try
						{
							switch (num)
							{
							}
							if (enumerator10.MoveNext())
							{
								_6 = enumerator10.Current;
								this.$current = _6;
								if (!this.$disposing)
								{
									this.$PC = 6;
								}
								flag = true;
								return true;
							}
						}
						finally
						{
							if (!flag)
							{
								if ((disposable6 = (enumerator10 as IDisposable)) != null)
								{
									disposable6.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator9.MoveNext())
					{
						debuff = enumerator9.Current;
						enumerator10 = damage.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(<Cast>c__AnonStoreyB.skill.SourceUnit, (from d in debuff.GetDebuffs()
						select new AttributeModifier
						{
							AttributeType = d.BoostAttribute,
							ModificationType = ModificationType.Multiplication,
							Value = -d.BoostValue,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}).ToList<AttributeModifier>(), <Cast>c__AnonStoreyB.skill.Skill.SkillType.ToString() + "talentonhitdebuffbyrate", new int?(debuff.GetMaxStack()), new float?((float)debuff.GetLastingSeconds()), null, true, true), false).GetEnumerator();
						num = 4294967293u;
						goto Block_94;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator9).Dispose();
					}
				}
				IL_A79:
				if (debuffOnHitByValue.Any<AttributeDebuffByValueOnHitTalent>())
				{
					enumerator11 = debuffOnHitByValue.GetEnumerator();
					num = 4294967293u;
					goto Block_50;
				}
				IL_C29:
				if (totalStun > 0)
				{
					enumerator13 = LockTimeEffect.AddStunSeconds(damage.Target, (float)totalStun, <Cast>c__AnonStoreyB.skill.SourceUnit, false).GetEnumerator();
					num = 4294967293u;
					goto Block_52;
				}
				IL_CED:
				if (damage.Damages.Any((DamageComponent d) => d.IsFatal != null && d.IsFatal.Value))
				{
					if (<Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<AttributeBoostOnKillTalentByRate>().Any<AttributeBoostOnKillTalentByRate>())
					{
						enumerator14 = <Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<AttributeBoostOnKillTalentByRate>().GetEnumerator();
						num = 4294967293u;
						goto Block_56;
					}
				}
				else
				{
					if (dispelOnNotKill > 0)
					{
						enumerator21 = UnitStyleConfigurationBase.DispelPositiveEffects(damage.Target, new int?(dispelOnNotKill)).GetEnumerator();
						num = 4294967293u;
						goto Block_68;
					}
					goto IL_14FF;
				}
				IL_EEA:
				if (selfHealRate > 0.0)
				{
					selfReleaseable = new ReleaseableHeal(new List<BattleHeal>
					{
						new BattleHeal(<Cast>c__AnonStoreyB.skill.SourceUnit, <Cast>c__AnonStoreyB.skill.SourceUnit, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								RawHeal = selfHealRate * <Cast>c__AnonStoreyB.skill.SourceUnit.GetMaxLife(AttributeRetrievalLevel.Skill),
								HealType = OutputType.RealHeal,
								IsDirectHeal = false
							}
						}, false)
					}, <Cast>c__AnonStoreyB.skill.SourceUnit);
					enumerator16 = selfReleaseable.Release().GetEnumerator();
					num = 4294967293u;
					goto Block_58;
				}
				IL_103A:
				if (totalKillShields <= 0)
				{
					goto IL_1135;
				}
				j = 0;
				IL_1124:
				if (j < totalKillShields)
				{
					enumerator17 = <Cast>c__AnonStoreyB.skill.SourceUnit.ApplySkillEffect(new DamageNeutralizationEffect(new int?(1), <Cast>c__AnonStoreyB.skill.SourceUnit, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_60;
				}
				IL_1135:
				if (memberBoostsByRate.Any<AttributeBoostMemberOnKillBasedOnSelfRateTalent>())
				{
					targets = (from e in <Cast>c__AnonStoreyB.skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true)
					where e != <Cast>c__AnonStoreyB.skill.SourceUnit
					select e).ToList<IBattleUnit>();
					enumerator18 = targets.GetEnumerator();
					num = 4294967293u;
					goto Block_62;
				}
				IL_12EF:
				if (!memberShields.Any<EmbraceShieldMemberOnKillTalent>())
				{
					goto IL_1441;
				}
				totalShields = EmbraceShieldMemberOnKillTalent.NumberOfShields;
				target = (from o in <Cast>c__AnonStoreyB.skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true)
				orderby o.HealthPoints / o.GetMaxLife(AttributeRetrievalLevel.Skill)
				select o).FirstOrDefault<IBattleUnit>();
				if (target == null)
				{
					goto IL_1441;
				}
				k = 0;
				IL_1430:
				if (k < totalShields)
				{
					enumerator20 = target.ApplySkillEffect(new ReflectiveShieldEffect("shieldonkill", new int?(2), <Cast>c__AnonStoreyB.skill.SourceUnit), false).GetEnumerator();
					num = 4294967293u;
					goto Block_66;
				}
				IL_1441:
				IL_14FF:
				if (enumerator4.MoveNext())
				{
					damage = enumerator4.Current;
					if (!damage.Target.IsAliveInBattle())
					{
						goto IL_CED;
					}
					if (pushRate > 0.0)
					{
						topush = pushRate * (double)damage.Damages.Count((DamageComponent d) => d.IsDirectDamage && !d.IsMissed);
						enumerator5 = UnitStyleConfigurationBase.PushTargetProgress(damage.Target, <Cast>c__AnonStoreyB.skill.SourceUnit, -topush).GetEnumerator();
						num = 4294967293u;
						goto Block_41;
					}
					goto IL_677;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator4).Dispose();
				}
			}
			enumerator22 = this.PostDamageProcess(releaseableDamage, <Cast>c__AnonStoreyB.skill).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1554:
				switch (num)
				{
				}
				if (enumerator22.MoveNext())
				{
					_15 = enumerator22.Current;
					this.$current = _15;
					if (!this.$disposing)
					{
						this.$PC = 15;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable15 = (enumerator22 as IDisposable)) != null)
					{
						disposable15.Dispose();
					}
				}
			}
			IL_15D8:
			healDefinition = this.GetHealDefinition(<Cast>c__AnonStoreyB.skill);
			if (healDefinition != null)
			{
				releaseableHeal = healDefinition.GetReleaseableHeal(<Cast>c__AnonStoreyB.skill.SourceUnit, <Cast>c__AnonStoreyB.skill, <Cast>c__AnonStoreyB.skill.GetSkillLogic().SkillOutputType);
				enumerator23 = this.PriorHealProcess(releaseableHeal, <Cast>c__AnonStoreyB.skill).GetEnumerator();
				num = 4294967293u;
				goto Block_15;
			}
			return false;
			Block_16:
			try
			{
				IL_1707:
				switch (num)
				{
				}
				if (enumerator24.MoveNext())
				{
					_17 = enumerator24.Current;
					this.$current = _17;
					if (!this.$disposing)
					{
						this.$PC = 17;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable17 = (enumerator24 as IDisposable)) != null)
					{
						disposable17.Dispose();
					}
				}
			}
			attributeBoostOnHealByRate = <Cast>c__AnonStoreyB.skill.GetActiveTalents().OfType<AttributeBoostOnHealByRateTalent>().ToList<AttributeBoostOnHealByRateTalent>();
			enumerator25 = releaseableHeal.BattleHeals.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_17C4:
				switch (num)
				{
				case 18u:
					Block_192:
					try
					{
						switch (num)
						{
						case 18u:
							Block_196:
							try
							{
								switch (num)
								{
								}
								if (enumerator27.MoveNext())
								{
									_18 = enumerator27.Current;
									this.$current = _18;
									if (!this.$disposing)
									{
										this.$PC = 18;
									}
									flag = true;
									return true;
								}
							}
							finally
							{
								if (!flag)
								{
									if ((disposable18 = (enumerator27 as IDisposable)) != null)
									{
										disposable18.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator26.MoveNext())
						{
							attributeBoostOnHealByRateTalent = enumerator26.Current;
							enumerator27 = releaseableHealBattleHeal.Target.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(releaseableHealBattleHeal.Target, (from b in attributeBoostOnHealByRateTalent.GetBoosts()
							select new AttributeModifier
							{
								AttributeType = b.BoostAttribute,
								ModificationType = ModificationType.Multiplication,
								Value = b.BoostValue,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}).ToList<AttributeModifier>(), <Cast>c__AnonStoreyB.skill.Skill.SkillType.ToString() + "attributeboostonheal", new int?(attributeBoostOnHealByRateTalent.GetMaxStack()), null, new int?(2), false, true, false), false).GetEnumerator();
							num = 4294967293u;
							goto Block_196;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator26).Dispose();
						}
					}
					break;
				}
				while (enumerator25.MoveNext())
				{
					releaseableHealBattleHeal = enumerator25.Current;
					if (attributeBoostOnHealByRate.Any<AttributeBoostOnHealByRateTalent>())
					{
						enumerator26 = attributeBoostOnHealByRate.GetEnumerator();
						num = 4294967293u;
						goto Block_192;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator25).Dispose();
				}
			}
			enumerator28 = this.PostHealProcess(releaseableHeal, <Cast>c__AnonStoreyB.skill).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_19E0:
				switch (num)
				{
				}
				if (enumerator28.MoveNext())
				{
					_19 = enumerator28.Current;
					this.$current = _19;
					if (!this.$disposing)
					{
						this.$PC = 19;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable19 = (enumerator28 as IDisposable)) != null)
					{
						disposable19.Dispose();
					}
				}
			}
			return false;
		}

		// Token: 0x1700140C RID: 5132
		// (get) Token: 0x06005FDD RID: 24541 RVA: 0x0012B6E4 File Offset: 0x00129AE4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700140D RID: 5133
		// (get) Token: 0x06005FDE RID: 24542 RVA: 0x0012B6EC File Offset: 0x00129AEC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005FDF RID: 24543 RVA: 0x0012B6F4 File Offset: 0x00129AF4
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
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
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
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
			case 5u:
			case 6u:
			case 7u:
			case 8u:
			case 9u:
			case 10u:
			case 11u:
			case 12u:
			case 13u:
			case 14u:
				try
				{
					switch (num)
					{
					case 4u:
						try
						{
						}
						finally
						{
							if ((disposable4 = (enumerator5 as IDisposable)) != null)
							{
								disposable4.Dispose();
							}
						}
						break;
					case 5u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable5 = (enumerator8 as IDisposable)) != null)
								{
									disposable5.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator7).Dispose();
						}
						break;
					case 6u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable6 = (enumerator10 as IDisposable)) != null)
								{
									disposable6.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator9).Dispose();
						}
						break;
					case 7u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable7 = (enumerator12 as IDisposable)) != null)
								{
									disposable7.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator11).Dispose();
						}
						break;
					case 8u:
						try
						{
						}
						finally
						{
							if ((disposable8 = (enumerator13 as IDisposable)) != null)
							{
								disposable8.Dispose();
							}
						}
						break;
					case 9u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable9 = (enumerator15 as IDisposable)) != null)
								{
									disposable9.Dispose();
								}
							}
						}
						finally
						{
							if (enumerator14 != null)
							{
								enumerator14.Dispose();
							}
						}
						break;
					case 10u:
						try
						{
						}
						finally
						{
							if ((disposable10 = (enumerator16 as IDisposable)) != null)
							{
								disposable10.Dispose();
							}
						}
						break;
					case 11u:
						try
						{
						}
						finally
						{
							if ((disposable11 = (enumerator17 as IDisposable)) != null)
							{
								disposable11.Dispose();
							}
						}
						break;
					case 12u:
						try
						{
							try
							{
							}
							finally
							{
								if ((disposable12 = (enumerator19 as IDisposable)) != null)
								{
									disposable12.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator18).Dispose();
						}
						break;
					case 13u:
						try
						{
						}
						finally
						{
							if ((disposable13 = (enumerator20 as IDisposable)) != null)
							{
								disposable13.Dispose();
							}
						}
						break;
					case 14u:
						try
						{
						}
						finally
						{
							if ((disposable14 = (enumerator21 as IDisposable)) != null)
							{
								disposable14.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator4).Dispose();
				}
				break;
			case 15u:
				try
				{
				}
				finally
				{
					if ((disposable15 = (enumerator22 as IDisposable)) != null)
					{
						disposable15.Dispose();
					}
				}
				break;
			case 16u:
				try
				{
				}
				finally
				{
					if ((disposable16 = (enumerator23 as IDisposable)) != null)
					{
						disposable16.Dispose();
					}
				}
				break;
			case 17u:
				try
				{
				}
				finally
				{
					if ((disposable17 = (enumerator24 as IDisposable)) != null)
					{
						disposable17.Dispose();
					}
				}
				break;
			case 18u:
				try
				{
					try
					{
						try
						{
						}
						finally
						{
							if ((disposable18 = (enumerator27 as IDisposable)) != null)
							{
								disposable18.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator26).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator25).Dispose();
				}
				break;
			case 19u:
				try
				{
				}
				finally
				{
					if ((disposable19 = (enumerator28 as IDisposable)) != null)
					{
						disposable19.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005FE0 RID: 24544 RVA: 0x0012BE6C File Offset: 0x0012A26C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005FE1 RID: 24545 RVA: 0x0012BE73 File Offset: 0x0012A273
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005FE2 RID: 24546 RVA: 0x0012BE7C File Offset: 0x0012A27C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SkillLogicBase.<Cast>c__Iterator0 <Cast>c__Iterator = new SkillLogicBase.<Cast>c__Iterator0();
			<Cast>c__Iterator.$this = this;
			<Cast>c__Iterator.skill = skill;
			return <Cast>c__Iterator;
		}

		// Token: 0x06005FE3 RID: 24547 RVA: 0x0012BEBC File Offset: 0x0012A2BC
		private static double <>m__0(PushOnHitTalent t)
		{
			return t.GetRate();
		}

		// Token: 0x06005FE4 RID: 24548 RVA: 0x0012BEC4 File Offset: 0x0012A2C4
		private static double <>m__1(SelfHealOnKillTalent t)
		{
			return t.GetHealrate();
		}

		// Token: 0x06005FE5 RID: 24549 RVA: 0x0012BECC File Offset: 0x0012A2CC
		private static int <>m__2(StunOnDamageTalent t)
		{
			return t.GetStunSeconds();
		}

		// Token: 0x06005FE6 RID: 24550 RVA: 0x0012BED4 File Offset: 0x0012A2D4
		private static int <>m__3(ShieldOnKillTalent k)
		{
			return k.GetNumberOfShields();
		}

		// Token: 0x06005FE7 RID: 24551 RVA: 0x0012BEDC File Offset: 0x0012A2DC
		private static bool <>m__4(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x06005FE8 RID: 24552 RVA: 0x0012BEF5 File Offset: 0x0012A2F5
		private static bool <>m__5(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x06005FE9 RID: 24553 RVA: 0x0012BF10 File Offset: 0x0012A310
		private static bool <>m__6(BattleEffectBase ef)
		{
			return ef.BattleEffectNatureForWearer == BattleEffectNature.Negative && (ef.MaxNumberOfLastingSeconds != null || ef.NumberOfLastingTurns != null);
		}

		// Token: 0x06005FEA RID: 24554 RVA: 0x0012BF50 File Offset: 0x0012A350
		private static bool <>m__7(DamageComponent c)
		{
			return c.IsDirectDamage && !c.IsMissed;
		}

		// Token: 0x06005FEB RID: 24555 RVA: 0x0012BF6C File Offset: 0x0012A36C
		private static AttributeModifier <>m__8(BoostSetting d)
		{
			return new AttributeModifier
			{
				AttributeType = d.BoostAttribute,
				ModificationType = ModificationType.Multiplication,
				Value = -d.BoostValue,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			};
		}

		// Token: 0x06005FEC RID: 24556 RVA: 0x0012BFB4 File Offset: 0x0012A3B4
		private static AttributeModifier <>m__9(BoostSetting d)
		{
			return new AttributeModifier
			{
				AttributeType = d.BoostAttribute,
				ModificationType = ModificationType.Addition,
				Value = -d.BoostValue,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			};
		}

		// Token: 0x06005FED RID: 24557 RVA: 0x0012BFFC File Offset: 0x0012A3FC
		private static bool <>m__A(DamageComponent d)
		{
			return d.IsFatal != null && d.IsFatal.Value;
		}

		// Token: 0x06005FEE RID: 24558 RVA: 0x0012C030 File Offset: 0x0012A430
		private static AttributeModifier <>m__B(BoostSetting b)
		{
			return new AttributeModifier
			{
				AttributeType = b.BoostAttribute,
				ModificationType = ModificationType.Multiplication,
				Value = b.BoostValue,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			};
		}

		// Token: 0x06005FEF RID: 24559 RVA: 0x0012C075 File Offset: 0x0012A475
		private static double <>m__C(IBattleUnit o)
		{
			return o.HealthPoints / o.GetMaxLife(AttributeRetrievalLevel.Skill);
		}

		// Token: 0x06005FF0 RID: 24560 RVA: 0x0012C088 File Offset: 0x0012A488
		private static AttributeModifier <>m__D(BoostSetting b)
		{
			return new AttributeModifier
			{
				AttributeType = b.BoostAttribute,
				ModificationType = ModificationType.Multiplication,
				Value = b.BoostValue,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			};
		}

		// Token: 0x040054BE RID: 21694
		internal AdventureUnitSkill skill;

		// Token: 0x040054BF RID: 21695
		internal IDamageDefinition <damageDefinition>__0;

		// Token: 0x040054C0 RID: 21696
		internal int <seed>__1;

		// Token: 0x040054C1 RID: 21697
		internal IEnumerator $locvar0;

		// Token: 0x040054C2 RID: 21698
		internal object <_>__2;

		// Token: 0x040054C3 RID: 21699
		internal IDisposable $locvar1;

		// Token: 0x040054C4 RID: 21700
		internal ReleaseableDamage <releaseableDamage>__1;

		// Token: 0x040054C5 RID: 21701
		internal IEnumerator $locvar2;

		// Token: 0x040054C6 RID: 21702
		internal object <_>__3;

		// Token: 0x040054C7 RID: 21703
		internal IDisposable $locvar3;

		// Token: 0x040054C8 RID: 21704
		internal IEnumerator $locvar4;

		// Token: 0x040054C9 RID: 21705
		internal object <_>__4;

		// Token: 0x040054CA RID: 21706
		internal IDisposable $locvar5;

		// Token: 0x040054CB RID: 21707
		internal double <pushRate>__1;

		// Token: 0x040054CC RID: 21708
		internal int <refreshCounts>__1;

		// Token: 0x040054CD RID: 21709
		internal List<DispelPositiveEffectOnHitTalent> <dispelPositives>__1;

		// Token: 0x040054CE RID: 21710
		internal List<AttributeDebuffByRateOnHitTalent> <debuffOnHitByRate>__1;

		// Token: 0x040054CF RID: 21711
		internal List<AttributeDebuffByValueOnHitTalent> <debuffOnHitByValue>__1;

		// Token: 0x040054D0 RID: 21712
		internal double <selfHealRate>__1;

		// Token: 0x040054D1 RID: 21713
		internal int <totalStun>__1;

		// Token: 0x040054D2 RID: 21714
		internal int <dispelOnNotKill>__1;

		// Token: 0x040054D3 RID: 21715
		internal int <totalKillShields>__1;

		// Token: 0x040054D4 RID: 21716
		internal List<AttributeBoostMemberOnKillBasedOnSelfRateTalent> <memberBoostsByRate>__1;

		// Token: 0x040054D5 RID: 21717
		internal List<EmbraceShieldMemberOnKillTalent> <memberShields>__1;

		// Token: 0x040054D6 RID: 21718
		internal List<BattleDamage>.Enumerator $locvar6;

		// Token: 0x040054D7 RID: 21719
		internal BattleDamage <damage>__5;

		// Token: 0x040054D8 RID: 21720
		internal double <topush>__6;

		// Token: 0x040054D9 RID: 21721
		internal IEnumerator $locvar7;

		// Token: 0x040054DA RID: 21722
		internal object <_>__7;

		// Token: 0x040054DB RID: 21723
		internal IDisposable $locvar8;

		// Token: 0x040054DC RID: 21724
		internal List<DispelPositiveEffectOnHitTalent>.Enumerator $locvarA;

		// Token: 0x040054DD RID: 21725
		internal DispelPositiveEffectOnHitTalent <dispel>__8;

		// Token: 0x040054DE RID: 21726
		internal int <numberOfEffectiveDamages>__9;

		// Token: 0x040054DF RID: 21727
		internal int <i>__10;

		// Token: 0x040054E0 RID: 21728
		internal IEnumerator $locvarB;

		// Token: 0x040054E1 RID: 21729
		internal object <_>__11;

		// Token: 0x040054E2 RID: 21730
		internal IDisposable $locvarC;

		// Token: 0x040054E3 RID: 21731
		internal List<AttributeDebuffByRateOnHitTalent>.Enumerator $locvarD;

		// Token: 0x040054E4 RID: 21732
		internal AttributeDebuffByRateOnHitTalent <debuff>__12;

		// Token: 0x040054E5 RID: 21733
		internal IEnumerator $locvarE;

		// Token: 0x040054E6 RID: 21734
		internal object <_>__13;

		// Token: 0x040054E7 RID: 21735
		internal IDisposable $locvarF;

		// Token: 0x040054E8 RID: 21736
		internal List<AttributeDebuffByValueOnHitTalent>.Enumerator $locvar10;

		// Token: 0x040054E9 RID: 21737
		internal AttributeDebuffByValueOnHitTalent <debuff>__14;

		// Token: 0x040054EA RID: 21738
		internal IEnumerator $locvar11;

		// Token: 0x040054EB RID: 21739
		internal object <_>__15;

		// Token: 0x040054EC RID: 21740
		internal IDisposable $locvar12;

		// Token: 0x040054ED RID: 21741
		internal IEnumerator $locvar13;

		// Token: 0x040054EE RID: 21742
		internal object <_>__16;

		// Token: 0x040054EF RID: 21743
		internal IDisposable $locvar14;

		// Token: 0x040054F0 RID: 21744
		internal IEnumerator<AttributeBoostOnKillTalentByRate> $locvar15;

		// Token: 0x040054F1 RID: 21745
		internal AttributeBoostOnKillTalentByRate <talent>__17;

		// Token: 0x040054F2 RID: 21746
		internal IEnumerator $locvar16;

		// Token: 0x040054F3 RID: 21747
		internal object <_>__18;

		// Token: 0x040054F4 RID: 21748
		internal IDisposable $locvar17;

		// Token: 0x040054F5 RID: 21749
		internal ReleaseableHeal <selfReleaseable>__19;

		// Token: 0x040054F6 RID: 21750
		internal IEnumerator $locvar18;

		// Token: 0x040054F7 RID: 21751
		internal object <_>__20;

		// Token: 0x040054F8 RID: 21752
		internal IDisposable $locvar19;

		// Token: 0x040054F9 RID: 21753
		internal int <i>__21;

		// Token: 0x040054FA RID: 21754
		internal IEnumerator $locvar1A;

		// Token: 0x040054FB RID: 21755
		internal object <_>__22;

		// Token: 0x040054FC RID: 21756
		internal IDisposable $locvar1B;

		// Token: 0x040054FD RID: 21757
		internal List<IBattleUnit> <targets>__23;

		// Token: 0x040054FE RID: 21758
		internal List<IBattleUnit>.Enumerator $locvar1C;

		// Token: 0x040054FF RID: 21759
		internal IBattleUnit <battleUnit>__24;

		// Token: 0x04005500 RID: 21760
		internal IEnumerator $locvar1D;

		// Token: 0x04005501 RID: 21761
		internal object <_>__25;

		// Token: 0x04005502 RID: 21762
		internal IDisposable $locvar1E;

		// Token: 0x04005503 RID: 21763
		internal int <totalShields>__26;

		// Token: 0x04005504 RID: 21764
		internal IBattleUnit <target>__26;

		// Token: 0x04005505 RID: 21765
		internal int <i>__27;

		// Token: 0x04005506 RID: 21766
		internal IEnumerator $locvar1F;

		// Token: 0x04005507 RID: 21767
		internal object <_>__28;

		// Token: 0x04005508 RID: 21768
		internal IDisposable $locvar20;

		// Token: 0x04005509 RID: 21769
		internal IEnumerator $locvar21;

		// Token: 0x0400550A RID: 21770
		internal object <_>__29;

		// Token: 0x0400550B RID: 21771
		internal IDisposable $locvar22;

		// Token: 0x0400550C RID: 21772
		internal IEnumerator $locvar23;

		// Token: 0x0400550D RID: 21773
		internal object <_>__30;

		// Token: 0x0400550E RID: 21774
		internal IDisposable $locvar24;

		// Token: 0x0400550F RID: 21775
		internal IHealDefinition <healDefinition>__0;

		// Token: 0x04005510 RID: 21776
		internal ReleaseableHeal <releaseableHeal>__31;

		// Token: 0x04005511 RID: 21777
		internal IEnumerator $locvar25;

		// Token: 0x04005512 RID: 21778
		internal object <_>__32;

		// Token: 0x04005513 RID: 21779
		internal IDisposable $locvar26;

		// Token: 0x04005514 RID: 21780
		internal IEnumerator $locvar27;

		// Token: 0x04005515 RID: 21781
		internal object <_>__33;

		// Token: 0x04005516 RID: 21782
		internal IDisposable $locvar28;

		// Token: 0x04005517 RID: 21783
		internal List<AttributeBoostOnHealByRateTalent> <attributeBoostOnHealByRate>__31;

		// Token: 0x04005518 RID: 21784
		internal List<BattleHeal>.Enumerator $locvar29;

		// Token: 0x04005519 RID: 21785
		internal BattleHeal <releaseableHealBattleHeal>__34;

		// Token: 0x0400551A RID: 21786
		internal List<AttributeBoostOnHealByRateTalent>.Enumerator $locvar2A;

		// Token: 0x0400551B RID: 21787
		internal AttributeBoostOnHealByRateTalent <attributeBoostOnHealByRateTalent>__35;

		// Token: 0x0400551C RID: 21788
		internal IEnumerator $locvar2B;

		// Token: 0x0400551D RID: 21789
		internal object <_>__36;

		// Token: 0x0400551E RID: 21790
		internal IDisposable $locvar2C;

		// Token: 0x0400551F RID: 21791
		internal IEnumerator $locvar2D;

		// Token: 0x04005520 RID: 21792
		internal object <_>__37;

		// Token: 0x04005521 RID: 21793
		internal IDisposable $locvar2E;

		// Token: 0x04005522 RID: 21794
		internal SkillLogicBase $this;

		// Token: 0x04005523 RID: 21795
		internal object $current;

		// Token: 0x04005524 RID: 21796
		internal bool $disposing;

		// Token: 0x04005525 RID: 21797
		internal int $PC;

		// Token: 0x04005526 RID: 21798
		private SkillLogicBase.<Cast>c__Iterator0.<Cast>c__AnonStoreyB $locvar2F;

		// Token: 0x04005527 RID: 21799
		private static Func<PushOnHitTalent, double> <>f__am$cache0;

		// Token: 0x04005528 RID: 21800
		private static Func<SelfHealOnKillTalent, double> <>f__am$cache1;

		// Token: 0x04005529 RID: 21801
		private static Func<StunOnDamageTalent, int> <>f__am$cache2;

		// Token: 0x0400552A RID: 21802
		private static Func<ShieldOnKillTalent, int> <>f__am$cache3;

		// Token: 0x0400552B RID: 21803
		private static Func<DamageComponent, bool> <>f__am$cache4;

		// Token: 0x0400552C RID: 21804
		private static Func<DamageComponent, bool> <>f__am$cache5;

		// Token: 0x0400552D RID: 21805
		private static Func<BattleEffectBase, bool> <>f__am$cache6;

		// Token: 0x0400552E RID: 21806
		private static Func<DamageComponent, bool> <>f__am$cache7;

		// Token: 0x0400552F RID: 21807
		private static Func<BoostSetting, AttributeModifier> <>f__am$cache8;

		// Token: 0x04005530 RID: 21808
		private static Func<BoostSetting, AttributeModifier> <>f__am$cache9;

		// Token: 0x04005531 RID: 21809
		private static Func<DamageComponent, bool> <>f__am$cacheA;

		// Token: 0x04005532 RID: 21810
		private static Func<BoostSetting, AttributeModifier> <>f__am$cacheB;

		// Token: 0x04005533 RID: 21811
		private static Func<IBattleUnit, double> <>f__am$cacheC;

		// Token: 0x04005534 RID: 21812
		private static Func<BoostSetting, AttributeModifier> <>f__am$cacheD;

		// Token: 0x02000EE5 RID: 3813
		private sealed class <Cast>c__AnonStoreyB
		{
			// Token: 0x06006041 RID: 24641 RVA: 0x0012C0CD File Offset: 0x0012A4CD
			public <Cast>c__AnonStoreyB()
			{
			}

			// Token: 0x06006042 RID: 24642 RVA: 0x0012C0D5 File Offset: 0x0012A4D5
			internal bool <>m__0(IBattleUnit e)
			{
				return e != this.skill.SourceUnit;
			}

			// Token: 0x06006043 RID: 24643 RVA: 0x0012C0E8 File Offset: 0x0012A4E8
			internal AttributeModifier <>m__1(AttributeBoostMemberOnKillBasedOnSelfRateTalent b)
			{
				return new AttributeModifier
				{
					AttributeType = b.GetBoostType(),
					ModificationType = ModificationType.Addition,
					Value = b.GetBoostRate() * this.skill.SourceUnit.GetAttributeValue_Final(b.GetBoostType(), AttributeRetrievalLevel.Skill),
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				};
			}

			// Token: 0x0400555F RID: 21855
			internal AdventureUnitSkill skill;

			// Token: 0x04005560 RID: 21856
			internal SkillLogicBase.<Cast>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000EDB RID: 3803
	[CompilerGenerated]
	private sealed class <PostDamageProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005FF1 RID: 24561 RVA: 0x0012C145 File Offset: 0x0012A545
		[DebuggerHidden]
		public <PostDamageProcess>c__Iterator1()
		{
		}

		// Token: 0x06005FF2 RID: 24562 RVA: 0x0012C14D File Offset: 0x0012A54D
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700140E RID: 5134
		// (get) Token: 0x06005FF3 RID: 24563 RVA: 0x0012C167 File Offset: 0x0012A567
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700140F RID: 5135
		// (get) Token: 0x06005FF4 RID: 24564 RVA: 0x0012C16F File Offset: 0x0012A56F
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005FF5 RID: 24565 RVA: 0x0012C177 File Offset: 0x0012A577
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005FF6 RID: 24566 RVA: 0x0012C179 File Offset: 0x0012A579
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005FF7 RID: 24567 RVA: 0x0012C180 File Offset: 0x0012A580
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005FF8 RID: 24568 RVA: 0x0012C188 File Offset: 0x0012A588
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SkillLogicBase.<PostDamageProcess>c__Iterator1();
		}

		// Token: 0x04005535 RID: 21813
		internal object $current;

		// Token: 0x04005536 RID: 21814
		internal bool $disposing;

		// Token: 0x04005537 RID: 21815
		internal int $PC;
	}

	// Token: 0x02000EDC RID: 3804
	[CompilerGenerated]
	private sealed class <PriorDamageFormationProcess>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005FF9 RID: 24569 RVA: 0x0012C1A3 File Offset: 0x0012A5A3
		[DebuggerHidden]
		public <PriorDamageFormationProcess>c__Iterator2()
		{
		}

		// Token: 0x06005FFA RID: 24570 RVA: 0x0012C1AB File Offset: 0x0012A5AB
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001410 RID: 5136
		// (get) Token: 0x06005FFB RID: 24571 RVA: 0x0012C1C5 File Offset: 0x0012A5C5
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001411 RID: 5137
		// (get) Token: 0x06005FFC RID: 24572 RVA: 0x0012C1CD File Offset: 0x0012A5CD
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005FFD RID: 24573 RVA: 0x0012C1D5 File Offset: 0x0012A5D5
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005FFE RID: 24574 RVA: 0x0012C1D7 File Offset: 0x0012A5D7
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005FFF RID: 24575 RVA: 0x0012C1DE File Offset: 0x0012A5DE
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006000 RID: 24576 RVA: 0x0012C1E6 File Offset: 0x0012A5E6
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SkillLogicBase.<PriorDamageFormationProcess>c__Iterator2();
		}

		// Token: 0x04005538 RID: 21816
		internal object $current;

		// Token: 0x04005539 RID: 21817
		internal bool $disposing;

		// Token: 0x0400553A RID: 21818
		internal int $PC;
	}

	// Token: 0x02000EDD RID: 3805
	[CompilerGenerated]
	private sealed class <PriorDamageProcess>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006001 RID: 24577 RVA: 0x0012C201 File Offset: 0x0012A601
		[DebuggerHidden]
		public <PriorDamageProcess>c__Iterator3()
		{
		}

		// Token: 0x06006002 RID: 24578 RVA: 0x0012C209 File Offset: 0x0012A609
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001412 RID: 5138
		// (get) Token: 0x06006003 RID: 24579 RVA: 0x0012C223 File Offset: 0x0012A623
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001413 RID: 5139
		// (get) Token: 0x06006004 RID: 24580 RVA: 0x0012C22B File Offset: 0x0012A62B
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006005 RID: 24581 RVA: 0x0012C233 File Offset: 0x0012A633
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06006006 RID: 24582 RVA: 0x0012C235 File Offset: 0x0012A635
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006007 RID: 24583 RVA: 0x0012C23C File Offset: 0x0012A63C
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006008 RID: 24584 RVA: 0x0012C244 File Offset: 0x0012A644
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SkillLogicBase.<PriorDamageProcess>c__Iterator3();
		}

		// Token: 0x0400553B RID: 21819
		internal object $current;

		// Token: 0x0400553C RID: 21820
		internal bool $disposing;

		// Token: 0x0400553D RID: 21821
		internal int $PC;
	}

	// Token: 0x02000EDE RID: 3806
	[CompilerGenerated]
	private sealed class <PostHealProcess>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006009 RID: 24585 RVA: 0x0012C25F File Offset: 0x0012A65F
		[DebuggerHidden]
		public <PostHealProcess>c__Iterator4()
		{
		}

		// Token: 0x0600600A RID: 24586 RVA: 0x0012C267 File Offset: 0x0012A667
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001414 RID: 5140
		// (get) Token: 0x0600600B RID: 24587 RVA: 0x0012C281 File Offset: 0x0012A681
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001415 RID: 5141
		// (get) Token: 0x0600600C RID: 24588 RVA: 0x0012C289 File Offset: 0x0012A689
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600600D RID: 24589 RVA: 0x0012C291 File Offset: 0x0012A691
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600600E RID: 24590 RVA: 0x0012C293 File Offset: 0x0012A693
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600600F RID: 24591 RVA: 0x0012C29A File Offset: 0x0012A69A
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006010 RID: 24592 RVA: 0x0012C2A2 File Offset: 0x0012A6A2
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SkillLogicBase.<PostHealProcess>c__Iterator4();
		}

		// Token: 0x0400553E RID: 21822
		internal object $current;

		// Token: 0x0400553F RID: 21823
		internal bool $disposing;

		// Token: 0x04005540 RID: 21824
		internal int $PC;
	}

	// Token: 0x02000EDF RID: 3807
	[CompilerGenerated]
	private sealed class <PriorHealProcess>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006011 RID: 24593 RVA: 0x0012C2BD File Offset: 0x0012A6BD
		[DebuggerHidden]
		public <PriorHealProcess>c__Iterator5()
		{
		}

		// Token: 0x06006012 RID: 24594 RVA: 0x0012C2C5 File Offset: 0x0012A6C5
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001416 RID: 5142
		// (get) Token: 0x06006013 RID: 24595 RVA: 0x0012C2DF File Offset: 0x0012A6DF
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001417 RID: 5143
		// (get) Token: 0x06006014 RID: 24596 RVA: 0x0012C2E7 File Offset: 0x0012A6E7
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006015 RID: 24597 RVA: 0x0012C2EF File Offset: 0x0012A6EF
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06006016 RID: 24598 RVA: 0x0012C2F1 File Offset: 0x0012A6F1
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006017 RID: 24599 RVA: 0x0012C2F8 File Offset: 0x0012A6F8
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006018 RID: 24600 RVA: 0x0012C300 File Offset: 0x0012A700
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SkillLogicBase.<PriorHealProcess>c__Iterator5();
		}

		// Token: 0x04005541 RID: 21825
		internal object $current;

		// Token: 0x04005542 RID: 21826
		internal bool $disposing;

		// Token: 0x04005543 RID: 21827
		internal int $PC;
	}

	// Token: 0x02000EE0 RID: 3808
	[CompilerGenerated]
	private sealed class <ProcessEvent>c__Iterator6 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006019 RID: 24601 RVA: 0x0012C31B File Offset: 0x0012A71B
		[DebuggerHidden]
		public <ProcessEvent>c__Iterator6()
		{
		}

		// Token: 0x0600601A RID: 24602 RVA: 0x0012C324 File Offset: 0x0012A724
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType == AdventureEventType.UnitReadyInBattle && eventTriggerUnit == skillOwner)
				{
					processingSkill.Timer = 0f;
				}
				if (!skillOwner.IsAliveInBattle())
				{
					enumerator2 = this.ProcessEvent_ExtraLogic_InactiveUnit(processingSkill, eventTriggerUnit, skillOwner, eventType, data).GetEnumerator();
					num = 4294967293u;
					goto Block_6;
				}
				enumerator = this.ProcessEvent_ExtraLogic_ActiveUnit(processingSkill, eventTriggerUnit, skillOwner, eventType, data).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_15A;
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
			goto IL_1DC;
			Block_6:
			try
			{
				IL_15A:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
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
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_1DC:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001418 RID: 5144
		// (get) Token: 0x0600601B RID: 24603 RVA: 0x0012C534 File Offset: 0x0012A934
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001419 RID: 5145
		// (get) Token: 0x0600601C RID: 24604 RVA: 0x0012C53C File Offset: 0x0012A93C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600601D RID: 24605 RVA: 0x0012C544 File Offset: 0x0012A944
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
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600601E RID: 24606 RVA: 0x0012C5F4 File Offset: 0x0012A9F4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600601F RID: 24607 RVA: 0x0012C5FB File Offset: 0x0012A9FB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006020 RID: 24608 RVA: 0x0012C604 File Offset: 0x0012AA04
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SkillLogicBase.<ProcessEvent>c__Iterator6 <ProcessEvent>c__Iterator = new SkillLogicBase.<ProcessEvent>c__Iterator6();
			<ProcessEvent>c__Iterator.$this = this;
			<ProcessEvent>c__Iterator.eventType = eventType;
			<ProcessEvent>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent>c__Iterator.skillOwner = skillOwner;
			<ProcessEvent>c__Iterator.processingSkill = processingSkill;
			<ProcessEvent>c__Iterator.data = data;
			return <ProcessEvent>c__Iterator;
		}

		// Token: 0x04005544 RID: 21828
		internal AdventureEventType eventType;

		// Token: 0x04005545 RID: 21829
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04005546 RID: 21830
		internal IBattleUnit skillOwner;

		// Token: 0x04005547 RID: 21831
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04005548 RID: 21832
		internal object data;

		// Token: 0x04005549 RID: 21833
		internal IEnumerator $locvar0;

		// Token: 0x0400554A RID: 21834
		internal object <_>__1;

		// Token: 0x0400554B RID: 21835
		internal IDisposable $locvar1;

		// Token: 0x0400554C RID: 21836
		internal IEnumerator $locvar2;

		// Token: 0x0400554D RID: 21837
		internal object <_>__2;

		// Token: 0x0400554E RID: 21838
		internal IDisposable $locvar3;

		// Token: 0x0400554F RID: 21839
		internal SkillLogicBase $this;

		// Token: 0x04005550 RID: 21840
		internal object $current;

		// Token: 0x04005551 RID: 21841
		internal bool $disposing;

		// Token: 0x04005552 RID: 21842
		internal int $PC;
	}

	// Token: 0x02000EE1 RID: 3809
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator7 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006021 RID: 24609 RVA: 0x0012C674 File Offset: 0x0012AA74
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator7()
		{
		}

		// Token: 0x06006022 RID: 24610 RVA: 0x0012C67C File Offset: 0x0012AA7C
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700141A RID: 5146
		// (get) Token: 0x06006023 RID: 24611 RVA: 0x0012C696 File Offset: 0x0012AA96
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700141B RID: 5147
		// (get) Token: 0x06006024 RID: 24612 RVA: 0x0012C69E File Offset: 0x0012AA9E
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006025 RID: 24613 RVA: 0x0012C6A6 File Offset: 0x0012AAA6
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06006026 RID: 24614 RVA: 0x0012C6A8 File Offset: 0x0012AAA8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006027 RID: 24615 RVA: 0x0012C6AF File Offset: 0x0012AAAF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006028 RID: 24616 RVA: 0x0012C6B7 File Offset: 0x0012AAB7
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SkillLogicBase.<PerSecondLogic_ActiveUnit>c__Iterator7();
		}

		// Token: 0x04005553 RID: 21843
		internal object $current;

		// Token: 0x04005554 RID: 21844
		internal bool $disposing;

		// Token: 0x04005555 RID: 21845
		internal int $PC;
	}

	// Token: 0x02000EE2 RID: 3810
	[CompilerGenerated]
	private sealed class <PerSecondLogic_InactiveUnit>c__Iterator8 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006029 RID: 24617 RVA: 0x0012C6D2 File Offset: 0x0012AAD2
		[DebuggerHidden]
		public <PerSecondLogic_InactiveUnit>c__Iterator8()
		{
		}

		// Token: 0x0600602A RID: 24618 RVA: 0x0012C6DA File Offset: 0x0012AADA
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700141C RID: 5148
		// (get) Token: 0x0600602B RID: 24619 RVA: 0x0012C6F4 File Offset: 0x0012AAF4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700141D RID: 5149
		// (get) Token: 0x0600602C RID: 24620 RVA: 0x0012C6FC File Offset: 0x0012AAFC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600602D RID: 24621 RVA: 0x0012C704 File Offset: 0x0012AB04
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600602E RID: 24622 RVA: 0x0012C706 File Offset: 0x0012AB06
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600602F RID: 24623 RVA: 0x0012C70D File Offset: 0x0012AB0D
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006030 RID: 24624 RVA: 0x0012C715 File Offset: 0x0012AB15
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SkillLogicBase.<PerSecondLogic_InactiveUnit>c__Iterator8();
		}

		// Token: 0x04005556 RID: 21846
		internal object $current;

		// Token: 0x04005557 RID: 21847
		internal bool $disposing;

		// Token: 0x04005558 RID: 21848
		internal int $PC;
	}

	// Token: 0x02000EE3 RID: 3811
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator9 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006031 RID: 24625 RVA: 0x0012C730 File Offset: 0x0012AB30
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator9()
		{
		}

		// Token: 0x06006032 RID: 24626 RVA: 0x0012C738 File Offset: 0x0012AB38
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700141E RID: 5150
		// (get) Token: 0x06006033 RID: 24627 RVA: 0x0012C752 File Offset: 0x0012AB52
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700141F RID: 5151
		// (get) Token: 0x06006034 RID: 24628 RVA: 0x0012C75A File Offset: 0x0012AB5A
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06006035 RID: 24629 RVA: 0x0012C762 File Offset: 0x0012AB62
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06006036 RID: 24630 RVA: 0x0012C764 File Offset: 0x0012AB64
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06006037 RID: 24631 RVA: 0x0012C76B File Offset: 0x0012AB6B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006038 RID: 24632 RVA: 0x0012C773 File Offset: 0x0012AB73
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SkillLogicBase.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator9();
		}

		// Token: 0x04005559 RID: 21849
		internal object $current;

		// Token: 0x0400555A RID: 21850
		internal bool $disposing;

		// Token: 0x0400555B RID: 21851
		internal int $PC;
	}

	// Token: 0x02000EE4 RID: 3812
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_InactiveUnit>c__IteratorA : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06006039 RID: 24633 RVA: 0x0012C78E File Offset: 0x0012AB8E
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_InactiveUnit>c__IteratorA()
		{
		}

		// Token: 0x0600603A RID: 24634 RVA: 0x0012C796 File Offset: 0x0012AB96
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001420 RID: 5152
		// (get) Token: 0x0600603B RID: 24635 RVA: 0x0012C7B0 File Offset: 0x0012ABB0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001421 RID: 5153
		// (get) Token: 0x0600603C RID: 24636 RVA: 0x0012C7B8 File Offset: 0x0012ABB8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600603D RID: 24637 RVA: 0x0012C7C0 File Offset: 0x0012ABC0
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600603E RID: 24638 RVA: 0x0012C7C2 File Offset: 0x0012ABC2
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600603F RID: 24639 RVA: 0x0012C7C9 File Offset: 0x0012ABC9
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06006040 RID: 24640 RVA: 0x0012C7D1 File Offset: 0x0012ABD1
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new SkillLogicBase.<ProcessEvent_ExtraLogic_InactiveUnit>c__IteratorA();
		}

		// Token: 0x0400555C RID: 21852
		internal object $current;

		// Token: 0x0400555D RID: 21853
		internal bool $disposing;

		// Token: 0x0400555E RID: 21854
		internal int $PC;
	}
}
