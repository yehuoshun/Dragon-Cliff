using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020009C9 RID: 2505
[Serializable]
public class LocalizationData
{
	// Token: 0x0600447C RID: 17532 RVA: 0x001BBB90 File Offset: 0x001B9F90
	public LocalizationData()
	{
		this.SkillDescriptions = new List<SkillLocalization>();
		this.EffectDescriptions = new List<EffectLocalization>();
		this.ItemDescriptions = new List<ResourceLocalization>();
		this.ResourceCategoryDescriptions = new List<ItemCategoryLocalization>();
		this.UnitDescriptions = new List<UnitLocalization>();
		this.BuildingDescriptions = new List<BuildingLocalization>();
		this.AdventureDescriptions = new List<AdventureLocalization>();
		this.FactionDescriptions = new List<FactionLocalization>();
		this.QuestRequirementDescriptions = new List<QuestRequirementLocalization>();
		this.QuestDescriptions = new List<QuestLocalization>();
		this.DialogDetails = new List<DialogDetails>();
		this.StoryDetailses = new List<StoryDetails>();
		this.UiLocalizations = new List<UILocalization>();
		this.AttributeLocalizations = new List<AttributeLocalization>();
		this.ResidentLocalizations = new List<ResidentLocalization>();
		this.SpecialEffectLocalizations = new List<SpecialEffectLocalization>();
		this.GrowthConditionLocalizations = new List<GrowthSpecialEffectConditionLocalization>();
		this.ItemGradeLocalizations = new List<ItemGradeLocalization>();
		this.RewardTypeLocalizations = new List<RewardTypeLocalization>();
		this.QuestChainLocalizations = new List<QuestChainLocalization>();
		this.UnitCategoryLocalizations = new List<UnitCategoryLocalization>();
		this.BattleEventLocalizations = new List<BattleEventLocalization>();
		this.OutputLocalizations = new List<OutputTypeLocalization>();
		this.BoostTypeLocalizations = new List<BoostTypeLocalization>();
		this.TargetCandidateTypeLocalizations = new List<TargetCandidateTypeLocalization>();
		this.TownTitleLocalizations = new List<TownTitleLocalization>();
		this.MonsterSlotLocalizations = new List<MonsterSlotLocalization>();
		this.AttributeModificationTypeLocalizations = new List<AttributeModificationTypeLocalization>();
		this.SocketTypeLocalizations = new List<SocketTypeLocalization>();
		this.ResidentEffectLocalizations = new List<ResidentEffectLocalization>();
		this.UpgradeCardLocalizations = new List<UpgradeCardLocalization>();
		this.BattleOptionLocalizations = new List<BattleOptionLocalization>();
		this.VehicleLocalizations = new List<VehicleLocalization>();
		this.JourneyContributionLocalizations = new List<JourneyContributionLocalization>();
		this.VehicleAttributeLocalizations = new List<VehicleAttributeLocalization>();
		this.TripEncounterLocalizations = new List<TripEncounterLocalization>();
		this.TripOutcomeLocalizations = new List<TripOutcomeLocalization>();
		this.DestinationLocalizations = new List<DestinationLocalization>();
		this.UnitStyleLocalizations = new List<UnitStyleLocalization>();
		this.ManualLocalizations = new List<ManualLocalization>();
		this.TalentLocalizations = new List<TalentLocalization>();
		this.TownEventLocalizaitons = new List<TownEventLocalizaiton>();
		this.TownEffectLocalizations = new List<TownEffectLocalization>();
		this.CandidateOrderMetricLocalizations = new List<CandidateOrderMetricLocalization>();
		this.OrderTypeLocalizations = new List<OrderTypeLocalization>();
	}

	// Token: 0x0600447D RID: 17533 RVA: 0x001BBD94 File Offset: 0x001BA194
	public void AddNewSkill()
	{
		List<SkillType> enumValues = ItemExtensions.GetEnumValues<SkillType>();
		if (this.SkillDescriptions.Any<SkillLocalization>())
		{
			SkillType skillType = enumValues.FirstOrDefault((SkillType sk) => this.SkillDescriptions.All((SkillLocalization esk) => esk.SkillType != sk));
			if (skillType != SkillType.None)
			{
				this.SkillDescriptions.Add(new SkillLocalization
				{
					Description = skillType.ToString(),
					SkillType = skillType,
					Title = skillType.ToString()
				});
			}
		}
		else
		{
			this.SkillDescriptions.Add(new SkillLocalization());
		}
	}

	// Token: 0x0600447E RID: 17534 RVA: 0x001BBE24 File Offset: 0x001BA224
	public void AddNewEffect()
	{
		List<BattleEffectType> enumValues = ItemExtensions.GetEnumValues<BattleEffectType>();
		if (this.EffectDescriptions.Any<EffectLocalization>())
		{
			List<BattleEffectType> source = (from r in enumValues
			where this.EffectDescriptions.All((EffectLocalization i) => i.BattleEffectType != r)
			orderby r
			select r).ToList<BattleEffectType>();
			BattleEffectType battleEffectType = source.FirstOrDefault<BattleEffectType>();
			if (battleEffectType != BattleEffectType.TurnDamage)
			{
				this.EffectDescriptions.Add(new EffectLocalization
				{
					Description = battleEffectType.ToString(),
					BattleEffectType = battleEffectType,
					Title = battleEffectType.ToString()
				});
				this.AddNewEffect();
			}
		}
		else
		{
			this.EffectDescriptions.Add(new EffectLocalization());
		}
	}

	// Token: 0x0600447F RID: 17535 RVA: 0x001BBEE8 File Offset: 0x001BA2E8
	public void AddNewItem()
	{
		List<ResourceType> enumValues = ItemExtensions.GetEnumValues<ResourceType>();
		if (this.ItemDescriptions.Any<ResourceLocalization>())
		{
			List<ResourceType> source = (from r in enumValues
			where this.ItemDescriptions.All((ResourceLocalization i) => i.ItemType != r)
			orderby r
			select r).ToList<ResourceType>();
			ResourceType resourceType = source.FirstOrDefault<ResourceType>();
			if (resourceType != (ResourceType)0)
			{
				this.ItemDescriptions.Add(new ResourceLocalization
				{
					Description = resourceType.ToString(),
					ItemType = resourceType,
					Title = resourceType.ToString()
				});
				this.AddNewItem();
			}
		}
		else
		{
			this.ItemDescriptions.Add(new ResourceLocalization());
		}
	}

	// Token: 0x06004480 RID: 17536 RVA: 0x001BBFAC File Offset: 0x001BA3AC
	public void AddNewItemCategory()
	{
		List<ResourceCategory> enumValues = ItemExtensions.GetEnumValues<ResourceCategory>();
		if (this.ResourceCategoryDescriptions.Any<ItemCategoryLocalization>())
		{
			List<ResourceCategory> source = (from r in enumValues
			where this.ResourceCategoryDescriptions.All((ItemCategoryLocalization i) => i.ResourceCategory != r)
			orderby r
			select r).ToList<ResourceCategory>();
			ResourceCategory resourceCategory = source.FirstOrDefault<ResourceCategory>();
			if (resourceCategory != ResourceCategory.None)
			{
				this.ResourceCategoryDescriptions.Add(new ItemCategoryLocalization
				{
					Description = resourceCategory.ToString(),
					ResourceCategory = resourceCategory,
					Title = resourceCategory.ToString()
				});
			}
		}
		else
		{
			this.ResourceCategoryDescriptions.Add(new ItemCategoryLocalization());
		}
	}

	// Token: 0x06004481 RID: 17537 RVA: 0x001BC06C File Offset: 0x001BA46C
	public void AddNewUnit()
	{
		List<UnitClass> enumValues = ItemExtensions.GetEnumValues<UnitClass>();
		if (this.UnitDescriptions.Any<UnitLocalization>())
		{
			List<UnitClass> source = (from r in enumValues
			where this.UnitDescriptions.All((UnitLocalization i) => i.UnitClass != r)
			orderby r
			select r).ToList<UnitClass>();
			UnitClass unitClass = source.FirstOrDefault<UnitClass>();
			if (unitClass != (UnitClass)0)
			{
				this.UnitDescriptions.Add(new UnitLocalization
				{
					Description = unitClass.ToString(),
					UnitClass = unitClass,
					Title = unitClass.ToString()
				});
				this.AddNewUnit();
			}
		}
		else
		{
			this.UnitDescriptions.Add(new UnitLocalization());
		}
	}

	// Token: 0x06004482 RID: 17538 RVA: 0x001BC130 File Offset: 0x001BA530
	public void AddNewBuilding()
	{
		List<BuildingType> enumValues = ItemExtensions.GetEnumValues<BuildingType>();
		if (this.BuildingDescriptions.Any<BuildingLocalization>())
		{
			List<BuildingType> source = (from r in enumValues
			where this.BuildingDescriptions.All((BuildingLocalization i) => i.BuildingType != r)
			orderby r
			select r).ToList<BuildingType>();
			BuildingType buildingType = source.FirstOrDefault<BuildingType>();
			if (buildingType != BuildingType.None)
			{
				this.BuildingDescriptions.Add(new BuildingLocalization
				{
					Description = buildingType.ToString(),
					BuildingType = buildingType,
					Title = buildingType.ToString()
				});
			}
		}
		else
		{
			this.BuildingDescriptions.Add(new BuildingLocalization());
		}
	}

	// Token: 0x06004483 RID: 17539 RVA: 0x001BC1F0 File Offset: 0x001BA5F0
	public void AddNewAdventure()
	{
		List<AdventureType> enumValues = ItemExtensions.GetEnumValues<AdventureType>();
		if (this.AdventureDescriptions.Any<AdventureLocalization>())
		{
			List<AdventureType> source = (from r in enumValues
			where this.AdventureDescriptions.All((AdventureLocalization i) => i.AdventureType != r)
			orderby r
			select r).ToList<AdventureType>();
			AdventureType adventureType = source.FirstOrDefault<AdventureType>();
			if (adventureType != AdventureType.WoodenForest)
			{
				this.AdventureDescriptions.Add(new AdventureLocalization
				{
					Description = adventureType.ToString(),
					AdventureType = adventureType,
					Title = adventureType.ToString()
				});
			}
		}
		else
		{
			this.AdventureDescriptions.Add(new AdventureLocalization());
		}
	}

	// Token: 0x06004484 RID: 17540 RVA: 0x001BC2B0 File Offset: 0x001BA6B0
	public void AddFaction()
	{
		List<GameFactionType> enumValues = ItemExtensions.GetEnumValues<GameFactionType>();
		if (this.FactionDescriptions.Any<FactionLocalization>())
		{
			List<GameFactionType> source = (from r in enumValues
			where this.FactionDescriptions.All((FactionLocalization i) => i.FactionType != r)
			orderby r
			select r).ToList<GameFactionType>();
			GameFactionType gameFactionType = source.FirstOrDefault<GameFactionType>();
			if (gameFactionType != GameFactionType.SystemProcess)
			{
				this.FactionDescriptions.Add(new FactionLocalization
				{
					Description = gameFactionType.ToString(),
					FactionType = gameFactionType,
					Title = gameFactionType.ToString()
				});
			}
		}
		else
		{
			this.FactionDescriptions.Add(new FactionLocalization());
		}
	}

	// Token: 0x06004485 RID: 17541 RVA: 0x001BC370 File Offset: 0x001BA770
	public void AddQuestRequirement()
	{
		List<QuestRequirementType> enumValues = ItemExtensions.GetEnumValues<QuestRequirementType>();
		if (this.QuestRequirementDescriptions.Any<QuestRequirementLocalization>())
		{
			List<QuestRequirementType> source = (from r in enumValues
			where this.QuestRequirementDescriptions.All((QuestRequirementLocalization i) => i.QuestRequirementType != r)
			orderby r
			select r).ToList<QuestRequirementType>();
			QuestRequirementType questRequirementType = source.FirstOrDefault<QuestRequirementType>();
			if (questRequirementType != QuestRequirementType.WeaponSale)
			{
				this.QuestRequirementDescriptions.Add(new QuestRequirementLocalization
				{
					Description = questRequirementType.ToString(),
					QuestRequirementType = questRequirementType,
					Title = questRequirementType.ToString()
				});
				this.AddQuestRequirement();
			}
		}
		else
		{
			this.QuestRequirementDescriptions.Add(new QuestRequirementLocalization());
		}
	}

	// Token: 0x06004486 RID: 17542 RVA: 0x001BC434 File Offset: 0x001BA834
	public void AddQuest()
	{
		List<QuestIdentifier> enumValues = ItemExtensions.GetEnumValues<QuestIdentifier>();
		if (this.QuestDescriptions.Any<QuestLocalization>())
		{
			List<QuestIdentifier> source = (from r in enumValues
			where this.QuestDescriptions.All((QuestLocalization i) => i.QuestIdentifier != r)
			orderby r
			select r).ToList<QuestIdentifier>();
			QuestIdentifier questIdentifier = source.FirstOrDefault<QuestIdentifier>();
			if (questIdentifier != QuestIdentifier.None)
			{
				this.QuestDescriptions.Add(new QuestLocalization
				{
					Description = questIdentifier.ToString(),
					QuestIdentifier = questIdentifier,
					Title = questIdentifier.ToString()
				});
				this.AddQuest();
			}
		}
		else
		{
			this.QuestDescriptions.Add(new QuestLocalization());
		}
	}

	// Token: 0x06004487 RID: 17543 RVA: 0x001BC4F8 File Offset: 0x001BA8F8
	public void AddDialog()
	{
		List<DialogIdentifier> enumValues = ItemExtensions.GetEnumValues<DialogIdentifier>();
		if (this.DialogDetails.Any<DialogDetails>())
		{
			List<DialogIdentifier> source = (from r in enumValues
			where this.DialogDetails.All((DialogDetails i) => i.Identifier != r)
			orderby r
			select r).ToList<DialogIdentifier>();
			DialogIdentifier dialogIdentifier = source.FirstOrDefault<DialogIdentifier>();
			if (dialogIdentifier != (DialogIdentifier)0)
			{
				this.DialogDetails.Add(new DialogDetails
				{
					Dialog = dialogIdentifier.ToString(),
					Identifier = dialogIdentifier
				});
				this.AddDialog();
			}
		}
		else
		{
			this.DialogDetails.Add(new DialogDetails());
		}
	}

