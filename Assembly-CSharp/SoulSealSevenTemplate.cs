using System;
using System.Collections.Generic;

// Token: 0x0200056E RID: 1390
public class SoulSealSevenTemplate : AccessoryTemplateBase
{
	// Token: 0x06002801 RID: 10241 RVA: 0x0011A16A File Offset: 0x0011856A
	public SoulSealSevenTemplate()
	{
	}

	// Token: 0x1700036F RID: 879
	// (get) Token: 0x06002802 RID: 10242 RVA: 0x0011A185 File Offset: 0x00118585
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000370 RID: 880
	// (get) Token: 0x06002803 RID: 10243 RVA: 0x0011A18D File Offset: 0x0011858D
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002804 RID: 10244 RVA: 0x0011A198 File Offset: 0x00118598
	public override List<ISpecialEffectDataLoad> GenerateStarEffects(QualityGrade grade, int itemTierNumber)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new SoulCollectionUndispellableData
			{
				IsStar = true
			}
		};
	}

	// Token: 0x06002805 RID: 10245 RVA: 0x0011A1C0 File Offset: 0x001185C0
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int num = 300;
		if (grade == QualityGrade.Rare)
		{
			num += 20;
		}
		if (grade == QualityGrade.Epic)
		{
			num += 40;
		}
		if (grade == QualityGrade.Legendary)
		{
			num += 60;
		}
		if (grade == QualityGrade.Ancient)
		{
			num += 80;
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

	// Token: 0x040021D2 RID: 8658
	private ResourceType _itemType = ResourceType.SoulSealSeven;

	// Token: 0x040021D3 RID: 8659
	private int _itemTierNumber = 52;
}
