using System;
using System.Collections.Generic;

// Token: 0x02000635 RID: 1589
public class GodsRageTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B22 RID: 11042 RVA: 0x0012024C File Offset: 0x0011E64C
	public GodsRageTemplate()
	{
	}

	// Token: 0x170004FF RID: 1279
	// (get) Token: 0x06002B23 RID: 11043 RVA: 0x00120254 File Offset: 0x0011E654
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.GodsRage;
		}
	}

	// Token: 0x17000500 RID: 1280
	// (get) Token: 0x06002B24 RID: 11044 RVA: 0x0012025B File Offset: 0x0011E65B
	public override int ItemTierNumber
	{
		get
		{
			return 32;
		}
	}

	// Token: 0x06002B25 RID: 11045 RVA: 0x00120260 File Offset: 0x0011E660
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Resilience,
			AttributeType.DodgeRateAdjustment
		};
	}

	// Token: 0x06002B26 RID: 11046 RVA: 0x0012028C File Offset: 0x0011E68C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				GrowthAttributeType = AttributeType.Intelligience,
				MaxGrowthValue = 1000.0,
				GrowthRate = 1.0,
				CurrentGrowthValue = 0.0,
				ConditionValue = (double)(500 + (grade - QualityGrade.Normal) * 200),
				Condition = GrowthConditionType.DealDamage,
				Id = Guid.NewGuid().ToString()
			}
		};
	}
}
