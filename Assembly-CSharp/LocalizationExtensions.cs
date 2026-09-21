using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

// Token: 0x0200049A RID: 1178
public static class LocalizationExtensions
{
	// Token: 0x060022C3 RID: 8899 RVA: 0x000FEEB0 File Offset: 0x000FD2B0
	public static Description GetDescription(this SpecialEffectType type)
	{
		SpecialEffectLocalization specialEffectLocalization = LocalizationSession.instance.LocalizationManager.GetSpecialEffectLocalization(type);
		return new Description
		{
			Details1 = specialEffectLocalization.Description,
			Title = specialEffectLocalization.Name
		};
	}

	// Token: 0x060022C4 RID: 8900 RVA: 0x000FEEF0 File Offset: 0x000FD2F0
	public static Description GetDescription(this GrowthConditionType type)
	{
		GrowthSpecialEffectConditionLocalization growthLocalization = LocalizationSession.instance.LocalizationManager.GetGrowthLocalization(type);
		return new Description
		{
			Details1 = growthLocalization.Description,
			Title = growthLocalization.Name
		};
	}

	// Token: 0x060022C5 RID: 8901 RVA: 0x000FEF30 File Offset: 0x000FD330
	public static Description GetDescription(this ResourceType type)
	{
		ResourceLocalization itemLocalization = LocalizationSession.instance.LocalizationManager.GetItemLocalization(type);
		return new Description
		{
			Details1 = itemLocalization.Description,
			Title = itemLocalization.Title
		};
	}

	// Token: 0x060022C6 RID: 8902 RVA: 0x000FEF70 File Offset: 0x000FD370
	public static Description GetDescription(this ResourceCategory type)
	{
		ItemCategoryLocalization itemCategoryLocalization = LocalizationSession.instance.LocalizationManager.GetItemCategoryLocalization(type);
		return new Description
		{
			Details1 = itemCategoryLocalization.Description,
			Title = itemCategoryLocalization.Title
		};
	}

	// Token: 0x060022C7 RID: 8903 RVA: 0x000FEFB0 File Offset: 0x000FD3B0
	public static Description GetDescription(this UnitClass @class)
	{
		UnitLocalization unitLocalization = LocalizationSession.instance.LocalizationManager.GetUnitLocalization(@class);
		return new Description
		{
			Details1 = unitLocalization.Description,
			Title = unitLocalization.Title
		};
	}

	// Token: 0x060022C8 RID: 8904 RVA: 0x000FEFF0 File Offset: 0x000FD3F0
	public static Description GetDescription(this BuildingType type)
	{
		BuildingLocalization buildingLocalization = LocalizationSession.instance.LocalizationManager.GetBuildingLocalization(type);
		return new Description
		{
			Details1 = buildingLocalization.Description,
			Title = buildingLocalization.Title
		};
	}

	// Token: 0x060022C9 RID: 8905 RVA: 0x000FF030 File Offset: 0x000FD430
	public static Description GetDescription(this AttributeType type)
	{
		AttributeLocalization attributeLocalization = LocalizationSession.instance.LocalizationManager.GetAttributeLocalization(type);
		return new Description
		{
			Details1 = attributeLocalization.Description,
			Title = attributeLocalization.Name
		};
	}

	// Token: 0x060022CA RID: 8906 RVA: 0x000FF070 File Offset: 0x000FD470
	public static Description GetDescription(this AdventureType type)
	{
		AdventureLocalization adventureLocalization = LocalizationSession.instance.LocalizationManager.GetAdventureLocalization(type);
		return new Description
		{
			Details1 = adventureLocalization.Description,
			Title = adventureLocalization.Title
		};
	}

	// Token: 0x060022CB RID: 8907 RVA: 0x000FF0B0 File Offset: 0x000FD4B0
	public static Description GetDescription(this QuestRequirementType type)
	{
		QuestRequirementLocalization questRequirementLocalization = LocalizationSession.instance.LocalizationManager.GetQuestRequirementLocalization(type);
		return new Description
		{
			Details1 = questRequirementLocalization.Description,
			Title = questRequirementLocalization.Title
		};
	}

	// Token: 0x060022CC RID: 8908 RVA: 0x000FF0F0 File Offset: 0x000FD4F0
	public static Description GetDescription(this ResidentType type)
	{
		ResidentLocalization localization = type.GetLocalization();
		return new Description
		{
			Details1 = localization.Description,
			Title = localization.Name
		};
	}

	// Token: 0x060022CD RID: 8909 RVA: 0x000FF124 File Offset: 0x000FD524
	public static Description GetDescription(this QuestIdentifier identifier)
	{
		QuestLocalization questLocalization = LocalizationSession.instance.LocalizationManager.GetQuestLocalization(identifier);
		return new Description
		{
			Details1 = questLocalization.Description,
			Title = questLocalization.Title
		};
	}

	// Token: 0x060022CE RID: 8910 RVA: 0x000FF161 File Offset: 0x000FD561
	public static AttributeLocalization GetLocalization(this AttributeType type)
	{
		return LocalizationSession.instance.LocalizationManager.GetAttributeLocalization(type);
	}

	// Token: 0x060022CF RID: 8911 RVA: 0x000FF174 File Offset: 0x000FD574
	public static Description GetDescription(this ClassCategory category)
	{
		UnitCategoryLocalization unitCategoryLocalization = LocalizationSession.instance.LocalizationManager.GetUnitCategoryLocalization(category);
		return new Description
		{
			Details1 = unitCategoryLocalization.Description,
			Title = unitCategoryLocalization.Name
		};
	}

	// Token: 0x060022D0 RID: 8912 RVA: 0x000FF1B4 File Offset: 0x000FD5B4
	public static Description GetDescription(this TownTitleType type)
	{
		TownTitleLocalization townTitleLocalization = LocalizationSession.instance.LocalizationManager.GetTownTitleLocalization(type);
		return new Description
		{
			Details1 = townTitleLocalization.Description,
			Title = townTitleLocalization.Name
		};
	}

