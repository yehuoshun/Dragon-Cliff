using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000470 RID: 1136
public class Product
{
	// Token: 0x06002027 RID: 8231 RVA: 0x000E0420 File Offset: 0x000DE820
	public Product()
	{
	}

	// Token: 0x1700020A RID: 522
	// (get) Token: 0x06002028 RID: 8232 RVA: 0x000E0428 File Offset: 0x000DE828
	// (set) Token: 0x06002029 RID: 8233 RVA: 0x000E0430 File Offset: 0x000DE830
	public bool Success
	{
		[CompilerGenerated]
		get
		{
			return this.<Success>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Success>k__BackingField = value;
		}
	}

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x0600202A RID: 8234 RVA: 0x000E0439 File Offset: 0x000DE839
	// (set) Token: 0x0600202B RID: 8235 RVA: 0x000E0441 File Offset: 0x000DE841
	public ResourceType ProductType
	{
		[CompilerGenerated]
		get
		{
			return this.<ProductType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ProductType>k__BackingField = value;
		}
	}

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x0600202C RID: 8236 RVA: 0x000E044A File Offset: 0x000DE84A
	// (set) Token: 0x0600202D RID: 8237 RVA: 0x000E0452 File Offset: 0x000DE852
	public List<Item> RelatedItems
	{
		[CompilerGenerated]
		get
		{
			return this.<RelatedItems>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<RelatedItems>k__BackingField = value;
		}
	}

	// Token: 0x1700020D RID: 525
	// (get) Token: 0x0600202E RID: 8238 RVA: 0x000E045B File Offset: 0x000DE85B
	// (set) Token: 0x0600202F RID: 8239 RVA: 0x000E0463 File Offset: 0x000DE863
	public Recipe SourceRecipe
	{
		[CompilerGenerated]
		get
		{
			return this.<SourceRecipe>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SourceRecipe>k__BackingField = value;
		}
	}

	// Token: 0x04001CB2 RID: 7346
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <Success>k__BackingField;

	// Token: 0x04001CB3 RID: 7347
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <ProductType>k__BackingField;

	// Token: 0x04001CB4 RID: 7348
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Item> <RelatedItems>k__BackingField;

	// Token: 0x04001CB5 RID: 7349
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Recipe <SourceRecipe>k__BackingField;
}