	// Token: 0x06004488 RID: 17544 RVA: 0x001BC5AC File Offset: 0x001BA9AC
	public void AddStory()
	{
		List<StoryIdentifier> enumValues = ItemExtensions.GetEnumValues<StoryIdentifier>();
		if (this.StoryDetailses.Any<StoryDetails>())
		{
			List<StoryIdentifier> source = (from r in enumValues
			where this.StoryDetailses.All((StoryDetails i) => i.Identifier != r)
			orderby r
			select r).ToList<StoryIdentifier>();
			StoryIdentifier storyIdentifier = source.FirstOrDefault<StoryIdentifier>();
			if (storyIdentifier != StoryIdentifier.NewDayAgain1)
			{
				this.StoryDetailses.Add(new StoryDetails
				{
					Details = storyIdentifier.ToString(),
					Identifier = storyIdentifier
				});
				this.AddStory();
			}
		}
		else
		{
			this.StoryDetailses.Add(new StoryDetails());
		}
	}

	// Token: 0x06004489 RID: 17545 RVA: 0x001BC660 File Offset: 0x001BAA60
	public void AddManualItem()
	{
		List<ManualType> enumValues = ItemExtensions.GetEnumValues<ManualType>();
		if (this.ManualLocalizations.Any<ManualLocalization>())
		{
			List<ManualType> source = (from r in enumValues
			where this.ManualLocalizations.All((ManualLocalization i) => i.ManualType != r)
			orderby r
			select r).ToList<ManualType>();
			ManualType manualType = source.FirstOrDefault<ManualType>();
			if (manualType != (ManualType)0)
			{
				this.ManualLocalizations.Add(new ManualLocalization
				{
					ManualType = manualType,
					Name = manualType.ToString(),
					Description = manualType.ToString()
				});
				this.AddManualItem();
			}
		}
		else
		{
			this.ManualLocalizations.Add(new ManualLocalization());
		}
	}

	// Token: 0x0600448A RID: 17546 RVA: 0x001BC724 File Offset: 0x001BAB24
	public void AddUiComponent()
	{
		List<UIComponentType> enumValues = ItemExtensions.GetEnumValues<UIComponentType>();
		if (this.UiLocalizations.Any<UILocalization>())
		{
			List<UIComponentType> source = (from r in enumValues
			where this.UiLocalizations.All((UILocalization i) => i.UiComponentType != r)
			orderby r
			select r).ToList<UIComponentType>();
			UIComponentType uicomponentType = source.FirstOrDefault<UIComponentType>();
			if (uicomponentType != (UIComponentType)0)
			{
				this.UiLocalizations.Add(new UILocalization
				{
					Name = uicomponentType.ToString(),
					UiComponentType = uicomponentType
				});
			}
		}
		else
		{
			this.UiLocalizations.Add(new UILocalization());
		}
	}

	// Token: 0x0600448B RID: 17547 RVA: 0x001BC7D0 File Offset: 0x001BABD0
	public void AddAttribute()
	{
		List<AttributeType> enumValues = ItemExtensions.GetEnumValues<AttributeType>();
		if (this.AttributeLocalizations.Any<AttributeLocalization>())
		{
			List<AttributeType> source = (from r in enumValues
			where this.AttributeLocalizations.All((AttributeLocalization i) => i.AttributeType != r)
			orderby r
			select r).ToList<AttributeType>();
			AttributeType attributeType = source.FirstOrDefault<AttributeType>();
			if (attributeType != AttributeType.None)
			{
				this.AttributeLocalizations.Add(new AttributeLocalization
				{
					Name = attributeType.ToString(),
					AttributeType = attributeType,
					Description = attributeType.ToString()
				});
				this.AddAttribute();
			}
		}
		else
		{
			this.AttributeLocalizations.Add(new AttributeLocalization());
		}
	}

	// Token: 0x0600448C RID: 17548 RVA: 0x001BC894 File Offset: 0x001BAC94
	public void AddResidentType()
	{
		List<ResidentType> enumValues = ItemExtensions.GetEnumValues<ResidentType>();
		if (this.ResidentLocalizations.Any<ResidentLocalization>())
		{
			List<ResidentType> source = (from r in enumValues
			where this.ResidentLocalizations.All((ResidentLocalization i) => i.ResidentType != r)
			orderby r
			select r).ToList<ResidentType>();
			ResidentType residentType = source.FirstOrDefault<ResidentType>();
			if (residentType != ResidentType.Traveller)
			{
				this.ResidentLocalizations.Add(new ResidentLocalization
				{
					Name = residentType.ToString(),
					ResidentType = residentType,
					Description = residentType.ToString()
				});
				this.AddResidentType();
			}
		}
		else
		{
			this.ResidentLocalizations.Add(new ResidentLocalization());
		}
	}

	// Token: 0x0600448D RID: 17549 RVA: 0x001BC958 File Offset: 0x001BAD58
	public void AddSpecialEffect()
	{
		List<SpecialEffectType> enumValues = ItemExtensions.GetEnumValues<SpecialEffectType>();
		if (this.SpecialEffectLocalizations.Any<SpecialEffectLocalization>())
		{
			List<SpecialEffectType> source = (from r in enumValues
			where this.SpecialEffectLocalizations.All((SpecialEffectLocalization i) => i.SpecialEffectType != r)
			orderby r
			select r).ToList<SpecialEffectType>();
			SpecialEffectType specialEffectType = source.FirstOrDefault<SpecialEffectType>();
			if (specialEffectType != SpecialEffectType.None)
			{
				this.SpecialEffectLocalizations.Add(new SpecialEffectLocalization
				{
					Name = specialEffectType.ToString(),
					SpecialEffectType = specialEffectType,
					Description = specialEffectType.ToString()
				});
				this.AddSpecialEffect();
			}
		}
		else
		{
			this.SpecialEffectLocalizations.Add(new SpecialEffectLocalization());
		}
	}

	// Token: 0x0600448E RID: 17550 RVA: 0x001BCA1C File Offset: 0x001BAE1C
	public void AddGrowthCondition()
	{
		List<GrowthConditionType> enumValues = ItemExtensions.GetEnumValues<GrowthConditionType>();
		if (this.GrowthConditionLocalizations.Any<GrowthSpecialEffectConditionLocalization>())
		{
			List<GrowthConditionType> source = (from r in enumValues
			where this.GrowthConditionLocalizations.All((GrowthSpecialEffectConditionLocalization i) => i.ConditionType != r)
			orderby r
			select r).ToList<GrowthConditionType>();
			GrowthConditionType growthConditionType = source.FirstOrDefault<GrowthConditionType>();
			if (growthConditionType != GrowthConditionType.DealDamage)
			{
				this.GrowthConditionLocalizations.Add(new GrowthSpecialEffectConditionLocalization
				{
					Name = growthConditionType.ToString(),
					ConditionType = growthConditionType,
					Description = growthConditionType.ToString()
				});
				this.AddGrowthCondition();
			}
		}
		else
		{
			this.GrowthConditionLocalizations.Add(new GrowthSpecialEffectConditionLocalization());
		}
	}

	// Token: 0x0600448F RID: 17551 RVA: 0x001BCAE0 File Offset: 0x001BAEE0
	public void AddItemGrade()
	{
		List<QualityGrade> enumValues = ItemExtensions.GetEnumValues<QualityGrade>();
		if (this.ItemGradeLocalizations.Any<ItemGradeLocalization>())
		{
			List<QualityGrade> source = (from r in enumValues
			where this.ItemGradeLocalizations.All((ItemGradeLocalization i) => i.Grade != r)
			orderby r
			select r).ToList<QualityGrade>();
			QualityGrade qualityGrade = source.FirstOrDefault<QualityGrade>();
			if (qualityGrade != (QualityGrade)0)
			{
				this.ItemGradeLocalizations.Add(new ItemGradeLocalization
				{
					Name = qualityGrade.ToString(),
					Grade = qualityGrade,
					Description = qualityGrade.ToString()
				});
				this.AddItemGrade();
			}
		}
		else
		{
			this.ItemGradeLocalizations.Add(new ItemGradeLocalization());
		}
	}

	// Token: 0x06004490 RID: 17552 RVA: 0x001BCBA4 File Offset: 0x001BAFA4
	public void AddQuestRewardType()
	{
		List<RewardType> enumValues = ItemExtensions.GetEnumValues<RewardType>();
		if (this.RewardTypeLocalizations.Any<RewardTypeLocalization>())
		{
			List<RewardType> source = (from r in enumValues
			where this.RewardTypeLocalizations.All((RewardTypeLocalization i) => i.RewardType != r)
			orderby r
			select r).ToList<RewardType>();
			RewardType rewardType = source.FirstOrDefault<RewardType>();
			if (rewardType != RewardType.GuaranteedDirectResource)
			{
				this.RewardTypeLocalizations.Add(new RewardTypeLocalization
				{
					Name = rewardType.ToString(),
					RewardType = rewardType,
					Description = rewardType.ToString()
				});
				this.AddQuestRewardType();
			}
		}
		else
		{
			this.RewardTypeLocalizations.Add(new RewardTypeLocalization());
		}
	}

	// Token: 0x06004491 RID: 17553 RVA: 0x001BCC68 File Offset: 0x001BB068
	public void AddQuestChain()
	{
		List<QuestChainIdentifier> enumValues = ItemExtensions.GetEnumValues<QuestChainIdentifier>();
		if (this.QuestChainLocalizations.Any<QuestChainLocalization>())
		{
			List<QuestChainIdentifier> source = (from r in enumValues
			where this.QuestChainLocalizations.All((QuestChainLocalization i) => i.QuestChainIdentifier != r)
			orderby r
			select r).ToList<QuestChainIdentifier>();
			QuestChainIdentifier questChainIdentifier = source.FirstOrDefault<QuestChainIdentifier>();
			if (questChainIdentifier != QuestChainIdentifier.MainChapterOne)
			{
				this.QuestChainLocalizations.Add(new QuestChainLocalization
				{
					Name = questChainIdentifier.ToString(),
					QuestChainIdentifier = questChainIdentifier,
					Description = questChainIdentifier.ToString()
				});
				this.AddQuestChain();
			}
		}
		else
		{
			this.QuestChainLocalizations.Add(new QuestChainLocalization());
		}
	}

	// Token: 0x06004492 RID: 17554 RVA: 0x001BCD2C File Offset: 0x001BB12C
	public void AddUnitCategory()
	{
		List<ClassCategory> enumValues = ItemExtensions.GetEnumValues<ClassCategory>();
		if (this.UnitCategoryLocalizations.Any<UnitCategoryLocalization>())
		{
			List<ClassCategory> source = (from r in enumValues
			where this.UnitCategoryLocalizations.All((UnitCategoryLocalization i) => i.ClassCategoryIdentifier != r)
			orderby r
			select r).ToList<ClassCategory>();
			ClassCategory classCategory = source.FirstOrDefault<ClassCategory>();
			if (classCategory != (ClassCategory)0)
			{
				this.UnitCategoryLocalizations.Add(new UnitCategoryLocalization
				{
					Name = classCategory.ToString(),
					ClassCategoryIdentifier = classCategory,
					Description = classCategory.ToString()
				});
				this.AddUnitCategory();
			}
		}
		else
		{
			this.UnitCategoryLocalizations.Add(new UnitCategoryLocalization());
		}
	}

	// Token: 0x06004493 RID: 17555 RVA: 0x001BCDF0 File Offset: 0x001BB1F0
	public void AddBattleEvent()
	{
		List<AdventureEventType> enumValues = ItemExtensions.GetEnumValues<AdventureEventType>();
		if (this.BattleEventLocalizations.Any<BattleEventLocalization>())
		{
			List<AdventureEventType> source = (from r in enumValues
			where this.BattleEventLocalizations.All((BattleEventLocalization i) => i.EventType != r)
			orderby r
			select r).ToList<AdventureEventType>();
			AdventureEventType adventureEventType = source.FirstOrDefault<AdventureEventType>();
			if (adventureEventType != AdventureEventType.AdventureInitialized)
			{
				this.BattleEventLocalizations.Add(new BattleEventLocalization
				{
					Name = adventureEventType.ToString(),
					EventType = adventureEventType,
					Description = adventureEventType.ToString()
				});
				this.AddBattleEvent();
			}
		}
		else
		{
			this.BattleEventLocalizations.Add(new BattleEventLocalization());
		}
	}

	// Token: 0x06004494 RID: 17556 RVA: 0x001BCEB4 File Offset: 0x001BB2B4
	public void AddOutputType()
	{
		List<OutputType> enumValues = ItemExtensions.GetEnumValues<OutputType>();
		if (this.OutputLocalizations.Any<OutputTypeLocalization>())
		{
			List<OutputType> source = (from r in enumValues
			where this.OutputLocalizations.All((OutputTypeLocalization i) => i.OutputType != r)
			orderby r
			select r).ToList<OutputType>();
			OutputType outputType = source.FirstOrDefault<OutputType>();
			if (outputType != OutputType.None)
			{
				this.OutputLocalizations.Add(new OutputTypeLocalization
				{
					Name = outputType.ToString(),
					OutputType = outputType,
					Description = outputType.ToString()
				});
				this.AddOutputType();
			}
		}
		else
		{
			this.OutputLocalizations.Add(new OutputTypeLocalization());
		}
	}

	// Token: 0x06004495 RID: 17557 RVA: 0x001BCF78 File Offset: 0x001BB378
	public void AddBoostType()
	{
		List<BoostType> enumValues = ItemExtensions.GetEnumValues<BoostType>();
		if (this.BoostTypeLocalizations.Any<BoostTypeLocalization>())
		{
			List<BoostType> source = (from r in enumValues
			where this.BoostTypeLocalizations.All((BoostTypeLocalization i) => i.BoostType != r)
			orderby r
			select r).ToList<BoostType>();
			BoostType boostType = source.FirstOrDefault<BoostType>();
			if (boostType != BoostType.Output)
			{
				this.BoostTypeLocalizations.Add(new BoostTypeLocalization
				{
					Name = boostType.ToString(),
					BoostType = boostType,
					Description = boostType.ToString()
				});
				this.AddBoostType();
			}
		}
		else
		{
			this.BoostTypeLocalizations.Add(new BoostTypeLocalization());
		}
	}

