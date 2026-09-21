using System;
using System.Collections.Generic;

// Token: 0x020004CB RID: 1227
public class MainChapterOnehandler : MainQuestHandlerBase
{
	// Token: 0x060024CD RID: 9421 RVA: 0x0010B9EB File Offset: 0x00109DEB
	public MainChapterOnehandler()
	{
	}

	// Token: 0x1700027A RID: 634
	// (get) Token: 0x060024CE RID: 9422 RVA: 0x0010B9F3 File Offset: 0x00109DF3
	public override QuestChainIdentifier ChainIdentifier
	{
		get
		{
			return this._chainIdentifier;
		}
	}

	// Token: 0x060024CF RID: 9423 RVA: 0x0010B9FC File Offset: 0x00109DFC
	public override void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		MainChapterOnehandler.Main11(evt);
		if (GameWorld.instance.PlayerProfile.GetStarRating() <= 1)
		{
			MainChapterOnehandler.Main12(evt, data);
			MainChapterOnehandler.Main13(evt, data);
			MainChapterOnehandler.Main14(evt, data);
			MainChapterOnehandler.Main15(evt, data);
		}
		MainChapterOnehandler.Main16(evt, data);
		MainChapterOnehandler.Main17(evt, data);
		MainChapterOnehandler.Main18(evt, data);
		MainChapterOnehandler.Main19(evt, data);
	}

	// Token: 0x060024D0 RID: 9424 RVA: 0x0010BA5C File Offset: 0x00109E5C
	private static void Main12(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main1_1)
			{
				GameWorld.instance.PlayerProfile.AddQuest(Quest.CreatNormalQuest(QuestIdentifier.Main1_2, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(1.0, ResourceType.WoodenWandRecipe, 1, null),
					GuaranteedDirectResourceReward.CreateDirectResourceReward(1.0, ResourceType.CopperCoatedPlateRecipe, 1, null),
					GuaranteedDirectResourceReward.CreateDirectResourceReward(100.0, ResourceType.Wood, 1, null),
					GuaranteedDirectResourceReward.CreateDirectResourceReward(100.0, ResourceType.Ore, 1, null),
					GuaranteedDirectResourceReward.CreateDirectResourceReward(100.0, ResourceType.Leather, 1, null)
				}, new List<QuestRequirementBase>
				{
					new WeaponProductionRequirementLogic
					{
						fullFilled = false,
						RequiredAmount = 1,
						ProducedAmountSoFar = 0
					},
					new ArmorProductionRequirement
					{
						fullFilled = false,
						RequiredAmount = 1,
						ProducedAmountSoFar = 0
					}
				}));
			}
		}
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent2 = data as QuestCompletedEvent;
			if (questCompletedEvent2.Quest.QuestIdentifier == QuestIdentifier.Main1_1)
			{
				MainChapterOnehandler.Add1222();
			}
		}
		if (evt == GameWorldEvent.GameDaysChanged && GameWorld.instance.PlayerProfile.GetProgress(null).Reputation >= 1000.0 && !QuestIdentifier.Main1_2_2_3.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating()) && !GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_2_2_3, GameWorld.instance.PlayerProfile.GetStarRating()))
		{
			MainChapterOnehandler.CreateQuest1223();
		}
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent3 = data as QuestCompletedEvent;
			if (questCompletedEvent3.Quest.QuestIdentifier == QuestIdentifier.Main1_2_2_3)
			{
				MainChapterOnehandler.AddQuest1224();
			}
		}
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent4 = data as QuestCompletedEvent;
			if (questCompletedEvent4.Quest.QuestIdentifier == QuestIdentifier.Main1_2_2_4)
			{
				MainChapterOnehandler.AddQuest1225();
			}
		}
	}

	// Token: 0x060024D1 RID: 9425 RVA: 0x0010BCC4 File Offset: 0x0010A0C4
	public static void Add1222()
	{
		GameWorld.instance.PlayerProfile.AddQuest(Quest.CreatNormalQuest(QuestIdentifier.Main1_2_2_2, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(500.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new ActiveSkillCastRequirementLogic
			{
				FFilled = false,
				CurrentCount = 0,
				NumberOfRequired = 15
			}
		}));
	}

	// Token: 0x060024D2 RID: 9426 RVA: 0x0010BD3C File Offset: 0x0010A13C
	public static void AddQuest1225()
	{
		GameWorld.instance.PlayerProfile.AddQuest(Quest.CreatNormalQuest(QuestIdentifier.Main1_2_2_5, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(12000.0, ResourceType.Money, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward(10000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.ShadowPath,
				Configuration = new AdventureLevelConfiguration
				{
					NumberOfRounds = 4,
					LevelNumber = 1,
					NumberOfMinionsPerRound = 0,
					CustomizedIdentityCode = "M1225",
					BossFormations = new List<FormationPresence>(),
					DungeonEffects = new List<ISpecialEffectDataLoad>(),
					MiniBossSpawnTable = new List<MonsterAppearance>
					{
						new MonsterAppearance(100, UnitClass.PurpleDevil)
					},
					MinionSpawnTable = new List<MonsterAppearance>
					{
						new MonsterAppearance(100, UnitClass.Devil),
						new MonsterAppearance(100, UnitClass.BlueDevil)
					},
					EnemyAmountInBattleToExclusive = 4,
					EnemyAmountInBattleFromInclusive = 5,
					CompletionReputation = 2100.0,
					BossSpawnTable = new List<MonsterAppearance>
					{
						new MonsterAppearance(100, UnitClass.Mutant)
					}
				},
				DifficultyMeasurement = new double?(21.0),
				IsTwistedTimeDungeon = true
			}
		}));
	}

	// Token: 0x060024D3 RID: 9427 RVA: 0x0010BED4 File Offset: 0x0010A2D4
	public static void AddQuest1224()
	{
		if (!ResourceType.SchoolPermit.HasObtained())
		{
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.SchoolPermit,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>()
				}
			});
		}
		GameWorld.instance.PlayerProfile.AddQuest(Quest.CreatNormalQuest(QuestIdentifier.Main1_2_2_4, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(3000.0, ResourceType.Money, 1, null)
		}, new List<QuestRequirementBase>
		{
			new SchoolLearningRequirementLogic
			{
				FFilled = false,
				RequiredAmount = 3,
				CurrentCount = 0
			}
		}));
	}

	// Token: 0x060024D4 RID: 9428 RVA: 0x0010BFAC File Offset: 0x0010A3AC
	public static void CreateQuest1223()
	{
		GameWorld.instance.PlayerProfile.AddQuest(Quest.CreatNormalQuest(QuestIdentifier.Main1_2_2_3, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(750.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new MonsterKillRequirementLogic
			{
				fullfilled = false,
				MonsterClass = UnitClass.DarkKnight,
				MonsterSlotType = AdventureEncounterSlotType.Boss,
				RequiredLevels = new List<int>
				{
					3
				},
				RequiredDungeons = new List<AdventureType>
				{
					AdventureType.MistForest
				},
				KilledAmount = 0,
				IsGurranteedSpawn = true,
				RequiredKills = 1
			}
		}));
	}

	// Token: 0x060024D5 RID: 9429 RVA: 0x0010C06C File Offset: 0x0010A46C
	private static void Main11(GameWorldEvent evt)
	{
		if ((evt == GameWorldEvent.GameDaysChanged && GameWorld.instance.PlayerProfile.GameDays == QuestConfigurations.InitialMainQuestStartingGameDay && !GameWorld.instance.PlayerProfile.QuestIsActive(QuestIdentifier.Main1_1)) || (evt == GameWorldEvent.GameSessionInitializationCompleted && !QuestIdentifier.Main1_1.QuestHasBeenIssued(GameWorld.instance.PlayerProfile.GetStarRating())))
		{
			AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.WoodenForest.GetAdventureLevelConfiguration(1).NakedDuplicate();
			adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
			{
				new MonsterAppearance(100, UnitClass.GreenOrc)
			};
			adventureLevelConfiguration.EnemyAmountInBattleFromInclusive = 1;
			adventureLevelConfiguration.EnemyAmountInBattleToExclusive = 3;
			adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
			adventureLevelConfiguration.BossFormations = new List<FormationPresence>
			{
				new FormationPresence
				{
					Presence = 100,
					Minions = new List<UnitClass>
					{
						UnitClass.GreenOrc
					}
				}
			};
			Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main1_1, new List<QuestRewardBase>
			{
				GuaranteedDirectResourceReward.CreateDirectResourceReward(100.0, ResourceType.Wood, 1, null),
				GuaranteedDirectResourceReward.CreateDirectResourceReward(100.0, ResourceType.Ore, 1, null),
				GuaranteedDirectResourceReward.CreateDirectResourceReward(100.0, ResourceType.Leather, 1, null),
				GuaranteedDirectResourceReward.CreateDirectResourceReward(1.0, ResourceType.ClothGownRecipe, 1, null),
				GuaranteedDirectResourceReward.CreateDirectResourceReward(1.0, ResourceType.WoodenSwordRecipe, 1, null)
			}, new List<QuestRequirementBase>
			{
				new CustomizedDungeonThroughRequirementLogic
				{
					fullfilled = false,
					DungeonType = AdventureType.WoodenForest,
					Configuration = adventureLevelConfiguration,
					DifficultyMeasurement = new double?(0.0),
					IsTwistedTimeDungeon = false
				}
			});
			GameWorld.instance.PlayerProfile.AddQuest(quest);
		}
	}

	// Token: 0x060024D6 RID: 9430 RVA: 0x0010C28C File Offset: 0x0010A68C
	private static void Main13(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main1_2)
			{
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
				{
					new ResourceUpdate
					{
						ResourceType = ResourceType.RecruitmentFacilityPermit,
						ChangeAmount = 1.0,
						RelatedItems = new List<Item>()
					}
				});
				Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main1_3, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(500.0, ResourceType.PracticePoints, 1, null)
				}, new List<QuestRequirementBase>
				{
					new RecruitHeroRequirementLogic
					{
						RequiredAmount = 1,
						FFilled = false,
						AmountSoFar = 0
					},
					new SaleWeaponRequirementLogic
					{
						fullFilled = false,
						SaleSoFar = 0,
						RequirementAmount = 1
					},
					new SaleArmorRequirementLogic
					{
						fullFilled = false,
						SaleSoFar = 0,
						RequirementAmount = 1
					}
				});
				GameWorld.instance.PlayerProfile.AddQuest(quest);
			}
		}
	}

	// Token: 0x060024D7 RID: 9431 RVA: 0x0010C3D4 File Offset: 0x0010A7D4
	private static void Main14(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main1_3)
			{
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
				{
					new ResourceUpdate
					{
						ResourceType = ResourceType.ShopPermit,
						ChangeAmount = 1.0,
						RelatedItems = new List<Item>()
					}
				});
				Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main1_4, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(2000.0, ResourceType.Money, 1, null)
				}, new List<QuestRequirementBase>
				{
					new PurchaseItemRequirementLogic
					{
						fullFilled = false,
						PurchasedSoFar = 0,
						RequirementNumberOfPurchases = 1
					}
				});
				GameWorld.instance.PlayerProfile.AddQuest(quest);
			}
		}
	}

	// Token: 0x060024D8 RID: 9432 RVA: 0x0010C4CC File Offset: 0x0010A8CC
	private static void Main15(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main1_4)
			{
				Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main1_5, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(2500.0, ResourceType.Money, 1, null)
				}, new List<QuestRequirementBase>
				{
					new ResidentCollectionRequirementLogic
					{
						fullFilled = false,
						CollectedAmountSoFar = 0,
						RequirementNumberOfCollection = 1
					}
				});
				GameWorld.instance.PlayerProfile.AddQuest(quest);
			}
		}
	}

	// Token: 0x060024D9 RID: 9433 RVA: 0x0010C578 File Offset: 0x0010A978
	private static void Main16(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if ((GameWorld.instance.PlayerProfile.GetStarRating() <= 1 && questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main1_5) || (GameWorld.instance.PlayerProfile.GetStarRating() > 1 && questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main1_1))
			{
				Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main1_6, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(3000.0, ResourceType.Money, 1, null)
				}, new List<QuestRequirementBase>
				{
					new DungeonExplorationRequirementLogic
					{
						fullFilled = false,
						LevelNumber = 8,
						DungeonType = AdventureType.WoodenForest
					},
					new DungeonCompletionRequirementLogic
					{
						fullFilled = false,
						LevelNumber = 8,
						DungeonType = AdventureType.WoodenForest
					},
					new MonsterKillRequirementLogic
					{
						fullfilled = false,
						MonsterClass = UnitClass.PurpleOrc,
						KilledAmount = 0,
						MonsterSlotType = AdventureEncounterSlotType.Boss,
						RequiredDungeons = new List<AdventureType>
						{
							AdventureType.WoodenForest
						},
						RequiredLevels = new List<int>
						{
							8
						},
						RequiredKills = 1,
						IsGurranteedSpawn = true
					}
				});
				GameWorld.instance.PlayerProfile.AddQuest(quest);
			}
		}
	}

	// Token: 0x060024DA RID: 9434 RVA: 0x0010C6FC File Offset: 0x0010AAFC
	private static void Main17(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main1_6)
			{
				MainChapterOnehandler.AddMain17();
			}
		}
	}

	// Token: 0x060024DB RID: 9435 RVA: 0x0010C73C File Offset: 0x0010AB3C
	public static void AddMain17()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.WoodenForest.GetAdventureLevelConfiguration(10).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.LavaBeast)
		};
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		double value = 10.0;
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main1_7, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(3500.0, ResourceType.Money, 1, null),
			GuaranteedDirectResourceReward.CreateDirectResourceReward(2000.0, ResourceType.PracticePoints, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.WoodenForest,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(value),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x060024DC RID: 9436 RVA: 0x0010C84C File Offset: 0x0010AC4C
	private static void Main18(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main1_7)
			{
				Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main1_8, new List<QuestRewardBase>
				{
					GuaranteedDirectResourceReward.CreateDirectResourceReward(3500.0, ResourceType.Money, 1, null)
				}, new List<QuestRequirementBase>
				{
					new DungeonExplorationRequirementLogic
					{
						fullFilled = false,
						LevelNumber = 12,
						DungeonType = AdventureType.WoodenForest
					},
					new DungeonCompletionRequirementLogic
					{
						fullFilled = false,
						LevelNumber = 12,
						DungeonType = AdventureType.WoodenForest
					}
				});
				GameWorld.instance.PlayerProfile.AddQuest(quest);
			}
		}
	}

	// Token: 0x060024DD RID: 9437 RVA: 0x0010C924 File Offset: 0x0010AD24
	private static void Main19(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main1_8)
			{
				MainChapterOnehandler.AddQuest19();
			}
		}
	}

	// Token: 0x060024DE RID: 9438 RVA: 0x0010C964 File Offset: 0x0010AD64
	public static void AddQuest19()
	{
		AdventureLevelConfiguration adventureLevelConfiguration = AdventureType.WoodenForest.GetAdventureLevelConfiguration(15).NakedDuplicate();
		adventureLevelConfiguration.BossSpawnTable = new List<MonsterAppearance>
		{
			new MonsterAppearance(100, UnitClass.BlacksmithBrother)
		};
		adventureLevelConfiguration.CustomizedIdentityCode = Guid.NewGuid().ToString();
		double value = 15.0;
		Quest quest = Quest.CreatNormalQuest(QuestIdentifier.Main1_9, new List<QuestRewardBase>
		{
			GuaranteedDirectResourceReward.CreateDirectResourceReward(4000.0, ResourceType.Money, 1, null)
		}, new List<QuestRequirementBase>
		{
			new CustomizedDungeonThroughRequirementLogic
			{
				fullfilled = false,
				DungeonType = AdventureType.WoodenForest,
				Configuration = adventureLevelConfiguration,
				DifficultyMeasurement = new double?(value),
				IsTwistedTimeDungeon = false
			}
		});
		GameWorld.instance.PlayerProfile.AddQuest(quest);
	}

	// Token: 0x04001FAD RID: 8109
	private QuestChainIdentifier _chainIdentifier;
}
