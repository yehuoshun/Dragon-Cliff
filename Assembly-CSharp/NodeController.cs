using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000145 RID: 325
public class NodeController : MonoBehaviour
{
	// Token: 0x060008DD RID: 2269 RVA: 0x00078772 File Offset: 0x00076B72
	public NodeController()
	{
	}

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x060008DE RID: 2270 RVA: 0x0007877A File Offset: 0x00076B7A
	// (set) Token: 0x060008DF RID: 2271 RVA: 0x00078782 File Offset: 0x00076B82
	public NodeController Parent
	{
		[CompilerGenerated]
		get
		{
			return this.<Parent>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Parent>k__BackingField = value;
		}
	}

	// Token: 0x17000033 RID: 51
	// (get) Token: 0x060008E0 RID: 2272 RVA: 0x0007878B File Offset: 0x00076B8B
	// (set) Token: 0x060008E1 RID: 2273 RVA: 0x00078793 File Offset: 0x00076B93
	public int GCost
	{
		[CompilerGenerated]
		get
		{
			return this.<GCost>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<GCost>k__BackingField = value;
		}
	}

	// Token: 0x17000034 RID: 52
	// (get) Token: 0x060008E2 RID: 2274 RVA: 0x0007879C File Offset: 0x00076B9C
	// (set) Token: 0x060008E3 RID: 2275 RVA: 0x000787A4 File Offset: 0x00076BA4
	public int HCost
	{
		[CompilerGenerated]
		get
		{
			return this.<HCost>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<HCost>k__BackingField = value;
		}
	}

	// Token: 0x17000035 RID: 53
	// (get) Token: 0x060008E4 RID: 2276 RVA: 0x000787AD File Offset: 0x00076BAD
	public int FCost
	{
		get
		{
			return this.GCost + this.HCost;
		}
	}

	// Token: 0x04000B81 RID: 2945
	public int PositionX;

	// Token: 0x04000B82 RID: 2946
	public int PositionY;

	// Token: 0x04000B83 RID: 2947
	public NodeType Type;

	// Token: 0x04000B84 RID: 2948
	public List<NodeController> Neighbours;

	// Token: 0x04000B85 RID: 2949
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private NodeController <Parent>k__BackingField;

	// Token: 0x04000B86 RID: 2950
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <GCost>k__BackingField;

	// Token: 0x04000B87 RID: 2951
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <HCost>k__BackingField;
}
