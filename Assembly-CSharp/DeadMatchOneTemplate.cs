using System;
using System.Collections.Generic;

// Token: 0x02000545 RID: 1349
public class DeadMatchOneTemplate : AccessoryTemplateBase
{
	// Token: 0x0600273C RID: 10044 RVA: 0x0011816B File Offset: 0x0011656B
	public DeadMatchOneTemplate()
	{
	}

	// Token: 0x1700031D RID: 797
	// (get) Token: 0x0600273D RID: 10045 RVA: 0x00118185 File Offset: 0x00116585
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700031E RID: 798
	// (get) Token: 0x0600273E RID: 10046 RVA: 0x0011818D File Offset: 0x0011658D
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600273F RID: 10047 RVA: 0x00118198 File Offset: 0x00116598
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		double killLifePercentage = 0.5;
		double killPossibility = 0.1;
		if (grade == QualityGrade.Rare)
		{
			killPossibility = 0.12;
		}
		if (grade == QualityGrade.Epic)
		{
			killPossibility = 0.14;
		}
		if (grade == QualityGrade.Legendary)
		{
			killPossibility = 0.16;
		}
		if (grade == QualityGrade.Ancient)
		{
			killPossibility = 0.18;
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

	// Token: 0x0400218B RID: 8587
	private ResourceType _itemType = ResourceType.DeadMatchOne;

	// Token: 0x0400218C RID: 8588
	private int _itemTierNumber = 4;
}
