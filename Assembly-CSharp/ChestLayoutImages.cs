using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000380 RID: 896
public class ChestLayoutImages
{
	// Token: 0x06001820 RID: 6176 RVA: 0x000B963B File Offset: 0x000B7A3B
	public ChestLayoutImages(string path, int normalIndex)
	{
		this.Path = path;
		this.Normal = normalIndex;
		this.Opening1 = normalIndex + 12;
		this.Opening2 = normalIndex + 24;
		this.Opening3 = normalIndex + 36;
	}

	// Token: 0x1700013B RID: 315
	// (get) Token: 0x06001821 RID: 6177 RVA: 0x000B966F File Offset: 0x000B7A6F
	// (set) Token: 0x06001822 RID: 6178 RVA: 0x000B9677 File Offset: 0x000B7A77
	public string Path
	{
		[CompilerGenerated]
		get
		{
			return this.<Path>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Path>k__BackingField = value;
		}
	}

	// Token: 0x1700013C RID: 316
	// (get) Token: 0x06001823 RID: 6179 RVA: 0x000B9680 File Offset: 0x000B7A80
	// (set) Token: 0x06001824 RID: 6180 RVA: 0x000B9688 File Offset: 0x000B7A88
	public int Normal
	{
		[CompilerGenerated]
		get
		{
			return this.<Normal>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Normal>k__BackingField = value;
		}
	}

	// Token: 0x1700013D RID: 317
	// (get) Token: 0x06001825 RID: 6181 RVA: 0x000B9691 File Offset: 0x000B7A91
	// (set) Token: 0x06001826 RID: 6182 RVA: 0x000B9699 File Offset: 0x000B7A99
	public int Opening1
	{
		[CompilerGenerated]
		get
		{
			return this.<Opening1>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Opening1>k__BackingField = value;
		}
	}

	// Token: 0x1700013E RID: 318
	// (get) Token: 0x06001827 RID: 6183 RVA: 0x000B96A2 File Offset: 0x000B7AA2
	// (set) Token: 0x06001828 RID: 6184 RVA: 0x000B96AA File Offset: 0x000B7AAA
	public int Opening2
	{
		[CompilerGenerated]
		get
		{
			return this.<Opening2>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Opening2>k__BackingField = value;
		}
	}

	// Token: 0x1700013F RID: 319
	// (get) Token: 0x06001829 RID: 6185 RVA: 0x000B96B3 File Offset: 0x000B7AB3
	// (set) Token: 0x0600182A RID: 6186 RVA: 0x000B96BB File Offset: 0x000B7ABB
	public int Opening3
	{
		[CompilerGenerated]
		get
		{
			return this.<Opening3>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Opening3>k__BackingField = value;
		}
	}

	// Token: 0x040017E4 RID: 6116
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Path>k__BackingField;

	// Token: 0x040017E5 RID: 6117
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Normal>k__BackingField;

	// Token: 0x040017E6 RID: 6118
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Opening1>k__BackingField;

	// Token: 0x040017E7 RID: 6119
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Opening2>k__BackingField;

	// Token: 0x040017E8 RID: 6120
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Opening3>k__BackingField;
}
