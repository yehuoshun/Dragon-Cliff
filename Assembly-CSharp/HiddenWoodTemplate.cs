using System;
using System.Collections.Generic;

// Token: 0x02000639 RID: 1593
public class HiddenWoodTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B33 RID: 11059 RVA: 0x00120496 File Offset: 0x0011E896
	public HiddenWoodTemplate()
	{
	}

	// Token: 0x17000507 RID: 1287
	// (get) Token: 0x06002B34 RID: 11060 RVA: 0x0012049E File Offset: 0x0011E89E
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.HiddenWood;
		}
	}

	// Token: 0x17000508 RID: 1288
	// (get) Token: 0x06002B35 RID: 11061 RVA: 0x001204A5 File Offset: 0x0011E8A5
	public override int ItemTierNumber
	{
		get
		{
			return 5;
		}
	}

	// Token: 0x06002B36 RID: 11062 RVA: 0x001204A8 File Offset: 0x0011E8A8
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				Condition = GrowthConditionType.DealDamage,
				CurrentGrowthValue = 0.0,
				MaxGrowthValue = (double)(20 + (grade - QualityGrade.Normal) * 8),
				GrowthAttributeType = AttributeType.Intelligience,
				ConditionValue = 50.0,
				GrowthRate = 2.0,
				Id = Guid.NewGuid().ToString()
			}
		};
	}
}
