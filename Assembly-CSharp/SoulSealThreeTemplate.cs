using System;
using System.Collections.Generic;

// Token: 0x02000570 RID: 1392
public class SoulSealThreeTemplate : AccessoryTemplateBase
{
	// Token: 0x0600280B RID: 10251 RVA: 0x0011A30A File Offset: 0x0011870A
	public SoulSealThreeTemplate()
	{
	}

	// Token: 0x17000373 RID: 883
	// (get) Token: 0x0600280C RID: 10252 RVA: 0x0011A325 File Offset: 0x00118725
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000374 RID: 884
	// (get) Token: 0x0600280D RID: 10253 RVA: 0x0011A32D File Offset: 0x0011872D
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600280E RID: 10254 RVA: 0x0011A338 File Offset: 0x00118738
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int num = 90;
		if (grade == QualityGrade.Rare)
		{
			num += 10;
		}
		if (grade == QualityGrade.Epic)
		{
			num += 20;
		}
		if (grade == QualityGrade.Legendary)
		{
			num += 30;
		}
		if (grade == QualityGrade.Ancient)
		{
			num += 40;
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

	// Token: 0x040021D6 RID: 8662
	private ResourceType _itemType = ResourceType.SoulSealThree;

	// Token: 0x040021D7 RID: 8663
	private int _itemTierNumber = 18;
}
