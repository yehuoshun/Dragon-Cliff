using System;
using System.Collections.Generic;

// Token: 0x02000611 RID: 1553
public class WindTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A90 RID: 10896 RVA: 0x0011F722 File Offset: 0x0011DB22
	public WindTemplate()
	{
	}

	// Token: 0x170004B7 RID: 1207
	// (get) Token: 0x06002A91 RID: 10897 RVA: 0x0011F72A File Offset: 0x0011DB2A
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Wind;
		}
	}

	// Token: 0x170004B8 RID: 1208
	// (get) Token: 0x06002A92 RID: 10898 RVA: 0x0011F731 File Offset: 0x0011DB31
	public override int ItemTierNumber
	{
		get
		{
			return 15;
		}
	}

	// Token: 0x06002A93 RID: 10899 RVA: 0x0011F738 File Offset: 0x0011DB38
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				GrowthRate = 2.0,
				CurrentGrowthValue = 0.0,
				ConditionValue = 100.0,
				GrowthAttributeType = AttributeType.Strength,
				MaxGrowthValue = (double)(80 + (grade - QualityGrade.Normal) * 15),
				Condition = GrowthConditionType.DealCritDamage,
				Id = Guid.NewGuid().ToString()
			}
		};
	}
}