	// Token: 0x060022D1 RID: 8913 RVA: 0x000FF1F4 File Offset: 0x000FD5F4
	public static Description GetDescription(this Item item)
	{
		Description description = item.Type.GetDescription();
		List<AttributeModifier> attributeModifiers = item.GetAttributeModifiers();
		if (attributeModifiers.Any((AttributeModifier m) => m.AttributeType == AttributeType.Strength && m.ModificationType == ModificationType.Multiplication))
		{
			double num = (from m in attributeModifiers
			where m.AttributeType == AttributeType.Strength && m.ModificationType == ModificationType.Multiplication
			select m).Sum((AttributeModifier m) => m.Value);
			description.Details1 = description.Details1.Replace("{strengthincreaserate}", (num * 100.0).ToExpression());
		}
		if (attributeModifiers.Any((AttributeModifier m) => m.AttributeType == AttributeType.Intelligience && m.ModificationType == ModificationType.Multiplication))
		{
			double num2 = (from m in attributeModifiers
			where m.AttributeType == AttributeType.Intelligience && m.ModificationType == ModificationType.Multiplication
			select m).Sum((AttributeModifier m) => m.Value);
			description.Details1 = description.Details1.Replace("{intelligienceincreaserate}", (num2 * 100.0).ToExpression());
		}
		return description;
	}

	// Token: 0x060022D2 RID: 8914 RVA: 0x000FF33D File Offset: 0x000FD73D
	public static Description GetDescription(this IBuildingProfile building)
	{
		return building.BuildingType.GetDescription();
	}

	// Token: 0x060022D3 RID: 8915 RVA: 0x000FF34A File Offset: 0x000FD74A
	public static Description GetDescription(this AdventurerProfile adventurer)
	{
		return adventurer.UnitClass.GetDescription();
	}

	// Token: 0x060022D4 RID: 8916 RVA: 0x000FF357 File Offset: 0x000FD757
	public static Description GetDescription(this IBattleUnit unit)
	{
		return unit.GetUnitType().GetDescription();
	}

	// Token: 0x060022D5 RID: 8917 RVA: 0x000FF364 File Offset: 0x000FD764
	public static Description GetDescription(this Adventure adventure)
	{
		return adventure.AdventureType.GetDescription();
	}

	// Token: 0x060022D6 RID: 8918 RVA: 0x000FF374 File Offset: 0x000FD774
	public static Description GetDescription(this Quest quest)
	{
		Description description = quest.QuestIdentifier.GetDescription();
		StringBuilder stringBuilder = new StringBuilder(description.Title);
		StringBuilder stringBuilder2 = new StringBuilder(description.Details1);
		if (quest.QuestIdentifier == QuestIdentifier.MonsterKill)
		{
			MonsterKillRequirementLogic monsterKillRequirementLogic = quest.QuestRequirements.OfType<MonsterKillRequirementLogic>().FirstOrDefault<MonsterKillRequirementLogic>();
			if (monsterKillRequirementLogic != null)
			{
				stringBuilder.Replace("{monsterslot}", monsterKillRequirementLogic.MonsterSlotType.GetDescription().Title).Replace("{monstertype}", monsterKillRequirementLogic.MonsterClass.GetDescription().Title);
				stringBuilder2.Replace("{monsterslot}", monsterKillRequirementLogic.MonsterSlotType.GetDescription().Title).Replace("{monstertype}", monsterKillRequirementLogic.MonsterClass.GetDescription().Title);
			}
		}
		if (quest.QuestIdentifier == QuestIdentifier.Heresy_p1 || quest.QuestIdentifier == QuestIdentifier.Heresy_p2)
		{
			CustomizedDungeonThroughRequirementLogic customizedDungeonThroughRequirementLogic = quest.QuestRequirements.OfType<CustomizedDungeonThroughRequirementLogic>().FirstOrDefault<CustomizedDungeonThroughRequirementLogic>();
			if (customizedDungeonThroughRequirementLogic != null)
			{
				stringBuilder.Replace("{dungeontype}", customizedDungeonThroughRequirementLogic.DungeonType.GetDescription().Title);
				stringBuilder2.Replace("{dungeontype}", customizedDungeonThroughRequirementLogic.DungeonType.GetDescription().Title).Replace("{effects}", string.Join("\n", (from d in customizedDungeonThroughRequirementLogic.Configuration.DungeonEffects
				select d.GetDescription().Details1).ToArray<string>()));
			}
		}
		description.Title = stringBuilder.ToString();
		description.Details1 = stringBuilder2.ToString();
		return description;
	}

