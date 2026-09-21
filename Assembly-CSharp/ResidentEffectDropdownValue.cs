using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000248 RID: 584
public class ResidentEffectDropdownValue
{
	// Token: 0x06000F15 RID: 3861 RVA: 0x000933BC File Offset: 0x000917BC
	public ResidentEffectDropdownValue()
	{
	}

	// Token: 0x17000094 RID: 148
	// (get) Token: 0x06000F16 RID: 3862 RVA: 0x000933C4 File Offset: 0x000917C4
	// (set) Token: 0x06000F17 RID: 3863 RVA: 0x000933CC File Offset: 0x000917CC
	public ResidentEffectType Type
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

	// Token: 0x17000095 RID: 149
	// (get) Token: 0x06000F18 RID: 3864 RVA: 0x000933D5 File Offset: 0x000917D5
	// (set) Token: 0x06000F19 RID: 3865 RVA: 0x000933DD File Offset: 0x000917DD
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

	// Token: 0x0400107E RID: 4222
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResidentEffectType <Type>k__BackingField;

	// Token: 0x0400107F RID: 4223
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Value>k__BackingField;
}
