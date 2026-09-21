using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000441 RID: 1089
public class ReflectDamageSource : IBattleEffectSource
{
	// Token: 0x06001E66 RID: 7782 RVA: 0x000D5485 File Offset: 0x000D3885
	public ReflectDamageSource(IBattleUnit sourceUnit, IBattleEffectSource from)
	{
		this.SourceUnit = sourceUnit;
		this.ReflectDamageFrom = from;
	}

	// Token: 0x17000197 RID: 407
	// (get) Token: 0x06001E67 RID: 7783 RVA: 0x000D549B File Offset: 0x000D389B
	// (set) Token: 0x06001E68 RID: 7784 RVA: 0x000D54A3 File Offset: 0x000D38A3
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

	// Token: 0x17000198 RID: 408
	// (get) Token: 0x06001E69 RID: 7785 RVA: 0x000D54AC File Offset: 0x000D38AC
	// (set) Token: 0x06001E6A RID: 7786 RVA: 0x000D54B4 File Offset: 0x000D38B4
	public IBattleEffectSource ReflectDamageFrom
	{
		[CompilerGenerated]
		get
		{
			return this.<ReflectDamageFrom>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<ReflectDamageFrom>k__BackingField = value;
		}
	}

	// Token: 0x04001BFD RID: 7165
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <SourceUnit>k__BackingField;

	// Token: 0x04001BFE RID: 7166
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleEffectSource <ReflectDamageFrom>k__BackingField;
}
