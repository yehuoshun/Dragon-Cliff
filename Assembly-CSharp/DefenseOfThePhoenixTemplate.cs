using System;
using System.Collections.Generic;

// Token: 0x0200059E RID: 1438
public class DefenseOfThePhoenixTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028BB RID: 10427 RVA: 0x0011B0F5 File Offset: 0x001194F5
	public DefenseOfThePhoenixTemplate()
	{
	}

	// Token: 0x170003D0 RID: 976
	// (get) Token: 0x060028BC RID: 10428 RVA: 0x0011B110 File Offset: 0x00119510
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003D1 RID: 977
	// (get) Token: 0x060028BD RID: 10429 RVA: 0x0011B118 File Offset: 0x00119518
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060028BE RID: 10430 RVA: 0x0011B120 File Offset: 0x00119520
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SufferlessData
			{
				RecoveryRate = 0.03 + (double)(grade - QualityGrade.Normal) * 0.01,
				NumberOfMaxTriggersPerBattle = 1,
				ImmuneTurns = 1
			}
		};
	}

	// Token: 0x0400220C RID: 8716
	private ResourceType _itemType = ResourceType.DefenseOfThePhoenix;

	// Token: 0x0400220D RID: 8717
	private int _itemTierNumber = 19;
}
