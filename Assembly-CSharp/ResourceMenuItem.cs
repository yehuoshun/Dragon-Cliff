using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000288 RID: 648
public class ResourceMenuItem
{
	// Token: 0x06001142 RID: 4418 RVA: 0x0009A439 File Offset: 0x00098839
	public ResourceMenuItem()
	{
	}

	// Token: 0x170000C2 RID: 194
	// (get) Token: 0x06001143 RID: 4419 RVA: 0x0009A441 File Offset: 0x00098841
	// (set) Token: 0x06001144 RID: 4420 RVA: 0x0009A449 File Offset: 0x00098849
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

	// Token: 0x170000C3 RID: 195
	// (get) Token: 0x06001145 RID: 4421 RVA: 0x0009A452 File Offset: 0x00098852
	// (set) Token: 0x06001146 RID: 4422 RVA: 0x0009A45A File Offset: 0x0009885A
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

	// Token: 0x0400121E RID: 4638
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <Type>k__BackingField;

	// Token: 0x0400121F RID: 4639
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Amount>k__BackingField;
}
