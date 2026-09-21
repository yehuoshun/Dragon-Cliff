using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200021F RID: 543
public class NormalItem : PageItem
{
	// Token: 0x06000E39 RID: 3641 RVA: 0x0009132D File Offset: 0x0008F72D
	public NormalItem()
	{
	}

	// Token: 0x1700007C RID: 124
	// (get) Token: 0x06000E3A RID: 3642 RVA: 0x00091335 File Offset: 0x0008F735
	// (set) Token: 0x06000E3B RID: 3643 RVA: 0x0009133D File Offset: 0x0008F73D
	public Item Item
	{
		[CompilerGenerated]
		get
		{
			return this.<Item>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Item>k__BackingField = value;
		}
	}

	// Token: 0x1700007D RID: 125
	// (get) Token: 0x06000E3C RID: 3644 RVA: 0x00091346 File Offset: 0x0008F746
	// (set) Token: 0x06000E3D RID: 3645 RVA: 0x0009134E File Offset: 0x0008F74E
	public QualityGrade ItemGrade
	{
		[CompilerGenerated]
		get
		{
			return this.<ItemGrade>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ItemGrade>k__BackingField = value;
		}
	}

	// Token: 0x1700007E RID: 126
	// (get) Token: 0x06000E3E RID: 3646 RVA: 0x00091357 File Offset: 0x0008F757
	// (set) Token: 0x06000E3F RID: 3647 RVA: 0x0009135F File Offset: 0x0008F75F
	public double Price
	{
		[CompilerGenerated]
		get
		{
			return this.<Price>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Price>k__BackingField = value;
		}
	}

	// Token: 0x1700007F RID: 127
	// (get) Token: 0x06000E40 RID: 3648 RVA: 0x00091368 File Offset: 0x0008F768
	// (set) Token: 0x06000E41 RID: 3649 RVA: 0x00091370 File Offset: 0x0008F770
	public Commodity Commodity
	{
		[CompilerGenerated]
		get
		{
			return this.<Commodity>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Commodity>k__BackingField = value;
		}
	}

	// Token: 0x04000FF3 RID: 4083
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Item <Item>k__BackingField;

	// Token: 0x04000FF4 RID: 4084
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private QualityGrade <ItemGrade>k__BackingField;

	// Token: 0x04000FF5 RID: 4085
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Price>k__BackingField;

	// Token: 0x04000FF6 RID: 4086
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Commodity <Commodity>k__BackingField;
}
