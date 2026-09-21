using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000440 RID: 1088
public class SpecialEffectTriggerSource : IBattleEffectSource
{
	// Token: 0x06001E61 RID: 7777 RVA: 0x000D544D File Offset: 0x000D384D
	public SpecialEffectTriggerSource(IBattleUnit sourceUnit, SpecialEffectType specialEffectType)
	{
		this.SourceUnit = sourceUnit;
		this.SpecialEffectType = specialEffectType;
	}

	// Token: 0x17000195 RID: 405
	// (get) Token: 0x06001E62 RID: 7778 RVA: 0x000D5463 File Offset: 0x000D3863
	// (set) Token: 0x06001E63 RID: 7779 RVA: 0x000D546B File Offset: 0x000D386B
	public IBattleUnit SourceUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<SourceUnit>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<SourceUnit>k__BackingField = value;
		}
	}

	// Token: 0x17000196 RID: 406
	// (get) Token: 0x06001E64 RID: 7780 RVA: 0x000D5474 File Offset: 0x000D3874
	// (set) Token: 0x06001E65 RID: 7781 RVA: 0x000D547C File Offset: 0x000D387C
	public SpecialEffectType SpecialEffectType
	{
		[CompilerGenerated]
		get
		{
			return this.<SpecialEffectType>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<SpecialEffectType>k__BackingField = value;
		}
	}

	// Token: 0x04001BFB RID: 7163
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <SourceUnit>k__BackingField;

	// Token: 0x04001BFC RID: 7164
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SpecialEffectType <SpecialEffectType>k__BackingField;
}
