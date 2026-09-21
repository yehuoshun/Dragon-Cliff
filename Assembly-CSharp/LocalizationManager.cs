using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x020009F7 RID: 2551
public class LocalizationManager
{
	// Token: 0x06004532 RID: 17714 RVA: 0x001BEF48 File Offset: 0x001BD348
	public LocalizationManager()
	{
	}

	// Token: 0x06004533 RID: 17715 RVA: 0x001BEF50 File Offset: 0x001BD350
	public void LoadLocalizedText(string fileName)
	{
		this.localizedSkills = new Dictionary<SkillType, SkillLocalization>();
		this.localizedBattleEffects = new Dictionary<BattleEffectType, EffectLocalization>();
		this.localizedItems = new Dictionary<ResourceType, ResourceLocalization>();
		this.localizedItemCategories = new Dictionary<ResourceCategory, ItemCategoryLocalization>();
		this.localizedUnits = new Dictionary<UnitClass, UnitLocalization>();
		this.localizedBuilding = new Dictionary<BuildingType, BuildingLocalization>();
		this.localizedAdventures = new Dictionary<AdventureType, AdventureLocalization>();
		this.localizedQuestRequirements = new Dictionary<QuestRequirementType, QuestRequirementLocalization>();
		this.localizedQuest = new Dictionary<QuestIdentifier, QuestLocalization>();
		this.localizedStories = new Dictionary<StoryIdentifier, StoryDetails>();
		this.localizedDialogs = new Dictionary<DialogIdentifier, DialogDetails>();
		this.localizedUiComponents = new Dictionary<UIComponentType, UILocalization>();
		this.localizedAttributes = new Dictionary<AttributeType, AttributeLocalization>();
		this.localizedResidents = new Dictionary<ResidentType, ResidentLocalization>();
		this.localizedSpecialEffects = new Dictionary<SpecialEffectType, SpecialEffectLocalization>();
		this.localizedGrowthConditions = new Dictionary<GrowthConditionType, GrowthSpecialEffectConditionLocalization>();
		this.localizedItemGrades = new Dictionary<QualityGrade, ItemGradeLocalization>();
		this.localizedRewardTypes = new Dictionary<RewardType, RewardTypeLocalization>();
		this.localizedQuestchainIdentifiers = new Dictionary<QuestChainIdentifier, QuestChainLocalization>();
		this.localizedUnitCategories = new Dictionary<ClassCategory, UnitCategoryLocalization>();
		this.localizedBattleEvents = new Dictionary<AdventureEventType, BattleEventLocalization>();
		this.localizedOutputs = new Dictionary<OutputType, OutputTypeLocalization>();
		this.localizedBoostTypes = new Dictionary<BoostType, BoostTypeLocalization>();
		this.localizedTargetCandidateTypes = new Dictionary<TargetCandidateType, TargetCandidateTypeLocalization>();
		this.localizedTownTitles = new Dictionary<TownTitleType, TownTitleLocalization>();
		this.localizedMonsterSlots = new Dictionary<AdventureEncounterSlotType, MonsterSlotLocalization>();
		this.localizedAttributeModificationTypes = new Dictionary<ModificationType, AttributeModificationTypeLocalization>();
		this.localizedSocketTypes = new Dictionary<SocketType, SocketTypeLocalization>();
		this.localizedResidentEffects = new Dictionary<ResidentEffectType, ResidentEffectLocalization>();
		this.localizedCardUpgrades = new Dictionary<UpgradeCardType, UpgradeCardLocalization>();
		this.localizedBattleOptions = new Dictionary<BattleOptionType, BattleOptionLocalization>();
		this.localizedVehicles = new Dictionary<VehicleType, VehicleLocalization>();
		this.localizedJourneyContribution = new Dictionary<JourneyContributeType, JourneyContributionLocalization>();
		this.localizedVehicleAttributes = new Dictionary<VehicleAttributeType, VehicleAttributeLocalization>();
		this.localizedTripEncounters = new Dictionary<TripEncounterType, TripEncounterLocalization>();
		this.localizedTripOutcomes = new Dictionary<TripEncounterOutcomeType, TripOutcomeLocalization>();
		this.localizedDestinations = new Dictionary<DestinationType, DestinationLocalization>();
		this.localizedUnitStyles = new Dictionary<UnitClassStyle, UnitStyleLocalization>();
		this.localizedManualTypes = new Dictionary<ManualType, ManualLocalization>();
		this.localizedTalents = new Dictionary<AdventurerTalentType, TalentLocalization>();
		this.localizedTownEffects = new Dictionary<TownEffectType, TownEffectLocalization>();
		this.localizedTownEvents = new Dictionary<TownEventType, TownEventLocalizaiton>();
		this.localizedCandidateOrderMetrics = new Dictionary<CandidateOrderringMetric, CandidateOrderMetricLocalization>();
		this.localizedOrderTypes = new Dictionary<OrderingType, OrderTypeLocalization>();
		string path = Path.Combine(Application.streamingAssetsPath, fileName);
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
			LocalizationData localizationData = JsonUtility.FromJson<LocalizationData>(json);
			foreach (SkillLocalization skillLocalization in localizationData.SkillDescriptions)
			{
				this.localizedSkills.Add(skillLocalization.SkillType, skillLocalization);
			}
			foreach (EffectLocalization effectLocalization in localizationData.EffectDescriptions)
			{
				this.localizedBattleEffects.Add(effectLocalization.BattleEffectType, effectLocalization);
			}
			foreach (ResourceLocalization resourceLocalization in localizationData.ItemDescriptions)
			{
				this.localizedItems.Add(resourceLocalization.ItemType, resourceLocalization);
			}
			foreach (ItemCategoryLocalization itemCategoryLocalization in localizationData.ResourceCategoryDescriptions)
			{
				this.localizedItemCategories.Add(itemCategoryLocalization.ResourceCategory, itemCategoryLocalization);
			}
			foreach (UnitLocalization unitLocalization in localizationData.UnitDescriptions)
			{
				this.localizedUnits.Add(unitLocalization.UnitClass, unitLocalization);
			}
			foreach (BuildingLocalization buildingLocalization in localizationData.BuildingDescriptions)
			{
				this.localizedBuilding.Add(buildingLocalization.BuildingType, buildingLocalization);
			}
			foreach (AdventureLocalization adventureLocalization in localizationData.AdventureDescriptions)
			{
				this.localizedAdventures.Add(adventureLocalization.AdventureType, adventureLocalization);
			}
			foreach (QuestRequirementLocalization questRequirementLocalization in localizationData.QuestRequirementDescriptions)
			{
				this.localizedQuestRequirements.Add(questRequirementLocalization.QuestRequirementType, questRequirementLocalization);
			}
			foreach (QuestLocalization questLocalization in localizationData.QuestDescriptions)
			{
				this.localizedQuest.Add(questLocalization.QuestIdentifier, questLocalization);
			}
			foreach (DialogDetails dialogDetails in localizationData.DialogDetails)
			{
				this.localizedDialogs.Add(dialogDetails.Identifier, dialogDetails);
			}
			foreach (StoryDetails storyDetails in localizationData.StoryDetailses)
			{
				this.localizedStories.Add(storyDetails.Identifier, storyDetails);
			}
			foreach (UILocalization uilocalization in localizationData.UiLocalizations)
			{
				this.localizedUiComponents.Add(uilocalization.UiComponentType, uilocalization);
			}
			foreach (ManualLocalization manualLocalization in localizationData.ManualLocalizations)
			{
				this.localizedManualTypes.Add(manualLocalization.ManualType, manualLocalization);
			}
			foreach (AttributeLocalization attributeLocalization in localizationData.AttributeLocalizations)
			{
				this.localizedAttributes.Add(attributeLocalization.AttributeType, attributeLocalization);
			}
			foreach (ResidentLocalization residentLocalization in localizationData.ResidentLocalizations)
			{
				this.localizedResidents.Add(residentLocalization.ResidentType, residentLocalization);
			}
			foreach (SpecialEffectLocalization specialEffectLocalization in localizationData.SpecialEffectLocalizations)
			{
				this.localizedSpecialEffects.Add(specialEffectLocalization.SpecialEffectType, specialEffectLocalization);
			}
			foreach (GrowthSpecialEffectConditionLocalization growthSpecialEffectConditionLocalization in localizationData.GrowthConditionLocalizations)
			{
				this.localizedGrowthConditions.Add(growthSpecialEffectConditionLocalization.ConditionType, growthSpecialEffectConditionLocalization);
			}
			foreach (ItemGradeLocalization itemGradeLocalization in localizationData.ItemGradeLocalizations)
			{
				this.localizedItemGrades.Add(itemGradeLocalization.Grade, itemGradeLocalization);
			}
			foreach (UnitCategoryLocalization unitCategoryLocalization in localizationData.UnitCategoryLocalizations)
			{
				this.localizedUnitCategories.Add(unitCategoryLocalization.ClassCategoryIdentifier, unitCategoryLocalization);
			}
			foreach (BattleEventLocalization battleEventLocalization in localizationData.BattleEventLocalizations)
			{
				this.localizedBattleEvents.Add(battleEventLocalization.EventType, battleEventLocalization);
			}
			foreach (OutputTypeLocalization outputTypeLocalization in localizationData.OutputLocalizations)
			{
				this.localizedOutputs.Add(outputTypeLocalization.OutputType, outputTypeLocalization);
			}
			foreach (BoostTypeLocalization boostTypeLocalization in localizationData.BoostTypeLocalizations)
			{
				this.localizedBoostTypes.Add(boostTypeLocalization.BoostType, boostTypeLocalization);
			}
			foreach (TargetCandidateTypeLocalization targetCandidateTypeLocalization in localizationData.TargetCandidateTypeLocalizations)
			{
				this.localizedTargetCandidateTypes.Add(targetCandidateTypeLocalization.TargetCandidateType, targetCandidateTypeLocalization);
			}
			foreach (TownTitleLocalization townTitleLocalization in localizationData.TownTitleLocalizations)
			{
				this.localizedTownTitles.Add(townTitleLocalization.TownTitleType, townTitleLocalization);
			}
			foreach (MonsterSlotLocalization monsterSlotLocalization in localizationData.MonsterSlotLocalizations)
			{
				this.localizedMonsterSlots.Add(monsterSlotLocalization.SlotType, monsterSlotLocalization);
			}
			foreach (RewardTypeLocalization rewardTypeLocalization in localizationData.RewardTypeLocalizations)
			{
				this.localizedRewardTypes.Add(rewardTypeLocalization.RewardType, rewardTypeLocalization);
			}
			foreach (AttributeModificationTypeLocalization attributeModificationTypeLocalization in localizationData.AttributeModificationTypeLocalizations)
			{
				this.localizedAttributeModificationTypes.Add(attributeModificationTypeLocalization.ModificationType, attributeModificationTypeLocalization);
			}
			foreach (SocketTypeLocalization socketTypeLocalization in localizationData.SocketTypeLocalizations)
			{
				this.localizedSocketTypes.Add(socketTypeLocalization.SocketType, socketTypeLocalization);
			}
			foreach (ResidentEffectLocalization residentEffectLocalization in localizationData.ResidentEffectLocalizations)
			{
				this.localizedResidentEffects.Add(residentEffectLocalization.EffectType, residentEffectLocalization);
			}
			foreach (UpgradeCardLocalization upgradeCardLocalization in localizationData.UpgradeCardLocalizations)
			{
				this.localizedCardUpgrades.Add(upgradeCardLocalization.Type, upgradeCardLocalization);
			}
			foreach (BattleOptionLocalization battleOptionLocalization in localizationData.BattleOptionLocalizations)
			{
				this.localizedBattleOptions.Add(battleOptionLocalization.Type, battleOptionLocalization);
			}
			foreach (VehicleLocalization vehicleLocalization in localizationData.VehicleLocalizations)
			{
				this.localizedVehicles.Add(vehicleLocalization.Type, vehicleLocalization);
			}
			foreach (JourneyContributionLocalization journeyContributionLocalization in localizationData.JourneyContributionLocalizations)
			{
				this.localizedJourneyContribution.Add(journeyContributionLocalization.Type, journeyContributionLocalization);
			}
			foreach (VehicleAttributeLocalization vehicleAttributeLocalization in localizationData.VehicleAttributeLocalizations)
			{
				this.localizedVehicleAttributes.Add(vehicleAttributeLocalization.Type, vehicleAttributeLocalization);
			}
			foreach (TripEncounterLocalization tripEncounterLocalization in localizationData.TripEncounterLocalizations)
			{
				this.localizedTripEncounters.Add(tripEncounterLocalization.Type, tripEncounterLocalization);
			}
			foreach (TripOutcomeLocalization tripOutcomeLocalization in localizationData.TripOutcomeLocalizations)
			{
				this.localizedTripOutcomes.Add(tripOutcomeLocalization.Type, tripOutcomeLocalization);
			}
			foreach (DestinationLocalization destinationLocalization in localizationData.DestinationLocalizations)
			{
				this.localizedDestinations.Add(destinationLocalization.Type, destinationLocalization);
			}
			foreach (UnitStyleLocalization unitStyleLocalization in localizationData.UnitStyleLocalizations)
			{
				this.localizedUnitStyles.Add(unitStyleLocalization.Type, unitStyleLocalization);
			}
			foreach (TalentLocalization talentLocalization in localizationData.TalentLocalizations)
			{
				this.localizedTalents.Add(talentLocalization.Type, talentLocalization);
			}
			foreach (TownEffectLocalization townEffectLocalization in localizationData.TownEffectLocalizations)
			{
				this.localizedTownEffects.Add(townEffectLocalization.Type, townEffectLocalization);
			}
			foreach (TownEventLocalizaiton townEventLocalizaiton in localizationData.TownEventLocalizaitons)
			{
				this.localizedTownEvents.Add(townEventLocalizaiton.Type, townEventLocalizaiton);
			}
			foreach (CandidateOrderMetricLocalization candidateOrderMetricLocalization in localizationData.CandidateOrderMetricLocalizations)
			{
				this.localizedCandidateOrderMetrics.Add(candidateOrderMetricLocalization.Type, candidateOrderMetricLocalization);
			}
			foreach (OrderTypeLocalization orderTypeLocalization in localizationData.OrderTypeLocalizations)
			{
				this.localizedOrderTypes.Add(orderTypeLocalization.Type, orderTypeLocalization);
			}
		}
		else
		{
			Debug.LogError("Cannot find file!");
		}
		this.isReady = true;
	}

	// Token: 0x06004534 RID: 17716 RVA: 0x001C02A0 File Offset: 0x001BE6A0
	public SkillLocalization GetSkillDescription(SkillType type)
	{
		SkillLocalization skillLocalization = new SkillLocalization
		{
			Description = string.Empty,
			Title = string.Empty,
			SkillType = type
		};
		if (this.localizedSkills.ContainsKey(type))
		{
			SkillLocalization skillLocalization2 = this.localizedSkills[type];
			skillLocalization.Description = skillLocalization2.Description;
			skillLocalization.PassiveDescription = skillLocalization2.PassiveDescription;
			skillLocalization.SkillType = skillLocalization2.SkillType;
			skillLocalization.Title = skillLocalization2.Title;
		}
		else
		{
			skillLocalization.Title = type.ToString();
		}
		return skillLocalization;
	}

	// Token: 0x06004535 RID: 17717 RVA: 0x001C033C File Offset: 0x001BE73C
	public ManualLocalization GetManualLocalization(ManualType type)
	{
		ManualLocalization manualLocalization = new ManualLocalization
		{
			Description = string.Empty,
			ManualType = type,
			Name = string.Empty
		};
		if (this.localizedManualTypes.ContainsKey(type))
		{
			return this.localizedManualTypes[type];
		}
		manualLocalization.Description = type.ToString();
		manualLocalization.Name = manualLocalization.Description;
		return manualLocalization;
	}

	// Token: 0x06004536 RID: 17718 RVA: 0x001C03AC File Offset: 0x001BE7AC
	public UILocalization GetUiLocalization(UIComponentType type)
	{
		UILocalization uilocalization = new UILocalization
		{
			UiComponentType = type,
			Name = string.Empty
		};
		if (this.localizedUiComponents.ContainsKey(type))
		{
			return this.localizedUiComponents[type];
		}
		uilocalization.Name = type.ToString();
		return uilocalization;
	}

	// Token: 0x06004537 RID: 17719 RVA: 0x001C0408 File Offset: 0x001BE808
	public EffectLocalization GetEffectLocalization(BattleEffectType type)
	{
		EffectLocalization effectLocalization = new EffectLocalization
		{
			Description = string.Empty,
			Title = string.Empty,
			BattleEffectType = type,
			Short = string.Empty
		};
		effectLocalization.Title = type.ToString();
		if (this.localizedBattleEffects.ContainsKey(type))
		{
			EffectLocalization effectLocalization2 = this.localizedBattleEffects[type];
			effectLocalization.BattleEffectType = effectLocalization2.BattleEffectType;
			effectLocalization.Description = effectLocalization2.Description;
			effectLocalization.Short = effectLocalization2.Short;
			effectLocalization.Title = effectLocalization2.Title;
		}
		else
		{
			effectLocalization.Title = type.ToString();
			effectLocalization.Description = effectLocalization.Title;
			effectLocalization.Short = effectLocalization.Title;
		}
		return effectLocalization;
	}

	// Token: 0x06004538 RID: 17720 RVA: 0x001C04D8 File Offset: 0x001BE8D8
	public ResourceLocalization GetItemLocalization(ResourceType type)
	{
		ResourceLocalization resourceLocalization = new ResourceLocalization
		{
			Description = string.Empty,
			Title = string.Empty,
			ItemType = type
		};
		resourceLocalization.Title = type.ToString();
		if (this.localizedItems.ContainsKey(type))
		{
			ResourceLocalization resourceLocalization2 = this.localizedItems[type];
			resourceLocalization.Description = resourceLocalization2.Description;
			resourceLocalization.ItemType = resourceLocalization2.ItemType;
			resourceLocalization.Title = resourceLocalization2.Title;
		}
		else
		{
			resourceLocalization.Title = type.ToString();
		}
		return resourceLocalization;
	}

	// Token: 0x06004539 RID: 17721 RVA: 0x001C0578 File Offset: 0x001BE978
	public ItemCategoryLocalization GetItemCategoryLocalization(ResourceCategory type)
	{
		ItemCategoryLocalization itemCategoryLocalization = new ItemCategoryLocalization
		{
			Description = string.Empty,
			Title = string.Empty,
			ResourceCategory = type
		};
		if (this.localizedItemCategories.ContainsKey(type))
		{
			itemCategoryLocalization = this.localizedItemCategories[type];
		}
		else
		{
			itemCategoryLocalization.Title = type.ToString();
		}
		return itemCategoryLocalization;
	}

	// Token: 0x0600453A RID: 17722 RVA: 0x001C05E4 File Offset: 0x001BE9E4
	public UnitLocalization GetUnitLocalization(UnitClass @class)
	{
		UnitLocalization unitLocalization = new UnitLocalization
		{
			Description = string.Empty,
			Title = string.Empty,
			UnitClass = @class
		};
		if (this.localizedUnits.ContainsKey(@class))
		{
			unitLocalization = this.localizedUnits[@class];
		}
		else
		{
			unitLocalization.Title = @class.ToString();
		}
		return unitLocalization;
	}

	// Token: 0x0600453B RID: 17723 RVA: 0x001C0650 File Offset: 0x001BEA50
	public BuildingLocalization GetBuildingLocalization(BuildingType type)
	{
		BuildingLocalization buildingLocalization = new BuildingLocalization
		{
			Description = string.Empty,
			Title = string.Empty,
			BuildingType = type
		};
		if (this.localizedBuilding.ContainsKey(type))
		{
			buildingLocalization = this.localizedBuilding[type];
		}
		else
		{
			buildingLocalization.Title = type.ToString();
		}
		return buildingLocalization;
	}

	// Token: 0x0600453C RID: 17724 RVA: 0x001C06BC File Offset: 0x001BEABC
	public AdventureLocalization GetAdventureLocalization(AdventureType type)
	{
		AdventureLocalization adventureLocalization = new AdventureLocalization
		{
			Description = string.Empty,
			Title = string.Empty,
			AdventureType = type
		};
		if (this.localizedAdventures.ContainsKey(type))
		{
			adventureLocalization = this.localizedAdventures[type];
		}
		else
		{
			adventureLocalization.Title = type.ToString();
		}
		return adventureLocalization;
	}

	// Token: 0x0600453D RID: 17725 RVA: 0x001C0728 File Offset: 0x001BEB28
	public QuestRequirementLocalization GetQuestRequirementLocalization(QuestRequirementType type)
	{
		QuestRequirementLocalization questRequirementLocalization = new QuestRequirementLocalization
		{
			Description = string.Empty,
			Title = string.Empty,
			QuestRequirementType = type
		};
		if (this.localizedQuestRequirements.ContainsKey(type))
		{
			QuestRequirementLocalization questRequirementLocalization2 = this.localizedQuestRequirements[type];
			questRequirementLocalization.Description = questRequirementLocalization2.Description;
			questRequirementLocalization.QuestRequirementType = questRequirementLocalization2.QuestRequirementType;
			questRequirementLocalization.Title = questRequirementLocalization2.Title;
		}
		else
		{
			questRequirementLocalization.Title = type.ToString();
		}
		return questRequirementLocalization;
	}

	// Token: 0x0600453E RID: 17726 RVA: 0x001C07B8 File Offset: 0x001BEBB8
	public QuestLocalization GetQuestLocalization(QuestIdentifier identifier)
	{
		QuestLocalization questLocalization = new QuestLocalization
		{
			Description = string.Empty,
			Title = string.Empty,
			QuestIdentifier = identifier
		};
		if (this.localizedQuest.ContainsKey(identifier))
		{
			QuestLocalization questLocalization2 = this.localizedQuest[identifier];
			questLocalization.Description = questLocalization2.Description;
			questLocalization.QuestIdentifier = questLocalization2.QuestIdentifier;
			questLocalization.Title = questLocalization2.Title;
		}
		else
		{
			questLocalization.Title = identifier.ToString();
		}
		return questLocalization;
	}

	// Token: 0x0600453F RID: 17727 RVA: 0x001C0848 File Offset: 0x001BEC48
	public StoryDetails GetStoryLocalizedDetails(StoryIdentifier identifier)
	{
		StoryDetails storyDetails = new StoryDetails
		{
			Identifier = identifier,
			Details = string.Empty
		};
		if (this.localizedStories.ContainsKey(identifier))
		{
			return this.localizedStories[identifier];
		}
		storyDetails.Details = identifier.ToString();
		return storyDetails;
	}

	// Token: 0x06004540 RID: 17728 RVA: 0x001C08A4 File Offset: 0x001BECA4
	public DialogDetails GetLocalizedDialog(DialogIdentifier identifier)
	{
		DialogDetails dialogDetails = new DialogDetails
		{
			Identifier = identifier,
			Dialog = string.Empty
		};
		if (this.localizedDialogs.ContainsKey(identifier))
		{
			return this.localizedDialogs[identifier];
		}
		dialogDetails.Dialog = identifier.ToString();
		return dialogDetails;
	}

	// Token: 0x06004541 RID: 17729 RVA: 0x001C0900 File Offset: 0x001BED00
	public AttributeLocalization GetAttributeLocalization(AttributeType type)
	{
		AttributeLocalization attributeLocalization = new AttributeLocalization
		{
			Description = string.Empty,
			AttributeType = type,
			Name = string.Empty
		};
		if (this.localizedAttributes.ContainsKey(type))
		{
			return this.localizedAttributes[type];
		}
		attributeLocalization.Description = type.ToString();
		attributeLocalization.Name = attributeLocalization.Description;
		return attributeLocalization;
	}

	// Token: 0x06004542 RID: 17730 RVA: 0x001C0970 File Offset: 0x001BED70
	public ResidentLocalization GetResidentLocalization(ResidentType type)
	{
		ResidentLocalization residentLocalization = new ResidentLocalization
		{
			Description = string.Empty,
			ResidentType = type,
			Name = string.Empty
		};
		if (this.localizedResidents.ContainsKey(type))
		{
			return this.localizedResidents[type];
		}
		residentLocalization.Description = type.ToString();
		residentLocalization.Name = residentLocalization.Description;
		return residentLocalization;
	}

	// Token: 0x06004543 RID: 17731 RVA: 0x001C09E0 File Offset: 0x001BEDE0
	public SpecialEffectLocalization GetSpecialEffectLocalization(SpecialEffectType type)
	{
		SpecialEffectLocalization specialEffectLocalization = new SpecialEffectLocalization
		{
			Description = string.Empty,
			SpecialEffectType = type,
			Name = string.Empty,
			GeneralInfo = string.Empty
		};
		if (this.localizedSpecialEffects.ContainsKey(type))
		{
			SpecialEffectLocalization specialEffectLocalization2 = this.localizedSpecialEffects[type];
			specialEffectLocalization.Description = specialEffectLocalization2.Description;
			specialEffectLocalization.Name = specialEffectLocalization2.Name;
			specialEffectLocalization.SpecialEffectType = specialEffectLocalization2.SpecialEffectType;
			specialEffectLocalization.GeneralInfo = specialEffectLocalization2.GeneralInfo;
		}
		else
		{
			specialEffectLocalization.Description = type.ToString();
			specialEffectLocalization.Name = specialEffectLocalization.Description;
		}
		return specialEffectLocalization;
	}

	// Token: 0x06004544 RID: 17732 RVA: 0x001C0A90 File Offset: 0x001BEE90
	public GrowthSpecialEffectConditionLocalization GetGrowthLocalization(GrowthConditionType type)
	{
		GrowthSpecialEffectConditionLocalization growthSpecialEffectConditionLocalization = new GrowthSpecialEffectConditionLocalization
		{
			Description = string.Empty,
			ConditionType = type,
			Name = string.Empty
		};
		if (this.localizedGrowthConditions.ContainsKey(type))
		{
			return this.localizedGrowthConditions[type];
		}
		growthSpecialEffectConditionLocalization.Description = type.ToString();
		growthSpecialEffectConditionLocalization.Name = type.ToString();
		return growthSpecialEffectConditionLocalization;
	}

	// Token: 0x06004545 RID: 17733 RVA: 0x001C0B08 File Offset: 0x001BEF08
	public ItemGradeLocalization GetItemGradeLocalization(QualityGrade grade)
	{
		ItemGradeLocalization itemGradeLocalization = new ItemGradeLocalization
		{
			Description = string.Empty,
			Name = string.Empty,
			Grade = grade
		};
		if (this.localizedItemGrades.ContainsKey(grade))
		{
			return this.localizedItemGrades[grade];
		}
		itemGradeLocalization.Description = grade.ToString();
		itemGradeLocalization.Name = itemGradeLocalization.Description;
		return itemGradeLocalization;
	}

	// Token: 0x06004546 RID: 17734 RVA: 0x001C0B78 File Offset: 0x001BEF78
	public RewardTypeLocalization GetRewardTypeLocalization(RewardType type)
	{
		RewardTypeLocalization rewardTypeLocalization = new RewardTypeLocalization
		{
			RewardType = type,
			Description = string.Empty,
			Name = string.Empty
		};
		if (this.localizedRewardTypes.ContainsKey(type))
		{
			rewardTypeLocalization.RewardType = type;
			rewardTypeLocalization.Description = this.localizedRewardTypes[type].Description;
			rewardTypeLocalization.Name = this.localizedRewardTypes[type].Name;
		}
		else
		{
			rewardTypeLocalization.Description = type.ToString();
			rewardTypeLocalization.Name = rewardTypeLocalization.Description;
		}
		return rewardTypeLocalization;
	}

	// Token: 0x06004547 RID: 17735 RVA: 0x001C0C18 File Offset: 0x001BF018
	public QuestChainLocalization GetQuestChainLocalization(QuestChainIdentifier type)
	{
		QuestChainLocalization questChainLocalization = new QuestChainLocalization
		{
			QuestChainIdentifier = type,
			Description = string.Empty,
			Name = string.Empty
		};
		if (this.localizedQuestchainIdentifiers.ContainsKey(type))
		{
			QuestChainLocalization questChainLocalization2 = this.localizedQuestchainIdentifiers[type];
			questChainLocalization.QuestChainIdentifier = questChainLocalization2.QuestChainIdentifier;
			questChainLocalization.Description = questChainLocalization2.Description;
			questChainLocalization.Name = questChainLocalization2.Name;
		}
		else
		{
			questChainLocalization.Description = type.ToString();
			questChainLocalization.Name = questChainLocalization.Description;
		}
		return questChainLocalization;
	}

	// Token: 0x06004548 RID: 17736 RVA: 0x001C0CB4 File Offset: 0x001BF0B4
	public UnitCategoryLocalization GetUnitCategoryLocalization(ClassCategory type)
	{
		UnitCategoryLocalization unitCategoryLocalization = new UnitCategoryLocalization
		{
			Description = string.Empty,
			Name = string.Empty,
			ClassCategoryIdentifier = type
		};
		if (this.localizedUnitCategories.ContainsKey(type))
		{
			UnitCategoryLocalization unitCategoryLocalization2 = this.localizedUnitCategories[type];
			unitCategoryLocalization.ClassCategoryIdentifier = unitCategoryLocalization2.ClassCategoryIdentifier;
			unitCategoryLocalization.Description = unitCategoryLocalization2.Description;
			unitCategoryLocalization.Name = unitCategoryLocalization2.Name;
		}
		else
		{
			unitCategoryLocalization.Name = type.ToString();
			unitCategoryLocalization.Description = unitCategoryLocalization.Name;
		}
		return unitCategoryLocalization;
	}

	// Token: 0x06004549 RID: 17737 RVA: 0x001C0D50 File Offset: 0x001BF150
	public BattleEventLocalization GetBattleEventLocalization(AdventureEventType type)
	{
		BattleEventLocalization battleEventLocalization = new BattleEventLocalization
		{
			Description = string.Empty,
			EventType = type,
			Name = string.Empty
		};
		if (this.localizedBattleEvents.ContainsKey(type))
		{
			return this.localizedBattleEvents[type];
		}
		battleEventLocalization.Name = type.ToString();
		battleEventLocalization.Description = battleEventLocalization.Name;
		return battleEventLocalization;
	}

	// Token: 0x0600454A RID: 17738 RVA: 0x001C0DC0 File Offset: 0x001BF1C0
	public OutputTypeLocalization GetOutputLocalization(OutputType type)
	{
		OutputTypeLocalization outputTypeLocalization = new OutputTypeLocalization
		{
			Description = string.Empty,
			OutputType = type,
			Name = string.Empty
		};
		if (this.localizedOutputs.ContainsKey(type))
		{
			return this.localizedOutputs[type];
		}
		outputTypeLocalization.Description = type.ToString();
		outputTypeLocalization.Name = outputTypeLocalization.Description;
		return outputTypeLocalization;
	}

	// Token: 0x0600454B RID: 17739 RVA: 0x001C0E30 File Offset: 0x001BF230
	public BoostTypeLocalization GetBoostTypeLocalization(BoostType type)
	{
		BoostTypeLocalization boostTypeLocalization = new BoostTypeLocalization
		{
			Description = string.Empty,
			BoostType = type,
			Name = string.Empty
		};
		if (this.localizedBoostTypes.ContainsKey(type))
		{
			return this.localizedBoostTypes[type];
		}
		boostTypeLocalization.Description = type.ToString();
		boostTypeLocalization.Name = boostTypeLocalization.Description;
		return boostTypeLocalization;
	}

	// Token: 0x0600454C RID: 17740 RVA: 0x001C0EA0 File Offset: 0x001BF2A0
	public TargetCandidateTypeLocalization GetTargetCandidateTypeLocalization(TargetCandidateType type)
	{
		TargetCandidateTypeLocalization targetCandidateTypeLocalization = new TargetCandidateTypeLocalization
		{
			Description = string.Empty,
			TargetCandidateType = type,
			Name = string.Empty
		};
		if (this.localizedTargetCandidateTypes.ContainsKey(type))
		{
			return this.localizedTargetCandidateTypes[type];
		}
		targetCandidateTypeLocalization.Description = type.ToString();
		targetCandidateTypeLocalization.Name = targetCandidateTypeLocalization.Description;
		return targetCandidateTypeLocalization;
	}

	// Token: 0x0600454D RID: 17741 RVA: 0x001C0F10 File Offset: 0x001BF310
	public TownTitleLocalization GetTownTitleLocalization(TownTitleType type)
	{
		TownTitleLocalization townTitleLocalization = new TownTitleLocalization
		{
			Description = string.Empty,
			Name = string.Empty,
			TownTitleType = type
		};
		if (this.localizedTownTitles.ContainsKey(type))
		{
			return this.localizedTownTitles[type];
		}
		townTitleLocalization.Description = type.ToString();
		townTitleLocalization.Name = townTitleLocalization.Description;
		return townTitleLocalization;
	}

	// Token: 0x0600454E RID: 17742 RVA: 0x001C0F80 File Offset: 0x001BF380
	public MonsterSlotLocalization GetMonsterSlotLocalization(AdventureEncounterSlotType slot)
	{
		MonsterSlotLocalization monsterSlotLocalization = new MonsterSlotLocalization
		{
			Description = string.Empty,
			Name = string.Empty,
			SlotType = slot
		};
		if (this.localizedMonsterSlots.ContainsKey(slot))
		{
			return this.localizedMonsterSlots[slot];
		}
		monsterSlotLocalization.Description = slot.ToString();
		monsterSlotLocalization.Name = monsterSlotLocalization.Description;
		return monsterSlotLocalization;
	}

	// Token: 0x0600454F RID: 17743 RVA: 0x001C0FF0 File Offset: 0x001BF3F0
	public AttributeModificationTypeLocalization GetAttributeModificationTypeLocalization(ModificationType type)
	{
		AttributeModificationTypeLocalization attributeModificationTypeLocalization = new AttributeModificationTypeLocalization
		{
			Description = string.Empty,
			ModificationType = type,
			Name = string.Empty
		};
		if (this.localizedAttributeModificationTypes.ContainsKey(type))
		{
			AttributeModificationTypeLocalization attributeModificationTypeLocalization2 = this.localizedAttributeModificationTypes[type];
			attributeModificationTypeLocalization.Description = attributeModificationTypeLocalization2.Description;
			attributeModificationTypeLocalization.Name = attributeModificationTypeLocalization2.Name;
		}
		else
		{
			attributeModificationTypeLocalization.Description = type.ToString();
			attributeModificationTypeLocalization.Name = attributeModificationTypeLocalization.Description;
		}
		return attributeModificationTypeLocalization;
	}

	// Token: 0x06004550 RID: 17744 RVA: 0x001C1080 File Offset: 0x001BF480
	public SocketTypeLocalization GetSocketLocalization(SocketType type)
	{
		SocketTypeLocalization socketTypeLocalization = new SocketTypeLocalization
		{
			Description = string.Empty,
			Name = string.Empty,
			SocketType = type
		};
		if (this.localizedSocketTypes.ContainsKey(type))
		{
			SocketTypeLocalization socketTypeLocalization2 = this.localizedSocketTypes[type];
			socketTypeLocalization.SocketType = socketTypeLocalization2.SocketType;
			socketTypeLocalization.Description = socketTypeLocalization2.Description;
			socketTypeLocalization.Name = socketTypeLocalization2.Name;
		}
		else
		{
			socketTypeLocalization.Description = type.ToString();
			socketTypeLocalization.Name = socketTypeLocalization.Description;
		}
		return socketTypeLocalization;
	}

	// Token: 0x06004551 RID: 17745 RVA: 0x001C111C File Offset: 0x001BF51C
	public ResidentEffectLocalization GetResidentEffectLocalization(ResidentEffectType type)
	{
		ResidentEffectLocalization residentEffectLocalization = new ResidentEffectLocalization
		{
			Description = string.Empty,
			Name = string.Empty,
			EffectType = type
		};
		if (this.localizedResidentEffects.ContainsKey(type))
		{
			ResidentEffectLocalization residentEffectLocalization2 = this.localizedResidentEffects[type];
			residentEffectLocalization.Description = residentEffectLocalization2.Description;
			residentEffectLocalization.EffectType = residentEffectLocalization2.EffectType;
			residentEffectLocalization.Name = residentEffectLocalization2.Name;
		}
		else
		{
			residentEffectLocalization.Description = type.ToString();
			residentEffectLocalization.Name = residentEffectLocalization.Description;
		}
		return residentEffectLocalization;
	}

	// Token: 0x06004552 RID: 17746 RVA: 0x001C11B8 File Offset: 0x001BF5B8
	public UpgradeCardLocalization GetCardUpgradeLocalization(UpgradeCardType type)
	{
		UpgradeCardLocalization upgradeCardLocalization = new UpgradeCardLocalization
		{
			Description = string.Empty,
			Name = string.Empty,
			Type = type
		};
		if (this.localizedCardUpgrades.ContainsKey(type))
		{
			UpgradeCardLocalization upgradeCardLocalization2 = this.localizedCardUpgrades[type];
			upgradeCardLocalization.Description = upgradeCardLocalization2.Description;
			upgradeCardLocalization.Type = upgradeCardLocalization2.Type;
			upgradeCardLocalization.Name = upgradeCardLocalization2.Name;
		}
		else
		{
			upgradeCardLocalization.Description = type.ToString();
			upgradeCardLocalization.Name = upgradeCardLocalization.Description;
		}
		return upgradeCardLocalization;
	}

	// Token: 0x06004553 RID: 17747 RVA: 0x001C1254 File Offset: 0x001BF654
	public BattleOptionLocalization GetBattleOptionLocalization(BattleOptionType type)
	{
		BattleOptionLocalization battleOptionLocalization = new BattleOptionLocalization
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedBattleOptions.ContainsKey(type))
		{
			BattleOptionLocalization battleOptionLocalization2 = this.localizedBattleOptions[type];
			battleOptionLocalization.Description = battleOptionLocalization2.Description;
			battleOptionLocalization.Type = battleOptionLocalization2.Type;
			battleOptionLocalization.Name = battleOptionLocalization2.Name;
		}
		else
		{
			battleOptionLocalization.Description = type.ToString();
			battleOptionLocalization.Name = battleOptionLocalization.Description;
		}
		return battleOptionLocalization;
	}

	// Token: 0x06004554 RID: 17748 RVA: 0x001C12F0 File Offset: 0x001BF6F0
	public VehicleLocalization GetVehicleLocalization(VehicleType type)
	{
		VehicleLocalization vehicleLocalization = new VehicleLocalization
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedVehicles.ContainsKey(type))
		{
			VehicleLocalization vehicleLocalization2 = this.localizedVehicles[type];
			vehicleLocalization.Type = vehicleLocalization2.Type;
			vehicleLocalization.Description = vehicleLocalization2.Description;
			vehicleLocalization.Name = vehicleLocalization2.Name;
		}
		else
		{
			vehicleLocalization.Name = type.ToString();
			vehicleLocalization.Description = vehicleLocalization.Name;
		}
		return vehicleLocalization;
	}

	// Token: 0x06004555 RID: 17749 RVA: 0x001C138C File Offset: 0x001BF78C
	public JourneyContributionLocalization GetJourneyContribution(JourneyContributeType type)
	{
		JourneyContributionLocalization journeyContributionLocalization = new JourneyContributionLocalization
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedJourneyContribution.ContainsKey(type))
		{
			JourneyContributionLocalization journeyContributionLocalization2 = this.localizedJourneyContribution[type];
			journeyContributionLocalization.Description = journeyContributionLocalization2.Description;
			journeyContributionLocalization.Type = journeyContributionLocalization2.Type;
			journeyContributionLocalization.Name = journeyContributionLocalization2.Name;
		}
		else
		{
			journeyContributionLocalization.Description = type.ToString();
			journeyContributionLocalization.Name = journeyContributionLocalization.Description;
		}
		return journeyContributionLocalization;
	}

	// Token: 0x06004556 RID: 17750 RVA: 0x001C1428 File Offset: 0x001BF828
	public VehicleAttributeLocalization GetVehicleAttribute(VehicleAttributeType type)
	{
		VehicleAttributeLocalization vehicleAttributeLocalization = new VehicleAttributeLocalization
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedVehicleAttributes.ContainsKey(type))
		{
			VehicleAttributeLocalization vehicleAttributeLocalization2 = this.localizedVehicleAttributes[type];
			vehicleAttributeLocalization.Description = vehicleAttributeLocalization2.Description;
			vehicleAttributeLocalization.Type = vehicleAttributeLocalization2.Type;
			vehicleAttributeLocalization.Name = vehicleAttributeLocalization2.Name;
		}
		else
		{
			vehicleAttributeLocalization.Description = type.ToString();
			vehicleAttributeLocalization.Name = vehicleAttributeLocalization.Description;
		}
		return vehicleAttributeLocalization;
	}

	// Token: 0x06004557 RID: 17751 RVA: 0x001C14C4 File Offset: 0x001BF8C4
	public TripEncounterLocalization GetTripEncounter(TripEncounterType type)
	{
		TripEncounterLocalization tripEncounterLocalization = new TripEncounterLocalization
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedTripEncounters.ContainsKey(type))
		{
			TripEncounterLocalization tripEncounterLocalization2 = this.localizedTripEncounters[type];
			tripEncounterLocalization.Description = tripEncounterLocalization2.Description;
			tripEncounterLocalization.Type = tripEncounterLocalization2.Type;
			tripEncounterLocalization.Name = tripEncounterLocalization2.Name;
		}
		else
		{
			tripEncounterLocalization.Name = type.ToString();
			tripEncounterLocalization.Description = tripEncounterLocalization.Name;
		}
		return tripEncounterLocalization;
	}

	// Token: 0x06004558 RID: 17752 RVA: 0x001C1560 File Offset: 0x001BF960
	public TripOutcomeLocalization GetTripOutcome(TripEncounterOutcomeType type)
	{
		TripOutcomeLocalization tripOutcomeLocalization = new TripOutcomeLocalization
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedTripOutcomes.ContainsKey(type))
		{
			TripOutcomeLocalization tripOutcomeLocalization2 = this.localizedTripOutcomes[type];
			tripOutcomeLocalization.Description = tripOutcomeLocalization2.Description;
			tripOutcomeLocalization.Type = tripOutcomeLocalization2.Type;
			tripOutcomeLocalization.Name = tripOutcomeLocalization2.Name;
		}
		else
		{
			tripOutcomeLocalization.Description = type.ToString();
			tripOutcomeLocalization.Name = tripOutcomeLocalization.Description;
		}
		return tripOutcomeLocalization;
	}

	// Token: 0x06004559 RID: 17753 RVA: 0x001C15FC File Offset: 0x001BF9FC
	public DestinationLocalization GetDestination(DestinationType type)
	{
		DestinationLocalization destinationLocalization = new DestinationLocalization
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedDestinations.ContainsKey(type))
		{
			DestinationLocalization destinationLocalization2 = this.localizedDestinations[type];
			destinationLocalization.Description = destinationLocalization2.Description;
			destinationLocalization.Type = destinationLocalization2.Type;
			destinationLocalization.Name = destinationLocalization2.Name;
		}
		else
		{
			destinationLocalization.Description = type.ToString();
			destinationLocalization.Name = destinationLocalization.Description;
		}
		return destinationLocalization;
	}

	// Token: 0x0600455A RID: 17754 RVA: 0x001C1698 File Offset: 0x001BFA98
	public UnitStyleLocalization GetUnitStyle(UnitClassStyle type)
	{
		UnitStyleLocalization unitStyleLocalization = new UnitStyleLocalization
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedUnitStyles.ContainsKey(type))
		{
			UnitStyleLocalization unitStyleLocalization2 = this.localizedUnitStyles[type];
			unitStyleLocalization.Description = unitStyleLocalization2.Description;
			unitStyleLocalization.Type = unitStyleLocalization2.Type;
			unitStyleLocalization.Name = unitStyleLocalization2.Name;
		}
		else
		{
			unitStyleLocalization.Name = type.ToString();
			unitStyleLocalization.Description = unitStyleLocalization.Name;
		}
		return unitStyleLocalization;
	}

	// Token: 0x0600455B RID: 17755 RVA: 0x001C1734 File Offset: 0x001BFB34
	public TalentLocalization GetTalent(AdventurerTalentType type)
	{
		TalentLocalization talentLocalization = new TalentLocalization
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedTalents.ContainsKey(type))
		{
			TalentLocalization talentLocalization2 = this.localizedTalents[type];
			talentLocalization.Description = talentLocalization2.Description;
			talentLocalization.Type = talentLocalization2.Type;
			talentLocalization.Name = talentLocalization2.Name;
		}
		else
		{
			talentLocalization.Description = type.ToString();
			talentLocalization.Name = talentLocalization.Description;
		}
		return talentLocalization;
	}

	// Token: 0x0600455C RID: 17756 RVA: 0x001C17D0 File Offset: 0x001BFBD0
	public TownEventLocalizaiton GetTownEvent(TownEventType type)
	{
		TownEventLocalizaiton townEventLocalizaiton = new TownEventLocalizaiton
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedTownEvents.ContainsKey(type))
		{
			TownEventLocalizaiton townEventLocalizaiton2 = this.localizedTownEvents[type];
			townEventLocalizaiton.Description = townEventLocalizaiton2.Description;
			townEventLocalizaiton.Type = townEventLocalizaiton2.Type;
			townEventLocalizaiton.Name = townEventLocalizaiton2.Name;
		}
		else
		{
			townEventLocalizaiton.Description = type.ToString();
			townEventLocalizaiton.Name = townEventLocalizaiton.Description;
		}
		return townEventLocalizaiton;
	}

	// Token: 0x0600455D RID: 17757 RVA: 0x001C186C File Offset: 0x001BFC6C
	public TownEffectLocalization GetTownEffect(TownEffectType type)
	{
		TownEffectLocalization townEffectLocalization = new TownEffectLocalization
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedTownEffects.ContainsKey(type))
		{
			TownEffectLocalization townEffectLocalization2 = this.localizedTownEffects[type];
			townEffectLocalization.Description = townEffectLocalization2.Description;
			townEffectLocalization.Type = townEffectLocalization2.Type;
			townEffectLocalization.Name = townEffectLocalization2.Name;
		}
		else
		{
			townEffectLocalization.Description = type.ToString();
			townEffectLocalization.Name = townEffectLocalization.Description;
		}
		return townEffectLocalization;
	}

	// Token: 0x0600455E RID: 17758 RVA: 0x001C1908 File Offset: 0x001BFD08
	public CandidateOrderMetricLocalization GetCandidateMetric(CandidateOrderringMetric type)
	{
		CandidateOrderMetricLocalization candidateOrderMetricLocalization = new CandidateOrderMetricLocalization
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedCandidateOrderMetrics.ContainsKey(type))
		{
			CandidateOrderMetricLocalization candidateOrderMetricLocalization2 = this.localizedCandidateOrderMetrics[type];
			candidateOrderMetricLocalization.Type = candidateOrderMetricLocalization2.Type;
			candidateOrderMetricLocalization.Description = candidateOrderMetricLocalization2.Description;
			candidateOrderMetricLocalization.Name = candidateOrderMetricLocalization2.Name;
		}
		else
		{
			candidateOrderMetricLocalization.Description = type.ToString();
			candidateOrderMetricLocalization.Name = candidateOrderMetricLocalization.Description;
		}
		return candidateOrderMetricLocalization;
	}

	// Token: 0x0600455F RID: 17759 RVA: 0x001C19A4 File Offset: 0x001BFDA4
	public OrderTypeLocalization GetOrderType(OrderingType type)
	{
		OrderTypeLocalization orderTypeLocalization = new OrderTypeLocalization
		{
			Description = string.Empty,
			Type = type,
			Name = string.Empty
		};
		if (this.localizedOrderTypes.ContainsKey(type))
		{
			OrderTypeLocalization orderTypeLocalization2 = this.localizedOrderTypes[type];
			orderTypeLocalization.Type = orderTypeLocalization2.Type;
			orderTypeLocalization.Description = orderTypeLocalization2.Description;
			orderTypeLocalization.Name = orderTypeLocalization2.Name;
		}
		else
		{
			orderTypeLocalization.Description = type.ToString();
			orderTypeLocalization.Name = orderTypeLocalization.Description;
		}
		return orderTypeLocalization;
	}

	// Token: 0x06004560 RID: 17760 RVA: 0x001C1A3D File Offset: 0x001BFE3D
	public bool GetIsReady()
	{
		return this.isReady;
	}

	// Token: 0x0400348A RID: 13450
	private Dictionary<SkillType, SkillLocalization> localizedSkills;

	// Token: 0x0400348B RID: 13451
	private Dictionary<BattleEffectType, EffectLocalization> localizedBattleEffects;

	// Token: 0x0400348C RID: 13452
	private Dictionary<ResourceType, ResourceLocalization> localizedItems;

	// Token: 0x0400348D RID: 13453
	private Dictionary<ResourceCategory, ItemCategoryLocalization> localizedItemCategories;

	// Token: 0x0400348E RID: 13454
	private Dictionary<UnitClass, UnitLocalization> localizedUnits;

	// Token: 0x0400348F RID: 13455
	private Dictionary<BuildingType, BuildingLocalization> localizedBuilding;

	// Token: 0x04003490 RID: 13456
	private Dictionary<AdventureType, AdventureLocalization> localizedAdventures;

	// Token: 0x04003491 RID: 13457
	private Dictionary<QuestRequirementType, QuestRequirementLocalization> localizedQuestRequirements;

	// Token: 0x04003492 RID: 13458
	private Dictionary<QuestIdentifier, QuestLocalization> localizedQuest;

	// Token: 0x04003493 RID: 13459
	private Dictionary<DialogIdentifier, DialogDetails> localizedDialogs;

	// Token: 0x04003494 RID: 13460
	private Dictionary<StoryIdentifier, StoryDetails> localizedStories;

	// Token: 0x04003495 RID: 13461
	private Dictionary<UIComponentType, UILocalization> localizedUiComponents;

	// Token: 0x04003496 RID: 13462
	private Dictionary<AttributeType, AttributeLocalization> localizedAttributes;

	// Token: 0x04003497 RID: 13463
	private Dictionary<ResidentType, ResidentLocalization> localizedResidents;

	// Token: 0x04003498 RID: 13464
	private Dictionary<SpecialEffectType, SpecialEffectLocalization> localizedSpecialEffects;

	// Token: 0x04003499 RID: 13465
	private Dictionary<GrowthConditionType, GrowthSpecialEffectConditionLocalization> localizedGrowthConditions;

	// Token: 0x0400349A RID: 13466
	private Dictionary<QualityGrade, ItemGradeLocalization> localizedItemGrades;

	// Token: 0x0400349B RID: 13467
	private Dictionary<RewardType, RewardTypeLocalization> localizedRewardTypes;

	// Token: 0x0400349C RID: 13468
	private Dictionary<QuestChainIdentifier, QuestChainLocalization> localizedQuestchainIdentifiers;

	// Token: 0x0400349D RID: 13469
	private Dictionary<ClassCategory, UnitCategoryLocalization> localizedUnitCategories;

	// Token: 0x0400349E RID: 13470
	private Dictionary<AdventureEventType, BattleEventLocalization> localizedBattleEvents;

	// Token: 0x0400349F RID: 13471
	private Dictionary<OutputType, OutputTypeLocalization> localizedOutputs;

	// Token: 0x040034A0 RID: 13472
	private Dictionary<BoostType, BoostTypeLocalization> localizedBoostTypes;

	// Token: 0x040034A1 RID: 13473
	private Dictionary<TargetCandidateType, TargetCandidateTypeLocalization> localizedTargetCandidateTypes;

	// Token: 0x040034A2 RID: 13474
	private Dictionary<TownTitleType, TownTitleLocalization> localizedTownTitles;

	// Token: 0x040034A3 RID: 13475
	private Dictionary<AdventureEncounterSlotType, MonsterSlotLocalization> localizedMonsterSlots;

	// Token: 0x040034A4 RID: 13476
	private Dictionary<ModificationType, AttributeModificationTypeLocalization> localizedAttributeModificationTypes;

	// Token: 0x040034A5 RID: 13477
	private Dictionary<SocketType, SocketTypeLocalization> localizedSocketTypes;

	// Token: 0x040034A6 RID: 13478
	private Dictionary<ResidentEffectType, ResidentEffectLocalization> localizedResidentEffects;

	// Token: 0x040034A7 RID: 13479
	private Dictionary<UpgradeCardType, UpgradeCardLocalization> localizedCardUpgrades;

	// Token: 0x040034A8 RID: 13480
	private Dictionary<BattleOptionType, BattleOptionLocalization> localizedBattleOptions;

	// Token: 0x040034A9 RID: 13481
	private Dictionary<VehicleType, VehicleLocalization> localizedVehicles;

	// Token: 0x040034AA RID: 13482
	private Dictionary<JourneyContributeType, JourneyContributionLocalization> localizedJourneyContribution;

	// Token: 0x040034AB RID: 13483
	private Dictionary<VehicleAttributeType, VehicleAttributeLocalization> localizedVehicleAttributes;

	// Token: 0x040034AC RID: 13484
	private Dictionary<TripEncounterType, TripEncounterLocalization> localizedTripEncounters;

	// Token: 0x040034AD RID: 13485
	private Dictionary<TripEncounterOutcomeType, TripOutcomeLocalization> localizedTripOutcomes;

	// Token: 0x040034AE RID: 13486
	private Dictionary<DestinationType, DestinationLocalization> localizedDestinations;

	// Token: 0x040034AF RID: 13487
	private Dictionary<UnitClassStyle, UnitStyleLocalization> localizedUnitStyles;

	// Token: 0x040034B0 RID: 13488
	private Dictionary<ManualType, ManualLocalization> localizedManualTypes;

	// Token: 0x040034B1 RID: 13489
	private Dictionary<AdventurerTalentType, TalentLocalization> localizedTalents;

	// Token: 0x040034B2 RID: 13490
	private Dictionary<TownEventType, TownEventLocalizaiton> localizedTownEvents;

	// Token: 0x040034B3 RID: 13491
	private Dictionary<TownEffectType, TownEffectLocalization> localizedTownEffects;

	// Token: 0x040034B4 RID: 13492
	private Dictionary<CandidateOrderringMetric, CandidateOrderMetricLocalization> localizedCandidateOrderMetrics;

	// Token: 0x040034B5 RID: 13493
	private Dictionary<OrderingType, OrderTypeLocalization> localizedOrderTypes;

	// Token: 0x040034B6 RID: 13494
	private bool isReady;
}