	// Token: 0x06004496 RID: 17558 RVA: 0x001BD03C File Offset: 0x001BB43C
	public void AddTargetCandidateType()
	{
		List<TargetCandidateType> enumValues = ItemExtensions.GetEnumValues<TargetCandidateType>();
		if (this.TargetCandidateTypeLocalizations.Any<TargetCandidateTypeLocalization>())
		{
			List<TargetCandidateType> source = (from r in enumValues
			where this.TargetCandidateTypeLocalizations.All((TargetCandidateTypeLocalization i) => i.TargetCandidateType != r)
			orderby r
			select r).ToList<TargetCandidateType>();
			TargetCandidateType targetCandidateType = source.FirstOrDefault<TargetCandidateType>();
			if (targetCandidateType != TargetCandidateType.None)
			{
				this.TargetCandidateTypeLocalizations.Add(new TargetCandidateTypeLocalization
				{
					Name = targetCandidateType.ToString(),
					TargetCandidateType = targetCandidateType,
					Description = targetCandidateType.ToString()
				});
				this.AddTargetCandidateType();
			}
		}
		else
		{
			this.TargetCandidateTypeLocalizations.Add(new TargetCandidateTypeLocalization());
		}
	}

	// Token: 0x06004497 RID: 17559 RVA: 0x001BD100 File Offset: 0x001BB500
	public void AddTownTitle()
	{
		List<TownTitleType> enumValues = ItemExtensions.GetEnumValues<TownTitleType>();
		if (this.TownTitleLocalizations.Any<TownTitleLocalization>())
		{
			List<TownTitleType> source = (from r in enumValues
			where this.TownTitleLocalizations.All((TownTitleLocalization i) => i.TownTitleType != r)
			orderby r
			select r).ToList<TownTitleType>();
			TownTitleType townTitleType = source.FirstOrDefault<TownTitleType>();
			if (townTitleType != TownTitleType.None)
			{
				this.TownTitleLocalizations.Add(new TownTitleLocalization
				{
					Name = townTitleType.ToString(),
					TownTitleType = townTitleType,
					Description = townTitleType.ToString()
				});
				this.AddTownTitle();
			}
		}
		else
		{
			this.TownTitleLocalizations.Add(new TownTitleLocalization());
		}
	}

	// Token: 0x06004498 RID: 17560 RVA: 0x001BD1C4 File Offset: 0x001BB5C4
	public void AddMonsterSlot()
	{
		List<AdventureEncounterSlotType> enumValues = ItemExtensions.GetEnumValues<AdventureEncounterSlotType>();
		if (this.MonsterSlotLocalizations.Any<MonsterSlotLocalization>())
		{
			List<AdventureEncounterSlotType> source = (from r in enumValues
			where this.MonsterSlotLocalizations.All((MonsterSlotLocalization i) => i.SlotType != r)
			orderby r
			select r).ToList<AdventureEncounterSlotType>();
			AdventureEncounterSlotType adventureEncounterSlotType = source.FirstOrDefault<AdventureEncounterSlotType>();
			if (adventureEncounterSlotType != AdventureEncounterSlotType.Minion)
			{
				this.MonsterSlotLocalizations.Add(new MonsterSlotLocalization
				{
					Name = adventureEncounterSlotType.ToString(),
					SlotType = adventureEncounterSlotType,
					Description = adventureEncounterSlotType.ToString()
				});
				this.AddMonsterSlot();
			}
		}
		else
		{
			this.MonsterSlotLocalizations.Add(new MonsterSlotLocalization());
		}
	}

	// Token: 0x06004499 RID: 17561 RVA: 0x001BD288 File Offset: 0x001BB688
	public void AddAttributeModificationType()
	{
		List<ModificationType> enumValues = ItemExtensions.GetEnumValues<ModificationType>();
		if (this.AttributeModificationTypeLocalizations.Any<AttributeModificationTypeLocalization>())
		{
			List<ModificationType> source = (from r in enumValues
			where this.AttributeModificationTypeLocalizations.All((AttributeModificationTypeLocalization i) => i.ModificationType != r)
			orderby r
			select r).ToList<ModificationType>();
			ModificationType modificationType = source.FirstOrDefault<ModificationType>();
			if (modificationType != (ModificationType)0)
			{
				this.AttributeModificationTypeLocalizations.Add(new AttributeModificationTypeLocalization
				{
					Name = modificationType.ToString(),
					ModificationType = modificationType,
					Description = modificationType.ToString()
				});
				this.AddAttributeModificationType();
			}
		}
		else
		{
			this.AttributeModificationTypeLocalizations.Add(new AttributeModificationTypeLocalization());
		}
	}

	// Token: 0x0600449A RID: 17562 RVA: 0x001BD34C File Offset: 0x001BB74C
	public void AddSocketType()
	{
		List<SocketType> enumValues = ItemExtensions.GetEnumValues<SocketType>();
		if (this.SocketTypeLocalizations.Any<SocketTypeLocalization>())
		{
			List<SocketType> source = (from r in enumValues
			where this.SocketTypeLocalizations.All((SocketTypeLocalization i) => i.SocketType != r)
			orderby r
			select r).ToList<SocketType>();
			SocketType socketType = source.FirstOrDefault<SocketType>();
			if (socketType != SocketType.All)
			{
				this.SocketTypeLocalizations.Add(new SocketTypeLocalization
				{
					Name = socketType.ToString(),
					SocketType = socketType,
					Description = socketType.ToString()
				});
				this.AddSocketType();
			}
		}
		else
		{
			this.SocketTypeLocalizations.Add(new SocketTypeLocalization());
		}
	}

	// Token: 0x0600449B RID: 17563 RVA: 0x001BD410 File Offset: 0x001BB810
	public void AddResidentEffect()
	{
		List<ResidentEffectType> enumValues = ItemExtensions.GetEnumValues<ResidentEffectType>();
		if (this.ResidentEffectLocalizations.Any<ResidentEffectLocalization>())
		{
			List<ResidentEffectType> source = (from r in enumValues
			where this.ResidentEffectLocalizations.All((ResidentEffectLocalization i) => i.EffectType != r)
			orderby r
			select r).ToList<ResidentEffectType>();
			ResidentEffectType residentEffectType = source.FirstOrDefault<ResidentEffectType>();
			if (residentEffectType != ResidentEffectType.Production)
			{
				this.ResidentEffectLocalizations.Add(new ResidentEffectLocalization
				{
					Name = residentEffectType.ToString(),
					EffectType = residentEffectType,
					Description = residentEffectType.ToString()
				});
				this.AddResidentEffect();
			}
		}
		else
		{
			this.ResidentEffectLocalizations.Add(new ResidentEffectLocalization());
		}
	}

	// Token: 0x0600449C RID: 17564 RVA: 0x001BD4D4 File Offset: 0x001BB8D4
	public void AddUpgradeCard()
	{
		List<UpgradeCardType> enumValues = ItemExtensions.GetEnumValues<UpgradeCardType>();
		if (this.UpgradeCardLocalizations.Any<UpgradeCardLocalization>())
		{
			List<UpgradeCardType> source = (from r in enumValues
			where this.UpgradeCardLocalizations.All((UpgradeCardLocalization i) => i.Type != r)
			orderby r
			select r).ToList<UpgradeCardType>();
			UpgradeCardType upgradeCardType = source.FirstOrDefault<UpgradeCardType>();
			if (upgradeCardType != (UpgradeCardType)0)
			{
				this.UpgradeCardLocalizations.Add(new UpgradeCardLocalization
				{
					Name = upgradeCardType.ToString(),
					Type = upgradeCardType,
					Description = upgradeCardType.ToString()
				});
				this.AddUpgradeCard();
			}
		}
		else
		{
			this.UpgradeCardLocalizations.Add(new UpgradeCardLocalization());
		}
	}

	// Token: 0x0600449D RID: 17565 RVA: 0x001BD598 File Offset: 0x001BB998
	public void AddBattleOption()
	{
		List<BattleOptionType> enumValues = ItemExtensions.GetEnumValues<BattleOptionType>();
		if (this.BattleOptionLocalizations.Any<BattleOptionLocalization>())
		{
			List<BattleOptionType> source = (from r in enumValues
			where this.BattleOptionLocalizations.All((BattleOptionLocalization i) => i.Type != r)
			orderby r
			select r).ToList<BattleOptionType>();
			BattleOptionType battleOptionType = source.FirstOrDefault<BattleOptionType>();
			if (battleOptionType != (BattleOptionType)0)
			{
				this.BattleOptionLocalizations.Add(new BattleOptionLocalization
				{
					Name = battleOptionType.ToString(),
					Type = battleOptionType,
					Description = battleOptionType.ToString()
				});
				this.AddBattleOption();
			}
		}
		else
		{
			this.BattleOptionLocalizations.Add(new BattleOptionLocalization());
		}
	}

	// Token: 0x0600449E RID: 17566 RVA: 0x001BD65C File Offset: 0x001BBA5C
	public void AddVehicle()
	{
		List<VehicleType> enumValues = ItemExtensions.GetEnumValues<VehicleType>();
		if (this.VehicleLocalizations.Any<VehicleLocalization>())
		{
			List<VehicleType> source = (from r in enumValues
			where this.VehicleLocalizations.All((VehicleLocalization i) => i.Type != r)
			orderby r
			select r).ToList<VehicleType>();
			VehicleType vehicleType = source.FirstOrDefault<VehicleType>();
			if (vehicleType != (VehicleType)0)
			{
				this.VehicleLocalizations.Add(new VehicleLocalization
				{
					Name = vehicleType.ToString(),
					Type = vehicleType,
					Description = vehicleType.ToString()
				});
				this.AddVehicle();
			}
		}
		else
		{
			this.VehicleLocalizations.Add(new VehicleLocalization());
		}
	}

	// Token: 0x0600449F RID: 17567 RVA: 0x001BD720 File Offset: 0x001BBB20
	public void AddJourneyContribution()
	{
		List<JourneyContributeType> enumValues = ItemExtensions.GetEnumValues<JourneyContributeType>();
		if (this.JourneyContributionLocalizations.Any<JourneyContributionLocalization>())
		{
			List<JourneyContributeType> source = (from r in enumValues
			where this.JourneyContributionLocalizations.All((JourneyContributionLocalization i) => i.Type != r)
			orderby r
			select r).ToList<JourneyContributeType>();
			JourneyContributeType journeyContributeType = source.FirstOrDefault<JourneyContributeType>();
			if (journeyContributeType != (JourneyContributeType)0)
			{
				this.JourneyContributionLocalizations.Add(new JourneyContributionLocalization
				{
					Name = journeyContributeType.ToString(),
					Type = journeyContributeType,
					Description = journeyContributeType.ToString()
				});
				this.AddJourneyContribution();
			}
		}
		else
		{
			this.JourneyContributionLocalizations.Add(new JourneyContributionLocalization());
		}
	}

	// Token: 0x060044A0 RID: 17568 RVA: 0x001BD7E4 File Offset: 0x001BBBE4
	public void AddVehicleAttribute()
	{
		List<VehicleAttributeType> enumValues = ItemExtensions.GetEnumValues<VehicleAttributeType>();
		if (this.VehicleAttributeLocalizations.Any<VehicleAttributeLocalization>())
		{
			List<VehicleAttributeType> source = (from r in enumValues
			where this.VehicleAttributeLocalizations.All((VehicleAttributeLocalization i) => i.Type != r)
			orderby r
			select r).ToList<VehicleAttributeType>();
			VehicleAttributeType vehicleAttributeType = source.FirstOrDefault<VehicleAttributeType>();
			if (vehicleAttributeType != (VehicleAttributeType)0)
			{
				this.VehicleAttributeLocalizations.Add(new VehicleAttributeLocalization
				{
					Name = vehicleAttributeType.ToString(),
					Type = vehicleAttributeType,
					Description = vehicleAttributeType.ToString()
				});
				this.AddVehicleAttribute();
			}
		}
		else
		{
			this.VehicleAttributeLocalizations.Add(new VehicleAttributeLocalization());
		}
	}

	// Token: 0x060044A1 RID: 17569 RVA: 0x001BD8A8 File Offset: 0x001BBCA8
	public void AddTripEncounter()
	{
		List<TripEncounterType> enumValues = ItemExtensions.GetEnumValues<TripEncounterType>();
		if (this.TripEncounterLocalizations.Any<TripEncounterLocalization>())
		{
			List<TripEncounterType> source = (from r in enumValues
			where this.TripEncounterLocalizations.All((TripEncounterLocalization i) => i.Type != r)
			orderby r
			select r).ToList<TripEncounterType>();
			TripEncounterType tripEncounterType = source.FirstOrDefault<TripEncounterType>();
			if (tripEncounterType != (TripEncounterType)0)
			{
				this.TripEncounterLocalizations.Add(new TripEncounterLocalization
				{
					Name = tripEncounterType.ToString(),
					Type = tripEncounterType,
					Description = tripEncounterType.ToString()
				});
				this.AddTripEncounter();
			}
		}
		else
		{
			this.TripEncounterLocalizations.Add(new TripEncounterLocalization());
		}
	}

	// Token: 0x060044A2 RID: 17570 RVA: 0x001BD96C File Offset: 0x001BBD6C
	public void AddTripEncounterOutcome()
	{
		List<TripEncounterOutcomeType> enumValues = ItemExtensions.GetEnumValues<TripEncounterOutcomeType>();
		if (this.TripOutcomeLocalizations.Any<TripOutcomeLocalization>())
		{
			List<TripEncounterOutcomeType> source = (from r in enumValues
			where this.TripOutcomeLocalizations.All((TripOutcomeLocalization i) => i.Type != r)
			orderby r
			select r).ToList<TripEncounterOutcomeType>();
			TripEncounterOutcomeType tripEncounterOutcomeType = source.FirstOrDefault<TripEncounterOutcomeType>();
			if (tripEncounterOutcomeType != (TripEncounterOutcomeType)0)
			{
				this.TripOutcomeLocalizations.Add(new TripOutcomeLocalization
				{
					Name = tripEncounterOutcomeType.ToString(),
					Type = tripEncounterOutcomeType,
					Description = tripEncounterOutcomeType.ToString()
				});
				this.AddTripEncounterOutcome();
			}
		}
		else
		{
			this.TripOutcomeLocalizations.Add(new TripOutcomeLocalization());
		}
	}

	// Token: 0x060044A3 RID: 17571 RVA: 0x001BDA30 File Offset: 0x001BBE30
	public void AddDestination()
	{
		List<DestinationType> enumValues = ItemExtensions.GetEnumValues<DestinationType>();
		if (this.DestinationLocalizations.Any<DestinationLocalization>())
		{
			List<DestinationType> source = (from r in enumValues
			where this.DestinationLocalizations.All((DestinationLocalization i) => i.Type != r)
			orderby r
			select r).ToList<DestinationType>();
			DestinationType destinationType = source.FirstOrDefault<DestinationType>();
			if (destinationType != (DestinationType)0)
			{
				this.DestinationLocalizations.Add(new DestinationLocalization
				{
					Name = destinationType.ToString(),
					Type = destinationType,
					Description = destinationType.ToString()
				});
				this.AddDestination();
			}
		}
		else
		{
			this.DestinationLocalizations.Add(new DestinationLocalization());
		}
	}

