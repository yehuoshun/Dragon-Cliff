using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000AF1 RID: 2801
public class EndlessDungeonMinibossConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x06004B60 RID: 19296 RVA: 0x001EE8AF File Offset: 0x001ECCAF
	public EndlessDungeonMinibossConfiguration(UnitClass correspondingUnitClass, UnitClassStyle correspondingClassStyle, List<ISpecialEffectDataLoad> additionalSpecialEffects, OutputType outputType)
	{
		this._correspondingUnitClass = correspondingUnitClass;
		this._correspondingClassStyle = correspondingClassStyle;
		this._additionalSpecialEffects = additionalSpecialEffects;
		this._outputType = outputType;
	}

	// Token: 0x17000FE7 RID: 4071
	// (get) Token: 0x06004B61 RID: 19297 RVA: 0x001EE8D4 File Offset: 0x001ECCD4
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x17000FE8 RID: 4072
	// (get) Token: 0x06004B62 RID: 19298 RVA: 0x001EE8DC File Offset: 0x001ECCDC
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x06004B63 RID: 19299 RVA: 0x001EE8E4 File Offset: 0x001ECCE4
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return base.GetSkillPresences().WeightedRandomSelect<SkillPresence>().Skills;
	}

	// Token: 0x06004B64 RID: 19300 RVA: 0x001EE8F8 File Offset: 0x001ECCF8
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
			DecreaseRate = 0.75
		});
		list.Add(new ExtraTargetingData
		{
			IsStarEf = new bool?(false),
			CandidateTypes = new List<TargetCandidateType>
			{
				TargetCandidateType.HostileAlive
			},
			Extra = 3
		});
		if (relevantDifficultyLevelMeasurement.DifficultyValue > 900.0)
		{
			list.Add(new TurnResistanceData
			{
				Rate = 0.9,
				IsStar = false
			});
			list.Add(new TimeLockResistanceData
			{
				IsStar = false,
				Chance = 0.7
			});
		}
		list.AddRange(this._additionalSpecialEffects);
		List<ISpecialEffectDataLoad> list2 = (relevantDifficultyLevelMeasurement.DifficultyValue > 700.0) ? ((relevantDifficultyLevelMeasurement.DifficultyValue > 900.0) ? this.GetSpecialEffectsPresences_Super().WeightedRandomSelect<SpecialEffectPresence>().SpecialEffectDataLoads : this.GetSpecialEffectsPresences_Advanced().WeightedRandomSelect<SpecialEffectPresence>().SpecialEffectDataLoads) : this.GetSpecialEffectsPresences().WeightedRandomSelect<SpecialEffectPresence>().SpecialEffectDataLoads;
		if (relevantDifficultyLevelMeasurement.DifficultyValue > 700.0)
		{
			list.Add(new MonksEyesData
			{
				IsStarEf = new bool?(false),
				MaxLoss = 0.3
			});
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

	// Token: 0x06004B65 RID: 19301 RVA: 0x001EEB24 File Offset: 0x001ECF24
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
							Chance = 0.5,
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
							Chance = 0.1,
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
							Chance = 0.1
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
							StartFires = 3
						},
						new PoisonSeedEffectData
						{
							IsStar = false,
							HealDecayPerSecond = 0.05,
							StablizeSeconds = 6,
							NumberOfSeedPerHit = 1,
							ResistanceDecayValuePerSecond = 50.0
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
						new TranscendenceEffectData
						{
							IsStarEf = new bool?(false),
							Rate = 0.3
						},
						new TurnResistanceData
						{
							IsStar = false,
							Rate = 0.4
						},
						new DiseaseData
						{
							IsStar = false,
							DamageType = this._outputType,
							DamageRate = 0.5,
							DamageLastingSeconds = 8,
							ResistanceReductionRateValue = 20.0,
							ResistanceReductionStartingValue = 100.0
						},
						new FearData
						{
							IsStar = false,
							Chance = 0.2,
							NumberOfSeconds = 1
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
							HealRate = 0.3
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
							ChargeCap = 3,
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
							NumberOfShields = 2
						},
						new PushOnHitData
						{
							IsStar = false,
							PushBackRate = 0.1
						},
						new DispelOnHitData
						{
							IsStar = false,
							Chance = 0.7,
							NumberOfDispels = 1
						},
						new SwallowData
						{
							IsStar = false,
							LastingTurns = 5,
							DamagePercentage = 0.4,
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
							DamageRate = 0.4,
							ResistanceReductionRateValue = 250.0,
							ResistanceReductionStartingValue = 400.0,
							DamageLastingSeconds = 8
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
							HealRate = 1.2,
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
							TauntSeconds = 3
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
						new FirstHandEffectData
						{
							IsStarEf = new bool?(false),
							StartProgress = 1.0
						},
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
							DamageRatePerSecond = 0.05,
							TargetSwitchTimerCap = 10
						},
						new DecayBladeData
						{
							IsStar = false,
							ResistanceReductionValue = 100.0,
							AgilityReductionValue = 100.0
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
							NumberOfElements = 2
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
							HealDecayPerSecond = 0.3,
							StablizeSeconds = 6,
							NumberOfSeedPerHit = 1,
							ResistanceDecayValuePerSecond = 50.0
						}
					}
				}
			};
		}
		return new List<SpecialEffectPresence>();
	}

	// Token: 0x06004B66 RID: 19302 RVA: 0x001EF770 File Offset: 0x001EDB70
	public List<SpecialEffectPresence> GetSpecialEffectsPresences_Advanced()
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
							SteamPercentage = 0.25
						},
						new StarfallData
						{
							IsStarEf = new bool?(false),
							Chance = 0.5,
							DamageType = OutputType.Divine,
							DamagePercentage = 1.6
						},
						new StoneOfSoulbringerData
						{
							IsStarEf = new bool?(false),
							LastingSeconds = 2f
						},
						new GodsMoralData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.2
						},
						new ImmortalShieldEffectData
						{
							IsStarEf = new bool?(false),
							NumberOfShields = 3
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
							Chance = 0.2,
							IsStarEf = new bool?(false),
							ReplaceAttribute = AttributeType.Agility,
							ReplacementValue = 0.0
						},
						new BoneOfRaptureData
						{
							IsStarEf = new bool?(false),
							Chance = 0.3,
							Timer = 0f,
							SpeedUpRate = 0.2
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
							DamageRate = 0.15,
							NumberOfShields = 2
						},
						new EffectSealData
						{
							IsStar = false,
							Chance = 0.25
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
							HealDecayPerSecond = 0.05,
							StablizeSeconds = 6,
							NumberOfSeedPerHit = 1,
							ResistanceDecayValuePerSecond = 100.0
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
							PushBackRate = 0.2
						},
						new TranscendenceEffectData
						{
							IsStarEf = new bool?(false),
							Rate = 0.3
						},
						new TurnResistanceData
						{
							IsStar = false,
							Rate = 0.4
						},
						new DiseaseData
						{
							IsStar = false,
							DamageType = this._outputType,
							DamageRate = 0.5,
							DamageLastingSeconds = 8,
							ResistanceReductionRateValue = 50.0,
							ResistanceReductionStartingValue = 100.0
						},
						new FearData
						{
							IsStar = false,
							Chance = 0.3,
							NumberOfSeconds = 1
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
							SuctionValue = 10.0
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
							ChargeCap = 3,
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
							NumberOfShields = 2
						},
						new PushOnHitData
						{
							IsStar = false,
							PushBackRate = 0.1
						},
						new DispelOnHitData
						{
							IsStar = false,
							Chance = 0.8,
							NumberOfDispels = 1
						},
						new SwallowData
						{
							IsStar = false,
							LastingTurns = 5,
							DamagePercentage = 0.4,
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
							DamageRate = 0.4,
							ResistanceReductionRateValue = 80.0,
							ResistanceReductionStartingValue = 100.0,
							DamageLastingSeconds = 8
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
							HealRate = 1.5,
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
							TauntSeconds = 3
						},
						new OutrageData
						{
							IsStar = false,
							Chance = 0.4
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
						new FirstHandEffectData
						{
							IsStarEf = new bool?(false),
							StartProgress = 1.0
						},
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
							DamageRatePerSecond = 0.05,
							TargetSwitchTimerCap = 10
						},
						new DecayBladeData
						{
							IsStar = false,
							ResistanceReductionValue = 100.0,
							AgilityReductionValue = 100.0
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
							NumberOfElements = 2
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
							HealDecayPerSecond = 0.3,
							StablizeSeconds = 6,
							NumberOfSeedPerHit = 1,
							ResistanceDecayValuePerSecond = 100.0
						}
					}
				}
			};
		}
		return new List<SpecialEffectPresence>();
	}

	// Token: 0x06004B67 RID: 19303 RVA: 0x001F03BC File Offset: 0x001EE7BC
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
							SteamPercentage = 0.25
						},
						new StarfallData
						{
							IsStarEf = new bool?(false),
							Chance = 1.0,
							DamageType = OutputType.Divine,
							DamagePercentage = 1.6
						},
						new StoneOfSoulbringerData
						{
							IsStarEf = new bool?(false),
							LastingSeconds = 2f
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
						},
						new VictiousEffectData
						{
							IsStarEf = new bool?(false),
							CurrentTargetCounter = 0,
							CurrentTargets = new List<IBattleUnit>(),
							DamageRatePerSecond = 0.5,
							DamageType = OutputType.Fire,
							TargetSwitchTimerCap = 6
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
							Chance = 0.2,
							IsStarEf = new bool?(false),
							ReplaceAttribute = AttributeType.Agility,
							ReplacementValue = 0.0
						},
						new BoneOfRaptureData
						{
							IsStarEf = new bool?(false),
							Chance = 0.4,
							Timer = 0f,
							SpeedUpRate = 0.2
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
							DamageRate = 0.15,
							NumberOfShields = 2
						},
						new EffectSealData
						{
							IsStar = false,
							Chance = 0.2
						},
						new DispelOnHitData
						{
							IsStar = false,
							Chance = 1.0,
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
							HealDecayPerSecond = 0.1,
							StablizeSeconds = 6,
							NumberOfSeedPerHit = 2,
							ResistanceDecayValuePerSecond = 100.0
						},
						new VictiousEffectData
						{
							IsStarEf = new bool?(false),
							DamageType = OutputType.Lightening,
							DamageRatePerSecond = 0.8,
							CurrentTargets = new List<IBattleUnit>(),
							TargetSwitchTimerCap = 6,
							CurrentTargetCounter = 0
						},
						new ShiftShieldData
						{
							IsStar = false,
							Counter = 0,
							NumberOfElements = 2,
							NumberOfSecondsPerShift = 5
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
						new TranscendenceEffectData
						{
							IsStarEf = new bool?(false),
							Rate = 0.2
						},
						new DiseaseData
						{
							IsStar = false,
							DamageType = this._outputType,
							DamageRate = 0.5,
							DamageLastingSeconds = 8,
							ResistanceReductionRateValue = 50.0,
							ResistanceReductionStartingValue = 100.0
						},
						new FearData
						{
							IsStar = false,
							Chance = 0.3,
							NumberOfSeconds = 1
						},
						new DispelOnHitData
						{
							IsStar = false,
							Chance = 1.0,
							NumberOfDispels = 2
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
							SacrificeRate = 0.05,
							MinimumSelfRate = 0.1
						},
						new TrickyDefenceEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 0.1
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
						new DomineeringData()
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
							ChargeCap = 3,
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
							NumberOfShields = 2
						},
						new PushOnHitData
						{
							IsStar = false,
							PushBackRate = 0.1
						},
						new DispelOnHitData
						{
							IsStar = false,
							Chance = 1.0,
							NumberOfDispels = 4
						},
						new SwallowData
						{
							IsStar = false,
							LastingTurns = 5,
							DamagePercentage = 0.2,
							SwallowCounts = 3
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
							PushPercentage = 0.3,
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
							StunRate = 0.5,
							OutputReductionRate = 0.1
						},
						new ClearUpData
						{
							IsStar = false
						},
						new DiseaseData
						{
							IsStar = false,
							DamageType = this._outputType,
							DamageRate = 0.4,
							ResistanceReductionRateValue = 80.0,
							ResistanceReductionStartingValue = 100.0,
							DamageLastingSeconds = 8
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
							HealRate = 0.1
						},
						new SacrificeEffectData
						{
							IsStarEf = new bool?(false),
							HealRate = 1.5,
							SacrificeRate = 0.1,
							MinimumSelfRate = 0.3
						},
						new ExtremeTauntData
						{
							IsStar = false,
							TauntSeconds = 3
						},
						new OutrageData
						{
							IsStar = false,
							Chance = 0.5
						},
						new CourageBlessingData
						{
							IsStar = false,
							StunRate = 0.6,
							OutputReductionRate = 0.05
						},
						new DamageReductionByValueData
						{
							Percentage = 0.05
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 2,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new FirstHandEffectData
						{
							IsStarEf = new bool?(false),
							StartProgress = 1.0
						},
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
							DamageRatePerSecond = 0.05,
							TargetSwitchTimerCap = 10
						},
						new DecayBladeData
						{
							IsStar = false,
							ResistanceReductionValue = 100.0,
							AgilityReductionValue = 100.0
						},
						new DamageReductionByValueData
						{
							Percentage = 0.05
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
							NumberOfElements = 2
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
							HealDecayPerSecond = 0.3,
							StablizeSeconds = 6,
							NumberOfSeedPerHit = 1,
							ResistanceDecayValuePerSecond = 100.0
						},
						new DomineeringData()
					}
				}
			};
		}
		return new List<SpecialEffectPresence>();
	}

	// Token: 0x06004B68 RID: 19304 RVA: 0x001F1145 File Offset: 0x001EF545
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return this._outputType;
	}

	// Token: 0x06004B69 RID: 19305 RVA: 0x001F1150 File Offset: 0x001EF550
	[CompilerGenerated]
	private static ElementEffectData <GetSpecialEffectDataLoads>m__0(OutputType e)
	{
		return new ElementEffectData
		{
			ElementType = e
		};
	}

	// Token: 0x04003AB7 RID: 15031
	private UnitClass _correspondingUnitClass;

	// Token: 0x04003AB8 RID: 15032
	private UnitClassStyle _correspondingClassStyle;

	// Token: 0x04003AB9 RID: 15033
	private List<ISpecialEffectDataLoad> _additionalSpecialEffects;

	// Token: 0x04003ABA RID: 15034
	private OutputType _outputType;

	// Token: 0x04003ABB RID: 15035
	[CompilerGenerated]
	private static Func<OutputType, ElementEffectData> <>f__am$cache0;

	// Token: 0x0200107A RID: 4218
	[CompilerGenerated]
	private sealed class <GetSpecialEffectDataLoads>c__AnonStorey0
	{
		// Token: 0x06006972 RID: 26994 RVA: 0x001F116B File Offset: 0x001EF56B
		public <GetSpecialEffectDataLoads>c__AnonStorey0()
		{
		}

		// Token: 0x06006973 RID: 26995 RVA: 0x001F1173 File Offset: 0x001EF573
		internal bool <>m__0(ISpecialEffectDataLoad r)
		{
			return r.GetSpecialEffectType() != this.randomEffect.GetSpecialEffectType();
		}

		// Token: 0x040063FB RID: 25595
		internal ISpecialEffectDataLoad randomEffect;
	}
}
