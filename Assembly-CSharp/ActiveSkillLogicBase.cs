using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using Core.Battle.RunePower;

// Token: 0x020006B7 RID: 1719
public abstract class ActiveSkillLogicBase : SkillLogicBase
{
	// Token: 0x06002D8D RID: 11661 RVA: 0x0012C7EC File Offset: 0x0012ABEC
	protected ActiveSkillLogicBase()
	{
	}

	// Token: 0x170005C8 RID: 1480
	// (get) Token: 0x06002D8E RID: 11662 RVA: 0x0012C7FB File Offset: 0x0012ABFB
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return SkillCommandType.Active;
		}
	}

	// Token: 0x170005C9 RID: 1481
	// (get) Token: 0x06002D8F RID: 11663 RVA: 0x0012C7FE File Offset: 0x0012ABFE
	public sealed override CastingStyle CastingStyle
	{
		get
		{
			return this._castingStyle;
		}
	}

	// Token: 0x06002D90 RID: 11664 RVA: 0x0012C808 File Offset: 0x0012AC08
	protected static bool IsSelfResolvable<T>() where T : ActiveSkillTargetingStrategyBase
	{
		return typeof(T) == typeof(FriendlyAllStrategy) || typeof(T) == typeof(FriendlyOrderbyStrategy) || (typeof(T) != typeof(FriendlySingleStrategy) && (typeof(T) == typeof(HostileAllStrategy) || (typeof(T) != typeof(HostileSingleStrategy) && typeof(T) == typeof(SelfStrategy))));
	}

	// Token: 0x06002D91 RID: 11665
	public abstract bool IsSelfResolvable(AdventurerProfile profile);

	// Token: 0x06002D92 RID: 11666 RVA: 0x0012C8B8 File Offset: 0x0012ACB8
	public double GetGaugeCost(Skill skill, IBattleUnit sourceUnit)
	{
		if (sourceUnit.BattleEffects.OfType<FreeCastEffect>().Any<FreeCastEffect>())
		{
			return 0.0;
		}
		double attributeValue_Final = sourceUnit.GetAttributeValue_Final(AttributeType.SkillRageEfficiencyRate, AttributeRetrievalLevel.Skill);
		double num = 1.0;
		num += sourceUnit.SpecialEffects.OfType<MindlessData>().Sum((MindlessData s) => s.CurrentCostIncreasedRate);
		double num2 = num - attributeValue_Final;
		if (num2 < 0.2)
		{
			num2 = 0.2;
		}
		double num3 = this.GetGaugeCost(skill);
		TacticRageCostChangeData tacticRageCostChangeData = sourceUnit.SpecialEffects.OfType<TacticRageCostChangeData>().FirstOrDefault<TacticRageCostChangeData>();
		if (tacticRageCostChangeData != null)
		{
			num3 = tacticRageCostChangeData.Cost;
		}
		if (sourceUnit.GetUnitType() == UnitClass.Killer)
		{
			ThousandKnivesExtremeDamageEnhancementData thousandKnivesExtremeDamageEnhancementData = sourceUnit.SpecialEffects.OfType<ThousandKnivesExtremeDamageEnhancementData>().FirstOrDefault<ThousandKnivesExtremeDamageEnhancementData>();
			if (thousandKnivesExtremeDamageEnhancementData != null)
			{
				num3 *= 0.5;
			}
		}
		double num4 = num3 * num2;
		if (num4 > 100.0)
		{
			num4 = 100.0;
		}
		return num4;
	}

	// Token: 0x06002D93 RID: 11667 RVA: 0x0012C9C8 File Offset: 0x0012ADC8
	public double GetGaugeCost(Skill skill, AdventurerProfile sourceUnit)
	{
		double attributeValue_Final = sourceUnit.GetAttributeValue_Final(AttributeType.SkillRageEfficiencyRate, AttributeRetrievalLevel.Skill);
		double num = 1.0 - attributeValue_Final;
		if (num < 0.2)
		{
			num = 0.2;
		}
		double num2 = this.GetGaugeCost(skill);
		TacticRageCostChangeData tacticRageCostChangeData = sourceUnit.GetSpecialEffects().OfType<TacticRageCostChangeData>().FirstOrDefault<TacticRageCostChangeData>();
		if (tacticRageCostChangeData != null)
		{
			num2 = tacticRageCostChangeData.Cost;
		}
		return num2 * num;
	}

	// Token: 0x06002D94 RID: 11668
	public abstract double GetGaugeCost(Skill skill);

	// Token: 0x06002D95 RID: 11669
	public abstract float? CoolingDownSeconds(Skill skill);

	// Token: 0x06002D96 RID: 11670 RVA: 0x0012CA30 File Offset: 0x0012AE30
	public virtual bool IsCastable(AdventureUnitSkill skill)
	{
		BattleEncounter battleEncounter = skill.SourceUnit.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			bool result;
			if ((this.MetGaugeRequirement(skill) || skill.SourceUnit.BattleEffects.OfType<FreeCastEffect>().Any<FreeCastEffect>()) && this.GetCoolingDownRemainingSeconds(skill) <= 0f && skill.SourceUnit.Status == BattleUnitStatus.Active && !skill.InProgress && !battleEncounter.TacticInProgress && !skill.SourceUnit.BattleEffects.OfType<SiliencedEffect>().Any<SiliencedEffect>())
			{
				result = skill.SourceUnit.BattleEffects.All((BattleEffectBase e) => e.BattleEffectType != BattleEffectType.Fear);
			}
			else
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	// Token: 0x06002D97 RID: 11671 RVA: 0x0012CAFE File Offset: 0x0012AEFE
	public float GetCoolingDownRemainingSeconds(AdventureUnitSkill skill)
	{
		if (skill.RemainingCoolingDownSeconds != null)
		{
			return skill.RemainingCoolingDownSeconds.Value;
		}
		return 0f;
	}

	// Token: 0x06002D98 RID: 11672 RVA: 0x0012CB24 File Offset: 0x0012AF24
	public bool MetGaugeRequirement(AdventureUnitSkill skill)
	{
		BattleEncounter battleEncounter = skill.SourceUnit.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			double num;
			if (skill.SourceUnit.IsPlayer)
			{
				num = battleEncounter.PlayerGauge;
			}
			else
			{
				num = battleEncounter.EnemyGauge;
			}
			return num >= this.GetGaugeCost(skill.Skill, skill.SourceUnit);
		}
		return false;
	}

	// Token: 0x06002D99 RID: 11673
	public abstract ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill);

	// Token: 0x06002D9A RID: 11674 RVA: 0x0012CB90 File Offset: 0x0012AF90
	public sealed override IEnumerable Cast(AdventureUnitSkill skill)
	{
		yield break;
	}

	// Token: 0x06002D9B RID: 11675 RVA: 0x0012CBAC File Offset: 0x0012AFAC
	public bool IsAutoCastable(AdventureUnitSkill skill)
	{
		return this.IsCastable(skill);
	}

	// Token: 0x06002D9C RID: 11676 RVA: 0x0012CBB8 File Offset: 0x0012AFB8
	public IEnumerable AutoCast(CandidateOrderringMetric orderMetric, OrderingType orderType, AdventureUnitSkill skill)
	{
		if (this.IsAutoCastable(skill))
		{
			ActiveSkillTargetingStrategyBase strategy = this.InitiatingTargetingStrategy(skill);
			if (strategy.IsResolved)
			{
				IEnumerator enumerator = this.Cast(skill, strategy, false).GetEnumerator();
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
				List<IBattleUnit> candidates = strategy.GetCandidates();
				if (candidates.Any<IBattleUnit>())
				{
					strategy.Resolve(TargetDefinition.FilterCandidates(candidates, orderMetric, orderType).Take(1).ToList<IBattleUnit>());
					IEnumerator enumerator2 = this.Cast(skill, strategy, false).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x06002D9D RID: 11677 RVA: 0x0012CBF0 File Offset: 0x0012AFF0
	public IEnumerable Cast(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy, bool forceCast = false)
	{
		if ((this.IsCastable(skill) || forceCast) && strategy.IsResolved)
		{
			BattleEncounter battleEncounter = skill.SourceUnit.CurrentEncounter as BattleEncounter;
			if (battleEncounter != null)
			{
				skill.InProgress = true;
				battleEncounter.TacticInProgress = true;
				if (!forceCast)
				{
					if (skill.SourceUnit.IsPlayer)
					{
						IEnumerator enumerator = battleEncounter.UpdatePlayerGauge(-this.GetGaugeCost(skill.Skill, skill.SourceUnit), skill).GetEnumerator();
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
						IEnumerator enumerator2 = battleEncounter.UpdateEnemyGauge(-this.GetGaugeCost(skill.Skill, skill.SourceUnit), skill).GetEnumerator();
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
				}
				Adventure currentAdventure = skill.SourceUnit.CurrentAdventure;
				double? actionCountSoFar = currentAdventure.ActionCountSoFar;
				currentAdventure.ActionCountSoFar = ((actionCountSoFar == null) ? null : new double?(actionCountSoFar.GetValueOrDefault() + 2.0));
				if (skill.SourceUnit.CurrentAdventure.RunePower != null)
				{
					int adventurePointCollectionRate = skill.SourceUnit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.PrismLightAdventurePointsCollection);
					IEnumerator enumerator3 = skill.SourceUnit.CurrentAdventure.RunePower.AddPower(RunePowerType.PrismLight, adventurePointCollectionRate * 2, skill.SourceUnit).GetEnumerator();
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
					int tacticCollectionRate = skill.SourceUnit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.PrismLightTacticCollection);
					IEnumerator enumerator4 = skill.SourceUnit.CurrentAdventure.RunePower.AddPower(RunePowerType.PrismLight, tacticCollectionRate, skill.SourceUnit).GetEnumerator();
					try
					{
						while (enumerator4.MoveNext())
						{
							object _4 = enumerator4.Current;
							yield return _4;
						}
					}
					finally
					{
						IDisposable disposable4;
						if ((disposable4 = (enumerator4 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				IEnumerator enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.AdventureEnergyPointsConsumed, 2)).GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						object _5 = enumerator5.Current;
						yield return _5;
					}
				}
				finally
				{
					IDisposable disposable5;
					if ((disposable5 = (enumerator5 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				IEnumerator enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.UnitCastsSkill, new SkillCastBattleEvent
				{
					Skill = skill,
					SkillLogic = skill.GetSkillLogic()
				})).GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						object _6 = enumerator6.Current;
						yield return _6;
					}
				}
				finally
				{
					IDisposable disposable6;
					if ((disposable6 = (enumerator6 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
				IEnumerator enumerator7 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.UnitCastActiveSkill, new ActiveSkillCastBattleEvent
				{
					Skill = skill,
					SkillLogic = skill.GetSkillLogic(),
					TargetingStrategy = strategy
				})).GetEnumerator();
				try
				{
					while (enumerator7.MoveNext())
					{
						object _7 = enumerator7.Current;
						yield return _7;
					}
				}
				finally
				{
					IDisposable disposable7;
					if ((disposable7 = (enumerator7 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
				FreeCastEffect freeCast = skill.SourceUnit.BattleEffects.OfType<FreeCastEffect>().FirstOrDefault<FreeCastEffect>();
				if (freeCast != null)
				{
					IEnumerator enumerator8 = skill.SourceUnit.LooseSkillEffect(freeCast, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
					try
					{
						while (enumerator8.MoveNext())
						{
							object _8 = enumerator8.Current;
							yield return _8;
						}
					}
					finally
					{
						IDisposable disposable8;
						if ((disposable8 = (enumerator8 as IDisposable)) != null)
						{
							disposable8.Dispose();
						}
					}
				}
				ActiveTargetAttributeDecayPriorCastData priorCastDecay = skill.SourceUnit.SpecialEffects.OfType<ActiveTargetAttributeDecayPriorCastData>().FirstOrDefault<ActiveTargetAttributeDecayPriorCastData>();
				ActiveTargetDispelPositivePriorCastData priorCastDispel = skill.SourceUnit.SpecialEffects.OfType<ActiveTargetDispelPositivePriorCastData>().FirstOrDefault<ActiveTargetDispelPositivePriorCastData>();
				if (priorCastDecay != null)
				{
					foreach (IBattleUnit strategySelection in strategy.Selections)
					{
						IEnumerator enumerator10 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = priorCastDecay.Type,
								ModificationType = priorCastDecay.ModificationType,
								Value = -priorCastDecay.Rate,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}
						}, "priorcastattributedecay", new int?(1), new float?((float)priorCastDecay.Seconds), null, true, true), false).GetEnumerator();
						try
						{
							while (enumerator10.MoveNext())
							{
								object _9 = enumerator10.Current;
								yield return _9;
							}
						}
						finally
						{
							IDisposable disposable9;
							if ((disposable9 = (enumerator10 as IDisposable)) != null)
							{
								disposable9.Dispose();
							}
						}
					}
				}
				if (priorCastDispel != null)
				{
					foreach (IBattleUnit strategySelection2 in strategy.Selections)
					{
						IEnumerator enumerator12 = UnitStyleConfigurationBase.DispelNegativeEffects(strategySelection2, new int?(priorCastDispel.NumberOfDispels)).GetEnumerator();
						try
						{
							while (enumerator12.MoveNext())
							{
								object _10 = enumerator12.Current;
								yield return _10;
							}
						}
						finally
						{
							IDisposable disposable10;
							if ((disposable10 = (enumerator12 as IDisposable)) != null)
							{
								disposable10.Dispose();
							}
						}
					}
				}
				IEnumerator enumerator13 = this.CastSkillLogic(skill, strategy).GetEnumerator();
				try
				{
					while (enumerator13.MoveNext())
					{
						object _11 = enumerator13.Current;
						yield return _11;
					}
				}
				finally
				{
					IDisposable disposable11;
					if ((disposable11 = (enumerator13 as IDisposable)) != null)
					{
						disposable11.Dispose();
					}
				}
				List<ActiveStrategyTargetBoostData> activeBoostDatas = skill.SourceUnit.SpecialEffects.OfType<ActiveStrategyTargetBoostData>().ToList<ActiveStrategyTargetBoostData>();
				foreach (ActiveStrategyTargetBoostData activeStrategyTargetBoostData in activeBoostDatas)
				{
					foreach (IBattleUnit strategySelection3 in strategy.Selections)
					{
						IEnumerator enumerator16 = strategySelection3.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = activeStrategyTargetBoostData.Type,
								ModificationType = activeStrategyTargetBoostData.ModificationType,
								Value = activeStrategyTargetBoostData.Value,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}
						}, "activeboost" + activeStrategyTargetBoostData.Type + activeStrategyTargetBoostData.ModificationType, new int?(1), new float?((float)activeStrategyTargetBoostData.Seconds), null, false, true, false), false).GetEnumerator();
						try
						{
							while (enumerator16.MoveNext())
							{
								object _12 = enumerator16.Current;
								yield return _12;
							}
						}
						finally
						{
							IDisposable disposable12;
							if ((disposable12 = (enumerator16 as IDisposable)) != null)
							{
								disposable12.Dispose();
							}
						}
					}
				}
				List<ActiveStrategyTargetDebuffData> activedebuffDatas = skill.SourceUnit.SpecialEffects.OfType<ActiveStrategyTargetDebuffData>().ToList<ActiveStrategyTargetDebuffData>();
				foreach (ActiveStrategyTargetDebuffData activeStrategyTargetdebuffData in activedebuffDatas)
				{
					foreach (IBattleUnit strategySelection4 in strategy.Selections)
					{
						IEnumerator enumerator19 = strategySelection4.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = activeStrategyTargetdebuffData.Type,
								ModificationType = activeStrategyTargetdebuffData.ModificationType,
								Value = -activeStrategyTargetdebuffData.Value,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}
						}, "activedebuff" + activeStrategyTargetdebuffData.Type + activeStrategyTargetdebuffData.ModificationType, new int?(1), new float?((float)activeStrategyTargetdebuffData.Seconds), null, true, true), false).GetEnumerator();
						try
						{
							while (enumerator19.MoveNext())
							{
								object _13 = enumerator19.Current;
								yield return _13;
							}
						}
						finally
						{
							IDisposable disposable13;
							if ((disposable13 = (enumerator19 as IDisposable)) != null)
							{
								disposable13.Dispose();
							}
						}
					}
				}
				ActiveTargetPushProgressData pushEnhancement = skill.SourceUnit.SpecialEffects.OfType<ActiveTargetPushProgressData>().FirstOrDefault<ActiveTargetPushProgressData>();
				if (pushEnhancement != null)
				{
					foreach (IBattleUnit strategySelection5 in strategy.Selections)
					{
						UnitTurnProgressUpdateEvent change = new UnitTurnProgressUpdateEvent
						{
							Dealer = skill.SourceUnit,
							ChangePercentage = -pushEnhancement.PushRate,
							CausingSource = skill
						};
						IEnumerator enumerator21 = strategySelection5.ChangeTurnCounterProgress(change).GetEnumerator();
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
				IEnumerator enumerator22 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.UnitPostCastSkill, new SkillCastBattleEvent
				{
					Skill = skill,
					SkillLogic = skill.GetSkillLogic()
				})).GetEnumerator();
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
				IEnumerator enumerator23 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.UnitPostCastActiveSkill, new ActiveSkillCastBattleEvent
				{
					Skill = skill,
					SkillLogic = skill.GetSkillLogic(),
					TargetingStrategy = strategy
				})).GetEnumerator();
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
				IEnumerator enumerator24 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.UnitCompletesSkillCast, null)).GetEnumerator();
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
				IEnumerator enumerator25 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.UnitCompleteActiveSkill, null)).GetEnumerator();
				try
				{
					while (enumerator25.MoveNext())
					{
						object _18 = enumerator25.Current;
						yield return _18;
					}
				}
				finally
				{
					IDisposable disposable18;
					if ((disposable18 = (enumerator25 as IDisposable)) != null)
					{
						disposable18.Dispose();
					}
				}
				skill.InProgress = false;
				battleEncounter.TacticInProgress = false;
			}
		}
		yield break;
	}

	// Token: 0x06002D9E RID: 11678 RVA: 0x0012CC28 File Offset: 0x0012B028
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		List<AdventureEventType> list = new List<AdventureEventType>
		{
			AdventureEventType.BattleEncounterPlayerGaugeFullyCharged,
			AdventureEventType.BattleEncounterEnemyGaugeFullyCharged,
			AdventureEventType.BattleEncounterPlayerGaugeReleased,
			AdventureEventType.BattleEncounterEnemyGaugeReleased,
			AdventureEventType.ActiveBattleSkillEntersCoolingDowns,
			AdventureEventType.ActiveBattleSkillCompletesCoolingDowns
		};
		list.AddRange(this.ActiveAdditionalEvents());
		return list;
	}

	// Token: 0x06002D9F RID: 11679
	public abstract List<AdventureEventType> ActiveAdditionalEvents();

	// Token: 0x06002DA0 RID: 11680 RVA: 0x0012CC7C File Offset: 0x0012B07C
	public sealed override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReadyInBattle && eventTriggerUnit == skillOwner)
		{
			processingSkill.InProgress = false;
		}
		if (((eventType == AdventureEventType.BattleEncounterPlayerGaugeFullyCharged && skillOwner.IsPlayer) || (eventType == AdventureEventType.BattleEncounterEnemyGaugeFullyCharged && !skillOwner.IsPlayer)) && this.GetCoolingDownRemainingSeconds(processingSkill) <= 0f && !processingSkill.PassiveHasBeenRecentlyApplied)
		{
			IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(processingSkill.SourceUnit, AdventureEventType.ActiveSkillPassiveBecomesAlive, processingSkill)).GetEnumerator();
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
			IEnumerator enumerator2 = this.PassiveEffectApplies(processingSkill).GetEnumerator();
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
			processingSkill.PassiveHasBeenRecentlyApplied = true;
		}
		if ((eventType == AdventureEventType.BattleEncounterPlayerGaugeReleased && skillOwner.IsPlayer) || (eventType == AdventureEventType.BattleEncounterEnemyGaugeReleased && !skillOwner.IsPlayer))
		{
			BattleGaugeUpdateEvent update = data as BattleGaugeUpdateEvent;
			if (update.CurrentValue < 100.0 && processingSkill.PassiveHasBeenRecentlyApplied)
			{
				IEnumerator enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(processingSkill.SourceUnit, AdventureEventType.ActiveSkillPassiveBecomesFades, processingSkill)).GetEnumerator();
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
				processingSkill.PassiveHasBeenRecentlyApplied = false;
				IEnumerator enumerator4 = this.PassiveEffectLooses(processingSkill).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _4 = enumerator4.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
		}
		if (eventTriggerUnit == skillOwner)
		{
			if (eventType == AdventureEventType.ActiveBattleSkillEntersCoolingDowns)
			{
				AdventureUnitSkill cdSkill = data as AdventureUnitSkill;
				if (cdSkill == processingSkill && processingSkill.PassiveHasBeenRecentlyApplied)
				{
					IEnumerator enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(processingSkill.SourceUnit, AdventureEventType.ActiveSkillPassiveBecomesFades, processingSkill)).GetEnumerator();
					try
					{
						while (enumerator5.MoveNext())
						{
							object _5 = enumerator5.Current;
							yield return _5;
						}
					}
					finally
					{
						IDisposable disposable5;
						if ((disposable5 = (enumerator5 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
					processingSkill.PassiveHasBeenRecentlyApplied = false;
					IEnumerator enumerator6 = this.PassiveEffectLooses(processingSkill).GetEnumerator();
					try
					{
						while (enumerator6.MoveNext())
						{
							object _6 = enumerator6.Current;
							yield return _6;
						}
					}
					finally
					{
						IDisposable disposable6;
						if ((disposable6 = (enumerator6 as IDisposable)) != null)
						{
							disposable6.Dispose();
						}
					}
				}
			}
			if (eventType == AdventureEventType.ActiveBattleSkillCompletesCoolingDowns)
			{
				AdventureUnitSkill cdSkill2 = data as AdventureUnitSkill;
				if (cdSkill2 == processingSkill)
				{
					BattleEncounter battleEncounter = processingSkill.SourceUnit.CurrentEncounter as BattleEncounter;
					if (battleEncounter != null)
					{
						double currentGauge = battleEncounter.GetGauge(processingSkill.SourceUnit);
						if (currentGauge >= 100.0 && !processingSkill.PassiveHasBeenRecentlyApplied)
						{
							IEnumerator enumerator7 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(processingSkill.SourceUnit, AdventureEventType.ActiveSkillPassiveBecomesAlive, processingSkill)).GetEnumerator();
							try
							{
								while (enumerator7.MoveNext())
								{
									object _7 = enumerator7.Current;
									yield return _7;
								}
							}
							finally
							{
								IDisposable disposable7;
								if ((disposable7 = (enumerator7 as IDisposable)) != null)
								{
									disposable7.Dispose();
								}
							}
							IEnumerator enumerator8 = this.PassiveEffectApplies(processingSkill).GetEnumerator();
							try
							{
								while (enumerator8.MoveNext())
								{
									object _8 = enumerator8.Current;
									yield return _8;
								}
							}
							finally
							{
								IDisposable disposable8;
								if ((disposable8 = (enumerator8 as IDisposable)) != null)
								{
									disposable8.Dispose();
								}
							}
							processingSkill.PassiveHasBeenRecentlyApplied = true;
						}
					}
				}
			}
		}
		if (this.PassiveIsActive(processingSkill))
		{
			IEnumerator enumerator9 = this.PassiveBeingActiveEventProcess(processingSkill, eventTriggerUnit, skillOwner, eventType, data).GetEnumerator();
			try
			{
				while (enumerator9.MoveNext())
				{
					object _9 = enumerator9.Current;
					yield return _9;
				}
			}
			finally
			{
				IDisposable disposable9;
				if ((disposable9 = (enumerator9 as IDisposable)) != null)
				{
					disposable9.Dispose();
				}
			}
		}
		IEnumerator enumerator10 = this.AdditionalEventProcess(processingSkill, eventTriggerUnit, skillOwner, eventType, data).GetEnumerator();
		try
		{
			while (enumerator10.MoveNext())
			{
				object _10 = enumerator10.Current;
				yield return _10;
			}
		}
		finally
		{
			IDisposable disposable10;
			if ((disposable10 = (enumerator10 as IDisposable)) != null)
			{
				disposable10.Dispose();
			}
		}
		yield break;
	}

	// Token: 0x06002DA1 RID: 11681 RVA: 0x0012CCC4 File Offset: 0x0012B0C4
	protected virtual IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		yield break;
	}

	// Token: 0x06002DA2 RID: 11682 RVA: 0x0012CCE0 File Offset: 0x0012B0E0
	protected virtual IEnumerable AdditionalEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		yield break;
	}

	// Token: 0x06002DA3 RID: 11683 RVA: 0x0012CCFC File Offset: 0x0012B0FC
	public bool PassiveIsActive(AdventureUnitSkill processingSkill)
	{
		return processingSkill.PassiveHasBeenRecentlyApplied;
	}

	// Token: 0x06002DA4 RID: 11684 RVA: 0x0012CD04 File Offset: 0x0012B104
	public virtual IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		yield break;
	}

	// Token: 0x06002DA5 RID: 11685 RVA: 0x0012CD20 File Offset: 0x0012B120
	public virtual IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		yield break;
	}

	// Token: 0x06002DA6 RID: 11686
	public abstract IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy);

	// Token: 0x06002DA7 RID: 11687 RVA: 0x0012CD3C File Offset: 0x0012B13C
	[CompilerGenerated]
	private static double <GetGaugeCost>m__0(MindlessData s)
	{
		return s.CurrentCostIncreasedRate;
	}

	// Token: 0x06002DA8 RID: 11688 RVA: 0x0012CD44 File Offset: 0x0012B144
	[CompilerGenerated]
	private static bool <IsCastable>m__1(BattleEffectBase e)
	{
		return e.BattleEffectType != BattleEffectType.Fear;
	}

	// Token: 0x040026D9 RID: 9945
	private CastingStyle _castingStyle = CastingStyle.DirectCast;

	// Token: 0x040026DA RID: 9946
	[CompilerGenerated]
	private static Func<MindlessData, double> <>f__am$cache0;

	// Token: 0x040026DB RID: 9947
	[CompilerGenerated]
	private static Func<BattleEffectBase, bool> <>f__am$cache1;

	// Token: 0x02000DE8 RID: 3560
	[CompilerGenerated]
	private sealed class <Cast>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005940 RID: 22848 RVA: 0x0012CD53 File Offset: 0x0012B153
		[DebuggerHidden]
		public <Cast>c__Iterator0()
		{
		}

		// Token: 0x06005941 RID: 22849 RVA: 0x0012CD5B File Offset: 0x0012B15B
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x17001298 RID: 4760
		// (get) Token: 0x06005942 RID: 22850 RVA: 0x0012CD75 File Offset: 0x0012B175
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001299 RID: 4761
		// (get) Token: 0x06005943 RID: 22851 RVA: 0x0012CD7D File Offset: 0x0012B17D
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005944 RID: 22852 RVA: 0x0012CD85 File Offset: 0x0012B185
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005945 RID: 22853 RVA: 0x0012CD87 File Offset: 0x0012B187
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005946 RID: 22854 RVA: 0x0012CD8E File Offset: 0x0012B18E
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005947 RID: 22855 RVA: 0x0012CD96 File Offset: 0x0012B196
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new ActiveSkillLogicBase.<Cast>c__Iterator0();
		}

		// Token: 0x0400490B RID: 18699
		internal object $current;

		// Token: 0x0400490C RID: 18700
		internal bool $disposing;

		// Token: 0x0400490D RID: 18701
		internal int $PC;
	}

	// Token: 0x02000DE9 RID: 3561
	[CompilerGenerated]
	private sealed class <AutoCast>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005948 RID: 22856 RVA: 0x0012CDB1 File Offset: 0x0012B1B1
		[DebuggerHidden]
		public <AutoCast>c__Iterator1()
		{
		}

		// Token: 0x06005949 RID: 22857 RVA: 0x0012CDBC File Offset: 0x0012B1BC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (!base.IsAutoCastable(skill))
				{
					goto IL_207;
				}
				strategy = this.InitiatingTargetingStrategy(skill);
				if (strategy.IsResolved)
				{
					enumerator = base.Cast(skill, strategy, false).GetEnumerator();
					num = 4294967293u;
				}
				else
				{
					candidates = strategy.GetCandidates();
					if (candidates.Any<IBattleUnit>())
					{
						strategy.Resolve(TargetDefinition.FilterCandidates(candidates, orderMetric, orderType).Take(1).ToList<IBattleUnit>());
						enumerator2 = base.Cast(skill, strategy, false).GetEnumerator();
						num = 4294967293u;
						goto Block_6;
					}
					goto IL_207;
				}
				break;
			case 1u:
				break;
			case 2u:
				goto IL_185;
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
			goto IL_207;
			Block_6:
			try
			{
				IL_185:
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
			IL_207:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700129A RID: 4762
		// (get) Token: 0x0600594A RID: 22858 RVA: 0x0012CFF8 File Offset: 0x0012B3F8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700129B RID: 4763
		// (get) Token: 0x0600594B RID: 22859 RVA: 0x0012D000 File Offset: 0x0012B400
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600594C RID: 22860 RVA: 0x0012D008 File Offset: 0x0012B408
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

		// Token: 0x0600594D RID: 22861 RVA: 0x0012D0B8 File Offset: 0x0012B4B8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600594E RID: 22862 RVA: 0x0012D0BF File Offset: 0x0012B4BF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600594F RID: 22863 RVA: 0x0012D0C8 File Offset: 0x0012B4C8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ActiveSkillLogicBase.<AutoCast>c__Iterator1 <AutoCast>c__Iterator = new ActiveSkillLogicBase.<AutoCast>c__Iterator1();
			<AutoCast>c__Iterator.$this = this;
			<AutoCast>c__Iterator.skill = skill;
			<AutoCast>c__Iterator.orderMetric = orderMetric;
			<AutoCast>c__Iterator.orderType = orderType;
			return <AutoCast>c__Iterator;
		}

		// Token: 0x0400490E RID: 18702
		internal AdventureUnitSkill skill;

		// Token: 0x0400490F RID: 18703
		internal ActiveSkillTargetingStrategyBase <strategy>__1;

		// Token: 0x04004910 RID: 18704
		internal IEnumerator $locvar0;

		// Token: 0x04004911 RID: 18705
		internal object <_>__2;

		// Token: 0x04004912 RID: 18706
		internal IDisposable $locvar1;

		// Token: 0x04004913 RID: 18707
		internal List<IBattleUnit> <candidates>__3;

		// Token: 0x04004914 RID: 18708
		internal CandidateOrderringMetric orderMetric;

		// Token: 0x04004915 RID: 18709
		internal OrderingType orderType;

		// Token: 0x04004916 RID: 18710
		internal IEnumerator $locvar2;

		// Token: 0x04004917 RID: 18711
		internal object <_>__4;

		// Token: 0x04004918 RID: 18712
		internal IDisposable $locvar3;

		// Token: 0x04004919 RID: 18713
		internal ActiveSkillLogicBase $this;

		// Token: 0x0400491A RID: 18714
		internal object $current;

		// Token: 0x0400491B RID: 18715
		internal bool $disposing;

		// Token: 0x0400491C RID: 18716
		internal int $PC;
	}

	// Token: 0x02000DEA RID: 3562
	[CompilerGenerated]
	private sealed class <Cast>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005950 RID: 22864 RVA: 0x0012D120 File Offset: 0x0012B520
		[DebuggerHidden]
		public <Cast>c__Iterator2()
		{
		}

		// Token: 0x06005951 RID: 22865 RVA: 0x0012D128 File Offset: 0x0012B528
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if ((!this.IsCastable(skill) && !forceCast) || !strategy.IsResolved)
				{
					goto IL_14CB;
				}
				battleEncounter = (skill.SourceUnit.CurrentEncounter as BattleEncounter);
				if (battleEncounter == null)
				{
					goto IL_14CB;
				}
				skill.InProgress = true;
				battleEncounter.TacticInProgress = true;
				if (forceCast)
				{
					goto IL_281;
				}
				if (!skill.SourceUnit.IsPlayer)
				{
					enumerator2 = battleEncounter.UpdateEnemyGauge(-base.GetGaugeCost(skill.Skill, skill.SourceUnit), skill).GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				}
				enumerator = battleEncounter.UpdatePlayerGauge(-base.GetGaugeCost(skill.Skill, skill.SourceUnit), skill).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1FF;
			case 3u:
				Block_11:
				try
				{
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
				tacticCollectionRate = skill.SourceUnit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.PrismLightTacticCollection);
				enumerator4 = skill.SourceUnit.CurrentAdventure.RunePower.AddPower(RunePowerType.PrismLight, tacticCollectionRate, skill.SourceUnit).GetEnumerator();
				num = 4294967293u;
				goto Block_12;
			case 4u:
				goto IL_427;
			case 5u:
				Block_13:
				try
				{
					switch (num)
					{
					}
					if (enumerator5.MoveNext())
					{
						_5 = enumerator5.Current;
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
						if ((disposable5 = (enumerator5 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				enumerator6 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.UnitCastsSkill, new SkillCastBattleEvent
				{
					Skill = skill,
					SkillLogic = skill.GetSkillLogic()
				})).GetEnumerator();
				num = 4294967293u;
				goto Block_14;
			case 6u:
				goto IL_5AD;
			case 7u:
				goto IL_68E;
			case 8u:
				goto IL_760;
			case 9u:
				Block_19:
				try
				{
					switch (num)
					{
					case 9u:
						Block_80:
						try
						{
							switch (num)
							{
							}
							if (enumerator10.MoveNext())
							{
								_9 = enumerator10.Current;
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
								if ((disposable9 = (enumerator10 as IDisposable)) != null)
								{
									disposable9.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator9.MoveNext())
					{
						strategySelection = enumerator9.Current;
						enumerator10 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
						{
							new AttributeModifier
							{
								AttributeType = priorCastDecay.Type,
								ModificationType = priorCastDecay.ModificationType,
								Value = -priorCastDecay.Rate,
								Key = string.Empty,
								AttributeModifierType = AttributeModifierType.Skill
							}
						}, "priorcastattributedecay", new int?(1), new float?((float)priorCastDecay.Seconds), null, true, true), false).GetEnumerator();
						num = 4294967293u;
						goto Block_80;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator9).Dispose();
					}
				}
				goto IL_9CE;
			case 10u:
				Block_21:
				try
				{
					switch (num)
					{
					case 10u:
						Block_91:
						try
						{
							switch (num)
							{
							}
							if (enumerator12.MoveNext())
							{
								_10 = enumerator12.Current;
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
								if ((disposable10 = (enumerator12 as IDisposable)) != null)
								{
									disposable10.Dispose();
								}
							}
						}
						break;
					}
					if (enumerator11.MoveNext())
					{
						strategySelection2 = enumerator11.Current;
						enumerator12 = UnitStyleConfigurationBase.DispelNegativeEffects(strategySelection2, new int?(priorCastDispel.NumberOfDispels)).GetEnumerator();
						num = 4294967293u;
						goto Block_91;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)enumerator11).Dispose();
					}
				}
				goto IL_AED;
			case 11u:
				Block_22:
				try
				{
					switch (num)
					{
					}
					if (enumerator13.MoveNext())
					{
						_11 = enumerator13.Current;
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
						if ((disposable11 = (enumerator13 as IDisposable)) != null)
						{
							disposable11.Dispose();
						}
					}
				}
				activeBoostDatas = skill.SourceUnit.SpecialEffects.OfType<ActiveStrategyTargetBoostData>().ToList<ActiveStrategyTargetBoostData>();
				enumerator14 = activeBoostDatas.GetEnumerator();
				num = 4294967293u;
				goto Block_23;
			case 12u:
				goto IL_BCA;
			case 13u:
				goto IL_E12;
			case 14u:
				goto IL_106A;
			case 15u:
				Block_27:
				try
				{
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
				enumerator23 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.UnitPostCastActiveSkill, new ActiveSkillCastBattleEvent
				{
					Skill = skill,
					SkillLogic = skill.GetSkillLogic(),
					TargetingStrategy = strategy
				})).GetEnumerator();
				num = 4294967293u;
				goto Block_28;
			case 16u:
				goto IL_12D1;
			case 17u:
				goto IL_1380;
			case 18u:
				goto IL_142F;
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
			goto IL_281;
			Block_8:
			try
			{
				IL_1FF:
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
			IL_281:
			Adventure currentAdventure = skill.SourceUnit.CurrentAdventure;
			double? actionCountSoFar = currentAdventure.ActionCountSoFar;
			currentAdventure.ActionCountSoFar = ((actionCountSoFar == null) ? null : new double?(actionCountSoFar.GetValueOrDefault() + 2.0));
			if (skill.SourceUnit.CurrentAdventure.RunePower != null)
			{
				adventurePointCollectionRate = skill.SourceUnit.CurrentAdventure.RunePower.GetRate(SpecialEffectType.PrismLightAdventurePointsCollection);
				enumerator3 = skill.SourceUnit.CurrentAdventure.RunePower.AddPower(RunePowerType.PrismLight, adventurePointCollectionRate * 2, skill.SourceUnit).GetEnumerator();
				num = 4294967293u;
				goto Block_11;
			}
			goto IL_4A9;
			Block_12:
			try
			{
				IL_427:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_4 = enumerator4.Current;
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
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			IL_4A9:
			enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.AdventureEnergyPointsConsumed, 2)).GetEnumerator();
			num = 4294967293u;
			goto Block_13;
			Block_14:
			try
			{
				IL_5AD:
				switch (num)
				{
				}
				if (enumerator6.MoveNext())
				{
					_6 = enumerator6.Current;
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
					if ((disposable6 = (enumerator6 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
			enumerator7 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.UnitCastActiveSkill, new ActiveSkillCastBattleEvent
			{
				Skill = skill,
				SkillLogic = skill.GetSkillLogic(),
				TargetingStrategy = strategy
			})).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_68E:
				switch (num)
				{
				}
				if (enumerator7.MoveNext())
				{
					_7 = enumerator7.Current;
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
					if ((disposable7 = (enumerator7 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
			}
			freeCast = skill.SourceUnit.BattleEffects.OfType<FreeCastEffect>().FirstOrDefault<FreeCastEffect>();
			if (freeCast == null)
			{
				goto IL_7E2;
			}
			enumerator8 = skill.SourceUnit.LooseSkillEffect(freeCast, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_760:
				switch (num)
				{
				}
				if (enumerator8.MoveNext())
				{
					_8 = enumerator8.Current;
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
					if ((disposable8 = (enumerator8 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
			}
			IL_7E2:
			priorCastDecay = skill.SourceUnit.SpecialEffects.OfType<ActiveTargetAttributeDecayPriorCastData>().FirstOrDefault<ActiveTargetAttributeDecayPriorCastData>();
			priorCastDispel = skill.SourceUnit.SpecialEffects.OfType<ActiveTargetDispelPositivePriorCastData>().FirstOrDefault<ActiveTargetDispelPositivePriorCastData>();
			if (priorCastDecay != null)
			{
				enumerator9 = strategy.Selections.GetEnumerator();
				num = 4294967293u;
				goto Block_19;
			}
			IL_9CE:
			if (priorCastDispel != null)
			{
				enumerator11 = strategy.Selections.GetEnumerator();
				num = 4294967293u;
				goto Block_21;
			}
			IL_AED:
			enumerator13 = this.CastSkillLogic(skill, strategy).GetEnumerator();
			num = 4294967293u;
			goto Block_22;
			Block_23:
			try
			{
				IL_BCA:
				switch (num)
				{
				case 12u:
					Block_108:
					try
					{
						switch (num)
						{
						case 12u:
							Block_111:
							try
							{
								switch (num)
								{
								}
								if (enumerator16.MoveNext())
								{
									_12 = enumerator16.Current;
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
									if ((disposable12 = (enumerator16 as IDisposable)) != null)
									{
										disposable12.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator15.MoveNext())
						{
							strategySelection3 = enumerator15.Current;
							enumerator16 = strategySelection3.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
							{
								new AttributeModifier
								{
									AttributeType = activeStrategyTargetBoostData.Type,
									ModificationType = activeStrategyTargetBoostData.ModificationType,
									Value = activeStrategyTargetBoostData.Value,
									Key = string.Empty,
									AttributeModifierType = AttributeModifierType.Skill
								}
							}, "activeboost" + activeStrategyTargetBoostData.Type + activeStrategyTargetBoostData.ModificationType, new int?(1), new float?((float)activeStrategyTargetBoostData.Seconds), null, false, true, false), false).GetEnumerator();
							num = 4294967293u;
							goto Block_111;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator15).Dispose();
						}
					}
					break;
				}
				if (enumerator14.MoveNext())
				{
					activeStrategyTargetBoostData = enumerator14.Current;
					enumerator15 = strategy.Selections.GetEnumerator();
					num = 4294967293u;
					goto Block_108;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator14).Dispose();
				}
			}
			activedebuffDatas = skill.SourceUnit.SpecialEffects.OfType<ActiveStrategyTargetDebuffData>().ToList<ActiveStrategyTargetDebuffData>();
			enumerator17 = activedebuffDatas.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_E12:
				switch (num)
				{
				case 13u:
					Block_124:
					try
					{
						switch (num)
						{
						case 13u:
							Block_127:
							try
							{
								switch (num)
								{
								}
								if (enumerator19.MoveNext())
								{
									_13 = enumerator19.Current;
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
									if ((disposable13 = (enumerator19 as IDisposable)) != null)
									{
										disposable13.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator18.MoveNext())
						{
							strategySelection4 = enumerator18.Current;
							enumerator19 = strategySelection4.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
							{
								new AttributeModifier
								{
									AttributeType = activeStrategyTargetdebuffData.Type,
									ModificationType = activeStrategyTargetdebuffData.ModificationType,
									Value = -activeStrategyTargetdebuffData.Value,
									Key = string.Empty,
									AttributeModifierType = AttributeModifierType.Skill
								}
							}, "activedebuff" + activeStrategyTargetdebuffData.Type + activeStrategyTargetdebuffData.ModificationType, new int?(1), new float?((float)activeStrategyTargetdebuffData.Seconds), null, true, true), false).GetEnumerator();
							num = 4294967293u;
							goto Block_127;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator18).Dispose();
						}
					}
					break;
				}
				if (enumerator17.MoveNext())
				{
					activeStrategyTargetdebuffData = enumerator17.Current;
					enumerator18 = strategy.Selections.GetEnumerator();
					num = 4294967293u;
					goto Block_124;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator17).Dispose();
				}
			}
			pushEnhancement = skill.SourceUnit.SpecialEffects.OfType<ActiveTargetPushProgressData>().FirstOrDefault<ActiveTargetPushProgressData>();
			if (pushEnhancement == null)
			{
				goto IL_119C;
			}
			enumerator20 = strategy.Selections.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_106A:
				switch (num)
				{
				case 14u:
					Block_140:
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
					break;
				}
				if (enumerator20.MoveNext())
				{
					strategySelection5 = enumerator20.Current;
					change = new UnitTurnProgressUpdateEvent
					{
						Dealer = skill.SourceUnit,
						ChangePercentage = -pushEnhancement.PushRate,
						CausingSource = skill
					};
					enumerator21 = strategySelection5.ChangeTurnCounterProgress(change).GetEnumerator();
					num = 4294967293u;
					goto Block_140;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator20).Dispose();
				}
			}
			IL_119C:
			enumerator22 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.UnitPostCastSkill, new SkillCastBattleEvent
			{
				Skill = skill,
				SkillLogic = skill.GetSkillLogic()
			})).GetEnumerator();
			num = 4294967293u;
			goto Block_27;
			Block_28:
			try
			{
				IL_12D1:
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
			enumerator24 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.UnitCompletesSkillCast, null)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1380:
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
			enumerator25 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.SourceUnit, AdventureEventType.UnitCompleteActiveSkill, null)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_142F:
				switch (num)
				{
				}
				if (enumerator25.MoveNext())
				{
					_18 = enumerator25.Current;
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
					if ((disposable18 = (enumerator25 as IDisposable)) != null)
					{
						disposable18.Dispose();
					}
				}
			}
			skill.InProgress = false;
			battleEncounter.TacticInProgress = false;
			IL_14CB:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700129C RID: 4764
		// (get) Token: 0x06005952 RID: 22866 RVA: 0x0012E868 File Offset: 0x0012CC68
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700129D RID: 4765
		// (get) Token: 0x06005953 RID: 22867 RVA: 0x0012E870 File Offset: 0x0012CC70
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005954 RID: 22868 RVA: 0x0012E878 File Offset: 0x0012CC78
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
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			case 5u:
				try
				{
				}
				finally
				{
					if ((disposable5 = (enumerator5 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				break;
			case 6u:
				try
				{
				}
				finally
				{
					if ((disposable6 = (enumerator6 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
				break;
			case 7u:
				try
				{
				}
				finally
				{
					if ((disposable7 = (enumerator7 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
				break;
			case 8u:
				try
				{
				}
				finally
				{
					if ((disposable8 = (enumerator8 as IDisposable)) != null)
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
						if ((disposable9 = (enumerator10 as IDisposable)) != null)
						{
							disposable9.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator9).Dispose();
				}
				break;
			case 10u:
				try
				{
					try
					{
					}
					finally
					{
						if ((disposable10 = (enumerator12 as IDisposable)) != null)
						{
							disposable10.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator11).Dispose();
				}
				break;
			case 11u:
				try
				{
				}
				finally
				{
					if ((disposable11 = (enumerator13 as IDisposable)) != null)
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
						try
						{
						}
						finally
						{
							if ((disposable12 = (enumerator16 as IDisposable)) != null)
							{
								disposable12.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator15).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator14).Dispose();
				}
				break;
			case 13u:
				try
				{
					try
					{
						try
						{
						}
						finally
						{
							if ((disposable13 = (enumerator19 as IDisposable)) != null)
							{
								disposable13.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator18).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator17).Dispose();
				}
				break;
			case 14u:
				try
				{
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
				}
				finally
				{
					((IDisposable)enumerator20).Dispose();
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
				}
				finally
				{
					if ((disposable18 = (enumerator25 as IDisposable)) != null)
					{
						disposable18.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005955 RID: 22869 RVA: 0x0012EF38 File Offset: 0x0012D338
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005956 RID: 22870 RVA: 0x0012EF3F File Offset: 0x0012D33F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005957 RID: 22871 RVA: 0x0012EF48 File Offset: 0x0012D348
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ActiveSkillLogicBase.<Cast>c__Iterator2 <Cast>c__Iterator = new ActiveSkillLogicBase.<Cast>c__Iterator2();
			<Cast>c__Iterator.$this = this;
			<Cast>c__Iterator.skill = skill;
			<Cast>c__Iterator.forceCast = forceCast;
			<Cast>c__Iterator.strategy = strategy;
			return <Cast>c__Iterator;
		}

		// Token: 0x0400491D RID: 18717
		internal AdventureUnitSkill skill;

		// Token: 0x0400491E RID: 18718
		internal bool forceCast;

		// Token: 0x0400491F RID: 18719
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004920 RID: 18720
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x04004921 RID: 18721
		internal IEnumerator $locvar0;

		// Token: 0x04004922 RID: 18722
		internal object <_>__2;

		// Token: 0x04004923 RID: 18723
		internal IDisposable $locvar1;

		// Token: 0x04004924 RID: 18724
		internal IEnumerator $locvar2;

		// Token: 0x04004925 RID: 18725
		internal object <_>__3;

		// Token: 0x04004926 RID: 18726
		internal IDisposable $locvar3;

		// Token: 0x04004927 RID: 18727
		internal int <adventurePointCollectionRate>__4;

		// Token: 0x04004928 RID: 18728
		internal IEnumerator $locvar4;

		// Token: 0x04004929 RID: 18729
		internal object <_>__5;

		// Token: 0x0400492A RID: 18730
		internal IDisposable $locvar5;

		// Token: 0x0400492B RID: 18731
		internal int <tacticCollectionRate>__4;

		// Token: 0x0400492C RID: 18732
		internal IEnumerator $locvar6;

		// Token: 0x0400492D RID: 18733
		internal object <_>__6;

		// Token: 0x0400492E RID: 18734
		internal IDisposable $locvar7;

		// Token: 0x0400492F RID: 18735
		internal IEnumerator $locvar8;

		// Token: 0x04004930 RID: 18736
		internal object <_>__7;

		// Token: 0x04004931 RID: 18737
		internal IDisposable $locvar9;

		// Token: 0x04004932 RID: 18738
		internal IEnumerator $locvarA;

		// Token: 0x04004933 RID: 18739
		internal object <_>__8;

		// Token: 0x04004934 RID: 18740
		internal IDisposable $locvarB;

		// Token: 0x04004935 RID: 18741
		internal IEnumerator $locvarC;

		// Token: 0x04004936 RID: 18742
		internal object <_>__9;

		// Token: 0x04004937 RID: 18743
		internal IDisposable $locvarD;

		// Token: 0x04004938 RID: 18744
		internal FreeCastEffect <freeCast>__10;

		// Token: 0x04004939 RID: 18745
		internal IEnumerator $locvarE;

		// Token: 0x0400493A RID: 18746
		internal object <_>__11;

		// Token: 0x0400493B RID: 18747
		internal IDisposable $locvarF;

		// Token: 0x0400493C RID: 18748
		internal ActiveTargetAttributeDecayPriorCastData <priorCastDecay>__10;

		// Token: 0x0400493D RID: 18749
		internal ActiveTargetDispelPositivePriorCastData <priorCastDispel>__10;

		// Token: 0x0400493E RID: 18750
		internal List<IBattleUnit>.Enumerator $locvar10;

		// Token: 0x0400493F RID: 18751
		internal IBattleUnit <strategySelection>__12;

		// Token: 0x04004940 RID: 18752
		internal IEnumerator $locvar11;

		// Token: 0x04004941 RID: 18753
		internal object <_>__13;

		// Token: 0x04004942 RID: 18754
		internal IDisposable $locvar12;

		// Token: 0x04004943 RID: 18755
		internal List<IBattleUnit>.Enumerator $locvar13;

		// Token: 0x04004944 RID: 18756
		internal IBattleUnit <strategySelection>__14;

		// Token: 0x04004945 RID: 18757
		internal IEnumerator $locvar14;

		// Token: 0x04004946 RID: 18758
		internal object <_>__15;

		// Token: 0x04004947 RID: 18759
		internal IDisposable $locvar15;

		// Token: 0x04004948 RID: 18760
		internal IEnumerator $locvar16;

		// Token: 0x04004949 RID: 18761
		internal object <_>__16;

		// Token: 0x0400494A RID: 18762
		internal IDisposable $locvar17;

		// Token: 0x0400494B RID: 18763
		internal List<ActiveStrategyTargetBoostData> <activeBoostDatas>__10;

		// Token: 0x0400494C RID: 18764
		internal List<ActiveStrategyTargetBoostData>.Enumerator $locvar18;

		// Token: 0x0400494D RID: 18765
		internal ActiveStrategyTargetBoostData <activeStrategyTargetBoostData>__17;

		// Token: 0x0400494E RID: 18766
		internal List<IBattleUnit>.Enumerator $locvar19;

		// Token: 0x0400494F RID: 18767
		internal IBattleUnit <strategySelection>__18;

		// Token: 0x04004950 RID: 18768
		internal IEnumerator $locvar1A;

		// Token: 0x04004951 RID: 18769
		internal object <_>__19;

		// Token: 0x04004952 RID: 18770
		internal IDisposable $locvar1B;

		// Token: 0x04004953 RID: 18771
		internal List<ActiveStrategyTargetDebuffData> <activedebuffDatas>__10;

		// Token: 0x04004954 RID: 18772
		internal List<ActiveStrategyTargetDebuffData>.Enumerator $locvar1C;

		// Token: 0x04004955 RID: 18773
		internal ActiveStrategyTargetDebuffData <activeStrategyTargetdebuffData>__20;

		// Token: 0x04004956 RID: 18774
		internal List<IBattleUnit>.Enumerator $locvar1D;

		// Token: 0x04004957 RID: 18775
		internal IBattleUnit <strategySelection>__21;

		// Token: 0x04004958 RID: 18776
		internal IEnumerator $locvar1E;

		// Token: 0x04004959 RID: 18777
		internal object <_>__22;

		// Token: 0x0400495A RID: 18778
		internal IDisposable $locvar1F;

		// Token: 0x0400495B RID: 18779
		internal ActiveTargetPushProgressData <pushEnhancement>__10;

		// Token: 0x0400495C RID: 18780
		internal List<IBattleUnit>.Enumerator $locvar20;

		// Token: 0x0400495D RID: 18781
		internal IBattleUnit <strategySelection>__23;

		// Token: 0x0400495E RID: 18782
		internal UnitTurnProgressUpdateEvent <change>__24;

		// Token: 0x0400495F RID: 18783
		internal IEnumerator $locvar21;

		// Token: 0x04004960 RID: 18784
		internal object <_>__25;

		// Token: 0x04004961 RID: 18785
		internal IDisposable $locvar22;

		// Token: 0x04004962 RID: 18786
		internal IEnumerator $locvar23;

		// Token: 0x04004963 RID: 18787
		internal object <_>__26;

		// Token: 0x04004964 RID: 18788
		internal IDisposable $locvar24;

		// Token: 0x04004965 RID: 18789
		internal IEnumerator $locvar25;

		// Token: 0x04004966 RID: 18790
		internal object <_>__27;

		// Token: 0x04004967 RID: 18791
		internal IDisposable $locvar26;

		// Token: 0x04004968 RID: 18792
		internal IEnumerator $locvar27;

		// Token: 0x04004969 RID: 18793
		internal object <_>__28;

		// Token: 0x0400496A RID: 18794
		internal IDisposable $locvar28;

		// Token: 0x0400496B RID: 18795
		internal IEnumerator $locvar29;

		// Token: 0x0400496C RID: 18796
		internal object <_>__29;

		// Token: 0x0400496D RID: 18797
		internal IDisposable $locvar2A;

		// Token: 0x0400496E RID: 18798
		internal ActiveSkillLogicBase $this;

		// Token: 0x0400496F RID: 18799
		internal object $current;

		// Token: 0x04004970 RID: 18800
		internal bool $disposing;

		// Token: 0x04004971 RID: 18801
		internal int $PC;
	}

	// Token: 0x02000DEB RID: 3563
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005958 RID: 22872 RVA: 0x0012EFA0 File Offset: 0x0012D3A0
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator3()
		{
		}

		// Token: 0x06005959 RID: 22873 RVA: 0x0012EFA8 File Offset: 0x0012D3A8
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
					processingSkill.InProgress = false;
				}
				if (((eventType != AdventureEventType.BattleEncounterPlayerGaugeFullyCharged || !skillOwner.IsPlayer) && (eventType != AdventureEventType.BattleEncounterEnemyGaugeFullyCharged || skillOwner.IsPlayer)) || base.GetCoolingDownRemainingSeconds(processingSkill) > 0f || processingSkill.PassiveHasBeenRecentlyApplied)
				{
					goto IL_235;
				}
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(processingSkill.SourceUnit, AdventureEventType.ActiveSkillPassiveBecomesAlive, processingSkill)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1A7;
			case 3u:
				Block_14:
				try
				{
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
				processingSkill.PassiveHasBeenRecentlyApplied = false;
				enumerator4 = this.PassiveEffectLooses(processingSkill).GetEnumerator();
				num = 4294967293u;
				goto Block_15;
			case 4u:
				goto IL_386;
			case 5u:
				Block_20:
				try
				{
					switch (num)
					{
					}
					if (enumerator5.MoveNext())
					{
						_5 = enumerator5.Current;
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
						if ((disposable5 = (enumerator5 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				processingSkill.PassiveHasBeenRecentlyApplied = false;
				enumerator6 = this.PassiveEffectLooses(processingSkill).GetEnumerator();
				num = 4294967293u;
				goto Block_21;
			case 6u:
				goto IL_535;
			case 7u:
				Block_27:
				try
				{
					switch (num)
					{
					}
					if (enumerator7.MoveNext())
					{
						_7 = enumerator7.Current;
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
						if ((disposable7 = (enumerator7 as IDisposable)) != null)
						{
							disposable7.Dispose();
						}
					}
				}
				enumerator8 = this.PassiveEffectApplies(processingSkill).GetEnumerator();
				num = 4294967293u;
				goto Block_28;
			case 8u:
				goto IL_71D;
			case 9u:
				Block_30:
				try
				{
					switch (num)
					{
					}
					if (enumerator9.MoveNext())
					{
						_9 = enumerator9.Current;
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
						if ((disposable9 = (enumerator9 as IDisposable)) != null)
						{
							disposable9.Dispose();
						}
					}
				}
				goto IL_87C;
			case 10u:
				Block_31:
				try
				{
					switch (num)
					{
					}
					if (enumerator10.MoveNext())
					{
						_10 = enumerator10.Current;
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
						if ((disposable10 = (enumerator10 as IDisposable)) != null)
						{
							disposable10.Dispose();
						}
					}
				}
				this.$PC = -1;
				return false;
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
			enumerator2 = this.PassiveEffectApplies(processingSkill).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1A7:
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
			processingSkill.PassiveHasBeenRecentlyApplied = true;
			IL_235:
			if ((eventType != AdventureEventType.BattleEncounterPlayerGaugeReleased || !skillOwner.IsPlayer) && (eventType != AdventureEventType.BattleEncounterEnemyGaugeReleased || skillOwner.IsPlayer))
			{
				goto IL_408;
			}
			update = (data as BattleGaugeUpdateEvent);
			if (update.CurrentValue < 100.0 && processingSkill.PassiveHasBeenRecentlyApplied)
			{
				enumerator3 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(processingSkill.SourceUnit, AdventureEventType.ActiveSkillPassiveBecomesFades, processingSkill)).GetEnumerator();
				num = 4294967293u;
				goto Block_14;
			}
			goto IL_408;
			Block_15:
			try
			{
				IL_386:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_4 = enumerator4.Current;
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
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			IL_408:
			if (eventTriggerUnit != skillOwner)
			{
				goto IL_7AB;
			}
			if (eventType != AdventureEventType.ActiveBattleSkillEntersCoolingDowns)
			{
				goto IL_5B7;
			}
			cdSkill = (data as AdventureUnitSkill);
			if (cdSkill == processingSkill && processingSkill.PassiveHasBeenRecentlyApplied)
			{
				enumerator5 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(processingSkill.SourceUnit, AdventureEventType.ActiveSkillPassiveBecomesFades, processingSkill)).GetEnumerator();
				num = 4294967293u;
				goto Block_20;
			}
			goto IL_5B7;
			Block_21:
			try
			{
				IL_535:
				switch (num)
				{
				}
				if (enumerator6.MoveNext())
				{
					_6 = enumerator6.Current;
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
					if ((disposable6 = (enumerator6 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
			}
			IL_5B7:
			if (eventType != AdventureEventType.ActiveBattleSkillCompletesCoolingDowns)
			{
				goto IL_7AB;
			}
			cdSkill2 = (data as AdventureUnitSkill);
			if (cdSkill2 != processingSkill)
			{
				goto IL_7AB;
			}
			battleEncounter = (processingSkill.SourceUnit.CurrentEncounter as BattleEncounter);
			if (battleEncounter == null)
			{
				goto IL_7AB;
			}
			currentGauge = battleEncounter.GetGauge(processingSkill.SourceUnit);
			if (currentGauge >= 100.0 && !processingSkill.PassiveHasBeenRecentlyApplied)
			{
				enumerator7 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(processingSkill.SourceUnit, AdventureEventType.ActiveSkillPassiveBecomesAlive, processingSkill)).GetEnumerator();
				num = 4294967293u;
				goto Block_27;
			}
			goto IL_7AB;
			Block_28:
			try
			{
				IL_71D:
				switch (num)
				{
				}
				if (enumerator8.MoveNext())
				{
					_8 = enumerator8.Current;
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
					if ((disposable8 = (enumerator8 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
			}
			processingSkill.PassiveHasBeenRecentlyApplied = true;
			IL_7AB:
			if (base.PassiveIsActive(processingSkill))
			{
				enumerator9 = this.PassiveBeingActiveEventProcess(processingSkill, eventTriggerUnit, skillOwner, eventType, data).GetEnumerator();
				num = 4294967293u;
				goto Block_30;
			}
			IL_87C:
			enumerator10 = this.AdditionalEventProcess(processingSkill, eventTriggerUnit, skillOwner, eventType, data).GetEnumerator();
			num = 4294967293u;
			goto Block_31;
		}

		// Token: 0x1700129E RID: 4766
		// (get) Token: 0x0600595A RID: 22874 RVA: 0x0012F974 File Offset: 0x0012DD74
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700129F RID: 4767
		// (get) Token: 0x0600595B RID: 22875 RVA: 0x0012F97C File Offset: 0x0012DD7C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600595C RID: 22876 RVA: 0x0012F984 File Offset: 0x0012DD84
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
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			case 5u:
				try
				{
				}
				finally
				{
					if ((disposable5 = (enumerator5 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				break;
			case 6u:
				try
				{
				}
				finally
				{
					if ((disposable6 = (enumerator6 as IDisposable)) != null)
					{
						disposable6.Dispose();
					}
				}
				break;
			case 7u:
				try
				{
				}
				finally
				{
					if ((disposable7 = (enumerator7 as IDisposable)) != null)
					{
						disposable7.Dispose();
					}
				}
				break;
			case 8u:
				try
				{
				}
				finally
				{
					if ((disposable8 = (enumerator8 as IDisposable)) != null)
					{
						disposable8.Dispose();
					}
				}
				break;
			case 9u:
				try
				{
				}
				finally
				{
					if ((disposable9 = (enumerator9 as IDisposable)) != null)
					{
						disposable9.Dispose();
					}
				}
				break;
			case 10u:
				try
				{
				}
				finally
				{
					if ((disposable10 = (enumerator10 as IDisposable)) != null)
					{
						disposable10.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x0600595D RID: 22877 RVA: 0x0012FC2C File Offset: 0x0012E02C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600595E RID: 22878 RVA: 0x0012FC33 File Offset: 0x0012E033
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600595F RID: 22879 RVA: 0x0012FC3C File Offset: 0x0012E03C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ActiveSkillLogicBase.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator3 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new ActiveSkillLogicBase.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator3();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.skillOwner = skillOwner;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x04004972 RID: 18802
		internal AdventureEventType eventType;

		// Token: 0x04004973 RID: 18803
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004974 RID: 18804
		internal IBattleUnit skillOwner;

		// Token: 0x04004975 RID: 18805
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004976 RID: 18806
		internal IEnumerator $locvar0;

		// Token: 0x04004977 RID: 18807
		internal object <_>__1;

		// Token: 0x04004978 RID: 18808
		internal IDisposable $locvar1;

		// Token: 0x04004979 RID: 18809
		internal IEnumerator $locvar2;

		// Token: 0x0400497A RID: 18810
		internal object <_>__2;

		// Token: 0x0400497B RID: 18811
		internal IDisposable $locvar3;

		// Token: 0x0400497C RID: 18812
		internal object data;

		// Token: 0x0400497D RID: 18813
		internal BattleGaugeUpdateEvent <update>__3;

		// Token: 0x0400497E RID: 18814
		internal IEnumerator $locvar4;

		// Token: 0x0400497F RID: 18815
		internal object <_>__4;

		// Token: 0x04004980 RID: 18816
		internal IDisposable $locvar5;

		// Token: 0x04004981 RID: 18817
		internal IEnumerator $locvar6;

		// Token: 0x04004982 RID: 18818
		internal object <_>__5;

		// Token: 0x04004983 RID: 18819
		internal IDisposable $locvar7;

		// Token: 0x04004984 RID: 18820
		internal AdventureUnitSkill <cdSkill>__6;

		// Token: 0x04004985 RID: 18821
		internal IEnumerator $locvar8;

		// Token: 0x04004986 RID: 18822
		internal object <_>__7;

		// Token: 0x04004987 RID: 18823
		internal IDisposable $locvar9;

		// Token: 0x04004988 RID: 18824
		internal IEnumerator $locvarA;

		// Token: 0x04004989 RID: 18825
		internal object <_>__8;

		// Token: 0x0400498A RID: 18826
		internal IDisposable $locvarB;

		// Token: 0x0400498B RID: 18827
		internal AdventureUnitSkill <cdSkill>__9;

		// Token: 0x0400498C RID: 18828
		internal BattleEncounter <battleEncounter>__10;

		// Token: 0x0400498D RID: 18829
		internal double <currentGauge>__11;

		// Token: 0x0400498E RID: 18830
		internal IEnumerator $locvarC;

		// Token: 0x0400498F RID: 18831
		internal object <_>__12;

		// Token: 0x04004990 RID: 18832
		internal IDisposable $locvarD;

		// Token: 0x04004991 RID: 18833
		internal IEnumerator $locvarE;

		// Token: 0x04004992 RID: 18834
		internal object <_>__13;

		// Token: 0x04004993 RID: 18835
		internal IDisposable $locvarF;

		// Token: 0x04004994 RID: 18836
		internal IEnumerator $locvar10;

		// Token: 0x04004995 RID: 18837
		internal object <_>__14;

		// Token: 0x04004996 RID: 18838
		internal IDisposable $locvar11;

		// Token: 0x04004997 RID: 18839
		internal IEnumerator $locvar12;

		// Token: 0x04004998 RID: 18840
		internal object <_>__15;

		// Token: 0x04004999 RID: 18841
		internal IDisposable $locvar13;

		// Token: 0x0400499A RID: 18842
		internal ActiveSkillLogicBase $this;

		// Token: 0x0400499B RID: 18843
		internal object $current;

		// Token: 0x0400499C RID: 18844
		internal bool $disposing;

		// Token: 0x0400499D RID: 18845
		internal int $PC;
	}

	// Token: 0x02000DEC RID: 3564
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005960 RID: 22880 RVA: 0x0012FCAC File Offset: 0x0012E0AC
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator4()
		{
		}

		// Token: 0x06005961 RID: 22881 RVA: 0x0012FCB4 File Offset: 0x0012E0B4
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x170012A0 RID: 4768
		// (get) Token: 0x06005962 RID: 22882 RVA: 0x0012FCCE File Offset: 0x0012E0CE
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012A1 RID: 4769
		// (get) Token: 0x06005963 RID: 22883 RVA: 0x0012FCD6 File Offset: 0x0012E0D6
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005964 RID: 22884 RVA: 0x0012FCDE File Offset: 0x0012E0DE
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005965 RID: 22885 RVA: 0x0012FCE0 File Offset: 0x0012E0E0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005966 RID: 22886 RVA: 0x0012FCE7 File Offset: 0x0012E0E7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005967 RID: 22887 RVA: 0x0012FCEF File Offset: 0x0012E0EF
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new ActiveSkillLogicBase.<PassiveBeingActiveEventProcess>c__Iterator4();
		}

		// Token: 0x0400499E RID: 18846
		internal object $current;

		// Token: 0x0400499F RID: 18847
		internal bool $disposing;

		// Token: 0x040049A0 RID: 18848
		internal int $PC;
	}

	// Token: 0x02000DED RID: 3565
	[CompilerGenerated]
	private sealed class <AdditionalEventProcess>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005968 RID: 22888 RVA: 0x0012FD0A File Offset: 0x0012E10A
		[DebuggerHidden]
		public <AdditionalEventProcess>c__Iterator5()
		{
		}

		// Token: 0x06005969 RID: 22889 RVA: 0x0012FD12 File Offset: 0x0012E112
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x170012A2 RID: 4770
		// (get) Token: 0x0600596A RID: 22890 RVA: 0x0012FD2C File Offset: 0x0012E12C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012A3 RID: 4771
		// (get) Token: 0x0600596B RID: 22891 RVA: 0x0012FD34 File Offset: 0x0012E134
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600596C RID: 22892 RVA: 0x0012FD3C File Offset: 0x0012E13C
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600596D RID: 22893 RVA: 0x0012FD3E File Offset: 0x0012E13E
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600596E RID: 22894 RVA: 0x0012FD45 File Offset: 0x0012E145
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600596F RID: 22895 RVA: 0x0012FD4D File Offset: 0x0012E14D
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new ActiveSkillLogicBase.<AdditionalEventProcess>c__Iterator5();
		}

		// Token: 0x040049A1 RID: 18849
		internal object $current;

		// Token: 0x040049A2 RID: 18850
		internal bool $disposing;

		// Token: 0x040049A3 RID: 18851
		internal int $PC;
	}

	// Token: 0x02000DEE RID: 3566
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator6 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005970 RID: 22896 RVA: 0x0012FD68 File Offset: 0x0012E168
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator6()
		{
		}

		// Token: 0x06005971 RID: 22897 RVA: 0x0012FD70 File Offset: 0x0012E170
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x170012A4 RID: 4772
		// (get) Token: 0x06005972 RID: 22898 RVA: 0x0012FD8A File Offset: 0x0012E18A
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012A5 RID: 4773
		// (get) Token: 0x06005973 RID: 22899 RVA: 0x0012FD92 File Offset: 0x0012E192
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005974 RID: 22900 RVA: 0x0012FD9A File Offset: 0x0012E19A
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005975 RID: 22901 RVA: 0x0012FD9C File Offset: 0x0012E19C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005976 RID: 22902 RVA: 0x0012FDA3 File Offset: 0x0012E1A3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005977 RID: 22903 RVA: 0x0012FDAB File Offset: 0x0012E1AB
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new ActiveSkillLogicBase.<PassiveEffectApplies>c__Iterator6();
		}

		// Token: 0x040049A4 RID: 18852
		internal object $current;

		// Token: 0x040049A5 RID: 18853
		internal bool $disposing;

		// Token: 0x040049A6 RID: 18854
		internal int $PC;
	}

	// Token: 0x02000DEF RID: 3567
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator7 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005978 RID: 22904 RVA: 0x0012FDC6 File Offset: 0x0012E1C6
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator7()
		{
		}

		// Token: 0x06005979 RID: 22905 RVA: 0x0012FDCE File Offset: 0x0012E1CE
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x170012A6 RID: 4774
		// (get) Token: 0x0600597A RID: 22906 RVA: 0x0012FDE8 File Offset: 0x0012E1E8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012A7 RID: 4775
		// (get) Token: 0x0600597B RID: 22907 RVA: 0x0012FDF0 File Offset: 0x0012E1F0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600597C RID: 22908 RVA: 0x0012FDF8 File Offset: 0x0012E1F8
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600597D RID: 22909 RVA: 0x0012FDFA File Offset: 0x0012E1FA
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600597E RID: 22910 RVA: 0x0012FE01 File Offset: 0x0012E201
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600597F RID: 22911 RVA: 0x0012FE09 File Offset: 0x0012E209
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new ActiveSkillLogicBase.<PassiveEffectLooses>c__Iterator7();
		}

		// Token: 0x040049A7 RID: 18855
		internal object $current;

		// Token: 0x040049A8 RID: 18856
		internal bool $disposing;

		// Token: 0x040049A9 RID: 18857
		internal int $PC;
	}
}
