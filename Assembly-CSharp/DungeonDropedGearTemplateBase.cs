using System;
using System.Collections.Generic;

// Token: 0x020005E7 RID: 1511
public abstract class DungeonDropedGearTemplateBase : ItemTemplateBase
{
	// Token: 0x060029BC RID: 10684 RVA: 0x0011C367 File Offset: 0x0011A767
	protected DungeonDropedGearTemplateBase()
	{
	}

	// Token: 0x17000462 RID: 1122
	// (get) Token: 0x060029BD RID: 10685 RVA: 0x0011C370 File Offset: 0x0011A770
	public sealed override List<ResourceSourceType> ItemSourceTypes
	{
		get
		{
			return new List<ResourceSourceType>
			{
				ResourceSourceType.DungeonDrop
			};
		}
	}

	// Token: 0x17000463 RID: 1123
	// (get) Token: 0x060029BE RID: 10686 RVA: 0x0011C38B File Offset: 0x0011A78B
	public sealed override List<ResourceSourceType> RecipeSourceTypes
	{
		get
		{
			return new List<ResourceSourceType>();
		}
	}
}