	// Token: 0x060022D7 RID: 8919 RVA: 0x000FF504 File Offset: 0x000FD904
	public static Description GetDescription(this QuestRequirementBase questRequirement)
	{
		Description description = questRequirement.CorrespondingQuestRequirementType.GetDescription();
		StringBuilder stringBuilder = new StringBuilder(description.Details1);
		if (questRequirement is DungeonExplorationRequirementLogic)
		{
			DungeonExplorationRequirementLogic dungeonExplorationRequirementLogic = questRequirement as DungeonExplorationRequirementLogic;
			stringBuilder.Replace("{dungeontype}", dungeonExplorationRequirementLogic.DungeonType.GetDescription().Title).Replace("{levelnumber}", dungeonExplorationRequirementLogic.LevelNumber.ToString());
		}
		if (questRequirement is DungeonCompletionRequirementLogic)
		{
			DungeonCompletionRequirementLogic dungeonCompletionRequirementLogic = questRequirement as DungeonCompletionRequirementLogic;
			stringBuilder.Replace("{dungeontype}", dungeonCompletionRequirementLogic.DungeonType.GetDescription().Title).Replace("{levelnumber}", dungeonCompletionRequirementLogic.LevelNumber.ToString());
		}
		if (questRequirement is HundredBattleRequirementLogic)
		{
			HundredBattleRequirementLogic hundredBattleRequirementLogic = questRequirement as HundredBattleRequirementLogic;
			stringBuilder.Replace("{dungeontype}", hundredBattleRequirementLogic.DungeonType.GetDescription().Title).Replace("{completed}", hundredBattleRequirementLogic.CompletedOEncounters.ToString()).ToString();
		}
		if (questRequirement is MonsterKillRequirementLogic)
		{
			MonsterKillRequirementLogic monsterKillRequirementLogic = questRequirement as MonsterKillRequirementLogic;
			stringBuilder.Replace("{dungeons}", string.Join(",", (from d in monsterKillRequirementLogic.RequiredDungeons
			select d.GetDescription().Title).ToArray<string>())).Replace("{levels}", string.Join(", ", (from l in monsterKillRequirementLogic.RequiredLevels
			select l.ToString()).ToArray<string>())).Replace("{killed}", monsterKillRequirementLogic.KilledAmount.ToString()).Replace("{total}", monsterKillRequirementLogic.RequiredKills.ToString()).Replace("{killtype}", monsterKillRequirementLogic.MonsterClass.GetDescription().Title);
		}
		if (questRequirement is RecruitHeroRequirementLogic)
		{
			RecruitHeroRequirementLogic recruitHeroRequirementLogic = questRequirement as RecruitHeroRequirementLogic;
			stringBuilder.Replace("{total}", recruitHeroRequirementLogic.RequiredAmount.ToString()).Replace("{count}", recruitHeroRequirementLogic.AmountSoFar.ToString());
		}
		if (questRequirement is ObtainResourceRequirementLogic)
		{
			ObtainResourceRequirementLogic obtainResourceRequirementLogic = questRequirement as ObtainResourceRequirementLogic;
			stringBuilder.Replace("{resourcetype}", obtainResourceRequirementLogic.ResourceType.GetDescription().Title).Replace("{total}", obtainResourceRequirementLogic.RequiredAmount.ToString()).Replace("{completed}", ((int)obtainResourceRequirementLogic.ObtainedRelevantResource.Sum((ResourceUpdate r) => r.ChangeAmount)).ToString());
		}
		if (questRequirement is WeaponProductionRequirementLogic)
		{
			WeaponProductionRequirementLogic weaponProductionRequirementLogic = questRequirement as WeaponProductionRequirementLogic;
			stringBuilder.Replace("{total}", weaponProductionRequirementLogic.RequiredAmount.ToString()).Replace("{produced}", weaponProductionRequirementLogic.ProducedAmountSoFar.ToString());
		}
		if (questRequirement is ArmorProductionRequirement)
		{
			ArmorProductionRequirement armorProductionRequirement = questRequirement as ArmorProductionRequirement;
			stringBuilder.Replace("{total}", armorProductionRequirement.RequiredAmount.ToString()).Replace("{produced}", armorProductionRequirement.ProducedAmountSoFar.ToString());
		}
		if (questRequirement is PurchaseItemRequirementLogic)
		{
			PurchaseItemRequirementLogic purchaseItemRequirementLogic = questRequirement as PurchaseItemRequirementLogic;
			stringBuilder.Replace("{total}", purchaseItemRequirementLogic.RequirementNumberOfPurchases.ToString()).Replace("{purchased}", purchaseItemRequirementLogic.PurchasedSoFar.ToString());
		}
		if (questRequirement is ResidencyOccupancyChangeRequirementLogic)
		{
			ResidencyOccupancyChangeRequirementLogic residencyOccupancyChangeRequirementLogic = questRequirement as ResidencyOccupancyChangeRequirementLogic;
			stringBuilder.Replace("{total}", residencyOccupancyChangeRequirementLogic.RequiredAmount.ToString()).Replace("{changes}", residencyOccupancyChangeRequirementLogic.ChangesSoFar.ToString());
		}
		if (questRequirement is ResidentCollectionRequirementLogic)
		{
			ResidentCollectionRequirementLogic residentCollectionRequirementLogic = questRequirement as ResidentCollectionRequirementLogic;
			stringBuilder.Replace("{total}", residentCollectionRequirementLogic.RequirementNumberOfCollection.ToString()).Replace("{collected}", residentCollectionRequirementLogic.CollectedAmountSoFar.ToString());
		}
		if (questRequirement is SaleWeaponRequirementLogic)
		{
			SaleWeaponRequirementLogic saleWeaponRequirementLogic = questRequirement as SaleWeaponRequirementLogic;
			stringBuilder.Replace("{total}", saleWeaponRequirementLogic.RequirementAmount.ToString()).Replace("{sold}", saleWeaponRequirementLogic.SaleSoFar.ToString());
		}
		if (questRequirement is SaleArmorRequirementLogic)
		{
			SaleArmorRequirementLogic saleArmorRequirementLogic = questRequirement as SaleArmorRequirementLogic;
			stringBuilder.Replace("{total}", saleArmorRequirementLogic.RequirementAmount.ToString()).Replace("{sold}", saleArmorRequirementLogic.SaleSoFar.ToString());
		}
		if (questRequirement is AdventurerTacticUnlockRequirementLogic)
		{
			AdventurerTacticUnlockRequirementLogic adventurerTacticUnlockRequirementLogic = questRequirement as AdventurerTacticUnlockRequirementLogic;
			stringBuilder.Replace("{total}", adventurerTacticUnlockRequirementLogic.RequiredAmount.ToString()).Replace("{completed}", adventurerTacticUnlockRequirementLogic.AmountSoFar.ToString());
		}
		if (questRequirement is TotalResidentsRequirementLogic)
		{
			TotalResidentsRequirementLogic totalResidentsRequirementLogic = questRequirement as TotalResidentsRequirementLogic;
			stringBuilder.Replace("{total}", totalResidentsRequirementLogic.RequiredAmount.ToString()).Replace("{current}", totalResidentsRequirementLogic.CurrentAmount.ToString());
		}
		if (questRequirement is ActiveSkillCastRequirementLogic)
		{
			ActiveSkillCastRequirementLogic activeSkillCastRequirementLogic = questRequirement as ActiveSkillCastRequirementLogic;
			stringBuilder.Replace("{total}", activeSkillCastRequirementLogic.NumberOfRequired.ToString()).Replace("{current}", activeSkillCastRequirementLogic.CurrentCount.ToString());
		}
		if (questRequirement is SchoolLearningRequirementLogic)
		{
			SchoolLearningRequirementLogic schoolLearningRequirementLogic = questRequirement as SchoolLearningRequirementLogic;
			stringBuilder.Replace("{total}", schoolLearningRequirementLogic.RequiredAmount.ToString()).Replace("{current}", schoolLearningRequirementLogic.CurrentCount.ToString());
		}
		if (questRequirement is CustomizedDungeonThroughRequirementLogic)
		{
			CustomizedDungeonThroughRequirementLogic customizedDungeonThroughRequirementLogic = questRequirement as CustomizedDungeonThroughRequirementLogic;
			if (customizedDungeonThroughRequirementLogic.IsTwistedTimeDungeon)
			{
				stringBuilder = new StringBuilder(description.Details1.Split(new char[]
				{
					';'
				}).First<string>()).Replace("{type}", customizedDungeonThroughRequirementLogic.DungeonType.GetDescription().Title);
			}
			else
			{
				stringBuilder = new StringBuilder(description.Details1.Split(new char[]
				{
					';'
				}).Last<string>()).Replace("{type}", customizedDungeonThroughRequirementLogic.DungeonType.GetDescription().Title).Replace("{level}", customizedDungeonThroughRequirementLogic.Configuration.LevelNumber.ToString());
			}
		}
		if (questRequirement is ItemCombineRequirementLogic)
		{
			ItemCombineRequirementLogic itemCombineRequirementLogic = questRequirement as ItemCombineRequirementLogic;
			stringBuilder.Replace("{total}", itemCombineRequirementLogic.RequiredAmount.ToString()).Replace("{current}", itemCombineRequirementLogic.AmountSoFar.ToString());
		}
		description.Details1 = stringBuilder.ToString();
		return description;
	}

