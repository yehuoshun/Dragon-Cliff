using System;
using System.Collections.Generic;

// Token: 0x02000579 RID: 1401
public abstract class AccessoryTemplateBase : ItemTemplateBase
{
	// Token: 0x06002839 RID: 10297 RVA: 0x0011758C File Offset: 0x0011598C
	protected AccessoryTemplateBase()
	{
	}

	// Token: 0x17000385 RID: 901
	// (get) Token: 0x0600283A RID: 10298 RVA: 0x00117594 File Offset: 0x00115994
	public override List<ResourceSourceType> ItemSourceTypes
	{
		get
		{
			return new List<ResourceSourceType>
			{
				ResourceSourceType.ShopPurchase
			};
		}
	}

	// Token: 0x17000386 RID: 902
	// (get) Token: 0x0600283B RID: 10299 RVA: 0x001175AF File Offset: 0x001159AF
	public override List<ResourceSourceType> RecipeSourceTypes
	{
		get
		{
			return new List<ResourceSourceType>();
		}
	}

	// Token: 0x17000387 RID: 903
	// (get) Token: 0x0600283C RID: 10300 RVA: 0x001175B6 File Offset: 0x001159B6
	public override int DefaultItemDropPresences
	{
		get
		{
			return 100;
		}
	}

	// Token: 0x0600283D RID: 10301 RVA: 0x001175BA File Offset: 0x001159BA
	public virtual List<ISpecialEffectDataLoad> GenerateStarEffects(QualityGrade grade, int itemTierNumber)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x0600283E RID: 10302 RVA: 0x001175C4 File Offset: 0x001159C4
	public override float GetValueBase(int itemTier)
	{
		int num = base.ItemLevel(itemTier);
		if (num < 8)
		{
			return (float)(500 + num * 500);
		}
		return (float)(10000 + (num - 8) * 5000);
	}
}
