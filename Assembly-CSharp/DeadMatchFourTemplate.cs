using System;
using System.Collections.Generic;

// Token: 0x02000544 RID: 1348
public class DeadMatchFourTemplate : AccessoryTemplateBase
{
	// Token: 0x06002738 RID: 10040 RVA: 0x001180B6 File Offset: 0x001164B6
	public DeadMatchFourTemplate()
	{
	}

	// Token: 0x1700031B RID: 795
	// (get) Token: 0x06002739 RID: 10041 RVA: 0x001180D1 File Offset: 0x001164D1
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700031C RID: 796
	// (get) Token: 0x0600273A RID: 10042 RVA: 0x001180D9 File Offset: 0x001164D9
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600273B RID: 10043 RVA: 0x001180E4 File Offset: 0x001164E4
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		double killLifePercentage = 0.5;
		double killPossibility = 0.4;
		if (grade == QualityGrade.Rare)
		{
			killPossibility = 0.42;
		}
		if (grade == QualityGrade.Epic)
		{
			killPossibility = 0.44;
		}
		if (grade == QualityGrade.Legendary)
		{
			killPossibility = 0.46;
		}
		if (grade == QualityGrade.Ancient)
		{
			killPossibility = 0.48;
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

	// Token: 0x04002189 RID: 8585
	private ResourceType _itemType = ResourceType.DeadMatchFour;

	// Token: 0x0400218A RID: 8586
	private int _itemTierNumber = 19;
}
