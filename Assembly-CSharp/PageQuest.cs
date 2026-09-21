using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200022A RID: 554
public class PageQuest : PageElement
{
	// Token: 0x06000E70 RID: 3696 RVA: 0x00091533 File Offset: 0x0008F933
	public PageQuest()
	{
	}

	// Token: 0x1700008A RID: 138
	// (get) Token: 0x06000E71 RID: 3697 RVA: 0x0009153B File Offset: 0x0008F93B
	// (set) Token: 0x06000E72 RID: 3698 RVA: 0x00091543 File Offset: 0x0008F943
	public Quest Quest
	{
		[CompilerGenerated]
		get
		{
			return this.<Quest>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Quest>k__BackingField = value;
		}
	}

	// Token: 0x04001008 RID: 4104
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Quest <Quest>k__BackingField;
}
