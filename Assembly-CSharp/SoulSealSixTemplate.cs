using System;
using System.Collections.Generic;

// Token: 0x0200056F RID: 1391
public class SoulSealSixTemplate : AccessoryTemplateBase
{
	// Token: 0x06002806 RID: 10246 RVA: 0x0011A23A File Offset: 0x0011863A
	public SoulSealSixTemplate()
	{
	}

	// Token: 0x17000371 RID: 881
	// (get) Token: 0x06002807 RID: 10247 RVA: 0x0011A255 File Offset: 0x00118655
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000372 RID: 882
	// (get) Token: 0x06002808 RID: 10248 RVA: 0x0011A25D File Offset: 0x0011865D
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002809 RID: 10249 RVA: 0x0011A268 File Offset: 0x00118668
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

	// Token: 0x0600280A RID: 10250 RVA: 0x0011A290 File Offset: 0x00118690
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int num = 250;
		if (grade == QualityGrade.Rare)
		{
			num += 15;
		}
		if (grade == QualityGrade.Epic)
		{
			num += 30;
		}
		if (grade == QualityGrade.Legendary)
		{
			num += 45;
		}
		if (grade == QualityGrade.Ancient)
		{
			num += 60;
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

	// Token: 0x040021D4 RID: 8660
	private ResourceType _itemType = ResourceType.SoulSealSix;

	// Token: 0x040021D5 RID: 8661
	private int _itemTierNumber = 45;
}
