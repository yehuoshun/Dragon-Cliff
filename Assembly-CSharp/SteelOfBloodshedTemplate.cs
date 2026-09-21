using System;
using System.Collections.Generic;

// Token: 0x020005B2 RID: 1458
public class SteelOfBloodshedTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028FE RID: 10494 RVA: 0x0011B47D File Offset: 0x0011987D
	public SteelOfBloodshedTemplate()
	{
	}

	// Token: 0x170003F8 RID: 1016
	// (get) Token: 0x060028FF RID: 10495 RVA: 0x0011B498 File Offset: 0x00119898
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003F9 RID: 1017
	// (get) Token: 0x06002900 RID: 10496 RVA: 0x0011B4A0 File Offset: 0x001198A0
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002901 RID: 10497 RVA: 0x0011B4A8 File Offset: 0x001198A8
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new TauntRecoveryData
			{
				RecoveryRate = 0.03 + (double)(grade - QualityGrade.Normal) * 0.01
			}
		};
	}

	// Token: 0x0400221C RID: 8732
	private ResourceType _itemType = ResourceType.SteelOfBloodshed;

	// Token: 0x0400221D RID: 8733
	private int _itemTierNumber = 18;
}