	// Token: 0x060044A4 RID: 17572 RVA: 0x001BDAF4 File Offset: 0x001BBEF4
	public void AddUnitStyle()
	{
		List<UnitClassStyle> enumValues = ItemExtensions.GetEnumValues<UnitClassStyle>();
		if (this.UnitStyleLocalizations.Any<UnitStyleLocalization>())
		{
			List<UnitClassStyle> source = (from r in enumValues
			where this.UnitStyleLocalizations.All((UnitStyleLocalization i) => i.Type != r)
			orderby r
			select r).ToList<UnitClassStyle>();
			UnitClassStyle unitClassStyle = source.FirstOrDefault<UnitClassStyle>();
			if (unitClassStyle != UnitClassStyle.None)
			{
				this.UnitStyleLocalizations.Add(new UnitStyleLocalization
				{
					Name = unitClassStyle.ToString(),
					Type = unitClassStyle,
					Description = unitClassStyle.ToString()
				});
				this.AddUnitStyle();
			}
		}
		else
		{
			this.UnitStyleLocalizations.Add(new UnitStyleLocalization());
		}
	}

	// Token: 0x060044A5 RID: 17573 RVA: 0x001BDBB8 File Offset: 0x001BBFB8
	public void AddTalent()
	{
		List<AdventurerTalentType> enumValues = ItemExtensions.GetEnumValues<AdventurerTalentType>();
		if (this.TalentLocalizations.Any<TalentLocalization>())
		{
			List<AdventurerTalentType> source = (from r in enumValues
			where this.TalentLocalizations.All((TalentLocalization i) => i.Type != r)
			orderby r
			select r).ToList<AdventurerTalentType>();
			AdventurerTalentType adventurerTalentType = source.FirstOrDefault<AdventurerTalentType>();
			if (adventurerTalentType != (AdventurerTalentType)0)
			{
				this.TalentLocalizations.Add(new TalentLocalization
				{
					Name = adventurerTalentType.ToString(),
					Type = adventurerTalentType,
					Description = adventurerTalentType.ToString()
				});
				this.AddTalent();
			}
		}
		else
		{
			this.TalentLocalizations.Add(new TalentLocalization());
		}
	}

	// Token: 0x060044A6 RID: 17574 RVA: 0x001BDC7C File Offset: 0x001BC07C
	public void AddTownEvent()
	{
		List<TownEventType> enumValues = ItemExtensions.GetEnumValues<TownEventType>();
		if (this.TownEventLocalizaitons.Any<TownEventLocalizaiton>())
		{
			List<TownEventType> source = (from r in enumValues
			where this.TownEventLocalizaitons.All((TownEventLocalizaiton i) => i.Type != r)
			orderby r
			select r).ToList<TownEventType>();
			TownEventType townEventType = source.FirstOrDefault<TownEventType>();
			if (townEventType != (TownEventType)0)
			{
				this.TownEventLocalizaitons.Add(new TownEventLocalizaiton
				{
					Name = townEventType.ToString(),
					Type = townEventType,
					Description = townEventType.ToString()
				});
				this.AddTownEvent();
			}
		}
		else
		{
			this.TownEventLocalizaitons.Add(new TownEventLocalizaiton());
		}
	}

	// Token: 0x060044A7 RID: 17575 RVA: 0x001BDD40 File Offset: 0x001BC140
	public void AddTownEffect()
	{
		List<TownEffectType> enumValues = ItemExtensions.GetEnumValues<TownEffectType>();
		if (this.TownEffectLocalizations.Any<TownEffectLocalization>())
		{
			List<TownEffectType> source = (from r in enumValues
			where this.TownEffectLocalizations.All((TownEffectLocalization i) => i.Type != r)
			orderby r
			select r).ToList<TownEffectType>();
			TownEffectType townEffectType = source.FirstOrDefault<TownEffectType>();
			if (townEffectType != (TownEffectType)0)
			{
				this.TownEffectLocalizations.Add(new TownEffectLocalization
				{
					Name = townEffectType.ToString(),
					Type = townEffectType,
					Description = townEffectType.ToString()
				});
				this.AddTownEffect();
			}
		}
		else
		{
			this.TownEffectLocalizations.Add(new TownEffectLocalization());
		}
	}

	// Token: 0x060044A8 RID: 17576 RVA: 0x001BDE04 File Offset: 0x001BC204
	public void AddCandidateMetric()
	{
		List<CandidateOrderringMetric> enumValues = ItemExtensions.GetEnumValues<CandidateOrderringMetric>();
		if (this.CandidateOrderMetricLocalizations.Any<CandidateOrderMetricLocalization>())
		{
			List<CandidateOrderringMetric> source = (from r in enumValues
			where this.CandidateOrderMetricLocalizations.All((CandidateOrderMetricLocalization i) => i.Type != r)
			orderby r
			select r).ToList<CandidateOrderringMetric>();
			CandidateOrderringMetric candidateOrderringMetric = source.FirstOrDefault<CandidateOrderringMetric>();
			if (candidateOrderringMetric != CandidateOrderringMetric.Random)
			{
				this.CandidateOrderMetricLocalizations.Add(new CandidateOrderMetricLocalization
				{
					Name = candidateOrderringMetric.ToString(),
					Type = candidateOrderringMetric,
					Description = candidateOrderringMetric.ToString()
				});
				this.AddCandidateMetric();
			}
		}
		else
		{
			this.CandidateOrderMetricLocalizations.Add(new CandidateOrderMetricLocalization());
		}
	}

	// Token: 0x060044A9 RID: 17577 RVA: 0x001BDEC8 File Offset: 0x001BC2C8
	public void AddOrderType()
	{
		List<OrderingType> enumValues = ItemExtensions.GetEnumValues<OrderingType>();
		if (this.OrderTypeLocalizations.Any<OrderTypeLocalization>())
		{
			List<OrderingType> source = (from r in enumValues
			where this.OrderTypeLocalizations.All((OrderTypeLocalization i) => i.Type != r)
			orderby r
			select r).ToList<OrderingType>();
			OrderingType orderingType = source.FirstOrDefault<OrderingType>();
			if (orderingType != (OrderingType)0)
			{
				this.OrderTypeLocalizations.Add(new OrderTypeLocalization
				{
					Name = orderingType.ToString(),
					Type = orderingType,
					Description = orderingType.ToString()
				});
				this.AddOrderType();
			}
		}
		else
		{
			this.OrderTypeLocalizations.Add(new OrderTypeLocalization());
		}
	}

	// Token: 0x060044AA RID: 17578 RVA: 0x001BDF8C File Offset: 0x001BC38C
	[CompilerGenerated]
	private bool <AddNewSkill>m__0(SkillType sk)
	{
		return this.SkillDescriptions.All((SkillLocalization esk) => esk.SkillType != sk);
	}

	// Token: 0x060044AB RID: 17579 RVA: 0x001BDFC0 File Offset: 0x001BC3C0
	[CompilerGenerated]
	private bool <AddNewEffect>m__1(BattleEffectType r)
	{
		return this.EffectDescriptions.All((EffectLocalization i) => i.BattleEffectType != r);
	}

	// Token: 0x060044AC RID: 17580 RVA: 0x001BDFF1 File Offset: 0x001BC3F1
	[CompilerGenerated]
	private static BattleEffectType <AddNewEffect>m__2(BattleEffectType r)
	{
		return r;
	}

	// Token: 0x060044AD RID: 17581 RVA: 0x001BDFF4 File Offset: 0x001BC3F4
	[CompilerGenerated]
	private bool <AddNewItem>m__3(ResourceType r)
	{
		return this.ItemDescriptions.All((ResourceLocalization i) => i.ItemType != r);
	}

	// Token: 0x060044AE RID: 17582 RVA: 0x001BE025 File Offset: 0x001BC425
	[CompilerGenerated]
	private static ResourceType <AddNewItem>m__4(ResourceType r)
	{
		return r;
	}

	// Token: 0x060044AF RID: 17583 RVA: 0x001BE028 File Offset: 0x001BC428
	[CompilerGenerated]
	private bool <AddNewItemCategory>m__5(ResourceCategory r)
	{
		return this.ResourceCategoryDescriptions.All((ItemCategoryLocalization i) => i.ResourceCategory != r);
	}

	// Token: 0x060044B0 RID: 17584 RVA: 0x001BE059 File Offset: 0x001BC459
	[CompilerGenerated]
	private static ResourceCategory <AddNewItemCategory>m__6(ResourceCategory r)
	{
		return r;
	}

	// Token: 0x060044B1 RID: 17585 RVA: 0x001BE05C File Offset: 0x001BC45C
	[CompilerGenerated]
	private bool <AddNewUnit>m__7(UnitClass r)
	{
		return this.UnitDescriptions.All((UnitLocalization i) => i.UnitClass != r);
	}

	// Token: 0x060044B2 RID: 17586 RVA: 0x001BE08D File Offset: 0x001BC48D
	[CompilerGenerated]
	private static UnitClass <AddNewUnit>m__8(UnitClass r)
	{
		return r;
	}

	// Token: 0x060044B3 RID: 17587 RVA: 0x001BE090 File Offset: 0x001BC490
	[CompilerGenerated]
	private bool <AddNewBuilding>m__9(BuildingType r)
	{
		return this.BuildingDescriptions.All((BuildingLocalization i) => i.BuildingType != r);
	}

	// Token: 0x060044B4 RID: 17588 RVA: 0x001BE0C1 File Offset: 0x001BC4C1
	[CompilerGenerated]
	private static BuildingType <AddNewBuilding>m__A(BuildingType r)
	{
		return r;
	}

	// Token: 0x060044B5 RID: 17589 RVA: 0x001BE0C4 File Offset: 0x001BC4C4
	[CompilerGenerated]
	private bool <AddNewAdventure>m__B(AdventureType r)
	{
		return this.AdventureDescriptions.All((AdventureLocalization i) => i.AdventureType != r);
	}

	// Token: 0x060044B6 RID: 17590 RVA: 0x001BE0F5 File Offset: 0x001BC4F5
	[CompilerGenerated]
	private static AdventureType <AddNewAdventure>m__C(AdventureType r)
	{
		return r;
	}

	// Token: 0x060044B7 RID: 17591 RVA: 0x001BE0F8 File Offset: 0x001BC4F8
	[CompilerGenerated]
	private bool <AddFaction>m__D(GameFactionType r)
	{
		return this.FactionDescriptions.All((FactionLocalization i) => i.FactionType != r);
	}

	// Token: 0x060044B8 RID: 17592 RVA: 0x001BE129 File Offset: 0x001BC529
	[CompilerGenerated]
	private static GameFactionType <AddFaction>m__E(GameFactionType r)
	{
		return r;
	}

	// Token: 0x060044B9 RID: 17593 RVA: 0x001BE12C File Offset: 0x001BC52C
	[CompilerGenerated]
	private bool <AddQuestRequirement>m__F(QuestRequirementType r)
	{
		return this.QuestRequirementDescriptions.All((QuestRequirementLocalization i) => i.QuestRequirementType != r);
	}

	// Token: 0x060044BA RID: 17594 RVA: 0x001BE15D File Offset: 0x001BC55D
	[CompilerGenerated]
	private static QuestRequirementType <AddQuestRequirement>m__10(QuestRequirementType r)
	{
		return r;
	}

	// Token: 0x060044BB RID: 17595 RVA: 0x001BE160 File Offset: 0x001BC560
	[CompilerGenerated]
	private bool <AddQuest>m__11(QuestIdentifier r)
	{
		return this.QuestDescriptions.All((QuestLocalization i) => i.QuestIdentifier != r);
	}

	// Token: 0x060044BC RID: 17596 RVA: 0x001BE191 File Offset: 0x001BC591
	[CompilerGenerated]
	private static QuestIdentifier <AddQuest>m__12(QuestIdentifier r)
	{
		return r;
	}

	// Token: 0x060044BD RID: 17597 RVA: 0x001BE194 File Offset: 0x001BC594
	[CompilerGenerated]
	private bool <AddDialog>m__13(DialogIdentifier r)
	{
		return this.DialogDetails.All((DialogDetails i) => i.Identifier != r);
	}

	// Token: 0x060044BE RID: 17598 RVA: 0x001BE1C5 File Offset: 0x001BC5C5
	[CompilerGenerated]
	private static DialogIdentifier <AddDialog>m__14(DialogIdentifier r)
	{
		return r;
	}

	// Token: 0x060044BF RID: 17599 RVA: 0x001BE1C8 File Offset: 0x001BC5C8
	[CompilerGenerated]
	private bool <AddStory>m__15(StoryIdentifier r)
	{
		return this.StoryDetailses.All((StoryDetails i) => i.Identifier != r);
	}

	// Token: 0x060044C0 RID: 17600 RVA: 0x001BE1F9 File Offset: 0x001BC5F9
	[CompilerGenerated]
	private static StoryIdentifier <AddStory>m__16(StoryIdentifier r)
	{
		return r;
	}

	// Token: 0x060044C1 RID: 17601 RVA: 0x001BE1FC File Offset: 0x001BC5FC
	[CompilerGenerated]
	private bool <AddManualItem>m__17(ManualType r)
	{
		return this.ManualLocalizations.All((ManualLocalization i) => i.ManualType != r);
	}

	// Token: 0x060044C2 RID: 17602 RVA: 0x001BE22D File Offset: 0x001BC62D
	[CompilerGenerated]
	private static ManualType <AddManualItem>m__18(ManualType r)
	{
		return r;
	}

	// Token: 0x060044C3 RID: 17603 RVA: 0x001BE230 File Offset: 0x001BC630
	[CompilerGenerated]
	private bool <AddUiComponent>m__19(UIComponentType r)
	{
		return this.UiLocalizations.All((UILocalization i) => i.UiComponentType != r);
	}

	// Token: 0x060044C4 RID: 17604 RVA: 0x001BE261 File Offset: 0x001BC661
	[CompilerGenerated]
	private static UIComponentType <AddUiComponent>m__1A(UIComponentType r)
	{
		return r;
	}

