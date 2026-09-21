using System;
using System.Collections.Generic;

// Token: 0x0200056C RID: 1388
public class SoulSealFourTemplate : AccessoryTemplateBase
{
	// Token: 0x060027F9 RID: 10233 RVA: 0x0011A022 File Offset: 0x00118422
	public SoulSealFourTemplate()
	{
	}

	// Token: 0x1700036B RID: 875
	// (get) Token: 0x060027FA RID: 10234 RVA: 0x0011A03D File Offset: 0x0011843D
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700036C RID: 876
	// (get) Token: 0x060027FB RID: 10235 RVA: 0x0011A045 File Offset: 0x00118445
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027FC RID: 10236 RVA: 0x0011A050 File Offset: 0x00118450
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int num = 140;
		if (grade == QualityGrade.Rare)
		{
			num += 12;
		}
		if (grade == QualityGrade.Epic)
		{
			num += 24;
		}
		if (grade == QualityGrade.Legendary)
		{
			num += 36;
		}
		if (grade == QualityGrade.Ancient)
		{
			num += 48;
		}
		return new List<ISpecialEffectDataLoad>
		{
			new SoulCollectionData
			{
				BoostTypes = new List<BoostType>
				{
					BoostType.Agility,
					BoostType.Output
				},
				IncreaseAmount = (double)num
			}
		};
	}

	// Token: 0x040021CE RID: 8654
	private ResourceType _itemType = ResourceType.SoulSealFour;

	// Token: 0x040021CF RID: 8655
	private int _itemTierNumber = 22;
}