	// Token: 0x060022D8 RID: 8920 RVA: 0x000FFC3A File Offset: 0x000FE03A
	public static EffectLocalization GetLocalization(this BattleEffectType type)
	{
		return LocalizationSession.instance.LocalizationManager.GetEffectLocalization(type);
	}

	// Token: 0x060022D9 RID: 8921 RVA: 0x000FFC4C File Offset: 0x000FE04C
	public static Description GetDescription(this BattleEffectType type)
	{
		return type.GetLocalization().CreateDescription();
	}

	// Token: 0x060022DA RID: 8922 RVA: 0x000FFC59 File Offset: 0x000FE059
	public static Description GetDescription(this SkillType type)
	{
		return type.GetLocalization().CreateDescription();
	}

	// Token: 0x060022DB RID: 8923 RVA: 0x000FFC66 File Offset: 0x000FE066
	public static Description GetDescription(this Skill skill)
	{
		return skill.SkillType.GetSkillLogic().ParseDescription(skill);
	}

	// Token: 0x060022DC RID: 8924 RVA: 0x000FFC7C File Offset: 0x000FE07C
	public static Description GetDescription(this QualityGrade grade)
	{
		ItemGradeLocalization itemGradeLocalization = LocalizationSession.instance.LocalizationManager.GetItemGradeLocalization(grade);
		return new Description
		{
			Details1 = itemGradeLocalization.Description,
			Title = itemGradeLocalization.Name
		};
	}

	// Token: 0x060022DD RID: 8925 RVA: 0x000FFCBC File Offset: 0x000FE0BC
	public static Description GetDescription(this QuestChainIdentifier type)
	{
		QuestChainLocalization questChainLocalization = LocalizationSession.instance.LocalizationManager.GetQuestChainLocalization(type);
		return new Description
		{
			Details1 = questChainLocalization.Description,
			Title = questChainLocalization.Name
		};
	}

	// Token: 0x060022DE RID: 8926 RVA: 0x000FFCFC File Offset: 0x000FE0FC
	public static Description GetDescription(this AdventureEventType type)
	{
		BattleEventLocalization battleEventLocalization = LocalizationSession.instance.LocalizationManager.GetBattleEventLocalization(type);
		return new Description
		{
			Details1 = battleEventLocalization.Description,
			Title = battleEventLocalization.Name
		};
	}

	// Token: 0x060022DF RID: 8927 RVA: 0x000FFD3C File Offset: 0x000FE13C
	public static Description GetDescription(this OutputType type)
	{
		OutputTypeLocalization outputLocalization = LocalizationSession.instance.LocalizationManager.GetOutputLocalization(type);
		return new Description
		{
			Details1 = outputLocalization.Description,
			Title = outputLocalization.Name,
			Details2 = outputLocalization.Description.Replace(" Damage", string.Empty).Replace("伤害", string.Empty)
		};
	}

	// Token: 0x060022E0 RID: 8928 RVA: 0x000FFDA4 File Offset: 0x000FE1A4
	public static Description GetDescription(this BoostType type)
	{
		BoostTypeLocalization boostTypeLocalization = LocalizationSession.instance.LocalizationManager.GetBoostTypeLocalization(type);
		return new Description
		{
			Details1 = boostTypeLocalization.Description,
			Title = boostTypeLocalization.Name
		};
	}

	// Token: 0x060022E1 RID: 8929 RVA: 0x000FFDE4 File Offset: 0x000FE1E4
	public static Description GetDescription(this TargetCandidateType type)
	{
		TargetCandidateTypeLocalization targetCandidateTypeLocalization = LocalizationSession.instance.LocalizationManager.GetTargetCandidateTypeLocalization(type);
		return new Description
		{
			Details1 = targetCandidateTypeLocalization.Description,
			Title = targetCandidateTypeLocalization.Name
		};
	}

	// Token: 0x060022E2 RID: 8930 RVA: 0x000FFE24 File Offset: 0x000FE224
	public static Description GetDescription(this AdventureEncounterSlotType type)
	{
		MonsterSlotLocalization monsterSlotLocalization = LocalizationSession.instance.LocalizationManager.GetMonsterSlotLocalization(type);
		return new Description
		{
			Details1 = monsterSlotLocalization.Description,
			Title = monsterSlotLocalization.Name
		};
	}

	// Token: 0x060022E3 RID: 8931 RVA: 0x000FFE64 File Offset: 0x000FE264
	public static Description GetDescription(this IBattleOption option)
	{
		BattleOptionLocalization battleOptionLocalization = LocalizationSession.instance.LocalizationManager.GetBattleOptionLocalization(option.GetBattleOptionType());
		return new Description
		{
			Details1 = battleOptionLocalization.Description,
			Details2 = string.Empty,
			Title = battleOptionLocalization.Name
		};
	}

