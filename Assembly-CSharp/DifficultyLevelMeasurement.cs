using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000449 RID: 1097
public class DifficultyLevelMeasurement
{
	// Token: 0x06001EB2 RID: 7858 RVA: 0x000D5E5B File Offset: 0x000D425B
	private DifficultyLevelMeasurement()
	{
	}

	// Token: 0x170001B2 RID: 434
	// (get) Token: 0x06001EB3 RID: 7859 RVA: 0x000D5E63 File Offset: 0x000D4263
	// (set) Token: 0x06001EB4 RID: 7860 RVA: 0x000D5E6B File Offset: 0x000D426B
	public double DifficultyValue
	{
		[CompilerGenerated]
		get
		{
			return this.<DifficultyValue>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<DifficultyValue>k__BackingField = value;
		}
	}

	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x06001EB5 RID: 7861 RVA: 0x000D5E74 File Offset: 0x000D4274
	// (set) Token: 0x06001EB6 RID: 7862 RVA: 0x000D5E7C File Offset: 0x000D427C
	public int DifficultyTier
	{
		[CompilerGenerated]
		get
		{
			return this.<DifficultyTier>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<DifficultyTier>k__BackingField = value;
		}
	}

	// Token: 0x170001B4 RID: 436
	// (get) Token: 0x06001EB7 RID: 7863 RVA: 0x000D5E85 File Offset: 0x000D4285
	// (set) Token: 0x06001EB8 RID: 7864 RVA: 0x000D5E8D File Offset: 0x000D428D
	public double TierPowerness
	{
		[CompilerGenerated]
		get
		{
			return this.<TierPowerness>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<TierPowerness>k__BackingField = value;
		}
	}

	// Token: 0x170001B5 RID: 437
	// (get) Token: 0x06001EB9 RID: 7865 RVA: 0x000D5E96 File Offset: 0x000D4296
	// (set) Token: 0x06001EBA RID: 7866 RVA: 0x000D5E9E File Offset: 0x000D429E
	public int GemTier
	{
		[CompilerGenerated]
		get
		{
			return this.<GemTier>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<GemTier>k__BackingField = value;
		}
	}

	// Token: 0x170001B6 RID: 438
	// (get) Token: 0x06001EBB RID: 7867 RVA: 0x000D5EA7 File Offset: 0x000D42A7
	// (set) Token: 0x06001EBC RID: 7868 RVA: 0x000D5EAF File Offset: 0x000D42AF
	public double CorrespondingReputation
	{
		[CompilerGenerated]
		get
		{
			return this.<CorrespondingReputation>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<CorrespondingReputation>k__BackingField = value;
		}
	}

