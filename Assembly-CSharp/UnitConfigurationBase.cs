using System;
using System.Collections.Generic;

// Token: 0x02000B2A RID: 2858
public abstract class UnitConfigurationBase
{
	// Token: 0x06004C2D RID: 19501 RVA: 0x001DB2A5 File Offset: 0x001D96A5
	protected UnitConfigurationBase()
	{
	}

	// Token: 0x1700104F RID: 4175
	// (get) Token: 0x06004C2E RID: 19502
	public abstract UnitClass CorrespondingUnitClass { get; }

	// Token: 0x17001050 RID: 4176
	// (get) Token: 0x06004C2F RID: 19503 RVA: 0x001DB2AD File Offset: 0x001D96AD
	public virtual ResourceType CorrespondingInvitationType
	{
		get
		{
			return ResourceType.MonsterInvitation;
		}
	}

	// Token: 0x17001051 RID: 4177
	// (get) Token: 0x06004C30 RID: 19504
	public abstract UnitClassStyle CorrespondingClassStyle { get; }

	// Token: 0x17001052 RID: 4178
	// (get) Token: 0x06004C31 RID: 19505 RVA: 0x001DB2B4 File Offset: 0x001D96B4
	public virtual RecruitmentCandidatePresence RecruitmentPresence
	{
		get
		{
			return new RecruitmentCandidatePresence
			{
				UnitClass = this.CorrespondingUnitClass,
				Presence = 1000
			};
		}
	}

	// Token: 0x17001053 RID: 4179
	// (get) Token: 0x06004C32 RID: 19506 RVA: 0x001DB2DF File Offset: 0x001D96DF
	public virtual int RecruitmentPriceRaw
	{
		get
		{
			return 1000;
		}
	}

