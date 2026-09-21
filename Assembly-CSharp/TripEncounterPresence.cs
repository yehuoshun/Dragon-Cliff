using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020009BC RID: 2492
public class TripEncounterPresence : IPresentable
{
	// Token: 0x06004435 RID: 17461 RVA: 0x001BAC53 File Offset: 0x001B9053
	public TripEncounterPresence()
	{
	}

	// Token: 0x17000D98 RID: 3480
	// (get) Token: 0x06004436 RID: 17462 RVA: 0x001BAC5B File Offset: 0x001B905B
	// (set) Token: 0x06004437 RID: 17463 RVA: 0x001BAC63 File Offset: 0x001B9063
	public int Presence
	{
		[CompilerGenerated]
		get
		{
			return this.<Presence>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Presence>k__BackingField = value;
		}
	}

	// Token: 0x17000D99 RID: 3481
	// (get) Token: 0x06004438 RID: 17464 RVA: 0x001BAC6C File Offset: 0x001B906C
	// (set) Token: 0x06004439 RID: 17465 RVA: 0x001BAC74 File Offset: 0x001B9074
	public TripEncounterType TripEncounterType
	{
		[CompilerGenerated]
		get
		{
			return this.<TripEncounterType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<TripEncounterType>k__BackingField = value;
		}
	}

	// Token: 0x0600443A RID: 17466 RVA: 0x001BAC7D File Offset: 0x001B907D
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x04003380 RID: 13184
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Presence>k__BackingField;

	// Token: 0x04003381 RID: 13185
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TripEncounterType <TripEncounterType>k__BackingField;
}
