using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000196 RID: 406
public class QuickCombineItem
{
	// Token: 0x06000AC7 RID: 2759 RVA: 0x0008306A File Offset: 0x0008146A
	public QuickCombineItem()
	{
	}

	// Token: 0x17000040 RID: 64
	// (get) Token: 0x06000AC8 RID: 2760 RVA: 0x00083072 File Offset: 0x00081472
	// (set) Token: 0x06000AC9 RID: 2761 RVA: 0x0008307A File Offset: 0x0008147A
	public ResourceType Resource
	{
		[CompilerGenerated]
		get
		{
			return this.<Resource>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Resource>k__BackingField = value;
		}
	}

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x06000ACA RID: 2762 RVA: 0x00083083 File Offset: 0x00081483
	// (set) Token: 0x06000ACB RID: 2763 RVA: 0x0008308B File Offset: 0x0008148B
	public QualityGrade Grade
	{
		[CompilerGenerated]
		get
		{
			return this.<Grade>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Grade>k__BackingField = value;
		}
	}

	// Token: 0x17000042 RID: 66
	// (get) Token: 0x06000ACC RID: 2764 RVA: 0x00083094 File Offset: 0x00081494
	// (set) Token: 0x06000ACD RID: 2765 RVA: 0x0008309C File Offset: 0x0008149C
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

	// Token: 0x17000043 RID: 67
	// (get) Token: 0x06000ACE RID: 2766 RVA: 0x000830A5 File Offset: 0x000814A5
	// (set) Token: 0x06000ACF RID: 2767 RVA: 0x000830AD File Offset: 0x000814AD
	public int Amount
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

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x000830B6 File Offset: 0x000814B6
	// (set) Token: 0x06000AD1 RID: 2769 RVA: 0x000830BE File Offset: 0x000814BE
	public bool InsufficientAmount
	{
		[CompilerGenerated]
		get
		{
			return this.<InsufficientAmount>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<InsufficientAmount>k__BackingField = value;
		}
	}

	// Token: 0x04000D66 RID: 3430
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <Resource>k__BackingField;

	// Token: 0x04000D67 RID: 3431
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private QualityGrade <Grade>k__BackingField;

	// Token: 0x04000D68 RID: 3432
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Level>k__BackingField;

	// Token: 0x04000D69 RID: 3433
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Amount>k__BackingField;

	// Token: 0x04000D6A RID: 3434
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <InsufficientAmount>k__BackingField;
}
