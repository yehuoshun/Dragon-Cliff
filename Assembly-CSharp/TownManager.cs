using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020009A3 RID: 2467
public class TownManager : MonoBehaviour
{
	// Token: 0x060043A3 RID: 17315 RVA: 0x001B7596 File Offset: 0x001B5996
	public TownManager()
	{
	}

	// Token: 0x17000D88 RID: 3464
	// (get) Token: 0x060043A4 RID: 17316 RVA: 0x001B759E File Offset: 0x001B599E
	// (set) Token: 0x060043A5 RID: 17317 RVA: 0x001B75A6 File Offset: 0x001B59A6
	public SlotsController Slots
	{
		[CompilerGenerated]
		get
		{
			return this.<Slots>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Slots>k__BackingField = value;
		}
	}

	// Token: 0x060043A6 RID: 17318 RVA: 0x001B75B0 File Offset: 0x001B59B0
	private void Awake()
	{
		TownManager.Instance = this;
		GameWorld.instance.PlayerProfile = GameLoader.CurrentLoadedProfile;
		if (GameLoader.CurrentLoadedProfile == null)
		{
			PlayerProfileLoadDetails playerProfileLoadDetails = GameLoader.LoadProfiles().First<PlayerProfileLoadDetails>();
			GameWorld.instance.PlayerProfile = GameLoader.Load(playerProfileLoadDetails.Profile, playerProfileLoadDetails.FileName);
			base.GetComponentInChildren<LocalizationSession>(true).gameObject.SetActive(true);
		}
		PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
		playerProfile.ReceiveEvent(GameWorldEvent.GameSessionStarted, null);
		PlayerProfile playerProfile2 = playerProfile;
		playerProfile2.GameWorldEventTriggered = (Action<GameWorldEvent, object>)Delegate.Combine(playerProfile2.GameWorldEventTriggered, new Action<GameWorldEvent, object>(this.PlayerProfile_GameWorldEventTriggered));
		this.InitTown();
		playerProfile.ReceiveEvent(GameWorldEvent.GameSessionInitializationCompleted, null);
		if (!playerProfile.AdditionalData.ContainsBool(UIAdditionalDataKey.BattleTutorialTriggered))
		{
			playerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.BattleTutorialTriggered, !(playerProfile.StarRating == 1) || Math.Abs(playerProfile.GetDifficultyValue()) >= 1E-05);
		}
		if (playerProfile.StoredCandidates == null)
		{
			playerProfile.StoredCandidates = new List<ResidentCandidate>();
		}
		if (playerProfile.GetBattleTeams().Any((BattleTeam b) => b.Rules == null))
		{
			playerProfile.GetBattleTeams().ForEach(delegate(BattleTeam b)
			{
				b.Rules = new List<StrategyRule>();
			});
		}
		GC.Collect();
	}

	// Token: 0x060043A7 RID: 17319 RVA: 0x001B7728 File Offset: 0x001B5B28
	private void OnApplicationFocus(bool hasFocus)
	{
		bool additionalData = this.GetAdditionalData(UIAdditionalDataKey.MuteInBackground, false);
		if (additionalData && !hasFocus)
		{
			this.SetMainVolume(0f);
		}
		if (additionalData && hasFocus)
		{
			this.SetMainVolume(PlayerPrefs.GetFloat(PlayerPrefsAttribute.MainVolume));
		}
	}

	// Token: 0x060043A8 RID: 17320 RVA: 0x001B7775 File Offset: 0x001B5B75
	public void UploadSaveAsync()
	{
	}

	// Token: 0x060043A9 RID: 17321 RVA: 0x001B7777 File Offset: 0x001B5B77
	public void UploadSave()
	{
		if (SteamManager.Initialized && PlayerPrefs.GetInt(UIAdditionalDataKey.SteamCloud) == 1)
		{
			FileUploadController.Instance.UploadWhenReturnToMainMenu();
		}
	}

	// Token: 0x060043AA RID: 17322 RVA: 0x001B779D File Offset: 0x001B5B9D
	private void PresetPlayerPrefs()
	{
		if (!PlayerPrefs.HasKey(PlayerPrefsAttribute.MainVolume))
		{
			PlayerPrefs.SetFloat(PlayerPrefsAttribute.MainVolume, 0.5f);
			PlayerPrefs.SetFloat(PlayerPrefsAttribute.MusicVolume, 0.5f);
			PlayerPrefs.SetFloat(PlayerPrefsAttribute.EffectVolume, 0.5f);
		}
	}

	// Token: 0x060043AB RID: 17323 RVA: 0x001B77DC File Offset: 0x001B5BDC
	private void InitTown()
	{
		this.PresetPlayerPrefs();
		float @float = PlayerPrefs.GetFloat(PlayerPrefsAttribute.MainVolume);
		float float2 = PlayerPrefs.GetFloat(PlayerPrefsAttribute.MusicVolume);
		float float3 = PlayerPrefs.GetFloat(PlayerPrefsAttribute.EffectVolume);
		this.SetMainVolume(@float);
		this.SetMusicVolume(float2);
		this.SetEffectVolume(float3);
		this.Slots = UnityEngine.Object.FindObjectOfType<SlotsController>();
		TownAppearanceManager.Instance.UpdateSeasonMap(GameWorld.instance.PlayerProfile.CurrentSeason);
		TownAppearanceManager.Instance.WeatherChange(GameWorld.instance.PlayerProfile.CurrentWeather);
		this.VehiclePoints.UpdateShipsOnPoints();
		foreach (KeyValuePair<TownSlot, IBuildingProfile> keyValuePair in GameWorld.instance.PlayerProfile.Buildings)
		{
			this.PlaceBuilding(keyValuePair.Key, keyValuePair.Value);
		}
		foreach (KeyValuePair<ResourceType, ResourceProfileAntiCheat> keyValuePair2 in GameWorld.instance.PlayerProfile.ResourcesAt)
		{
			if (keyValuePair2.Key.GetResourceCategory().IsRawMaterial())
			{
				this.Ui.ResourceMenu.AddItem(new PageItem
				{
					Id = keyValuePair2.Key.ToString(),
					ResourceType = keyValuePair2.Key,
					Amount = keyValuePair2.Value.GetValue()
				});
			}
		}
		this.Ui.HeroMenu.UpdateHeroList(GameWorld.instance.PlayerProfile.AdventurerProfiles);
		this.Ui.HeroMenu.InventoryPanel.Init();
		this.Ui.QuestMenu.Init();
	}

	// Token: 0x060043AC RID: 17324 RVA: 0x001B79D8 File Offset: 0x001B5DD8
	public void PlaceBuilding(TownSlot slot, IBuildingProfile building)
	{
		if (building is ProductionBuildingProfile)
		{
			ProductionBuildingProfile productionBuildingProfile = building as ProductionBuildingProfile;
			ProductionBuildingController productionBuildingController = UnityEngine.Object.Instantiate<ProductionBuildingController>(Resources.Load<ProductionBuildingController>(FilePath.GetBuildingPrefab(productionBuildingProfile.BuildingType)));
			productionBuildingController.Init(productionBuildingProfile);
			this.Slots.PlaceBuilding(slot, productionBuildingController.gameObject);
		}
		if (building is RecruitmentFacility)
		{
			RecruitmentFacility recruitmentFacility = building as RecruitmentFacility;
			RecruitmentFacilityController recruitmentFacilityController = UnityEngine.Object.Instantiate<RecruitmentFacilityController>(Resources.Load<RecruitmentFacilityController>(FilePath.GetBuildingPrefab(recruitmentFacility.BuildingType)));
			recruitmentFacilityController.Init(slot, recruitmentFacility);
			this.Slots.PlaceBuilding(slot, recruitmentFacilityController.gameObject);
		}
		if (building is Shop)
		{
			Shop shop = building as Shop;
			ShopController shopController = UnityEngine.Object.Instantiate<ShopController>(Resources.Load<ShopController>(FilePath.GetBuildingPrefab(shop.BuildingType)));
			shopController.Init(shop);
			this.Slots.PlaceBuilding(slot, shopController.gameObject);
			this.UpdateShopItems(shop.GetCommodities());
		}
		if (building is School)
		{
			School school = building as School;
			SchoolBuildingController schoolBuildingController = UnityEngine.Object.Instantiate<SchoolBuildingController>(Resources.Load<SchoolBuildingController>(FilePath.GetBuildingPrefab(school.BuildingType)));
			schoolBuildingController.Init(school);
			this.Slots.PlaceBuilding(slot, schoolBuildingController.gameObject);
		}
		if (building is ForgingFacility)
		{
			ForgingFacility forgingFacility = building as ForgingFacility;
			FurnaceBuildingController furnaceBuildingController = UnityEngine.Object.Instantiate<FurnaceBuildingController>(Resources.Load<FurnaceBuildingController>(FilePath.GetBuildingPrefab(forgingFacility.BuildingType)));
			this.Slots.PlaceBuilding(slot, furnaceBuildingController.gameObject);
			this.Ui.FurnaceMenu.Init(forgingFacility);
		}
		if (building is Citytown)
		{
			Citytown citytown = building as Citytown;
			CityTownController cityTownController = UnityEngine.Object.Instantiate<CityTownController>(Resources.Load<CityTownController>(FilePath.GetBuildingPrefab(citytown.BuildingType)));
			this.Slots.PlaceBuilding(slot, cityTownController.gameObject);
		}
	}

	// Token: 0x060043AD RID: 17325 RVA: 0x001B7B94 File Offset: 0x001B5F94
	private void PlayerProfile_GameWorldEventTriggered(GameWorldEvent gameWorldEvent, object obj)
	{
		switch (gameWorldEvent)
		{
		case GameWorldEvent.NewQuestReceived:
			this.NewQuestReceived(obj as Quest);
			break;
		case GameWorldEvent.QuestCompleted:
			this.QuestCompleted(obj as QuestCompletedEvent);
			break;
		case GameWorldEvent.QuestPreCompletion:
			this.QuestPreCompleted(obj as Quest);
			break;
		case GameWorldEvent.QuestExpired:
			this.QuestExpired(obj as Quest);
			break;
		case GameWorldEvent.QuestCancelled:
			this.QuestCancelled(obj as Quest);
			break;
		case GameWorldEvent.AdventurerTypeUnloced:
			this.AdventurerTypeUnloced((UnitClass)Enum.Parse(typeof(UnitClass), obj.ToString()));
			break;
		case GameWorldEvent.ItemProduced:
			this.ItemProduced(obj as Product);
			break;
		case GameWorldEvent.ItemPutOnSale:
		{
			List<ItemStatusUpdateEvent> updateEvent = obj as List<ItemStatusUpdateEvent>;
			this.PlayerProfile_ItemOnSale(updateEvent);
			break;
		}
		case GameWorldEvent.ItemReserved:
		{
			ItemStatusUpdateEvent updateEvent2 = obj as ItemStatusUpdateEvent;
			this.PlayerProfile_ItemReserved(updateEvent2);
			break;
		}
		case GameWorldEvent.ItemEquipped:
			this.ItemEquipped(obj as ItemStatusUpdateEvent);
			break;
		case GameWorldEvent.AdventurerListUpdated:
			this.PlayerProfile_AdventurerListUpdate();
			break;
		case GameWorldEvent.RecruitmentListUpdated:
			this.RecruitmentListUpdated();
			break;
		case GameWorldEvent.ResidentContributed:
			this.ResidentContributed(obj as ResidentResourceContributeEvent);
			break;
		case GameWorldEvent.ResidentCandidateAdded:
			this.ResidentCandidateAdded(obj as List<ResidentCandidate>);
			break;
		case GameWorldEvent.BuildingTypeUnlocked:
			this.BuildingTypeUnlocked((BuildingType)Enum.Parse(typeof(BuildingType), obj.ToString()));
			break;
		case GameWorldEvent.BuildingConstructed:
			this.BuildingConstructed(obj);
			break;
		case GameWorldEvent.DungeonNewTypeUnlocked:
			this.DungeonNewTypeUnlocked(obj as DungeonRecord);
			break;
		case GameWorldEvent.WeatherChanged:
			this.WeatherChanged(obj);
			break;
		case GameWorldEvent.SeasonChanged:
			this.SeasonChanged(obj);
			break;
		case GameWorldEvent.ShopStockRefreshed:
			this.ShopStockRefresh(obj as ShopRefreshedEvent);
			break;
		case GameWorldEvent.PurchaseSuccessful:
			this.PurchaseSuccessful(obj as PurchaseSuccessEvent);
			break;
		case GameWorldEvent.AdventurerTriggersDialog:
			this.AdventurerTriggersDialog(obj as AdventurerSpeaksEvent);
			break;
		case GameWorldEvent.AdventureSnapUpdated:
			this.AdventureSnapUpdated(obj as AdventureSnapshot);
			break;
		case GameWorldEvent.NewSkillUnlocked:
			this.NewSkillUnlocked((SkillType)Enum.Parse(typeof(SkillType), obj.ToString()));
			break;
		case GameWorldEvent.ForgeUpgraded:
			this.ForgeUpgraded((int)obj);
			break;
		case GameWorldEvent.SchoolUpgraded:
			this.SchoolUpgraded((int)obj);
			break;
		case GameWorldEvent.ChestBlessBoosted:
			this.ChestBlessBoosted();
			break;
		case GameWorldEvent.TripEncounterCollected:
			this.TripEncounterCollected(obj as ITripeEncounter);
			break;
		case GameWorldEvent.BoatAdded:
			this.BoatAdded(obj as Vehicle);
			break;
		case GameWorldEvent.NewJourneyStarted:
			this.NewJourneyStarted(obj as TripRecord);
			break;
		case GameWorldEvent.JourneyCompleted:
			this.JourneyCompleted(obj as TripRecord);
			break;
		case GameWorldEvent.ShopPackOpenned:
			this.ShopPackOpenned(obj as List<ResourceUpdate>);
			break;
		case GameWorldEvent.TownEventCompleted:
			this.TownEventCompleted(obj as TownEventProcessorBase);
			break;
		case GameWorldEvent.TownEffectAdded:
			this.TownEffectAdded(obj as TownEffectAddedEvent);
			break;
		case GameWorldEvent.TownEffectRemoved:
			this.TownEffectRemoved(obj as TownEffectBase);
			break;
		case GameWorldEvent.TownEffectGenerated:
			this.TownEffectGenerated(obj as TownEffectAddedEvent);
			break;
		}
	}

	// Token: 0x060043AE RID: 17326 RVA: 0x001B80C0 File Offset: 0x001B64C0
	private void TownEventCompleted(TownEventProcessorBase eventBase)
	{
		string text = UIComponentType.TownEventCompleted.GetName().ReplaceToBuilder(UIComponentKey.Name, eventBase.GetDescription().Title.ToColor(ColorPicker.Yellow)).ToString();
		this.DisplyMovingNotification(new FlyingText
		{
			DisplyingText = text
		});
		this.AddLogTextOneLine(new LogText
		{
			Text = text
		});
	}

	// Token: 0x060043AF RID: 17327 RVA: 0x001B8124 File Offset: 0x001B6524
	private void TownEffectGenerated(TownEffectAddedEvent effect)
	{
		if (effect.Trigger is Resident)
		{
			Resident resident = effect.Trigger as Resident;
			this.ResidentManager.TriggerHappyResident(resident);
			string text = UIComponentType.TownEffectNewAddedTitle.GetName().ReplaceToBuilder(UIComponentKey.SkillName, ColorPicker.GetHaxString(ColorPicker.Yellow, effect.Effect.GetDescription().Title)).ToString().ReplaceToBuilder(UIComponentKey.Name, ColorPicker.GetHaxString(ColorPicker.GetGradeColor(resident.Grade, false), resident.Type.GetDescription().Title)).ToString();
			this.AddLogTextOneLine(new LogText
			{
				Text = text
			});
			this.DisplyMovingNotification(new FlyingText
			{
				DisplyingText = text
			});
		}
		if (effect.Trigger is TownEventProcessorBase)
		{
			TownEventProcessorBase townEventProcessorBase = effect.Trigger as TownEventProcessorBase;
			string text2 = UIComponentType.TownEventContributedEffect.GetName().ReplaceToBuilder(UIComponentKey.SkillName, ColorPicker.GetHaxString(ColorPicker.Yellow, effect.Effect.GetDescription().Title)).ToString().ReplaceToBuilder(UIComponentKey.Name, townEventProcessorBase.GetDescription().Title.ToColor(ColorPicker.PositiveGreen)).ToString();
			this.AddLogTextOneLine(new LogText
			{
				Text = text2
			});
			this.DisplyMovingNotification(new FlyingText
			{
				DisplyingText = text2
			});
		}
	}

	// Token: 0x060043B0 RID: 17328 RVA: 0x001B8286 File Offset: 0x001B6686
	private void TownEffectAdded(TownEffectAddedEvent effect)
	{
		this.Ui.TownEffectPanel.TownEffectAdded(effect.Effect);
	}

	// Token: 0x060043B1 RID: 17329 RVA: 0x001B82A0 File Offset: 0x001B66A0
	private void TownEffectRemoved(TownEffectBase effect)
	{
		this.Ui.TownEffectPanel.TownEffectRemoved(effect);
		this.AddLogTextOneLine(new LogText
		{
			Text = UIComponentType.TownEffectExpiredTitle.GetName().ReplaceToBuilder(UIComponentKey.SkillName, ColorPicker.GetHaxString(ColorPicker.NagetiveRed, effect.GetDescription().Title)).ToString()
		});
	}

	// Token: 0x060043B2 RID: 17330 RVA: 0x001B82FF File Offset: 0x001B66FF
	private void ShopPackOpenned(List<ResourceUpdate> resources)
	{
		this.Ui.MyShopMenu.OpenedPack(resources);
	}

	// Token: 0x060043B3 RID: 17331 RVA: 0x001B8314 File Offset: 0x001B6714
	private void ItemProduced(Product product)
	{
		foreach (Item item in product.RelatedItems)
		{
			if (this.Ui.HeroMenu.gameObject.activeSelf)
			{
				this.Ui.HeroMenu.InventoryPanel.AddItemToStorage(item);
			}
			ResourceCategory resourceCategory = item.Type.GetResourceCategory();
			if (GameWorld.instance.PlayerProfile.BuildingHasBeenBuilt(BuildingType.ForgingFacility) && (resourceCategory.IsWeapon() || resourceCategory.IsArmor() || resourceCategory == ResourceCategory.Gem) && this.Ui.FurnaceMenu.gameObject.activeSelf)
			{
				this.Ui.FurnaceMenu.AddItemToFurnace(item);
			}
		}
	}

	// Token: 0x060043B4 RID: 17332 RVA: 0x001B8404 File Offset: 0x001B6804
	private void JourneyCompleted(TripRecord record)
	{
		if (this.Ui.ShipMenu.gameObject.activeSelf)
		{
			this.Ui.ShipMenu.CompleteTrip(record);
		}
		this.VehiclePoints.UpdateShipsOnPoints();
		this.Ui.ShipMenu.TryAutoExplore(record);
	}

	// Token: 0x060043B5 RID: 17333 RVA: 0x001B8458 File Offset: 0x001B6858
	private void NewJourneyStarted(TripRecord trip)
	{
		if (this.Ui.ShipMenu.gameObject.activeSelf)
		{
			this.Ui.ShipMenu.AddStartLog();
		}
		this.VehiclePoints.PlaceStartJourneyShip(trip.Vehicle);
	}

	// Token: 0x060043B6 RID: 17334 RVA: 0x001B8495 File Offset: 0x001B6895
	private void TripEncounterCollected(ITripeEncounter encounter)
	{
		if (this.Ui.ShipMenu.gameObject.activeSelf)
		{
			this.Ui.ShipMenu.AddLog(encounter);
		}
	}

	// Token: 0x060043B7 RID: 17335 RVA: 0x001B84C2 File Offset: 0x001B68C2
	private void BoatAdded(Vehicle vehicle)
	{
		this.VehiclePoints.UpdateShipsOnPoints();
	}

	// Token: 0x060043B8 RID: 17336 RVA: 0x001B84D0 File Offset: 0x001B68D0
	private void DungeonNewTypeUnlocked(DungeonRecord record)
	{
		this.DisplyMovingNotification(new FlyingText
		{
			DisplyingText = UIComponentType.DungeonNewTypeUnlock.GetName().ReplaceToBuilder(UIComponentKey.DungeonTitle, ColorPicker.GetHaxString(ColorPicker.Yellow, record.AdventureType.GetDescription().Title)).ToString()
		});
	}

	// Token: 0x060043B9 RID: 17337 RVA: 0x001B8524 File Offset: 0x001B6924
	private void ChestBlessBoosted()
	{
		this.DisplyMovingNotification(new FlyingText
		{
			DisplyingText = UIComponentType.ChestBlessBoostedNotificatoinText.GetName(),
			Textcolor = ColorPicker.PositiveGreen
		});
	}

	// Token: 0x060043BA RID: 17338 RVA: 0x001B855C File Offset: 0x001B695C
	private void AdventurerTypeUnloced(UnitClass unit)
	{
		this.DisplyMovingNotification(new FlyingText
		{
			DisplyingText = UIComponentType.NotificatoinUnlockNewUnitClass.GetName().ReplaceToBuilder(UIComponentKey.UnitClass, ColorPicker.GetHaxString(ColorPicker.Yellow, unit.GetDescription().Title)).ToString(),
			Textcolor = ColorPicker.PositiveGreen
		});
	}

	// Token: 0x060043BB RID: 17339 RVA: 0x001B85B8 File Offset: 0x001B69B8
	private void ForgeUpgraded(int level)
	{
		this.Ui.FurnaceMenu.LevelPanel.UpdateLevel(level);
		this.DisplyMovingNotification(new FlyingText
		{
			DisplyingText = UIComponentType.FurnaceUpgradeToLevelText.GetName().ReplaceToBuilder(UIComponentKey.Level, level.ToLevelText()).ToString(),
			Textcolor = ColorPicker.PositiveGreen
		});
	}

	// Token: 0x060043BC RID: 17340 RVA: 0x001B8618 File Offset: 0x001B6A18
	private void SchoolUpgraded(int level)
	{
		this.Ui.SchoolMenu.LevelPanel.UpdateLevel(level);
		this.DisplyMovingNotification(new FlyingText
		{
			DisplyingText = UIComponentType.SchoolUpgradeToLevelText.GetName().ReplaceToBuilder(UIComponentKey.Level, level.ToLevelText()).ToString(),
			Textcolor = ColorPicker.PositiveGreen
		});
	}

	// Token: 0x060043BD RID: 17341 RVA: 0x001B8678 File Offset: 0x001B6A78
	private void BuildingTypeUnlocked(BuildingType buildingType)
	{
	}

	// Token: 0x060043BE RID: 17342 RVA: 0x001B867C File Offset: 0x001B6A7C
	private void NewSkillUnlocked(SkillType skillType)
	{
		this.DisplyMovingNotification(new FlyingText
		{
			DisplyingText = UIComponentType.NotificationNewSkillUnlock.GetName().ReplaceToBuilder(UIComponentKey.SkillName, ColorPicker.GetHaxString(ColorPicker.PositiveGreen, skillType.GetDescription().Title)).ToString(),
			Textcolor = ColorPicker.Yellow
		});
		SchoolBuildingController componentInChildren = this.Slots.GetComponentInChildren<SchoolBuildingController>();
		if (componentInChildren != null)
		{
			componentInChildren.ShowWidget(skillType);
		}
	}

	// Token: 0x060043BF RID: 17343 RVA: 0x001B86F4 File Offset: 0x001B6AF4
	private void ResidentCandidateAdded(List<ResidentCandidate> candidates)
	{
		this.AddLogTextOneLine(new LogText
		{
			Text = UIComponentType.ResidentCandidateRefreshed.GetName()
		});
		this.Ui.ResidentMenu.UpdateCandidateList();
		CityTownController componentInChildren = this.Slots.GetComponentInChildren<CityTownController>();
		if (!this.Ui.ResidentMenu.gameObject.activeSelf)
		{
			componentInChildren.ShowNewResidentIcon(candidates);
		}
		foreach (ResidentCandidate residentCandidate in candidates)
		{
			Resident candidate = residentCandidate.Candidate;
			if (candidate.Grade == QualityGrade.Legendary || candidate.Grade == QualityGrade.Ancient)
			{
				this.DisplyMovingNotification(new FlyingText
				{
					DisplyingText = UIComponentType.NotificationHighClassResidentVisits.GetName().ReplaceToBuilder(UIComponentKey.Grade, ColorPicker.GetHaxString(ColorPicker.GetGradeColor(candidate.Grade, false), candidate.Grade.GetDescription().Title)).ToString()
				});
				componentInChildren.PlayGoodResidentClip();
			}
		}
		bool flag = false;
		if (candidates.Any((ResidentCandidate c) => c.Candidate.Grade == QualityGrade.Legendary) && this.GetAdditionalData(UIAdditionalDataKey.StoreLegendaryResident, false))
		{
			GameWorld.instance.PlayerProfile.StoreCandidate(candidates);
			if (!this.Ui.ResidentMenu.gameObject.activeSelf || (this.Ui.ResidentMenu.gameObject.activeSelf && !this.Ui.ResidentMenu.SavedCandidatePanel.gameObject.activeSelf))
			{
				this.Ui.ResidentMenu.SavedCandidateDot.SetActive(true);
			}
			this.Ui.ResidentMenu.UpdateCandidateList();
			this.Ui.ResidentMenu.SavedCandidatePanel.Init();
			flag = true;
		}
		if (!flag)
		{
			if (candidates.Any((ResidentCandidate c) => c.Candidate.Grade == QualityGrade.Ancient) && this.GetAdditionalData(UIAdditionalDataKey.StoreAncientResident, false))
			{
				GameWorld.instance.PlayerProfile.StoreCandidate(candidates);
				if (!this.Ui.ResidentMenu.gameObject.activeSelf || (this.Ui.ResidentMenu.gameObject.activeSelf && !this.Ui.ResidentMenu.SavedCandidatePanel.gameObject.activeSelf))
				{
					this.Ui.ResidentMenu.SavedCandidateDot.SetActive(true);
				}
				this.Ui.ResidentMenu.UpdateCandidateList();
				this.Ui.ResidentMenu.SavedCandidatePanel.Init();
			}
		}
	}

	// Token: 0x060043C0 RID: 17344 RVA: 0x001B89D4 File Offset: 0x001B6DD4
	private void RecruitmentListUpdated()
	{
		this.AddLogTextOneLine(new LogText
		{
			Text = UIComponentType.RecruitmentRefreshed.GetName()
		});
	}

	// Token: 0x060043C1 RID: 17345 RVA: 0x001B8A00 File Offset: 0x001B6E00
	private void ResidentContributed(ResidentResourceContributeEvent contributeEvent)
	{
		if (contributeEvent.Contributor == null)
		{
			List<ResourceUpdate> resourceUpdates = contributeEvent.ResourceUpdates;
			string name = UIComponentType.ResidentContributedText.GetName();
			string text = name;
			LogTexts logTexts = new LogTexts
			{
				Texts = new List<LogText>
				{
					new LogText
					{
						Text = name
					}
				}
			};
			foreach (ResourceUpdate resourceUpdate in resourceUpdates)
			{
				List<Item> relatedItems = resourceUpdate.RelatedItems;
				bool flag = relatedItems.Count > 0;
				NormalItem relatedObject = new NormalItem
				{
					Id = resourceUpdate.ResourceType.ToString(),
					Amount = resourceUpdate.ChangeAmount,
					Description = resourceUpdate.ResourceType.GetDescription().Details1,
					ItemGrade = QualityGrade.Normal,
					ResourceType = resourceUpdate.ResourceType
				};
				if (flag)
				{
					relatedObject = relatedItems[0].ConvertToUiNormalItem();
				}
				logTexts.Texts.Add(new LogText
				{
					Text = "[" + resourceUpdate.ResourceType.GetDescription().Title + "]",
					TextType = LogTextType.Item,
					RelatedObject = relatedObject
				});
				text = text + "[" + ColorPicker.GetHaxString(ColorPicker.Yellow, resourceUpdate.ResourceType.GetDescription().Title) + "] ";
			}
			this.DisplyMovingNotification(new FlyingText
			{
				DisplyingText = text
			});
			this.AddLogText(logTexts);
		}
	}

	// Token: 0x060043C2 RID: 17346 RVA: 0x001B8BD8 File Offset: 0x001B6FD8
	private void AdventureSnapUpdated(AdventureSnapshot snapShot)
	{
		if (snapShot.Status != AdventureStatus.Walking)
		{
			this.Ui.PreviewBar.UpdateBar(snapShot);
			this.Ui.PreviewBar.gameObject.SetActive(true);
		}
	}

	// Token: 0x060043C3 RID: 17347 RVA: 0x001B8C10 File Offset: 0x001B7010
	private void QuestCancelled(Quest quest)
	{
		this.DisplyMovingNotification(new FlyingText
		{
			DisplyingText = UIComponentType.TownManagerQuestCanceled.GetName().ReplaceToBuilder(UIComponentKey.QuestTitle, quest.GetDescription().Title).ToString()
		});
		this.UpdateQuestList();
	}

	// Token: 0x060043C4 RID: 17348 RVA: 0x001B8C5C File Offset: 0x001B705C
	private void QuestExpired(Quest quest)
	{
		string text = UIComponentType.TownManagerQuestExpired.GetName().ReplaceToBuilder(UIComponentKey.QuestTitle, ColorPicker.GetHaxString(Color.yellow, quest.GetDescription().Title)).ToString();
		this.DisplayWarningText(text);
		this.AddLogTextOneLine(new LogText
		{
			Text = text
		});
		this.UpdateQuestList();
	}

	// Token: 0x060043C5 RID: 17349 RVA: 0x001B8CBC File Offset: 0x001B70BC
	private void QuestPreCompleted(Quest quest)
	{
		string text = UIComponentType.TownManagerQuestCompleted.GetName().ReplaceToBuilder(UIComponentKey.QuestTitle, ColorPicker.GetHaxString(Color.yellow, quest.GetDescription().Title)).ToString();
		this.DisplyMovingNotification(new FlyingText
		{
			DisplyingText = text,
			Textcolor = ColorPicker.PositiveGreen,
			LinkText = UIComponentType.RewardClaimText.GetName(),
			RelatedObj = quest
		});
		List<LogText> texts = new List<LogText>
		{
			new LogText
			{
				Text = text
			},
			new LogText
			{
				Text = UIComponentType.RewardClaimText.GetName(),
				TextColor = ColorPicker.PositiveGreen,
				TextType = LogTextType.CompleteQuest,
				RelatedObject = quest
			}
		};
		this.AddLogText(new LogTexts
		{
			Texts = texts
		});
		this.UpdateQuestList();
		this.Ui.QuestMenu.QuestInfo.UpdateSelectedQuest();
	}

	// Token: 0x060043C6 RID: 17350 RVA: 0x001B8DBB File Offset: 0x001B71BB
	private void QuestCompleted(QuestCompletedEvent quest)
	{
		this.Ui.QuestMenu.Completed(quest);
		LogPanelController.Instance.CompleteQuestTextUpdate(quest.Quest);
		if (quest.Quest.QuestIdentifier == QuestIdentifier.Side_8_p2)
		{
			this.Ui.ShowGameEndingPanel();
		}
	}

	// Token: 0x060043C7 RID: 17351 RVA: 0x001B8DFC File Offset: 0x001B71FC
	private void NewQuestReceived(Quest quest)
	{
		quest.IsNew = true;
		if (quest.QuestIdentifier == QuestIdentifier.Side_7)
		{
			this.Ui.QuestMenu.PlayImportantQuestClip();
		}
		this.UpdateQuestList();
		string text = UIComponentType.TownManagerNewQuest.GetName().ReplaceToBuilder(UIComponentKey.QuestTitle, ColorPicker.GetHaxString(Color.yellow, quest.GetDescription().Title)).ToString();
		this.DisplyMovingNotification(new FlyingText
		{
			DisplyingText = text
		});
		LogTexts texts = text.SplitLogText(LogTextType.NewQuest, new PageQuest
		{
			Id = quest.Id,
			Quest = quest
		});
		this.AddLogText(texts);
	}

	// Token: 0x060043C8 RID: 17352 RVA: 0x001B8E9F File Offset: 0x001B729F
	private void UpdateQuestList()
	{
		this.Ui.QuestMenu.UpdateQuestList();
	}

	// Token: 0x060043C9 RID: 17353 RVA: 0x001B8EB4 File Offset: 0x001B72B4
	private void WeatherChanged(object obj)
	{
		WeatherUpdateEvent weatherUpdateEvent = obj as WeatherUpdateEvent;
		TownAppearanceManager.Instance.WeatherChange(weatherUpdateEvent.NewWeather);
	}

	// Token: 0x060043CA RID: 17354 RVA: 0x001B8ED8 File Offset: 0x001B72D8
	private void SeasonChanged(object obj)
	{
		SeasonUpdateEvent seasonUpdateEvent = obj as SeasonUpdateEvent;
		base.StartCoroutine(TownAppearanceManager.Instance.SeasonChange(seasonUpdateEvent.CurrentSeason));
	}

	// Token: 0x060043CB RID: 17355 RVA: 0x001B8F04 File Offset: 0x001B7304
	public void AdventurerTriggersDialog(AdventurerSpeaksEvent speaksEvent)
	{
		if (speaksEvent.AdventureSpeaksContents.Count == 0 || speaksEvent.AdventureSpeaksContents[0].DialogDetailses.Count == 0)
		{
			throw new Exception("出错啦");
		}
		if (speaksEvent.AdventureSpeaksContents[0].DialogDetailses[0].IsCriticalDialog)
		{
			this.CreatePanelDialogs((from s in speaksEvent.AdventureSpeaksContents
			select new DialogItem
			{
				Dialogs = s.DialogDetailses.GetContents(),
				OnLeftSide = true,
				UnitType = s.AdventurerUnitType
			}).ToList<DialogItem>());
		}
		else
		{
			this.Ui.AddNewAdventurerDialog(speaksEvent);
		}
	}

	// Token: 0x060043CC RID: 17356 RVA: 0x001B8FAC File Offset: 0x001B73AC
	public void CreatePanelDialogs(List<DialogItem> items)
	{
		this.Ui.CriticalAdvneAdventurerDialog.gameObject.SetActive(true);
		this.Ui.CriticalAdvneAdventurerDialog.Init(items);
	}

	// Token: 0x060043CD RID: 17357 RVA: 0x001B8FD5 File Offset: 0x001B73D5
	public void CreateAdventureStory(string dialog)
	{
		this.Ui.AdventureStory.Init(dialog);
		this.Ui.AdventureStory.gameObject.SetActive(true);
	}

	// Token: 0x060043CE RID: 17358 RVA: 0x001B9000 File Offset: 0x001B7400
	public void ShopStockRefresh(ShopRefreshedEvent shop)
	{
		this.UpdateShopItems(shop.Shop.GetCommodities());
		this.Slots.GetComponentInChildren<ShopController>().ShowWidget();
		this.AddLogTextOneLine(new LogText
		{
			Text = UIComponentType.ShopRefreshed.GetName()
		});
	}

	// Token: 0x060043CF RID: 17359 RVA: 0x001B904B File Offset: 0x001B744B
	public void PurchaseSuccessful(PurchaseSuccessEvent successEvent)
	{
		this.UpdateShopItems(successEvent.Shop.GetCommodities());
	}

	// Token: 0x060043D0 RID: 17360 RVA: 0x001B905E File Offset: 0x001B745E
	public void UpdateShopItems(List<Commodity> commodities)
	{
		this.Ui.MyShopMenu.UpdateItems(commodities);
	}

	// Token: 0x060043D1 RID: 17361 RVA: 0x001B9074 File Offset: 0x001B7474
	public void BuildingConstructed(object obj)
	{
		BuildingBuiltEvent buildingBuiltEvent = obj as BuildingBuiltEvent;
		if (buildingBuiltEvent != null)
		{
			this.PlaceBuilding(buildingBuiltEvent.TownSlot, buildingBuiltEvent.Building);
			this.DisplyMovingNotification(new FlyingText
			{
				DisplyingText = UIComponentType.BuildingConstructedNotify.GetName().ReplaceToBuilder(UIComponentKey.Name, ColorPicker.GetHaxString(ColorPicker.Yellow, buildingBuiltEvent.Building.BuildingType.GetDescription().Title)).ToString(),
				Textcolor = Color.white
			});
		}
	}

	// Token: 0x060043D2 RID: 17362 RVA: 0x001B90F6 File Offset: 0x001B74F6
	private void PlayerProfile_AdventurerListUpdate()
	{
		this.Ui.HeroMenu.UpdateHeroList(GameWorld.instance.PlayerProfile.AdventurerProfiles);
	}

	// Token: 0x060043D3 RID: 17363 RVA: 0x001B9117 File Offset: 0x001B7517
	public void PlayerProfile_ItemOnSale(List<ItemStatusUpdateEvent> updateEvent)
	{
	}

	// Token: 0x060043D4 RID: 17364 RVA: 0x001B9119 File Offset: 0x001B7519
	public void PlayerProfile_ItemReserved(ItemStatusUpdateEvent updateEvent)
	{
		this.Ui.HeroMenu.InventoryPanel.AddItemToStorage(updateEvent.Item);
	}

	// Token: 0x060043D5 RID: 17365 RVA: 0x001B9138 File Offset: 0x001B7538
	public void ItemEquipped(ItemStatusUpdateEvent updateEvent)
	{
		this.Ui.HeroMenu.InventoryPanel.UpdateHeroEquipments();
		this.Ui.HeroMenu.InventoryPanel.RemoveItemFromStorage(updateEvent.Item);
		if (GameWorld.instance.PlayerProfile.BuildingHasBeenBuilt(BuildingType.ForgingFacility))
		{
			this.Ui.FurnaceMenu.RemoveItemFromStorage(updateEvent.Item);
		}
	}

	// Token: 0x060043D6 RID: 17366 RVA: 0x001B91A1 File Offset: 0x001B75A1
	public Item GetWeapon(AdventurerProfile adventurer)
	{
		return adventurer.GetEquipments().FirstOrDefault((Item e) => e.SlotType == ItemType.Weapon);
	}

	// Token: 0x060043D7 RID: 17367 RVA: 0x001B91CB File Offset: 0x001B75CB
	[CompilerGenerated]
	private static bool <Awake>m__0(BattleTeam b)
	{
		return b.Rules == null;
	}

	// Token: 0x060043D8 RID: 17368 RVA: 0x001B91D6 File Offset: 0x001B75D6
	[CompilerGenerated]
	private static void <Awake>m__1(BattleTeam b)
	{
		b.Rules = new List<StrategyRule>();
	}

	// Token: 0x060043D9 RID: 17369 RVA: 0x001B91E3 File Offset: 0x001B75E3
	[CompilerGenerated]
	private static bool <ResidentCandidateAdded>m__2(ResidentCandidate c)
	{
		return c.Candidate.Grade == QualityGrade.Legendary;
	}

	// Token: 0x060043DA RID: 17370 RVA: 0x001B91F3 File Offset: 0x001B75F3
	[CompilerGenerated]
	private static bool <ResidentCandidateAdded>m__3(ResidentCandidate c)
	{
		return c.Candidate.Grade == QualityGrade.Ancient;
	}

	// Token: 0x060043DB RID: 17371 RVA: 0x001B9204 File Offset: 0x001B7604
	[CompilerGenerated]
	private static DialogItem <AdventurerTriggersDialog>m__4(AdventureSpeaksContent s)
	{
		return new DialogItem
		{
			Dialogs = s.DialogDetailses.GetContents(),
			OnLeftSide = true,
			UnitType = s.AdventurerUnitType
		};
	}

	// Token: 0x060043DC RID: 17372 RVA: 0x001B923C File Offset: 0x001B763C
	[CompilerGenerated]
	private static bool <GetWeapon>m__5(Item e)
	{
		return e.SlotType == ItemType.Weapon;
	}

	// Token: 0x04003338 RID: 13112
	public static TownManager Instance;

	// Token: 0x04003339 RID: 13113
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SlotsController <Slots>k__BackingField;

	// Token: 0x0400333A RID: 13114
	public VehiclePointsController VehiclePoints;

	// Token: 0x0400333B RID: 13115
	public ResidentManager ResidentManager;

	// Token: 0x0400333C RID: 13116
	public UIController Ui;

	// Token: 0x0400333D RID: 13117
	public IBuildingProfile SelectedBuilding;

	// Token: 0x0400333E RID: 13118
	[CompilerGenerated]
	private static Func<BattleTeam, bool> <>f__am$cache0;

	// Token: 0x0400333F RID: 13119
	[CompilerGenerated]
	private static Action<BattleTeam> <>f__am$cache1;

	// Token: 0x04003340 RID: 13120
	[CompilerGenerated]
	private static Func<ResidentCandidate, bool> <>f__am$cache2;

	// Token: 0x04003341 RID: 13121
	[CompilerGenerated]
	private static Func<ResidentCandidate, bool> <>f__am$cache3;

	// Token: 0x04003342 RID: 13122
	[CompilerGenerated]
	private static Func<AdventureSpeaksContent, DialogItem> <>f__am$cache4;

	// Token: 0x04003343 RID: 13123
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache5;
}
