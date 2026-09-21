using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004A9 RID: 1193
public class GameDaysChangedEvent
{
	// Token: 0x06002370 RID: 9072 RVA: 0x00102EE1 File Offset: 0x001012E1
	public GameDaysChangedEvent()
	{
	}

	// Token: 0x17000246 RID: 582
	// (get) Token: 0x06002371 RID: 9073 RVA: 0x00102EE9 File Offset: 0x001012E9
	// (set) Token: 0x06002372 RID: 9074 RVA: 0x00102EF1 File Offset: 0x001012F1
	public int OriginalDay
	{
		[CompilerGenerated]
		get
		{
			return this.<OriginalDay>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<OriginalDay>k__BackingField = value;
		}
	}

	// Token: 0x17000247 RID: 583
	// (get) Token: 0x06002373 RID: 9075 RVA: 0x00102EFA File Offset: 0x001012FA
	// (set) Token: 0x06002374 RID: 9076 RVA: 0x00102F02 File Offset: 0x00101302
	public int NewDay
	{
		[CompilerGenerated]
		get
		{
			return this.<NewDay>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NewDay>k__BackingField = value;
		}
	}

	// Token: 0x04001E69 RID: 7785
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <OriginalDay>k__BackingField;

	// Token: 0x04001E6A RID: 7786
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <NewDay>k__BackingField;
}
