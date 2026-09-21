using System;
using System.Collections.Generic;

// Token: 0x020005E0 RID: 1504
public class LifePotionOneTemplate : ConsumableTemplateBase
{
	// Token: 0x060029A0 RID: 10656 RVA: 0x0011C195 File Offset: 0x0011A595
	public LifePotionOneTemplate()
	{
	}

	// Token: 0x17000454 RID: 1108
	// (get) Token: 0x060029A1 RID: 10657 RVA: 0x0011C19D File Offset: 0x0011A59D
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.LifePotionOne;
		}
	}

	// Token: 0x17000455 RID: 1109
	// (get) Token: 0x060029A2 RID: 10658 RVA: 0x0011C1A4 File Offset: 0x0011A5A4
	public override int ItemTierNumber
	{
		get
		{
			return 5;
		}
	}

	// Token: 0x060029A3 RID: 10659 RVA: 0x0011C1A8 File Offset: 0x0011A5A8
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int healValue = 150;
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
