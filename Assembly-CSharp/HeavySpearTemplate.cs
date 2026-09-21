using System;
using System.Collections.Generic;

// Token: 0x02000624 RID: 1572
public class HeavySpearTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002ADC RID: 10972 RVA: 0x0011FCA3 File Offset: 0x0011E0A3
	public HeavySpearTemplate()
	{
	}

	// Token: 0x170004DD RID: 1245
	// (get) Token: 0x06002ADD RID: 10973 RVA: 0x0011FCAB File Offset: 0x0011E0AB
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.HeavySpear;
		}
	}

	// Token: 0x170004DE RID: 1246
	// (get) Token: 0x06002ADE RID: 10974 RVA: 0x0011FCB2 File Offset: 0x0011E0B2
	public override int ItemTierNumber
	{
		get
		{
			return 10;
		}
	}

	// Token: 0x06002ADF RID: 10975 RVA: 0x0011FCB8 File Offset: 0x0011E0B8
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				MaxGrowthValue = 200.0,
				GrowthRate = 1.0,
				CurrentGrowthValue = 0.0,
				Condition = GrowthConditionType.DealDamage,
				ConditionValue = (double)(75 + (grade - QualityGrade.Normal) * 15),
				GrowthAttributeType = AttributeType.Strength,
				Id = Guid.NewGuid().ToString()
			}
		};
	}
}
