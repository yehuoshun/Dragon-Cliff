using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004B2 RID: 1202
public class ResidentOccupancyUpdateEvent
{
	// Token: 0x060023A0 RID: 9120 RVA: 0x00103075 File Offset: 0x00101475
	public ResidentOccupancyUpdateEvent()
	{
	}

	// Token: 0x1700025A RID: 602
	// (get) Token: 0x060023A1 RID: 9121 RVA: 0x0010307D File Offset: 0x0010147D
	// (set) Token: 0x060023A2 RID: 9122 RVA: 0x00103085 File Offset: 0x00101485
	public int OriginalOccupancy
	{
		[CompilerGenerated]
		get
		{
			return this.<OriginalOccupancy>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<OriginalOccupancy>k__BackingField = value;
		}
	}

	// Token: 0x1700025B RID: 603
	// (get) Token: 0x060023A3 RID: 9123 RVA: 0x0010308E File Offset: 0x0010148E
	// (set) Token: 0x060023A4 RID: 9124 RVA: 0x00103096 File Offset: 0x00101496
	public int UpdatedToOccupancy
	{
		[CompilerGenerated]
		get
		{
			return this.<UpdatedToOccupancy>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<UpdatedToOccupancy>k__BackingField = value;
		}
	}

	// Token: 0x04001EDB RID: 7899
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <OriginalOccupancy>k__BackingField;

	// Token: 0x04001EDC RID: 7900
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <UpdatedToOccupancy>k__BackingField;
}
