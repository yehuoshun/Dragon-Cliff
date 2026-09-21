using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000218 RID: 536
public class GemItem : PageItem
{
	// Token: 0x06000E17 RID: 3607 RVA: 0x000909EB File Offset: 0x0008EDEB
	public GemItem()
	{
	}

	// Token: 0x17000077 RID: 119
	// (get) Token: 0x06000E18 RID: 3608 RVA: 0x000909F3 File Offset: 0x0008EDF3
	// (set) Token: 0x06000E19 RID: 3609 RVA: 0x000909FB File Offset: 0x0008EDFB
	public Item Gem
	{
		[CompilerGenerated]
		get
		{
			return this.<Gem>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Gem>k__BackingField = value;
		}
	}

	// Token: 0x04000FE8 RID: 4072
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Item <Gem>k__BackingField;
}
