using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200047D RID: 1149
public class WorkProgress
{
	// Token: 0x060020BE RID: 8382 RVA: 0x000E2DC4 File Offset: 0x000E11C4
	public WorkProgress()
	{
	}

	// Token: 0x17000222 RID: 546
	// (get) Token: 0x060020BF RID: 8383 RVA: 0x000E2DCC File Offset: 0x000E11CC
	// (set) Token: 0x060020C0 RID: 8384 RVA: 0x000E2DD4 File Offset: 0x000E11D4
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

	// Token: 0x17000223 RID: 547
	// (get) Token: 0x060020C1 RID: 8385 RVA: 0x000E2DDD File Offset: 0x000E11DD
	// (set) Token: 0x060020C2 RID: 8386 RVA: 0x000E2DE5 File Offset: 0x000E11E5
	public double Progress
	{
		[CompilerGenerated]
		get
		{
			return this.<Progress>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Progress>k__BackingField = value;
		}
	}

	// Token: 0x04001D05 RID: 7429
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <ProductType>k__BackingField;

	// Token: 0x04001D06 RID: 7430
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Progress>k__BackingField;
}
