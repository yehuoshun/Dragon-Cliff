using System;
using System.Collections.Generic;

// Token: 0x020005E6 RID: 1510
public abstract class ConsumableTemplateBase : ItemTemplateBase
{
	// Token: 0x060029B8 RID: 10680 RVA: 0x0011BE41 File Offset: 0x0011A241
	protected ConsumableTemplateBase()
	{
	}

	// Token: 0x17000460 RID: 1120
	// (get) Token: 0x060029B9 RID: 10681 RVA: 0x0011BE4C File Offset: 0x0011A24C
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

	// Token: 0x17000461 RID: 1121
	// (get) Token: 0x060029BA RID: 10682 RVA: 0x0011BE67 File Offset: 0x0011A267
	public override List<ResourceSourceType> RecipeSourceTypes
	{
		get
		{
			return new List<ResourceSourceType>();
		}
	}

	// Token: 0x060029BB RID: 10683 RVA: 0x0011BE70 File Offset: 0x0011A270
	public sealed override float GetValueBase(int itemTier)
	{
		int num = base.ItemLevel(itemTier);
		if (num == 1)
		{
			return 200f;
		}
		if (num == 2)
		{
			return 400f;
		}
		if (num == 3)
		{
			return 800f;
		}
		if (num == 4)
		{
			return 1600f;
		}
		if (num == 5)
		{
			return 3200f;
		}
		if (num == 6)
		{
			return 6400f;
		}
		return 15000f;
	}
}
