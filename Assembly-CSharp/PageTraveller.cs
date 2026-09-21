using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020002A7 RID: 679
public class PageTraveller : PageElement
{
	// Token: 0x0600123F RID: 4671 RVA: 0x0009D8DF File Offset: 0x0009BCDF
	public PageTraveller()
	{
	}

	// Token: 0x170000CA RID: 202
	// (get) Token: 0x06001240 RID: 4672 RVA: 0x0009D8E7 File Offset: 0x0009BCE7
	// (set) Token: 0x06001241 RID: 4673 RVA: 0x0009D8EF File Offset: 0x0009BCEF
	public bool Picked
	{
		[CompilerGenerated]
		get
		{
			return this.<Picked>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Picked>k__BackingField = value;
		}
	}

	// Token: 0x170000CB RID: 203
	// (get) Token: 0x06001242 RID: 4674 RVA: 0x0009D8F8 File Offset: 0x0009BCF8
	// (set) Token: 0x06001243 RID: 4675 RVA: 0x0009D900 File Offset: 0x0009BD00
	public ITraveller Traveller
	{
		[CompilerGenerated]
		get
		{
			return this.<Traveller>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Traveller>k__BackingField = value;
		}
	}

	// Token: 0x04001308 RID: 4872
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <Picked>k__BackingField;

	// Token: 0x04001309 RID: 4873
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ITraveller <Traveller>k__BackingField;
}
