using System;
using System.Collections.Generic;

// Token: 0x020005E4 RID: 1508
public class LifePotionTwoTemplate : ConsumableTemplateBase
{
	// Token: 0x060029B0 RID: 10672 RVA: 0x0011C2C1 File Offset: 0x0011A6C1
	public LifePotionTwoTemplate()
	{
	}

	// Token: 0x1700045C RID: 1116
	// (get) Token: 0x060029B1 RID: 10673 RVA: 0x0011C2C9 File Offset: 0x0011A6C9
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.LifePotionTwo;
		}
	}

	// Token: 0x1700045D RID: 1117
	// (get) Token: 0x060029B2 RID: 10674 RVA: 0x0011C2D0 File Offset: 0x0011A6D0
	public override int ItemTierNumber
	{
		get
		{
			return 10;
		}
	}

	// Token: 0x060029B3 RID: 10675 RVA: 0x0011C2D4 File Offset: 0x0011A6D4
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int healValue = 300;
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
