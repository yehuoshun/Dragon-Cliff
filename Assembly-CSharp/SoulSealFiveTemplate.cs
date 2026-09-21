using System;
using System.Collections.Generic;

// Token: 0x0200056B RID: 1387
public class SoulSealFiveTemplate : AccessoryTemplateBase
{
	// Token: 0x060027F4 RID: 10228 RVA: 0x00119F52 File Offset: 0x00118352
	public SoulSealFiveTemplate()
	{
	}

	// Token: 0x17000369 RID: 873
	// (get) Token: 0x060027F5 RID: 10229 RVA: 0x00119F6D File Offset: 0x0011836D
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700036A RID: 874
	// (get) Token: 0x060027F6 RID: 10230 RVA: 0x00119F75 File Offset: 0x00118375
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027F7 RID: 10231 RVA: 0x00119F80 File Offset: 0x00118380
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

	// Token: 0x060027F8 RID: 10232 RVA: 0x00119FA8 File Offset: 0x001183A8
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int num = 200;
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

	// Token: 0x040021CC RID: 8652
	private ResourceType _itemType = ResourceType.SoulSealFive;

	// Token: 0x040021CD RID: 8653
	private int _itemTierNumber = 37;
}