	// Token: 0x060022E4 RID: 8932 RVA: 0x000FFEB1 File Offset: 0x000FE2B1
	public static QuestRequirementLocalization GetLocalization(this QuestRequirementType type)
	{
		return LocalizationSession.instance.LocalizationManager.GetQuestRequirementLocalization(type);
	}

	// Token: 0x060022E5 RID: 8933 RVA: 0x000FFEC3 File Offset: 0x000FE2C3
	public static RewardTypeLocalization GetLocalization(this RewardType type)
	{
		return LocalizationSession.instance.LocalizationManager.GetRewardTypeLocalization(type);
	}

	// Token: 0x060022E6 RID: 8934 RVA: 0x000FFED5 File Offset: 0x000FE2D5
	public static SkillLocalization GetLocalization(this SkillType type)
	{
		return LocalizationSession.instance.LocalizationManager.GetSkillDescription(type);
	}

	// Token: 0x060022E7 RID: 8935 RVA: 0x000FFEE7 File Offset: 0x000FE2E7
	public static ResidentLocalization GetLocalization(this ResidentType type)
	{
		return LocalizationSession.instance.LocalizationManager.GetResidentLocalization(type);
	}

	// Token: 0x060022E8 RID: 8936 RVA: 0x000FFEFC File Offset: 0x000FE2FC
	public static Description GetDescription(this ModificationType type)
	{
		AttributeModificationTypeLocalization attributeModificationTypeLocalization = LocalizationSession.instance.LocalizationManager.GetAttributeModificationTypeLocalization(type);
		return new Description
		{
			Details1 = attributeModificationTypeLocalization.Description,
			Details2 = string.Empty,
			Title = attributeModificationTypeLocalization.Name
		};
	}

	// Token: 0x060022E9 RID: 8937 RVA: 0x000FFF44 File Offset: 0x000FE344
	public static Description GetDescription(this SocketType type)
	{
		SocketTypeLocalization socketLocalization = LocalizationSession.instance.LocalizationManager.GetSocketLocalization(type);
		return new Description
		{
			Details1 = socketLocalization.Description,
			Details2 = string.Empty,
			Title = socketLocalization.Name
		};
	}

	// Token: 0x060022EA RID: 8938 RVA: 0x000FFF8C File Offset: 0x000FE38C
	public static Description GetDescription(this UpgradeCardType type)
	{
		UpgradeCardLocalization cardUpgradeLocalization = LocalizationSession.instance.LocalizationManager.GetCardUpgradeLocalization(type);
		return new Description
		{
			Details1 = cardUpgradeLocalization.Description,
			Details2 = string.Empty,
			Title = cardUpgradeLocalization.Name
		};
	}

	// Token: 0x060022EB RID: 8939 RVA: 0x000FFFD4 File Offset: 0x000FE3D4
	public static Description GetDescription(this CardUpgrade upgrade)
	{
		Description description = upgrade.CorrespondingCardType.GetDescription();
		StringBuilder stringBuilder = new StringBuilder(description.Details1);
		if ((upgrade.CorrespondingCardType == UpgradeCardType.OutputBoost || upgrade.CorrespondingCardType == UpgradeCardType.ElementalEnhancement || upgrade.CorrespondingCardType == UpgradeCardType.ElementalResistance) && upgrade.Modifiers.Any<AttributeModifier>())
		{
			stringBuilder.Replace("{attributetype}", upgrade.Modifiers[0].AttributeType.GetDescription().Title).Replace("{value}", upgrade.Modifiers[0].GetDisplayValue().ToDisplayValueFormat());
		}
		if (upgrade.CorrespondingCardType == UpgradeCardType.ElementalEffects)
		{
			ElementEffectData elementEffectData = upgrade.Effects.OfType<ElementEffectData>().FirstOrDefault<ElementEffectData>();
			if (elementEffectData != null)
			{
				Description description2 = elementEffectData.ElementType.GetDescription();
				stringBuilder.Replace("{element}", description2.Title).Replace("{details}", description2.Details1);
			}
		}
		if ((upgrade.CorrespondingCardType == UpgradeCardType.CritDamageBoost || upgrade.CorrespondingCardType == UpgradeCardType.TauntBoost) && upgrade.Modifiers.Any<AttributeModifier>())
		{
			stringBuilder.Replace("{value}", upgrade.Modifiers[0].Value.ToExpressionMultiply100());
		}
		if (upgrade.CorrespondingCardType == UpgradeCardType.Speedness && upgrade.Modifiers.Any<AttributeModifier>())
		{
			stringBuilder.Replace("{value}", upgrade.Modifiers[0].Value.ToExpression());
		}
		if (upgrade.CorrespondingCardType == UpgradeCardType.RagePower)
		{
			AttributeModifier attributeModifier = upgrade.Modifiers.FirstOrDefault((AttributeModifier m) => m.AttributeType == AttributeType.SkillRageEfficiencyRate);
			if (attributeModifier != null)
			{
				stringBuilder.Replace("{value}", attributeModifier.Value.ToExpressionMultiply100());
			}
		}
		if (upgrade.CorrespondingCardType == UpgradeCardType.Revenge)
		{
			AttributeModifier attributeModifier2 = upgrade.Modifiers.FirstOrDefault((AttributeModifier f) => f.AttributeType == AttributeType.ReflectiveDamage);
			if (attributeModifier2 != null)
			{
				stringBuilder.Replace("{reflectdamage}", attributeModifier2.Value.ToExpressionMultiply100());
			}
			AttributeModifier attributeModifier3 = upgrade.Modifiers.FirstOrDefault((AttributeModifier f) => f.AttributeType == AttributeType.HealingAbsorbRate);
			if (attributeModifier3 != null)
			{
				stringBuilder.Replace("{ragerate}", attributeModifier3.Value.ToExpressionMultiply100());
			}
		}
		if (upgrade.CorrespondingCardType == UpgradeCardType.Vitality)
		{
			AttributeModifier attributeModifier4 = upgrade.Modifiers.FirstOrDefault((AttributeModifier f) => f.AttributeType == AttributeType.Vitality);
			if (attributeModifier4 != null)
			{
				stringBuilder.Replace("{value}", attributeModifier4.Value.ToExpression());
			}
		}
		if (upgrade.CorrespondingCardType == UpgradeCardType.Stun)
		{
			AttributeModifier attributeModifier5 = upgrade.Modifiers.FirstOrDefault((AttributeModifier f) => f.AttributeType == AttributeType.StunOnHit);
			if (attributeModifier5 != null)
			{
				stringBuilder.Replace("{value}", attributeModifier5.Value.ToExpressionMultiply100());
			}
		}
		if (upgrade.CorrespondingCardType == UpgradeCardType.Reflection)
		{
			AttributeModifier attributeModifier6 = upgrade.Modifiers.FirstOrDefault((AttributeModifier f) => f.AttributeType == AttributeType.ReflectiveDamage);
			if (attributeModifier6 != null)
			{
				stringBuilder.Replace("{value}", attributeModifier6.Value.ToExpressionMultiply100());
			}
		}
		if (upgrade.CorrespondingCardType == UpgradeCardType.Absorb)
		{
			AttributeModifier attributeModifier7 = upgrade.Modifiers.FirstOrDefault((AttributeModifier f) => f.AttributeType == AttributeType.HealingAbsorbRate);
			if (attributeModifier7 != null)
			{
				stringBuilder.Replace("{value}", attributeModifier7.Value.ToExpressionMultiply100());
			}
		}
		description.Details1 = stringBuilder.ToString();
		return description;
	}

