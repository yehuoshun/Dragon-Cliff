using System;
using System.Collections.Generic;

// Token: 0x0200063A RID: 1594
public class KunlunTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B37 RID: 11063 RVA: 0x0012052E File Offset: 0x0011E92E
	public KunlunTemplate()
	{
	}

	// Token: 0x17000509 RID: 1289
	// (get) Token: 0x06002B38 RID: 11064 RVA: 0x00120536 File Offset: 0x0011E936
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Kunlun;
		}
	}

	// Token: 0x1700050A RID: 1290
	// (get) Token: 0x06002B39 RID: 11065 RVA: 0x0012053D File Offset: 0x0011E93D
	public override int ItemTierNumber
	{
		get
		{
			return 33;
		}
	}

	// Token: 0x06002B3A RID: 11066 RVA: 0x00120544 File Offset: 0x0011E944
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				MaxGrowthValue = 0.5 + (double)(grade - QualityGrade.Normal) * 0.1,
				GrowthRate = 0.003,
				CurrentGrowthValue = 0.0,
				ConditionValue = 1400.0,
				GrowthAttributeType = AttributeType.CritRate,
				Condition = GrowthConditionType.DealCritDamage,
				Id = Guid.NewGuid().ToString()
			}
		};
	}
}