	// Token: 0x060044C5 RID: 17605 RVA: 0x001BE264 File Offset: 0x001BC664
	[CompilerGenerated]
	private bool <AddAttribute>m__1B(AttributeType r)
	{
		return this.AttributeLocalizations.All((AttributeLocalization i) => i.AttributeType != r);
	}

	// Token: 0x060044C6 RID: 17606 RVA: 0x001BE295 File Offset: 0x001BC695
	[CompilerGenerated]
	private static AttributeType <AddAttribute>m__1C(AttributeType r)
	{
		return r;
	}

	// Token: 0x060044C7 RID: 17607 RVA: 0x001BE298 File Offset: 0x001BC698
	[CompilerGenerated]
	private bool <AddResidentType>m__1D(ResidentType r)
	{
		return this.ResidentLocalizations.All((ResidentLocalization i) => i.ResidentType != r);
	}

	// Token: 0x060044C8 RID: 17608 RVA: 0x001BE2C9 File Offset: 0x001BC6C9
	[CompilerGenerated]
	private static ResidentType <AddResidentType>m__1E(ResidentType r)
	{
		return r;
	}

	// Token: 0x060044C9 RID: 17609 RVA: 0x001BE2CC File Offset: 0x001BC6CC
	[CompilerGenerated]
	private bool <AddSpecialEffect>m__1F(SpecialEffectType r)
	{
		return this.SpecialEffectLocalizations.All((SpecialEffectLocalization i) => i.SpecialEffectType != r);
	}

	// Token: 0x060044CA RID: 17610 RVA: 0x001BE2FD File Offset: 0x001BC6FD
	[CompilerGenerated]
	private static SpecialEffectType <AddSpecialEffect>m__20(SpecialEffectType r)
	{
		return r;
	}

	// Token: 0x060044CB RID: 17611 RVA: 0x001BE300 File Offset: 0x001BC700
	[CompilerGenerated]
	private bool <AddGrowthCondition>m__21(GrowthConditionType r)
	{
		return this.GrowthConditionLocalizations.All((GrowthSpecialEffectConditionLocalization i) => i.ConditionType != r);
	}

	// Token: 0x060044CC RID: 17612 RVA: 0x001BE331 File Offset: 0x001BC731
	[CompilerGenerated]
	private static GrowthConditionType <AddGrowthCondition>m__22(GrowthConditionType r)
	{
		return r;
	}

	// Token: 0x060044CD RID: 17613 RVA: 0x001BE334 File Offset: 0x001BC734
	[CompilerGenerated]
	private bool <AddItemGrade>m__23(QualityGrade r)
	{
		return this.ItemGradeLocalizations.All((ItemGradeLocalization i) => i.Grade != r);
	}

	// Token: 0x060044CE RID: 17614 RVA: 0x001BE365 File Offset: 0x001BC765
	[CompilerGenerated]
	private static QualityGrade <AddItemGrade>m__24(QualityGrade r)
	{
		return r;
	}

	// Token: 0x060044CF RID: 17615 RVA: 0x001BE368 File Offset: 0x001BC768
	[CompilerGenerated]
	private bool <AddQuestRewardType>m__25(RewardType r)
	{
		return this.RewardTypeLocalizations.All((RewardTypeLocalization i) => i.RewardType != r);
	}

	// Token: 0x060044D0 RID: 17616 RVA: 0x001BE399 File Offset: 0x001BC799
	[CompilerGenerated]
	private static RewardType <AddQuestRewardType>m__26(RewardType r)
	{
		return r;
	}

	// Token: 0x060044D1 RID: 17617 RVA: 0x001BE39C File Offset: 0x001BC79C
	[CompilerGenerated]
	private bool <AddQuestChain>m__27(QuestChainIdentifier r)
	{
		return this.QuestChainLocalizations.All((QuestChainLocalization i) => i.QuestChainIdentifier != r);
	}

	// Token: 0x060044D2 RID: 17618 RVA: 0x001BE3CD File Offset: 0x001BC7CD
	[CompilerGenerated]
	private static QuestChainIdentifier <AddQuestChain>m__28(QuestChainIdentifier r)
	{
		return r;
	}

	// Token: 0x060044D3 RID: 17619 RVA: 0x001BE3D0 File Offset: 0x001BC7D0
	[CompilerGenerated]
	private bool <AddUnitCategory>m__29(ClassCategory r)
	{
		return this.UnitCategoryLocalizations.All((UnitCategoryLocalization i) => i.ClassCategoryIdentifier != r);
	}

	// Token: 0x060044D4 RID: 17620 RVA: 0x001BE401 File Offset: 0x001BC801
	[CompilerGenerated]
	private static ClassCategory <AddUnitCategory>m__2A(ClassCategory r)
	{
		return r;
	}

	// Token: 0x060044D5 RID: 17621 RVA: 0x001BE404 File Offset: 0x001BC804
	[CompilerGenerated]
	private bool <AddBattleEvent>m__2B(AdventureEventType r)
	{
		return this.BattleEventLocalizations.All((BattleEventLocalization i) => i.EventType != r);
	}

	// Token: 0x060044D6 RID: 17622 RVA: 0x001BE435 File Offset: 0x001BC835
	[CompilerGenerated]
	private static AdventureEventType <AddBattleEvent>m__2C(AdventureEventType r)
	{
		return r;
	}

	// Token: 0x060044D7 RID: 17623 RVA: 0x001BE438 File Offset: 0x001BC838
	[CompilerGenerated]
	private bool <AddOutputType>m__2D(OutputType r)
	{
		return this.OutputLocalizations.All((OutputTypeLocalization i) => i.OutputType != r);
	}

	// Token: 0x060044D8 RID: 17624 RVA: 0x001BE469 File Offset: 0x001BC869
	[CompilerGenerated]
	private static OutputType <AddOutputType>m__2E(OutputType r)
	{
		return r;
	}

	// Token: 0x060044D9 RID: 17625 RVA: 0x001BE46C File Offset: 0x001BC86C
	[CompilerGenerated]
	private bool <AddBoostType>m__2F(BoostType r)
	{
		return this.BoostTypeLocalizations.All((BoostTypeLocalization i) => i.BoostType != r);
	}

	// Token: 0x060044DA RID: 17626 RVA: 0x001BE49D File Offset: 0x001BC89D
	[CompilerGenerated]
	private static BoostType <AddBoostType>m__30(BoostType r)
	{
		return r;
	}

	// Token: 0x060044DB RID: 17627 RVA: 0x001BE4A0 File Offset: 0x001BC8A0
	[CompilerGenerated]
	private bool <AddTargetCandidateType>m__31(TargetCandidateType r)
	{
		return this.TargetCandidateTypeLocalizations.All((TargetCandidateTypeLocalization i) => i.TargetCandidateType != r);
	}

	// Token: 0x060044DC RID: 17628 RVA: 0x001BE4D1 File Offset: 0x001BC8D1
	[CompilerGenerated]
	private static TargetCandidateType <AddTargetCandidateType>m__32(TargetCandidateType r)
	{
		return r;
	}

	// Token: 0x060044DD RID: 17629 RVA: 0x001BE4D4 File Offset: 0x001BC8D4
	[CompilerGenerated]
	private bool <AddTownTitle>m__33(TownTitleType r)
	{
		return this.TownTitleLocalizations.All((TownTitleLocalization i) => i.TownTitleType != r);
	}

	// Token: 0x060044DE RID: 17630 RVA: 0x001BE505 File Offset: 0x001BC905
	[CompilerGenerated]
	private static TownTitleType <AddTownTitle>m__34(TownTitleType r)
	{
		return r;
	}

	// Token: 0x060044DF RID: 17631 RVA: 0x001BE508 File Offset: 0x001BC908
	[CompilerGenerated]
	private bool <AddMonsterSlot>m__35(AdventureEncounterSlotType r)
	{
		return this.MonsterSlotLocalizations.All((MonsterSlotLocalization i) => i.SlotType != r);
	}

	// Token: 0x060044E0 RID: 17632 RVA: 0x001BE539 File Offset: 0x001BC939
	[CompilerGenerated]
	private static AdventureEncounterSlotType <AddMonsterSlot>m__36(AdventureEncounterSlotType r)
	{
		return r;
	}

	// Token: 0x060044E1 RID: 17633 RVA: 0x001BE53C File Offset: 0x001BC93C
	[CompilerGenerated]
	private bool <AddAttributeModificationType>m__37(ModificationType r)
	{
		return this.AttributeModificationTypeLocalizations.All((AttributeModificationTypeLocalization i) => i.ModificationType != r);
	}

	// Token: 0x060044E2 RID: 17634 RVA: 0x001BE56D File Offset: 0x001BC96D
	[CompilerGenerated]
	private static ModificationType <AddAttributeModificationType>m__38(ModificationType r)
	{
		return r;
	}

	// Token: 0x060044E3 RID: 17635 RVA: 0x001BE570 File Offset: 0x001BC970
	[CompilerGenerated]
	private bool <AddSocketType>m__39(SocketType r)
	{
		return this.SocketTypeLocalizations.All((SocketTypeLocalization i) => i.SocketType != r);
	}

	// Token: 0x060044E4 RID: 17636 RVA: 0x001BE5A1 File Offset: 0x001BC9A1
	[CompilerGenerated]
	private static SocketType <AddSocketType>m__3A(SocketType r)
	{
		return r;
	}

	// Token: 0x060044E5 RID: 17637 RVA: 0x001BE5A4 File Offset: 0x001BC9A4
	[CompilerGenerated]
	private bool <AddResidentEffect>m__3B(ResidentEffectType r)
	{
		return this.ResidentEffectLocalizations.All((ResidentEffectLocalization i) => i.EffectType != r);
	}

	// Token: 0x060044E6 RID: 17638 RVA: 0x001BE5D5 File Offset: 0x001BC9D5
	[CompilerGenerated]
	private static ResidentEffectType <AddResidentEffect>m__3C(ResidentEffectType r)
	{
		return r;
	}

	// Token: 0x060044E7 RID: 17639 RVA: 0x001BE5D8 File Offset: 0x001BC9D8
	[CompilerGenerated]
	private bool <AddUpgradeCard>m__3D(UpgradeCardType r)
	{
		return this.UpgradeCardLocalizations.All((UpgradeCardLocalization i) => i.Type != r);
	}

	// Token: 0x060044E8 RID: 17640 RVA: 0x001BE609 File Offset: 0x001BCA09
	[CompilerGenerated]
	private static UpgradeCardType <AddUpgradeCard>m__3E(UpgradeCardType r)
	{
		return r;
	}

	// Token: 0x060044E9 RID: 17641 RVA: 0x001BE60C File Offset: 0x001BCA0C
	[CompilerGenerated]
	private bool <AddBattleOption>m__3F(BattleOptionType r)
	{
		return this.BattleOptionLocalizations.All((BattleOptionLocalization i) => i.Type != r);
	}

	// Token: 0x060044EA RID: 17642 RVA: 0x001BE63D File Offset: 0x001BCA3D
	[CompilerGenerated]
	private static BattleOptionType <AddBattleOption>m__40(BattleOptionType r)
	{
		return r;
	}

	// Token: 0x060044EB RID: 17643 RVA: 0x001BE640 File Offset: 0x001BCA40
	[CompilerGenerated]
	private bool <AddVehicle>m__41(VehicleType r)
	{
		return this.VehicleLocalizations.All((VehicleLocalization i) => i.Type != r);
	}

	// Token: 0x060044EC RID: 17644 RVA: 0x001BE671 File Offset: 0x001BCA71
	[CompilerGenerated]
	private static VehicleType <AddVehicle>m__42(VehicleType r)
	{
		return r;
	}

	// Token: 0x060044ED RID: 17645 RVA: 0x001BE674 File Offset: 0x001BCA74
	[CompilerGenerated]
	private bool <AddJourneyContribution>m__43(JourneyContributeType r)
	{
		return this.JourneyContributionLocalizations.All((JourneyContributionLocalization i) => i.Type != r);
	}

	// Token: 0x060044EE RID: 17646 RVA: 0x001BE6A5 File Offset: 0x001BCAA5
	[CompilerGenerated]
	private static JourneyContributeType <AddJourneyContribution>m__44(JourneyContributeType r)
	{
		return r;
	}

	// Token: 0x060044EF RID: 17647 RVA: 0x001BE6A8 File Offset: 0x001BCAA8
	[CompilerGenerated]
	private bool <AddVehicleAttribute>m__45(VehicleAttributeType r)
	{
		return this.VehicleAttributeLocalizations.All((VehicleAttributeLocalization i) => i.Type != r);
	}

	// Token: 0x060044F0 RID: 17648 RVA: 0x001BE6D9 File Offset: 0x001BCAD9
	[CompilerGenerated]
	private static VehicleAttributeType <AddVehicleAttribute>m__46(VehicleAttributeType r)
	{
		return r;
	}

	// Token: 0x060044F1 RID: 17649 RVA: 0x001BE6DC File Offset: 0x001BCADC
	[CompilerGenerated]
	private bool <AddTripEncounter>m__47(TripEncounterType r)
	{
		return this.TripEncounterLocalizations.All((TripEncounterLocalization i) => i.Type != r);
	}

	// Token: 0x060044F2 RID: 17650 RVA: 0x001BE70D File Offset: 0x001BCB0D
	[CompilerGenerated]
	private static TripEncounterType <AddTripEncounter>m__48(TripEncounterType r)
	{
		return r;
	}

	// Token: 0x060044F3 RID: 17651 RVA: 0x001BE710 File Offset: 0x001BCB10
	[CompilerGenerated]
	private bool <AddTripEncounterOutcome>m__49(TripEncounterOutcomeType r)
	{
		return this.TripOutcomeLocalizations.All((TripOutcomeLocalization i) => i.Type != r);
	}

	// Token: 0x060044F4 RID: 17652 RVA: 0x001BE741 File Offset: 0x001BCB41
	[CompilerGenerated]
	private static TripEncounterOutcomeType <AddTripEncounterOutcome>m__4A(TripEncounterOutcomeType r)
	{
		return r;
	}

	// Token: 0x060044F5 RID: 17653 RVA: 0x001BE744 File Offset: 0x001BCB44
	[CompilerGenerated]
	private bool <AddDestination>m__4B(DestinationType r)
	{
		return this.DestinationLocalizations.All((DestinationLocalization i) => i.Type != r);
	}

	// Token: 0x060044F6 RID: 17654 RVA: 0x001BE775 File Offset: 0x001BCB75
	[CompilerGenerated]
	private static DestinationType <AddDestination>m__4C(DestinationType r)
	{
		return r;
	}

