using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000220 RID: 544
public class OnGoingItem : PageItem
{
	// Token: 0x06000E42 RID: 3650 RVA: 0x00091379 File Offset: 0x0008F779
	public OnGoingItem()
	{
	}

	// Token: 0x17000080 RID: 128
	// (get) Token: 0x06000E43 RID: 3651 RVA: 0x00091381 File Offset: 0x0008F781
	// (set) Token: 0x06000E44 RID: 3652 RVA: 0x00091389 File Offset: 0x0008F789
	public ProductionBuildingController BelongsToBuilding
	{
		[CompilerGenerated]
		get
		{
			return this.<BelongsToBuilding>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BelongsToBuilding>k__BackingField = value;
		}
	}

	// Token: 0x17000081 RID: 129
	// (get) Token: 0x06000E45 RID: 3653 RVA: 0x00091392 File Offset: 0x0008F792
	// (set) Token: 0x06000E46 RID: 3654 RVA: 0x0009139A File Offset: 0x0008F79A
	public RecipeInfo Recipe
	{
		[CompilerGenerated]
		get
		{
			return this.<Recipe>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Recipe>k__BackingField = value;
		}
	}

	// Token: 0x04000FF7 RID: 4087
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ProductionBuildingController <BelongsToBuilding>k__BackingField;

	// Token: 0x04000FF8 RID: 4088
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RecipeInfo <Recipe>k__BackingField;
}
