using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004B0 RID: 1200
public class ReputationChangedEvent
{
	// Token: 0x06002392 RID: 9106 RVA: 0x00102FFF File Offset: 0x001013FF
	public ReputationChangedEvent()
	{
	}

	// Token: 0x17000254 RID: 596
	// (get) Token: 0x06002393 RID: 9107 RVA: 0x00103007 File Offset: 0x00101407
	// (set) Token: 0x06002394 RID: 9108 RVA: 0x0010300F File Offset: 0x0010140F
	public double Original
	{
		[CompilerGenerated]
		get
		{
			return this.<Original>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Original>k__BackingField = value;
		}
	}

	// Token: 0x17000255 RID: 597
	// (get) Token: 0x06002395 RID: 9109 RVA: 0x00103018 File Offset: 0x00101418
	// (set) Token: 0x06002396 RID: 9110 RVA: 0x00103020 File Offset: 0x00101420
	public double Resulted
	{
		[CompilerGenerated]
		get
		{
			return this.<Resulted>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Resulted>k__BackingField = value;
		}
	}

	// Token: 0x17000256 RID: 598
	// (get) Token: 0x06002397 RID: 9111 RVA: 0x00103029 File Offset: 0x00101429
	// (set) Token: 0x06002398 RID: 9112 RVA: 0x00103031 File Offset: 0x00101431
	public double Amount
	{
		[CompilerGenerated]
		get
		{
			return this.<Amount>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Amount>k__BackingField = value;
		}
	}

	// Token: 0x04001ED5 RID: 7893
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Original>k__BackingField;

	// Token: 0x04001ED6 RID: 7894
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Resulted>k__BackingField;

	// Token: 0x04001ED7 RID: 7895
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Amount>k__BackingField;
}