	// Token: 0x060044F7 RID: 17655 RVA: 0x001BE778 File Offset: 0x001BCB78
	[CompilerGenerated]
	private bool <AddUnitStyle>m__4D(UnitClassStyle r)
	{
		return this.UnitStyleLocalizations.All((UnitStyleLocalization i) => i.Type != r);
	}

	// Token: 0x060044F8 RID: 17656 RVA: 0x001BE7A9 File Offset: 0x001BCBA9
	[CompilerGenerated]
	private static UnitClassStyle <AddUnitStyle>m__4E(UnitClassStyle r)
	{
		return r;
	}

	// Token: 0x060044F9 RID: 17657 RVA: 0x001BE7AC File Offset: 0x001BCBAC
	[CompilerGenerated]
	private bool <AddTalent>m__4F(AdventurerTalentType r)
	{
		return this.TalentLocalizations.All((TalentLocalization i) => i.Type != r);
	}

	// Token: 0x060044FA RID: 17658 RVA: 0x001BE7DD File Offset: 0x001BCBDD
	[CompilerGenerated]
	private static AdventurerTalentType <AddTalent>m__50(AdventurerTalentType r)
	{
		return r;
	}

	// Token: 0x060044FB RID: 17659 RVA: 0x001BE7E0 File Offset: 0x001BCBE0
	[CompilerGenerated]
	private bool <AddTownEvent>m__51(TownEventType r)
	{
		return this.TownEventLocalizaitons.All((TownEventLocalizaiton i) => i.Type != r);
	}

	// Token: 0x060044FC RID: 17660 RVA: 0x001BE811 File Offset: 0x001BCC11
	[CompilerGenerated]
	private static TownEventType <AddTownEvent>m__52(TownEventType r)
	{
		return r;
	}

	// Token: 0x060044FD RID: 17661 RVA: 0x001BE814 File Offset: 0x001BCC14
	[CompilerGenerated]
	private bool <AddTownEffect>m__53(TownEffectType r)
	{
		return this.TownEffectLocalizations.All((TownEffectLocalization i) => i.Type != r);
	}

	// Token: 0x060044FE RID: 17662 RVA: 0x001BE845 File Offset: 0x001BCC45
	[CompilerGenerated]
	private static TownEffectType <AddTownEffect>m__54(TownEffectType r)
	{
		return r;
	}

	// Token: 0x060044FF RID: 17663 RVA: 0x001BE848 File Offset: 0x001BCC48
	[CompilerGenerated]
	private bool <AddCandidateMetric>m__55(CandidateOrderringMetric r)
	{
		return this.CandidateOrderMetricLocalizations.All((CandidateOrderMetricLocalization i) => i.Type != r);
	}

	// Token: 0x06004500 RID: 17664 RVA: 0x001BE879 File Offset: 0x001BCC79
	[CompilerGenerated]
	private static CandidateOrderringMetric <AddCandidateMetric>m__56(CandidateOrderringMetric r)
	{
		return r;
	}

	// Token: 0x06004501 RID: 17665 RVA: 0x001BE87C File Offset: 0x001BCC7C
	[CompilerGenerated]
	private bool <AddOrderType>m__57(OrderingType r)
	{
		return this.OrderTypeLocalizations.All((OrderTypeLocalization i) => i.Type != r);
	}

	// Token: 0x06004502 RID: 17666 RVA: 0x001BE8AD File Offset: 0x001BCCAD
	[CompilerGenerated]
	private static OrderingType <AddOrderType>m__58(OrderingType r)
	{
		return r;
	}

	// Token: 0x040033A8 RID: 13224
	public List<SkillLocalization> SkillDescriptions;

	// Token: 0x040033A9 RID: 13225
	public List<EffectLocalization> EffectDescriptions;

	// Token: 0x040033AA RID: 13226
	public List<ResourceLocalization> ItemDescriptions;

	// Token: 0x040033AB RID: 13227
	public List<ItemCategoryLocalization> ResourceCategoryDescriptions;

	// Token: 0x040033AC RID: 13228
	public List<UnitLocalization> UnitDescriptions;

	// Token: 0x040033AD RID: 13229
	public List<BuildingLocalization> BuildingDescriptions;

	// Token: 0x040033AE RID: 13230
	public List<AdventureLocalization> AdventureDescriptions;

	// Token: 0x040033AF RID: 13231
	public List<FactionLocalization> FactionDescriptions;

	// Token: 0x040033B0 RID: 13232
	public List<QuestRequirementLocalization> QuestRequirementDescriptions;

	// Token: 0x040033B1 RID: 13233
	public List<QuestLocalization> QuestDescriptions;

	// Token: 0x040033B2 RID: 13234
	public List<DialogDetails> DialogDetails;

	// Token: 0x040033B3 RID: 13235
	public List<StoryDetails> StoryDetailses;

	// Token: 0x040033B4 RID: 13236
	public List<UILocalization> UiLocalizations;

	// Token: 0x040033B5 RID: 13237
	public List<AttributeLocalization> AttributeLocalizations;

	// Token: 0x040033B6 RID: 13238
	public List<ResidentLocalization> ResidentLocalizations;

	// Token: 0x040033B7 RID: 13239
	public List<SpecialEffectLocalization> SpecialEffectLocalizations;

	// Token: 0x040033B8 RID: 13240
	public List<GrowthSpecialEffectConditionLocalization> GrowthConditionLocalizations;

	// Token: 0x040033B9 RID: 13241
	public List<ItemGradeLocalization> ItemGradeLocalizations;

	// Token: 0x040033BA RID: 13242
	public List<RewardTypeLocalization> RewardTypeLocalizations;

	// Token: 0x040033BB RID: 13243
	public List<QuestChainLocalization> QuestChainLocalizations;

	// Token: 0x040033BC RID: 13244
	public List<UnitCategoryLocalization> UnitCategoryLocalizations;

	// Token: 0x040033BD RID: 13245
	public List<BattleEventLocalization> BattleEventLocalizations;

	// Token: 0x040033BE RID: 13246
	public List<OutputTypeLocalization> OutputLocalizations;

	// Token: 0x040033BF RID: 13247
	public List<BoostTypeLocalization> BoostTypeLocalizations;

	// Token: 0x040033C0 RID: 13248
	public List<TargetCandidateTypeLocalization> TargetCandidateTypeLocalizations;

	// Token: 0x040033C1 RID: 13249
	public List<TownTitleLocalization> TownTitleLocalizations;

	// Token: 0x040033C2 RID: 13250
	public List<MonsterSlotLocalization> MonsterSlotLocalizations;

	// Token: 0x040033C3 RID: 13251
	public List<AttributeModificationTypeLocalization> AttributeModificationTypeLocalizations;

	// Token: 0x040033C4 RID: 13252
	public List<SocketTypeLocalization> SocketTypeLocalizations;

	// Token: 0x040033C5 RID: 13253
	public List<ResidentEffectLocalization> ResidentEffectLocalizations;

	// Token: 0x040033C6 RID: 13254
	public List<UpgradeCardLocalization> UpgradeCardLocalizations;

	// Token: 0x040033C7 RID: 13255
	public List<BattleOptionLocalization> BattleOptionLocalizations;

	// Token: 0x040033C8 RID: 13256
	public List<VehicleLocalization> VehicleLocalizations;

	// Token: 0x040033C9 RID: 13257
	public List<JourneyContributionLocalization> JourneyContributionLocalizations;

	// Token: 0x040033CA RID: 13258
	public List<VehicleAttributeLocalization> VehicleAttributeLocalizations;

	// Token: 0x040033CB RID: 13259
	public List<TripEncounterLocalization> TripEncounterLocalizations;

	// Token: 0x040033CC RID: 13260
	public List<TripOutcomeLocalization> TripOutcomeLocalizations;

	// Token: 0x040033CD RID: 13261
	public List<DestinationLocalization> DestinationLocalizations;

	// Token: 0x040033CE RID: 13262
	public List<UnitStyleLocalization> UnitStyleLocalizations;

	// Token: 0x040033CF RID: 13263
	public List<ManualLocalization> ManualLocalizations;

	// Token: 0x040033D0 RID: 13264
	public List<TalentLocalization> TalentLocalizations;

	// Token: 0x040033D1 RID: 13265
	public List<TownEventLocalizaiton> TownEventLocalizaitons;

	// Token: 0x040033D2 RID: 13266
	public List<TownEffectLocalization> TownEffectLocalizations;

	// Token: 0x040033D3 RID: 13267
	public List<CandidateOrderMetricLocalization> CandidateOrderMetricLocalizations;

	// Token: 0x040033D4 RID: 13268
	public List<OrderTypeLocalization> OrderTypeLocalizations;

	// Token: 0x040033D5 RID: 13269
	[CompilerGenerated]
	private static Func<BattleEffectType, BattleEffectType> <>f__am$cache0;

	// Token: 0x040033D6 RID: 13270
	[CompilerGenerated]
	private static Func<ResourceType, ResourceType> <>f__am$cache1;

	// Token: 0x040033D7 RID: 13271
	[CompilerGenerated]
	private static Func<ResourceCategory, ResourceCategory> <>f__am$cache2;

	// Token: 0x040033D8 RID: 13272
	[CompilerGenerated]
	private static Func<UnitClass, UnitClass> <>f__am$cache3;

	// Token: 0x040033D9 RID: 13273
	[CompilerGenerated]
	private static Func<BuildingType, BuildingType> <>f__am$cache4;

	// Token: 0x040033DA RID: 13274
	[CompilerGenerated]
	private static Func<AdventureType, AdventureType> <>f__am$cache5;

	// Token: 0x040033DB RID: 13275
	[CompilerGenerated]
	private static Func<GameFactionType, GameFactionType> <>f__am$cache6;

	// Token: 0x040033DC RID: 13276
	[CompilerGenerated]
	private static Func<QuestRequirementType, QuestRequirementType> <>f__am$cache7;

	// Token: 0x040033DD RID: 13277
	[CompilerGenerated]
	private static Func<QuestIdentifier, QuestIdentifier> <>f__am$cache8;

	// Token: 0x040033DE RID: 13278
	[CompilerGenerated]
	private static Func<DialogIdentifier, DialogIdentifier> <>f__am$cache9;

	// Token: 0x040033DF RID: 13279
	[CompilerGenerated]
	private static Func<StoryIdentifier, StoryIdentifier> <>f__am$cacheA;

	// Token: 0x040033E0 RID: 13280
	[CompilerGenerated]
	private static Func<ManualType, ManualType> <>f__am$cacheB;

	// Token: 0x040033E1 RID: 13281
	[CompilerGenerated]
	private static Func<UIComponentType, UIComponentType> <>f__am$cacheC;

	// Token: 0x040033E2 RID: 13282
	[CompilerGenerated]
	private static Func<AttributeType, AttributeType> <>f__am$cacheD;

	// Token: 0x040033E3 RID: 13283
	[CompilerGenerated]
	private static Func<ResidentType, ResidentType> <>f__am$cacheE;

	// Token: 0x040033E4 RID: 13284
	[CompilerGenerated]
	private static Func<SpecialEffectType, SpecialEffectType> <>f__am$cacheF;

	// Token: 0x040033E5 RID: 13285
	[CompilerGenerated]
	private static Func<GrowthConditionType, GrowthConditionType> <>f__am$cache10;

	// Token: 0x040033E6 RID: 13286
	[CompilerGenerated]
	private static Func<QualityGrade, QualityGrade> <>f__am$cache11;

	// Token: 0x040033E7 RID: 13287
	[CompilerGenerated]
	private static Func<RewardType, RewardType> <>f__am$cache12;

	// Token: 0x040033E8 RID: 13288
	[CompilerGenerated]
	private static Func<QuestChainIdentifier, QuestChainIdentifier> <>f__am$cache13;

	// Token: 0x040033E9 RID: 13289
	[CompilerGenerated]
	private static Func<ClassCategory, ClassCategory> <>f__am$cache14;

	// Token: 0x040033EA RID: 13290
	[CompilerGenerated]
	private static Func<AdventureEventType, AdventureEventType> <>f__am$cache15;

	// Token: 0x040033EB RID: 13291
	[CompilerGenerated]
	private static Func<OutputType, OutputType> <>f__am$cache16;

	// Token: 0x040033EC RID: 13292
	[CompilerGenerated]
	private static Func<BoostType, BoostType> <>f__am$cache17;

	// Token: 0x040033ED RID: 13293
	[CompilerGenerated]
	private static Func<TargetCandidateType, TargetCandidateType> <>f__am$cache18;

	// Token: 0x040033EE RID: 13294
	[CompilerGenerated]
	private static Func<TownTitleType, TownTitleType> <>f__am$cache19;

	// Token: 0x040033EF RID: 13295
	[CompilerGenerated]
	private static Func<AdventureEncounterSlotType, AdventureEncounterSlotType> <>f__am$cache1A;

	// Token: 0x040033F0 RID: 13296
	[CompilerGenerated]
	private static Func<ModificationType, ModificationType> <>f__am$cache1B;

	// Token: 0x040033F1 RID: 13297
	[CompilerGenerated]
	private static Func<SocketType, SocketType> <>f__am$cache1C;

	// Token: 0x040033F2 RID: 13298
	[CompilerGenerated]
	private static Func<ResidentEffectType, ResidentEffectType> <>f__am$cache1D;

	// Token: 0x040033F3 RID: 13299
	[CompilerGenerated]
	private static Func<UpgradeCardType, UpgradeCardType> <>f__am$cache1E;

	// Token: 0x040033F4 RID: 13300
	[CompilerGenerated]
	private static Func<BattleOptionType, BattleOptionType> <>f__am$cache1F;

	// Token: 0x040033F5 RID: 13301
	[CompilerGenerated]
	private static Func<VehicleType, VehicleType> <>f__am$cache20;

	// Token: 0x040033F6 RID: 13302
	[CompilerGenerated]
	private static Func<JourneyContributeType, JourneyContributeType> <>f__am$cache21;

	// Token: 0x040033F7 RID: 13303
	[CompilerGenerated]
	private static Func<VehicleAttributeType, VehicleAttributeType> <>f__am$cache22;

	// Token: 0x040033F8 RID: 13304
	[CompilerGenerated]
	private static Func<TripEncounterType, TripEncounterType> <>f__am$cache23;

	// Token: 0x040033F9 RID: 13305
	[CompilerGenerated]
	private static Func<TripEncounterOutcomeType, TripEncounterOutcomeType> <>f__am$cache24;

