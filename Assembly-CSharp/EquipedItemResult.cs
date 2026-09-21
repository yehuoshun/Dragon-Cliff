using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000530 RID: 1328
public class EquipedItemResult
{
	// Token: 0x060026DF RID: 9951 RVA: 0x0011650C File Offset: 0x0011490C
	public EquipedItemResult()
	{
	}

	// Token: 0x170002FA RID: 762
	// (get) Token: 0x060026E0 RID: 9952 RVA: 0x00116514 File Offset: 0x00114914
	// (set) Token: 0x060026E1 RID: 9953 RVA: 0x0011651C File Offset: 0x0011491C
	public List<AttributeDisplayValue> Changes
	{
		[CompilerGenerated]
		get
		{
			return this.<Changes>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Changes>k__BackingField = value;
		}
	}

	// Token: 0x170002FB RID: 763
	// (get) Token: 0x060026E2 RID: 9954 RVA: 0x00116525 File Offset: 0x00114925
	// (set) Token: 0x060026E3 RID: 9955 RVA: 0x0011652D File Offset: 0x0011492D
	public List<ISpecialEffectDataLoad> LostSpecialEffects
	{
		[CompilerGenerated]
		get
		{
			return this.<LostSpecialEffects>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<LostSpecialEffects>k__BackingField = value;
		}
	}

	// Token: 0x170002FC RID: 764
	// (get) Token: 0x060026E4 RID: 9956 RVA: 0x00116536 File Offset: 0x00114936
	// (set) Token: 0x060026E5 RID: 9957 RVA: 0x0011653E File Offset: 0x0011493E
	public List<ISpecialEffectDataLoad> AddedSpecialEffects
	{
		[CompilerGenerated]
		get
		{
			return this.<AddedSpecialEffects>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<AddedSpecialEffects>k__BackingField = value;
		}
	}

	// Token: 0x0400215E RID: 8542
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AttributeDisplayValue> <Changes>k__BackingField;

	// Token: 0x0400215F RID: 8543
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ISpecialEffectDataLoad> <LostSpecialEffects>k__BackingField;

	// Token: 0x04002160 RID: 8544
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ISpecialEffectDataLoad> <AddedSpecialEffects>k__BackingField;
}
