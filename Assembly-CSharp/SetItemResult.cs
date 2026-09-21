using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020006A9 RID: 1705
public class SetItemResult
{
	// Token: 0x06002D44 RID: 11588 RVA: 0x00127A19 File Offset: 0x00125E19
	public SetItemResult()
	{
	}

	// Token: 0x170005B1 RID: 1457
	// (get) Token: 0x06002D45 RID: 11589 RVA: 0x00127A21 File Offset: 0x00125E21
	// (set) Token: 0x06002D46 RID: 11590 RVA: 0x00127A29 File Offset: 0x00125E29
	public ResourceType CorrespondingSetType
	{
		[CompilerGenerated]
		get
		{
			return this.<CorrespondingSetType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CorrespondingSetType>k__BackingField = value;
		}
	}

	// Token: 0x170005B2 RID: 1458
	// (get) Token: 0x06002D47 RID: 11591 RVA: 0x00127A32 File Offset: 0x00125E32
	// (set) Token: 0x06002D48 RID: 11592 RVA: 0x00127A3A File Offset: 0x00125E3A
	public List<AttributeModifier> MajorModifiers
	{
		[CompilerGenerated]
		get
		{
			return this.<MajorModifiers>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<MajorModifiers>k__BackingField = value;
		}
	}

	// Token: 0x170005B3 RID: 1459
	// (get) Token: 0x06002D49 RID: 11593 RVA: 0x00127A43 File Offset: 0x00125E43
	// (set) Token: 0x06002D4A RID: 11594 RVA: 0x00127A4B File Offset: 0x00125E4B
	public List<AttributeModifier> MinorModifiers
	{
		[CompilerGenerated]
		get
		{
			return this.<MinorModifiers>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<MinorModifiers>k__BackingField = value;
		}
	}

	// Token: 0x170005B4 RID: 1460
	// (get) Token: 0x06002D4B RID: 11595 RVA: 0x00127A54 File Offset: 0x00125E54
	// (set) Token: 0x06002D4C RID: 11596 RVA: 0x00127A5C File Offset: 0x00125E5C
	public List<ISpecialEffectDataLoad> MajorEffects
	{
		[CompilerGenerated]
		get
		{
			return this.<MajorEffects>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<MajorEffects>k__BackingField = value;
		}
	}

	// Token: 0x170005B5 RID: 1461
	// (get) Token: 0x06002D4D RID: 11597 RVA: 0x00127A65 File Offset: 0x00125E65
	// (set) Token: 0x06002D4E RID: 11598 RVA: 0x00127A6D File Offset: 0x00125E6D
	public List<ISpecialEffectDataLoad> MinorEffects
	{
		[CompilerGenerated]
		get
		{
			return this.<MinorEffects>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<MinorEffects>k__BackingField = value;
		}
	}

	// Token: 0x040026A8 RID: 9896
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceType <CorrespondingSetType>k__BackingField;

	// Token: 0x040026A9 RID: 9897
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AttributeModifier> <MajorModifiers>k__BackingField;

	// Token: 0x040026AA RID: 9898
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AttributeModifier> <MinorModifiers>k__BackingField;

	// Token: 0x040026AB RID: 9899
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ISpecialEffectDataLoad> <MajorEffects>k__BackingField;

	// Token: 0x040026AC RID: 9900
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ISpecialEffectDataLoad> <MinorEffects>k__BackingField;
}
