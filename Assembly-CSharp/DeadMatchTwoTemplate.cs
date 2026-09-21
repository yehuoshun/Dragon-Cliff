using System;
using System.Collections.Generic;

// Token: 0x02000547 RID: 1351
public class DeadMatchTwoTemplate : AccessoryTemplateBase
{
	// Token: 0x06002744 RID: 10052 RVA: 0x001182D3 File Offset: 0x001166D3
	public DeadMatchTwoTemplate()
	{
	}

	// Token: 0x17000321 RID: 801
	// (get) Token: 0x06002745 RID: 10053 RVA: 0x001182F5 File Offset: 0x001166F5
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000322 RID: 802
	// (get) Token: 0x06002746 RID: 10054 RVA: 0x001182FD File Offset: 0x001166FD
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002747 RID: 10055 RVA: 0x00118308 File Offset: 0x00116708
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		double killLifePercentage = 0.5;
		double killPossibility = 0.2;
		if (grade == QualityGrade.Rare)
		{
			killPossibility = 0.22;
		}
		if (grade == QualityGrade.Epic)
		{
			killPossibility = 0.24;
		}
		if (grade == QualityGrade.Legendary)
		{
			killPossibility = 0.26;
		}
		if (grade == QualityGrade.Ancient)
		{
			killPossibility = 0.28;
		}
		return new List<ISpecialEffectDataLoad>
		{
			new DeadMatchEffectData
			{
				KillLifePercentage = killLifePercentage,
				KillPossibility = killPossibility
			}
		};
	}

	// Token: 0x0400218F RID: 8591
	private ResourceType _itemType = ResourceType.DeadMatchTwo;

	// Token: 0x04002190 RID: 8592
	private int _itemLevel = 2;

	// Token: 0x04002191 RID: 8593
	private int _itemTierNumber = 9;
}
