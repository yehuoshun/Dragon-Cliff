using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020006B1 RID: 1713
public class TeamSetItemUpgradeResult
{
	// Token: 0x06002D80 RID: 11648 RVA: 0x001290B6 File Offset: 0x001274B6
	public TeamSetItemUpgradeResult()
	{
	}

	// Token: 0x170005C3 RID: 1475
	// (get) Token: 0x06002D81 RID: 11649 RVA: 0x001290BE File Offset: 0x001274BE
	// (set) Token: 0x06002D82 RID: 11650 RVA: 0x001290C6 File Offset: 0x001274C6
	public List<AttributeModifier> BoostedAttributes
	{
		[CompilerGenerated]
		get
		{
			return this.<BoostedAttributes>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BoostedAttributes>k__BackingField = value;
		}
	}

	// Token: 0x170005C4 RID: 1476
	// (get) Token: 0x06002D83 RID: 11651 RVA: 0x001290CF File Offset: 0x001274CF
	// (set) Token: 0x06002D84 RID: 11652 RVA: 0x001290D7 File Offset: 0x001274D7
	public List<ISpecialEffectDataLoad> BoostedEffects
	{
		[CompilerGenerated]
		get
		{
			return this.<BoostedEffects>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BoostedEffects>k__BackingField = value;
		}
	}

	// Token: 0x040026C2 RID: 9922
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AttributeModifier> <BoostedAttributes>k__BackingField;

	// Token: 0x040026C3 RID: 9923
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ISpecialEffectDataLoad> <BoostedEffects>k__BackingField;
}
