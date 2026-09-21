using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000474 RID: 1140
[Serializable]
public class ResourceConsumptionRequirement
{
	// Token: 0x06002059 RID: 8281 RVA: 0x000E1477 File Offset: 0x000DF877
	public ResourceConsumptionRequirement()
	{
	}

	// Token: 0x17000210 RID: 528
	// (get) Token: 0x0600205A RID: 8282 RVA: 0x000E147F File Offset: 0x000DF87F
	// (set) Token: 0x0600205B RID: 8283 RVA: 0x000E1487 File Offset: 0x000DF887
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

	// Token: 0x17000211 RID: 529
	// (get) Token: 0x0600205C RID: 8284 RVA: 0x000E1490 File Offset: 0x000DF890
	// (set) Token: 0x0600205D RID: 8285 RVA: 0x000E1498 File Offset: 0x000DF898
	public int AmountRequired
	{
		[CompilerGenerated]
		get
		{
			return this.<AmountRequired>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AmountRequired>k__BackingField = value;
		}
	}

	// Token: 0x0600205E RID: 8286 RVA: 0x000E14A1 File Offset: 0x000DF8A1
	public bool MetRequirement()
	{
		return GameWorld.instance.PlayerProfile.GetResourceQuantity(this.ResourceType) >= (double)this.AmountRequired;
	}

	// Token: 0x04001CD7 RID: 7383
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <ResourceType>k__BackingField;

	// Token: 0x04001CD8 RID: 7384
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <AmountRequired>k__BackingField;
}
