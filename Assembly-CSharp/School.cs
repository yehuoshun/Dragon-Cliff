using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200047A RID: 1146
[Serializable]
public class School : IBuildingProfile
{
	// Token: 0x06002094 RID: 8340 RVA: 0x000E1D12 File Offset: 0x000E0112
	public School()
	{
	}

	// Token: 0x06002095 RID: 8341 RVA: 0x000E1D1A File Offset: 0x000E011A
	public int GetLevel()
	{
		if (ResourceType.BookCollection.HasObtained())
		{
			return 3;
		}
		if (ResourceType.MysticStone.HasObtained())
		{
			return 2;
		}
		return 1;
	}

	// Token: 0x06002096 RID: 8342 RVA: 0x000E1D40 File Offset: 0x000E0140
	public List<Skill> GetAllSkillProfiles(SkillCommandType? commandType)
	{
		List<SkillType> list = new List<SkillType>();
		List<SkillType> collection = GameWorld.instance.PlayerProfile.AdventurerProfiles.SelectMany((AdventurerProfile ad) => ad.Skills).ToList<SkillType>();
		List<SkillType> collection2 = (from a in GameWorld.instance.PlayerProfile.AcquiredPassives
		select a).ToList<SkillType>();
		list.AddRange(collection);
		list.AddRange(collection2);
		IEnumerable<SkillType> source = list.Distinct<SkillType>();
		if (School.<>f__mg$cache0 == null)
		{
			School.<>f__mg$cache0 = new Func<SkillType, Skill>(SkillExtensions.CreatePlayerSkill);
		}
		return (from s in source.Select(School.<>f__mg$cache0)
		where commandType != null && s.CommandType == commandType.Value
		select s).ToList<Skill>();
	}

