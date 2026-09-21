using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020001B1 RID: 433
public class OrderTypeDropdownValue
{
	// Token: 0x06000B5E RID: 2910 RVA: 0x00085DB3 File Offset: 0x000841B3
	public OrderTypeDropdownValue()
	{
	}

	// Token: 0x17000047 RID: 71
	// (get) Token: 0x06000B5F RID: 2911 RVA: 0x00085DBB File Offset: 0x000841BB
	// (set) Token: 0x06000B60 RID: 2912 RVA: 0x00085DC3 File Offset: 0x000841C3
	public ItemOrderType Type
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

	// Token: 0x17000048 RID: 72
	// (get) Token: 0x06000B61 RID: 2913 RVA: 0x00085DCC File Offset: 0x000841CC
	// (set) Token: 0x06000B62 RID: 2914 RVA: 0x00085DD4 File Offset: 0x000841D4
	public string Text
	{
		[CompilerGenerated]
		get
		{
			return this.<Text>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Text>k__BackingField = value;
		}
	}

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x06000B63 RID: 2915 RVA: 0x00085DDD File Offset: 0x000841DD
	// (set) Token: 0x06000B64 RID: 2916 RVA: 0x00085DE5 File Offset: 0x000841E5
	public int Value
	{
		[CompilerGenerated]
		get
		{
			return this.<Value>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Value>k__BackingField = value;
		}
	}

	// Token: 0x04000DDA RID: 3546
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ItemOrderType <Type>k__BackingField;

	// Token: 0x04000DDB RID: 3547
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Text>k__BackingField;

	// Token: 0x04000DDC RID: 3548
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Value>k__BackingField;
}
