using System;
using System.Collections.Generic;

// Token: 0x02000637 RID: 1591
public class GrowthTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B2B RID: 11051 RVA: 0x0012034B File Offset: 0x0011E74B
	public GrowthTemplate()
	{
	}

	// Token: 0x17000503 RID: 1283
	// (get) Token: 0x06002B2C RID: 11052 RVA: 0x00120353 File Offset: 0x0011E753
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Growth;
		}
	}

	// Token: 0x17000504 RID: 1284
	// (get) Token: 0x06002B2D RID: 11053 RVA: 0x0012035A File Offset: 0x0011E75A
	public override int ItemTierNumber
	{
		get
		{
			return 17;
		}
	}

	// Token: 0x06002B2E RID: 11054 RVA: 0x00120360 File Offset: 0x0011E760
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				Condition = GrowthConditionType.DealCritDamage,
				ConditionValue = 250.0,
				CurrentGrowthValue = 0.0,
				GrowthAttributeType = AttributeType.CritRate,
				GrowthRate = 0.02,
				MaxGrowthValue = 0.3 + (double)(grade - QualityGrade.Normal) * 0.05,
				Id = Guid.NewGuid().ToString()
			}
		};
	}
}
