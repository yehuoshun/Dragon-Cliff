using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020002EF RID: 751
public class MetricTypeDropdownValue
{
	// Token: 0x060013E7 RID: 5095 RVA: 0x000A5100 File Offset: 0x000A3500
	public MetricTypeDropdownValue()
	{
	}

	// Token: 0x170000E8 RID: 232
	// (get) Token: 0x060013E8 RID: 5096 RVA: 0x000A5108 File Offset: 0x000A3508
	// (set) Token: 0x060013E9 RID: 5097 RVA: 0x000A5110 File Offset: 0x000A3510
	public OrderingType Type
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

	// Token: 0x170000E9 RID: 233
	// (get) Token: 0x060013EA RID: 5098 RVA: 0x000A5119 File Offset: 0x000A3519
	// (set) Token: 0x060013EB RID: 5099 RVA: 0x000A5121 File Offset: 0x000A3521
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

	// Token: 0x170000EA RID: 234
	// (get) Token: 0x060013EC RID: 5100 RVA: 0x000A512A File Offset: 0x000A352A
	// (set) Token: 0x060013ED RID: 5101 RVA: 0x000A5132 File Offset: 0x000A3532
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

	// Token: 0x0400144D RID: 5197
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OrderingType <Type>k__BackingField;

	// Token: 0x0400144E RID: 5198
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Text>k__BackingField;

	// Token: 0x0400144F RID: 5199
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Value>k__BackingField;
}
