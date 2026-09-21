using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020001BA RID: 442
public class HeroOrderTypeDropdownValue
{
	// Token: 0x06000B7E RID: 2942 RVA: 0x00086796 File Offset: 0x00084B96
	public HeroOrderTypeDropdownValue()
	{
	}

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x06000B7F RID: 2943 RVA: 0x0008679E File Offset: 0x00084B9E
	// (set) Token: 0x06000B80 RID: 2944 RVA: 0x000867A6 File Offset: 0x00084BA6
	public AdventurerOrderType Type
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

	// Token: 0x1700004D RID: 77
	// (get) Token: 0x06000B81 RID: 2945 RVA: 0x000867AF File Offset: 0x00084BAF
	// (set) Token: 0x06000B82 RID: 2946 RVA: 0x000867B7 File Offset: 0x00084BB7
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

	// Token: 0x1700004E RID: 78
	// (get) Token: 0x06000B83 RID: 2947 RVA: 0x000867C0 File Offset: 0x00084BC0
	// (set) Token: 0x06000B84 RID: 2948 RVA: 0x000867C8 File Offset: 0x00084BC8
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

	// Token: 0x04000DF7 RID: 3575
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerOrderType <Type>k__BackingField;

	// Token: 0x04000DF8 RID: 3576
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Text>k__BackingField;

	// Token: 0x04000DF9 RID: 3577
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Value>k__BackingField;
}