	// Token: 0x060022EC RID: 8940 RVA: 0x001003A8 File Offset: 0x000FE7A8
	public static string ToExpression(this double value)
	{
		return Math.Round(Math.Floor(value), 0).ToString();
	}

	// Token: 0x060022ED RID: 8941 RVA: 0x001003D0 File Offset: 0x000FE7D0
	public static string ToExpressionMultiply100(this double value)
	{
		value = Math.Round(value, 3, MidpointRounding.AwayFromZero);
		return Math.Round(value * 100.0, 1).ToString();
	}

	// Token: 0x060022EE RID: 8942 RVA: 0x00100406 File Offset: 0x000FE806
	public static double DoubleMultiply100(this double value)
	{
		return (double)((int)(value * 100.0));
	}

	// Token: 0x060022EF RID: 8943 RVA: 0x00100418 File Offset: 0x000FE818
	public static StringBuilder ReplaceToBuilder(this string content, string orignal, string ncontent)
	{
		StringBuilder stringBuilder = new StringBuilder(content);
		stringBuilder.Replace(orignal, ncontent);
		return stringBuilder;
	}

	// Token: 0x060022F0 RID: 8944 RVA: 0x00100436 File Offset: 0x000FE836
	public static string GetName(this UIComponentType type)
	{
		return LocalizationSession.instance.LocalizationManager.GetUiLocalization(type).Name;
	}

	// Token: 0x060022F1 RID: 8945 RVA: 0x00100450 File Offset: 0x000FE850
	public static Description GetDescription(this ManualType type)
	{
		ManualLocalization manualLocalization = LocalizationSession.instance.LocalizationManager.GetManualLocalization(type);
		return new Description
		{
			Details1 = manualLocalization.Description,
			Title = manualLocalization.Name
		};
	}

	// Token: 0x060022F2 RID: 8946 RVA: 0x00100490 File Offset: 0x000FE890
	public static Description GetDescription(this IResidentEffect effect)
	{
		ResidentEffectLocalization residentEffectLocalization = LocalizationSession.instance.LocalizationManager.GetResidentEffectLocalization(effect.CorrespondingEffectType);
		if (effect is ProductionResidentEffect)
		{
			ProductionResidentEffect productionResidentEffect = effect as ProductionResidentEffect;
			residentEffectLocalization.Description = residentEffectLocalization.Description.Replace("{rate}", productionResidentEffect.CurrentRate.ToExpressionMultiply100());
		}
		if (effect is WeaponSaleResidentEffect)
		{
			WeaponSaleResidentEffect weaponSaleResidentEffect = effect as WeaponSaleResidentEffect;
			residentEffectLocalization.Description = residentEffectLocalization.Description.Replace("{rate}", weaponSaleResidentEffect.CurrentRate.ToExpressionMultiply100());
		}
		if (effect is ArmorSaleResidentEffect)
		{
			ArmorSaleResidentEffect armorSaleResidentEffect = effect as ArmorSaleResidentEffect;
			residentEffectLocalization.Description = residentEffectLocalization.Description.Replace("{rate}", armorSaleResidentEffect.CurrentRate.ToExpressionMultiply100());
		}
		if (effect is LuckResidentEffect)
		{
			LuckResidentEffect luckResidentEffect = effect as LuckResidentEffect;
			residentEffectLocalization.Description = residentEffectLocalization.Description.Replace("{rate}", luckResidentEffect.CurrentRate.ToExpressionMultiply100());
		}
		if (effect is PracticeResidentEffect)
		{
			PracticeResidentEffect practiceResidentEffect = effect as PracticeResidentEffect;
			residentEffectLocalization.Description = residentEffectLocalization.Description.Replace("{rate}", practiceResidentEffect.CurrentRate.ToExpressionMultiply100());
		}
		if (effect is MysticStoneResidentEffect)
		{
			MysticStoneResidentEffect mysticStoneResidentEffect = effect as MysticStoneResidentEffect;
			residentEffectLocalization.Description = residentEffectLocalization.Description.Replace("{rate}", mysticStoneResidentEffect.CurrentRate.ToExpressionMultiply100());
		}
		if (effect is DeterminationResidentEffect)
		{
			residentEffectLocalization.Description = residentEffectLocalization.Description.Replace("{rate}", DeterminationResidentEffect.Rate.ToExpressionMultiply100());
		}
		if (effect is DivineHeartResidentEffect)
		{
			DivineHeartResidentEffect divineHeartResidentEffect = effect as DivineHeartResidentEffect;
			residentEffectLocalization.Description = residentEffectLocalization.Description.Replace("{rate}", divineHeartResidentEffect.CurrentRate.ToExpressionMultiply100());
		}
		if (effect is RecruitmentResidentEffect)
		{
			RecruitmentResidentEffect recruitmentResidentEffect = effect as RecruitmentResidentEffect;
			residentEffectLocalization.Description = residentEffectLocalization.Description.Replace("{rate}", recruitmentResidentEffect.Chance.ToExpressionMultiply100());
		}
		if (effect is WealthResidentEffect)
		{
			WealthResidentEffect wealthResidentEffect = effect as WealthResidentEffect;
			residentEffectLocalization.Description = residentEffectLocalization.Description.Replace("{amount}", wealthResidentEffect.ContributionAmount.ToExpression());
		}
		return new Description
		{
			Details1 = residentEffectLocalization.Description,
			Details2 = residentEffectLocalization.Description,
			Title = residentEffectLocalization.Name
		};
	}

