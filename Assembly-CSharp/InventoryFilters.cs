using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020001EC RID: 492
public class InventoryFilters
{
	// Token: 0x06000D13 RID: 3347 RVA: 0x0008D46E File Offset: 0x0008B86E
	public InventoryFilters()
	{
	}

	// Token: 0x1700005A RID: 90
	// (get) Token: 0x06000D14 RID: 3348 RVA: 0x0008D476 File Offset: 0x0008B876
	// (set) Token: 0x06000D15 RID: 3349 RVA: 0x0008D47E File Offset: 0x0008B87E
	public bool IsOn
	{
		[CompilerGenerated]
		get
		{
			return this.<IsOn>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsOn>k__BackingField = value;
		}
	}

	// Token: 0x1700005B RID: 91
	// (get) Token: 0x06000D16 RID: 3350 RVA: 0x0008D487 File Offset: 0x0008B887
	// (set) Token: 0x06000D17 RID: 3351 RVA: 0x0008D48F File Offset: 0x0008B88F
	public string TitleText
	{
		[CompilerGenerated]
		get
		{
			return this.<TitleText>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<TitleText>k__BackingField = value;
		}
	}

	// Token: 0x1700005C RID: 92
	// (get) Token: 0x06000D18 RID: 3352 RVA: 0x0008D498 File Offset: 0x0008B898
	// (set) Token: 0x06000D19 RID: 3353 RVA: 0x0008D4A0 File Offset: 0x0008B8A0
	public string SpecialEffectText
	{
		[CompilerGenerated]
		get
		{
			return this.<SpecialEffectText>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SpecialEffectText>k__BackingField = value;
		}
	}

	// Token: 0x1700005D RID: 93
	// (get) Token: 0x06000D1A RID: 3354 RVA: 0x0008D4A9 File Offset: 0x0008B8A9
	// (set) Token: 0x06000D1B RID: 3355 RVA: 0x0008D4B1 File Offset: 0x0008B8B1
	public int Level
	{
		[CompilerGenerated]
		get
		{
			return this.<Level>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Level>k__BackingField = value;
		}
	}

	// Token: 0x1700005E RID: 94
	// (get) Token: 0x06000D1C RID: 3356 RVA: 0x0008D4BA File Offset: 0x0008B8BA
	// (set) Token: 0x06000D1D RID: 3357 RVA: 0x0008D4C2 File Offset: 0x0008B8C2
	public LockStatus LockStatus
	{
		[CompilerGenerated]
		get
		{
			return this.<LockStatus>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<LockStatus>k__BackingField = value;
		}
	}

	// Token: 0x1700005F RID: 95
	// (get) Token: 0x06000D1E RID: 3358 RVA: 0x0008D4CB File Offset: 0x0008B8CB
	// (set) Token: 0x06000D1F RID: 3359 RVA: 0x0008D4D3 File Offset: 0x0008B8D3
	public HasGemStatus HasGemStatus
	{
		[CompilerGenerated]
		get
		{
			return this.<HasGemStatus>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<HasGemStatus>k__BackingField = value;
		}
	}

	// Token: 0x17000060 RID: 96
	// (get) Token: 0x06000D20 RID: 3360 RVA: 0x0008D4DC File Offset: 0x0008B8DC
	// (set) Token: 0x06000D21 RID: 3361 RVA: 0x0008D4E4 File Offset: 0x0008B8E4
	public SocketType SocketType
	{
		[CompilerGenerated]
		get
		{
			return this.<SocketType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SocketType>k__BackingField = value;
		}
	}

	// Token: 0x17000061 RID: 97
	// (get) Token: 0x06000D22 RID: 3362 RVA: 0x0008D4ED File Offset: 0x0008B8ED
	// (set) Token: 0x06000D23 RID: 3363 RVA: 0x0008D4F5 File Offset: 0x0008B8F5
	public List<AttributeType> Attributes
	{
		[CompilerGenerated]
		get
		{
			return this.<Attributes>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Attributes>k__BackingField = value;
		}
	}

	// Token: 0x17000062 RID: 98
	// (get) Token: 0x06000D24 RID: 3364 RVA: 0x0008D4FE File Offset: 0x0008B8FE
	// (set) Token: 0x06000D25 RID: 3365 RVA: 0x0008D506 File Offset: 0x0008B906
	public List<FilterGrade> ItemGrades
	{
		[CompilerGenerated]
		get
		{
			return this.<ItemGrades>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ItemGrades>k__BackingField = value;
		}
	}

	// Token: 0x17000063 RID: 99
	// (get) Token: 0x06000D26 RID: 3366 RVA: 0x0008D50F File Offset: 0x0008B90F
	// (set) Token: 0x06000D27 RID: 3367 RVA: 0x0008D517 File Offset: 0x0008B917
	public bool SortBySpecialEffect
	{
		[CompilerGenerated]
		get
		{
			return this.<SortBySpecialEffect>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SortBySpecialEffect>k__BackingField = value;
		}
	}

	// Token: 0x17000064 RID: 100
	// (get) Token: 0x06000D28 RID: 3368 RVA: 0x0008D520 File Offset: 0x0008B920
	// (set) Token: 0x06000D29 RID: 3369 RVA: 0x0008D528 File Offset: 0x0008B928
	public int NumberOfAttributes
	{
		[CompilerGenerated]
		get
		{
			return this.<NumberOfAttributes>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NumberOfAttributes>k__BackingField = value;
		}
	}

	// Token: 0x04000F1F RID: 3871
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsOn>k__BackingField;

	// Token: 0x04000F20 RID: 3872
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <TitleText>k__BackingField;

	// Token: 0x04000F21 RID: 3873
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <SpecialEffectText>k__BackingField;

	// Token: 0x04000F22 RID: 3874
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Level>k__BackingField;

	// Token: 0x04000F23 RID: 3875
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LockStatus <LockStatus>k__BackingField;

	// Token: 0x04000F24 RID: 3876
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HasGemStatus <HasGemStatus>k__BackingField;

	// Token: 0x04000F25 RID: 3877
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SocketType <SocketType>k__BackingField;

	// Token: 0x04000F26 RID: 3878
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AttributeType> <Attributes>k__BackingField;

	// Token: 0x04000F27 RID: 3879
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<FilterGrade> <ItemGrades>k__BackingField;

	// Token: 0x04000F28 RID: 3880
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <SortBySpecialEffect>k__BackingField;

	// Token: 0x04000F29 RID: 3881
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <NumberOfAttributes>k__BackingField;
}
