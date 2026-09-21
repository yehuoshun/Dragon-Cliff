using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000AE1 RID: 2785
public abstract class RemnantsBossBase : BossUnitConfigurationBase
{
	// Token: 0x06004B0D RID: 19213 RVA: 0x001EAD37 File Offset: 0x001E9137
	protected RemnantsBossBase()
	{
	}

	// Token: 0x06004B0E RID: 19214 RVA: 0x001EAD40 File Offset: 0x001E9140
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (GameWorld.instance.PlayerProfile.QuestIsActive(QuestIdentifier.Side_7))
		{
			if (fromAdventure.CorrespondingDifficultyMeasurement.StarRating == 1)
			{
				list.AddRange(fromAdventure.CorrespondingDifficultyMeasurement.GenerateDropableGears(2, new QualityGrade?(QualityGrade.Ancient), false));
				list.AddRange(fromAdventure.CorrespondingDifficultyMeasurement.GenerateDropableGems(3));
				int num = UnityEngine.Random.Range(2, 5);
				if (fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue > 100.0)
				{
					int num2 = (int)Math.Ceiling((fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue - 100.0) / 5.0);
					if (num2 > 20)
					{
						num2 = 20;
					}
					if (num2 < 1)
					{
						num2 = 1;
					}
					num *= num2;
				}
				list.Add(new ResourceUpdate
				{
					ResourceType = ResourceType.FragmentOfDemon,
					ChangeAmount = (double)num,
					RelatedItems = new List<Item>()
				});
				if ((double)UnityEngine.Random.value <= 0.01)
				{
					list.AddRange(fromAdventure.CorrespondingDifficultyMeasurement.GenerateAccessories(1, new QualityGrade?(QualityGrade.Ancient), true));
				}
			}
			if (fromAdventure.CorrespondingDifficultyMeasurement.StarRating == 2)
			{
				list.AddRange(fromAdventure.CorrespondingDifficultyMeasurement.GenerateDropableGears(2, new QualityGrade?(QualityGrade.Ancient), false));
				list.AddRange(fromAdventure.CorrespondingDifficultyMeasurement.GenerateDropableGems(UnityEngine.Random.Range(3, 5)));
				int num3 = 100;
				if (fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue > 100.0)
				{
					int num4 = (int)Math.Ceiling((fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue - 100.0) / 5.0);
					int num5 = UnityEngine.Random.Range(2, 5);
					if (num4 > 20)
					{
						num4 = 20;
					}
					if (num4 < 1)
					{
						num4 = 1;
					}
					num5 *= num4;
					num3 += num5;
				}
				list.Add(new ResourceUpdate
				{
					ResourceType = ResourceType.FragmentOfDemon,
					ChangeAmount = (double)num3,
					RelatedItems = new List<Item>()
				});
				list.AddRange(fromAdventure.CorrespondingDifficultyMeasurement.GenerateAccessories(1, new QualityGrade?(QualityGrade.Ancient), true));
			}
		}
		return list;
	}

	// Token: 0x06004B0F RID: 19215 RVA: 0x001EAF5C File Offset: 0x001E935C
	protected override UnitGrowthProfile FurtherProfileModification(UnitGrowthProfile originalGrowthProfile, DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 2)
		{
			originalGrowthProfile.SetValue(AttributeType.Resilience, 10000.0, false);
			originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
			where v.AttributeType == AttributeType.Vitality
			select v).Sum((UnitGrowthValue v) => v.Potential) * 8.0, false);
		}
		else if (measurement.DifficultyValue > 100.0)
		{
			originalGrowthProfile.SetValue(AttributeType.Resilience, 6000.0, false);
			originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
			where v.AttributeType == AttributeType.Vitality
			select v).Sum((UnitGrowthValue v) => v.Potential) * 4.0, false);
		}
		else
		{
			originalGrowthProfile.SetValue(AttributeType.Resilience, 3000.0, false);
			originalGrowthProfile.SetValue(AttributeType.Vitality, (from v in originalGrowthProfile.UnitGrowthValues
			where v.AttributeType == AttributeType.Vitality
			select v).Sum((UnitGrowthValue v) => v.Potential) * 2.5, false);
		}
		return originalGrowthProfile;
	}

	// Token: 0x06004B10 RID: 19216 RVA: 0x001EB0ED File Offset: 0x001E94ED
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__0(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004B11 RID: 19217 RVA: 0x001EB0F8 File Offset: 0x001E94F8
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__1(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x06004B12 RID: 19218 RVA: 0x001EB100 File Offset: 0x001E9500
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__2(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004B13 RID: 19219 RVA: 0x001EB10B File Offset: 0x001E950B
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__3(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x06004B14 RID: 19220 RVA: 0x001EB113 File Offset: 0x001E9513
	[CompilerGenerated]
	private static bool <FurtherProfileModification>m__4(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004B15 RID: 19221 RVA: 0x001EB11E File Offset: 0x001E951E
	[CompilerGenerated]
	private static double <FurtherProfileModification>m__5(UnitGrowthValue v)
	{
		return v.Potential;
	}

	// Token: 0x04003AAA RID: 15018
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache0;

	// Token: 0x04003AAB RID: 15019
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache1;

	// Token: 0x04003AAC RID: 15020
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache2;

	// Token: 0x04003AAD RID: 15021
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache3;

	// Token: 0x04003AAE RID: 15022
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache4;

	// Token: 0x04003AAF RID: 15023
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache5;
}
