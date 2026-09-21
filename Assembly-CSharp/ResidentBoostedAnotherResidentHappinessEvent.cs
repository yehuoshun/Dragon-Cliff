using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004B1 RID: 1201
public class ResidentBoostedAnotherResidentHappinessEvent
{
	// Token: 0x06002399 RID: 9113 RVA: 0x0010303A File Offset: 0x0010143A
	public ResidentBoostedAnotherResidentHappinessEvent()
	{
	}

	// Token: 0x17000257 RID: 599
	// (get) Token: 0x0600239A RID: 9114 RVA: 0x00103042 File Offset: 0x00101442
	// (set) Token: 0x0600239B RID: 9115 RVA: 0x0010304A File Offset: 0x0010144A
	public Resident From
	{
		[CompilerGenerated]
		get
		{
			return this.<From>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<From>k__BackingField = value;
		}
	}

	// Token: 0x17000258 RID: 600
	// (get) Token: 0x0600239C RID: 9116 RVA: 0x00103053 File Offset: 0x00101453
	// (set) Token: 0x0600239D RID: 9117 RVA: 0x0010305B File Offset: 0x0010145B
	public Resident To
	{
		[CompilerGenerated]
		get
		{
			return this.<To>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<To>k__BackingField = value;
		}
	}

	// Token: 0x17000259 RID: 601
	// (get) Token: 0x0600239E RID: 9118 RVA: 0x00103064 File Offset: 0x00101464
	// (set) Token: 0x0600239F RID: 9119 RVA: 0x0010306C File Offset: 0x0010146C
	public double Value
	{
		[CompilerGenerated]
		get
		{
			return this.<Value>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Value>k__BackingField = value;
		}
	}

	// Token: 0x04001ED8 RID: 7896
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Resident <From>k__BackingField;

	// Token: 0x04001ED9 RID: 7897
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Resident <To>k__BackingField;

	// Token: 0x04001EDA RID: 7898
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Value>k__BackingField;
}
