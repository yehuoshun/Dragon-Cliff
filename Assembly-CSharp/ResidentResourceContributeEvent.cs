using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004B4 RID: 1204
public class ResidentResourceContributeEvent
{
	// Token: 0x060023AA RID: 9130 RVA: 0x001030C9 File Offset: 0x001014C9
	public ResidentResourceContributeEvent()
	{
	}

	// Token: 0x1700025E RID: 606
	// (get) Token: 0x060023AB RID: 9131 RVA: 0x001030D1 File Offset: 0x001014D1
	// (set) Token: 0x060023AC RID: 9132 RVA: 0x001030D9 File Offset: 0x001014D9
	public List<ResourceUpdate> ResourceUpdates
	{
		[CompilerGenerated]
		get
		{
			return this.<ResourceUpdates>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ResourceUpdates>k__BackingField = value;
		}
	}

	// Token: 0x1700025F RID: 607
	// (get) Token: 0x060023AD RID: 9133 RVA: 0x001030E2 File Offset: 0x001014E2
	// (set) Token: 0x060023AE RID: 9134 RVA: 0x001030EA File Offset: 0x001014EA
	public Resident Contributor
	{
		[CompilerGenerated]
		get
		{
			return this.<Contributor>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Contributor>k__BackingField = value;
		}
	}

	// Token: 0x04001EDF RID: 7903
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ResourceUpdate> <ResourceUpdates>k__BackingField;

	// Token: 0x04001EE0 RID: 7904
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Resident <Contributor>k__BackingField;
}