	// Token: 0x170001B7 RID: 439
	// (get) Token: 0x06001EBD RID: 7869 RVA: 0x000D5EB8 File Offset: 0x000D42B8
	// (set) Token: 0x06001EBE RID: 7870 RVA: 0x000D5EC0 File Offset: 0x000D42C0
	public double MosnterPowerLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<MosnterPowerLevel>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<MosnterPowerLevel>k__BackingField = value;
		}
	}

	// Token: 0x170001B8 RID: 440
	// (get) Token: 0x06001EBF RID: 7871 RVA: 0x000D5EC9 File Offset: 0x000D42C9
	// (set) Token: 0x06001EC0 RID: 7872 RVA: 0x000D5ED1 File Offset: 0x000D42D1
	public int MonsterSkillLevel
	{
		[CompilerGenerated]
		get
		{
			return this.<MonsterSkillLevel>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<MonsterSkillLevel>k__BackingField = value;
		}
	}

	// Token: 0x170001B9 RID: 441
	// (get) Token: 0x06001EC1 RID: 7873 RVA: 0x000D5EDA File Offset: 0x000D42DA
	// (set) Token: 0x06001EC2 RID: 7874 RVA: 0x000D5EE2 File Offset: 0x000D42E2
	public int StarRating
	{
		[CompilerGenerated]
		get
		{
			return this.<StarRating>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<StarRating>k__BackingField = value;
		}
	}

	// Token: 0x06001EC3 RID: 7875 RVA: 0x000D5EEC File Offset: 0x000D42EC
	public double GetAmuletChance()
	{
		if (this.StarRating != -1)
		{
			return 0.0;
		}
		if (TestingProcessor.InTesting)
		{
			return 1.0;
		}
		if (this.DifficultyValue <= 200.0)
		{
			return 0.008;
		}
		if (this.DifficultyValue <= 400.0)
		{
			return 0.012;
		}
		if (this.DifficultyValue <= 600.0)
		{
			return 0.022;
		}
		if (this.DifficultyValue <= 900.0)
		{
			return 0.04;
		}
		if (this.DifficultyValue <= 1000.0)
		{
			return 0.06;
		}
		return 0.07;
	}

	// Token: 0x06001EC4 RID: 7876 RVA: 0x000D5FC4 File Offset: 0x000D43C4
	public List<ResourceUpdate> GetAmuletDrop()
	{
		List<ResourceType> list = new List<ResourceType>
		{
			ResourceType.AshOfDeerGod,
			ResourceType.RockOfDeerGod,
			ResourceType.TorchOfDeerGod,
			ResourceType.HeartOfThorns,
			ResourceType.EyesOfThorns,
			ResourceType.BoneOfThorns,
			ResourceType.HatredOfPrince,
			ResourceType.LoveOfPrince,
			ResourceType.SinOfPrince,
			ResourceType.DustOfCorruption,
			ResourceType.PetalOfCorruption,
			ResourceType.GhostOfCorruption,
			ResourceType.CircleOfFocus,
			ResourceType.WheelOfFocus,
			ResourceType.SpikeOfFocus
		};
		ResourceType resourceType = list[UnityEngine.Random.Range(0, list.Count)];
		return new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = resourceType,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>
				{
					resourceType.ItemGenerate(ResourceSourceType.DungeonDrop, ItemGenerationQuality.CreateGraded(QualityGrade.Ancient), 1, 1)
				}
			}
		};
	}

	// Token: 0x06001EC5 RID: 7877 RVA: 0x000D60E8 File Offset: 0x000D44E8
	public int GetMonsterLevel(AdventureEncounterSlotType type)
	{
		int num = 1;
		if (TestingProcessor.InTesting)
		{
			return 1;
		}
		if (this.StarRating == 1)
		{
			if (this.DifficultyValue <= 60.0)
			{
				num = (int)Math.Ceiling(this.DifficultyValue / 1.5);
			}
			else if (this.DifficultyValue <= 120.0)
			{
				num = 40 + (int)Math.Ceiling((this.DifficultyValue - 60.0) / 1.5);
			}
			else
			{
				num = 80 + (int)Math.Ceiling((this.DifficultyValue - 120.0) / 10.0);
			}
		}
		if (this.StarRating == 2)
		{
			if (this.DifficultyValue <= 120.0)
			{
				num = 80 + (int)Math.Ceiling(this.DifficultyValue / 10.0);
			}
			else
			{
				num = 92 + (int)Math.Ceiling((this.DifficultyValue - 120.0) / 13.0);
			}
		}
		if (this.StarRating == -1)
		{
			if (this.DifficultyValue <= 100.0)
			{
				num = 90 + (int)Math.Ceiling(this.DifficultyValue / 20.0);
			}
			else if (this.DifficultyValue <= 200.0)
			{
				num = 95 + (int)Math.Ceiling((this.DifficultyValue - 100.0) / 50.0);
			}
			else if (this.DifficultyValue <= 300.0)
			{
				num = 98;
			}
			else
			{
				num = 98 + (int)Math.Ceiling((this.DifficultyValue - 300.0) / 50.0);
			}
		}
		if (type == AdventureEncounterSlotType.MiniBoss)
		{
			num += 2;
		}
		if (type == AdventureEncounterSlotType.Boss)
		{
			num += 3;
		}
		return num;
	}

	// Token: 0x06001EC6 RID: 7878 RVA: 0x000D62D8 File Offset: 0x000D46D8
	public GenerationDistribution GetDefaultItemGenerationDistribution(ResourceSourceType itemSource)
	{
		if (itemSource == ResourceSourceType.BuildingProduction)
		{
			return new GenerationDistribution(0.1, 0.02, 0.004, 0.0002);
		}
		if (itemSource == ResourceSourceType.Exploration)
		{
			return new GenerationDistribution(0.05, 0.07, 0.1, 0.0004);
		}
		if (itemSource != ResourceSourceType.DungeonDrop && itemSource != ResourceSourceType.ShopPurchase)
		{
			return new GenerationDistribution(0.1, 0.02, 0.004, 0.0002);
		}
		if (this.StarRating == 1 && this.DifficultyValue <= 100.0)
		{
			return new GenerationDistribution(0.1, 0.04, 0.02, 0.01);
		}
		if (this.StarRating == 1)
		{
			return new GenerationDistribution(0.1, 0.05, 0.01, 0.0005);
		}
		return new GenerationDistribution(0.1, 0.05, 0.02, 0.001);
	}

	// Token: 0x06001EC7 RID: 7879 RVA: 0x000D6428 File Offset: 0x000D4828
	public int GetResidentLevel()
	{
		if (this.DifficultyValue <= 100.0 && this.StarRating == 1)
		{
			return this.DifficultyTier;
		}
		return 10;
	}

	// Token: 0x06001EC8 RID: 7880 RVA: 0x000D6454 File Offset: 0x000D4854
	public List<double> GetChestDropHits()
	{
		if (this.DifficultyValue <= 100.0 && this.StarRating == 1)
		{
			return new List<double>
			{
				0.6
			};
		}
		if (this.StarRating == -1)
		{
			return new List<double>
			{
				1.0
			};
		}
		return new List<double>
		{
			0.6
		};
	}

	// Token: 0x06001EC9 RID: 7881 RVA: 0x000D64D4 File Offset: 0x000D48D4
	public List<double> GetUnitDeathHits(EnemyBattleUnit unit)
	{
		if (unit.SlotSelection == AdventureEncounterSlotType.Boss)
		{
			return new List<double>
			{
				1.0
			};
		}
		return new List<double>
		{
			0.6
		};
	}

	// Token: 0x06001ECA RID: 7882 RVA: 0x000D651C File Offset: 0x000D491C
	public GenerationDistribution GetDefaultChestGenerationDistribution()
	{
		if (this.StarRating == 1 && this.DifficultyValue <= 100.0)
		{
			return new GenerationDistribution(0.2, 0.12, 0.09, 0.06);
		}
		if (this.StarRating == 1)
		{
			return new GenerationDistribution(0.15, 0.05, 0.02, 0.01);
		}
		return new GenerationDistribution(0.2, 0.12, 0.05, 0.05);
	}

	// Token: 0x06001ECB RID: 7883 RVA: 0x000D65D4 File Offset: 0x000D49D4
	public double GetStarChance(ResourceSourceType itemSource)
	{
		if (itemSource == ResourceSourceType.Combine)
		{
			return 0.015;
		}
		if (itemSource == ResourceSourceType.ScrollCreation)
		{
			return 0.3;
		}
		if (this.StarRating == 1)
		{
			return 0.0005;
		}
		if (itemSource == ResourceSourceType.DungeonDrop || itemSource == ResourceSourceType.ShopPurchase)
		{
			return 0.01;
		}
		return 0.001;
	}

	// Token: 0x06001ECC RID: 7884 RVA: 0x000D663C File Offset: 0x000D4A3C
	public GenerationDistribution GetGradedChestGeneration(QualityGrade grade)
	{
		if (this.StarRating == 1 && this.DifficultyValue <= 100.0)
		{
			switch (grade)
			{
			case QualityGrade.Normal:
				return this.GetDefaultItemGenerationDistribution(ResourceSourceType.DungeonDrop);
			case QualityGrade.Rare:
				return new GenerationDistribution(0.6, 0.02, 0.01, 0.001);
			case QualityGrade.Epic:
				return new GenerationDistribution(0.2, 0.5, 0.01, 0.001);
			case QualityGrade.Legendary:
				return new GenerationDistribution(0.1, 0.2, 0.5, 0.001);
			case QualityGrade.Ancient:
				return new GenerationDistribution(0.1, 0.1, 0.1, 0.5);
			default:
				return null;
			}
		}
		else if (this.StarRating == 1)
		{
			switch (grade)
			{
			case QualityGrade.Normal:
				return this.GetDefaultItemGenerationDistribution(ResourceSourceType.DungeonDrop);
			case QualityGrade.Rare:
				return new GenerationDistribution(0.5, 0.01, 0.005, 0.001);
			case QualityGrade.Epic:
				return new GenerationDistribution(0.5, 0.3, 0.01, 0.001);
			case QualityGrade.Legendary:
				return new GenerationDistribution(0.4, 0.1, 0.3, 0.001);
			case QualityGrade.Ancient:
				return new GenerationDistribution(0.01, 0.01, 0.5, 0.3);
			default:
				return null;
			}
		}
		else if (this.StarRating == 2)
		{
			switch (grade)
			{
			case QualityGrade.Normal:
				return this.GetDefaultItemGenerationDistribution(ResourceSourceType.DungeonDrop);
			case QualityGrade.Rare:
				return new GenerationDistribution(0.4, 0.02, 0.01, 0.0005);
			case QualityGrade.Epic:
				return new GenerationDistribution(0.4, 0.2, 0.01, 0.001);
			case QualityGrade.Legendary:
				return new GenerationDistribution(0.1, 0.2, 0.2, 0.005);
			case QualityGrade.Ancient:
				return new GenerationDistribution(0.1, 0.1, 0.4, 0.01);
			default:
				return null;
			}
		}
		else
		{
			switch (grade)
			{
			case QualityGrade.Normal:
				return this.GetDefaultItemGenerationDistribution(ResourceSourceType.DungeonDrop);
			case QualityGrade.Rare:
				return new GenerationDistribution(0.4, 0.015, 0.001, 0.0005);
			case QualityGrade.Epic:
				return new GenerationDistribution(0.3, 0.25, 0.001, 0.002);
			case QualityGrade.Legendary:
				return new GenerationDistribution(0.1, 0.15, 0.3, 0.003);
			case QualityGrade.Ancient:
				return new GenerationDistribution(0.1, 0.1, 0.4, 0.01);
			default:
				return null;
			}
		}
	}

	// Token: 0x06001ECD RID: 7885 RVA: 0x000D69CC File Offset: 0x000D4DCC
	public static DifficultyLevelMeasurement GetDifficultyLevelMeasurementByValue(double difficultyvalue, int starrating)
	{
		DifficultyLevelMeasurement difficultyLevelMeasurement = new DifficultyLevelMeasurement();
		difficultyLevelMeasurement.DifficultyValue = difficultyvalue;
		difficultyLevelMeasurement.DifficultyTier = 1 + (int)Math.Floor(difficultyLevelMeasurement.DifficultyValue / DifficultyLevelMeasurement.DifficultyLevelToIndicatorCoefficient);
		difficultyLevelMeasurement.TierPowerness = (difficultyLevelMeasurement.DifficultyValue - (double)(difficultyLevelMeasurement.DifficultyTier - 1) * DifficultyLevelMeasurement.DifficultyLevelToIndicatorCoefficient) / DifficultyLevelMeasurement.DifficultyLevelToIndicatorCoefficient;
		difficultyLevelMeasurement.GemTier = DifficultyLevelMeasurement.GetGemLevel(difficultyvalue, starrating);
		difficultyLevelMeasurement.MonsterSkillLevel = 1;
		difficultyLevelMeasurement.MosnterPowerLevel = ((starrating != -1) ? ((starrating > 1) ? ((double)((starrating - 1) * 310) + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(difficultyvalue)) : DifficultyLevelMeasurement.GetMonsterPowerLevel(difficultyvalue)) : DifficultyLevelMeasurement.GetMonsterPowerLevel_Endless(difficultyvalue));
		difficultyLevelMeasurement.CorrespondingReputation = difficultyLevelMeasurement.DifficultyValue * 100.0;
		difficultyLevelMeasurement.StarRating = starrating;
		return difficultyLevelMeasurement;
	}

	// Token: 0x06001ECE RID: 7886 RVA: 0x000D6A8F File Offset: 0x000D4E8F
	public static DifficultyLevelMeasurement GetDifficultyLevelMeasurementForDungeonRelated(double? difficultyValue)
	{
		if (difficultyValue != null)
		{
			return DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(difficultyValue.Value, GameWorld.instance.PlayerProfile.GetStarRating());
		}
		return GameWorld.instance.PlayerProfile.GetDifficultyLevelMeasurement_CurrentRating();
	}

	// Token: 0x06001ECF RID: 7887 RVA: 0x000D6AC8 File Offset: 0x000D4EC8
	public static DifficultyLevelMeasurement GetDifficultyLevelMeasurementForTripEncounter(double difficultyValue)
	{
		return DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(difficultyValue, 1);
	}

	// Token: 0x06001ED0 RID: 7888 RVA: 0x000D6AD4 File Offset: 0x000D4ED4
	public int GetCorrespondingItemTierLevel(ResourceType type)
	{
		ResourceCategory resourceCategory = type.GetResourceCategory();
		if ((this.DifficultyValue <= 100.0 && this.StarRating == 1) || resourceCategory == ResourceCategory.Consumable || resourceCategory == ResourceCategory.Accessory)
		{
			if (type.HasCreationTemplate())
			{
				return type.GetCreationTemplate().ItemTierNumber;
			}
			return 1;
		}
		else
		{
			if (resourceCategory.IsWeapon() || resourceCategory.IsArmor() || resourceCategory == ResourceCategory.Scrolls || resourceCategory == ResourceCategory.Device)
			{
				return this.GetCorrespondingItemTier_Advanced();
			}
			return 1;
		}
	}

	// Token: 0x06001ED1 RID: 7889 RVA: 0x000D6B60 File Offset: 0x000D4F60
	public List<ResourceUpdate> GenerateRandomDevice()
	{
		List<ResourceType> list = new List<ResourceType>
		{
			ResourceType.PrismLightCharger,
			ResourceType.GhostBreathCollector,
			ResourceType.VitalEnergyContainer,
			ResourceType.SpiritBox,
			ResourceType.PrismScope,
			ResourceType.SoulLocker,
			ResourceType.ShieldRemover,
			ResourceType.PoisonousNeedles,
			ResourceType.FirstAidKit,
			ResourceType.MagicShield,
			ResourceType.Pacemaker,
			ResourceType.Dispeller,
			ResourceType.DefenceBreaker,
			ResourceType.ChaoticFlowTrigger,
			ResourceType.ReflectiveShield,
			ResourceType.VitalitySuppressor
		};
		list.Shuffle<ResourceType>();
		ResourceType resourceType = list.First<ResourceType>();
		return new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = resourceType,
				RelatedItems = new List<Item>
				{
					resourceType.ItemGenerate(ResourceSourceType.DungeonDrop, this.GetDefaultItemGenerationQuality(resourceType, ResourceSourceType.DungeonDrop), this.GetCorrespondingItemTierLevel(resourceType), 1)
				},
				ChangeAmount = 1.0
			}
		};
	}

	// Token: 0x06001ED2 RID: 7890 RVA: 0x000D6C90 File Offset: 0x000D5090
	private int GetCorrespondingItemTier_Advanced()
	{
		if (this.StarRating == 1)
		{
			if (this.DifficultyValue <= 110.0)
			{
				return 36;
			}
			if (this.DifficultyValue <= 130.0)
			{
				return 37;
			}
			if (this.DifficultyValue <= 150.0)
			{
				return 38;
			}
			if (this.DifficultyValue <= 180.0)
			{
				return 39;
			}
			if (this.DifficultyValue <= 210.0)
			{
				return 40;
			}
			return 41;
		}
		else if (this.StarRating == 2)
		{
			if (this.DifficultyValue <= 10.0)
			{
				return 41;
			}
			if (this.DifficultyValue <= 25.0)
			{
				return 42;
			}
			if (this.DifficultyValue <= 40.0)
			{
				return 43;
			}
			if (this.DifficultyValue <= 55.0)
			{
				return 44;
			}
			if (this.DifficultyValue <= 70.0)
			{
				return 45;
			}
			if (this.DifficultyValue <= 95.0)
			{
				return 46;
			}
			if (this.DifficultyValue <= 110.0)
			{
				return 47;
			}
			if (this.DifficultyValue <= 145.0)
			{
				return 48;
			}
			if (this.DifficultyValue <= 180.0)
			{
				return 49;
			}
			if (this.DifficultyValue <= 210.0)
			{
				return 50;
			}
			return 51;
		}
		else
		{
			if (this.StarRating != -1)
			{
				return 1;
			}
			if (this.DifficultyValue <= 5000.0)
			{
				int num = (int)Math.Ceiling(this.DifficultyValue / 30.0);
				int num2 = 50 + num;
				if (num2 > 90)
				{
					num2 = 90;
				}
				return num2;
			}
			int num3 = (int)Math.Ceiling((this.DifficultyValue - 5000.0) / 350.0);
			int num4 = 90 + num3;
			if (num4 > 110)
			{
				num4 = 110;
			}
			return num4;
		}
	}

	// Token: 0x06001ED3 RID: 7891 RVA: 0x000D6E94 File Offset: 0x000D5294
	private static int GetMonsterSkillLevel(double difficultyValue, int starrating)
	{
		if (difficultyValue <= 100.0 && starrating <= 1)
		{
			return (int)Math.Ceiling(difficultyValue / 20.0) + 1;
		}
		if (starrating == 2 || starrating == -1)
		{
			return 9;
		}
		int num = 5 + (int)Math.Ceiling((difficultyValue - 100.0) / 20.0);
		if (num > 9)
		{
			num = 9;
		}
		return num;
	}

	// Token: 0x06001ED4 RID: 7892 RVA: 0x000D6F08 File Offset: 0x000D5308
	public BattleEncounterRangeConfiguration GetEncounterRangeConfiguration()
	{
		if (this.StarRating == 1)
		{
			if (this.DifficultyValue <= 3.0)
			{
				return new BattleEncounterRangeConfiguration
				{
					NumberOfRounds = 1,
					EnemyAmountInBattleExclusiveTo = 3,
					EnemyAmountInBattleInclusiveFrom = 2
				};
			}
			if (this.DifficultyValue <= 10.0)
			{
				return new BattleEncounterRangeConfiguration
				{
					NumberOfRounds = 2,
					EnemyAmountInBattleExclusiveTo = 4,
					EnemyAmountInBattleInclusiveFrom = 2
				};
			}
			if (this.DifficultyValue <= 15.0)
			{
				return new BattleEncounterRangeConfiguration
				{
					NumberOfRounds = 2,
					EnemyAmountInBattleExclusiveTo = 5,
					EnemyAmountInBattleInclusiveFrom = 3
				};
			}
			if (this.DifficultyValue <= 28.0)
			{
				return new BattleEncounterRangeConfiguration
				{
					NumberOfRounds = 2,
					EnemyAmountInBattleExclusiveTo = 5,
					EnemyAmountInBattleInclusiveFrom = 4
				};
			}
			if (this.DifficultyValue <= 35.0)
			{
				return new BattleEncounterRangeConfiguration
				{
					NumberOfRounds = 2,
					EnemyAmountInBattleExclusiveTo = 6,
					EnemyAmountInBattleInclusiveFrom = 4
				};
			}
			if (this.DifficultyValue <= 50.0)
			{
				return new BattleEncounterRangeConfiguration
				{
					NumberOfRounds = 2,
					EnemyAmountInBattleExclusiveTo = 7,
					EnemyAmountInBattleInclusiveFrom = 5
				};
			}
		}
		return new BattleEncounterRangeConfiguration
		{
			EnemyAmountInBattleInclusiveFrom = 6,
			EnemyAmountInBattleExclusiveTo = 7,
			NumberOfRounds = 2
		};
	}

	// Token: 0x06001ED5 RID: 7893 RVA: 0x000D7064 File Offset: 0x000D5464
	public List<ResourceUpdate> GenerateDropableWeapons(QualityGrade grade, int numberOfItems, bool forceStar = false)
	{
		List<DropTableParameter> presences = (from s in this.GetDifficultyRelevantWeapons(new List<ResourceSourceType>
		{
			ResourceSourceType.DungeonDrop
		})
		select new DropTableParameter
		{
			ResourceType = s,
			Presence = 100,
			Level = 1,
			InclusiveVolumTo = 1.0,
			InclusiveVolumFrom = 1.0
		}).ToList<DropTableParameter>();
		return presences.WeightedRandomSelectMaxUniqueness((DropTableParameter a, DropTableParameter b) => a.ResourceType == b.ResourceType, numberOfItems).Select(delegate(DropTableParameter i)
		{
			ResourceUpdate resourceUpdate = new ResourceUpdate();
			resourceUpdate.ResourceType = i.ResourceType;
			resourceUpdate.ChangeAmount = 1.0;
			ResourceUpdate resourceUpdate2 = resourceUpdate;
			List<Item> list = new List<Item>();
			List<Item> list2 = list;
			ResourceType resourceType = i.ResourceType;
			ResourceSourceType itemSource = ResourceSourceType.DungeonDrop;
			int correspondingItemTierLevel = this.GetCorrespondingItemTierLevel(i.ResourceType);
			list2.Add(resourceType.ItemGenerate(itemSource, this.GetQualityConfig(new QualityGrade?(grade), ResourceSourceType.DungeonDrop, i.ResourceType, forceStar), correspondingItemTierLevel, 1));
			resourceUpdate2.RelatedItems = list;
			return resourceUpdate;
		}).ToList<ResourceUpdate>();
	}

	// Token: 0x06001ED6 RID: 7894 RVA: 0x000D7104 File Offset: 0x000D5504
	public List<ResourceUpdate> GenerateDropableGears(int numberOfItems, QualityGrade? determined, bool forceStar = false)
	{
		List<ResourceType> list = new List<ResourceType>();
		list.AddRange(this.GetDifficultyRelevantArmors(new List<ResourceSourceType>
		{
			ResourceSourceType.DungeonDrop
		}));
		list.AddRange(this.GetDifficultyRelevantWeapons(new List<ResourceSourceType>
		{
			ResourceSourceType.DungeonDrop
		}));
		List<DropTableParameter> presences = (from p in list
		select new DropTableParameter
		{
			ResourceType = p,
			Presence = 100,
			Level = 1,
			InclusiveVolumTo = 1.0,
			InclusiveVolumFrom = 1.0
		}).ToList<DropTableParameter>();
		return presences.WeightedRandomSelectMaxUniqueness((DropTableParameter a, DropTableParameter b) => a.ResourceType == b.ResourceType, numberOfItems).Select(delegate(DropTableParameter i)
		{
			ResourceUpdate resourceUpdate = new ResourceUpdate();
			resourceUpdate.ResourceType = i.ResourceType;
			resourceUpdate.ChangeAmount = 1.0;
			ResourceUpdate resourceUpdate2 = resourceUpdate;
			List<Item> list2 = new List<Item>();
			List<Item> list3 = list2;
			ResourceType resourceType = i.ResourceType;
			ResourceSourceType itemSource = ResourceSourceType.DungeonDrop;
			int correspondingItemTierLevel = this.GetCorrespondingItemTierLevel(i.ResourceType);
			list3.Add(resourceType.ItemGenerate(itemSource, this.GetQualityConfig(determined, ResourceSourceType.DungeonDrop, i.ResourceType, forceStar), correspondingItemTierLevel, 1));
			resourceUpdate2.RelatedItems = list2;
			return resourceUpdate;
		}).ToList<ResourceUpdate>();
	}

	// Token: 0x06001ED7 RID: 7895 RVA: 0x000D71D0 File Offset: 0x000D55D0
	private ItemGenerationQuality GetQualityConfig(QualityGrade? determined, ResourceSourceType sourceType, ResourceType itemType, bool forceStar = false)
	{
		ResourceCategory resourceCategory = itemType.GetResourceCategory();
		int correspondingItemTierLevel = this.GetCorrespondingItemTierLevel(itemType);
		bool flag = ((resourceCategory.IsWeapon() || resourceCategory.IsArmor()) && correspondingItemTierLevel > 35) || (resourceCategory == ResourceCategory.Accessory && correspondingItemTierLevel > 35 && forceStar) || (resourceCategory == ResourceCategory.Scrolls && correspondingItemTierLevel > 35);
		if (flag && forceStar)
		{
			return ItemGenerationQuality.CreateStar();
		}
		if (determined != null)
		{
			if (determined.Value == QualityGrade.Ancient)
			{
				bool flag2 = flag && (double)UnityEngine.Random.value <= this.GetStarChance(sourceType);
				if (flag2)
				{
					return ItemGenerationQuality.CreateStar();
				}
			}
			return ItemGenerationQuality.CreateGraded(determined.Value);
		}
		GenerationDistribution generationDistribution = this.GetDefaultItemGenerationDistribution(sourceType);
		double totalItemDropBoostRate = GameWorld.instance.PlayerProfile.GetTownStats().TotalItemDropBoostRate;
		generationDistribution = generationDistribution.BoostDrop(totalItemDropBoostRate);
		QualityGrade grade = generationDistribution.GetGrade();
		if (grade == QualityGrade.Ancient)
		{
			bool flag3 = flag && (double)UnityEngine.Random.value <= this.GetStarChance(sourceType);
			if (flag3)
			{
				return ItemGenerationQuality.CreateStar();
			}
		}
		return ItemGenerationQuality.CreateGraded(grade);
	}

	// Token: 0x06001ED8 RID: 7896 RVA: 0x000D7302 File Offset: 0x000D5702
	public ItemGenerationQuality GetItemGenerationQuality(QualityGrade grade, ResourceType type, ResourceSourceType sourceType)
	{
		return this.GetQualityConfig(new QualityGrade?(grade), sourceType, type, false);
	}

	// Token: 0x06001ED9 RID: 7897 RVA: 0x000D7314 File Offset: 0x000D5714
	public ItemGenerationQuality GetDefaultItemGenerationQuality(ResourceType type, ResourceSourceType sourceType)
	{
		return this.GetQualityConfig(null, sourceType, type, false);
	}

	// Token: 0x06001EDA RID: 7898 RVA: 0x000D7334 File Offset: 0x000D5734
	public List<ResourceUpdate> GenerateDropableGems(int numberOfGems)
	{
		List<DropTableParameter> presences = (from g in this.GetAllDropableGems()
		select new DropTableParameter
		{
			ResourceType = g,
			Presence = 100,
			Level = this.GemTier,
			InclusiveVolumTo = 1.0,
			InclusiveVolumFrom = 1.0
		}).ToList<DropTableParameter>();
		return (from g in presences.WeightedRandomSelectMaxUniqueness((DropTableParameter a, DropTableParameter b) => a.ResourceType == b.ResourceType, numberOfGems)
		select new ResourceUpdate
		{
			ResourceType = g.ResourceType,
			ChangeAmount = 1.0,
			RelatedItems = new List<Item>
			{
				g.ResourceType.ItemGenerate(ResourceSourceType.DungeonDrop, null, 1, g.Level)
			}
		}).ToList<ResourceUpdate>();
	}

	// Token: 0x06001EDB RID: 7899 RVA: 0x000D73AC File Offset: 0x000D57AC
	public List<UnitClass> GetPossibleMinionUnits()
	{
		List<UnitClass> list = new List<UnitClass>();
		foreach (AdventureType adventureType in this.GetPossibleAdventureTypes())
		{
			int highestLevelNumber = this.GetHighestLevelNumber(adventureType);
			if (highestLevelNumber != -1)
			{
				list.AddRange(from p in adventureType.GetConfiguration().GetPossibleMinionClasses(highestLevelNumber)
				select p.UnitClass);
			}
		}
		return list.Distinct<UnitClass>().ToList<UnitClass>();
	}

	// Token: 0x06001EDC RID: 7900 RVA: 0x000D7458 File Offset: 0x000D5858
	public List<UnitClass> GetPossibleMinibossUnits()
	{
		List<UnitClass> list = new List<UnitClass>();
		foreach (AdventureType adventureType in this.GetPossibleAdventureTypes())
		{
			int highestLevelNumber = this.GetHighestLevelNumber(adventureType);
			if (highestLevelNumber != -1)
			{
				list.AddRange(from a in adventureType.GetConfiguration().GetPossibleMinibossClasses(highestLevelNumber)
				select a.UnitClass);
			}
		}
		return list.Distinct<UnitClass>().ToList<UnitClass>();
	}

	// Token: 0x06001EDD RID: 7901 RVA: 0x000D7504 File Offset: 0x000D5904
	public List<UnitClass> GetPossibleBossUnits()
	{
		List<UnitClass> list = new List<UnitClass>();
		foreach (AdventureType adventureType in this.GetPossibleAdventureTypes())
		{
			int highestLevelNumber = this.GetHighestLevelNumber(adventureType);
			if (highestLevelNumber != -1)
			{
				list.AddRange(from a in adventureType.GetConfiguration().GetPossibleBossClasses(highestLevelNumber)
				select a.UnitClass);
			}
		}
		return list.Distinct<UnitClass>().ToList<UnitClass>();
	}

	// Token: 0x06001EDE RID: 7902 RVA: 0x000D75B0 File Offset: 0x000D59B0
	public List<AdventureType> GetPossibleAdventureTypes()
	{
		return (from c in LevelConfigurationExtension.AdventureConfigurations.Values
		where c.StartingDifficultyLevel <= this.DifficultyValue
		select c into a
		select a.CorrespondingAdventureType).ToList<AdventureType>();
	}

	// Token: 0x06001EDF RID: 7903 RVA: 0x000D7600 File Offset: 0x000D5A00
	public DropTable GetStandardDropableCompleteTable()
	{
		DropTable dropTable = new DropTable(new List<DropTableParameter>());
		dropTable.DropTableParameters.AddRange(from r in this.GetRawResources()
		select this.GetDefaultDropParameter(r, 1));
		List<ResourceType> allDropableGems = this.GetAllDropableGems();
		foreach (ResourceType resourceType in allDropableGems)
		{
			dropTable.DropTableParameters.Add(this.GetDefaultDropParameter(resourceType, this.GemTier));
		}
		dropTable.DropTableParameters.AddRange(from r in this.GetDifficultyRelatedWeaponRecipes(new List<ResourceSourceType>
		{
			ResourceSourceType.DungeonDrop
		})
		select this.GetDefaultDropParameter(r, 1));
		dropTable.DropTableParameters.AddRange(from r in this.GetDifficultyRelatedArmorRecipes(new List<ResourceSourceType>
		{
			ResourceSourceType.DungeonDrop
		})
		select this.GetDefaultDropParameter(r, 1));
		dropTable.DropTableParameters.AddRange(from a in this.GetDifficultyRelatedGears(new List<ResourceSourceType>
		{
			ResourceSourceType.DungeonDrop
		})
		select this.GetDefaultDropParameter(a, 1));
		dropTable.DropTableParameters.Add(this.GetDefaultDropParameter(ResourceType.PracticePoints, 1));
		if (this.StarRating == -1)
		{
			dropTable.DropTableParameters.Add(this.GetDefaultDropParameter(ResourceType.AshOfHope, 1));
		}
		return dropTable;
	}

	// Token: 0x06001EE0 RID: 7904 RVA: 0x000D7770 File Offset: 0x000D5B70
	private int GetLevelOneMaterialDropAmount()
	{
		if (this.StarRating == 1)
		{
			double num = 20.0 + this.DifficultyValue * 2.0;
			if (num > 150.0)
			{
				num = 150.0;
			}
			return (int)num;
		}
		return 0;
	}

	// Token: 0x06001EE1 RID: 7905 RVA: 0x000D77C4 File Offset: 0x000D5BC4
	private int GetLevelTwoMaterialDropAmount()
	{
		if (this.StarRating != 1)
		{
			double num = 50.0 + this.DifficultyValue;
			if (num > 150.0)
			{
				num = 150.0;
			}
			return (int)num;
		}
		if (this.DifficultyValue > 100.0)
		{
			double num2 = 5.0 + Math.Floor((this.DifficultyValue - 100.0) / 2.0);
			if (num2 > 50.0)
			{
				num2 = 50.0;
			}
			return (int)num2;
		}
		return 0;
	}

	// Token: 0x06001EE2 RID: 7906 RVA: 0x000D7868 File Offset: 0x000D5C68
	public DropTableParameter GetDefaultDropParameter(ResourceType resourceType, int level = 1)
	{
		ResourceCategory resourceCategory = resourceType.GetResourceCategory();
		if (resourceCategory == ResourceCategory.Hides || resourceCategory == ResourceCategory.Timber || resourceCategory == ResourceCategory.Ore)
		{
			if (resourceType == ResourceType.Ore || resourceType == ResourceType.Leather || resourceType == ResourceType.Wood)
			{
				int levelOneMaterialDropAmount = this.GetLevelOneMaterialDropAmount();
				return new DropTableParameter
				{
					ResourceType = resourceType,
					Presence = 100,
					InclusiveVolumFrom = (double)levelOneMaterialDropAmount,
					InclusiveVolumTo = (double)levelOneMaterialDropAmount
				};
			}
			if (resourceType == ResourceType.RefinedOre || resourceType == ResourceType.RefinedLeather)
			{
				int levelTwoMaterialDropAmount = this.GetLevelTwoMaterialDropAmount();
				return new DropTableParameter
				{
					ResourceType = resourceType,
					Presence = 100,
					InclusiveVolumFrom = (double)levelTwoMaterialDropAmount,
					InclusiveVolumTo = (double)levelTwoMaterialDropAmount
				};
			}
		}
		if (resourceCategory == ResourceCategory.Gem)
		{
			return new DropTableParameter
			{
				ResourceType = resourceType,
				Level = level,
				Presence = 100,
				InclusiveVolumTo = 1.0,
				InclusiveVolumFrom = 1.0
			};
		}
		if (resourceCategory == ResourceCategory.Usable)
		{
			if (resourceType == ResourceType.AllSocketBatcher)
			{
				return new DropTableParameter
				{
					ResourceType = resourceType,
					Level = level,
					Presence = 10,
					InclusiveVolumTo = 1.0,
					InclusiveVolumFrom = 1.0
				};
			}
			return new DropTableParameter
			{
				ResourceType = resourceType,
				Level = level,
				Presence = 100,
				InclusiveVolumTo = 1.0,
				InclusiveVolumFrom = 1.0
			};
		}
		else
		{
			if (resourceCategory == ResourceCategory.ProductionRecipe)
			{
				return new DropTableParameter
				{
					ResourceType = resourceType,
					Presence = resourceType.GetRecipeByRecipeName().ProductType.GetCreationTemplate().DefaultRecipeDropPresences,
					InclusiveVolumFrom = 1.0,
					InclusiveVolumTo = 1.0
				};
			}
			if (resourceCategory == ResourceCategory.Accessory)
			{
				return new DropTableParameter
				{
					ResourceType = resourceType,
					Presence = resourceType.GetCreationTemplate().DefaultItemDropPresences,
					InclusiveVolumTo = 1.0,
					InclusiveVolumFrom = 1.0
				};
			}
			if (resourceCategory.IsWeapon() || resourceCategory.IsArmor())
			{
				return new DropTableParameter
				{
					ResourceType = resourceType,
					Presence = resourceType.GetCreationTemplate().DefaultItemDropPresences,
					InclusiveVolumTo = 1.0,
					InclusiveVolumFrom = 1.0
				};
			}
			if (resourceType == ResourceType.PracticePoints)
			{
				double num = this.GetPracticePointsPerGain((this.StarRating != 1) ? (this.DifficultyValue + 200.0) : this.DifficultyValue);
				if (num > 4000.0)
				{
					num = 4000.0;
				}
				double num2 = GameWorld.instance.PlayerProfile.GetTownStats().TotalPracticePointsBoost + 1.0;
				return new DropTableParameter
				{
					ResourceType = resourceType,
					Level = 1,
					Presence = 100,
					InclusiveVolumTo = num * num2,
					InclusiveVolumFrom = num * num2
				};
			}
			if (resourceType == ResourceType.AshOfHope)
			{
				int num3 = (this.StarRating != -1) ? 0 : (5 + (int)Math.Floor(this.DifficultyValue / 4.0));
				return new DropTableParameter
				{
					ResourceType = resourceType,
					Level = 1,
					Presence = 100,
					InclusiveVolumTo = (double)num3,
					InclusiveVolumFrom = (double)num3
				};
			}
			throw new NotImplementedException();
		}
	}

	// Token: 0x06001EE3 RID: 7907 RVA: 0x000D7BF4 File Offset: 0x000D5FF4
	public double GetPracticePointsPerGain(double difficultyValue)
	{
		if (this.StarRating == 1)
		{
			if (difficultyValue <= 20.0)
			{
				return difficultyValue * 80.0 + 300.0;
			}
			if (difficultyValue <= 40.0)
			{
				return (difficultyValue - 20.0) * 50.0 + 1900.0;
			}
			if (difficultyValue <= 60.0)
			{
				return (difficultyValue - 40.0) * 20.0 + 2900.0;
			}
			if (difficultyValue <= 100.0)
			{
				return (difficultyValue - 60.0) * 10.0 + 3300.0;
			}
			if (difficultyValue <= 150.0)
			{
				return (difficultyValue - 100.0) * 5.0 + 3700.0;
			}
			return 4000.0;
		}
		else
		{
			if (this.StarRating != 2)
			{
				return 7000.0;
			}
			if (difficultyValue <= 50.0)
			{
				return 4000.0 + 20.0 * difficultyValue;
			}
			if (difficultyValue <= 150.0)
			{
				return 5000.0 + 10.0 * (difficultyValue - 50.0);
			}
			return 6000.0;
		}
	}

	// Token: 0x06001EE4 RID: 7908 RVA: 0x000D7D6C File Offset: 0x000D616C
	public List<ResourceType> GetDifficultyRelatedWeaponRecipes(List<ResourceSourceType> sourceTypes)
	{
		DifficultyLevelMeasurement.<GetDifficultyRelatedWeaponRecipes>c__AnonStorey2 <GetDifficultyRelatedWeaponRecipes>c__AnonStorey = new DifficultyLevelMeasurement.<GetDifficultyRelatedWeaponRecipes>c__AnonStorey2();
		<GetDifficultyRelatedWeaponRecipes>c__AnonStorey.sourceTypes = sourceTypes;
		<GetDifficultyRelatedWeaponRecipes>c__AnonStorey.$this = this;
		if (this.DifficultyValue > 100.0 || this.StarRating > 1 || this.StarRating == -1)
		{
			List<ResourceType> allResourceTypes = ItemExtensions.AllResourceTypes;
			return (from r in allResourceTypes
			where r.GetResourceCategory().IsWeapon() && r.HasCreationTemplate() && r.GetCreationTemplate().RecipeSourceTypes.Any((ResourceSourceType t) => <GetDifficultyRelatedWeaponRecipes>c__AnonStorey.sourceTypes.Any((ResourceSourceType ss) => ss == t))
			select r into w
			select w.GetCreationTemplate().GetRecipe().RecipeName).ToList<ResourceType>();
		}
		List<ResourceType> allResourceTypes2 = ItemExtensions.AllResourceTypes;
		List<int> itemLevels = this.GetCorrespondingItemTiers_Normal();
		return (from r in allResourceTypes2
		where r.GetResourceCategory().IsWeapon() && r.HasCreationTemplate() && r.GetCreationTemplate().RecipeSourceTypes.Any((ResourceSourceType t) => <GetDifficultyRelatedWeaponRecipes>c__AnonStorey.sourceTypes.Any((ResourceSourceType ss) => ss == t))
		select r into w
		where itemLevels.Any((int l) => l == <GetDifficultyRelatedWeaponRecipes>c__AnonStorey.$this.GetCorrespondingItemTierLevel(w))
		select w.GetCreationTemplate().GetRecipe().RecipeName).ToList<ResourceType>();
	}

	// Token: 0x06001EE5 RID: 7909 RVA: 0x000D7E66 File Offset: 0x000D6266
	public int GetDropableEquipmentLevel()
	{
		return (int)Math.Ceiling((double)this.GetDropableEquipmentItemTierLevel() / 5.0);
	}

	// Token: 0x06001EE6 RID: 7910 RVA: 0x000D7E80 File Offset: 0x000D6280
	public int GetDropableEquipmentItemTierLevel()
	{
		if (this.StarRating == 1 && this.DifficultyValue <= 100.0)
		{
			return (from n in this.GetCorrespondingItemTiers_Normal()
			orderby n descending
			select n).First<int>();
		}
		return this.GetCorrespondingItemTier_Advanced();
	}

	// Token: 0x06001EE7 RID: 7911 RVA: 0x000D7EE4 File Offset: 0x000D62E4
	public List<ResourceType> GetDifficultyRelatedArmorRecipes(List<ResourceSourceType> sourceTypes)
	{
		DifficultyLevelMeasurement.<GetDifficultyRelatedArmorRecipes>c__AnonStorey7 <GetDifficultyRelatedArmorRecipes>c__AnonStorey = new DifficultyLevelMeasurement.<GetDifficultyRelatedArmorRecipes>c__AnonStorey7();
		<GetDifficultyRelatedArmorRecipes>c__AnonStorey.sourceTypes = sourceTypes;
		<GetDifficultyRelatedArmorRecipes>c__AnonStorey.$this = this;
		if (this.DifficultyValue > 100.0 || this.StarRating > 1 || this.StarRating == -1)
		{
			List<ResourceType> allResourceTypes = ItemExtensions.AllResourceTypes;
			return (from r in allResourceTypes
			where r.GetResourceCategory().IsArmor() && r.HasCreationTemplate() && r.GetCreationTemplate().RecipeSourceTypes.Any((ResourceSourceType t) => <GetDifficultyRelatedArmorRecipes>c__AnonStorey.sourceTypes.Any((ResourceSourceType ss) => ss == t))
			select r into w
			select w.GetCreationTemplate().GetRecipe().RecipeName).ToList<ResourceType>();
		}
		List<ResourceType> allResourceTypes2 = ItemExtensions.AllResourceTypes;
		List<int> itemLevels = this.GetCorrespondingItemTiers_Normal();
		return (from r in allResourceTypes2
		where r.GetResourceCategory().IsArmor() && r.HasCreationTemplate() && r.GetCreationTemplate().RecipeSourceTypes.Any((ResourceSourceType t) => <GetDifficultyRelatedArmorRecipes>c__AnonStorey.sourceTypes.Any((ResourceSourceType ss) => ss == t))
		select r into w
		where itemLevels.Any((int l) => l == <GetDifficultyRelatedArmorRecipes>c__AnonStorey.$this.GetCorrespondingItemTierLevel(w))
		select w.GetCreationTemplate().GetRecipe().RecipeName).ToList<ResourceType>();
	}

	// Token: 0x06001EE8 RID: 7912 RVA: 0x000D7FE4 File Offset: 0x000D63E4
	public List<ResourceUpdate> GenerateAccessories(int volum, QualityGrade? grade = null, bool forceStar = false)
	{
		List<DropTableParameter> list = (from t in this.GetDifficultyRelatedAccessories()
		select new DropTableParameter
		{
			ResourceType = t,
			Presence = 100,
			Level = 1,
			InclusiveVolumTo = 1.0,
			InclusiveVolumFrom = 1.0
		}).ToList<DropTableParameter>();
		if (forceStar)
		{
			list = (from p in list
			where p.ResourceType.GetCreationTemplate() is AccessoryTemplateBase && (p.ResourceType.GetCreationTemplate() as AccessoryTemplateBase).GenerateStarEffects(QualityGrade.Ancient, this.GetCorrespondingItemTierLevel(p.ResourceType)).Any<ISpecialEffectDataLoad>()
			select p).ToList<DropTableParameter>();
		}
		List<DropTableParameter> list2 = list.WeightedRandomSelectMaxUniqueness((DropTableParameter a, DropTableParameter b) => a.ResourceType == b.ResourceType, volum);
		List<ResourceUpdate> list3 = new List<ResourceUpdate>();
		foreach (DropTableParameter dropTableParameter in list2)
		{
			AccessoryTemplateBase accessoryTemplateBase = dropTableParameter.ResourceType.GetCreationTemplate() as AccessoryTemplateBase;
			if (accessoryTemplateBase != null)
			{
				if (forceStar && !accessoryTemplateBase.GenerateStarEffects(QualityGrade.Ancient, this.GetCorrespondingItemTierLevel(accessoryTemplateBase.ItemType)).Any<ISpecialEffectDataLoad>())
				{
					forceStar = false;
				}
				ResourceType resourceType = dropTableParameter.ResourceType;
				ResourceSourceType itemSource = ResourceSourceType.DungeonDrop;
				int correspondingItemTierLevel = this.GetCorrespondingItemTierLevel(dropTableParameter.ResourceType);
				Item item = resourceType.ItemGenerate(itemSource, this.GetQualityConfig(grade, ResourceSourceType.DungeonDrop, dropTableParameter.ResourceType, forceStar), correspondingItemTierLevel, 1);
				list3.Add(new ResourceUpdate
				{
					ResourceType = item.Type,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>
					{
						item
					}
				});
			}
		}
		return list3;
	}

	// Token: 0x06001EE9 RID: 7913 RVA: 0x000D816C File Offset: 0x000D656C
	public List<ResourceType> GetDifficultyRelatedAccessories()
	{
		if (this.StarRating == 1)
		{
			if (this.DifficultyValue <= 15.0)
			{
				return new List<ResourceType>
				{
					ResourceType.ClearWaterOne,
					ResourceType.CollectorOne,
					ResourceType.DeadMatchOne,
					ResourceType.DragonSealOne,
					ResourceType.FameOne,
					ResourceType.InsolenceOne,
					ResourceType.LighteningRunnerOne,
					ResourceType.PhenixOne,
					ResourceType.SoulSealOne,
					ResourceType.WarmJadeOne
				};
			}
			if (this.DifficultyValue <= 40.0)
			{
				return new List<ResourceType>
				{
					ResourceType.ClearWaterTwo,
					ResourceType.CollectorTwo,
					ResourceType.DeadMatchTwo,
					ResourceType.DragonSealTwo,
					ResourceType.FameTwo,
					ResourceType.InsolenceTwo,
					ResourceType.LighteningRunnerTwo,
					ResourceType.PhenixTwo,
					ResourceType.SoulSealTwo,
					ResourceType.WarmJadeTwo
				};
			}
			if (this.DifficultyValue <= 65.0)
			{
				return new List<ResourceType>
				{
					ResourceType.ClearWaterThree,
					ResourceType.CollectorThree,
					ResourceType.DeadMatchThree,
					ResourceType.DragonSealThree,
					ResourceType.FameThree,
					ResourceType.InsolenceThree,
					ResourceType.LighteningRunnerThree,
					ResourceType.PhenixThree,
					ResourceType.SoulSealThree,
					ResourceType.WarmJadeThree
				};
			}
			if (this.DifficultyValue <= 100.0)
			{
				return new List<ResourceType>
				{
					ResourceType.ClearWaterFour,
					ResourceType.CollectorFour,
					ResourceType.DeadMatchFour,
					ResourceType.DragonSealFour,
					ResourceType.FameFour,
					ResourceType.InsolenceFour,
					ResourceType.LighteningRunnerFour,
					ResourceType.PhenixFour,
					ResourceType.SoulSealFour,
					ResourceType.WarmJadeFour
				};
			}
			if (this.DifficultyValue <= 150.0)
			{
				return new List<ResourceType>
				{
					ResourceType.ClearWaterFive,
					ResourceType.DeadMatchFour,
					ResourceType.DragonSealFive,
					ResourceType.FameFive,
					ResourceType.InsolenceFive,
					ResourceType.LightningRunnerFive,
					ResourceType.PhenixFive,
					ResourceType.SoulSealFive,
					ResourceType.WarmJadeFive,
					ResourceType.CollectorFour
				};
			}
			return new List<ResourceType>
			{
				ResourceType.ClearWaterSix,
				ResourceType.DeadMatchFour,
				ResourceType.DragonSealSix,
				ResourceType.FameSix,
				ResourceType.InsolenceSix,
				ResourceType.LightningRunnerSix,
				ResourceType.PhenixSix,
				ResourceType.SoulSealSix,
				ResourceType.WarmJadeSix,
				ResourceType.CollectorFour
			};
		}
		else
		{
			if (this.DifficultyValue <= 50.0 && this.StarRating == 2)
			{
				return new List<ResourceType>
				{
					ResourceType.ClearWaterSix,
					ResourceType.DeadMatchFour,
					ResourceType.DragonSealSix,
					ResourceType.FameSix,
					ResourceType.InsolenceSix,
					ResourceType.LightningRunnerSix,
					ResourceType.PhenixSix,
					ResourceType.SoulSealSix,
					ResourceType.WarmJadeSix,
					ResourceType.CollectorFour
				};
			}
			return new List<ResourceType>
			{
				ResourceType.ClearWaterSeven,
				ResourceType.DeadMatchFour,
				ResourceType.DragonSealSeven,
				ResourceType.FameSeven,
				ResourceType.InsolenceSeven,
				ResourceType.LightningRunnerSeven,
				ResourceType.PhenixSeven,
				ResourceType.SoulSealSeven,
				ResourceType.WarmJadeSeven,
				ResourceType.CollectorFour
			};
		}
	}

	// Token: 0x06001EEA RID: 7914 RVA: 0x000D85B8 File Offset: 0x000D69B8
	public List<ResourceType> GetDifficultyRelatedGears(List<ResourceSourceType> sourceTypes)
	{
		if (this.DifficultyValue <= 100.0 && this.StarRating == 1)
		{
			List<ResourceType> allResourceTypes = ItemExtensions.AllResourceTypes;
			List<int> itemLevels = this.GetCorrespondingItemTiers_Normal();
			return (from r in allResourceTypes
			where (r.GetResourceCategory().IsWeapon() || r.GetResourceCategory().IsArmor()) && r.HasCreationTemplate() && r.GetCreationTemplate().ItemSourceTypes.Any((ResourceSourceType t) => sourceTypes.Any((ResourceSourceType ss) => ss == t))
			select r into w
			where itemLevels.Any((int l) => l == this.GetCorrespondingItemTierLevel(w))
			select w).ToList<ResourceType>();
		}
		List<ResourceType> allResourceTypes2 = ItemExtensions.AllResourceTypes;
		return (from r in allResourceTypes2
		where (r.GetResourceCategory().IsWeapon() || r.GetResourceCategory().IsArmor()) && r.HasCreationTemplate() && r.GetCreationTemplate().ItemSourceTypes.Any((ResourceSourceType t) => sourceTypes.Any((ResourceSourceType ss) => ss == t))
		select r).ToList<ResourceType>();
	}

	// Token: 0x06001EEB RID: 7915 RVA: 0x000D8668 File Offset: 0x000D6A68
	public List<ResourceType> GetAllDropableGems()
	{
		List<ResourceType> list = new List<ResourceType>();
		list.Add(ResourceType.FairyStone);
		list.Add(ResourceType.StoneOfSoulbringer);
		list.Add(ResourceType.FlyingFeather);
		list.Add(ResourceType.GodsMoral);
		list.Add(ResourceType.SpiritOfDeadGeneral);
		list.Add(ResourceType.EmeraldOfClearHeart);
		list.Add(ResourceType.BoneOfRapture);
		list.Add(ResourceType.UndeadAsh);
		list.Add(ResourceType.MonksEyes);
		list.Add(ResourceType.SavageHeart);
		list.Add(ResourceType.DemonicFire);
		list.Add(ResourceType.EvilHeart);
		if (this.StarRating == -1 || (this.StarRating == 2 && this.DifficultyValue >= 220.0))
		{
			list.Add(ResourceType.EyeOfPrecision);
			list.Add(ResourceType.StoneOfExorcism);
			list.Add(ResourceType.CommandmentOfSpell);
		}
		return list;
	}

	// Token: 0x06001EEC RID: 7916 RVA: 0x000D8750 File Offset: 0x000D6B50
	public List<ResidentType> ResidentCandidates()
	{
		return (from v in ResidentsExtensions.ResidentBaseLogics
		select v.Value into v
		where (double)v.ResidentRankParameter <= this.DifficultyValue || this.StarRating > 1 || this.StarRating == -1
		select v.ResidentType).ToList<ResidentType>();
	}

	// Token: 0x06001EED RID: 7917 RVA: 0x000D87BC File Offset: 0x000D6BBC
	public List<ResourceType> GetDifficultyRelevantWeapons(List<ResourceSourceType> sourceTypes)
	{
		if (this.DifficultyValue <= 100.0 && this.StarRating == 1)
		{
			List<ResourceType> allResourceTypes = ItemExtensions.AllResourceTypes;
			List<int> itemLevels = this.GetCorrespondingItemTiers_Normal();
			return (from r in allResourceTypes
			where r.GetResourceCategory().IsWeapon()
			select r into w
			where itemLevels.Any((int l) => l == this.GetCorrespondingItemTierLevel(w)) && w.HasCreationTemplate() && w.GetCreationTemplate().ItemSourceTypes.Any((ResourceSourceType t) => sourceTypes.Any((ResourceSourceType ss) => ss == t))
			select w).ToList<ResourceType>();
		}
		List<ResourceType> allResourceTypes2 = ItemExtensions.AllResourceTypes;
		return (from r in allResourceTypes2
		where r.GetResourceCategory().IsWeapon()
		select r into w
		where w.HasCreationTemplate() && w.GetCreationTemplate().ItemSourceTypes.Any((ResourceSourceType t) => sourceTypes.Any((ResourceSourceType ss) => ss == t))
		select w).ToList<ResourceType>();
	}

	// Token: 0x06001EEE RID: 7918 RVA: 0x000D88A0 File Offset: 0x000D6CA0
	public List<ResourceType> GetDifficultyRelevantArmors(List<ResourceSourceType> sourceTypes)
	{
		if (this.DifficultyValue <= 100.0 && this.StarRating == 1)
		{
			List<ResourceType> allResourceTypes = ItemExtensions.AllResourceTypes;
			List<int> itemLevels = this.GetCorrespondingItemTiers_Normal();
			return (from r in allResourceTypes
			where r.GetResourceCategory().IsArmor()
			select r into w
			where itemLevels.Any((int l) => l == this.GetCorrespondingItemTierLevel(w)) && w.HasCreationTemplate() && w.GetCreationTemplate().ItemSourceTypes.Any((ResourceSourceType t) => sourceTypes.Any((ResourceSourceType ss) => ss == t))
			select w).ToList<ResourceType>();
		}
		List<ResourceType> allResourceTypes2 = ItemExtensions.AllResourceTypes;
		return (from r in allResourceTypes2
		where r.GetResourceCategory().IsArmor()
		select r into w
		where w.HasCreationTemplate() && w.GetCreationTemplate().ItemSourceTypes.Any((ResourceSourceType t) => sourceTypes.Any((ResourceSourceType ss) => ss == t))
		select w).ToList<ResourceType>();
	}

	// Token: 0x06001EEF RID: 7919 RVA: 0x000D8984 File Offset: 0x000D6D84
	public List<Commodity> GetShopItems(int numberOfItems)
	{
		List<Commodity> list = new List<Commodity>();
		List<DropTypePresence> presences = new List<DropTypePresence>
		{
			new DropTypePresence
			{
				Presence = 100,
				DropType = DropType.Accessories
			}
		};
		int numberOfDaysTillExpiration = 45;
		for (int i = 0; i < numberOfItems; i++)
		{
			DropType dropType = presences.WeightedRandomSelect<DropTypePresence>().DropType;
			if (dropType == DropType.Accessories)
			{
				List<ResourceType> difficultyRelatedAccessories = this.GetDifficultyRelatedAccessories();
				if (difficultyRelatedAccessories.Any<ResourceType>())
				{
					ResourceType randomSelection = this.GetRandomSelection(difficultyRelatedAccessories);
					ResourceType type = randomSelection;
					ResourceSourceType itemSource = ResourceSourceType.ShopPurchase;
					int correspondingItemTierLevel = this.GetCorrespondingItemTierLevel(randomSelection);
					Item item = type.ItemGenerate(itemSource, this.GetQualityConfig(null, ResourceSourceType.ShopPurchase, randomSelection, false), correspondingItemTierLevel, 1);
					list.Add(new Commodity
					{
						ResourceType = item.Type,
						Amount = 1,
						Items = new List<Item>
						{
							item
						},
						PricePerItem = item.Value * 2.0 * (0.8 + 0.2 * (double)item.ItemGrade),
						NumberOfDaysTillExpiration = numberOfDaysTillExpiration
					});
				}
			}
		}
		return list;
	}

	// Token: 0x06001EF0 RID: 7920 RVA: 0x000D8AC8 File Offset: 0x000D6EC8
	public List<ResourceType> GetRawResources()
	{
		if (this.StarRating != 1)
		{
			return new List<ResourceType>
			{
				ResourceType.RefinedOre,
				ResourceType.RefinedLeather
			};
		}
		if (this.DifficultyValue <= 100.0)
		{
			return new List<ResourceType>
			{
				ResourceType.Ore,
				ResourceType.Leather
			};
		}
		return new List<ResourceType>
		{
			ResourceType.RefinedOre,
			ResourceType.RefinedLeather,
			ResourceType.Ore,
			ResourceType.Leather
		};
	}

	// Token: 0x06001EF1 RID: 7921 RVA: 0x000D8B64 File Offset: 0x000D6F64
	public List<ResourceType> GetDifficultyRelatedConsumables()
	{
		if (this.StarRating != 1)
		{
			return new List<ResourceType>
			{
				ResourceType.MagicBreadOne,
				ResourceType.LifePotionSix,
				ResourceType.LifePotionSeven
			};
		}
		if (this.DifficultyValue <= 15.0)
		{
			return new List<ResourceType>
			{
				ResourceType.LifePotionOne
			};
		}
		if (this.DifficultyValue <= 25.0)
		{
			return new List<ResourceType>
			{
				ResourceType.LifePotionOne,
				ResourceType.LifePotionTwo
			};
		}
		if (this.DifficultyValue <= 40.0)
		{
			return new List<ResourceType>
			{
				ResourceType.LifePotionTwo,
				ResourceType.LifePotionThree
			};
		}
		if (this.DifficultyValue <= 55.0)
		{
			return new List<ResourceType>
			{
				ResourceType.LifePotionThree,
				ResourceType.LifePotionFour
			};
		}
		if (this.DifficultyValue <= 65.0)
		{
			return new List<ResourceType>
			{
				ResourceType.LifePotionFour,
				ResourceType.LifePotionFive
			};
		}
		return new List<ResourceType>
		{
			ResourceType.LifePotionFive,
			ResourceType.LifePotionSix
		};
	}

	// Token: 0x06001EF2 RID: 7922 RVA: 0x000D8CB4 File Offset: 0x000D70B4
	public List<ResourceType> GetDifficultyRelatedUseables()
	{
		return new List<ResourceType>
		{
			ResourceType.AllSocketBatcher
		};
	}

	// Token: 0x06001EF3 RID: 7923 RVA: 0x000D8CD3 File Offset: 0x000D70D3
	public static int GetMaxNumberOfLevels(double currentDifficultyValue, double endingDifficultyValue)
	{
		return (int)((endingDifficultyValue - currentDifficultyValue) / DifficultyLevelMeasurement.DefaultDifficultyGapPerDungeonLevelIncrement);
	}

	// Token: 0x06001EF4 RID: 7924 RVA: 0x000D8CE0 File Offset: 0x000D70E0
	public static DifficultyLevelMeasurement GetDifficultyLevelMeasurementByDungeonLevel(int dungeonLevel, AdventureType type, int starrating)
	{
		if (type == AdventureType.Endless_Entry)
		{
			return DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue((double)dungeonLevel, -1);
		}
		LevelConfigurationBase configuration = type.GetConfiguration();
		return DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByValue(configuration.GetDifficultyValue(dungeonLevel), starrating);
	}

	// Token: 0x06001EF5 RID: 7925 RVA: 0x000D8D14 File Offset: 0x000D7114
	public int GetHighestLevelNumber(AdventureType dungeonType)
	{
		LevelConfigurationBase configuration = dungeonType.GetConfiguration();
		if (this.DifficultyValue < configuration.StartingDifficultyLevel)
		{
			return -1;
		}
		return (int)Math.Floor((this.DifficultyValue + 1.0 - configuration.StartingDifficultyLevel) / DifficultyLevelMeasurement.DefaultDifficultyGapPerDungeonLevelIncrement);
	}

	// Token: 0x06001EF6 RID: 7926 RVA: 0x000D8D60 File Offset: 0x000D7160
	public List<Commodity> GetAdvancedCommodities()
	{
		if (this.StarRating != -1)
		{
			return new List<Commodity>();
		}
		if (GameWorld.instance.PlayerProfile.EndlessDungeonIsEnabled() || TestingProcessor.InTesting)
		{
			return new List<Commodity>
			{
				new Commodity
				{
					ResourceType = ResourceType.FragmentOfDemon,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(3.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.InfusedPowder,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(2.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.CrystalOfWoodenForest,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(6.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.InkOfMistForest,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(6.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.IceOfSnowMountain,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(6.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.SealOfBuriedTemple,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(6.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.StoneOfHellishPath,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(6.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.LeafOfImperialM,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(6.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.SandOfNorthernTerritory,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(6.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.AdventurerPack,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(120.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.GreenGemPack,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(25.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.YellowGemPack,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(25.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.RedGemPack,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(25.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.BlueGemPack,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(25.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.PracticePointsPack,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(25.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.ResidentsPack,
					Amount = 1,
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0,
					AshPerItem = new double?(35.0)
				},
				new Commodity
				{
					ResourceType = ResourceType.BookFragments,
					Amount = 1,
					AshPerItem = new double?(20.0),
					Items = new List<Item>(),
					NumberOfDaysTillExpiration = int.MaxValue,
					PricePerItem = 0.0
				}
			};
		}
		return new List<Commodity>();
	}

	// Token: 0x06001EF7 RID: 7927 RVA: 0x000D9384 File Offset: 0x000D7784
	private static int GetGemLevel(double difficultyValue, int starRating)
	{
		if (starRating == 1)
		{
			if (difficultyValue <= 10.0)
			{
				return 1;
			}
			if (difficultyValue <= 26.0)
			{
				return 2;
			}
			if (difficultyValue <= 35.0)
			{
				return 3;
			}
			if (difficultyValue <= 42.0)
			{
				return 4;
			}
			if (difficultyValue <= 100.0)
			{
				return 5;
			}
			if (difficultyValue <= 130.0)
			{
				return 6;
			}
			if (difficultyValue <= 210.0)
			{
				return 7;
			}
			return 8;
		}
		else if (starRating == 2)
		{
			if (difficultyValue <= 80.0)
			{
				return 8;
			}
			if (difficultyValue <= 200.0)
			{
				return 9;
			}
			return 10;
		}
		else
		{
			if (difficultyValue <= 50.0)
			{
				return 10;
			}
			if (difficultyValue <= 100.0)
			{
				return 11;
			}
			if (difficultyValue <= 200.0)
			{
				return 12;
			}
			if (difficultyValue <= 300.0)
			{
				return 13;
			}
			if (difficultyValue <= 400.0)
			{
				return 14;
			}
			if (difficultyValue <= 500.0)
			{
				return 15;
			}
			if (difficultyValue <= 600.0)
			{
				return 16;
			}
			if (difficultyValue <= 700.0)
			{
				return 17;
			}
			if (difficultyValue <= 800.0)
			{
				return 18;
			}
			if (difficultyValue <= 5000.0)
			{
				return 19;
			}
			return 20;
		}
	}

	// Token: 0x06001EF8 RID: 7928 RVA: 0x000D94F4 File Offset: 0x000D78F4
	private static double GetMonsterPowerLevel(double difficultyValue)
	{
		if (difficultyValue <= 6.0)
		{
			return difficultyValue * 0.6 + 0.06;
		}
		if (difficultyValue <= 9.0)
		{
			return (difficultyValue - 6.0) * 0.3 + DifficultyLevelMeasurement.GetMonsterPowerLevel(6.0);
		}
		if (difficultyValue <= 13.0)
		{
			return (difficultyValue - 9.0) * 1.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel(9.0);
		}
		if (difficultyValue <= 16.0)
		{
			return (difficultyValue - 13.0) * 1.3 + DifficultyLevelMeasurement.GetMonsterPowerLevel(13.0);
		}
		if (difficultyValue <= 20.0)
		{
			return (difficultyValue - 16.0) * 2.1 + DifficultyLevelMeasurement.GetMonsterPowerLevel(16.0);
		}
		if (difficultyValue <= 23.0)
		{
			return (difficultyValue - 20.0) * 1.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel(20.0);
		}
		if (difficultyValue <= 27.0)
		{
			return (difficultyValue - 23.0) * 2.0 + DifficultyLevelMeasurement.GetMonsterPowerLevel(23.0);
		}
		if (difficultyValue <= 30.0)
		{
			return (difficultyValue - 27.0) * 1.2 + DifficultyLevelMeasurement.GetMonsterPowerLevel(27.0);
		}
		if (difficultyValue <= 35.0)
		{
			return (difficultyValue - 30.0) * 2.1 + DifficultyLevelMeasurement.GetMonsterPowerLevel(30.0);
		}
		if (difficultyValue <= 38.0)
		{
			return (difficultyValue - 35.0) * 1.2 + DifficultyLevelMeasurement.GetMonsterPowerLevel(35.0);
		}
		if (difficultyValue <= 42.0)
		{
			return (difficultyValue - 38.0) * 2.1 + DifficultyLevelMeasurement.GetMonsterPowerLevel(38.0);
		}
		if (difficultyValue <= 45.0)
		{
			return (difficultyValue - 42.0) * 1.2 + DifficultyLevelMeasurement.GetMonsterPowerLevel(42.0);
		}
		if (difficultyValue <= 50.0)
		{
			return (difficultyValue - 45.0) * 2.1 + DifficultyLevelMeasurement.GetMonsterPowerLevel(45.0);
		}
		if (difficultyValue <= 53.0)
		{
			return (difficultyValue - 50.0) * 1.0 + DifficultyLevelMeasurement.GetMonsterPowerLevel(50.0);
		}
		if (difficultyValue <= 58.0)
		{
			return (difficultyValue - 53.0) * 2.0 + DifficultyLevelMeasurement.GetMonsterPowerLevel(53.0);
		}
		if (difficultyValue <= 61.0)
		{
			return (difficultyValue - 58.0) * 1.2 + DifficultyLevelMeasurement.GetMonsterPowerLevel(58.0);
		}
		if (difficultyValue <= 66.0)
		{
			return (difficultyValue - 61.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel(61.0);
		}
		if (difficultyValue <= 69.0)
		{
			return (difficultyValue - 66.0) * 1.2 + DifficultyLevelMeasurement.GetMonsterPowerLevel(66.0);
		}
		if (difficultyValue <= 74.0)
		{
			return (difficultyValue - 69.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel(69.0);
		}
		if (difficultyValue <= 77.0)
		{
			return (difficultyValue - 74.0) * 1.0 + DifficultyLevelMeasurement.GetMonsterPowerLevel(74.0);
		}
		if (difficultyValue <= 82.0)
		{
			return (difficultyValue - 77.0) * 2.0 + DifficultyLevelMeasurement.GetMonsterPowerLevel(77.0);
		}
		if (difficultyValue <= 85.0)
		{
			return (difficultyValue - 82.0) * 1.0 + DifficultyLevelMeasurement.GetMonsterPowerLevel(82.0);
		}
		if (difficultyValue <= 100.0)
		{
			return (difficultyValue - 85.0) * 2.3 + DifficultyLevelMeasurement.GetMonsterPowerLevel(85.0);
		}
		if (difficultyValue <= 110.0)
		{
			return 20.0 + (difficultyValue - 100.0) * 2.8 + DifficultyLevelMeasurement.GetMonsterPowerLevel(100.0);
		}
		if (difficultyValue <= 120.0)
		{
			return 20.0 + (difficultyValue - 110.0) * 3.0 + DifficultyLevelMeasurement.GetMonsterPowerLevel(110.0);
		}
		if (difficultyValue <= 130.0)
		{
			return 20.0 + (difficultyValue - 120.0) * 2.8 + DifficultyLevelMeasurement.GetMonsterPowerLevel(120.0);
		}
		if (difficultyValue <= 140.0)
		{
			return 20.0 + (difficultyValue - 130.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel(130.0);
		}
		if (difficultyValue <= 150.0)
		{
			return 20.0 + (difficultyValue - 140.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel(140.0);
		}
		if (difficultyValue <= 160.0)
		{
			return 20.0 + (difficultyValue - 150.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel(150.0);
		}
		if (difficultyValue <= 170.0)
		{
			return 25.0 + (difficultyValue - 160.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel(160.0);
		}
		if (difficultyValue <= 180.0)
		{
			return 25.0 + (difficultyValue - 170.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel(170.0);
		}
		if (difficultyValue <= 190.0)
		{
			return 30.0 + (difficultyValue - 180.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel(180.0);
		}
		if (difficultyValue <= 200.0)
		{
			return 40.0 + (difficultyValue - 190.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel(190.0);
		}
		return (difficultyValue - 200.0) * 4.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel(200.0);
	}

	// Token: 0x06001EF9 RID: 7929 RVA: 0x000D9C30 File Offset: 0x000D8030
	private static double GetMonsterPowerLevel_HigherStar(double difficultyValue)
	{
		if (difficultyValue <= 6.0)
		{
			return difficultyValue * 0.6;
		}
		if (difficultyValue <= 9.0)
		{
			return (difficultyValue - 6.0) * 1.0 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(6.0);
		}
		if (difficultyValue <= 13.0)
		{
			return (difficultyValue - 9.0) * 1.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(9.0);
		}
		if (difficultyValue <= 16.0)
		{
			return (difficultyValue - 13.0) * 0.8 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(13.0);
		}
		if (difficultyValue <= 20.0)
		{
			return (difficultyValue - 16.0) * 1.8 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(16.0);
		}
		if (difficultyValue <= 23.0)
		{
			return (difficultyValue - 20.0) * 0.7 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(20.0);
		}
		if (difficultyValue <= 27.0)
		{
			return (difficultyValue - 23.0) * 1.2 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(23.0);
		}
		if (difficultyValue <= 30.0)
		{
			return (difficultyValue - 27.0) * 0.4 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(27.0);
		}
		if (difficultyValue <= 35.0)
		{
			return (difficultyValue - 30.0) * 1.1 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(30.0);
		}
		if (difficultyValue <= 38.0)
		{
			return (difficultyValue - 35.0) * 0.2 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(35.0);
		}
		if (difficultyValue <= 42.0)
		{
			return (difficultyValue - 38.0) * 0.9 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(38.0);
		}
		if (difficultyValue <= 45.0)
		{
			return (difficultyValue - 42.0) * 0.2 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(42.0);
		}
		if (difficultyValue <= 50.0)
		{
			return (difficultyValue - 45.0) * 1.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(45.0);
		}
		if (difficultyValue <= 53.0)
		{
			return (difficultyValue - 50.0) * 0.2 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(50.0);
		}
		if (difficultyValue <= 58.0)
		{
			return (difficultyValue - 53.0) * 1.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(53.0);
		}
		if (difficultyValue <= 61.0)
		{
			return (difficultyValue - 58.0) * 0.3 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(58.0);
		}
		if (difficultyValue <= 66.0)
		{
			return (difficultyValue - 61.0) * 1.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(61.0);
		}
		if (difficultyValue <= 69.0)
		{
			return (difficultyValue - 66.0) * 0.2 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(66.0);
		}
		if (difficultyValue <= 74.0)
		{
			return (difficultyValue - 69.0) * 1.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(69.0);
		}
		if (difficultyValue <= 77.0)
		{
			return (difficultyValue - 74.0) * 0.2 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(74.0);
		}
		if (difficultyValue <= 82.0)
		{
			return (difficultyValue - 77.0) * 1.3 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(77.0);
		}
		if (difficultyValue <= 85.0)
		{
			return (difficultyValue - 82.0) * 0.2 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(82.0);
		}
		if (difficultyValue <= 100.0)
		{
			return (difficultyValue - 85.0) * 1.3 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(85.0);
		}
		if (difficultyValue <= 110.0)
		{
			return 20.0 + (difficultyValue - 100.0) * 2.8 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(100.0);
		}
		if (difficultyValue <= 120.0)
		{
			return 20.0 + (difficultyValue - 110.0) * 3.0 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(110.0);
		}
		if (difficultyValue <= 130.0)
		{
			return 20.0 + (difficultyValue - 120.0) * 2.8 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(120.0);
		}
		if (difficultyValue <= 140.0)
		{
			return 20.0 + (difficultyValue - 130.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(130.0);
		}
		if (difficultyValue <= 150.0)
		{
			return 20.0 + (difficultyValue - 140.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(140.0);
		}
		if (difficultyValue <= 160.0)
		{
			return 20.0 + (difficultyValue - 150.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(150.0);
		}
		if (difficultyValue <= 170.0)
		{
			return 25.0 + (difficultyValue - 160.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(160.0);
		}
		if (difficultyValue <= 180.0)
		{
			return 25.0 + (difficultyValue - 170.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(170.0);
		}
		if (difficultyValue <= 190.0)
		{
			return 30.0 + (difficultyValue - 180.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(180.0);
		}
		if (difficultyValue <= 200.0)
		{
			return 40.0 + (difficultyValue - 190.0) * 2.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(190.0);
		}
		return (difficultyValue - 200.0) * 4.5 + DifficultyLevelMeasurement.GetMonsterPowerLevel_HigherStar(200.0);
	}

	// Token: 0x06001EFA RID: 7930 RVA: 0x000DA360 File Offset: 0x000D8760
	private static double GetMonsterPowerLevel_Endless(double difficultyValue)
	{
		return 400.0 + difficultyValue * 2.0;
	}

	// Token: 0x06001EFB RID: 7931 RVA: 0x000DA378 File Offset: 0x000D8778
	private List<int> GetCorrespondingItemTiers_Normal()
	{
		if (this.StarRating == 1)
		{
			if (this.DifficultyValue >= 0.0 && this.DifficultyValue < 5.0)
			{
				return new List<int>
				{
					1,
					2,
					3
				};
			}
			if (this.DifficultyValue >= 5.0 && this.DifficultyValue < 10.0)
			{
				return new List<int>
				{
					2,
					3,
					4,
					5
				};
			}
			if (this.DifficultyValue >= 10.0 && this.DifficultyValue < 15.0)
			{
				return new List<int>
				{
					4,
					5,
					6,
					7,
					8
				};
			}
			if (this.DifficultyValue >= 15.0 && this.DifficultyValue < 20.0)
			{
				return new List<int>
				{
					6,
					7,
					8,
					9,
					10
				};
			}
			if (this.DifficultyValue >= 20.0 && this.DifficultyValue < 25.0)
			{
				return new List<int>
				{
					8,
					9,
					10,
					11,
					12
				};
			}
			if (this.DifficultyValue >= 25.0 && this.DifficultyValue < 30.0)
			{
				return new List<int>
				{
					10,
					11,
					12,
					13,
					14
				};
			}
			if (this.DifficultyValue >= 30.0 && this.DifficultyValue < 35.0)
			{
				return new List<int>
				{
					13,
					14,
					15,
					16
				};
			}
			if (this.DifficultyValue >= 35.0 && this.DifficultyValue < 40.0)
			{
				return new List<int>
				{
					14,
					15,
					16,
					17
				};
			}
			if (this.DifficultyValue >= 40.0 && this.DifficultyValue < 45.0)
			{
				return new List<int>
				{
					16,
					17,
					18,
					19
				};
			}
			if (this.DifficultyValue >= 45.0 && this.DifficultyValue < 50.0)
			{
				return new List<int>
				{
					18,
					19,
					20,
					21
				};
			}
			if (this.DifficultyValue >= 50.0 && this.DifficultyValue < 55.0)
			{
				return new List<int>
				{
					21,
					22,
					23,
					24
				};
			}
			if (this.DifficultyValue >= 55.0 && this.DifficultyValue < 60.0)
			{
				return new List<int>
				{
					22,
					23,
					24,
					25,
					26
				};
			}
			if (this.DifficultyValue >= 60.0 && this.DifficultyValue < 65.0)
			{
				return new List<int>
				{
					26,
					27,
					28,
					29
				};
			}
			if (this.DifficultyValue >= 65.0 && this.DifficultyValue < 70.0)
			{
				return new List<int>
				{
					27,
					28,
					29,
					30
				};
			}
			if (this.DifficultyValue >= 70.0 && this.DifficultyValue < 75.0)
			{
				return new List<int>
				{
					29,
					30,
					31,
					32
				};
			}
			if (this.DifficultyValue >= 75.0 && this.DifficultyValue <= 100.0)
			{
				return new List<int>
				{
					27,
					28,
					29,
					30,
					31,
					32,
					33,
					34,
					35
				};
			}
		}
		return new List<int>();
	}

	// Token: 0x06001EFC RID: 7932 RVA: 0x000DA8CE File Offset: 0x000D8CCE
	private ResourceType GetRandomSelection(List<ResourceType> selections)
	{
		return selections[UnityEngine.Random.Range(0, selections.Count)];
	}

	// Token: 0x06001EFD RID: 7933 RVA: 0x000DA8E2 File Offset: 0x000D8CE2
	// Note: this type is marked as 'beforefieldinit'.
	static DifficultyLevelMeasurement()
	{
	}

	// Token: 0x06001EFE RID: 7934 RVA: 0x000DA900 File Offset: 0x000D8D00
	[CompilerGenerated]
	private static DropTableParameter <GenerateDropableWeapons>m__0(ResourceType s)
	{
		return new DropTableParameter
		{
			ResourceType = s,
			Presence = 100,
			Level = 1,
			InclusiveVolumTo = 1.0,
			InclusiveVolumFrom = 1.0
		};
	}

	// Token: 0x06001EFF RID: 7935 RVA: 0x000DA948 File Offset: 0x000D8D48
	[CompilerGenerated]
	private static bool <GenerateDropableWeapons>m__1(DropTableParameter a, DropTableParameter b)
	{
		return a.ResourceType == b.ResourceType;
	}

	// Token: 0x06001F00 RID: 7936 RVA: 0x000DA958 File Offset: 0x000D8D58
	[CompilerGenerated]
	private static DropTableParameter <GenerateDropableGears>m__2(ResourceType p)
	{
		return new DropTableParameter
		{
			ResourceType = p,
			Presence = 100,
			Level = 1,
			InclusiveVolumTo = 1.0,
			InclusiveVolumFrom = 1.0
		};
	}

	// Token: 0x06001F01 RID: 7937 RVA: 0x000DA9A0 File Offset: 0x000D8DA0
	[CompilerGenerated]
	private static bool <GenerateDropableGears>m__3(DropTableParameter a, DropTableParameter b)
	{
		return a.ResourceType == b.ResourceType;
	}

	// Token: 0x06001F02 RID: 7938 RVA: 0x000DA9B0 File Offset: 0x000D8DB0
	[CompilerGenerated]
	private DropTableParameter <GenerateDropableGems>m__4(ResourceType g)
	{
		return new DropTableParameter
		{
			ResourceType = g,
			Presence = 100,
			Level = this.GemTier,
			InclusiveVolumTo = 1.0,
			InclusiveVolumFrom = 1.0
		};
	}

	// Token: 0x06001F03 RID: 7939 RVA: 0x000DA9FD File Offset: 0x000D8DFD
	[CompilerGenerated]
	private static bool <GenerateDropableGems>m__5(DropTableParameter a, DropTableParameter b)
	{
		return a.ResourceType == b.ResourceType;
	}

	// Token: 0x06001F04 RID: 7940 RVA: 0x000DAA10 File Offset: 0x000D8E10
	[CompilerGenerated]
	private static ResourceUpdate <GenerateDropableGems>m__6(DropTableParameter g)
	{
		return new ResourceUpdate
		{
			ResourceType = g.ResourceType,
			ChangeAmount = 1.0,
			RelatedItems = new List<Item>
			{
				g.ResourceType.ItemGenerate(ResourceSourceType.DungeonDrop, null, 1, g.Level)
			}
		};
	}

	// Token: 0x06001F05 RID: 7941 RVA: 0x000DAA66 File Offset: 0x000D8E66
	[CompilerGenerated]
	private static UnitClass <GetPossibleMinionUnits>m__7(MonsterAppearance p)
	{
		return p.UnitClass;
	}

	// Token: 0x06001F06 RID: 7942 RVA: 0x000DAA6E File Offset: 0x000D8E6E
	[CompilerGenerated]
	private static UnitClass <GetPossibleMinibossUnits>m__8(MonsterAppearance a)
	{
		return a.UnitClass;
	}

	// Token: 0x06001F07 RID: 7943 RVA: 0x000DAA76 File Offset: 0x000D8E76
	[CompilerGenerated]
	private static UnitClass <GetPossibleBossUnits>m__9(MonsterAppearance a)
	{
		return a.UnitClass;
	}

	// Token: 0x06001F08 RID: 7944 RVA: 0x000DAA7E File Offset: 0x000D8E7E
	[CompilerGenerated]
	private bool <GetPossibleAdventureTypes>m__A(LevelConfigurationBase c)
	{
		return c.StartingDifficultyLevel <= this.DifficultyValue;
	}

	// Token: 0x06001F09 RID: 7945 RVA: 0x000DAA91 File Offset: 0x000D8E91
	[CompilerGenerated]
	private static AdventureType <GetPossibleAdventureTypes>m__B(LevelConfigurationBase a)
	{
		return a.CorrespondingAdventureType;
	}

	// Token: 0x06001F0A RID: 7946 RVA: 0x000DAA99 File Offset: 0x000D8E99
	[CompilerGenerated]
	private DropTableParameter <GetStandardDropableCompleteTable>m__C(ResourceType r)
	{
		return this.GetDefaultDropParameter(r, 1);
	}

	// Token: 0x06001F0B RID: 7947 RVA: 0x000DAAA3 File Offset: 0x000D8EA3
	[CompilerGenerated]
	private DropTableParameter <GetStandardDropableCompleteTable>m__D(ResourceType r)
	{
		return this.GetDefaultDropParameter(r, 1);
	}

	// Token: 0x06001F0C RID: 7948 RVA: 0x000DAAAD File Offset: 0x000D8EAD
	[CompilerGenerated]
	private DropTableParameter <GetStandardDropableCompleteTable>m__E(ResourceType r)
	{
		return this.GetDefaultDropParameter(r, 1);
	}

	// Token: 0x06001F0D RID: 7949 RVA: 0x000DAAB7 File Offset: 0x000D8EB7
	[CompilerGenerated]
	private DropTableParameter <GetStandardDropableCompleteTable>m__F(ResourceType a)
	{
		return this.GetDefaultDropParameter(a, 1);
	}

	// Token: 0x06001F0E RID: 7950 RVA: 0x000DAAC1 File Offset: 0x000D8EC1
	[CompilerGenerated]
	private static ResourceType <GetDifficultyRelatedWeaponRecipes>m__10(ResourceType w)
	{
		return w.GetCreationTemplate().GetRecipe().RecipeName;
	}

	// Token: 0x06001F0F RID: 7951 RVA: 0x000DAAD3 File Offset: 0x000D8ED3
	[CompilerGenerated]
	private static ResourceType <GetDifficultyRelatedWeaponRecipes>m__11(ResourceType w)
	{
		return w.GetCreationTemplate().GetRecipe().RecipeName;
	}

	// Token: 0x06001F10 RID: 7952 RVA: 0x000DAAE5 File Offset: 0x000D8EE5
	[CompilerGenerated]
	private static int <GetDropableEquipmentItemTierLevel>m__12(int n)
	{
		return n;
	}

	// Token: 0x06001F11 RID: 7953 RVA: 0x000DAAE8 File Offset: 0x000D8EE8
	[CompilerGenerated]
	private static ResourceType <GetDifficultyRelatedArmorRecipes>m__13(ResourceType w)
	{
		return w.GetCreationTemplate().GetRecipe().RecipeName;
	}

	// Token: 0x06001F12 RID: 7954 RVA: 0x000DAAFA File Offset: 0x000D8EFA
	[CompilerGenerated]
	private static ResourceType <GetDifficultyRelatedArmorRecipes>m__14(ResourceType w)
	{
		return w.GetCreationTemplate().GetRecipe().RecipeName;
	}

	// Token: 0x06001F13 RID: 7955 RVA: 0x000DAB0C File Offset: 0x000D8F0C
	[CompilerGenerated]
	private static DropTableParameter <GenerateAccessories>m__15(ResourceType t)
	{
		return new DropTableParameter
		{
			ResourceType = t,
			Presence = 100,
			Level = 1,
			InclusiveVolumTo = 1.0,
			InclusiveVolumFrom = 1.0
		};
	}

	// Token: 0x06001F14 RID: 7956 RVA: 0x000DAB54 File Offset: 0x000D8F54
	[CompilerGenerated]
	private bool <GenerateAccessories>m__16(DropTableParameter p)
	{
		return p.ResourceType.GetCreationTemplate() is AccessoryTemplateBase && (p.ResourceType.GetCreationTemplate() as AccessoryTemplateBase).GenerateStarEffects(QualityGrade.Ancient, this.GetCorrespondingItemTierLevel(p.ResourceType)).Any<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001F15 RID: 7957 RVA: 0x000DABA0 File Offset: 0x000D8FA0
	[CompilerGenerated]
	private static bool <GenerateAccessories>m__17(DropTableParameter a, DropTableParameter b)
	{
		return a.ResourceType == b.ResourceType;
	}

	// Token: 0x06001F16 RID: 7958 RVA: 0x000DABB0 File Offset: 0x000D8FB0
	[CompilerGenerated]
	private static ResidentBase <ResidentCandidates>m__18(KeyValuePair<ResidentType, ResidentBase> v)
	{
		return v.Value;
	}

	// Token: 0x06001F17 RID: 7959 RVA: 0x000DABB9 File Offset: 0x000D8FB9
	[CompilerGenerated]
	private bool <ResidentCandidates>m__19(ResidentBase v)
	{
		return (double)v.ResidentRankParameter <= this.DifficultyValue || this.StarRating > 1 || this.StarRating == -1;
	}

	// Token: 0x06001F18 RID: 7960 RVA: 0x000DABE5 File Offset: 0x000D8FE5
	[CompilerGenerated]
	private static ResidentType <ResidentCandidates>m__1A(ResidentBase v)
	{
		return v.ResidentType;
	}

	// Token: 0x06001F19 RID: 7961 RVA: 0x000DABED File Offset: 0x000D8FED
	[CompilerGenerated]
	private static bool <GetDifficultyRelevantWeapons>m__1B(ResourceType r)
	{
		return r.GetResourceCategory().IsWeapon();
	}

	// Token: 0x06001F1A RID: 7962 RVA: 0x000DABFA File Offset: 0x000D8FFA
	[CompilerGenerated]
	private static bool <GetDifficultyRelevantWeapons>m__1C(ResourceType r)
	{
		return r.GetResourceCategory().IsWeapon();
	}

	// Token: 0x06001F1B RID: 7963 RVA: 0x000DAC07 File Offset: 0x000D9007
	[CompilerGenerated]
	private static bool <GetDifficultyRelevantArmors>m__1D(ResourceType r)
	{
		return r.GetResourceCategory().IsArmor();
	}

	// Token: 0x06001F1C RID: 7964 RVA: 0x000DAC14 File Offset: 0x000D9014
	[CompilerGenerated]
	private static bool <GetDifficultyRelevantArmors>m__1E(ResourceType r)
	{
		return r.GetResourceCategory().IsArmor();
	}

	// Token: 0x04001C1C RID: 7196
	public static double DefaultDifficultyGapPerDungeonLevelIncrement = 1.0;

	// Token: 0x04001C1D RID: 7197
	public static double DifficultyLevelToIndicatorCoefficient = 10.0;

	// Token: 0x04001C1E RID: 7198
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <DifficultyValue>k__BackingField;

	// Token: 0x04001C1F RID: 7199
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <DifficultyTier>k__BackingField;

	// Token: 0x04001C20 RID: 7200
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <TierPowerness>k__BackingField;

	// Token: 0x04001C21 RID: 7201
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <GemTier>k__BackingField;

	// Token: 0x04001C22 RID: 7202
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <CorrespondingReputation>k__BackingField;

	// Token: 0x04001C23 RID: 7203
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <MosnterPowerLevel>k__BackingField;

	// Token: 0x04001C24 RID: 7204
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <MonsterSkillLevel>k__BackingField;

	// Token: 0x04001C25 RID: 7205
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <StarRating>k__BackingField;

	// Token: 0x04001C26 RID: 7206
	[CompilerGenerated]
	private static Func<ResourceType, DropTableParameter> <>f__am$cache0;

	// Token: 0x04001C27 RID: 7207
	[CompilerGenerated]
	private static Func<DropTableParameter, DropTableParameter, bool> <>f__am$cache1;

	// Token: 0x04001C28 RID: 7208
	[CompilerGenerated]
	private static Func<ResourceType, DropTableParameter> <>f__am$cache2;

	// Token: 0x04001C29 RID: 7209
	[CompilerGenerated]
	private static Func<DropTableParameter, DropTableParameter, bool> <>f__am$cache3;

	// Token: 0x04001C2A RID: 7210
	[CompilerGenerated]
	private static Func<DropTableParameter, DropTableParameter, bool> <>f__am$cache4;

	// Token: 0x04001C2B RID: 7211
	[CompilerGenerated]
	private static Func<DropTableParameter, ResourceUpdate> <>f__am$cache5;

	// Token: 0x04001C2C RID: 7212
	[CompilerGenerated]
	private static Func<MonsterAppearance, UnitClass> <>f__am$cache6;

	// Token: 0x04001C2D RID: 7213
	[CompilerGenerated]
	private static Func<MonsterAppearance, UnitClass> <>f__am$cache7;

	// Token: 0x04001C2E RID: 7214
	[CompilerGenerated]
	private static Func<MonsterAppearance, UnitClass> <>f__am$cache8;

	// Token: 0x04001C2F RID: 7215
	[CompilerGenerated]
	private static Func<LevelConfigurationBase, AdventureType> <>f__am$cache9;

	// Token: 0x04001C30 RID: 7216
	[CompilerGenerated]
	private static Func<ResourceType, ResourceType> <>f__am$cacheA;

	// Token: 0x04001C31 RID: 7217
	[CompilerGenerated]
	private static Func<ResourceType, ResourceType> <>f__am$cacheB;

	// Token: 0x04001C32 RID: 7218
	[CompilerGenerated]
	private static Func<int, int> <>f__am$cacheC;

	// Token: 0x04001C33 RID: 7219
	[CompilerGenerated]
	private static Func<ResourceType, ResourceType> <>f__am$cacheD;

	// Token: 0x04001C34 RID: 7220
	[CompilerGenerated]
	private static Func<ResourceType, ResourceType> <>f__am$cacheE;

	// Token: 0x04001C35 RID: 7221
	[CompilerGenerated]
	private static Func<ResourceType, DropTableParameter> <>f__am$cacheF;

	// Token: 0x04001C36 RID: 7222
	[CompilerGenerated]
	private static Func<DropTableParameter, DropTableParameter, bool> <>f__am$cache10;

	// Token: 0x04001C37 RID: 7223
	[CompilerGenerated]
	private static Func<KeyValuePair<ResidentType, ResidentBase>, ResidentBase> <>f__am$cache11;

	// Token: 0x04001C38 RID: 7224
	[CompilerGenerated]
	private static Func<ResidentBase, ResidentType> <>f__am$cache12;

	// Token: 0x04001C39 RID: 7225
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache13;

	// Token: 0x04001C3A RID: 7226
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache14;

	// Token: 0x04001C3B RID: 7227
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache15;

	// Token: 0x04001C3C RID: 7228
	[CompilerGenerated]
	private static Func<ResourceType, bool> <>f__am$cache16;

	// Token: 0x02000CEF RID: 3311
	[CompilerGenerated]
	private sealed class <GenerateDropableWeapons>c__AnonStorey0
	{
		// Token: 0x06005597 RID: 21911 RVA: 0x000DAC21 File Offset: 0x000D9021
		public <GenerateDropableWeapons>c__AnonStorey0()
		{
		}

		// Token: 0x06005598 RID: 21912 RVA: 0x000DAC2C File Offset: 0x000D902C
		internal ResourceUpdate <>m__0(DropTableParameter i)
		{
			ResourceUpdate resourceUpdate = new ResourceUpdate();
			resourceUpdate.ResourceType = i.ResourceType;
			resourceUpdate.ChangeAmount = 1.0;
			ResourceUpdate resourceUpdate2 = resourceUpdate;
			List<Item> list = new List<Item>();
			List<Item> list2 = list;
			ResourceType resourceType = i.ResourceType;
			ResourceSourceType itemSource = ResourceSourceType.DungeonDrop;
			int correspondingItemTierLevel = this.$this.GetCorrespondingItemTierLevel(i.ResourceType);
			list2.Add(resourceType.ItemGenerate(itemSource, this.$this.GetQualityConfig(new QualityGrade?(this.grade), ResourceSourceType.DungeonDrop, i.ResourceType, this.forceStar), correspondingItemTierLevel, 1));
			resourceUpdate2.RelatedItems = list;
			return resourceUpdate;
		}

		// Token: 0x0400442D RID: 17453
		internal QualityGrade grade;

		// Token: 0x0400442E RID: 17454
		internal bool forceStar;

		// Token: 0x0400442F RID: 17455
		internal DifficultyLevelMeasurement $this;
	}

	// Token: 0x02000CF0 RID: 3312
	[CompilerGenerated]
	private sealed class <GenerateDropableGears>c__AnonStorey1
	{
		// Token: 0x06005599 RID: 21913 RVA: 0x000DACB7 File Offset: 0x000D90B7
		public <GenerateDropableGears>c__AnonStorey1()
		{
		}

		// Token: 0x0600559A RID: 21914 RVA: 0x000DACC0 File Offset: 0x000D90C0
		internal ResourceUpdate <>m__0(DropTableParameter i)
		{
			ResourceUpdate resourceUpdate = new ResourceUpdate();
			resourceUpdate.ResourceType = i.ResourceType;
			resourceUpdate.ChangeAmount = 1.0;
			ResourceUpdate resourceUpdate2 = resourceUpdate;
			List<Item> list = new List<Item>();
			List<Item> list2 = list;
			ResourceType resourceType = i.ResourceType;
			ResourceSourceType itemSource = ResourceSourceType.DungeonDrop;
			int correspondingItemTierLevel = this.$this.GetCorrespondingItemTierLevel(i.ResourceType);
			list2.Add(resourceType.ItemGenerate(itemSource, this.$this.GetQualityConfig(this.determined, ResourceSourceType.DungeonDrop, i.ResourceType, this.forceStar), correspondingItemTierLevel, 1));
			resourceUpdate2.RelatedItems = list;
			return resourceUpdate;
		}

		// Token: 0x04004430 RID: 17456
		internal QualityGrade? determined;

		// Token: 0x04004431 RID: 17457
		internal bool forceStar;

		// Token: 0x04004432 RID: 17458
		internal DifficultyLevelMeasurement $this;
	}

	// Token: 0x02000CF1 RID: 3313
	[CompilerGenerated]
	private sealed class <GetDifficultyRelatedWeaponRecipes>c__AnonStorey2
	{
		// Token: 0x0600559B RID: 21915 RVA: 0x000DAD46 File Offset: 0x000D9146
		public <GetDifficultyRelatedWeaponRecipes>c__AnonStorey2()
		{
		}

		// Token: 0x0600559C RID: 21916 RVA: 0x000DAD4E File Offset: 0x000D914E
		internal bool <>m__0(ResourceType r)
		{
			return r.GetResourceCategory().IsWeapon() && r.HasCreationTemplate() && r.GetCreationTemplate().RecipeSourceTypes.Any((ResourceSourceType t) => this.sourceTypes.Any((ResourceSourceType ss) => ss == t));
		}

		// Token: 0x0600559D RID: 21917 RVA: 0x000DAD8C File Offset: 0x000D918C
		internal bool <>m__1(ResourceSourceType t)
		{
			return this.sourceTypes.Any((ResourceSourceType ss) => ss == t);
		}

		// Token: 0x04004433 RID: 17459
		internal List<ResourceSourceType> sourceTypes;

		// Token: 0x04004434 RID: 17460
		internal DifficultyLevelMeasurement $this;

		// Token: 0x02000CFB RID: 3323
		private sealed class <GetDifficultyRelatedWeaponRecipes>c__AnonStorey3
		{
			// Token: 0x060055BA RID: 21946 RVA: 0x000DADC4 File Offset: 0x000D91C4
			public <GetDifficultyRelatedWeaponRecipes>c__AnonStorey3()
			{
			}

			// Token: 0x060055BB RID: 21947 RVA: 0x000DADCC File Offset: 0x000D91CC
			internal bool <>m__0(ResourceSourceType ss)
			{
				return ss == this.t;
			}

			// Token: 0x04004447 RID: 17479
			internal ResourceSourceType t;

			// Token: 0x04004448 RID: 17480
			internal DifficultyLevelMeasurement.<GetDifficultyRelatedWeaponRecipes>c__AnonStorey2 <>f__ref$2;
		}
	}

	// Token: 0x02000CF2 RID: 3314
	[CompilerGenerated]
	private sealed class <GetDifficultyRelatedWeaponRecipes>c__AnonStorey5
	{
		// Token: 0x0600559E RID: 21918 RVA: 0x000DADD7 File Offset: 0x000D91D7
		public <GetDifficultyRelatedWeaponRecipes>c__AnonStorey5()
		{
		}

		// Token: 0x0600559F RID: 21919 RVA: 0x000DADDF File Offset: 0x000D91DF
		internal bool <>m__0(ResourceType r)
		{
			return r.GetResourceCategory().IsWeapon() && r.HasCreationTemplate() && r.GetCreationTemplate().RecipeSourceTypes.Any(delegate(ResourceSourceType t)
			{
				DifficultyLevelMeasurement.<GetDifficultyRelatedWeaponRecipes>c__AnonStorey2 <>f__ref$2 = this.<>f__ref$2;
				ResourceSourceType t = t;
				return this.<>f__ref$2.sourceTypes.Any((ResourceSourceType ss) => ss == t);
			});
		}

		// Token: 0x060055A0 RID: 21920 RVA: 0x000DAE1C File Offset: 0x000D921C
		internal bool <>m__1(ResourceType w)
		{
			DifficultyLevelMeasurement.<GetDifficultyRelatedWeaponRecipes>c__AnonStorey2 <>f__ref$2 = this.<>f__ref$2;
			DifficultyLevelMeasurement.<GetDifficultyRelatedWeaponRecipes>c__AnonStorey5 <>f__ref$5 = this;
			ResourceType w = w2;
			return this.itemLevels.Any((int l) => l == <>f__ref$2.$this.GetCorrespondingItemTierLevel(w));
		}

		// Token: 0x060055A1 RID: 21921 RVA: 0x000DAE60 File Offset: 0x000D9260
		internal bool <>m__2(ResourceSourceType t)
		{
			DifficultyLevelMeasurement.<GetDifficultyRelatedWeaponRecipes>c__AnonStorey2 <>f__ref$2 = this.<>f__ref$2;
			ResourceSourceType t = t2;
			return this.<>f__ref$2.sourceTypes.Any((ResourceSourceType ss) => ss == t);
		}

		// Token: 0x04004435 RID: 17461
		internal List<int> itemLevels;

		// Token: 0x04004436 RID: 17462
		internal DifficultyLevelMeasurement.<GetDifficultyRelatedWeaponRecipes>c__AnonStorey2 <>f__ref$2;

		// Token: 0x02000CFC RID: 3324
		private sealed class <GetDifficultyRelatedWeaponRecipes>c__AnonStorey6
		{
			// Token: 0x060055BC RID: 21948 RVA: 0x000DAEA2 File Offset: 0x000D92A2
			public <GetDifficultyRelatedWeaponRecipes>c__AnonStorey6()
			{
			}

			// Token: 0x060055BD RID: 21949 RVA: 0x000DAEAA File Offset: 0x000D92AA
			internal bool <>m__0(int l)
			{
				return l == this.<>f__ref$2.$this.GetCorrespondingItemTierLevel(this.w);
			}

			// Token: 0x04004449 RID: 17481
			internal ResourceType w;

			// Token: 0x0400444A RID: 17482
			internal DifficultyLevelMeasurement.<GetDifficultyRelatedWeaponRecipes>c__AnonStorey2 <>f__ref$2;

			// Token: 0x0400444B RID: 17483
			internal DifficultyLevelMeasurement.<GetDifficultyRelatedWeaponRecipes>c__AnonStorey5 <>f__ref$5;
		}

		// Token: 0x02000CFD RID: 3325
		private sealed class <GetDifficultyRelatedWeaponRecipes>c__AnonStorey4
		{
			// Token: 0x060055BE RID: 21950 RVA: 0x000DAEC5 File Offset: 0x000D92C5
			public <GetDifficultyRelatedWeaponRecipes>c__AnonStorey4()
			{
			}

			// Token: 0x060055BF RID: 21951 RVA: 0x000DAECD File Offset: 0x000D92CD
			internal bool <>m__0(ResourceSourceType ss)
			{
				return ss == this.t;
			}

			// Token: 0x0400444C RID: 17484
			internal ResourceSourceType t;

			// Token: 0x0400444D RID: 17485
			internal DifficultyLevelMeasurement.<GetDifficultyRelatedWeaponRecipes>c__AnonStorey2 <>f__ref$2;
		}
	}

	// Token: 0x02000CF3 RID: 3315
	[CompilerGenerated]
	private sealed class <GetDifficultyRelatedArmorRecipes>c__AnonStorey7
	{
		// Token: 0x060055A2 RID: 21922 RVA: 0x000DAED8 File Offset: 0x000D92D8
		public <GetDifficultyRelatedArmorRecipes>c__AnonStorey7()
		{
		}

		// Token: 0x060055A3 RID: 21923 RVA: 0x000DAEE0 File Offset: 0x000D92E0
		internal bool <>m__0(ResourceType r)
		{
			return r.GetResourceCategory().IsArmor() && r.HasCreationTemplate() && r.GetCreationTemplate().RecipeSourceTypes.Any((ResourceSourceType t) => this.sourceTypes.Any((ResourceSourceType ss) => ss == t));
		}

		// Token: 0x060055A4 RID: 21924 RVA: 0x000DAF1C File Offset: 0x000D931C
		internal bool <>m__1(ResourceSourceType t)
		{
			return this.sourceTypes.Any((ResourceSourceType ss) => ss == t);
		}

		// Token: 0x04004437 RID: 17463
		internal List<ResourceSourceType> sourceTypes;

		// Token: 0x04004438 RID: 17464
		internal DifficultyLevelMeasurement $this;

		// Token: 0x02000CFE RID: 3326
		private sealed class <GetDifficultyRelatedArmorRecipes>c__AnonStorey8
		{
			// Token: 0x060055C0 RID: 21952 RVA: 0x000DAF54 File Offset: 0x000D9354
			public <GetDifficultyRelatedArmorRecipes>c__AnonStorey8()
			{
			}

			// Token: 0x060055C1 RID: 21953 RVA: 0x000DAF5C File Offset: 0x000D935C
			internal bool <>m__0(ResourceSourceType ss)
			{
				return ss == this.t;
			}

			// Token: 0x0400444E RID: 17486
			internal ResourceSourceType t;

			// Token: 0x0400444F RID: 17487
			internal DifficultyLevelMeasurement.<GetDifficultyRelatedArmorRecipes>c__AnonStorey7 <>f__ref$7;
		}
	}

	// Token: 0x02000CF4 RID: 3316
	[CompilerGenerated]
	private sealed class <GetDifficultyRelatedArmorRecipes>c__AnonStoreyA
	{
		// Token: 0x060055A5 RID: 21925 RVA: 0x000DAF67 File Offset: 0x000D9367
		public <GetDifficultyRelatedArmorRecipes>c__AnonStoreyA()
		{
		}

		// Token: 0x060055A6 RID: 21926 RVA: 0x000DAF6F File Offset: 0x000D936F
		internal bool <>m__0(ResourceType r)
		{
			return r.GetResourceCategory().IsArmor() && r.HasCreationTemplate() && r.GetCreationTemplate().RecipeSourceTypes.Any(delegate(ResourceSourceType t)
			{
				DifficultyLevelMeasurement.<GetDifficultyRelatedArmorRecipes>c__AnonStorey7 <>f__ref$7 = this.<>f__ref$7;
				ResourceSourceType t = t;
				return this.<>f__ref$7.sourceTypes.Any((ResourceSourceType ss) => ss == t);
			});
		}

		// Token: 0x060055A7 RID: 21927 RVA: 0x000DAFAC File Offset: 0x000D93AC
		internal bool <>m__1(ResourceType w)
		{
			DifficultyLevelMeasurement.<GetDifficultyRelatedArmorRecipes>c__AnonStorey7 <>f__ref$7 = this.<>f__ref$7;
			DifficultyLevelMeasurement.<GetDifficultyRelatedArmorRecipes>c__AnonStoreyA <>f__ref$10 = this;
			ResourceType w = w2;
			return this.itemLevels.Any((int l) => l == <>f__ref$7.$this.GetCorrespondingItemTierLevel(w));
		}

		// Token: 0x060055A8 RID: 21928 RVA: 0x000DAFF0 File Offset: 0x000D93F0
		internal bool <>m__2(ResourceSourceType t)
		{
			DifficultyLevelMeasurement.<GetDifficultyRelatedArmorRecipes>c__AnonStorey7 <>f__ref$7 = this.<>f__ref$7;
			ResourceSourceType t = t2;
			return this.<>f__ref$7.sourceTypes.Any((ResourceSourceType ss) => ss == t);
		}

		// Token: 0x04004439 RID: 17465
		internal List<int> itemLevels;

		// Token: 0x0400443A RID: 17466
		internal DifficultyLevelMeasurement.<GetDifficultyRelatedArmorRecipes>c__AnonStorey7 <>f__ref$7;

		// Token: 0x02000CFF RID: 3327
		private sealed class <GetDifficultyRelatedArmorRecipes>c__AnonStoreyB
		{
			// Token: 0x060055C2 RID: 21954 RVA: 0x000DB032 File Offset: 0x000D9432
			public <GetDifficultyRelatedArmorRecipes>c__AnonStoreyB()
			{
			}

			// Token: 0x060055C3 RID: 21955 RVA: 0x000DB03A File Offset: 0x000D943A
			internal bool <>m__0(int l)
			{
				return l == this.<>f__ref$7.$this.GetCorrespondingItemTierLevel(this.w);
			}

			// Token: 0x04004450 RID: 17488
			internal ResourceType w;

			// Token: 0x04004451 RID: 17489
			internal DifficultyLevelMeasurement.<GetDifficultyRelatedArmorRecipes>c__AnonStorey7 <>f__ref$7;

			// Token: 0x04004452 RID: 17490
			internal DifficultyLevelMeasurement.<GetDifficultyRelatedArmorRecipes>c__AnonStoreyA <>f__ref$10;
		}

		// Token: 0x02000D00 RID: 3328
		private sealed class <GetDifficultyRelatedArmorRecipes>c__AnonStorey9
		{
			// Token: 0x060055C4 RID: 21956 RVA: 0x000DB055 File Offset: 0x000D9455
			public <GetDifficultyRelatedArmorRecipes>c__AnonStorey9()
			{
			}

			// Token: 0x060055C5 RID: 21957 RVA: 0x000DB05D File Offset: 0x000D945D
			internal bool <>m__0(ResourceSourceType ss)
			{
				return ss == this.t;
			}

			// Token: 0x04004453 RID: 17491
			internal ResourceSourceType t;

			// Token: 0x04004454 RID: 17492
			internal DifficultyLevelMeasurement.<GetDifficultyRelatedArmorRecipes>c__AnonStorey7 <>f__ref$7;
		}
	}

	// Token: 0x02000CF5 RID: 3317
	[CompilerGenerated]
	private sealed class <GetDifficultyRelatedGears>c__AnonStoreyC
	{
		// Token: 0x060055A9 RID: 21929 RVA: 0x000DB068 File Offset: 0x000D9468
		public <GetDifficultyRelatedGears>c__AnonStoreyC()
		{
		}

		// Token: 0x060055AA RID: 21930 RVA: 0x000DB070 File Offset: 0x000D9470
		internal bool <>m__0(ResourceType r)
		{
			return (r.GetResourceCategory().IsWeapon() || r.GetResourceCategory().IsArmor()) && r.HasCreationTemplate() && r.GetCreationTemplate().ItemSourceTypes.Any((ResourceSourceType t) => this.sourceTypes.Any((ResourceSourceType ss) => ss == t));
		}

		// Token: 0x060055AB RID: 21931 RVA: 0x000DB0C8 File Offset: 0x000D94C8
		internal bool <>m__1(ResourceSourceType t)
		{
			return this.sourceTypes.Any((ResourceSourceType ss) => ss == t);
		}

		// Token: 0x0400443B RID: 17467
		internal List<ResourceSourceType> sourceTypes;

		// Token: 0x0400443C RID: 17468
		internal DifficultyLevelMeasurement $this;

		// Token: 0x02000D01 RID: 3329
		private sealed class <GetDifficultyRelatedGears>c__AnonStorey10
		{
			// Token: 0x060055C6 RID: 21958 RVA: 0x000DB100 File Offset: 0x000D9500
			public <GetDifficultyRelatedGears>c__AnonStorey10()
			{
			}

			// Token: 0x060055C7 RID: 21959 RVA: 0x000DB108 File Offset: 0x000D9508
			internal bool <>m__0(ResourceSourceType ss)
			{
				return ss == this.t;
			}

			// Token: 0x04004455 RID: 17493
			internal ResourceSourceType t;

			// Token: 0x04004456 RID: 17494
			internal DifficultyLevelMeasurement.<GetDifficultyRelatedGears>c__AnonStoreyC <>f__ref$12;
		}
	}

	// Token: 0x02000CF6 RID: 3318
	[CompilerGenerated]
	private sealed class <GetDifficultyRelatedGears>c__AnonStoreyE
	{
		// Token: 0x060055AC RID: 21932 RVA: 0x000DB113 File Offset: 0x000D9513
		public <GetDifficultyRelatedGears>c__AnonStoreyE()
		{
		}

		// Token: 0x060055AD RID: 21933 RVA: 0x000DB11C File Offset: 0x000D951C
		internal bool <>m__0(ResourceType r)
		{
			return (r.GetResourceCategory().IsWeapon() || r.GetResourceCategory().IsArmor()) && r.HasCreationTemplate() && r.GetCreationTemplate().ItemSourceTypes.Any(delegate(ResourceSourceType t)
			{
				DifficultyLevelMeasurement.<GetDifficultyRelatedGears>c__AnonStoreyC <>f__ref$12 = this.<>f__ref$12;
				ResourceSourceType t = t;
				return this.<>f__ref$12.sourceTypes.Any((ResourceSourceType ss) => ss == t);
			});
		}

		// Token: 0x060055AE RID: 21934 RVA: 0x000DB174 File Offset: 0x000D9574
		internal bool <>m__1(ResourceType w)
		{
			DifficultyLevelMeasurement.<GetDifficultyRelatedGears>c__AnonStoreyC <>f__ref$12 = this.<>f__ref$12;
			DifficultyLevelMeasurement.<GetDifficultyRelatedGears>c__AnonStoreyE <>f__ref$14 = this;
			ResourceType w = w2;
			return this.itemLevels.Any((int l) => l == <>f__ref$12.$this.GetCorrespondingItemTierLevel(w));
		}

		// Token: 0x060055AF RID: 21935 RVA: 0x000DB1B8 File Offset: 0x000D95B8
		internal bool <>m__2(ResourceSourceType t)
		{
			DifficultyLevelMeasurement.<GetDifficultyRelatedGears>c__AnonStoreyC <>f__ref$12 = this.<>f__ref$12;
			ResourceSourceType t = t2;
			return this.<>f__ref$12.sourceTypes.Any((ResourceSourceType ss) => ss == t);
		}

		// Token: 0x0400443D RID: 17469
		internal List<int> itemLevels;

		// Token: 0x0400443E RID: 17470
		internal DifficultyLevelMeasurement.<GetDifficultyRelatedGears>c__AnonStoreyC <>f__ref$12;

		// Token: 0x02000D02 RID: 3330
		private sealed class <GetDifficultyRelatedGears>c__AnonStoreyF
		{
			// Token: 0x060055C8 RID: 21960 RVA: 0x000DB1FA File Offset: 0x000D95FA
			public <GetDifficultyRelatedGears>c__AnonStoreyF()
			{
			}

			// Token: 0x060055C9 RID: 21961 RVA: 0x000DB202 File Offset: 0x000D9602
			internal bool <>m__0(int l)
			{
				return l == this.<>f__ref$12.$this.GetCorrespondingItemTierLevel(this.w);
			}

			// Token: 0x04004457 RID: 17495
			internal ResourceType w;

			// Token: 0x04004458 RID: 17496
			internal DifficultyLevelMeasurement.<GetDifficultyRelatedGears>c__AnonStoreyC <>f__ref$12;

			// Token: 0x04004459 RID: 17497
			internal DifficultyLevelMeasurement.<GetDifficultyRelatedGears>c__AnonStoreyE <>f__ref$14;
		}

		// Token: 0x02000D03 RID: 3331
		private sealed class <GetDifficultyRelatedGears>c__AnonStoreyD
		{
			// Token: 0x060055CA RID: 21962 RVA: 0x000DB21D File Offset: 0x000D961D
			public <GetDifficultyRelatedGears>c__AnonStoreyD()
			{
			}

			// Token: 0x060055CB RID: 21963 RVA: 0x000DB225 File Offset: 0x000D9625
			internal bool <>m__0(ResourceSourceType ss)
			{
				return ss == this.t;
			}

			// Token: 0x0400445A RID: 17498
			internal ResourceSourceType t;

			// Token: 0x0400445B RID: 17499
			internal DifficultyLevelMeasurement.<GetDifficultyRelatedGears>c__AnonStoreyC <>f__ref$12;
		}
	}

	// Token: 0x02000CF7 RID: 3319
	[CompilerGenerated]
	private sealed class <GetDifficultyRelevantWeapons>c__AnonStorey13
	{
		// Token: 0x060055B0 RID: 21936 RVA: 0x000DB230 File Offset: 0x000D9630
		public <GetDifficultyRelevantWeapons>c__AnonStorey13()
		{
		}

		// Token: 0x060055B1 RID: 21937 RVA: 0x000DB238 File Offset: 0x000D9638
		internal bool <>m__0(ResourceType w)
		{
			return w.HasCreationTemplate() && w.GetCreationTemplate().ItemSourceTypes.Any((ResourceSourceType t) => this.sourceTypes.Any((ResourceSourceType ss) => ss == t));
		}

		// Token: 0x060055B2 RID: 21938 RVA: 0x000DB264 File Offset: 0x000D9664
		internal bool <>m__1(ResourceSourceType t)
		{
			return this.sourceTypes.Any((ResourceSourceType ss) => ss == t);
		}

		// Token: 0x0400443F RID: 17471
		internal List<ResourceSourceType> sourceTypes;

		// Token: 0x04004440 RID: 17472
		internal DifficultyLevelMeasurement $this;

		// Token: 0x02000D04 RID: 3332
		private sealed class <GetDifficultyRelevantWeapons>c__AnonStorey15
		{
			// Token: 0x060055CC RID: 21964 RVA: 0x000DB29C File Offset: 0x000D969C
			public <GetDifficultyRelevantWeapons>c__AnonStorey15()
			{
			}

			// Token: 0x060055CD RID: 21965 RVA: 0x000DB2A4 File Offset: 0x000D96A4
			internal bool <>m__0(ResourceSourceType ss)
			{
				return ss == this.t;
			}

			// Token: 0x0400445C RID: 17500
			internal ResourceSourceType t;

			// Token: 0x0400445D RID: 17501
			internal DifficultyLevelMeasurement.<GetDifficultyRelevantWeapons>c__AnonStorey13 <>f__ref$19;
		}
	}

	// Token: 0x02000CF8 RID: 3320
	[CompilerGenerated]
	private sealed class <GetDifficultyRelevantWeapons>c__AnonStorey11
	{
		// Token: 0x060055B3 RID: 21939 RVA: 0x000DB2AF File Offset: 0x000D96AF
		public <GetDifficultyRelevantWeapons>c__AnonStorey11()
		{
		}

		// Token: 0x060055B4 RID: 21940 RVA: 0x000DB2B8 File Offset: 0x000D96B8
		internal bool <>m__0(ResourceType w)
		{
			DifficultyLevelMeasurement.<GetDifficultyRelevantWeapons>c__AnonStorey13 <>f__ref$19 = this.<>f__ref$19;
			DifficultyLevelMeasurement.<GetDifficultyRelevantWeapons>c__AnonStorey11 <>f__ref$17 = this;
			ResourceType w = w2;
			return this.itemLevels.Any((int l) => l == <>f__ref$19.$this.GetCorrespondingItemTierLevel(w)) && w.HasCreationTemplate() && w.GetCreationTemplate().ItemSourceTypes.Any(delegate(ResourceSourceType t)
			{
				DifficultyLevelMeasurement.<GetDifficultyRelevantWeapons>c__AnonStorey13 <>f__ref$19 = <>f__ref$19;
				ResourceSourceType t = t;
				return <>f__ref$19.sourceTypes.Any((ResourceSourceType ss) => ss == t);
			});
		}

		// Token: 0x04004441 RID: 17473
		internal List<int> itemLevels;

		// Token: 0x04004442 RID: 17474
		internal DifficultyLevelMeasurement.<GetDifficultyRelevantWeapons>c__AnonStorey13 <>f__ref$19;

		// Token: 0x02000D05 RID: 3333
		private sealed class <GetDifficultyRelevantWeapons>c__AnonStorey12
		{
			// Token: 0x060055CE RID: 21966 RVA: 0x000DB335 File Offset: 0x000D9735
			public <GetDifficultyRelevantWeapons>c__AnonStorey12()
			{
			}

			// Token: 0x060055CF RID: 21967 RVA: 0x000DB33D File Offset: 0x000D973D
			internal bool <>m__0(int l)
			{
				return l == this.<>f__ref$19.$this.GetCorrespondingItemTierLevel(this.w);
			}

			// Token: 0x060055D0 RID: 21968 RVA: 0x000DB358 File Offset: 0x000D9758
			internal bool <>m__1(ResourceSourceType t)
			{
				DifficultyLevelMeasurement.<GetDifficultyRelevantWeapons>c__AnonStorey13 <>f__ref$19 = this.<>f__ref$19;
				ResourceSourceType t = t2;
				return this.<>f__ref$19.sourceTypes.Any((ResourceSourceType ss) => ss == t);
			}

			// Token: 0x0400445E RID: 17502
			internal ResourceType w;

			// Token: 0x0400445F RID: 17503
			internal DifficultyLevelMeasurement.<GetDifficultyRelevantWeapons>c__AnonStorey13 <>f__ref$19;

			// Token: 0x04004460 RID: 17504
			internal DifficultyLevelMeasurement.<GetDifficultyRelevantWeapons>c__AnonStorey11 <>f__ref$17;

			// Token: 0x02000D06 RID: 3334
			private sealed class <GetDifficultyRelevantWeapons>c__AnonStorey14
			{
				// Token: 0x060055D1 RID: 21969 RVA: 0x000DB39A File Offset: 0x000D979A
				public <GetDifficultyRelevantWeapons>c__AnonStorey14()
				{
				}

				// Token: 0x060055D2 RID: 21970 RVA: 0x000DB3A2 File Offset: 0x000D97A2
				internal bool <>m__0(ResourceSourceType ss)
				{
					return ss == this.t;
				}

				// Token: 0x04004461 RID: 17505
				internal ResourceSourceType t;

				// Token: 0x04004462 RID: 17506
				internal DifficultyLevelMeasurement.<GetDifficultyRelevantWeapons>c__AnonStorey13 <>f__ref$19;
			}
		}
	}

	// Token: 0x02000CF9 RID: 3321
	[CompilerGenerated]
	private sealed class <GetDifficultyRelevantArmors>c__AnonStorey18
	{
		// Token: 0x060055B5 RID: 21941 RVA: 0x000DB3AD File Offset: 0x000D97AD
		public <GetDifficultyRelevantArmors>c__AnonStorey18()
		{
		}

		// Token: 0x060055B6 RID: 21942 RVA: 0x000DB3B5 File Offset: 0x000D97B5
		internal bool <>m__0(ResourceType w)
		{
			return w.HasCreationTemplate() && w.GetCreationTemplate().ItemSourceTypes.Any((ResourceSourceType t) => this.sourceTypes.Any((ResourceSourceType ss) => ss == t));
		}

		// Token: 0x060055B7 RID: 21943 RVA: 0x000DB3E4 File Offset: 0x000D97E4
		internal bool <>m__1(ResourceSourceType t)
		{
			return this.sourceTypes.Any((ResourceSourceType ss) => ss == t);
		}

		// Token: 0x04004443 RID: 17475
		internal List<ResourceSourceType> sourceTypes;

		// Token: 0x04004444 RID: 17476
		internal DifficultyLevelMeasurement $this;

		// Token: 0x02000D07 RID: 3335
		private sealed class <GetDifficultyRelevantArmors>c__AnonStorey1A
		{
			// Token: 0x060055D3 RID: 21971 RVA: 0x000DB41C File Offset: 0x000D981C
			public <GetDifficultyRelevantArmors>c__AnonStorey1A()
			{
			}

			// Token: 0x060055D4 RID: 21972 RVA: 0x000DB424 File Offset: 0x000D9824
			internal bool <>m__0(ResourceSourceType ss)
			{
				return ss == this.t;
			}

			// Token: 0x04004463 RID: 17507
			internal ResourceSourceType t;

			// Token: 0x04004464 RID: 17508
			internal DifficultyLevelMeasurement.<GetDifficultyRelevantArmors>c__AnonStorey18 <>f__ref$24;
		}
	}

	// Token: 0x02000CFA RID: 3322
	[CompilerGenerated]
	private sealed class <GetDifficultyRelevantArmors>c__AnonStorey16
	{
		// Token: 0x060055B8 RID: 21944 RVA: 0x000DB42F File Offset: 0x000D982F
		public <GetDifficultyRelevantArmors>c__AnonStorey16()
		{
		}

		// Token: 0x060055B9 RID: 21945 RVA: 0x000DB438 File Offset: 0x000D9838
		internal bool <>m__0(ResourceType w)
		{
			DifficultyLevelMeasurement.<GetDifficultyRelevantArmors>c__AnonStorey18 <>f__ref$24 = this.<>f__ref$24;
			DifficultyLevelMeasurement.<GetDifficultyRelevantArmors>c__AnonStorey16 <>f__ref$22 = this;
			ResourceType w = w2;
			return this.itemLevels.Any((int l) => l == <>f__ref$24.$this.GetCorrespondingItemTierLevel(w)) && w.HasCreationTemplate() && w.GetCreationTemplate().ItemSourceTypes.Any(delegate(ResourceSourceType t)
			{
				DifficultyLevelMeasurement.<GetDifficultyRelevantArmors>c__AnonStorey18 <>f__ref$24 = <>f__ref$24;
				ResourceSourceType t = t;
				return <>f__ref$24.sourceTypes.Any((ResourceSourceType ss) => ss == t);
			});
		}

		// Token: 0x04004445 RID: 17477
		internal List<int> itemLevels;

		// Token: 0x04004446 RID: 17478
		internal DifficultyLevelMeasurement.<GetDifficultyRelevantArmors>c__AnonStorey18 <>f__ref$24;

		// Token: 0x02000D08 RID: 3336
		private sealed class <GetDifficultyRelevantArmors>c__AnonStorey17
		{
			// Token: 0x060055D5 RID: 21973 RVA: 0x000DB4B5 File Offset: 0x000D98B5
			public <GetDifficultyRelevantArmors>c__AnonStorey17()
			{
			}

			// Token: 0x060055D6 RID: 21974 RVA: 0x000DB4BD File Offset: 0x000D98BD
			internal bool <>m__0(int l)
			{
				return l == this.<>f__ref$24.$this.GetCorrespondingItemTierLevel(this.w);
			}

			// Token: 0x060055D7 RID: 21975 RVA: 0x000DB4D8 File Offset: 0x000D98D8
			internal bool <>m__1(ResourceSourceType t)
			{
				DifficultyLevelMeasurement.<GetDifficultyRelevantArmors>c__AnonStorey18 <>f__ref$24 = this.<>f__ref$24;
				ResourceSourceType t = t2;
				return this.<>f__ref$24.sourceTypes.Any((ResourceSourceType ss) => ss == t);
			}

			// Token: 0x04004465 RID: 17509
			internal ResourceType w;

			// Token: 0x04004466 RID: 17510
			internal DifficultyLevelMeasurement.<GetDifficultyRelevantArmors>c__AnonStorey18 <>f__ref$24;

			// Token: 0x04004467 RID: 17511
			internal DifficultyLevelMeasurement.<GetDifficultyRelevantArmors>c__AnonStorey16 <>f__ref$22;

			// Token: 0x02000D09 RID: 3337
			private sealed class <GetDifficultyRelevantArmors>c__AnonStorey19
			{
				// Token: 0x060055D8 RID: 21976 RVA: 0x000DB51A File Offset: 0x000D991A
				public <GetDifficultyRelevantArmors>c__AnonStorey19()
				{
				}

				// Token: 0x060055D9 RID: 21977 RVA: 0x000DB522 File Offset: 0x000D9922
				internal bool <>m__0(ResourceSourceType ss)
				{
					return ss == this.t;
				}

				// Token: 0x04004468 RID: 17512
				internal ResourceSourceType t;

				// Token: 0x04004469 RID: 17513
				internal DifficultyLevelMeasurement.<GetDifficultyRelevantArmors>c__AnonStorey18 <>f__ref$24;
			}
		}
	}
}
