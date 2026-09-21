using System;
using System.Collections.Generic;

// Token: 0x020005E1 RID: 1505
public class LifePotionSevenTemplate : ConsumableTemplateBase
{
	// Token: 0x060029A4 RID: 10660 RVA: 0x0011C1DD File Offset: 0x0011A5DD
	public LifePotionSevenTemplate()
	{
	}

	// Token: 0x17000456 RID: 1110
	// (get) Token: 0x060029A5 RID: 10661 RVA: 0x0011C1E5 File Offset: 0x0011A5E5
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.LifePotionSeven;
		}
	}

	// Token: 0x17000457 RID: 1111
	// (get) Token: 0x060029A6 RID: 10662 RVA: 0x0011C1EC File Offset: 0x0011A5EC
	public override int ItemTierNumber
	{
		get
		{
			return 35;
		}
	}

	// Token: 0x060029A7 RID: 10663 RVA: 0x0011C1F0 File Offset: 0x0011A5F0
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new LifePotionPercentageData
			{
				IsStarEf = false,
				Rate = 0.5,
				IsPlayerUnit = true
			}
		};
	}
}