	// Token: 0x040033FA RID: 13306
	[CompilerGenerated]
	private static Func<DestinationType, DestinationType> <>f__am$cache25;

	// Token: 0x040033FB RID: 13307
	[CompilerGenerated]
	private static Func<UnitClassStyle, UnitClassStyle> <>f__am$cache26;

	// Token: 0x040033FC RID: 13308
	[CompilerGenerated]
	private static Func<AdventurerTalentType, AdventurerTalentType> <>f__am$cache27;

	// Token: 0x040033FD RID: 13309
	[CompilerGenerated]
	private static Func<TownEventType, TownEventType> <>f__am$cache28;

	// Token: 0x040033FE RID: 13310
	[CompilerGenerated]
	private static Func<TownEffectType, TownEffectType> <>f__am$cache29;

	// Token: 0x040033FF RID: 13311
	[CompilerGenerated]
	private static Func<CandidateOrderringMetric, CandidateOrderringMetric> <>f__am$cache2A;

	// Token: 0x04003400 RID: 13312
	[CompilerGenerated]
	private static Func<OrderingType, OrderingType> <>f__am$cache2B;

	// Token: 0x0200100C RID: 4108
	[CompilerGenerated]
	private sealed class <AddNewSkill>c__AnonStorey0
	{
		// Token: 0x060067E0 RID: 26592 RVA: 0x001BE8B0 File Offset: 0x001BCCB0
		public <AddNewSkill>c__AnonStorey0()
		{
		}

		// Token: 0x060067E1 RID: 26593 RVA: 0x001BE8B8 File Offset: 0x001BCCB8
		internal bool <>m__0(SkillLocalization esk)
		{
			return esk.SkillType != this.sk;
		}

		// Token: 0x040061D7 RID: 25047
		internal SkillType sk;
	}

	// Token: 0x0200100D RID: 4109
	[CompilerGenerated]
	private sealed class <AddNewEffect>c__AnonStorey1
	{
		// Token: 0x060067E2 RID: 26594 RVA: 0x001BE8CB File Offset: 0x001BCCCB
		public <AddNewEffect>c__AnonStorey1()
		{
		}

		// Token: 0x060067E3 RID: 26595 RVA: 0x001BE8D3 File Offset: 0x001BCCD3
		internal bool <>m__0(EffectLocalization i)
		{
			return i.BattleEffectType != this.r;
		}

		// Token: 0x040061D8 RID: 25048
		internal BattleEffectType r;
	}

	// Token: 0x0200100E RID: 4110
	[CompilerGenerated]
	private sealed class <AddNewItem>c__AnonStorey2
	{
		// Token: 0x060067E4 RID: 26596 RVA: 0x001BE8E6 File Offset: 0x001BCCE6
		public <AddNewItem>c__AnonStorey2()
		{
		}

		// Token: 0x060067E5 RID: 26597 RVA: 0x001BE8EE File Offset: 0x001BCCEE
		internal bool <>m__0(ResourceLocalization i)
		{
			return i.ItemType != this.r;
		}

		// Token: 0x040061D9 RID: 25049
		internal ResourceType r;
	}

	// Token: 0x0200100F RID: 4111
	[CompilerGenerated]
	private sealed class <AddNewItemCategory>c__AnonStorey3
	{
		// Token: 0x060067E6 RID: 26598 RVA: 0x001BE901 File Offset: 0x001BCD01
		public <AddNewItemCategory>c__AnonStorey3()
		{
		}

		// Token: 0x060067E7 RID: 26599 RVA: 0x001BE909 File Offset: 0x001BCD09
		internal bool <>m__0(ItemCategoryLocalization i)
		{
			return i.ResourceCategory != this.r;
		}

		// Token: 0x040061DA RID: 25050
		internal ResourceCategory r;
	}

	// Token: 0x02001010 RID: 4112
	[CompilerGenerated]
	private sealed class <AddNewUnit>c__AnonStorey4
	{
		// Token: 0x060067E8 RID: 26600 RVA: 0x001BE91C File Offset: 0x001BCD1C
		public <AddNewUnit>c__AnonStorey4()
		{
		}

		// Token: 0x060067E9 RID: 26601 RVA: 0x001BE924 File Offset: 0x001BCD24
		internal bool <>m__0(UnitLocalization i)
		{
			return i.UnitClass != this.r;
		}

		// Token: 0x040061DB RID: 25051
		internal UnitClass r;
	}

	// Token: 0x02001011 RID: 4113
	[CompilerGenerated]
	private sealed class <AddNewBuilding>c__AnonStorey5
	{
		// Token: 0x060067EA RID: 26602 RVA: 0x001BE937 File Offset: 0x001BCD37
		public <AddNewBuilding>c__AnonStorey5()
		{
		}

		// Token: 0x060067EB RID: 26603 RVA: 0x001BE93F File Offset: 0x001BCD3F
		internal bool <>m__0(BuildingLocalization i)
		{
			return i.BuildingType != this.r;
		}

		// Token: 0x040061DC RID: 25052
		internal BuildingType r;
	}

	// Token: 0x02001012 RID: 4114
	[CompilerGenerated]
	private sealed class <AddNewAdventure>c__AnonStorey6
	{
		// Token: 0x060067EC RID: 26604 RVA: 0x001BE952 File Offset: 0x001BCD52
		public <AddNewAdventure>c__AnonStorey6()
		{
		}

		// Token: 0x060067ED RID: 26605 RVA: 0x001BE95A File Offset: 0x001BCD5A
		internal bool <>m__0(AdventureLocalization i)
		{
			return i.AdventureType != this.r;
		}

		// Token: 0x040061DD RID: 25053
		internal AdventureType r;
	}

	// Token: 0x02001013 RID: 4115
	[CompilerGenerated]
	private sealed class <AddFaction>c__AnonStorey7
	{
		// Token: 0x060067EE RID: 26606 RVA: 0x001BE96D File Offset: 0x001BCD6D
		public <AddFaction>c__AnonStorey7()
		{
		}

		// Token: 0x060067EF RID: 26607 RVA: 0x001BE975 File Offset: 0x001BCD75
		internal bool <>m__0(FactionLocalization i)
		{
			return i.FactionType != this.r;
		}

		// Token: 0x040061DE RID: 25054
		internal GameFactionType r;
	}

	// Token: 0x02001014 RID: 4116
	[CompilerGenerated]
	private sealed class <AddQuestRequirement>c__AnonStorey8
	{
		// Token: 0x060067F0 RID: 26608 RVA: 0x001BE988 File Offset: 0x001BCD88
		public <AddQuestRequirement>c__AnonStorey8()
		{
		}

		// Token: 0x060067F1 RID: 26609 RVA: 0x001BE990 File Offset: 0x001BCD90
		internal bool <>m__0(QuestRequirementLocalization i)
		{
			return i.QuestRequirementType != this.r;
		}

		// Token: 0x040061DF RID: 25055
		internal QuestRequirementType r;
	}

	// Token: 0x02001015 RID: 4117
	[CompilerGenerated]
	private sealed class <AddQuest>c__AnonStorey9
	{
		// Token: 0x060067F2 RID: 26610 RVA: 0x001BE9A3 File Offset: 0x001BCDA3
		public <AddQuest>c__AnonStorey9()
		{
		}

		// Token: 0x060067F3 RID: 26611 RVA: 0x001BE9AB File Offset: 0x001BCDAB
		internal bool <>m__0(QuestLocalization i)
		{
			return i.QuestIdentifier != this.r;
		}

		// Token: 0x040061E0 RID: 25056
		internal QuestIdentifier r;
	}

	// Token: 0x02001016 RID: 4118
	[CompilerGenerated]
	private sealed class <AddDialog>c__AnonStoreyA
	{
		// Token: 0x060067F4 RID: 26612 RVA: 0x001BE9BE File Offset: 0x001BCDBE
		public <AddDialog>c__AnonStoreyA()
		{
		}

		// Token: 0x060067F5 RID: 26613 RVA: 0x001BE9C6 File Offset: 0x001BCDC6
		internal bool <>m__0(DialogDetails i)
		{
			return i.Identifier != this.r;
		}

		// Token: 0x040061E1 RID: 25057
		internal DialogIdentifier r;
	}

	// Token: 0x02001017 RID: 4119
	[CompilerGenerated]
	private sealed class <AddStory>c__AnonStoreyB
	{
		// Token: 0x060067F6 RID: 26614 RVA: 0x001BE9D9 File Offset: 0x001BCDD9
		public <AddStory>c__AnonStoreyB()
		{
		}

		// Token: 0x060067F7 RID: 26615 RVA: 0x001BE9E1 File Offset: 0x001BCDE1
		internal bool <>m__0(StoryDetails i)
		{
			return i.Identifier != this.r;
		}

		// Token: 0x040061E2 RID: 25058
		internal StoryIdentifier r;
	}

	// Token: 0x02001018 RID: 4120
	[CompilerGenerated]
	private sealed class <AddManualItem>c__AnonStoreyC
	{
		// Token: 0x060067F8 RID: 26616 RVA: 0x001BE9F4 File Offset: 0x001BCDF4
		public <AddManualItem>c__AnonStoreyC()
		{
		}

		// Token: 0x060067F9 RID: 26617 RVA: 0x001BE9FC File Offset: 0x001BCDFC
		internal bool <>m__0(ManualLocalization i)
		{
			return i.ManualType != this.r;
		}

		// Token: 0x040061E3 RID: 25059
		internal ManualType r;
	}

	// Token: 0x02001019 RID: 4121
	[CompilerGenerated]
	private sealed class <AddUiComponent>c__AnonStoreyD
	{
		// Token: 0x060067FA RID: 26618 RVA: 0x001BEA0F File Offset: 0x001BCE0F
		public <AddUiComponent>c__AnonStoreyD()
		{
		}

		// Token: 0x060067FB RID: 26619 RVA: 0x001BEA17 File Offset: 0x001BCE17
		internal bool <>m__0(UILocalization i)
		{
			return i.UiComponentType != this.r;
		}

		// Token: 0x040061E4 RID: 25060
		internal UIComponentType r;
	}

	// Token: 0x0200101A RID: 4122
	[CompilerGenerated]
	private sealed class <AddAttribute>c__AnonStoreyE
	{
		// Token: 0x060067FC RID: 26620 RVA: 0x001BEA2A File Offset: 0x001BCE2A
		public <AddAttribute>c__AnonStoreyE()
		{
		}

		// Token: 0x060067FD RID: 26621 RVA: 0x001BEA32 File Offset: 0x001BCE32
		internal bool <>m__0(AttributeLocalization i)
		{
			return i.AttributeType != this.r;
		}

		// Token: 0x040061E5 RID: 25061
		internal AttributeType r;
	}

	// Token: 0x0200101B RID: 4123
	[CompilerGenerated]
	private sealed class <AddResidentType>c__AnonStoreyF
	{
		// Token: 0x060067FE RID: 26622 RVA: 0x001BEA45 File Offset: 0x001BCE45
		public <AddResidentType>c__AnonStoreyF()
		{
		}

		// Token: 0x060067FF RID: 26623 RVA: 0x001BEA4D File Offset: 0x001BCE4D
		internal bool <>m__0(ResidentLocalization i)
		{
			return i.ResidentType != this.r;
		}

		// Token: 0x040061E6 RID: 25062
		internal ResidentType r;
	}

	// Token: 0x0200101C RID: 4124
	[CompilerGenerated]
	private sealed class <AddSpecialEffect>c__AnonStorey10
	{
		// Token: 0x06006800 RID: 26624 RVA: 0x001BEA60 File Offset: 0x001BCE60
		public <AddSpecialEffect>c__AnonStorey10()
		{
		}

		// Token: 0x06006801 RID: 26625 RVA: 0x001BEA68 File Offset: 0x001BCE68
		internal bool <>m__0(SpecialEffectLocalization i)
		{
			return i.SpecialEffectType != this.r;
		}

		// Token: 0x040061E7 RID: 25063
		internal SpecialEffectType r;
	}

	// Token: 0x0200101D RID: 4125
	[CompilerGenerated]
	private sealed class <AddGrowthCondition>c__AnonStorey11
	{
		// Token: 0x06006802 RID: 26626 RVA: 0x001BEA7B File Offset: 0x001BCE7B
		public <AddGrowthCondition>c__AnonStorey11()
		{
		}

		// Token: 0x06006803 RID: 26627 RVA: 0x001BEA83 File Offset: 0x001BCE83
		internal bool <>m__0(GrowthSpecialEffectConditionLocalization i)
		{
			return i.ConditionType != this.r;
		}

		// Token: 0x040061E8 RID: 25064
		internal GrowthConditionType r;
	}

	// Token: 0x0200101E RID: 4126
	[CompilerGenerated]
	private sealed class <AddItemGrade>c__AnonStorey12
	{
		// Token: 0x06006804 RID: 26628 RVA: 0x001BEA96 File Offset: 0x001BCE96
		public <AddItemGrade>c__AnonStorey12()
		{
		}

		// Token: 0x06006805 RID: 26629 RVA: 0x001BEA9E File Offset: 0x001BCE9E
		internal bool <>m__0(ItemGradeLocalization i)
		{
			return i.Grade != this.r;
		}

		// Token: 0x040061E9 RID: 25065
		internal QualityGrade r;
	}

	// Token: 0x0200101F RID: 4127
	[CompilerGenerated]
	private sealed class <AddQuestRewardType>c__AnonStorey13
	{
		// Token: 0x06006806 RID: 26630 RVA: 0x001BEAB1 File Offset: 0x001BCEB1
		public <AddQuestRewardType>c__AnonStorey13()
		{
		}

		// Token: 0x06006807 RID: 26631 RVA: 0x001BEAB9 File Offset: 0x001BCEB9
		internal bool <>m__0(RewardTypeLocalization i)
		{
			return i.RewardType != this.r;
		}

		// Token: 0x040061EA RID: 25066
		internal RewardType r;
	}

	// Token: 0x02001020 RID: 4128
	[CompilerGenerated]
	private sealed class <AddQuestChain>c__AnonStorey14
	{
		// Token: 0x06006808 RID: 26632 RVA: 0x001BEACC File Offset: 0x001BCECC
		public <AddQuestChain>c__AnonStorey14()
		{
		}

		// Token: 0x06006809 RID: 26633 RVA: 0x001BEAD4 File Offset: 0x001BCED4
		internal bool <>m__0(QuestChainLocalization i)
		{
			return i.QuestChainIdentifier != this.r;
		}

		// Token: 0x040061EB RID: 25067
		internal QuestChainIdentifier r;
	}