	// Token: 0x06002097 RID: 8343 RVA: 0x000E1E1C File Offset: 0x000E021C
	public List<ResourceConsumptionRequirement> GetCostForCombineScroll()
	{
		return new List<ResourceConsumptionRequirement>
		{
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.BookFragments,
				AmountRequired = 50
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.InfusedPowder,
				AmountRequired = 20
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.FragmentOfDemon,
				AmountRequired = 20
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.CrystalOfWoodenForest,
				AmountRequired = 1
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.InkOfMistForest,
				AmountRequired = 1
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.IceOfSnowMountain,
				AmountRequired = 1
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.SealOfBuriedTemple,
				AmountRequired = 1
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.StoneOfHellishPath,
				AmountRequired = 1
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.LeafOfImperialM,
				AmountRequired = 1
			},
			new ResourceConsumptionRequirement
			{
				ResourceType = ResourceType.SandOfNorthernTerritory,
				AmountRequired = 1
			}
		};
	}

	// Token: 0x06002098 RID: 8344 RVA: 0x000E1F6C File Offset: 0x000E036C
	public Item CombineScroll()
	{
		if (this.GetCostForCombineScroll().MetRequirements())
		{
			GameWorld.instance.PlayerProfile.StartScrollGenerationScope();
			List<ResourceUpdate> list = (from s in this.GetCostForCombineScroll()
			select new ResourceUpdate
			{
				ResourceType = s.ResourceType,
				ChangeAmount = (double)(-(double)s.AmountRequired),
				RelatedItems = new List<Item>()
			}).ToList<ResourceUpdate>();
			List<ResourceType> list2 = new List<ResourceType>
			{
				ResourceType.ScrollOfBoorishness,
				ResourceType.ScrollOfHardenedLife,
				ResourceType.ScrollOfElement,
				ResourceType.ScrollOfAffirmation,
				ResourceType.ScrollOfMasterfulness,
				ResourceType.ScrollOfTaunt,
				ResourceType.ScrollOfProtection,
				ResourceType.ScrollOfTactics,
				ResourceType.ScrollOfSharpness,
				ResourceType.ScrollOfHealers,
				ResourceType.ScrollOfMindless,
				ResourceType.ScrollOfStrongMan,
				ResourceType.ScrollOfArcane,
				ResourceType.ScrollOfArrogance,
				ResourceType.ScrollOfMist,
				ResourceType.ScrollOfFrozenHeart,
				ResourceType.ScrollOfFashion,
				ResourceType.ScrollOfBlade,
				ResourceType.ScrollOfNightKiller,
				ResourceType.ScrollOfTheDead,
				ResourceType.ScrollOfBun,
				ResourceType.ScrollOfGhost,
				ResourceType.ScrollOfExplosion,
				ResourceType.ScrollOfSpellObsorption,
				ResourceType.ScrollOfSwiftness,
				ResourceType.ScrollOfRage,
				ResourceType.ScrollOfReflection
			};
			ResourceType resourceType = list2[UnityEngine.Random.Range(0, list2.Count)];
			DifficultyLevelMeasurement productionDifficultyLevelMeasurement = GameWorld.instance.PlayerProfile.GetProductionDifficultyLevelMeasurement();
			bool flag = (double)UnityEngine.Random.value <= productionDifficultyLevelMeasurement.GetStarChance(ResourceSourceType.ScrollCreation);
			Item item = resourceType.ItemGenerate(ResourceSourceType.ScrollCreation, (!flag) ? ItemGenerationQuality.CreateGraded(QualityGrade.Ancient) : ItemGenerationQuality.CreateStar(), productionDifficultyLevelMeasurement.GetCorrespondingItemTierLevel(resourceType), 1);
			List<ResourceUpdate> collection = new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = resourceType,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						item
					}
				}
			};
			list.AddRange(collection);
			GameWorld.instance.PlayerProfile.RotateScrollGenerationSeed();
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(list);
			return item;
		}
		return null;
	}

	// Token: 0x06002099 RID: 8345 RVA: 0x000E21D0 File Offset: 0x000E05D0
	public int GetSkillRequiredSchoolLevel(SkillType skillType)
	{
		SkillLogicBase skillLogic = skillType.GetSkillLogic();
		if (skillLogic.SkillCommandType == SkillCommandType.Active)
		{
			if (skillType.GetLevel() <= 1)
			{
				return 2;
			}
			return 3;
		}
		else
		{
			if (skillLogic.SkillCommandType != SkillCommandType.Main && skillLogic.SkillCommandType != SkillCommandType.Secondary)
			{
				return 3;
			}
			if (skillType.GetLevel() < 3)
			{
				return 1;
			}
			if (skillType.GetLevel() < 6)
			{
				return 2;
			}
			return 3;
		}
	}

	// Token: 0x0600209A RID: 8346 RVA: 0x000E2238 File Offset: 0x000E0638
	public void UpgradeSkill(SkillType skillType)
	{
		if (this.CanUpgradeSkill(skillType))
		{
			List<ResourceUpdate> changes = (from c in skillType.GetSkillLogic().GetLevelUpgradeCost(skillType.GetLevel())
			select new ResourceUpdate
			{
				ResourceType = c.ResourceType,
				ChangeAmount = (double)(-(double)c.AmountRequired),
				RelatedItems = new List<Item>()
			}).ToList<ResourceUpdate>();
			GameWorld.instance.PlayerProfile.BatchResourceUpdate(changes);
			skillType.UpdateSkillLevel(skillType.GetLevel() + 1);
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.AdventurerSkillLevelsUp, skillType);
		}
	}

	// Token: 0x0600209B RID: 8347 RVA: 0x000E22BF File Offset: 0x000E06BF
	public bool SkillHasMoreLevelToUpgrad(SkillType skillType)
	{
		return skillType.GetSkillLogic().HasMoreLevelToUpgrade(skillType.GetLevel());
	}

	// Token: 0x0600209C RID: 8348 RVA: 0x000E22D4 File Offset: 0x000E06D4
	public Skill PreviewNextLevel(SkillType type)
	{
		if (this.SkillHasMoreLevelToUpgrad(type))
		{
			return new Skill
			{
				Level = type.GetLevel() + 1,
				SkillType = type,
				CommandType = type.GetSkillLogic().SkillCommandType,
				IsEnabled = false
			};
		}
		return null;
	}

	// Token: 0x0600209D RID: 8349 RVA: 0x000E2323 File Offset: 0x000E0723
	public int GetSkillMaxLevel(SkillType skillType)
	{
		return skillType.GetSkillLogic().GetMaxLevel();
	}

	// Token: 0x0600209E RID: 8350 RVA: 0x000E2330 File Offset: 0x000E0730
	public bool CanUpgradeSkill(SkillType skillType)
	{
		if (this.SkillHasMoreLevelToUpgrad(skillType) && this.GetLevel() >= this.GetSkillRequiredSchoolLevel(skillType))
		{
			List<ResourceConsumptionRequirement> levelUpgradeCost = skillType.GetSkillLogic().GetLevelUpgradeCost(skillType.GetLevel());
			return levelUpgradeCost.MetRequirements();
		}
		return false;
	}

	// Token: 0x0600209F RID: 8351 RVA: 0x000E2378 File Offset: 0x000E0778
	public int GetSkillUpgradeCost(SkillType skillType, ResourceType type)
	{
		ResourceConsumptionRequirement resourceConsumptionRequirement = skillType.GetSkillLogic().GetLevelUpgradeCost(skillType.GetLevel()).FirstOrDefault((ResourceConsumptionRequirement r) => r.ResourceType == type);
		if (resourceConsumptionRequirement != null)
		{
			return resourceConsumptionRequirement.AmountRequired;
		}
		return 0;
	}

	// Token: 0x1700021C RID: 540
	// (get) Token: 0x060020A0 RID: 8352 RVA: 0x000E23C3 File Offset: 0x000E07C3
	public BuildingType BuildingType
	{
		get
		{
			return BuildingType.School;
		}
	}

	// Token: 0x060020A1 RID: 8353 RVA: 0x000E23C6 File Offset: 0x000E07C6
	public void Process(float timeDelta)
	{
	}

	// Token: 0x1700021D RID: 541
	// (get) Token: 0x060020A2 RID: 8354 RVA: 0x000E23C8 File Offset: 0x000E07C8
	public string Id
	{
		get
		{
			return this._id;
		}
	}

	// Token: 0x060020A3 RID: 8355 RVA: 0x000E23D0 File Offset: 0x000E07D0
	public void ProcessEvent(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.ResourceUpdated && data is ResourceUpdateEvent)
		{
			ResourceUpdateEvent resourceUpdateEvent = data as ResourceUpdateEvent;
			if (resourceUpdateEvent.ResourceType == ResourceType.MysticStone)
			{
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.SchoolUpgraded, 2);
			}
			if (resourceUpdateEvent.ResourceType == ResourceType.BookCollection)
			{
				GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.SchoolUpgraded, 3);
			}
		}
	}

	// Token: 0x060020A4 RID: 8356 RVA: 0x000E2448 File Offset: 0x000E0848
	public List<AdventurerProfile> GetImpactedAdventurers(SkillType skillType)
	{
		SkillCommandType skillCommandType = skillType.GetSkillLogic().SkillCommandType;
		if (skillCommandType == SkillCommandType.Secondary)
		{
			return (from a in GameWorld.instance.PlayerProfile.AdventurerProfiles
			select a).ToList<AdventurerProfile>();
		}
		return (from ad in GameWorld.instance.PlayerProfile.AdventurerProfiles
		where ad.Skills.Any((SkillType sk) => sk == skillType)
		select ad).ToList<AdventurerProfile>();
	}

	// Token: 0x060020A5 RID: 8357 RVA: 0x000E24D6 File Offset: 0x000E08D6
	[CompilerGenerated]
	private static IEnumerable<SkillType> <GetAllSkillProfiles>m__0(AdventurerProfile ad)
	{
		return ad.Skills;
	}

	// Token: 0x060020A6 RID: 8358 RVA: 0x000E24DE File Offset: 0x000E08DE
	[CompilerGenerated]
	private static SkillType <GetAllSkillProfiles>m__1(SkillType a)
	{
		return a;
	}

	// Token: 0x060020A7 RID: 8359 RVA: 0x000E24E4 File Offset: 0x000E08E4
	[CompilerGenerated]
	private static ResourceUpdate <CombineScroll>m__2(ResourceConsumptionRequirement s)
	{
		return new ResourceUpdate
		{
			ResourceType = s.ResourceType,
			ChangeAmount = (double)(-(double)s.AmountRequired),
			RelatedItems = new List<Item>()
		};
	}

	// Token: 0x060020A8 RID: 8360 RVA: 0x000E2520 File Offset: 0x000E0920
	[CompilerGenerated]
	private static ResourceUpdate <UpgradeSkill>m__3(ResourceConsumptionRequirement c)
	{
		return new ResourceUpdate
		{
			ResourceType = c.ResourceType,
			ChangeAmount = (double)(-(double)c.AmountRequired),
			RelatedItems = new List<Item>()
		};
	}

	// Token: 0x060020A9 RID: 8361 RVA: 0x000E2559 File Offset: 0x000E0959
	[CompilerGenerated]
	private static AdventurerProfile <GetImpactedAdventurers>m__4(AdventurerProfile a)
	{
		return a;
	}

	// Token: 0x04001CF7 RID: 7415
	public string _id;

	// Token: 0x04001CF8 RID: 7416
	[CompilerGenerated]
	private static Func<SkillType, Skill> <>f__mg$cache0;

	// Token: 0x04001CF9 RID: 7417
	[CompilerGenerated]
	private static Func<AdventurerProfile, IEnumerable<SkillType>> <>f__am$cache0;

	// Token: 0x04001CFA RID: 7418
	[CompilerGenerated]
	private static Func<SkillType, SkillType> <>f__am$cache1;

	// Token: 0x04001CFB RID: 7419
	[CompilerGenerated]
	private static Func<ResourceConsumptionRequirement, ResourceUpdate> <>f__am$cache2;

	// Token: 0x04001CFC RID: 7420
	[CompilerGenerated]
	private static Func<ResourceConsumptionRequirement, ResourceUpdate> <>f__am$cache3;

	// Token: 0x04001CFD RID: 7421
	[CompilerGenerated]
	private static Func<AdventurerProfile, AdventurerProfile> <>f__am$cache4;

	// Token: 0x02000D27 RID: 3367
	[CompilerGenerated]
	private sealed class <GetAllSkillProfiles>c__AnonStorey0
	{
		// Token: 0x06005642 RID: 22082 RVA: 0x000E255C File Offset: 0x000E095C
		public <GetAllSkillProfiles>c__AnonStorey0()
		{
		}

		// Token: 0x06005643 RID: 22083 RVA: 0x000E2564 File Offset: 0x000E0964
		internal bool <>m__0(Skill s)
		{
			return this.commandType != null && s.CommandType == this.commandType.Value;
		}

		// Token: 0x040044CB RID: 17611
		internal SkillCommandType? commandType;
	}

	// Token: 0x02000D28 RID: 3368
	[CompilerGenerated]
	private sealed class <GetSkillUpgradeCost>c__AnonStorey1
	{
		// Token: 0x06005644 RID: 22084 RVA: 0x000E258C File Offset: 0x000E098C
		public <GetSkillUpgradeCost>c__AnonStorey1()
		{
		}

		// Token: 0x06005645 RID: 22085 RVA: 0x000E2594 File Offset: 0x000E0994
		internal bool <>m__0(ResourceConsumptionRequirement r)
		{
			return r.ResourceType == this.type;
		}

		// Token: 0x040044CC RID: 17612
		internal ResourceType type;
	}

	// Token: 0x02000D29 RID: 3369
	[CompilerGenerated]
	private sealed class <GetImpactedAdventurers>c__AnonStorey2
	{
		// Token: 0x06005646 RID: 22086 RVA: 0x000E25A4 File Offset: 0x000E09A4
		public <GetImpactedAdventurers>c__AnonStorey2()
		{
		}

		// Token: 0x06005647 RID: 22087 RVA: 0x000E25AC File Offset: 0x000E09AC
		internal bool <>m__0(AdventurerProfile ad)
		{
			return ad.Skills.Any((SkillType sk) => sk == this.skillType);
		}

		// Token: 0x06005648 RID: 22088 RVA: 0x000E25C5 File Offset: 0x000E09C5
		internal bool <>m__1(SkillType sk)
		{
			return sk == this.skillType;
		}

		// Token: 0x040044CD RID: 17613
		internal SkillType skillType;
	}
}
