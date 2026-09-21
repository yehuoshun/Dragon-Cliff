using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000B2B RID: 2859
public class SpecialEffectPresence : IPresentable
{
	// Token: 0x06004C37 RID: 19511 RVA: 0x001F1884 File Offset: 0x001EFC84
	public SpecialEffectPresence()
	{
	}

	// Token: 0x17001054 RID: 4180
	// (get) Token: 0x06004C38 RID: 19512 RVA: 0x001F188C File Offset: 0x001EFC8C
	// (set) Token: 0x06004C39 RID: 19513 RVA: 0x001F1894 File Offset: 0x001EFC94
	public int Index
	{
		[CompilerGenerated]
		get
		{
			return this.<Index>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Index>k__BackingField = value;
		}
	}

	// Token: 0x17001055 RID: 4181
	// (get) Token: 0x06004C3A RID: 19514 RVA: 0x001F189D File Offset: 0x001EFC9D
	// (set) Token: 0x06004C3B RID: 19515 RVA: 0x001F18A5 File Offset: 0x001EFCA5
	public int Presence
	{
		[CompilerGenerated]
		get
		{
			return this.<Presence>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Presence>k__BackingField = value;
		}
	}

	// Token: 0x17001056 RID: 4182
	// (get) Token: 0x06004C3C RID: 19516 RVA: 0x001F18AE File Offset: 0x001EFCAE
	// (set) Token: 0x06004C3D RID: 19517 RVA: 0x001F18B6 File Offset: 0x001EFCB6
	public List<ISpecialEffectDataLoad> SpecialEffectDataLoads
	{
		[CompilerGenerated]
		get
		{
			return this.<SpecialEffectDataLoads>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SpecialEffectDataLoads>k__BackingField = value;
		}
	}

	// Token: 0x06004C3E RID: 19518 RVA: 0x001F18BF File Offset: 0x001EFCBF
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x04003AE1 RID: 15073
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Index>k__BackingField;

	// Token: 0x04003AE2 RID: 15074
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int <Presence>k__BackingField;

	// Token: 0x04003AE3 RID: 15075
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ISpecialEffectDataLoad> <SpecialEffectDataLoads>k__BackingField;
}
