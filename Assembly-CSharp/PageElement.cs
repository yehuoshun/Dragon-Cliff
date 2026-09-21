using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000224 RID: 548
public class PageElement
{
	// Token: 0x06000E57 RID: 3671 RVA: 0x00090461 File Offset: 0x0008E861
	public PageElement()
	{
	}

	// Token: 0x17000083 RID: 131
	// (get) Token: 0x06000E58 RID: 3672 RVA: 0x00090469 File Offset: 0x0008E869
	// (set) Token: 0x06000E59 RID: 3673 RVA: 0x00090471 File Offset: 0x0008E871
	public string Id
	{
		[CompilerGenerated]
		get
		{
			return this.<Id>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Id>k__BackingField = value;
		}
	}

	// Token: 0x04000FFF RID: 4095
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Id>k__BackingField;
}
