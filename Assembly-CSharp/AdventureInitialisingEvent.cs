using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004A0 RID: 1184
public class AdventureInitialisingEvent
{
	// Token: 0x06002348 RID: 9032 RVA: 0x00102D91 File Offset: 0x00101191
	public AdventureInitialisingEvent()
	{
	}

	// Token: 0x17000236 RID: 566
	// (get) Token: 0x06002349 RID: 9033 RVA: 0x00102D99 File Offset: 0x00101199
	// (set) Token: 0x0600234A RID: 9034 RVA: 0x00102DA1 File Offset: 0x001011A1
	public Adventure Adventure
	{
		[CompilerGenerated]
		get
		{
			return this.<Adventure>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Adventure>k__BackingField = value;
		}
	}

	// Token: 0x17000237 RID: 567
	// (get) Token: 0x0600234B RID: 9035 RVA: 0x00102DAA File Offset: 0x001011AA
	// (set) Token: 0x0600234C RID: 9036 RVA: 0x00102DB2 File Offset: 0x001011B2
	public GameWorld GameWorld
	{
		[CompilerGenerated]
		get
		{
			return this.<GameWorld>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<GameWorld>k__BackingField = value;
		}
	}

	// Token: 0x04001E56 RID: 7766
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Adventure <Adventure>k__BackingField;

	// Token: 0x04001E57 RID: 7767
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GameWorld <GameWorld>k__BackingField;
}