	// Token: 0x02001021 RID: 4129
	[CompilerGenerated]
	private sealed class <AddUnitCategory>c__AnonStorey15
	{
		// Token: 0x0600680A RID: 26634 RVA: 0x001BEAE7 File Offset: 0x001BCEE7
		public <AddUnitCategory>c__AnonStorey15()
		{
		}

		// Token: 0x0600680B RID: 26635 RVA: 0x001BEAEF File Offset: 0x001BCEEF
		internal bool <>m__0(UnitCategoryLocalization i)
		{
			return i.ClassCategoryIdentifier != this.r;
		}

		// Token: 0x040061EC RID: 25068
		internal ClassCategory r;
	}

	// Token: 0x02001022 RID: 4130
	[CompilerGenerated]
	private sealed class <AddBattleEvent>c__AnonStorey16
	{
		// Token: 0x0600680C RID: 26636 RVA: 0x001BEB02 File Offset: 0x001BCF02
		public <AddBattleEvent>c__AnonStorey16()
		{
		}

		// Token: 0x0600680D RID: 26637 RVA: 0x001BEB0A File Offset: 0x001BCF0A
		internal bool <>m__0(BattleEventLocalization i)
		{
			return i.EventType != this.r;
		}

		// Token: 0x040061ED RID: 25069
		internal AdventureEventType r;
	}

	// Token: 0x02001023 RID: 4131
	[CompilerGenerated]
	private sealed class <AddOutputType>c__AnonStorey17
	{
		// Token: 0x0600680E RID: 26638 RVA: 0x001BEB1D File Offset: 0x001BCF1D
		public <AddOutputType>c__AnonStorey17()
		{
		}

		// Token: 0x0600680F RID: 26639 RVA: 0x001BEB25 File Offset: 0x001BCF25
		internal bool <>m__0(OutputTypeLocalization i)
		{
			return i.OutputType != this.r;
		}

		// Token: 0x040061EE RID: 25070
		internal OutputType r;
	}

	// Token: 0x02001024 RID: 4132
	[CompilerGenerated]
	private sealed class <AddBoostType>c__AnonStorey18
	{
		// Token: 0x06006810 RID: 26640 RVA: 0x001BEB38 File Offset: 0x001BCF38
		public <AddBoostType>c__AnonStorey18()
		{
		}

		// Token: 0x06006811 RID: 26641 RVA: 0x001BEB40 File Offset: 0x001BCF40
		internal bool <>m__0(BoostTypeLocalization i)
		{
			return i.BoostType != this.r;
		}

		// Token: 0x040061EF RID: 25071
		internal BoostType r;
	}

	// Token: 0x02001025 RID: 4133
	[CompilerGenerated]
	private sealed class <AddTargetCandidateType>c__AnonStorey19
	{
		// Token: 0x06006812 RID: 26642 RVA: 0x001BEB53 File Offset: 0x001BCF53
		public <AddTargetCandidateType>c__AnonStorey19()
		{
		}

		// Token: 0x06006813 RID: 26643 RVA: 0x001BEB5B File Offset: 0x001BCF5B
		internal bool <>m__0(TargetCandidateTypeLocalization i)
		{
			return i.TargetCandidateType != this.r;
		}

		// Token: 0x040061F0 RID: 25072
		internal TargetCandidateType r;
	}

	// Token: 0x02001026 RID: 4134
	[CompilerGenerated]
	private sealed class <AddTownTitle>c__AnonStorey1A
	{
		// Token: 0x06006814 RID: 26644 RVA: 0x001BEB6E File Offset: 0x001BCF6E
		public <AddTownTitle>c__AnonStorey1A()
		{
		}

		// Token: 0x06006815 RID: 26645 RVA: 0x001BEB76 File Offset: 0x001BCF76
		internal bool <>m__0(TownTitleLocalization i)
		{
			return i.TownTitleType != this.r;
		}

		// Token: 0x040061F1 RID: 25073
		internal TownTitleType r;
	}

	// Token: 0x02001027 RID: 4135
	[CompilerGenerated]
	private sealed class <AddMonsterSlot>c__AnonStorey1B
	{
		// Token: 0x06006816 RID: 26646 RVA: 0x001BEB89 File Offset: 0x001BCF89
		public <AddMonsterSlot>c__AnonStorey1B()
		{
		}

		// Token: 0x06006817 RID: 26647 RVA: 0x001BEB91 File Offset: 0x001BCF91
		internal bool <>m__0(MonsterSlotLocalization i)
		{
			return i.SlotType != this.r;
		}

		// Token: 0x040061F2 RID: 25074
		internal AdventureEncounterSlotType r;
	}

	// Token: 0x02001028 RID: 4136
	[CompilerGenerated]
	private sealed class <AddAttributeModificationType>c__AnonStorey1C
	{
		// Token: 0x06006818 RID: 26648 RVA: 0x001BEBA4 File Offset: 0x001BCFA4
		public <AddAttributeModificationType>c__AnonStorey1C()
		{
		}

		// Token: 0x06006819 RID: 26649 RVA: 0x001BEBAC File Offset: 0x001BCFAC
		internal bool <>m__0(AttributeModificationTypeLocalization i)
		{
			return i.ModificationType != this.r;
		}

		// Token: 0x040061F3 RID: 25075
		internal ModificationType r;
	}

	// Token: 0x02001029 RID: 4137
	[CompilerGenerated]
	private sealed class <AddSocketType>c__AnonStorey1D
	{
		// Token: 0x0600681A RID: 26650 RVA: 0x001BEBBF File Offset: 0x001BCFBF
		public <AddSocketType>c__AnonStorey1D()
		{
		}

		// Token: 0x0600681B RID: 26651 RVA: 0x001BEBC7 File Offset: 0x001BCFC7
		internal bool <>m__0(SocketTypeLocalization i)
		{
			return i.SocketType != this.r;
		}

		// Token: 0x040061F4 RID: 25076
		internal SocketType r;
	}

	// Token: 0x0200102A RID: 4138
	[CompilerGenerated]
	private sealed class <AddResidentEffect>c__AnonStorey1E
	{
		// Token: 0x0600681C RID: 26652 RVA: 0x001BEBDA File Offset: 0x001BCFDA
		public <AddResidentEffect>c__AnonStorey1E()
		{
		}

		// Token: 0x0600681D RID: 26653 RVA: 0x001BEBE2 File Offset: 0x001BCFE2
		internal bool <>m__0(ResidentEffectLocalization i)
		{
			return i.EffectType != this.r;
		}

		// Token: 0x040061F5 RID: 25077
		internal ResidentEffectType r;
	}

	// Token: 0x0200102B RID: 4139
	[CompilerGenerated]
	private sealed class <AddUpgradeCard>c__AnonStorey1F
	{
		// Token: 0x0600681E RID: 26654 RVA: 0x001BEBF5 File Offset: 0x001BCFF5
		public <AddUpgradeCard>c__AnonStorey1F()
		{
		}

		// Token: 0x0600681F RID: 26655 RVA: 0x001BEBFD File Offset: 0x001BCFFD
		internal bool <>m__0(UpgradeCardLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x040061F6 RID: 25078
		internal UpgradeCardType r;
	}

	// Token: 0x0200102C RID: 4140
	[CompilerGenerated]
	private sealed class <AddBattleOption>c__AnonStorey20
	{
		// Token: 0x06006820 RID: 26656 RVA: 0x001BEC10 File Offset: 0x001BD010
		public <AddBattleOption>c__AnonStorey20()
		{
		}

		// Token: 0x06006821 RID: 26657 RVA: 0x001BEC18 File Offset: 0x001BD018
		internal bool <>m__0(BattleOptionLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x040061F7 RID: 25079
		internal BattleOptionType r;
	}

	// Token: 0x0200102D RID: 4141
	[CompilerGenerated]
	private sealed class <AddVehicle>c__AnonStorey21
	{
		// Token: 0x06006822 RID: 26658 RVA: 0x001BEC2B File Offset: 0x001BD02B
		public <AddVehicle>c__AnonStorey21()
		{
		}

		// Token: 0x06006823 RID: 26659 RVA: 0x001BEC33 File Offset: 0x001BD033
		internal bool <>m__0(VehicleLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x040061F8 RID: 25080
		internal VehicleType r;
	}

	// Token: 0x0200102E RID: 4142
	[CompilerGenerated]
	private sealed class <AddJourneyContribution>c__AnonStorey22
	{
		// Token: 0x06006824 RID: 26660 RVA: 0x001BEC46 File Offset: 0x001BD046
		public <AddJourneyContribution>c__AnonStorey22()
		{
		}

		// Token: 0x06006825 RID: 26661 RVA: 0x001BEC4E File Offset: 0x001BD04E
		internal bool <>m__0(JourneyContributionLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x040061F9 RID: 25081
		internal JourneyContributeType r;
	}

	// Token: 0x0200102F RID: 4143
	[CompilerGenerated]
	private sealed class <AddVehicleAttribute>c__AnonStorey23
	{
		// Token: 0x06006826 RID: 26662 RVA: 0x001BEC61 File Offset: 0x001BD061
		public <AddVehicleAttribute>c__AnonStorey23()
		{
		}

		// Token: 0x06006827 RID: 26663 RVA: 0x001BEC69 File Offset: 0x001BD069
		internal bool <>m__0(VehicleAttributeLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x040061FA RID: 25082
		internal VehicleAttributeType r;
	}

	// Token: 0x02001030 RID: 4144
	[CompilerGenerated]
	private sealed class <AddTripEncounter>c__AnonStorey24
	{
		// Token: 0x06006828 RID: 26664 RVA: 0x001BEC7C File Offset: 0x001BD07C
		public <AddTripEncounter>c__AnonStorey24()
		{
		}

		// Token: 0x06006829 RID: 26665 RVA: 0x001BEC84 File Offset: 0x001BD084
		internal bool <>m__0(TripEncounterLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x040061FB RID: 25083
		internal TripEncounterType r;
	}

	// Token: 0x02001031 RID: 4145
	[CompilerGenerated]
	private sealed class <AddTripEncounterOutcome>c__AnonStorey25
	{
		// Token: 0x0600682A RID: 26666 RVA: 0x001BEC97 File Offset: 0x001BD097
		public <AddTripEncounterOutcome>c__AnonStorey25()
		{
		}

		// Token: 0x0600682B RID: 26667 RVA: 0x001BEC9F File Offset: 0x001BD09F
		internal bool <>m__0(TripOutcomeLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x040061FC RID: 25084
		internal TripEncounterOutcomeType r;
	}

	// Token: 0x02001032 RID: 4146
	[CompilerGenerated]
	private sealed class <AddDestination>c__AnonStorey26
	{
		// Token: 0x0600682C RID: 26668 RVA: 0x001BECB2 File Offset: 0x001BD0B2
		public <AddDestination>c__AnonStorey26()
		{
		}

		// Token: 0x0600682D RID: 26669 RVA: 0x001BECBA File Offset: 0x001BD0BA
		internal bool <>m__0(DestinationLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x040061FD RID: 25085
		internal DestinationType r;
	}

	// Token: 0x02001033 RID: 4147
	[CompilerGenerated]
	private sealed class <AddUnitStyle>c__AnonStorey27
	{
		// Token: 0x0600682E RID: 26670 RVA: 0x001BECCD File Offset: 0x001BD0CD
		public <AddUnitStyle>c__AnonStorey27()
		{
		}

		// Token: 0x0600682F RID: 26671 RVA: 0x001BECD5 File Offset: 0x001BD0D5
		internal bool <>m__0(UnitStyleLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x040061FE RID: 25086
		internal UnitClassStyle r;
	}

	// Token: 0x02001034 RID: 4148
	[CompilerGenerated]
	private sealed class <AddTalent>c__AnonStorey28
	{
		// Token: 0x06006830 RID: 26672 RVA: 0x001BECE8 File Offset: 0x001BD0E8
		public <AddTalent>c__AnonStorey28()
		{
		}

		// Token: 0x06006831 RID: 26673 RVA: 0x001BECF0 File Offset: 0x001BD0F0
		internal bool <>m__0(TalentLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x040061FF RID: 25087
		internal AdventurerTalentType r;
	}

	// Token: 0x02001035 RID: 4149
	[CompilerGenerated]
	private sealed class <AddTownEvent>c__AnonStorey29
	{
		// Token: 0x06006832 RID: 26674 RVA: 0x001BED03 File Offset: 0x001BD103
		public <AddTownEvent>c__AnonStorey29()
		{
		}

		// Token: 0x06006833 RID: 26675 RVA: 0x001BED0B File Offset: 0x001BD10B
		internal bool <>m__0(TownEventLocalizaiton i)
		{
			return i.Type != this.r;
		}

		// Token: 0x04006200 RID: 25088
		internal TownEventType r;
	}

	// Token: 0x02001036 RID: 4150
	[CompilerGenerated]
	private sealed class <AddTownEffect>c__AnonStorey2A
	{
		// Token: 0x06006834 RID: 26676 RVA: 0x001BED1E File Offset: 0x001BD11E
		public <AddTownEffect>c__AnonStorey2A()
		{
		}

		// Token: 0x06006835 RID: 26677 RVA: 0x001BED26 File Offset: 0x001BD126
		internal bool <>m__0(TownEffectLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x04006201 RID: 25089
		internal TownEffectType r;
	}

	// Token: 0x02001037 RID: 4151
	[CompilerGenerated]
	private sealed class <AddCandidateMetric>c__AnonStorey2B
	{
		// Token: 0x06006836 RID: 26678 RVA: 0x001BED39 File Offset: 0x001BD139
		public <AddCandidateMetric>c__AnonStorey2B()
		{
		}

		// Token: 0x06006837 RID: 26679 RVA: 0x001BED41 File Offset: 0x001BD141
		internal bool <>m__0(CandidateOrderMetricLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x04006202 RID: 25090
		internal CandidateOrderringMetric r;
	}

	// Token: 0x02001038 RID: 4152
	[CompilerGenerated]
	private sealed class <AddOrderType>c__AnonStorey2C
	{
		// Token: 0x06006838 RID: 26680 RVA: 0x001BED54 File Offset: 0x001BD154
		public <AddOrderType>c__AnonStorey2C()
		{
		}

		// Token: 0x06006839 RID: 26681 RVA: 0x001BED5C File Offset: 0x001BD15C
		internal bool <>m__0(OrderTypeLocalization i)
		{
			return i.Type != this.r;
		}

		// Token: 0x04006203 RID: 25091
		internal OrderingType r;
	}
}
