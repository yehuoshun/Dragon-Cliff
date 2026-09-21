using System;
using System.Collections.Generic;

// Token: 0x020005DF RID: 1503
public class LifePotionFourTemplate : ConsumableTemplateBase
{
	// Token: 0x0600299C RID: 10652 RVA: 0x0011C14D File Offset: 0x0011A54D
	public LifePotionFourTemplate()
	{
	}

	// Token: 0x17000452 RID: 1106
	// (get) Token: 0x0600299D RID: 10653 RVA: 0x0011C155 File Offset: 0x0011A555
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.LifePotionFour;
		}
	}

	// Token: 0x17000453 RID: 1107
	// (get) Token: 0x0600299E RID: 10654 RVA: 0x0011C15C File Offset: 0x0011A55C
	public override int ItemTierNumber
	{
		get
		{
			return 20;
		}
	}

	// Token: 0x0600299F RID: 10655 RVA: 0x0011C160 File Offset: 0x0011A560
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int healValue = 1000;
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
