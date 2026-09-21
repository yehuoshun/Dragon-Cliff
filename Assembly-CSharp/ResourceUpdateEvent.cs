using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004B6 RID: 1206
public class ResourceUpdateEvent
{
	// Token: 0x060023B8 RID: 9144 RVA: 0x0010313F File Offset: 0x0010153F
	public ResourceUpdateEvent()
	{
	}

	// Token: 0x17000264 RID: 612
	// (get) Token: 0x060023B9 RID: 9145 RVA: 0x00103147 File Offset: 0x00101547
	// (set) Token: 0x060023BA RID: 9146 RVA: 0x0010314F File Offset: 0x0010154F
	public double OriginalAmount
	{
		[CompilerGenerated]
		get
		{
			return this.<OriginalAmount>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<OriginalAmount>k__BackingField = value;
		}
	}

	// Token: 0x17000265 RID: 613
	// (get) Token: 0x060023BB RID: 9147 RVA: 0x00103158 File Offset: 0x00101558
	// (set) Token: 0x060023BC RID: 9148 RVA: 0x00103160 File Offset: 0x00101560
	public double ResultedAmount
	{
		[CompilerGenerated]
		get
		{
			return this.<ResultedAmount>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ResultedAmount>k__BackingField = value;
		}
	}

	// Token: 0x17000266 RID: 614
	// (get) Token: 0x060023BD RID: 9149 RVA: 0x00103169 File Offset: 0x00101569
	// (set) Token: 0x060023BE RID: 9150 RVA: 0x00103171 File Offset: 0x00101571
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

	// Token: 0x17000267 RID: 615
	// (get) Token: 0x060023BF RID: 9151 RVA: 0x0010317A File Offset: 0x0010157A
	// (set) Token: 0x060023C0 RID: 9152 RVA: 0x00103182 File Offset: 0x00101582
	public double Change
	{
		[CompilerGenerated]
		get
		{
			return this.<Change>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Change>k__BackingField = value;
		}
	}

	// Token: 0x17000268 RID: 616
	// (get) Token: 0x060023C1 RID: 9153 RVA: 0x0010318B File Offset: 0x0010158B
	// (set) Token: 0x060023C2 RID: 9154 RVA: 0x00103193 File Offset: 0x00101593
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

	// Token: 0x04001EE5 RID: 7909
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <OriginalAmount>k__BackingField;

	// Token: 0x04001EE6 RID: 7910
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <ResultedAmount>k__BackingField;

	// Token: 0x04001EE7 RID: 7911
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <ResourceType>k__BackingField;

	// Token: 0x04001EE8 RID: 7912
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <Change>k__BackingField;

	// Token: 0x04001EE9 RID: 7913
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Item> <RelatedItems>k__BackingField;
}
