using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DynamicLight2D
{
	// Token: 0x0200009A RID: 154
	public class verts
	{
		// Token: 0x060004B5 RID: 1205 RVA: 0x000583E8 File Offset: 0x000567E8
		public verts()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x000583F0 File Offset: 0x000567F0
		// (set) Token: 0x060004B7 RID: 1207 RVA: 0x000583F8 File Offset: 0x000567F8
		public float angle
		{
			[CompilerGenerated]
			get
			{
				return this.<angle>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<angle>k__BackingField = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x00058401 File Offset: 0x00056801
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x00058409 File Offset: 0x00056809
		public int location
		{
			[CompilerGenerated]
			get
			{
				return this.<location>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<location>k__BackingField = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x00058412 File Offset: 0x00056812
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x0005841A File Offset: 0x0005681A
		public Vector3 pos
		{
			[CompilerGenerated]
			get
			{
				return this.<pos>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<pos>k__BackingField = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x00058423 File Offset: 0x00056823
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x0005842B File Offset: 0x0005682B
		public bool endpoint
		{
			[CompilerGenerated]
			get
			{
				return this.<endpoint>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<endpoint>k__BackingField = value;
			}
		}

		// Token: 0x0400082E RID: 2094
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float <angle>k__BackingField;

		// Token: 0x0400082F RID: 2095
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int <location>k__BackingField;

		// Token: 0x04000830 RID: 2096
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Vector3 <pos>k__BackingField;

		// Token: 0x04000831 RID: 2097
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool <endpoint>k__BackingField;
	}
}
