using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020006AB RID: 1707
public class SpecialEffectDetails
{
	// Token: 0x06002D4F RID: 11599 RVA: 0x00127A76 File Offset: 0x00125E76
	public SpecialEffectDetails()
	{
	}

	// Token: 0x170005B6 RID: 1462
	// (get) Token: 0x06002D50 RID: 11600 RVA: 0x00127A7E File Offset: 0x00125E7E
	// (set) Token: 0x06002D51 RID: 11601 RVA: 0x00127A86 File Offset: 0x00125E86
	public SpecialEffectType Type
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

	// Token: 0x170005B7 RID: 1463
	// (get) Token: 0x06002D52 RID: 11602 RVA: 0x00127A8F File Offset: 0x00125E8F
	// (set) Token: 0x06002D53 RID: 11603 RVA: 0x00127A97 File Offset: 0x00125E97
	public string Details
	{
		[CompilerGenerated]
		get
		{
			return this.<Details>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Details>k__BackingField = value;
		}
	}

	// Token: 0x170005B8 RID: 1464
	// (get) Token: 0x06002D54 RID: 11604 RVA: 0x00127AA0 File Offset: 0x00125EA0
	// (set) Token: 0x06002D55 RID: 11605 RVA: 0x00127AA8 File Offset: 0x00125EA8
	public bool IsUnlocked
	{
		[CompilerGenerated]
		get
		{
			return this.<IsUnlocked>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<IsUnlocked>k__BackingField = value;
		}
	}

	// Token: 0x040026B3 RID: 9907
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SpecialEffectType <Type>k__BackingField;

	// Token: 0x040026B4 RID: 9908
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Details>k__BackingField;

	// Token: 0x040026B5 RID: 9909
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsUnlocked>k__BackingField;
}
