using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000489 RID: 1161
public class SystemProcessor : IFactionProcessor
{
	// Token: 0x060020EC RID: 8428 RVA: 0x000E5A38 File Offset: 0x000E3E38
	public SystemProcessor()
	{
	}

	// Token: 0x1700022A RID: 554
	// (get) Token: 0x060020ED RID: 8429 RVA: 0x000E5A5B File Offset: 0x000E3E5B
	public GameFactionType CorrespondingGameFactionType
	{
		get
		{
			return GameFactionType.SystemProcess;
		}
	}

	// Token: 0x060020EE RID: 8430 RVA: 0x000E5A5E File Offset: 0x000E3E5E
	private void Save()
	{
		GameWorld.instance.PlayerProfile.Save();
	}

	// Token: 0x060020EF RID: 8431 RVA: 0x000E5A6F File Offset: 0x000E3E6F
	private void Backup()
	{
		Thread.Sleep(15000);
		GameWorld.instance.PlayerProfile.Backup();
	}

	// Token: 0x060020F0 RID: 8432 RVA: 0x000E5A8C File Offset: 0x000E3E8C
	public void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.BuildingTypeUnlocked)
		{
			BuildingType type = (BuildingType)data;
			List<TownSlot> source = (from b in GameWorld.instance.PlayerProfile.Buildings
			where b.Value == null
			select b into s
			select s.Key).ToList<TownSlot>();
			if (source.Any<TownSlot>())
			{
				GameWorld.instance.PlayerProfile.Build(type, source.First<TownSlot>());
			}
		}
		SystemProcessor.GameStartupProcess(evt);
		this.InitialGameRewards(evt);
		SystemProcessor.ShopRefresh(evt);
		this.SeasonWeatherCalculation(evt);
		SystemProcessor.AdventureSuccessCalculation(evt, data);
		this.QuestHandlersProcess(evt, data);
		SystemProcessor.AdventureCompletionContribution(evt, data);
		SystemProcessor.InitialGameUpgrade(evt);
		SystemProcessor.ImperialDungeonProcess(evt, data);
		this.SaveProcess(evt, data);
		SystemProcessor.SchoolProcess(evt, data);
		this.BackupProcess(evt, data);
		SystemProcessor.AshOfHopePackProcess(evt, data);
		SystemProcessor.TownEventProcess(evt, data);
		SystemProcessor.DeterminationResidentEffectProcess(evt, data);
		this.SaveProfileToCloud(evt, data);
	}

	// Token: 0x060020F1 RID: 8433 RVA: 0x000E5B94 File Offset: 0x000E3F94
	private static void DeterminationResidentEffectProcess(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.ResourceUpdated && data is ResourceUpdateEvent)
		{
			ResourceUpdateEvent resourceUpdateEvent = data as ResourceUpdateEvent;
			if (resourceUpdateEvent.ResourceType == ResourceType.PracticePoints && resourceUpdateEvent.Change < 0.0)
			{
				if (GameWorld.instance.PlayerProfile.Residents.Any((Resident r) => r.Effects.OfType<DeterminationResidentEffect>().Any<DeterminationResidentEffect>()))
				{
					double num = Math.Round(-resourceUpdateEvent.Change * DeterminationResidentEffect.Rate, 0);
					if (num > 2147483647.0)
					{
						num = 2147483647.0;
					}
					int num2 = (int)num;
					GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
					{
						new ResourceUpdate
						{
							ResourceType = ResourceType.Money,
							ChangeAmount = (double)num2,
							RelatedItems = new List<Item>()
						}
					});
				}
			}
		}
	}

	// Token: 0x060020F2 RID: 8434 RVA: 0x000E5C8C File Offset: 0x000E408C
	private static void TownEventProcess(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.GameDaysChanged)
		{
			foreach (TownEventProcessorBase townEventProcessorBase in GameWorld.instance.PlayerProfile.GetTownEventProcessors())
			{
				townEventProcessorBase.DailyProcess();
			}
		}
		foreach (TownEffectBase townEffectBase in (from s in GameWorld.instance.PlayerProfile.GetTownEffects()
		select s).ToList<TownEffectBase>())
		{
			townEffectBase.ProcessGameEvent(evt, data);
		}
	}

	// Token: 0x060020F3 RID: 8435 RVA: 0x000E5D74 File Offset: 0x000E4174
	private static void AshOfHopePackProcess(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.ResourceUpdated && data is ResourceUpdateEvent)
		{
			ResourceUpdateEvent update = data as ResourceUpdateEvent;
			SystemProcessor.AdventurerPackProcess(update);
			SystemProcessor.GemPackProcess(update);
			SystemProcessor.PracticePointsPackProcess(update);
			SystemProcessor.ResidentPackProcess(update);
		}
	}

	// Token: 0x060020F4 RID: 8436 RVA: 0x000E5DB4 File Offset: 0x000E41B4
	private static void ResidentPackProcess(ResourceUpdateEvent update)
	{
		if (update.ResourceType == ResourceType.ResidentsPack && update.Change > 0.0)
		{
			GameWorld.instance.PlayerProfile.RunPredictable("residentPackGeneration", delegate
			{
				SystemProcessor.ResidentPackGeneration(update);
			});
		}
	}

	// Token: 0x060020F5 RID: 8437 RVA: 0x000E5E1C File Offset: 0x000E421C
	private static void ResidentPackGeneration(ResourceUpdateEvent update)
	{
		List<ResidentCandidate> list = new List<ResidentCandidate>();
		int num = 0;
		while ((double)num < update.Change)
		{
			for (int i = 0; i < 5; i++)
			{
				list.Add(new ResidentCandidate
				{
					Candidate = ResidentsExtensions.SpawnResident_Default(GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_OneStar()),
					CreatedOnDay = GameWorld.instance.PlayerProfile.GameDays
				});
			}
			num++;
		}
		GameWorld.instance.PlayerProfile.AddNewResidentCandidates(list);
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = ResourceType.ResidentsPack,
				ChangeAmount = -update.Change,
				RelatedItems = new List<Item>()
			}
		});
	}

	// Token: 0x060020F6 RID: 8438 RVA: 0x000E5EF4 File Offset: 0x000E42F4
	private static void PracticePointsPackProcess(ResourceUpdateEvent update)
	{
		if (update.ResourceType == ResourceType.PracticePointsPack && update.Change > 0.0)
		{
			List<ResourceUpdate> changes = new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.PracticePoints,
					ChangeAmount = update.Change * 1000000.0,
					RelatedItems = new List<Item>()
				}
			};
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(changes);
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.PracticePointsPack,
					ChangeAmount = -update.Change,
					RelatedItems = new List<Item>()
				}
			});
		}
	}

	// Token: 0x060020F7 RID: 8439 RVA: 0x000E5FBC File Offset: 0x000E43BC
	private static void GemPackProcess(ResourceUpdateEvent update)
	{
		if ((update.ResourceType == ResourceType.GreenGemPack || update.ResourceType == ResourceType.RedGemPack || update.ResourceType == ResourceType.BlueGemPack || update.ResourceType == ResourceType.YellowGemPack) && update.Change > 0.0)
		{
			GameWorld.instance.PlayerProfile.RunPredictable("gempackgeneration" + update.ResourceType, delegate
			{
				SystemProcessor.GenerateGemPack(update);
			});
		}
	}

	// Token: 0x060020F8 RID: 8440 RVA: 0x000E6078 File Offset: 0x000E4478
	private static void GenerateGemPack(ResourceUpdateEvent update)
	{
		Dictionary<ResourceType, SocketType> dictionary = new Dictionary<ResourceType, SocketType>
		{
			{
				ResourceType.GreenGemPack,
				SocketType.Green
			},
			{
				ResourceType.RedGemPack,
				SocketType.Red
			},
			{
				ResourceType.BlueGemPack,
				SocketType.Blue
			},
			{
				ResourceType.YellowGemPack,
				SocketType.Yellow
			}
		};
		List<ResourceType> gemtypesOfColor = GemGeneratorBase.GetGemtypesOfColor(dictionary[update.ResourceType]);
		double change = update.Change;
		List<ResourceUpdate> list = new List<ResourceUpdate>();
		DifficultyLevelMeasurement endlessDungeonDf = GameWorld.instance.PlayerProfile.GetEndlessDungeonDf();
		int num = 0;
		while ((double)num < change)
		{
			Item item = gemtypesOfColor[UnityEngine.Random.Range(0, gemtypesOfColor.Count)].ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 1, endlessDungeonDf.GemTier);
			list.Add(new ResourceUpdate
			{
				ResourceType = item.Type,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>
				{
					item
				}
			});
			num++;
		}
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(list);
		GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = update.ResourceType,
				ChangeAmount = -update.Change,
				RelatedItems = new List<Item>()
			}
		});
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ShopPackOpenned, list);
	}

	// Token: 0x060020F9 RID: 8441 RVA: 0x000E61E8 File Offset: 0x000E45E8
	private static void AdventurerPackProcess(ResourceUpdateEvent update)
	{
		if (update.ResourceType == ResourceType.AdventurerPack && update.Change > 0.0)
		{
			GameWorld.instance.PlayerProfile.RunPredictable("adventurerpack", delegate
			{
				SystemProcessor.GenerateAdventurerPack(update);
			});
		}
	}

	// Token: 0x060020FA RID: 8442 RVA: 0x000E6250 File Offset: 0x000E4650
	private static void GenerateAdventurerPack(ResourceUpdateEvent update)
	{
		List<AdventurerCandidate> list = new List<AdventurerCandidate>();
		int num = 0;
		while ((double)num < update.Change)
		{
			list.AddRange(RecruitmentFacility.GenerateProfiles(1, 0.2));
			num++;
		}
		RecruitmentFacility recruitmentFacility = (from b in GameWorld.instance.PlayerProfile.Buildings
		select b.Value into b
		where b != null && b.BuildingType == BuildingType.RecruitmentFacility
		select b).FirstOrDefault<IBuildingProfile>() as RecruitmentFacility;
		if (recruitmentFacility != null)
		{
			recruitmentFacility.AddCandidates(list);
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = ResourceType.AdventurerPack,
					ChangeAmount = -update.Change,
					RelatedItems = new List<Item>()
				}
			});
		}
	}

	// Token: 0x060020FB RID: 8443 RVA: 0x000E6348 File Offset: 0x000E4748
	private static void GameStartupProcess(GameWorldEvent evt)
	{
		if (evt == GameWorldEvent.GameSessionInitializationCompleted)
		{
			GameWorld.instance.PlayerProfile.GetProgress(null).Quests.RemoveAll((Quest q) => (q.Completed && q.Rewarded) || q.ExpirationNotified);
			GameWorld.instance.PlayerProfile.RunWhile("itemqualityratingadded", delegate
			{
				foreach (Item item in GameWorld.instance.PlayerProfile.Items)
				{
					item.CalculateQualityRatingsAndCacheAttributes();
				}
				foreach (AdventurerProfile adventurerProfile in GameWorld.instance.PlayerProfile.AdventurerProfiles)
				{
					foreach (Item item2 in adventurerProfile.GetEquipments())
					{
						item2.CalculateQualityRatingsAndCacheAttributes();
					}
				}
			});
			GameWorld.instance.PlayerProfile.RunWhile("item_ownerconnections", delegate
			{
				foreach (AdventurerProfile adventurerProfile in GameWorld.instance.PlayerProfile.AdventurerProfiles)
				{
					foreach (Item item in adventurerProfile.GetEquipments())
					{
						item.SetOwner(adventurerProfile);
					}
				}
			});
			if (ResourceType.ShopPermit.HasObtained() && !GameWorld.instance.PlayerProfile.BuildingHasBeenBuilt(BuildingType.Shop))
			{
				var <>__AnonType = (from b in GameWorld.instance.PlayerProfile.Buildings
				select new
				{
					slot = b.Key,
					building = b.Value
				}).FirstOrDefault(b => b.building == null);
				if (<>__AnonType != null)
				{
					GameWorld.instance.PlayerProfile.Build(BuildingType.Shop, <>__AnonType.slot);
				}
			}
			if (ResourceType.RecruitmentFacilityPermit.HasObtained() && !GameWorld.instance.PlayerProfile.BuildingHasBeenBuilt(BuildingType.RecruitmentFacility))
			{
				var <>__AnonType2 = (from b in GameWorld.instance.PlayerProfile.Buildings
				select new
				{
					slot = b.Key,
					building = b.Value
				}).FirstOrDefault(b => b.building == null);
				if (<>__AnonType2 != null)
				{
					GameWorld.instance.PlayerProfile.Build(BuildingType.RecruitmentFacility, <>__AnonType2.slot);
				}
			}
			if (ResourceType.ForgingFacilityPermit.HasObtained() && !GameWorld.instance.PlayerProfile.BuildingHasBeenBuilt(BuildingType.ForgingFacility))
			{
				var <>__AnonType3 = (from b in GameWorld.instance.PlayerProfile.Buildings
				select new
				{
					slot = b.Key,
					building = b.Value
				}).FirstOrDefault(b => b.building == null);
				if (<>__AnonType3 != null)
				{
					GameWorld.instance.PlayerProfile.Build(BuildingType.ForgingFacility, <>__AnonType3.slot);
				}
			}
			GameWorld.instance.PlayerProfile.RunWhile("tacticquestremoval02", delegate
			{
				if (GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).QuestIssuedRecords.ContainsKey(QuestIdentifier.Main1_2_2_1) && GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).QuestIssuedRecords[QuestIdentifier.Main1_2_2_1] > 0 && !GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_2_2_1, 1))
				{
					Quest quest = GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).Quests.FirstOrDefault((Quest q) => q.QuestIdentifier == QuestIdentifier.Main1_2_2_1);
					if (quest != null)
					{
						GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).Quests.Remove(quest);
					}
					if (!GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).QuestIssuedRecords.ContainsKey(QuestIdentifier.Main1_2_2_2) || GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).QuestIssuedRecords[QuestIdentifier.Main1_2_2_2] <= 0)
					{
						GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).Quests.Add(Quest.CreatNormalQuest(QuestIdentifier.Main1_2_2_2, new List<QuestRewardBase>
						{
							new GuaranteedDirectResourceReward
							{
								ResourceType = ResourceType.PracticePoints,
								Level = 1,
								Amount = 500.0,
								DeterminedGrade = null
							}
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
				}
			});
		}
	}

	// Token: 0x060020FC RID: 8444 RVA: 0x000E65F0 File Offset: 0x000E49F0
	private static void Cache()
	{
		Dictionary<ResourceType, ItemTemplateBase> itemTemplates = BuildingExtensions.ItemTemplates;
		Dictionary<AttributeType, AttributeProcessBase> attributeProcess = GameConfigurations.AttributeProcess;
		Dictionary<ResourceCategory, ItemCategoryRootDefault> itemCategoryRootDefaults = ItemExtensions.ItemCategoryRootDefaults;
		Dictionary<SpecialEffectType, SpecialEffectProcessBase> specialEffectProcessors = ItemExtensions.SpecialEffectProcessors;
		Dictionary<ResourceType, SetItemLogicBase> setItemLogics = ItemExtensions.SetItemLogics;
		Dictionary<ResourceType, GemGeneratorBase> gemGenerators = ItemExtensions.GemGenerators;
		Dictionary<AdventureType, LevelConfigurationBase> adventureConfigurations = LevelConfigurationExtension.AdventureConfigurations;
		Dictionary<ResidentType, ResidentBase> residentBaseLogics = ResidentsExtensions.ResidentBaseLogics;
		Dictionary<UnitClass, UnitConfigurationBase> unitConfigurations = UnitExtensions.UnitConfigurations;
		Dictionary<UnitClassStyle, UnitStyleConfigurationBase> unitStyleBases = UnitExtensions.UnitStyleBases;
		Dictionary<AffixType, AffixAttachmentRuleBase> unitAffixRules = UnitExtensions.UnitAffixRules;
		Dictionary<SkillType, SkillLogicBase> skillBuilders = UnitExtensions.SkillBuilders;
		Dictionary<TeamSetType, TeamSetBase> teamSetBases = TeamSetBase.TeamSetBases;
		Dictionary<DestinationType, DestinationProcessBase> destinationProcess = TravellerExtensions.DestinationProcess;
		Dictionary<VehicleType, VehicleGeneratorBase> vehicleCreators = TravellerExtensions.VehicleCreators;
		Dictionary<TripEncounterType, TripEncounterProcess> encounterProcess = TravellerExtensions.EncounterProcess;
		Dictionary<JourneyContributeType, JourneyContributionGenerator> journeyContributionGenerators = TravellerExtensions.JourneyContributionGenerators;
		foreach (AdventurerProfile adventurerProfile in GameWorld.instance.PlayerProfile.AdventurerProfiles)
		{
			adventurerProfile.CalculateCachedAttributeValues();
		}
	}

	// Token: 0x060020FD RID: 8445 RVA: 0x000E66CC File Offset: 0x000E4ACC
	private static void InitialGameUpgrade(GameWorldEvent evt)
	{
		if (evt == GameWorldEvent.GameStarted)
		{
		}
	}

	// Token: 0x060020FE RID: 8446 RVA: 0x000E66D8 File Offset: 0x000E4AD8
	private static void ImperialDungeonProcess(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.GameSessionStarted)
		{
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_2_2_3, GameWorld.instance.PlayerProfile.GetStarRating()) && !ResourceType.SchoolPermit.HasObtained())
			{
				SteamExceptionHandle.Handle(new Exception("school permit is somehow not present after quest given..."), 0u);
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
			if (GameWorld.instance.PlayerProfile.GetProgress(null).DungeonRecords.All((DungeonRecord d) => d.AdventureType != AdventureType.ImperialMausoleum))
			{
				GameWorld.instance.PlayerProfile.GetProgress(null).DungeonRecords.Add(DungeonRecord.InitLockedRecord(AdventureType.ImperialMausoleum));
			}
			if (GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main5_3, GameWorld.instance.PlayerProfile.GetStarRating()))
			{
				GameWorld.instance.PlayerProfile.EnableDungeonRecord(AdventureType.ImperialMausoleum);
			}
		}
		if (evt == GameWorldEvent.QuestCompleted && data is QuestCompletedEvent)
		{
			QuestCompletedEvent questCompletedEvent = data as QuestCompletedEvent;
			if (questCompletedEvent.Quest.QuestIdentifier == QuestIdentifier.Main5_3)
			{
				GameWorld.instance.PlayerProfile.EnableDungeonRecord(AdventureType.ImperialMausoleum);
			}
		}
	}

	// Token: 0x060020FF RID: 8447 RVA: 0x000E6854 File Offset: 0x000E4C54
	private static void SchoolProcess(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.BuildingConstructed)
		{
			BuildingBuiltEvent buildingBuiltEvent = data as BuildingBuiltEvent;
			if (buildingBuiltEvent != null && buildingBuiltEvent.Building.BuildingType == BuildingType.School)
			{
				GameWorld.instance.PlayerProfile.BatchResourceUpdate(new List<ResourceUpdate>
				{
					new ResourceUpdate
					{
						ResourceType = ResourceType.RageBook,
						ChangeAmount = 1.0,
						RelatedItems = new List<Item>()
					},
					new ResourceUpdate
					{
						ResourceType = ResourceType.StaminaBook,
						ChangeAmount = 1.0,
						RelatedItems = new List<Item>()
					},
					new ResourceUpdate
					{
						ResourceType = ResourceType.WaveBook,
						ChangeAmount = 1.0,
						RelatedItems = new List<Item>()
					}
				});
			}
		}
	}

	// Token: 0x06002100 RID: 8448 RVA: 0x000E6933 File Offset: 0x000E4D33
	private void SaveProfileToCloud(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.GameDaysChanged && GameWorld.instance.PlayerProfile.GameDays % 50 == 0)
		{
			TownManager.Instance.UploadSaveAsync();
		}
	}

	// Token: 0x06002101 RID: 8449 RVA: 0x000E6960 File Offset: 0x000E4D60
	private void SaveProcess(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.GameDaysChanged && GameWorld.instance.PlayerProfile.GameDays % 5 == 0 && !TestingProcessor.InTesting)
		{
			Thread thread = new Thread(new ThreadStart(this.Save));
			thread.Start();
		}
	}

	// Token: 0x06002102 RID: 8450 RVA: 0x000E69B0 File Offset: 0x000E4DB0
	private void BackupProcess(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.GameDaysChanged && GameWorld.instance.PlayerProfile.GameDays % 8 == 0 && !TestingProcessor.InTesting)
		{
			Thread thread = new Thread(new ThreadStart(this.Backup));
			thread.Start();
		}
	}

	// Token: 0x06002103 RID: 8451 RVA: 0x000E6A00 File Offset: 0x000E4E00
	private static void AdventureCompletionContribution(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.AdventureCompleted)
		{
			Adventure adventure = data as Adventure;
			if (adventure != null && adventure.Survivied == Adventure.SurvivalStatus.Surviving)
			{
				double num = GameWorld.instance.PlayerProfile.GetResidentEffects<WealthResidentEffect>().Sum((WealthResidentEffect w) => w.ContributionAmount);
				if (num > 5000.0)
				{
					num = 5000.0;
				}
				if (num > 0.0)
				{
					List<ResourceUpdate> list = new List<ResourceUpdate>
					{
						ResourceUpdate.CreateMoneyUpdate(num)
					};
					GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ResidentContributed, new ResidentResourceContributeEvent
					{
						Contributor = null,
						ResourceUpdates = list
					});
					GameWorld.instance.PlayerProfile.BatchResourceUpdate(list);
				}
				List<MysticStoneResidentEffect> source = (from s in GameWorld.instance.PlayerProfile.GetResidentEffects<MysticStoneResidentEffect>()
				orderby s.CurrentRate descending
				select s).ToList<MysticStoneResidentEffect>();
				if (source.Any<MysticStoneResidentEffect>() && (double)UnityEngine.Random.value <= source.First<MysticStoneResidentEffect>().CurrentRate)
				{
					List<ResourceType> allDropableGems = adventure.CorrespondingDifficultyMeasurement.GetAllDropableGems();
					if (allDropableGems.Any<ResourceType>())
					{
						List<ResourceUpdate> list2 = adventure.CorrespondingDifficultyMeasurement.GenerateDropableGems(1);
						GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ResidentContributed, new ResidentResourceContributeEvent
						{
							ResourceUpdates = list2,
							Contributor = null
						});
						GameWorld.instance.PlayerProfile.BatchResourceUpdate(list2);
					}
				}
			}
		}
	}

	// Token: 0x06002104 RID: 8452 RVA: 0x000E6B94 File Offset: 0x000E4F94
	private void QuestHandlersProcess(GameWorldEvent evt, object data)
	{
		foreach (QuestHandlerBase questHandlerBase in SystemProcessor.QuestHandlers)
		{
			questHandlerBase.ProcessGameEvent(evt, data);
		}
		this.RandomSideQuestsProcess(evt);
	}

	// Token: 0x06002105 RID: 8453 RVA: 0x000E6BF8 File Offset: 0x000E4FF8
	private void RandomSideQuestsProcess(GameWorldEvent evt)
	{
		if (evt == GameWorldEvent.GameDaysChanged && GameWorld.instance.PlayerProfile.SideQuestsIssueDayCounter != null)
		{
			PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
			int? sideQuestsIssueDayCounter = playerProfile.SideQuestsIssueDayCounter;
			playerProfile.SideQuestsIssueDayCounter = ((sideQuestsIssueDayCounter == null) ? null : new int?(sideQuestsIssueDayCounter.GetValueOrDefault() - 1));
			if (GameWorld.instance.PlayerProfile.SideQuestsIssueDayCounter <= 0)
			{
				SystemProcessor.GenerateRandomSideQuests();
				GameWorld.instance.PlayerProfile.SideQuestsIssueDayCounter = new int?(this._sideQuestsPeriod);
			}
		}
		if (evt == GameWorldEvent.InitialRandomSideQuestsPreIssue)
		{
			SystemProcessor.GenerateRandomSideQuests();
			GameWorld.instance.PlayerProfile.SideQuestsIssueDayCounter = new int?(this._sideQuestsPeriod);
		}
	}

	// Token: 0x06002106 RID: 8454 RVA: 0x000E6CD8 File Offset: 0x000E50D8
	private static void GenerateRandomSideQuests()
	{
		List<RandomSideQuestHandlerBase> presences = (from q in SystemProcessor.QuestHandlers.OfType<RandomSideQuestHandlerBase>()
		where q.IsSpawnable()
		select q).ToList<RandomSideQuestHandlerBase>();
		int num = GameWorld.instance.PlayerProfile.GetProgress(null).Quests.Count((Quest q) => !q.QuestIdentifier.IsSpawnableSideQuest());
		int num2 = GameWorld.instance.PlayerProfile.GetMaxNumberOfSideQuests() - num;
		if (num2 < 0)
		{
			num2 = 0;
		}
		List<QuestChainIdentifier> data = (from s in presences.WeightedRandomSelectMaxUniqueness((RandomSideQuestHandlerBase a, RandomSideQuestHandlerBase b) => a.ChainIdentifier == b.ChainIdentifier, num2)
		select s.ChainIdentifier).Distinct<QuestChainIdentifier>().ToList<QuestChainIdentifier>();
		GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.RandomSideQuestsSpawnTime, data);
	}

	// Token: 0x06002107 RID: 8455 RVA: 0x000E6DD8 File Offset: 0x000E51D8
	private static void AdventureSuccessCalculation(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.AdventureCompleted)
		{
			Adventure adventure = data as Adventure;
			if (adventure != null && adventure.Survivied == Adventure.SurvivalStatus.Surviving)
			{
				GameWorld.instance.PlayerProfile.UpdateDungeonRecord(adventure.AdventureType, adventure.LevelNumber, adventure.AdventureCode, adventure.GoForwardLevel);
				if (adventure.CorrespondingDifficultyMeasurement.StarRating == -1)
				{
					GameWorld.instance.PlayerProfile.EndlessDungeonDifficultyValue = new double?((double)GameWorld.instance.PlayerProfile.GetCurrentEndlessLevelFromBackup());
					if (GameWorld.instance.PlayerProfile.EndlessDungeonDifficultyValue < adventure.CorrespondingDifficultyMeasurement.DifficultyValue)
					{
						GameWorld.instance.PlayerProfile.EndlessDungeonDifficultyValue = new double?(adventure.CorrespondingDifficultyMeasurement.DifficultyValue);
						GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(Adventure.EndlessAdventureLevelKey, Adventure.EndlessAdventurePartial + adventure.CorrespondingDifficultyMeasurement.DifficultyValue);
					}
					List<ResidentCandidate> list = new List<ResidentCandidate>();
					for (int i = 0; i < 3; i++)
					{
						list.Add(new ResidentCandidate
						{
							Candidate = ResidentsExtensions.SpawnResident_Default(GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_OneStar()),
							CreatedOnDay = GameWorld.instance.PlayerProfile.GameDays
						});
					}
					GameWorld.instance.PlayerProfile.AddNewResidentCandidates(list);
					RecruitmentFacility recruitmentFacility = (from b in GameWorld.instance.PlayerProfile.Buildings
					select b.Value).FirstOrDefault((IBuildingProfile b) => b != null && b.BuildingType == BuildingType.RecruitmentFacility) as RecruitmentFacility;
					if (recruitmentFacility != null)
					{
						float value = UnityEngine.Random.value;
						if ((double)value <= 0.6)
						{
							recruitmentFacility.RefreshCandidates(1, 0.5);
						}
					}
				}
				else
				{
					AdventureLevelConfiguration correspondingLevelConfiguration = adventure.CorrespondingLevelConfiguration;
					if (GameWorld.instance.PlayerProfile.GetProgress(null).Reputation <= correspondingLevelConfiguration.CompletionReputation)
					{
						double amount = (GameWorld.instance.PlayerProfile.GetProgress(null).Reputation > correspondingLevelConfiguration.CompletionReputation) ? 0.0 : (correspondingLevelConfiguration.CompletionReputation - GameWorld.instance.PlayerProfile.GetProgress(null).Reputation);
						GameWorld.instance.PlayerProfile.ChangeReputation(amount);
					}
					if (GameWorld.instance.PlayerProfile.AchievedDifficultyValue <= adventure.CorrespondingDifficultyMeasurement.DifficultyValue)
					{
						GameWorld.instance.PlayerProfile.AchievedDifficultyValue = new double?(adventure.CorrespondingDifficultyMeasurement.DifficultyValue);
					}
					if (GameWorld.instance.PlayerProfile.Progresses[adventure.CorrespondingDifficultyMeasurement.StarRating].MaxAchievedDifficultyValue <= adventure.CorrespondingDifficultyMeasurement.DifficultyValue)
					{
						GameWorld.instance.PlayerProfile.Progresses[adventure.CorrespondingDifficultyMeasurement.StarRating].MaxAchievedDifficultyValue = adventure.CorrespondingDifficultyMeasurement.DifficultyValue;
					}
					Shop shop = (from b in GameWorld.instance.PlayerProfile.Buildings
					select b.Value).FirstOrDefault((IBuildingProfile b) => b != null && b.BuildingType == BuildingType.Shop) as Shop;
					if (shop != null)
					{
						shop.RefreshStock(adventure.CorrespondingDifficultyMeasurement, 1);
					}
					RecruitmentFacility recruitmentFacility2 = (from b in GameWorld.instance.PlayerProfile.Buildings
					select b.Value).FirstOrDefault((IBuildingProfile b) => b != null && b.BuildingType == BuildingType.RecruitmentFacility) as RecruitmentFacility;
					if (recruitmentFacility2 != null)
					{
						float value2 = UnityEngine.Random.value;
						if ((double)value2 <= 0.6)
						{
							recruitmentFacility2.RefreshCandidates(1, (adventure.CorrespondingDifficultyMeasurement.StarRating != 1) ? 0.3 : 0.0);
						}
					}
					List<ResidentCandidate> list2 = new List<ResidentCandidate>();
					for (int j = 0; j < 3; j++)
					{
						list2.Add(new ResidentCandidate
						{
							Candidate = ResidentsExtensions.SpawnResident_Default(GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_OneStar()),
							CreatedOnDay = GameWorld.instance.PlayerProfile.GameDays
						});
					}
					GameWorld.instance.PlayerProfile.AddNewResidentCandidates(list2);
				}
			}
		}
	}

	// Token: 0x06002108 RID: 8456 RVA: 0x000E72CC File Offset: 0x000E56CC
	private void SeasonWeatherCalculation(GameWorldEvent evt)
	{
		if (evt == GameWorldEvent.GameDaysChanged)
		{
			int gameDays = GameWorld.instance.PlayerProfile.GameDays;
			int num = (int)Math.Floor((double)gameDays / (double)this._seasonPeriod);
			int num2 = num % 4;
			Season season = GameWorld.instance.PlayerProfile.CurrentSeason;
			if (num2 == 0)
			{
				season = Season.Spring;
			}
			if (num2 == 1)
			{
				season = Season.Summer;
			}
			if (num2 == 2)
			{
				season = Season.Autumn;
			}
			if (num2 == 3)
			{
				season = Season.Winter;
			}
			if (season != GameWorld.instance.PlayerProfile.CurrentSeason)
			{
				GameWorld.instance.PlayerProfile.ChangeSeason(season);
			}
			if (gameDays % 4 == 0)
			{
				List<WeatherPresence> list = new List<WeatherPresence>
				{
					new WeatherPresence
					{
						Presence = 100,
						Weather = Weather.Sunny
					},
					new WeatherPresence
					{
						Presence = 100,
						Weather = Weather.Windy
					}
				};
				if (season == Season.Winter)
				{
					list.Add(new WeatherPresence
					{
						Presence = 100,
						Weather = Weather.Snow
					});
				}
				else
				{
					list.Add(new WeatherPresence
					{
						Presence = 200,
						Weather = Weather.Rainy
					});
				}
				Weather weather = list.WeightedRandomSelect<WeatherPresence>().Weather;
				if (weather != GameWorld.instance.PlayerProfile.CurrentWeather)
				{
					GameWorld.instance.PlayerProfile.ChangeWeather(weather);
				}
			}
		}
	}

	// Token: 0x06002109 RID: 8457 RVA: 0x000E743C File Offset: 0x000E583C
	private static void ShopRefresh(GameWorldEvent evt)
	{
		if (evt == GameWorldEvent.GameDaysChanged)
		{
			Shop shop = (from b in GameWorld.instance.PlayerProfile.Buildings
			select b.Value).FirstOrDefault((IBuildingProfile b) => b != null && b.BuildingType == BuildingType.Shop) as Shop;
			if (shop != null)
			{
				shop.NumberOfDaysToRefresh--;
				if (shop.NumberOfDaysToRefresh <= 0)
				{
					shop.RefreshStock(GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_CurrentRating(), 1);
					shop.NumberOfDaysToRefresh = PlayerProfile.ShopRefreshDays;
				}
			}
		}
	}

	// Token: 0x0600210A RID: 8458 RVA: 0x000E74EC File Offset: 0x000E58EC
	private void InitialGameRewards(GameWorldEvent evt)
	{
		if (evt == GameWorldEvent.GameStarted && (!GameWorld.instance.PlayerProfile.AdditionalData.ContainsBool(this.starterset_Key) || !GameWorld.instance.PlayerProfile.AdditionalData.GetBool(this.starterset_Key)))
		{
			GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(this.starterset_Key, true);
			GameWorld.instance.PlayerProfile.Residents.AddRange(new List<Resident>
			{
				ResidentType.Peasant.CreateResidentByCoeff(GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_OneStar(), 0.3),
				ResidentType.Traveller.CreateResidentByCoeff(GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_OneStar(), 0.3),
				ResidentType.Ronin.CreateResidentByCoeff(GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_OneStar(), 0.3)
			});
		}
	}

	// Token: 0x0600210B RID: 8459 RVA: 0x000E75E4 File Offset: 0x000E59E4
	public IEnumerable ProcessBattleEvent(BroadcastEvent evt)
	{
		foreach (QuestHandlerBase handler in SystemProcessor.QuestHandlers)
		{
			IEnumerator enumerator2 = handler.ProcessAdventureEvent(evt).GetEnumerator();
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
		if (evt.EventType == AdventureEventType.UnitReadyInBattle)
		{
			IEnumerator enumerator3 = evt.EventTriggeringUnit.ApplySkillEffect(new BattlePressureEffect(5, 0.0, 0.05, evt.EventTriggeringUnit, base.GetType().FullName), false).GetEnumerator();
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
		if (evt.EventType == AdventureEventType.UnitPostCastSkill)
		{
			SkillCastBattleEvent skill = evt.AdditionalData as SkillCastBattleEvent;
			if (skill != null && skill.SkillLogic is ActiveSkillLogicBase && (skill.SkillLogic as ActiveSkillLogicBase).CoolingDownSeconds(skill.Skill.Skill) != null)
			{
				double totalReduction = evt.EventTriggeringUnit.SpecialEffects.OfType<MindlessData>().Sum((MindlessData r) => r.CDReductionRate);
				double rate = 1.0 - totalReduction;
				if (rate < 0.0)
				{
					rate = 0.0;
				}
				AdventureUnitSkill skill2 = skill.Skill;
				float? num = (skill.SkillLogic as ActiveSkillLogicBase).CoolingDownSeconds(skill.Skill.Skill);
				double? num2 = (num == null) ? null : new double?((double)num.Value);
				skill2.RemainingCoolingDownSeconds = new float?(Convert.ToSingle((num2 == null) ? null : new double?(num2.GetValueOrDefault() * rate)));
				IEnumerator enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.Skill.SourceUnit, AdventureEventType.ActiveBattleSkillEntersCoolingDowns, skill.Skill)).GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						object _3 = enumerator4.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		if (evt.EventType == AdventureEventType.UnitPostCastSkill)
		{
			SkillCastBattleEvent cast = evt.AdditionalData as SkillCastBattleEvent;
			if (cast != null)
			{
				IBattleUnit unit = cast.Skill.SourceUnit;
				SkillLogicBase selectedSkillLogic = cast.SkillLogic;
				AdventureUnitSkill selectedSkill = cast.Skill;
				if (selectedSkillLogic is MainSkillBase)
				{
					MainSkillBase mainSkill = selectedSkillLogic as MainSkillBase;
					double skillRageRatio = 1.0;
					double gaugeChange = mainSkill.GetCastingGaugeRate(selectedSkill.Skill.Level) * skillRageRatio;
					if (selectedSkill.SourceUnit.BattleEffects.OfType<FrozenHeartEffect>().Any<FrozenHeartEffect>())
					{
						gaugeChange = 0.0;
					}
					if (unit.IsPlayer)
					{
						BattleEncounter battleEncounter = unit.CurrentEncounter as BattleEncounter;
						if (battleEncounter != null)
						{
							IEnumerator enumerator5 = battleEncounter.UpdatePlayerGauge(gaugeChange, selectedSkill).GetEnumerator();
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
					}
					else
					{
						BattleEncounter battleEncounter2 = unit.CurrentEncounter as BattleEncounter;
						if (battleEncounter2 != null)
						{
							IEnumerator enumerator6 = battleEncounter2.UpdateEnemyGauge(gaugeChange, selectedSkill).GetEnumerator();
							try
							{
								while (enumerator6.MoveNext())
								{
									object _5 = enumerator6.Current;
									yield return _5;
								}
							}
							finally
							{
								IDisposable disposable5;
								if ((disposable5 = (enumerator6 as IDisposable)) != null)
								{
									disposable5.Dispose();
								}
							}
						}
					}
				}
			}
		}
		Adventure adventure = GameWorld.instance.GetCurrentAdventure();
		if (adventure != null)
		{
			int count = adventure.Encounters.Count;
			int num3 = 1 + adventure.Encounters.Count((IEncounter e) => e.IsCompleted && e.IsPlayerWon());
			if (num3 > count)
			{
				num3 = count;
			}
			AdventureSnapshot adventureSnapshot = new AdventureSnapshot();
			adventureSnapshot.Adventurers = (from a in adventure.Adventurers
			select new UnitStats
			{
				Status = a.Status,
				CorrespondingUnit = a,
				CurrentLife = a.HealthPoints,
				MaxLife = a.GetMaxLife(AttributeRetrievalLevel.Skill)
			}).ToList<UnitStats>();
			adventureSnapshot.TotalNumberOfEncounters = count;
			adventureSnapshot.CurrentEncounterIndex = num3;
			adventureSnapshot.Enemies = new List<UnitStats>();
			AdventureSnapshot adventureSnapshot2 = adventureSnapshot;
			if (evt.EventType == AdventureEventType.AdventurersWalking || evt.EventType == AdventureEventType.AdventureProgresses)
			{
				adventureSnapshot2.Status = AdventureStatus.Walking;
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureSnapUpdated, adventureSnapshot2);
			}
			if (evt.EventType == AdventureEventType.UnitReadyInBattle || evt.EventType == AdventureEventType.UnitPostReceivesDamage || evt.EventType == AdventureEventType.UnitPostReceivesHeal || evt.EventType == AdventureEventType.UnitKilled)
			{
				adventureSnapshot2.Status = AdventureStatus.InBattle;
				adventureSnapshot2.Enemies = (from e in adventure.CurrentEncounter.EnemyUnits
				select new UnitStats
				{
					Status = e.Status,
					CorrespondingUnit = e,
					CurrentLife = e.HealthPoints,
					MaxLife = e.GetMaxLife(AttributeRetrievalLevel.Skill)
				}).ToList<UnitStats>();
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureSnapUpdated, adventureSnapshot2);
			}
			if (evt.EventType == AdventureEventType.AdventureSuccess)
			{
				adventureSnapshot2.Status = AdventureStatus.Won;
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureSnapUpdated, adventureSnapshot2);
			}
			if (evt.EventType == AdventureEventType.AdventureFailed)
			{
				adventureSnapshot2.Status = AdventureStatus.Lost;
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureSnapUpdated, adventureSnapshot2);
			}
		}
		yield break;
	}

	// Token: 0x0600210C RID: 8460 RVA: 0x000E7610 File Offset: 0x000E5A10
	public List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitKilled,
			AdventureEventType.UnitPostCastSkill,
			AdventureEventType.AdventurersWalking,
			AdventureEventType.AdventureProgresses,
			AdventureEventType.UnitReadyInBattle,
			AdventureEventType.UnitPostReceivesDamage,
			AdventureEventType.UnitPostReceivesHeal,
			AdventureEventType.AdventureSuccess,
			AdventureEventType.AdventureFailed
		};
	}

	// Token: 0x0600210D RID: 8461 RVA: 0x000E766B File Offset: 0x000E5A6B
	// Note: this type is marked as 'beforefieldinit'.
	static SystemProcessor()
	{
	}

	// Token: 0x0600210E RID: 8462 RVA: 0x000E7681 File Offset: 0x000E5A81
	[CompilerGenerated]
	private static bool <ProcessGameEvent>m__0(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value == null;
	}

	// Token: 0x0600210F RID: 8463 RVA: 0x000E768D File Offset: 0x000E5A8D
	[CompilerGenerated]
	private static TownSlot <ProcessGameEvent>m__1(KeyValuePair<TownSlot, IBuildingProfile> s)
	{
		return s.Key;
	}

	// Token: 0x06002110 RID: 8464 RVA: 0x000E7696 File Offset: 0x000E5A96
	[CompilerGenerated]
	private static bool <DeterminationResidentEffectProcess>m__2(Resident r)
	{
		return r.Effects.OfType<DeterminationResidentEffect>().Any<DeterminationResidentEffect>();
	}

	// Token: 0x06002111 RID: 8465 RVA: 0x000E76A8 File Offset: 0x000E5AA8
	[CompilerGenerated]
	private static TownEffectBase <TownEventProcess>m__3(TownEffectBase s)
	{
		return s;
	}

	// Token: 0x06002112 RID: 8466 RVA: 0x000E76AB File Offset: 0x000E5AAB
	[CompilerGenerated]
	private static IBuildingProfile <GenerateAdventurerPack>m__4(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value;
	}

	// Token: 0x06002113 RID: 8467 RVA: 0x000E76B4 File Offset: 0x000E5AB4
	[CompilerGenerated]
	private static bool <GenerateAdventurerPack>m__5(IBuildingProfile b)
	{
		return b != null && b.BuildingType == BuildingType.RecruitmentFacility;
	}

	// Token: 0x06002114 RID: 8468 RVA: 0x000E76C8 File Offset: 0x000E5AC8
	[CompilerGenerated]
	private static bool <GameStartupProcess>m__6(Quest q)
	{
		return (q.Completed && q.Rewarded) || q.ExpirationNotified;
	}

	// Token: 0x06002115 RID: 8469 RVA: 0x000E76EC File Offset: 0x000E5AEC
	[CompilerGenerated]
	private static void <GameStartupProcess>m__7()
	{
		foreach (Item item in GameWorld.instance.PlayerProfile.Items)
		{
			item.CalculateQualityRatingsAndCacheAttributes();
		}
		foreach (AdventurerProfile adventurerProfile in GameWorld.instance.PlayerProfile.AdventurerProfiles)
		{
			foreach (Item item2 in adventurerProfile.GetEquipments())
			{
				item2.CalculateQualityRatingsAndCacheAttributes();
			}
		}
	}

	// Token: 0x06002116 RID: 8470 RVA: 0x000E77EC File Offset: 0x000E5BEC
	[CompilerGenerated]
	private static void <GameStartupProcess>m__8()
	{
		foreach (AdventurerProfile adventurerProfile in GameWorld.instance.PlayerProfile.AdventurerProfiles)
		{
			foreach (Item item in adventurerProfile.GetEquipments())
			{
				item.SetOwner(adventurerProfile);
			}
		}
	}

	// Token: 0x06002117 RID: 8471 RVA: 0x000E7898 File Offset: 0x000E5C98
	[CompilerGenerated]
	private static <>__AnonType0<TownSlot, IBuildingProfile> <GameStartupProcess>m__9(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return new
		{
			slot = b.Key,
			building = b.Value
		};
	}

	// Token: 0x06002118 RID: 8472 RVA: 0x000E78AD File Offset: 0x000E5CAD
	[CompilerGenerated]
	private static bool <GameStartupProcess>m__A(<>__AnonType0<TownSlot, IBuildingProfile> b)
	{
		return b.building == null;
	}

	// Token: 0x06002119 RID: 8473 RVA: 0x000E78B8 File Offset: 0x000E5CB8
	[CompilerGenerated]
	private static <>__AnonType0<TownSlot, IBuildingProfile> <GameStartupProcess>m__B(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return new
		{
			slot = b.Key,
			building = b.Value
		};
	}

	// Token: 0x0600211A RID: 8474 RVA: 0x000E78CD File Offset: 0x000E5CCD
	[CompilerGenerated]
	private static bool <GameStartupProcess>m__C(<>__AnonType0<TownSlot, IBuildingProfile> b)
	{
		return b.building == null;
	}

	// Token: 0x0600211B RID: 8475 RVA: 0x000E78D8 File Offset: 0x000E5CD8
	[CompilerGenerated]
	private static <>__AnonType0<TownSlot, IBuildingProfile> <GameStartupProcess>m__D(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return new
		{
			slot = b.Key,
			building = b.Value
		};
	}

	// Token: 0x0600211C RID: 8476 RVA: 0x000E78ED File Offset: 0x000E5CED
	[CompilerGenerated]
	private static bool <GameStartupProcess>m__E(<>__AnonType0<TownSlot, IBuildingProfile> b)
	{
		return b.building == null;
	}

	// Token: 0x0600211D RID: 8477 RVA: 0x000E78F8 File Offset: 0x000E5CF8
	[CompilerGenerated]
	private static void <GameStartupProcess>m__F()
	{
		if (GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).QuestIssuedRecords.ContainsKey(QuestIdentifier.Main1_2_2_1) && GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).QuestIssuedRecords[QuestIdentifier.Main1_2_2_1] > 0 && !GameWorld.instance.PlayerProfile.QuestIsCompleted(QuestIdentifier.Main1_2_2_1, 1))
		{
			Quest quest = GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).Quests.FirstOrDefault((Quest q) => q.QuestIdentifier == QuestIdentifier.Main1_2_2_1);
			if (quest != null)
			{
				GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).Quests.Remove(quest);
			}
			if (!GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).QuestIssuedRecords.ContainsKey(QuestIdentifier.Main1_2_2_2) || GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).QuestIssuedRecords[QuestIdentifier.Main1_2_2_2] <= 0)
			{
				GameWorld.instance.PlayerProfile.GetProgress(new int?(1)).Quests.Add(Quest.CreatNormalQuest(QuestIdentifier.Main1_2_2_2, new List<QuestRewardBase>
				{
					new GuaranteedDirectResourceReward
					{
						ResourceType = ResourceType.PracticePoints,
						Level = 1,
						Amount = 500.0,
						DeterminedGrade = null
					}
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
		}
	}

	// Token: 0x0600211E RID: 8478 RVA: 0x000E7AB6 File Offset: 0x000E5EB6
	[CompilerGenerated]
	private static bool <ImperialDungeonProcess>m__10(DungeonRecord d)
	{
		return d.AdventureType != AdventureType.ImperialMausoleum;
	}

	// Token: 0x0600211F RID: 8479 RVA: 0x000E7AC4 File Offset: 0x000E5EC4
	[CompilerGenerated]
	private static double <AdventureCompletionContribution>m__11(WealthResidentEffect w)
	{
		return w.ContributionAmount;
	}

	// Token: 0x06002120 RID: 8480 RVA: 0x000E7ACC File Offset: 0x000E5ECC
	[CompilerGenerated]
	private static double <AdventureCompletionContribution>m__12(MysticStoneResidentEffect s)
	{
		return s.CurrentRate;
	}

	// Token: 0x06002121 RID: 8481 RVA: 0x000E7AD4 File Offset: 0x000E5ED4
	[CompilerGenerated]
	private static bool <GenerateRandomSideQuests>m__13(RandomSideQuestHandlerBase q)
	{
		return q.IsSpawnable();
	}

	// Token: 0x06002122 RID: 8482 RVA: 0x000E7ADC File Offset: 0x000E5EDC
	[CompilerGenerated]
	private static bool <GenerateRandomSideQuests>m__14(Quest q)
	{
		return !q.QuestIdentifier.IsSpawnableSideQuest();
	}

	// Token: 0x06002123 RID: 8483 RVA: 0x000E7AEC File Offset: 0x000E5EEC
	[CompilerGenerated]
	private static bool <GenerateRandomSideQuests>m__15(RandomSideQuestHandlerBase a, RandomSideQuestHandlerBase b)
	{
		return a.ChainIdentifier == b.ChainIdentifier;
	}

	// Token: 0x06002124 RID: 8484 RVA: 0x000E7AFC File Offset: 0x000E5EFC
	[CompilerGenerated]
	private static QuestChainIdentifier <GenerateRandomSideQuests>m__16(RandomSideQuestHandlerBase s)
	{
		return s.ChainIdentifier;
	}

	// Token: 0x06002125 RID: 8485 RVA: 0x000E7B04 File Offset: 0x000E5F04
	[CompilerGenerated]
	private static IBuildingProfile <AdventureSuccessCalculation>m__17(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value;
	}

	// Token: 0x06002126 RID: 8486 RVA: 0x000E7B0D File Offset: 0x000E5F0D
	[CompilerGenerated]
	private static bool <AdventureSuccessCalculation>m__18(IBuildingProfile b)
	{
		return b != null && b.BuildingType == BuildingType.RecruitmentFacility;
	}

	// Token: 0x06002127 RID: 8487 RVA: 0x000E7B21 File Offset: 0x000E5F21
	[CompilerGenerated]
	private static IBuildingProfile <AdventureSuccessCalculation>m__19(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value;
	}

	// Token: 0x06002128 RID: 8488 RVA: 0x000E7B2A File Offset: 0x000E5F2A
	[CompilerGenerated]
	private static bool <AdventureSuccessCalculation>m__1A(IBuildingProfile b)
	{
		return b != null && b.BuildingType == BuildingType.Shop;
	}

	// Token: 0x06002129 RID: 8489 RVA: 0x000E7B3E File Offset: 0x000E5F3E
	[CompilerGenerated]
	private static IBuildingProfile <AdventureSuccessCalculation>m__1B(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value;
	}

	// Token: 0x0600212A RID: 8490 RVA: 0x000E7B47 File Offset: 0x000E5F47
	[CompilerGenerated]
	private static bool <AdventureSuccessCalculation>m__1C(IBuildingProfile b)
	{
		return b != null && b.BuildingType == BuildingType.RecruitmentFacility;
	}

	// Token: 0x0600212B RID: 8491 RVA: 0x000E7B5B File Offset: 0x000E5F5B
	[CompilerGenerated]
	private static IBuildingProfile <ShopRefresh>m__1D(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value;
	}

	// Token: 0x0600212C RID: 8492 RVA: 0x000E7B64 File Offset: 0x000E5F64
	[CompilerGenerated]
	private static bool <ShopRefresh>m__1E(IBuildingProfile b)
	{
		return b != null && b.BuildingType == BuildingType.Shop;
	}

	// Token: 0x0600212D RID: 8493 RVA: 0x000E7B78 File Offset: 0x000E5F78
	[CompilerGenerated]
	private static bool <GameStartupProcess>m__1F(Quest q)
	{
		return q.QuestIdentifier == QuestIdentifier.Main1_2_2_1;
	}

	// Token: 0x04001D1B RID: 7451
	private readonly string starterset_Key = "system.start";

	// Token: 0x04001D1C RID: 7452
	private int _sideQuestsPeriod = 20;

	// Token: 0x04001D1D RID: 7453
	public static string ApplicationPath = Application.persistentDataPath;

	// Token: 0x04001D1E RID: 7454
	private static readonly List<QuestHandlerBase> QuestHandlers = GameConfigurations.GetImplementationsOfAbstractClass<QuestHandlerBase>();

	// Token: 0x04001D1F RID: 7455
	private int _seasonPeriod = 20;

	// Token: 0x04001D20 RID: 7456
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, bool> <>f__am$cache0;

	// Token: 0x04001D21 RID: 7457
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, TownSlot> <>f__am$cache1;

	// Token: 0x04001D22 RID: 7458
	[CompilerGenerated]
	private static Func<Resident, bool> <>f__am$cache2;

	// Token: 0x04001D23 RID: 7459
	[CompilerGenerated]
	private static Func<TownEffectBase, TownEffectBase> <>f__am$cache3;

	// Token: 0x04001D24 RID: 7460
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache4;

	// Token: 0x04001D25 RID: 7461
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache5;

	// Token: 0x04001D26 RID: 7462
	[CompilerGenerated]
	private static Predicate<Quest> <>f__am$cache6;

	// Token: 0x04001D27 RID: 7463
	[CompilerGenerated]
	private static Action <>f__am$cache7;

	// Token: 0x04001D28 RID: 7464
	[CompilerGenerated]
	private static Action <>f__am$cache8;

	// Token: 0x04001D29 RID: 7465
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, <>__AnonType0<TownSlot, IBuildingProfile>> <>f__am$cache9;

	// Token: 0x04001D2A RID: 7466
	[CompilerGenerated]
	private static Func<<>__AnonType0<TownSlot, IBuildingProfile>, bool> <>f__am$cacheA;

	// Token: 0x04001D2B RID: 7467
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, <>__AnonType0<TownSlot, IBuildingProfile>> <>f__am$cacheB;

	// Token: 0x04001D2C RID: 7468
	[CompilerGenerated]
	private static Func<<>__AnonType0<TownSlot, IBuildingProfile>, bool> <>f__am$cacheC;

	// Token: 0x04001D2D RID: 7469
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, <>__AnonType0<TownSlot, IBuildingProfile>> <>f__am$cacheD;

	// Token: 0x04001D2E RID: 7470
	[CompilerGenerated]
	private static Func<<>__AnonType0<TownSlot, IBuildingProfile>, bool> <>f__am$cacheE;

	// Token: 0x04001D2F RID: 7471
	[CompilerGenerated]
	private static Action <>f__am$cacheF;

	// Token: 0x04001D30 RID: 7472
	[CompilerGenerated]
	private static Func<DungeonRecord, bool> <>f__am$cache10;

	// Token: 0x04001D31 RID: 7473
	[CompilerGenerated]
	private static Func<WealthResidentEffect, double> <>f__am$cache11;

	// Token: 0x04001D32 RID: 7474
	[CompilerGenerated]
	private static Func<MysticStoneResidentEffect, double> <>f__am$cache12;

	// Token: 0x04001D33 RID: 7475
	[CompilerGenerated]
	private static Func<RandomSideQuestHandlerBase, bool> <>f__am$cache13;

	// Token: 0x04001D34 RID: 7476
	[CompilerGenerated]
	private static Func<Quest, bool> <>f__am$cache14;

	// Token: 0x04001D35 RID: 7477
	[CompilerGenerated]
	private static Func<RandomSideQuestHandlerBase, RandomSideQuestHandlerBase, bool> <>f__am$cache15;

	// Token: 0x04001D36 RID: 7478
	[CompilerGenerated]
	private static Func<RandomSideQuestHandlerBase, QuestChainIdentifier> <>f__am$cache16;

	// Token: 0x04001D37 RID: 7479
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache17;

	// Token: 0x04001D38 RID: 7480
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache18;

	// Token: 0x04001D39 RID: 7481
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache19;

	// Token: 0x04001D3A RID: 7482
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache1A;

	// Token: 0x04001D3B RID: 7483
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache1B;

	// Token: 0x04001D3C RID: 7484
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache1C;

	// Token: 0x04001D3D RID: 7485
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, IBuildingProfile> <>f__am$cache1D;

	// Token: 0x04001D3E RID: 7486
	[CompilerGenerated]
	private static Func<IBuildingProfile, bool> <>f__am$cache1E;

	// Token: 0x04001D3F RID: 7487
	[CompilerGenerated]
	private static Func<Quest, bool> <>f__am$cache1F;

	// Token: 0x02000D32 RID: 3378
	[CompilerGenerated]
	private sealed class <ResidentPackProcess>c__AnonStorey1
	{
		// Token: 0x06005676 RID: 22134 RVA: 0x000E7B84 File Offset: 0x000E5F84
		public <ResidentPackProcess>c__AnonStorey1()
		{
		}

		// Token: 0x06005677 RID: 22135 RVA: 0x000E7B8C File Offset: 0x000E5F8C
		internal void <>m__0()
		{
			SystemProcessor.ResidentPackGeneration(this.update);
		}

		// Token: 0x04004506 RID: 17670
		internal ResourceUpdateEvent update;
	}

	// Token: 0x02000D33 RID: 3379
	[CompilerGenerated]
	private sealed class <GemPackProcess>c__AnonStorey2
	{
		// Token: 0x06005678 RID: 22136 RVA: 0x000E7B99 File Offset: 0x000E5F99
		public <GemPackProcess>c__AnonStorey2()
		{
		}

		// Token: 0x06005679 RID: 22137 RVA: 0x000E7BA1 File Offset: 0x000E5FA1
		internal void <>m__0()
		{
			SystemProcessor.GenerateGemPack(this.update);
		}

		// Token: 0x04004507 RID: 17671
		internal ResourceUpdateEvent update;
	}

	// Token: 0x02000D34 RID: 3380
	[CompilerGenerated]
	private sealed class <AdventurerPackProcess>c__AnonStorey3
	{
		// Token: 0x0600567A RID: 22138 RVA: 0x000E7BAE File Offset: 0x000E5FAE
		public <AdventurerPackProcess>c__AnonStorey3()
		{
		}

		// Token: 0x0600567B RID: 22139 RVA: 0x000E7BB6 File Offset: 0x000E5FB6
		internal void <>m__0()
		{
			SystemProcessor.GenerateAdventurerPack(this.update);
		}

		// Token: 0x04004508 RID: 17672
		internal ResourceUpdateEvent update;
	}

	// Token: 0x02000D36 RID: 3382
	[CompilerGenerated]
	private sealed class <ProcessBattleEvent>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005682 RID: 22146 RVA: 0x000E7BC3 File Offset: 0x000E5FC3
		[DebuggerHidden]
		public <ProcessBattleEvent>c__Iterator0()
		{
		}

		// Token: 0x06005683 RID: 22147 RVA: 0x000E7BCC File Offset: 0x000E5FCC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = SystemProcessor.QuestHandlers.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_198;
			case 3u:
				Block_13:
				try
				{
					switch (num)
					{
					}
					if (enumerator4.MoveNext())
					{
						_3 = enumerator4.Current;
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
						if ((disposable3 = (enumerator4 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				goto IL_461;
			case 4u:
				Block_20:
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
				goto IL_62A;
			case 5u:
				Block_22:
				try
				{
					switch (num)
					{
					}
					if (enumerator6.MoveNext())
					{
						_5 = enumerator6.Current;
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
						if ((disposable5 = (enumerator6 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
				goto IL_6F7;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_35:
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
					handler = enumerator.Current;
					enumerator2 = handler.ProcessAdventureEvent(evt).GetEnumerator();
					num = 4294967293u;
					goto Block_35;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			if (evt.EventType != AdventureEventType.UnitReadyInBattle)
			{
				goto IL_21A;
			}
			enumerator3 = evt.EventTriggeringUnit.ApplySkillEffect(new BattlePressureEffect(5, 0.0, 0.05, evt.EventTriggeringUnit, base.GetType().FullName), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_198:
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
			IL_21A:
			if (evt.EventType == AdventureEventType.UnitPostCastSkill)
			{
				skill = (evt.AdditionalData as SkillCastBattleEvent);
				if (skill != null && skill.SkillLogic is ActiveSkillLogicBase && (skill.SkillLogic as ActiveSkillLogicBase).CoolingDownSeconds(skill.Skill.Skill) != null)
				{
					totalReduction = evt.EventTriggeringUnit.SpecialEffects.OfType<MindlessData>().Sum((MindlessData r) => r.CDReductionRate);
					rate = 1.0 - totalReduction;
					if (rate < 0.0)
					{
						rate = 0.0;
					}
					AdventureUnitSkill skill2 = skill.Skill;
					float? num2 = (skill.SkillLogic as ActiveSkillLogicBase).CoolingDownSeconds(skill.Skill.Skill);
					double? num3 = (num2 == null) ? null : new double?((double)num2.Value);
					skill2.RemainingCoolingDownSeconds = new float?(Convert.ToSingle((num3 == null) ? null : new double?(num3.GetValueOrDefault() * rate)));
					enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(skill.Skill.SourceUnit, AdventureEventType.ActiveBattleSkillEntersCoolingDowns, skill.Skill)).GetEnumerator();
					num = 4294967293u;
					goto Block_13;
				}
			}
			IL_461:
			if (evt.EventType == AdventureEventType.UnitPostCastSkill)
			{
				cast = (evt.AdditionalData as SkillCastBattleEvent);
				if (cast != null)
				{
					unit = cast.Skill.SourceUnit;
					selectedSkillLogic = cast.SkillLogic;
					selectedSkill = cast.Skill;
					if (selectedSkillLogic is MainSkillBase)
					{
						mainSkill = (selectedSkillLogic as MainSkillBase);
						skillRageRatio = 1.0;
						gaugeChange = mainSkill.GetCastingGaugeRate(selectedSkill.Skill.Level) * skillRageRatio;
						if (selectedSkill.SourceUnit.BattleEffects.OfType<FrozenHeartEffect>().Any<FrozenHeartEffect>())
						{
							gaugeChange = 0.0;
						}
						if (unit.IsPlayer)
						{
							battleEncounter = (unit.CurrentEncounter as BattleEncounter);
							if (battleEncounter != null)
							{
								enumerator5 = battleEncounter.UpdatePlayerGauge(gaugeChange, selectedSkill).GetEnumerator();
								num = 4294967293u;
								goto Block_20;
							}
						}
						else
						{
							battleEncounter2 = (unit.CurrentEncounter as BattleEncounter);
							if (battleEncounter2 != null)
							{
								enumerator6 = battleEncounter2.UpdateEnemyGauge(gaugeChange, selectedSkill).GetEnumerator();
								num = 4294967293u;
								goto Block_22;
							}
						}
					}
				}
			}
			IL_62A:
			IL_6F7:
			adventure = GameWorld.instance.GetCurrentAdventure();
			if (adventure != null)
			{
				int count = adventure.Encounters.Count;
				int num4 = 1 + adventure.Encounters.Count((IEncounter e) => e.IsCompleted && e.IsPlayerWon());
				if (num4 > count)
				{
					num4 = count;
				}
				AdventureSnapshot adventureSnapshot = new AdventureSnapshot();
				adventureSnapshot.Adventurers = (from a in adventure.Adventurers
				select new UnitStats
				{
					Status = a.Status,
					CorrespondingUnit = a,
					CurrentLife = a.HealthPoints,
					MaxLife = a.GetMaxLife(AttributeRetrievalLevel.Skill)
				}).ToList<UnitStats>();
				adventureSnapshot.TotalNumberOfEncounters = count;
				adventureSnapshot.CurrentEncounterIndex = num4;
				adventureSnapshot.Enemies = new List<UnitStats>();
				AdventureSnapshot adventureSnapshot2 = adventureSnapshot;
				if (evt.EventType == AdventureEventType.AdventurersWalking || evt.EventType == AdventureEventType.AdventureProgresses)
				{
					adventureSnapshot2.Status = AdventureStatus.Walking;
					GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureSnapUpdated, adventureSnapshot2);
				}
				if (evt.EventType == AdventureEventType.UnitReadyInBattle || evt.EventType == AdventureEventType.UnitPostReceivesDamage || evt.EventType == AdventureEventType.UnitPostReceivesHeal || evt.EventType == AdventureEventType.UnitKilled)
				{
					adventureSnapshot2.Status = AdventureStatus.InBattle;
					adventureSnapshot2.Enemies = (from e in adventure.CurrentEncounter.EnemyUnits
					select new UnitStats
					{
						Status = e.Status,
						CorrespondingUnit = e,
						CurrentLife = e.HealthPoints,
						MaxLife = e.GetMaxLife(AttributeRetrievalLevel.Skill)
					}).ToList<UnitStats>();
					GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureSnapUpdated, adventureSnapshot2);
				}
				if (evt.EventType == AdventureEventType.AdventureSuccess)
				{
					adventureSnapshot2.Status = AdventureStatus.Won;
					GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureSnapUpdated, adventureSnapshot2);
				}
				if (evt.EventType == AdventureEventType.AdventureFailed)
				{
					adventureSnapshot2.Status = AdventureStatus.Lost;
					GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventureSnapUpdated, adventureSnapshot2);
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001240 RID: 4672
		// (get) Token: 0x06005684 RID: 22148 RVA: 0x000E852C File Offset: 0x000E692C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001241 RID: 4673
		// (get) Token: 0x06005685 RID: 22149 RVA: 0x000E8534 File Offset: 0x000E6934
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005686 RID: 22150 RVA: 0x000E853C File Offset: 0x000E693C
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
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
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
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
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
					if ((disposable5 = (enumerator6 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005687 RID: 22151 RVA: 0x000E86CC File Offset: 0x000E6ACC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005688 RID: 22152 RVA: 0x000E86D3 File Offset: 0x000E6AD3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005689 RID: 22153 RVA: 0x000E86DC File Offset: 0x000E6ADC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SystemProcessor.<ProcessBattleEvent>c__Iterator0 <ProcessBattleEvent>c__Iterator = new SystemProcessor.<ProcessBattleEvent>c__Iterator0();
			<ProcessBattleEvent>c__Iterator.$this = this;
			<ProcessBattleEvent>c__Iterator.evt = evt;
			return <ProcessBattleEvent>c__Iterator;
		}

		// Token: 0x0600568A RID: 22154 RVA: 0x000E871C File Offset: 0x000E6B1C
		private static double <>m__0(MindlessData r)
		{
			return r.CDReductionRate;
		}

		// Token: 0x0600568B RID: 22155 RVA: 0x000E8724 File Offset: 0x000E6B24
		private static bool <>m__1(IEncounter e)
		{
			return e.IsCompleted && e.IsPlayerWon();
		}

		// Token: 0x0600568C RID: 22156 RVA: 0x000E873C File Offset: 0x000E6B3C
		private static UnitStats <>m__2(AdventurerBattleUnit a)
		{
			return new UnitStats
			{
				Status = a.Status,
				CorrespondingUnit = a,
				CurrentLife = a.HealthPoints,
				MaxLife = a.GetMaxLife(AttributeRetrievalLevel.Skill)
			};
		}

		// Token: 0x0600568D RID: 22157 RVA: 0x000E877C File Offset: 0x000E6B7C
		private static UnitStats <>m__3(IBattleUnit e)
		{
			return new UnitStats
			{
				Status = e.Status,
				CorrespondingUnit = e,
				CurrentLife = e.HealthPoints,
				MaxLife = e.GetMaxLife(AttributeRetrievalLevel.Skill)
			};
		}

		// Token: 0x0400450B RID: 17675
		internal List<QuestHandlerBase>.Enumerator $locvar0;

		// Token: 0x0400450C RID: 17676
		internal QuestHandlerBase <handler>__1;

		// Token: 0x0400450D RID: 17677
		internal BroadcastEvent evt;

		// Token: 0x0400450E RID: 17678
		internal IEnumerator $locvar1;

		// Token: 0x0400450F RID: 17679
		internal object <_>__2;

		// Token: 0x04004510 RID: 17680
		internal IDisposable $locvar2;

		// Token: 0x04004511 RID: 17681
		internal IEnumerator $locvar3;

		// Token: 0x04004512 RID: 17682
		internal object <_>__3;

		// Token: 0x04004513 RID: 17683
		internal IDisposable $locvar4;

		// Token: 0x04004514 RID: 17684
		internal SkillCastBattleEvent <skill>__4;

		// Token: 0x04004515 RID: 17685
		internal double <totalReduction>__5;

		// Token: 0x04004516 RID: 17686
		internal double <rate>__5;

		// Token: 0x04004517 RID: 17687
		internal IEnumerator $locvar5;

		// Token: 0x04004518 RID: 17688
		internal object <_>__6;

		// Token: 0x04004519 RID: 17689
		internal IDisposable $locvar6;

		// Token: 0x0400451A RID: 17690
		internal SkillCastBattleEvent <cast>__7;

		// Token: 0x0400451B RID: 17691
		internal IBattleUnit <unit>__8;

		// Token: 0x0400451C RID: 17692
		internal SkillLogicBase <selectedSkillLogic>__8;

		// Token: 0x0400451D RID: 17693
		internal AdventureUnitSkill <selectedSkill>__8;

		// Token: 0x0400451E RID: 17694
		internal MainSkillBase <mainSkill>__9;

		// Token: 0x0400451F RID: 17695
		internal double <skillRageRatio>__9;

		// Token: 0x04004520 RID: 17696
		internal double <gaugeChange>__9;

		// Token: 0x04004521 RID: 17697
		internal BattleEncounter <battleEncounter>__10;

		// Token: 0x04004522 RID: 17698
		internal IEnumerator $locvar7;

		// Token: 0x04004523 RID: 17699
		internal object <_>__11;

		// Token: 0x04004524 RID: 17700
		internal IDisposable $locvar8;

		// Token: 0x04004525 RID: 17701
		internal BattleEncounter <battleEncounter>__12;

		// Token: 0x04004526 RID: 17702
		internal IEnumerator $locvar9;

		// Token: 0x04004527 RID: 17703
		internal object <_>__13;

		// Token: 0x04004528 RID: 17704
		internal IDisposable $locvarA;

		// Token: 0x04004529 RID: 17705
		internal Adventure <adventure>__0;

		// Token: 0x0400452A RID: 17706
		internal SystemProcessor $this;

		// Token: 0x0400452B RID: 17707
		internal object $current;

		// Token: 0x0400452C RID: 17708
		internal bool $disposing;

		// Token: 0x0400452D RID: 17709
		internal int $PC;

		// Token: 0x0400452E RID: 17710
		private static Func<MindlessData, double> <>f__am$cache0;

		// Token: 0x0400452F RID: 17711
		private static Func<IEncounter, bool> <>f__am$cache1;

		// Token: 0x04004530 RID: 17712
		private static Func<AdventurerBattleUnit, UnitStats> <>f__am$cache2;

		// Token: 0x04004531 RID: 17713
		private static Func<IBattleUnit, UnitStats> <>f__am$cache3;
	}
}
