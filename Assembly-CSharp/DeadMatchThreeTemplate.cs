using System;
using System.Collections.Generic;

// Token: 0x02000546 RID: 1350
public class DeadMatchThreeTemplate : AccessoryTemplateBase
{
	// Token: 0x06002740 RID: 10048 RVA: 0x0011821F File Offset: 0x0011661F
	public DeadMatchThreeTemplate()
	{
	}

	// Token: 0x1700031F RID: 799
	// (get) Token: 0x06002741 RID: 10049 RVA: 0x0011823A File Offset: 0x0011663A
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000320 RID: 800
	// (get) Token: 0x06002742 RID: 10050 RVA: 0x00118242 File Offset: 0x00116642
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002743 RID: 10051 RVA: 0x0011824C File Offset: 0x0011664C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		double killLifePercentage = 0.5;
		double killPossibility = 0.3;
		if (grade == QualityGrade.Rare)
		{
			killPossibility = 0.32;
		}
		if (grade == QualityGrade.Epic)
		{
			killPossibility = 0.34;
		}
		if (grade == QualityGrade.Legendary)
		{
			killPossibility = 0.36;
		}
		if (grade == QualityGrade.Ancient)
		{
			killPossibility = 0.38;
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

	// Token: 0x0400218D RID: 8589
	private ResourceType _itemType = ResourceType.DeadMatchThree;

	// Token: 0x0400218E RID: 8590
	private int _itemTierNumber = 14;
}
