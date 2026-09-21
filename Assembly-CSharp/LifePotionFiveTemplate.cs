using System;
using System.Collections.Generic;

// Token: 0x020005DE RID: 1502
public class LifePotionFiveTemplate : ConsumableTemplateBase
{
	// Token: 0x06002998 RID: 10648 RVA: 0x0011C103 File Offset: 0x0011A503
	public LifePotionFiveTemplate()
	{
	}

	// Token: 0x17000450 RID: 1104
	// (get) Token: 0x06002999 RID: 10649 RVA: 0x0011C10B File Offset: 0x0011A50B
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.LifePotionFive;
		}
	}

	// Token: 0x17000451 RID: 1105
	// (get) Token: 0x0600299A RID: 10650 RVA: 0x0011C112 File Offset: 0x0011A512
	public override int ItemTierNumber
	{
		get
		{
			return 25;
		}
	}

	// Token: 0x0600299B RID: 10651 RVA: 0x0011C118 File Offset: 0x0011A518
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int healValue = 2000;
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
