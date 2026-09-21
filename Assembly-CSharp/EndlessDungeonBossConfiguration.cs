using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000AF0 RID: 2800
public class EndlessDungeonBossConfiguration : BossUnitConfigurationBase
{
	// Token: 0x06004B56 RID: 19286 RVA: 0x001EBE6B File Offset: 0x001EA26B
	public EndlessDungeonBossConfiguration(UnitClass correspondingUnitClass, UnitClassStyle correspondingClassStyle, List<ISpecialEffectDataLoad> additionalSpecialEffects, OutputType outputType)
	{
		this._correspondingUnitClass = correspondingUnitClass;
		this._correspondingClassStyle = correspondingClassStyle;
		this._additionalSpecialEffects = additionalSpecialEffects;
		this._outputType = outputType;
	}

	// Token: 0x17000FE5 RID: 4069
	// (get) Token: 0x06004B57 RID: 19287 RVA: 0x001EBE90 File Offset: 0x001EA290
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x17000FE6 RID: 4070
	// (get) Token: 0x06004B58 RID: 19288 RVA: 0x001EBE98 File Offset: 0x001EA298
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x06004B59 RID: 19289 RVA: 0x001EBEA0 File Offset: 0x001EA2A0
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if ((double)UnityEngine.Random.value <= fromAdventure.CorrespondingDifficultyMeasurement.GetAmuletChance())
		{
			list.AddRange(fromAdventure.CorrespondingDifficultyMeasurement.GetAmuletDrop());
		}
		return list;
	}

	// Token: 0x06004B5A RID: 19290 RVA: 0x001EBEE0 File Offset: 0x001EA2E0
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		list.AddRange((from e in UnitExtensions.GetAllDamageElements()
		select new ElementEffectData
		{
			ElementType = e
		}).Cast<ISpecialEffectDataLoad>());
		list.Add(new NegativeEffectSpeedupData
		{
			IsStarEf = new bool?(false),
			DecreaseRate = 0.85
		});
		list.AddRange(this._additionalSpecialEffects);
		List<ISpecialEffectDataLoad> list2 = (relevantDifficultyLevelMeasurement.DifficultyValue > 700.0) ? ((relevantDifficultyLevelMeasurement.DifficultyValue > 900.0) ? this.GetSpecialEffectsPresences_Super().WeightedRandomSelect<SpecialEffectPresence>().SpecialEffectDataLoads : this.GetSpecialEffectsPresences_HighLevel().WeightedRandomSelect<SpecialEffectPresence>().SpecialEffectDataLoads) : this.GetSpecialEffectsPresences().WeightedRandomSelect<SpecialEffectPresence>().SpecialEffectDataLoads;
		if (relevantDifficultyLevelMeasurement.DifficultyValue > 700.0)
		{
			if (relevantDifficultyLevelMeasurement.DifficultyValue <= 900.0)
			{
				list.Add(new MonksEyesData
				{
					IsStarEf = new bool?(false),
					MaxLoss = 0.3
				});
			}
			else
			{
				list.Add(new MonksEyesData
				{
					IsStarEf = new bool?(false),
					MaxLoss = 0.2
				});
				list.Add(new TurnResistanceData
				{
					IsStar = false,
					Rate = 0.9
				});
			}
		}
		using (List<ISpecialEffectDataLoad>.Enumerator enumerator = list2.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ISpecialEffectDataLoad randomEffect = enumerator.Current;
				if (list.All((ISpecialEffectDataLoad r) => r.GetSpecialEffectType() != randomEffect.GetSpecialEffectType()))
				{
					list.Add(randomEffect);
				}
			}
		}
		return list;
	}

	// Token: 0x06004B5B RID: 19291 RVA: 0x001EC0D8 File Offset: 0x001EA4D8
	public List<SpecialEffectPresence> GetSpecialEffectsPresences()
	{
		UnitClassStyle correspondingClassStyle = this.CorrespondingClassStyle;
		if (correspondingClassStyle == UnitClassStyle.PhysicalWarrior || correspondingClassStyle == UnitClassStyle.SpellWarrior || correspondingClassStyle == UnitClassStyle.PhysicalKiller || correspondingClassStyle == UnitClassStyle.SpellKiller)
		{
			return new List<SpecialEffectPresence>
			{
				new SpecialEffectPresence
				{
					Presence = 100,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new AttributeStealData
						{
							IsStarEf = new bool?(false),
							StealAttributeType = AttributeType.CritRate,
							MaximumStolenValue = 1.0,
							SteamPercentage = 0.5
						},
						new StarfallData
						{
							IsStarEf = new bool?(false),
							Chance = 0.4,
							DamageType = OutputType.Divine,
							DamagePercentage = 1.2
						},
						new StoneOfSoulbringerData
						{
							IsStarEf = new bool?(false),
							LastingSeconds = 1f
						},
						new GodsMoralData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.1
						},
						new ImmortalShieldEffectData
						{
							IsStarEf = new bool?(false),
							NumberOfShields = 2
						}
					},
					Index = 1
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 2,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new AttributeDestroyData
						{
							Chance = 0.3,
							IsStarEf = new bool?(false),
							ReplaceAttribute = AttributeType.Agility,
							ReplacementValue = 0.0
						},
						new BoneOfRaptureData
						{
							IsStarEf = new bool?(false),
							Chance = 0.3,
							Timer = 0f,
							SpeedUpRate = 0.1
						},
						new ChargeData
						{
							IsStarEf = new bool?(false),
							ChargeCap = 20000.0,
							BoostAttributeType = AttributeType.Resilience,
							ChargingDamageTypes = UnitExtensions.GetAllDamageElements()
						},
						new HardLifeData
						{
							IsStar = false,
							DamageRate = 0.15,
							NumberOfShields = 1
						},
						new EffectSealData
						{
							IsStar = false,
							Chance = 0.3
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 3,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new ElementReplacementData
						{
							IsStarEf = new bool?(false),
							Type = OutputType.Fire
						},
						new DemonicFireData
						{
							IsStarEf = new bool?(false)
						},
						new FieryTaleEffectData
						{
							IsStarEf = new bool?(false),
							FiresPerHit = 1,
							StartFires = 2
						},
						new PoisonSeedEffectData
						{
							IsStar = false,
							HealDecayPerSecond = 0.1,
							StablizeSeconds = 8,
							NumberOfSeedPerHit = 1,
							ResistanceDecayValuePerSecond = 200.0
						},
						new ClearUpData
						{
							IsStar = false
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 4,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new PushOnHitData
						{
							IsStar = false,
							PushBackRate = 0.1
						},
						new TurnResistanceData
						{
							IsStar = false,
							Rate = 0.2
						},
						new DiseaseData
						{
							IsStar = false,
							DamageType = this._outputType,
							DamageRate = 0.3,
							DamageLastingSeconds = 8,
							ResistanceReductionRateValue = 250.0,
							ResistanceReductionStartingValue = 800.0
						},
						new FearData
						{
							IsStar = false,
							Chance = 0.4,
							NumberOfSeconds = 1
						},
						new RageBoostData
						{
							IsStar = false,
							SuctionValue = 12.0
						}
					}
				}
			};
		}
		if (correspondingClassStyle == UnitClassStyle.PhysicalDefender || correspondingClassStyle == UnitClassStyle.SpellDefender || correspondingClassStyle == UnitClassStyle.Protector)
		{
			return new List<SpecialEffectPresence>
			{
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 1,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new SacrificeEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 2.0,
							SacrificeRate = 0.1,
							MinimumSelfRate = 0.1
						},
						new TrickyDefenceEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.2
						},
						new TurnResistanceData
						{
							IsStar = false,
							Rate = 1.0
						},
						new RageBoostData
						{
							IsStar = false,
							SuctionValue = 10.0
						},
						new ExtremeTauntData
						{
							IsStar = false,
							TauntSeconds = 2
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 2,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new DivineBlindnessData
						{
							IsStarEf = new bool?(false),
							ChargeCap = 5,
							ChargeCounter = 0,
							PushPercentage = 0.1
						},
						new RejuvenationEffectData
						{
							IsStarEf = new bool?(false),
							Rate = 0.05
						},
						new ImmortalShieldEffectData
						{
							IsStarEf = new bool?(false),
							NumberOfShields = 1
						},
						new PushOnHitData
						{
							IsStar = false,
							PushBackRate = 0.1
						},
						new DispelOnHitData
						{
							IsStar = false,
							Chance = 0.4,
							NumberOfDispels = 1
						},
						new SwallowData
						{
							IsStar = false,
							LastingTurns = 5,
							DamagePercentage = 0.3,
							SwallowCounts = 1
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 3,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new DivineBlindnessData
						{
							IsStarEf = new bool?(false),
							ChargeCap = 4,
							PushPercentage = 0.1,
							ChargeCounter = 0
						},
						new StoneGuardEffectData
						{
							IsStarEf = new bool?(false),
							StunSeconds = 1.0,
							ProgressPush = 1.0,
							ChancePerSecond = 0.3
						},
						new CourageBlessingData
						{
							IsStar = false,
							StunRate = 0.3,
							OutputReductionRate = 0.2
						},
						new ClearUpData
						{
							IsStar = false
						},
						new DiseaseData
						{
							IsStar = false,
							DamageType = this._outputType,
							DamageRate = 1.0,
							ResistanceReductionRateValue = 250.0,
							ResistanceReductionStartingValue = 800.0,
							DamageLastingSeconds = 8
						},
						new FearData
						{
							IsStar = false,
							Chance = 0.4,
							NumberOfSeconds = 1
						}
					}
				}
			};
		}
		if (correspondingClassStyle == UnitClassStyle.Healer || correspondingClassStyle == UnitClassStyle.SpellSupporter || correspondingClassStyle == UnitClassStyle.PhysicalSupporter)
		{
			return new List<SpecialEffectPresence>
			{
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 1,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new LifeGenData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.05
						},
						new SacrificeEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 2.0,
							SacrificeRate = 0.1
						},
						new TrickyDefenceEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.1
						},
						new ExtremeTauntData
						{
							IsStar = false,
							TauntSeconds = 2
						},
						new OutrageData
						{
							IsStar = false,
							Chance = 0.3
						},
						new CourageBlessingData
						{
							IsStar = false,
							StunRate = 0.3,
							OutputReductionRate = 0.2
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 2,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new HydraSpiritData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.1,
							TickCounter = 0,
							MaxFireySoulCap = 6,
							TickCap = 3
						},
						new VictiousEffectData
						{
							IsStarEf = new bool?(false),
							DamageType = OutputType.Divine,
							CurrentTargets = new List<IBattleUnit>(),
							CurrentTargetCounter = 0,
							DamageRatePerSecond = 0.2,
							TargetSwitchTimerCap = 10
						},
						new DecayBladeData
						{
							IsStar = false,
							ResistanceReductionValue = 1000.0,
							AgilityReductionValue = 500.0
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 3,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new ShiftShieldData
						{
							IsStar = false,
							NumberOfSecondsPerShift = 3,
							Counter = 0,
							NumberOfElements = 1
						},
						new ExtraTargetingData
						{
							IsStarEf = new bool?(false),
							CandidateTypes = new List<TargetCandidateType>
							{
								TargetCandidateType.FriendlyAlive
							},
							Extra = 3
						},
						new ConfidentHealerData
						{
							IsStar = false,
							AfterHealSeconds = 3,
							AfterHealRate = 0.2,
							HealBoostRate = 0.5
						},
						new AgilityData
						{
							IsStar = false,
							IncreaseRate = 0.2
						},
						new PowerThirstData
						{
							IsStar = false,
							SuctionRate = 0.2
						},
						new PoisonSeedEffectData
						{
							IsStar = false,
							HealDecayPerSecond = 0.1,
							StablizeSeconds = 3,
							NumberOfSeedPerHit = 1,
							ResistanceDecayValuePerSecond = 500.0
						}
					}
				}
			};
		}
		return new List<SpecialEffectPresence>();
	}

	// Token: 0x06004B5C RID: 19292 RVA: 0x001ECD58 File Offset: 0x001EB158
	public List<SpecialEffectPresence> GetSpecialEffectsPresences_HighLevel()
	{
		UnitClassStyle correspondingClassStyle = this.CorrespondingClassStyle;
		if (correspondingClassStyle == UnitClassStyle.PhysicalWarrior || correspondingClassStyle == UnitClassStyle.SpellWarrior || correspondingClassStyle == UnitClassStyle.PhysicalKiller || correspondingClassStyle == UnitClassStyle.SpellKiller)
		{
			return new List<SpecialEffectPresence>
			{
				new SpecialEffectPresence
				{
					Presence = 100,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new AttributeStealData
						{
							IsStarEf = new bool?(false),
							StealAttributeType = AttributeType.CritRate,
							MaximumStolenValue = 1.0,
							SteamPercentage = 0.7
						},
						new StarfallData
						{
							IsStarEf = new bool?(false),
							Chance = 0.6,
							DamageType = OutputType.Poison,
							DamagePercentage = 1.2
						},
						new StoneOfSoulbringerData
						{
							IsStarEf = new bool?(false),
							LastingSeconds = 3f
						},
						new GodsMoralData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.1
						},
						new ImmortalShieldEffectData
						{
							IsStarEf = new bool?(false),
							NumberOfShields = 4
						}
					},
					Index = 1
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 2,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new AttributeDestroyData
						{
							Chance = 0.4,
							IsStarEf = new bool?(false),
							ReplaceAttribute = AttributeType.Agility,
							ReplacementValue = 0.0
						},
						new BoneOfRaptureData
						{
							IsStarEf = new bool?(false),
							Chance = 0.3,
							Timer = 0f,
							SpeedUpRate = 0.3
						},
						new ChargeData
						{
							IsStarEf = new bool?(false),
							ChargeCap = 30000.0,
							BoostAttributeType = AttributeType.Resilience,
							ChargingDamageTypes = UnitExtensions.GetAllDamageElements()
						},
						new HardLifeData
						{
							IsStar = false,
							DamageRate = 0.1,
							NumberOfShields = 1
						},
						new EffectSealData
						{
							IsStar = false,
							Chance = 0.3
						},
						new RejuvenationEffectData
						{
							IsStarEf = new bool?(false),
							Rate = 0.05
						},
						new TimeLockResistanceData
						{
							IsStar = false,
							Chance = 0.5
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 3,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new ElementReplacementData
						{
							IsStarEf = new bool?(false),
							Type = OutputType.Fire
						},
						new DemonicFireData
						{
							IsStarEf = new bool?(false)
						},
						new FieryTaleEffectData
						{
							IsStarEf = new bool?(false),
							FiresPerHit = 2,
							StartFires = 4
						},
						new PoisonSeedEffectData
						{
							IsStar = false,
							HealDecayPerSecond = 0.15,
							StablizeSeconds = 8,
							NumberOfSeedPerHit = 1,
							ResistanceDecayValuePerSecond = 250.0
						},
						new ClearUpData
						{
							IsStar = false
						},
						new SwallowData
						{
							IsStar = false,
							LastingTurns = 3,
							DamagePercentage = 0.2,
							SwallowCounts = 2
						},
						new RageBoostData
						{
							IsStar = false,
							SuctionValue = 15.0
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 4,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new PushOnHitData
						{
							IsStar = false,
							PushBackRate = 0.1
						},
						new TurnResistanceData
						{
							IsStar = false,
							Rate = 0.3
						},
						new DiseaseData
						{
							IsStar = false,
							DamageType = this._outputType,
							DamageRate = 0.3,
							DamageLastingSeconds = 8,
							ResistanceReductionRateValue = 300.0,
							ResistanceReductionStartingValue = 1000.0
						},
						new FearData
						{
							IsStar = false,
							Chance = 0.7,
							NumberOfSeconds = 1
						},
						new RageBoostData
						{
							IsStar = false,
							SuctionValue = 12.0
						},
						new AgilityData
						{
							IsStar = false,
							IncreaseRate = 0.15
						}
					}
				}
			};
		}
		if (correspondingClassStyle == UnitClassStyle.PhysicalDefender || correspondingClassStyle == UnitClassStyle.SpellDefender || correspondingClassStyle == UnitClassStyle.Protector)
		{
			return new List<SpecialEffectPresence>
			{
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 1,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new SacrificeEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 3.0,
							SacrificeRate = 0.05,
							MinimumSelfRate = 0.1
						},
						new TrickyDefenceEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.2
						},
						new TurnResistanceData
						{
							IsStar = false,
							Rate = 1.0
						},
						new RageBoostData
						{
							IsStar = false,
							SuctionValue = 20.0
						},
						new ExtremeTauntData
						{
							IsStar = false,
							TauntSeconds = 2
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 2,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new DivineBlindnessData
						{
							IsStarEf = new bool?(false),
							ChargeCap = 5,
							ChargeCounter = 0,
							PushPercentage = 0.1
						},
						new RejuvenationEffectData
						{
							IsStarEf = new bool?(false),
							Rate = 0.05
						},
						new ImmortalShieldEffectData
						{
							IsStarEf = new bool?(false),
							NumberOfShields = 1
						},
						new PushOnHitData
						{
							IsStar = false,
							PushBackRate = 0.2
						},
						new DispelOnHitData
						{
							IsStar = false,
							Chance = 0.5,
							NumberOfDispels = 2
						},
						new SwallowData
						{
							IsStar = false,
							LastingTurns = 5,
							DamagePercentage = 0.3,
							SwallowCounts = 1
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 3,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new DivineBlindnessData
						{
							IsStarEf = new bool?(false),
							ChargeCap = 3,
							PushPercentage = 0.1,
							ChargeCounter = 0
						},
						new StoneGuardEffectData
						{
							IsStarEf = new bool?(false),
							StunSeconds = 1.0,
							ProgressPush = 1.0,
							ChancePerSecond = 0.3
						},
						new CourageBlessingData
						{
							IsStar = false,
							StunRate = 0.3,
							OutputReductionRate = 0.2
						},
						new ClearUpData
						{
							IsStar = false
						},
						new DiseaseData
						{
							IsStar = false,
							DamageType = this._outputType,
							DamageRate = 1.0,
							ResistanceReductionRateValue = 250.0,
							ResistanceReductionStartingValue = 800.0,
							DamageLastingSeconds = 8
						},
						new FearData
						{
							IsStar = false,
							Chance = 0.7,
							NumberOfSeconds = 1
						}
					}
				}
			};
		}
		if (correspondingClassStyle == UnitClassStyle.Healer || correspondingClassStyle == UnitClassStyle.SpellSupporter || correspondingClassStyle == UnitClassStyle.PhysicalSupporter)
		{
			return new List<SpecialEffectPresence>
			{
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 1,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new LifeGenData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.09
						},
						new SacrificeEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 2.5,
							SacrificeRate = 0.1
						},
						new TrickyDefenceEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.3
						},
						new ExtremeTauntData
						{
							IsStar = false,
							TauntSeconds = 3
						},
						new OutrageData
						{
							IsStar = false,
							Chance = 0.6
						},
						new CourageBlessingData
						{
							IsStar = false,
							StunRate = 0.3,
							OutputReductionRate = 0.2
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 2,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new HydraSpiritData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.2,
							TickCounter = 0,
							MaxFireySoulCap = 5,
							TickCap = 2
						},
						new VictiousEffectData
						{
							IsStarEf = new bool?(false),
							DamageType = OutputType.Divine,
							CurrentTargets = new List<IBattleUnit>(),
							CurrentTargetCounter = 0,
							DamageRatePerSecond = 0.3,
							TargetSwitchTimerCap = 3
						},
						new DecayBladeData
						{
							IsStar = false,
							ResistanceReductionValue = 1000.0,
							AgilityReductionValue = 600.0
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 3,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new ShiftShieldData
						{
							IsStar = false,
							NumberOfSecondsPerShift = 3,
							Counter = 0,
							NumberOfElements = 1
						},
						new ExtraTargetingData
						{
							IsStarEf = new bool?(false),
							CandidateTypes = new List<TargetCandidateType>
							{
								TargetCandidateType.FriendlyAlive
							},
							Extra = 3
						},
						new ConfidentHealerData
						{
							IsStar = false,
							AfterHealSeconds = 3,
							AfterHealRate = 0.2,
							HealBoostRate = 0.5
						},
						new AgilityData
						{
							IsStar = false,
							IncreaseRate = 0.2
						},
						new PowerThirstData
						{
							IsStar = false,
							SuctionRate = 0.3
						},
						new PoisonSeedEffectData
						{
							IsStar = false,
							HealDecayPerSecond = 0.1,
							StablizeSeconds = 3,
							NumberOfSeedPerHit = 1,
							ResistanceDecayValuePerSecond = 800.0
						}
					}
				}
			};
		}
		return new List<SpecialEffectPresence>();
	}

	// Token: 0x06004B5D RID: 19293 RVA: 0x001EDAB0 File Offset: 0x001EBEB0
	public List<SpecialEffectPresence> GetSpecialEffectsPresences_Super()
	{
		UnitClassStyle correspondingClassStyle = this.CorrespondingClassStyle;
		if (correspondingClassStyle == UnitClassStyle.PhysicalWarrior || correspondingClassStyle == UnitClassStyle.SpellWarrior || correspondingClassStyle == UnitClassStyle.PhysicalKiller || correspondingClassStyle == UnitClassStyle.SpellKiller)
		{
			return new List<SpecialEffectPresence>
			{
				new SpecialEffectPresence
				{
					Presence = 100,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new AttributeStealData
						{
							IsStarEf = new bool?(false),
							StealAttributeType = AttributeType.CritRate,
							MaximumStolenValue = 1.0,
							SteamPercentage = 0.5
						},
						new StarfallData
						{
							IsStarEf = new bool?(false),
							Chance = 1.0,
							DamageType = OutputType.Poison,
							DamagePercentage = 1.2
						},
						new StoneOfSoulbringerData
						{
							IsStarEf = new bool?(false),
							LastingSeconds = 3f
						},
						new ImmortalShieldEffectData
						{
							IsStarEf = new bool?(false),
							NumberOfShields = 4
						},
						new DomineeringData()
					},
					Index = 1
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 2,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new AttributeDestroyData
						{
							Chance = 0.2,
							IsStarEf = new bool?(false),
							ReplaceAttribute = AttributeType.Agility,
							ReplacementValue = 0.0
						},
						new BoneOfRaptureData
						{
							IsStarEf = new bool?(false),
							Chance = 0.5,
							Timer = 0f,
							SpeedUpRate = 0.3
						},
						new ChargeData
						{
							IsStarEf = new bool?(false),
							ChargeCap = 60000.0,
							BoostAttributeType = AttributeType.Resilience,
							ChargingDamageTypes = UnitExtensions.GetAllDamageElements()
						},
						new HardLifeData
						{
							IsStar = false,
							DamageRate = 0.1,
							NumberOfShields = 2
						},
						new EffectSealData
						{
							IsStar = false,
							Chance = 0.2
						},
						new RejuvenationEffectData
						{
							IsStarEf = new bool?(false),
							Rate = 0.03
						},
						new TimeLockResistanceData
						{
							IsStar = false,
							Chance = 0.8
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 3,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new ElementReplacementData
						{
							IsStarEf = new bool?(false),
							Type = OutputType.Fire
						},
						new DemonicFireData
						{
							IsStarEf = new bool?(false)
						},
						new FieryTaleEffectData
						{
							IsStarEf = new bool?(false),
							FiresPerHit = 2,
							StartFires = 4
						},
						new PoisonSeedEffectData
						{
							IsStar = false,
							HealDecayPerSecond = 0.2,
							StablizeSeconds = 8,
							NumberOfSeedPerHit = 1,
							ResistanceDecayValuePerSecond = 250.0
						},
						new ClearUpData
						{
							IsStar = false
						},
						new SwallowData
						{
							IsStar = false,
							LastingTurns = 3,
							DamagePercentage = 0.2,
							SwallowCounts = 3
						},
						new RageBoostData
						{
							IsStar = false,
							SuctionValue = 15.0
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 4,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new PushOnHitData
						{
							IsStar = false,
							PushBackRate = 0.25
						},
						new TurnResistanceData
						{
							IsStar = false,
							Rate = 1.0
						},
						new DiseaseData
						{
							IsStar = false,
							DamageType = this._outputType,
							DamageRate = 0.3,
							DamageLastingSeconds = 8,
							ResistanceReductionRateValue = 300.0,
							ResistanceReductionStartingValue = 1000.0
						},
						new FearData
						{
							IsStar = false,
							Chance = 0.7,
							NumberOfSeconds = 1
						},
						new RageBoostData
						{
							IsStar = false,
							SuctionValue = 12.0
						},
						new AgilityData
						{
							IsStar = false,
							IncreaseRate = 0.15
						},
						new DomineeringData()
					}
				}
			};
		}
		if (correspondingClassStyle == UnitClassStyle.PhysicalDefender || correspondingClassStyle == UnitClassStyle.SpellDefender || correspondingClassStyle == UnitClassStyle.Protector)
		{
			return new List<SpecialEffectPresence>
			{
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 1,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new SacrificeEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 2.0,
							SacrificeRate = 0.05,
							MinimumSelfRate = 0.1
						},
						new TrickyDefenceEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.2
						},
						new TurnResistanceData
						{
							IsStar = false,
							Rate = 1.0
						},
						new RageBoostData
						{
							IsStar = false,
							SuctionValue = 20.0
						},
						new ExtremeTauntData
						{
							IsStar = false,
							TauntSeconds = 2
						},
						new DamageReductionByValueData
						{
							Percentage = 0.1
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 2,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new DivineBlindnessData
						{
							IsStarEf = new bool?(false),
							ChargeCap = 5,
							ChargeCounter = 0,
							PushPercentage = 0.3
						},
						new ImmortalShieldEffectData
						{
							IsStarEf = new bool?(false),
							NumberOfShields = 2
						},
						new PushOnHitData
						{
							IsStar = false,
							PushBackRate = 0.2
						},
						new DispelOnHitData
						{
							IsStar = false,
							Chance = 1.0,
							NumberOfDispels = 3
						},
						new SwallowData
						{
							IsStar = false,
							LastingTurns = 5,
							DamagePercentage = 0.3,
							SwallowCounts = 3
						},
						new DomineeringData()
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 3,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new DivineBlindnessData
						{
							IsStarEf = new bool?(false),
							ChargeCap = 3,
							PushPercentage = 0.2,
							ChargeCounter = 0
						},
						new StoneGuardEffectData
						{
							IsStarEf = new bool?(false),
							StunSeconds = 1.0,
							ProgressPush = 1.0,
							ChancePerSecond = 0.3
						},
						new CourageBlessingData
						{
							IsStar = false,
							StunRate = 0.3,
							OutputReductionRate = 0.2
						},
						new ClearUpData
						{
							IsStar = false
						},
						new DiseaseData
						{
							IsStar = false,
							DamageType = this._outputType,
							DamageRate = 1.0,
							ResistanceReductionRateValue = 250.0,
							ResistanceReductionStartingValue = 800.0,
							DamageLastingSeconds = 8
						},
						new FearData
						{
							IsStar = false,
							Chance = 0.7,
							NumberOfSeconds = 1
						}
					}
				}
			};
		}
		if (correspondingClassStyle == UnitClassStyle.Healer || correspondingClassStyle == UnitClassStyle.SpellSupporter || correspondingClassStyle == UnitClassStyle.PhysicalSupporter)
		{
			return new List<SpecialEffectPresence>
			{
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 1,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new LifeGenData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.04
						},
						new SacrificeEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 2.5,
							SacrificeRate = 0.1
						},
						new TrickyDefenceEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.2
						},
						new ExtremeTauntData
						{
							IsStar = false,
							TauntSeconds = 3
						},
						new OutrageData
						{
							IsStar = false,
							Chance = 0.6
						},
						new CourageBlessingData
						{
							IsStar = false,
							StunRate = 0.3,
							OutputReductionRate = 0.2
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 2,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new HydraSpiritData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.2,
							TickCounter = 0,
							MaxFireySoulCap = 5,
							TickCap = 2
						},
						new VictiousEffectData
						{
							IsStarEf = new bool?(false),
							DamageType = OutputType.Divine,
							CurrentTargets = new List<IBattleUnit>(),
							CurrentTargetCounter = 0,
							DamageRatePerSecond = 0.3,
							TargetSwitchTimerCap = 3
						},
						new DecayBladeData
						{
							IsStar = false,
							ResistanceReductionValue = 1000.0,
							AgilityReductionValue = 600.0
						},
						new ConfidentHealerData
						{
							IsStar = false,
							AfterHealSeconds = 3,
							AfterHealRate = 0.2,
							HealBoostRate = 0.5
						},
						new DispelOnHealData
						{
							IsStar = false,
							NumberOfDispels = 2
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 3,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new ShiftShieldData
						{
							IsStar = false,
							NumberOfSecondsPerShift = 3,
							Counter = 0,
							NumberOfElements = 1
						},
						new ExtraTargetingData
						{
							IsStarEf = new bool?(false),
							CandidateTypes = new List<TargetCandidateType>
							{
								TargetCandidateType.FriendlyAlive
							},
							Extra = 3
						},
						new ConfidentHealerData
						{
							IsStar = false,
							AfterHealSeconds = 3,
							AfterHealRate = 0.2,
							HealBoostRate = 0.5
						},
						new AgilityData
						{
							IsStar = false,
							IncreaseRate = 0.5
						},
						new PowerThirstData
						{
							IsStar = false,
							SuctionRate = 0.4
						},
						new PoisonSeedEffectData
						{
							IsStar = false,
							HealDecayPerSecond = 0.1,
							StablizeSeconds = 3,
							NumberOfSeedPerHit = 1,
							ResistanceDecayValuePerSecond = 800.0
						},
						new DispelOnHealData
						{
							IsStar = false,
							NumberOfDispels = 2
						}
					}
				}
			};
		}
		return new List<SpecialEffectPresence>();
	}

	// Token: 0x06004B5E RID: 19294 RVA: 0x001EE86B File Offset: 0x001ECC6B
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return this._outputType;
	}

	// Token: 0x06004B5F RID: 19295 RVA: 0x001EE874 File Offset: 0x001ECC74
	[CompilerGenerated]
	private static ElementEffectData <GetSpecialEffectDataLoads>m__0(OutputType e)
	{
		return new ElementEffectData
		{
			ElementType = e
		};
	}

	// Token: 0x04003AB2 RID: 15026
	private UnitClass _correspondingUnitClass;

	// Token: 0x04003AB3 RID: 15027
	private UnitClassStyle _correspondingClassStyle;

	// Token: 0x04003AB4 RID: 15028
	private List<ISpecialEffectDataLoad> _additionalSpecialEffects;

	// Token: 0x04003AB5 RID: 15029
	private OutputType _outputType;

	// Token: 0x04003AB6 RID: 15030
	[CompilerGenerated]
	private static Func<OutputType, ElementEffectData> <>f__am$cache0;

	// Token: 0x02001079 RID: 4217
	[CompilerGenerated]
	private sealed class <GetSpecialEffectDataLoads>c__AnonStorey0
	{
		// Token: 0x06006970 RID: 26992 RVA: 0x001EE88F File Offset: 0x001ECC8F
		public <GetSpecialEffectDataLoads>c__AnonStorey0()
		{
		}

		// Token: 0x06006971 RID: 26993 RVA: 0x001EE897 File Offset: 0x001ECC97
		internal bool <>m__0(ISpecialEffectDataLoad r)
		{
			return r.GetSpecialEffectType() != this.randomEffect.GetSpecialEffectType();
		}

		// Token: 0x040063FA RID: 25594
		internal ISpecialEffectDataLoad randomEffect;
	}
}
