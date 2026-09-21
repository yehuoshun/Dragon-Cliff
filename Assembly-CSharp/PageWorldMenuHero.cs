using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020002F5 RID: 757
public class PageWorldMenuHero : PageHero
{
	// Token: 0x0600140A RID: 5130 RVA: 0x000A5565 File Offset: 0x000A3965
	public PageWorldMenuHero()
	{
	}

	// Token: 0x170000F1 RID: 241
	// (get) Token: 0x0600140B RID: 5131 RVA: 0x000A556D File Offset: 0x000A396D
	// (set) Token: 0x0600140C RID: 5132 RVA: 0x000A5575 File Offset: 0x000A3975
	public bool Selected
	{
		[CompilerGenerated]
		get
		{
			return this.<Selected>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Selected>k__BackingField = value;
		}
	}

	// Token: 0x0400145E RID: 5214
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <Selected>k__BackingField;
}