	// Token: 0x060022F3 RID: 8947 RVA: 0x001006E8 File Offset: 0x000FEAE8
	public static Description GetDescription(this VehicleType type)
	{
		VehicleLocalization vehicleLocalization = LocalizationSession.instance.LocalizationManager.GetVehicleLocalization(type);
		return new Description
		{
			Details1 = vehicleLocalization.Description,
			Title = vehicleLocalization.Name
		};
	}

	// Token: 0x060022F4 RID: 8948 RVA: 0x00100728 File Offset: 0x000FEB28
	public static Description GetDescription(this JourneyContributeType type)
	{
		JourneyContributionLocalization journeyContribution = LocalizationSession.instance.LocalizationManager.GetJourneyContribution(type);
		return new Description
		{
			Details1 = journeyContribution.Description,
			Title = journeyContribution.Name
		};
	}

	// Token: 0x060022F5 RID: 8949 RVA: 0x00100768 File Offset: 0x000FEB68
	public static Description GetDescription(this VehicleAttributeType type)
	{
		VehicleAttributeLocalization vehicleAttribute = LocalizationSession.instance.LocalizationManager.GetVehicleAttribute(type);
		return new Description
		{
			Details1 = vehicleAttribute.Description,
			Title = vehicleAttribute.Name
		};
	}

	// Token: 0x060022F6 RID: 8950 RVA: 0x001007A8 File Offset: 0x000FEBA8
	public static Description GetEncounterDescription(this ITripeEncounter encounter)
	{
		TripEncounterLocalization tripEncounter = LocalizationSession.instance.LocalizationManager.GetTripEncounter(encounter.GetEncounterType());
		return new Description
		{
			Details1 = tripEncounter.Description,
			Title = tripEncounter.Name
		};
	}

	// Token: 0x060022F7 RID: 8951 RVA: 0x001007EC File Offset: 0x000FEBEC
	public static Description GetEncounterOutcomeDescription(this ITripeEncounter encounter)
	{
		TripOutcomeLocalization tripOutcome = LocalizationSession.instance.LocalizationManager.GetTripOutcome(encounter.GetEncounterOutcomeType());
		if (encounter is NormalEncounter)
		{
			tripOutcome.Description = tripOutcome.Description.Replace("{rate}", (encounter as NormalEncounter).LossLife.ToExpression());
		}
		return new Description
		{
			Details1 = tripOutcome.Description,
			Title = tripOutcome.Name
		};
	}

	// Token: 0x060022F8 RID: 8952 RVA: 0x00100860 File Offset: 0x000FEC60
	public static Description GetDescription(this DestinationType type)
	{
		DestinationLocalization destination = LocalizationSession.instance.LocalizationManager.GetDestination(type);
		return new Description
		{
			Details1 = destination.Description,
			Title = destination.Name
		};
	}

	// Token: 0x060022F9 RID: 8953 RVA: 0x001008A0 File Offset: 0x000FECA0
	public static Description GetUnitStyleDescription(this IBattleUnit unit)
	{
		UnitClassStyle unitClassStyle = unit.GetUnitClassStyle();
		UnitStyleLocalization unitStyle = LocalizationSession.instance.LocalizationManager.GetUnitStyle(unitClassStyle);
		UnitPowerGrade abilityGrade = unitClassStyle.GetStyleConfig().GetAbilityGrade(unit);
		string[] array = unitStyle.Description.Split(new char[]
		{
			';'
		});
		Description description = new Description
		{
			Title = unitStyle.Name
		};
		if (abilityGrade == UnitPowerGrade.Easy && array.Length >= 1)
		{
			description.Details1 = array[0];
		}
		if (abilityGrade == UnitPowerGrade.Normal && array.Length >= 2)
		{
			description.Details1 = array[1];
		}
		if (abilityGrade == UnitPowerGrade.Hard && array.Length >= 3)
		{
			description.Details1 = array[2];
		}
		return description;
	}

	// Token: 0x060022FA RID: 8954 RVA: 0x00100950 File Offset: 0x000FED50
	public static Description GetDescription(this CandidateOrderringMetric type)
	{
		CandidateOrderMetricLocalization candidateMetric = LocalizationSession.instance.LocalizationManager.GetCandidateMetric(type);
		return new Description
		{
			Details1 = candidateMetric.Description,
			Title = candidateMetric.Name,
			Details2 = candidateMetric.Description
		};
	}

	// Token: 0x060022FB RID: 8955 RVA: 0x0010099C File Offset: 0x000FED9C
	public static Description GetDescription(this OrderingType type)
	{
		OrderTypeLocalization orderType = LocalizationSession.instance.LocalizationManager.GetOrderType(type);
		return new Description
		{
			Details1 = orderType.Description,
			Title = orderType.Name,
			Details2 = orderType.Description
		};
	}

	// Token: 0x060022FC RID: 8956 RVA: 0x001009E8 File Offset: 0x000FEDE8
	public static string GetName(this TeamSetType type)
	{
		if (type == TeamSetType.Deer)
		{
			return UIComponentType.Deer.GetName();
		}
		if (type == TeamSetType.Thorns)
		{
			return UIComponentType.Thorns.GetName();
		}
		if (type == TeamSetType.Guilt)
		{
			return UIComponentType.Guilt.GetName();
		}
		if (type == TeamSetType.Corruption)
		{
			return UIComponentType.Corruption.GetName();
		}
		if (type == TeamSetType.Focus)
		{
			return UIComponentType.Focus.GetName();
		}
		return type.ToString();
	}

	// Token: 0x060022FD RID: 8957 RVA: 0x00100A5C File Offset: 0x000FEE5C
	[CompilerGenerated]
	private static bool <GetDescription>m__0(AttributeModifier m)
	{
		return m.AttributeType == AttributeType.Strength && m.ModificationType == ModificationType.Multiplication;
	}

