using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200051F RID: 1311
public class ResidentUpgradeChange
{
	// Token: 0x06002699 RID: 9881 RVA: 0x00113C29 File Offset: 0x00112029
	public ResidentUpgradeChange()
	{
	}

	// Token: 0x170002EA RID: 746
	// (get) Token: 0x0600269A RID: 9882 RVA: 0x00113C31 File Offset: 0x00112031
	// (set) Token: 0x0600269B RID: 9883 RVA: 0x00113C39 File Offset: 0x00112039
	public IResidentEffect OriginalEffect
	{
		[CompilerGenerated]
		get
		{
			return this.<OriginalEffect>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<OriginalEffect>k__BackingField = value;
		}
	}

	// Token: 0x170002EB RID: 747
	// (get) Token: 0x0600269C RID: 9884 RVA: 0x00113C42 File Offset: 0x00112042
	// (set) Token: 0x0600269D RID: 9885 RVA: 0x00113C4A File Offset: 0x0011204A
	public IResidentEffect UpdatedEffect
	{
		[CompilerGenerated]
		get
		{
			return this.<UpdatedEffect>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<UpdatedEffect>k__BackingField = value;
		}
	}

	// Token: 0x0600269E RID: 9886 RVA: 0x00113C53 File Offset: 0x00112053
	public bool Changed()
	{
		return this.OriginalEffect != this.UpdatedEffect;
	}

	// Token: 0x040020FF RID: 8447
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IResidentEffect <OriginalEffect>k__BackingField;

	// Token: 0x04002100 RID: 8448
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IResidentEffect <UpdatedEffect>k__BackingField;
}
