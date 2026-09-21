using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200022B RID: 555
public class PageResident : PageElement
{
	// Token: 0x06000E73 RID: 3699 RVA: 0x0009154C File Offset: 0x0008F94C
	public PageResident()
	{
	}

	// Token: 0x1700008B RID: 139
	// (get) Token: 0x06000E74 RID: 3700 RVA: 0x00091554 File Offset: 0x0008F954
	// (set) Token: 0x06000E75 RID: 3701 RVA: 0x0009155C File Offset: 0x0008F95C
	public Resident Resident
	{
		[CompilerGenerated]
		get
		{
			return this.<Resident>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Resident>k__BackingField = value;
		}
	}

	// Token: 0x04001009 RID: 4105
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Resident <Resident>k__BackingField;
}
