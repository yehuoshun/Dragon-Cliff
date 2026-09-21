using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004AE RID: 1198
public class PurchaseSuccessEvent
{
	// Token: 0x06002388 RID: 9096 RVA: 0x00102FAB File Offset: 0x001013AB
	public PurchaseSuccessEvent()
	{
	}

	// Token: 0x17000250 RID: 592
	// (get) Token: 0x06002389 RID: 9097 RVA: 0x00102FB3 File Offset: 0x001013B3
	// (set) Token: 0x0600238A RID: 9098 RVA: 0x00102FBB File Offset: 0x001013BB
	public Commodity Purchase
	{
		[CompilerGenerated]
		get
		{
			return this.<Purchase>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Purchase>k__BackingField = value;
		}
	}

	// Token: 0x17000251 RID: 593
	// (get) Token: 0x0600238B RID: 9099 RVA: 0x00102FC4 File Offset: 0x001013C4
	// (set) Token: 0x0600238C RID: 9100 RVA: 0x00102FCC File Offset: 0x001013CC
	public Shop Shop
	{
		[CompilerGenerated]
		get
		{
			return this.<Shop>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Shop>k__BackingField = value;
		}
	}

	// Token: 0x04001ED1 RID: 7889
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Commodity <Purchase>k__BackingField;

	// Token: 0x04001ED2 RID: 7890
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Shop <Shop>k__BackingField;
}
