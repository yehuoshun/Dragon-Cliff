using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000149 RID: 329
public class WeatherCloud
{
	// Token: 0x06000904 RID: 2308 RVA: 0x00079458 File Offset: 0x00077858
	public WeatherCloud()
	{
	}

	// Token: 0x17000036 RID: 54
	// (get) Token: 0x06000905 RID: 2309 RVA: 0x00079460 File Offset: 0x00077860
	// (set) Token: 0x06000906 RID: 2310 RVA: 0x00079468 File Offset: 0x00077868
	public GameObject CloudObj
	{
		[CompilerGenerated]
		get
		{
			return this.<CloudObj>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CloudObj>k__BackingField = value;
		}
	}

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x06000907 RID: 2311 RVA: 0x00079471 File Offset: 0x00077871
	// (set) Token: 0x06000908 RID: 2312 RVA: 0x00079479 File Offset: 0x00077879
	public float Speed
	{
		[CompilerGenerated]
		get
		{
			return this.<Speed>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Speed>k__BackingField = value;
		}
	}

	// Token: 0x06000909 RID: 2313 RVA: 0x00079484 File Offset: 0x00077884
	public bool PassScreen(float screenEndX)
	{
		return this.CloudObj.transform.position.x >= screenEndX;
	}

	// Token: 0x04000BAA RID: 2986
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GameObject <CloudObj>k__BackingField;

	// Token: 0x04000BAB RID: 2987
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float <Speed>k__BackingField;
}
