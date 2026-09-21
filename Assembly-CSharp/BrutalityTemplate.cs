using System;
using System.Collections.Generic;

// Token: 0x02000666 RID: 1638
public class BrutalityTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BD9 RID: 11225 RVA: 0x0012111F File Offset: 0x0011F51F
	public BrutalityTemplate()
	{
	}

	// Token: 0x17000561 RID: 1377
	// (get) Token: 0x06002BDA RID: 11226 RVA: 0x0012113A File Offset: 0x0011F53A
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000562 RID: 1378
	// (get) Token: 0x06002BDB RID: 11227 RVA: 0x00121142 File Offset: 0x0011F542
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002BDC RID: 11228 RVA: 0x0012114C File Offset: 0x0011F54C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new StarfallData
			{
				Chance = 0.3,
				DamageType = OutputType.Physical,
				DamagePercentage = 0.8 + (double)(grade - QualityGrade.Normal) * 0.1
			}
		};
	}

	// Token: 0x040022B2 RID: 8882
	private ResourceType _itemType = ResourceType.Brutality;

	// Token: 0x040022B3 RID: 8883
	private int _itemTierNumber = 20;
}
