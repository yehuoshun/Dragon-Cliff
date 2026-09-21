using System;
using System.Collections.Generic;

// Token: 0x02000610 RID: 1552
public class HarvestTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A8C RID: 10892 RVA: 0x0011F687 File Offset: 0x0011DA87
	public HarvestTemplate()
	{
	}

	// Token: 0x170004B5 RID: 1205
	// (get) Token: 0x06002A8D RID: 10893 RVA: 0x0011F68F File Offset: 0x0011DA8F
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Harvest;
		}
	}

	// Token: 0x170004B6 RID: 1206
	// (get) Token: 0x06002A8E RID: 10894 RVA: 0x0011F696 File Offset: 0x0011DA96
	public override int ItemTierNumber
	{
		get
		{
			return 5;
		}
	}

	// Token: 0x06002A8F RID: 10895 RVA: 0x0011F69C File Offset: 0x0011DA9C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				Condition = GrowthConditionType.DealCritDamage,
				CurrentGrowthValue = 0.0,
				GrowthAttributeType = AttributeType.Strength,
				MaxGrowthValue = (double)(20 + (grade - QualityGrade.Normal) * 8),
				GrowthRate = 3.0,
				ConditionValue = 50.0,
				Id = Guid.NewGuid().ToString()
			}
		};
	}
}