	// Token: 0x060022FE RID: 8958 RVA: 0x00100A76 File Offset: 0x000FEE76
	[CompilerGenerated]
	private static bool <GetDescription>m__1(AttributeModifier m)
	{
		return m.AttributeType == AttributeType.Strength && m.ModificationType == ModificationType.Multiplication;
	}

	// Token: 0x060022FF RID: 8959 RVA: 0x00100A90 File Offset: 0x000FEE90
	[CompilerGenerated]
	private static double <GetDescription>m__2(AttributeModifier m)
	{
		return m.Value;
	}

	// Token: 0x06002300 RID: 8960 RVA: 0x00100A98 File Offset: 0x000FEE98
	[CompilerGenerated]
	private static bool <GetDescription>m__3(AttributeModifier m)
	{
		return m.AttributeType == AttributeType.Intelligience && m.ModificationType == ModificationType.Multiplication;
	}

	// Token: 0x06002301 RID: 8961 RVA: 0x00100AB2 File Offset: 0x000FEEB2
	[CompilerGenerated]
	private static bool <GetDescription>m__4(AttributeModifier m)
	{
		return m.AttributeType == AttributeType.Intelligience && m.ModificationType == ModificationType.Multiplication;
	}

	// Token: 0x06002302 RID: 8962 RVA: 0x00100ACC File Offset: 0x000FEECC
	[CompilerGenerated]
	private static double <GetDescription>m__5(AttributeModifier m)
	{
		return m.Value;
	}

	// Token: 0x06002303 RID: 8963 RVA: 0x00100AD4 File Offset: 0x000FEED4
	[CompilerGenerated]
	private static string <GetDescription>m__6(ISpecialEffectDataLoad d)
	{
		return d.GetDescription().Details1;
	}

	// Token: 0x06002304 RID: 8964 RVA: 0x00100AE1 File Offset: 0x000FEEE1
	[CompilerGenerated]
	private static string <GetDescription>m__7(AdventureType d)
	{
		return d.GetDescription().Title;
	}

	// Token: 0x06002305 RID: 8965 RVA: 0x00100AEE File Offset: 0x000FEEEE
	[CompilerGenerated]
	private static string <GetDescription>m__8(int l)
	{
		return l.ToString();
	}

	// Token: 0x06002306 RID: 8966 RVA: 0x00100AFD File Offset: 0x000FEEFD
	[CompilerGenerated]
	private static double <GetDescription>m__9(ResourceUpdate r)
	{
		return r.ChangeAmount;
	}

	// Token: 0x06002307 RID: 8967 RVA: 0x00100B05 File Offset: 0x000FEF05
	[CompilerGenerated]
	private static bool <GetDescription>m__A(AttributeModifier m)
	{
		return m.AttributeType == AttributeType.SkillRageEfficiencyRate;
	}

	// Token: 0x06002308 RID: 8968 RVA: 0x00100B14 File Offset: 0x000FEF14
	[CompilerGenerated]
	private static bool <GetDescription>m__B(AttributeModifier f)
	{
		return f.AttributeType == AttributeType.ReflectiveDamage;
	}

	// Token: 0x06002309 RID: 8969 RVA: 0x00100B23 File Offset: 0x000FEF23
	[CompilerGenerated]
	private static bool <GetDescription>m__C(AttributeModifier f)
	{
		return f.AttributeType == AttributeType.HealingAbsorbRate;
	}

	// Token: 0x0600230A RID: 8970 RVA: 0x00100B32 File Offset: 0x000FEF32
	[CompilerGenerated]
	private static bool <GetDescription>m__D(AttributeModifier f)
	{
		return f.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x0600230B RID: 8971 RVA: 0x00100B3D File Offset: 0x000FEF3D
	[CompilerGenerated]
	private static bool <GetDescription>m__E(AttributeModifier f)
	{
		return f.AttributeType == AttributeType.StunOnHit;
	}

	// Token: 0x0600230C RID: 8972 RVA: 0x00100B4C File Offset: 0x000FEF4C
	[CompilerGenerated]
	private static bool <GetDescription>m__F(AttributeModifier f)
	{
		return f.AttributeType == AttributeType.ReflectiveDamage;
	}

	// Token: 0x0600230D RID: 8973 RVA: 0x00100B5B File Offset: 0x000FEF5B
	[CompilerGenerated]
	private static bool <GetDescription>m__10(AttributeModifier f)
	{
		return f.AttributeType == AttributeType.HealingAbsorbRate;
	}

	// Token: 0x04001E2B RID: 7723
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache0;

	// Token: 0x04001E2C RID: 7724
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache1;

	// Token: 0x04001E2D RID: 7725
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache2;

	// Token: 0x04001E2E RID: 7726
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache3;

	// Token: 0x04001E2F RID: 7727
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache4;

	// Token: 0x04001E30 RID: 7728
	[CompilerGenerated]
	private static Func<AttributeModifier, double> <>f__am$cache5;

	// Token: 0x04001E31 RID: 7729
	[CompilerGenerated]
	private static Func<ISpecialEffectDataLoad, string> <>f__am$cache6;

	// Token: 0x04001E32 RID: 7730
	[CompilerGenerated]
	private static Func<AdventureType, string> <>f__am$cache7;

	// Token: 0x04001E33 RID: 7731
	[CompilerGenerated]
	private static Func<int, string> <>f__am$cache8;

	// Token: 0x04001E34 RID: 7732
	[CompilerGenerated]
	private static Func<ResourceUpdate, double> <>f__am$cache9;

	// Token: 0x04001E35 RID: 7733
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheA;

	// Token: 0x04001E36 RID: 7734
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheB;

	// Token: 0x04001E37 RID: 7735
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheC;

	// Token: 0x04001E38 RID: 7736
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheD;

	// Token: 0x04001E39 RID: 7737
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheE;

	// Token: 0x04001E3A RID: 7738
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cacheF;

	// Token: 0x04001E3B RID: 7739
	[CompilerGenerated]
	private static Func<AttributeModifier, bool> <>f__am$cache10;
}
