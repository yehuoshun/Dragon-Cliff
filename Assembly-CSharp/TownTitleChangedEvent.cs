using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004BC RID: 1212
public class TownTitleChangedEvent
{
	// Token: 0x060023D1 RID: 9169 RVA: 0x00103211 File Offset: 0x00101611
	public TownTitleChangedEvent()
	{
	}

	// Token: 0x1700026E RID: 622
	// (get) Token: 0x060023D2 RID: 9170 RVA: 0x00103219 File Offset: 0x00101619
	// (set) Token: 0x060023D3 RID: 9171 RVA: 0x00103221 File Offset: 0x00101621
	public TownTitleType OriginalTitle
	{
		[CompilerGenerated]
		get
		{
			return this.<OriginalTitle>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<OriginalTitle>k__BackingField = value;
		}
	}

	// Token: 0x1700026F RID: 623
	// (get) Token: 0x060023D4 RID: 9172 RVA: 0x0010322A File Offset: 0x0010162A
	// (set) Token: 0x060023D5 RID: 9173 RVA: 0x00103232 File Offset: 0x00101632
	public TownTitleType UpdatedTitle
	{
		[CompilerGenerated]
		get
		{
			return this.<UpdatedTitle>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<UpdatedTitle>k__BackingField = value;
		}
	}

	// Token: 0x04001EF6 RID: 7926
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TownTitleType <OriginalTitle>k__BackingField;

	// Token: 0x04001EF7 RID: 7927
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TownTitleType <UpdatedTitle>k__BackingField;
}
