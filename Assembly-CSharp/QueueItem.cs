using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000231 RID: 561
public class QueueItem : PageItem
{
	// Token: 0x06000EA9 RID: 3753 RVA: 0x000918A2 File Offset: 0x0008FCA2
	public QueueItem()
	{
	}

	// Token: 0x17000092 RID: 146
	// (get) Token: 0x06000EAA RID: 3754 RVA: 0x000918AA File Offset: 0x0008FCAA
	// (set) Token: 0x06000EAB RID: 3755 RVA: 0x000918B2 File Offset: 0x0008FCB2
	public WorkQueue Queue
	{
		[CompilerGenerated]
		get
		{
			return this.<Queue>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Queue>k__BackingField = value;
		}
	}

	// Token: 0x17000093 RID: 147
	// (get) Token: 0x06000EAC RID: 3756 RVA: 0x000918BB File Offset: 0x0008FCBB
	// (set) Token: 0x06000EAD RID: 3757 RVA: 0x000918C3 File Offset: 0x0008FCC3
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

	// Token: 0x04001020 RID: 4128
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WorkQueue <Queue>k__BackingField;

	// Token: 0x04001021 RID: 4129
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ProductionBuildingController <BelongsToBuilding>k__BackingField;
}