	// Token: 0x06004C33 RID: 19507 RVA: 0x001DB2E8 File Offset: 0x001D96E8
	public List<SpecialEffectPresence> GetMinibossSpecialEffectsPresences()
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
						new PossessionData
						{
							IsStarEf = new bool?(false),
							Chance = 0.7,
							TriggerEventType = AdventureEventType.DamageReleased,
							LastingTurns = 2,
							PossessionEffectSourceIdentityCode = "affix",
							Boosts = new List<BoostSetting>
							{
								new BoostSetting
								{
									BoostValue = 0.5,
									BoostAttribute = AttributeType.CritRate
								}
							}
						},
						new StarfallData
						{
							IsStarEf = new bool?(false),
							Chance = 0.5,
							DamageType = OutputType.Fire,
							DamagePercentage = 1.0
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
							Chance = 0.5,
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
							FiresPerHit = 3,
							StartFires = 1
						},
						new ExtraTargetingData
						{
							IsStarEf = new bool?(false),
							CandidateTypes = new List<TargetCandidateType>
							{
								TargetCandidateType.HostileAlive
							},
							Extra = 2
						}
					}
				},
				new SpecialEffectPresence
				{
					Presence = 100,
					Index = 4,
					SpecialEffectDataLoads = new List<ISpecialEffectDataLoad>
					{
						new TranscendenceEffectData
						{
							IsStarEf = new bool?(false),
							Rate = 1.0
						},
						new ExtraTargetingData
						{
							IsStarEf = new bool?(false),
							CandidateTypes = new List<TargetCandidateType>
							{
								TargetCandidateType.HostileAlive
							},
							Extra = 2
						},
						new PushOnHitData
						{
							IsStar = false,
							PushBackRate = 0.2
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
						new FirstHandEffectData
						{
							IsStarEf = new bool?(false),
							StartProgress = 1.0
						},
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
							PushPercentage = 0.2
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
							PushPercentage = 0.2,
							ChargeCounter = 0
						},
						new StoneGuardEffectData
						{
							IsStarEf = new bool?(false),
							StunSeconds = 2.0,
							ProgressPush = 1.0,
							ChancePerSecond = 0.3
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
							HealRate = 0.2
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
							MaxFireySoulCap = 5,
							TickCap = 3
						},
						new VictiousEffectData
						{
							IsStarEf = new bool?(false),
							DamageType = OutputType.Divine,
							CurrentTargets = new List<IBattleUnit>(),
							CurrentTargetCounter = 0,
							DamageRatePerSecond = 0.1,
							TargetSwitchTimerCap = 10
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
							Extra = 2
						},
						new ConfidentHealerData
						{
							IsStar = false,
							AfterHealSeconds = 3,
							AfterHealRate = 0.2,
							HealBoostRate = 0.5
						}
					}
				}
			};
		}
		return new List<SpecialEffectPresence>();
	}

	// Token: 0x06004C34 RID: 19508 RVA: 0x001DBB3C File Offset: 0x001D9F3C
	public List<SpecialEffectPresence> GetbossSpecialEffectsPresences()
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
						new PossessionData
						{
							IsStarEf = new bool?(false),
							Chance = 0.7,
							TriggerEventType = AdventureEventType.DamageReleased,
							LastingTurns = 2,
							PossessionEffectSourceIdentityCode = "affixPossesion",
							Boosts = new List<BoostSetting>
							{
								new BoostSetting
								{
									BoostValue = 0.8,
									BoostAttribute = AttributeType.CritRate
								}
							}
						},
						new StarfallData
						{
							IsStarEf = new bool?(false),
							Chance = 0.8,
							DamageType = OutputType.Divine,
							DamagePercentage = 1.2
						},
						new ExtraTargetingData
						{
							IsStarEf = new bool?(false),
							CandidateTypes = new List<TargetCandidateType>
							{
								TargetCandidateType.HostileAlive
							},
							Extra = 3
						},
						new StoneOfSoulbringerData
						{
							IsStarEf = new bool?(false),
							LastingSeconds = 2f
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
							Chance = 0.5,
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
							FiresPerHit = 3,
							StartFires = 3
						},
						new ExtraTargetingData
						{
							IsStarEf = new bool?(false),
							CandidateTypes = new List<TargetCandidateType>
							{
								TargetCandidateType.HostileAlive
							},
							Extra = 4
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
							PushBackRate = 0.3
						},
						new TranscendenceEffectData
						{
							IsStarEf = new bool?(false),
							Rate = 1.5
						},
						new ExtraTargetingData
						{
							IsStarEf = new bool?(false),
							CandidateTypes = new List<TargetCandidateType>
							{
								TargetCandidateType.HostileAlive
							},
							Extra = 4
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
						new FirstHandEffectData
						{
							IsStarEf = new bool?(false),
							StartProgress = 1.0
						},
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
						new TranscendenceEffectData
						{
							IsStarEf = new bool?(false),
							Rate = 1.0
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
							PushPercentage = 0.2
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
							PushBackRate = 0.3
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
							PushPercentage = 0.2,
							ChargeCounter = 0
						},
						new StoneGuardEffectData
						{
							IsStarEf = new bool?(false),
							StunSeconds = 2.0,
							ProgressPush = 1.0,
							ChancePerSecond = 0.3
						},
						new VictiousEffectData
						{
							IsStarEf = new bool?(false),
							DamageType = OutputType.Poison,
							DamageRatePerSecond = 0.1,
							TargetSwitchTimerCap = 5,
							CurrentTargets = new List<IBattleUnit>(),
							CurrentTargetCounter = 0
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
							HealRate = 0.2
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
							MaxFireySoulCap = 5,
							TickCap = 3
						},
						new VictiousEffectData
						{
							IsStarEf = new bool?(false),
							DamageType = OutputType.Divine,
							CurrentTargets = new List<IBattleUnit>(),
							CurrentTargetCounter = 0,
							DamageRatePerSecond = 0.1,
							TargetSwitchTimerCap = 10
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
						}
					}
				}
			};
		}
		return new List<SpecialEffectPresence>();
	}

	// Token: 0x06004C35 RID: 19509 RVA: 0x001DC498 File Offset: 0x001DA898
	public List<SkillPresence> GetSkillPresences()
	{
		return new List<SkillPresence>
		{
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.FireBall,
					SkillType.Harmony
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.FireBall,
					SkillType.Flame,
					SkillType.LightFire
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.FireBlast,
					SkillType.Harmony
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.ChargedBolt,
					SkillType.LightningSpeed
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.Meteorolite,
					SkillType.Swift
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.Freeze,
					SkillType.ReturningSoul
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.ShadowSacrifice,
					SkillType.Harmony
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.DivineHammer,
					SkillType.Stray
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.DivineLight,
					SkillType.Harmony
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.CurseOfCube,
					SkillType.Swift
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.Shock,
					SkillType.Wave
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.FireBurst,
					SkillType.Rebirth
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.Roar,
					SkillType.FleshToStone
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.GrandStrategy,
					SkillType.BloodThirst
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.StealSoul,
					SkillType.Swift
				}
			},
			new SkillPresence
			{
				Presence = 100,
				Skills = new List<SkillType>
				{
					SkillType.Strike,
					SkillType.FleshToStone
				}
			}
		};
	}

	// Token: 0x06004C36 RID: 19510 RVA: 0x001DC837 File Offset: 0x001DAC37
	public virtual void TownProcess(AdventurerProfile adventurer, GameWorldEvent evt, object data)
	{
	}
}
