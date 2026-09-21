using System;
using System.Collections.Generic;

// Token: 0x020005E3 RID: 1507
public class LifePotionThreeTemplate : ConsumableTemplateBase
{
	// Token: 0x060029AC RID: 10668 RVA: 0x0011C279 File Offset: 0x0011A679
	public LifePotionThreeTemplate()
	{
	}

	// Token: 0x1700045A RID: 1114
	// (get) Token: 0x060029AD RID: 10669 RVA: 0x0011C281 File Offset: 0x0011A681
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.LifePotionThree;
		}
	}

	// Token: 0x1700045B RID: 1115
	// (get) Token: 0x060029AE RID: 10670 RVA: 0x0011C288 File Offset: 0x0011A688
	public override int ItemTierNumber
	{
		get
		{
			return 15;
		}
	}

	// Token: 0x060029AF RID: 10671 RVA: 0x0011C28C File Offset: 0x0011A68C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int healValue = 600;
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
