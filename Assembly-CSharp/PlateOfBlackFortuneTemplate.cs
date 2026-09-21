using System;
using System.Collections.Generic;

// Token: 0x020005A9 RID: 1449
public class PlateOfBlackFortuneTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028E0 RID: 10464 RVA: 0x0011B297 File Offset: 0x00119697
	public PlateOfBlackFortuneTemplate()
	{
	}

	// Token: 0x170003E6 RID: 998
	// (get) Token: 0x060028E1 RID: 10465 RVA: 0x0011B2B2 File Offset: 0x001196B2
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003E7 RID: 999
	// (get) Token: 0x060028E2 RID: 10466 RVA: 0x0011B2BA File Offset: 0x001196BA
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060028E3 RID: 10467 RVA: 0x0011B2C4 File Offset: 0x001196C4
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ClearWaterData
			{
				Chance = 1.0,
				NumberOfCleanUps = 1
			}
		};
	}

	// Token: 0x04002210 RID: 8720
	private ResourceType _itemType = ResourceType.PlateOfBlackFortune;

	// Token: 0x04002211 RID: 8721
	private int _itemTierNumber = 14;
}
