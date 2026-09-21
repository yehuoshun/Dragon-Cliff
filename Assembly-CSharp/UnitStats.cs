using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000468 RID: 1128
public class UnitStats
{
	// Token: 0x06002009 RID: 8201 RVA: 0x000E0295 File Offset: 0x000DE695
	public UnitStats()
	{
	}

	// Token: 0x170001FE RID: 510
	// (get) Token: 0x0600200A RID: 8202 RVA: 0x000E029D File Offset: 0x000DE69D
	// (set) Token: 0x0600200B RID: 8203 RVA: 0x000E02A5 File Offset: 0x000DE6A5
	public BattleUnitStatus Status
	{
		[CompilerGenerated]
		get
		{
			return this.<Status>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Status>k__BackingField = value;
		}
	}

	// Token: 0x170001FF RID: 511
	// (get) Token: 0x0600200C RID: 8204 RVA: 0x000E02AE File Offset: 0x000DE6AE
	// (set) Token: 0x0600200D RID: 8205 RVA: 0x000E02B6 File Offset: 0x000DE6B6
	public double MaxLife
	{
		[CompilerGenerated]
		get
		{
			return this.<MaxLife>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<MaxLife>k__BackingField = value;
		}
	}

	// Token: 0x17000200 RID: 512
	// (get) Token: 0x0600200E RID: 8206 RVA: 0x000E02BF File Offset: 0x000DE6BF
	// (set) Token: 0x0600200F RID: 8207 RVA: 0x000E02C7 File Offset: 0x000DE6C7
	public double CurrentLife
	{
		[CompilerGenerated]
		get
		{
			return this.<CurrentLife>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CurrentLife>k__BackingField = value;
		}
	}

	// Token: 0x17000201 RID: 513
	// (get) Token: 0x06002010 RID: 8208 RVA: 0x000E02D0 File Offset: 0x000DE6D0
	// (set) Token: 0x06002011 RID: 8209 RVA: 0x000E02D8 File Offset: 0x000DE6D8
	public IBattleUnit CorrespondingUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<CorrespondingUnit>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CorrespondingUnit>k__BackingField = value;
		}
	}

	// Token: 0x04001C9A RID: 7322
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BattleUnitStatus <Status>k__BackingField;

	// Token: 0x04001C9B RID: 7323
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <MaxLife>k__BackingField;

	// Token: 0x04001C9C RID: 7324
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <CurrentLife>k__BackingField;

	// Token: 0x04001C9D RID: 7325
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <CorrespondingUnit>k__BackingField;
}
