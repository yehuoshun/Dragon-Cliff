using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004A7 RID: 1191
public class BuildingBuiltEvent
{
	// Token: 0x06002366 RID: 9062 RVA: 0x00102E8D File Offset: 0x0010128D
	public BuildingBuiltEvent()
	{
	}

	// Token: 0x17000242 RID: 578
	// (get) Token: 0x06002367 RID: 9063 RVA: 0x00102E95 File Offset: 0x00101295
	// (set) Token: 0x06002368 RID: 9064 RVA: 0x00102E9D File Offset: 0x0010129D
	public IBuildingProfile Building
	{
		[CompilerGenerated]
		get
		{
			return this.<Building>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Building>k__BackingField = value;
		}
	}

	// Token: 0x17000243 RID: 579
	// (get) Token: 0x06002369 RID: 9065 RVA: 0x00102EA6 File Offset: 0x001012A6
	// (set) Token: 0x0600236A RID: 9066 RVA: 0x00102EAE File Offset: 0x001012AE
	public TownSlot TownSlot
	{
		[CompilerGenerated]
		get
		{
			return this.<TownSlot>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<TownSlot>k__BackingField = value;
		}
	}

	// Token: 0x04001E65 RID: 7781
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBuildingProfile <Building>k__BackingField;

	// Token: 0x04001E66 RID: 7782
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TownSlot <TownSlot>k__BackingField;
}
