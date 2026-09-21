using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000228 RID: 552
public class PageItem : PageElement
{
	// Token: 0x06000E65 RID: 3685 RVA: 0x000904AC File Offset: 0x0008E8AC
	public PageItem()
	{
	}

	// Token: 0x17000087 RID: 135
	// (get) Token: 0x06000E66 RID: 3686 RVA: 0x000904B4 File Offset: 0x0008E8B4
	// (set) Token: 0x06000E67 RID: 3687 RVA: 0x000904BC File Offset: 0x0008E8BC
	public ResourceType ResourceType
	{
		[CompilerGenerated]
		get
		{
			return this.<ResourceType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ResourceType>k__BackingField = value;
		}
	}

	// Token: 0x17000088 RID: 136
	// (get) Token: 0x06000E68 RID: 3688 RVA: 0x000904C5 File Offset: 0x0008E8C5
	// (set) Token: 0x06000E69 RID: 3689 RVA: 0x000904CD File Offset: 0x0008E8CD
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

	// Token: 0x17000089 RID: 137
	// (get) Token: 0x06000E6A RID: 3690 RVA: 0x000904D6 File Offset: 0x0008E8D6
	// (set) Token: 0x06000E6B RID: 3691 RVA: 0x000904DE File Offset: 0x0008E8DE
	public string Description
	{
		[CompilerGenerated]
		get
		{
			return this.<Description>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Description>k__BackingField = value;
		}
	}

	// Token: 0x04001003 RID: 4099
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <ResourceType>k__BackingField;

	// Token: 0x04001004 RID: 4100
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Amount>k__BackingField;

	// Token: 0x04001005 RID: 4101
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Description>k__BackingField;
}
