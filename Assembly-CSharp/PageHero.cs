using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000226 RID: 550
public class PageHero : PageElement
{
	// Token: 0x06000E5E RID: 3678 RVA: 0x0009151A File Offset: 0x0008F91A
	public PageHero()
	{
	}

	// Token: 0x17000085 RID: 133
	// (get) Token: 0x06000E5F RID: 3679 RVA: 0x00091522 File Offset: 0x0008F922
	// (set) Token: 0x06000E60 RID: 3680 RVA: 0x0009152A File Offset: 0x0008F92A
	public AdventurerProfile AdventurerProfile
	{
		[CompilerGenerated]
		get
		{
			return this.<AdventurerProfile>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AdventurerProfile>k__BackingField = value;
		}
	}

	// Token: 0x04001001 RID: 4097
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerProfile <AdventurerProfile>k__BackingField;
}
