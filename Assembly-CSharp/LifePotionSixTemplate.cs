using System;
using System.Collections.Generic;

// Token: 0x020005E2 RID: 1506
public class LifePotionSixTemplate : ConsumableTemplateBase
{
	// Token: 0x060029A8 RID: 10664 RVA: 0x0011C22E File Offset: 0x0011A62E
	public LifePotionSixTemplate()
	{
	}

	// Token: 0x17000458 RID: 1112
	// (get) Token: 0x060029A9 RID: 10665 RVA: 0x0011C236 File Offset: 0x0011A636
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.LifePotionSix;
		}
	}

	// Token: 0x17000459 RID: 1113
	// (get) Token: 0x060029AA RID: 10666 RVA: 0x0011C23D File Offset: 0x0011A63D
	public override int ItemTierNumber
	{
		get
		{
			return 30;
		}
	}

	// Token: 0x060029AB RID: 10667 RVA: 0x0011C244 File Offset: 0x0011A644
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int healValue = 5000;
		return new List<ISpecialEffectDataLoad>
		{
			new LifePotionData
			{
				HealValue = healValue,
				IsPlayerUnit = true
			}
		};
	}
}
