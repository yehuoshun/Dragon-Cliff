using System;
using System.Collections.Generic;

// Token: 0x0200066B RID: 1643
public class MandateOfHeavenTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BEC RID: 11244 RVA: 0x0012127D File Offset: 0x0011F67D
	public MandateOfHeavenTemplate()
	{
	}

	// Token: 0x1700056B RID: 1387
	// (get) Token: 0x06002BED RID: 11245 RVA: 0x00121285 File Offset: 0x0011F685
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.MandateOfHeaven;
		}
	}

	// Token: 0x1700056C RID: 1388
	// (get) Token: 0x06002BEE RID: 11246 RVA: 0x0012128C File Offset: 0x0011F68C
	public override int ItemTierNumber
	{
		get
		{
			return 33;
		}
	}

	// Token: 0x06002BEF RID: 11247 RVA: 0x00121290 File Offset: 0x0011F690
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				GrowthAttributeType = AttributeType.LifeOnHit,
				MaxGrowthValue = 0.4 + (double)(grade - QualityGrade.Normal) * 0.05,
				GrowthRate = 0.02,
				CurrentGrowthValue = 0.0,
				Condition = GrowthConditionType.ReceiveHeal,
				ConditionValue = 0.6,
				Id = Guid.NewGuid().ToString()
			}
		};
	}
}
