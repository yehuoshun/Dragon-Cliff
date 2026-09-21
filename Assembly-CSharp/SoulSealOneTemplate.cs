using System;
using System.Collections.Generic;

// Token: 0x0200056D RID: 1389
public class SoulSealOneTemplate : AccessoryTemplateBase
{
	// Token: 0x060027FD RID: 10237 RVA: 0x0011A0CA File Offset: 0x001184CA
	public SoulSealOneTemplate()
	{
	}

	// Token: 0x1700036D RID: 877
	// (get) Token: 0x060027FE RID: 10238 RVA: 0x0011A0E4 File Offset: 0x001184E4
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x060027FF RID: 10239 RVA: 0x0011A0EC File Offset: 0x001184EC
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002800 RID: 10240 RVA: 0x0011A0F4 File Offset: 0x001184F4
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int num = 20;
		if (grade == QualityGrade.Rare)
		{
			num += 7;
		}
		if (grade == QualityGrade.Epic)
		{
			num += 14;
		}
		if (grade == QualityGrade.Legendary)
		{
			num += 21;
		}
		if (grade == QualityGrade.Ancient)
		{
			num += 28;
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

	// Token: 0x040021D0 RID: 8656
	private ResourceType _itemType = ResourceType.SoulSealOne;

	// Token: 0x040021D1 RID: 8657
	private int _itemTierNumber = 4;
}
