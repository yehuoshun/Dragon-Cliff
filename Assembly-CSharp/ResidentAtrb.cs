using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200030F RID: 783
public class ResidentAtrb
{
	// Token: 0x060014E9 RID: 5353 RVA: 0x000A9059 File Offset: 0x000A7459
	public ResidentAtrb()
	{
	}

	// Token: 0x17000109 RID: 265
	// (get) Token: 0x060014EA RID: 5354 RVA: 0x000A9061 File Offset: 0x000A7461
	// (set) Token: 0x060014EB RID: 5355 RVA: 0x000A9069 File Offset: 0x000A7469
	public Resident Resident
	{
		[CompilerGenerated]
		get
		{
			return this.<Resident>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Resident>k__BackingField = value;
		}
	}

	// Token: 0x1700010A RID: 266
	// (get) Token: 0x060014EC RID: 5356 RVA: 0x000A9072 File Offset: 0x000A7472
	// (set) Token: 0x060014ED RID: 5357 RVA: 0x000A907A File Offset: 0x000A747A
	public NodeController StartPoint
	{
		[CompilerGenerated]
		get
		{
			return this.<StartPoint>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<StartPoint>k__BackingField = value;
		}
	}

	// Token: 0x1700010B RID: 267
	// (get) Token: 0x060014EE RID: 5358 RVA: 0x000A9083 File Offset: 0x000A7483
	// (set) Token: 0x060014EF RID: 5359 RVA: 0x000A908B File Offset: 0x000A748B
	public NodeController EndPoint
	{
		[CompilerGenerated]
		get
		{
			return this.<EndPoint>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<EndPoint>k__BackingField = value;
		}
	}

	// Token: 0x1700010C RID: 268
	// (get) Token: 0x060014F0 RID: 5360 RVA: 0x000A9094 File Offset: 0x000A7494
	// (set) Token: 0x060014F1 RID: 5361 RVA: 0x000A909C File Offset: 0x000A749C
	public float HalfwayWaitTime
	{
		[CompilerGenerated]
		get
		{
			return this.<HalfwayWaitTime>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<HalfwayWaitTime>k__BackingField = value;
		}
	}

	// Token: 0x1700010D RID: 269
	// (get) Token: 0x060014F2 RID: 5362 RVA: 0x000A90A5 File Offset: 0x000A74A5
	// (set) Token: 0x060014F3 RID: 5363 RVA: 0x000A90AD File Offset: 0x000A74AD
	public bool HasExpression
	{
		[CompilerGenerated]
		get
		{
			return this.<HasExpression>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<HasExpression>k__BackingField = value;
		}
	}

	// Token: 0x1700010E RID: 270
	// (get) Token: 0x060014F4 RID: 5364 RVA: 0x000A90B6 File Offset: 0x000A74B6
	// (set) Token: 0x060014F5 RID: 5365 RVA: 0x000A90BE File Offset: 0x000A74BE
	public TownEffectBase TownEffect
	{
		[CompilerGenerated]
		get
		{
			return this.<TownEffect>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<TownEffect>k__BackingField = value;
		}
	}

	// Token: 0x04001504 RID: 5380
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Resident <Resident>k__BackingField;

	// Token: 0x04001505 RID: 5381
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private NodeController <StartPoint>k__BackingField;

	// Token: 0x04001506 RID: 5382
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private NodeController <EndPoint>k__BackingField;

	// Token: 0x04001507 RID: 5383
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float <HalfwayWaitTime>k__BackingField;

	// Token: 0x04001508 RID: 5384
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <HasExpression>k__BackingField;

	// Token: 0x04001509 RID: 5385
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TownEffectBase <TownEffect>k__BackingField;
}
