using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004AD RID: 1197
public class MoneySpentEvent
{
	// Token: 0x06002381 RID: 9089 RVA: 0x00102F70 File Offset: 0x00101370
	public MoneySpentEvent()
	{
	}

	// Token: 0x1700024D RID: 589
	// (get) Token: 0x06002382 RID: 9090 RVA: 0x00102F78 File Offset: 0x00101378
	// (set) Token: 0x06002383 RID: 9091 RVA: 0x00102F80 File Offset: 0x00101380
	public double OriginalAmount
	{
		[CompilerGenerated]
		get
		{
			return this.<OriginalAmount>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<OriginalAmount>k__BackingField = value;
		}
	}

	// Token: 0x1700024E RID: 590
	// (get) Token: 0x06002384 RID: 9092 RVA: 0x00102F89 File Offset: 0x00101389
	// (set) Token: 0x06002385 RID: 9093 RVA: 0x00102F91 File Offset: 0x00101391
	public double ResultedAmount
	{
		[CompilerGenerated]
		get
		{
			return this.<ResultedAmount>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ResultedAmount>k__BackingField = value;
		}
	}

	// Token: 0x1700024F RID: 591
	// (get) Token: 0x06002386 RID: 9094 RVA: 0x00102F9A File Offset: 0x0010139A
	// (set) Token: 0x06002387 RID: 9095 RVA: 0x00102FA2 File Offset: 0x001013A2
	public double SpentAmount
	{
		[CompilerGenerated]
		get
		{
			return this.<SpentAmount>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SpentAmount>k__BackingField = value;
		}
	}

	// Token: 0x04001ECE RID: 7886
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <OriginalAmount>k__BackingField;

	// Token: 0x04001ECF RID: 7887
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <ResultedAmount>k__BackingField;

	// Token: 0x04001ED0 RID: 7888
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <SpentAmount>k__BackingField;
}
