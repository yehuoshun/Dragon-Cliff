using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000442 RID: 1090
public class DamageOverTimeTickSource : IBattleEffectSource
{
	// Token: 0x06001E6B RID: 7787 RVA: 0x000D54BD File Offset: 0x000D38BD
	public DamageOverTimeTickSource(IBattleUnit sourceUnit)
	{
		this.SourceUnit = sourceUnit;
	}

	// Token: 0x17000199 RID: 409
	// (get) Token: 0x06001E6C RID: 7788 RVA: 0x000D54CC File Offset: 0x000D38CC
	// (set) Token: 0x06001E6D RID: 7789 RVA: 0x000D54D4 File Offset: 0x000D38D4
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

	// Token: 0x04001BFF RID: 7167
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <SourceUnit>k__BackingField;
}
