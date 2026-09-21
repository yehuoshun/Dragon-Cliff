using System;
using System.Collections.Generic;

// Token: 0x0200066E RID: 1646
public class MysticSwordTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BF8 RID: 11256 RVA: 0x0012138C File Offset: 0x0011F78C
	public MysticSwordTemplate()
	{
	}

	// Token: 0x17000571 RID: 1393
	// (get) Token: 0x06002BF9 RID: 11257 RVA: 0x00121394 File Offset: 0x0011F794
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.MysticSword;
		}
	}

	// Token: 0x17000572 RID: 1394
	// (get) Token: 0x06002BFA RID: 11258 RVA: 0x0012139B File Offset: 0x0011F79B
	public override int ItemTierNumber
	{
		get
		{
			return 31;
		}
	}

	// Token: 0x06002BFB RID: 11259 RVA: 0x001213A0 File Offset: 0x0011F7A0
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				ConditionValue = 800.0,
				GrowthAttributeType = AttributeType.FireResistanceResistance,
				MaxGrowthValue = (double)(1000 + (grade - QualityGrade.Normal) * 100),
				GrowthRate = 10.0,
				CurrentGrowthValue = 0.0,
				Condition = GrowthConditionType.ReceiveDamage,
				Id = Guid.NewGuid().ToString()
			}
		};
	}
}
