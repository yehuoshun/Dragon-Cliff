using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000210 RID: 528
public class BuildingItem : PageElement
{
	// Token: 0x06000DF4 RID: 3572 RVA: 0x0009047A File Offset: 0x0008E87A
	public BuildingItem()
	{
	}

	// Token: 0x17000071 RID: 113
	// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x00090482 File Offset: 0x0008E882
	// (set) Token: 0x06000DF6 RID: 3574 RVA: 0x0009048A File Offset: 0x0008E88A
	public BuildingType BuildingType
	{
		[CompilerGenerated]
		get
		{
			return this.<BuildingType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BuildingType>k__BackingField = value;
		}
	}

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x00090493 File Offset: 0x0008E893
	// (set) Token: 0x06000DF8 RID: 3576 RVA: 0x0009049B File Offset: 0x0008E89B
	public int Price
	{
		[CompilerGenerated]
		get
		{
			return this.<Price>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Price>k__BackingField = value;
		}
	}

	// Token: 0x04000FDD RID: 4061
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BuildingType <BuildingType>k__BackingField;

	// Token: 0x04000FDE RID: 4062
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Price>k__BackingField;
}
