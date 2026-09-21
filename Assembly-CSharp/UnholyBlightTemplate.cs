using System;
using System.Collections.Generic;

// Token: 0x02000659 RID: 1625
public class UnholyBlightTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BA9 RID: 11177 RVA: 0x00120DCF File Offset: 0x0011F1CF
	public UnholyBlightTemplate()
	{
	}

	// Token: 0x17000547 RID: 1351
	// (get) Token: 0x06002BAA RID: 11178 RVA: 0x00120DEA File Offset: 0x0011F1EA
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000548 RID: 1352
	// (get) Token: 0x06002BAB RID: 11179 RVA: 0x00120DF2 File Offset: 0x0011F1F2
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002BAC RID: 11180 RVA: 0x00120DFC File Offset: 0x0011F1FC
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new StarfallData
			{
				Chance = 0.3,
				DamagePercentage = 0.8 + (double)(grade - QualityGrade.Normal) * 0.1,
				DamageType = OutputType.Shadow
			}
		};
	}

	// Token: 0x040022AC RID: 8876
	private ResourceType _itemType = ResourceType.UnholyBlight;

	// Token: 0x040022AD RID: 8877
	private int _itemTierNumber = 19;
}
