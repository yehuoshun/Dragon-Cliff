using System;
using System.Collections.Generic;

// Token: 0x020005EC RID: 1516
public abstract class RecipeProducedGearTemplateBase : ItemTemplateBase
{
	// Token: 0x060029DB RID: 10715 RVA: 0x0011A95E File Offset: 0x00118D5E
	protected RecipeProducedGearTemplateBase()
	{
	}

	// Token: 0x1700046C RID: 1132
	// (get) Token: 0x060029DC RID: 10716 RVA: 0x0011A968 File Offset: 0x00118D68
	public sealed override List<ResourceSourceType> ItemSourceTypes
	{
		get
		{
			return new List<ResourceSourceType>
			{
				ResourceSourceType.BuildingProduction
			};
		}
	}

	// Token: 0x1700046D RID: 1133
	// (get) Token: 0x060029DD RID: 10717 RVA: 0x0011A984 File Offset: 0x00118D84
	public sealed override List<ResourceSourceType> RecipeSourceTypes
	{
		get
		{
			return new List<ResourceSourceType>
			{
				ResourceSourceType.DungeonDrop
			};
		}
	}
}
