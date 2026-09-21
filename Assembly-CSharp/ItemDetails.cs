using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200021C RID: 540
public class ItemDetails
{
	// Token: 0x06000E29 RID: 3625 RVA: 0x00091021 File Offset: 0x0008F421
	public ItemDetails()
	{
	}

	// Token: 0x17000079 RID: 121
	// (get) Token: 0x06000E2A RID: 3626 RVA: 0x00091029 File Offset: 0x0008F429
	// (set) Token: 0x06000E2B RID: 3627 RVA: 0x00091031 File Offset: 0x0008F431
	public ResourceType Type
	{
		[CompilerGenerated]
		get
		{
			return this.<Type>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Type>k__BackingField = value;
		}
	}

	// Token: 0x1700007A RID: 122
	// (get) Token: 0x06000E2C RID: 3628 RVA: 0x0009103A File Offset: 0x0008F43A
	// (set) Token: 0x06000E2D RID: 3629 RVA: 0x00091042 File Offset: 0x0008F442
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

	// Token: 0x1700007B RID: 123
	// (get) Token: 0x06000E2E RID: 3630 RVA: 0x0009104B File Offset: 0x0008F44B
	// (set) Token: 0x06000E2F RID: 3631 RVA: 0x00091053 File Offset: 0x0008F453
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

	// Token: 0x04000FED RID: 4077
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <Type>k__BackingField;

	// Token: 0x04000FEE RID: 4078
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Amount>k__BackingField;

	// Token: 0x04000FEF RID: 4079
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Description>k__BackingField;
}
