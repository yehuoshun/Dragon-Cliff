using System;
using System.Collections.Generic;

// Token: 0x02000571 RID: 1393
public class SoulSealTwoTemplate : AccessoryTemplateBase
{
	// Token: 0x0600280F RID: 10255 RVA: 0x0011A3AF File Offset: 0x001187AF
	public SoulSealTwoTemplate()
	{
	}

	// Token: 0x17000375 RID: 885
	// (get) Token: 0x06002810 RID: 10256 RVA: 0x0011A3CA File Offset: 0x001187CA
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000376 RID: 886
	// (get) Token: 0x06002811 RID: 10257 RVA: 0x0011A3D2 File Offset: 0x001187D2
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002812 RID: 10258 RVA: 0x0011A3DC File Offset: 0x001187DC
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int num = 50;
		if (grade == QualityGrade.Rare)
		{
			num += 9;
		}
		if (grade == QualityGrade.Epic)
		{
			num += 18;
		}
		if (grade == QualityGrade.Legendary)
		{
			num += 27;
		}
		if (grade == QualityGrade.Ancient)
		{
			num += 36;
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

	// Token: 0x040021D8 RID: 8664
	private ResourceType _itemType = ResourceType.SoulSealTwo;

	// Token: 0x040021D9 RID: 8665
	private int _itemTierNumber = 9;
}
