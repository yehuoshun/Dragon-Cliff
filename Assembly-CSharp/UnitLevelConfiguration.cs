using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000B39 RID: 2873
public class UnitLevelConfiguration
{
	// Token: 0x06004C77 RID: 19575 RVA: 0x001F1F58 File Offset: 0x001F0358
	public UnitLevelConfiguration()
	{
	}

	// Token: 0x17001077 RID: 4215
	// (get) Token: 0x06004C78 RID: 19576 RVA: 0x001F1F60 File Offset: 0x001F0360
	// (set) Token: 0x06004C79 RID: 19577 RVA: 0x001F1F68 File Offset: 0x001F0368
	public int Level
	{
		[CompilerGenerated]
		get
		{
			return this.<Level>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Level>k__BackingField = value;
		}
	}

	// Token: 0x17001078 RID: 4216
	// (get) Token: 0x06004C7A RID: 19578 RVA: 0x001F1F71 File Offset: 0x001F0371
	// (set) Token: 0x06004C7B RID: 19579 RVA: 0x001F1F79 File Offset: 0x001F0379
	public int FromExp
	{
		[CompilerGenerated]
		get
		{
			return this.<FromExp>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<FromExp>k__BackingField = value;
		}
	}

	// Token: 0x17001079 RID: 4217
	// (get) Token: 0x06004C7C RID: 19580 RVA: 0x001F1F82 File Offset: 0x001F0382
	// (set) Token: 0x06004C7D RID: 19581 RVA: 0x001F1F8A File Offset: 0x001F038A
	public int ToExp
	{
		[CompilerGenerated]
		get
		{
			return this.<ToExp>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ToExp>k__BackingField = value;
		}
	}

	// Token: 0x04003AEC RID: 15084
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Level>k__BackingField;

	// Token: 0x04003AED RID: 15085
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <FromExp>k__BackingField;

	// Token: 0x04003AEE RID: 15086
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <ToExp>k__BackingField;
}
