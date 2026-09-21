using System;
using System.Collections.Generic;

// Token: 0x02000651 RID: 1617
public class GrandCandyWandTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B8D RID: 11149 RVA: 0x00120BEC File Offset: 0x0011EFEC
	public GrandCandyWandTemplate()
	{
	}

	// Token: 0x17000537 RID: 1335
	// (get) Token: 0x06002B8E RID: 11150 RVA: 0x00120C07 File Offset: 0x0011F007
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000538 RID: 1336
	// (get) Token: 0x06002B8F RID: 11151 RVA: 0x00120C0F File Offset: 0x0011F00F
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002B90 RID: 11152 RVA: 0x00120C18 File Offset: 0x0011F018
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new TauntRecoveryData
			{
				RecoveryRate = 0.06 + (double)(grade - QualityGrade.Normal) * 0.01
			}
		};
	}

	// Token: 0x040022A8 RID: 8872
	private ResourceType _itemType = ResourceType.GrandCandyWand;

	// Token: 0x040022A9 RID: 8873
	private int _itemTierNumber = 33;
}
