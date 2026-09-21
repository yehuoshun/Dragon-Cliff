using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000443 RID: 1091
public class DamageOverTimeInstantSource : IBattleEffectSource
{
	// Token: 0x06001E6E RID: 7790 RVA: 0x000D54DD File Offset: 0x000D38DD
	public DamageOverTimeInstantSource(IBattleUnit sourceUnit)
	{
		this.SourceUnit = sourceUnit;
	}

	// Token: 0x1700019A RID: 410
	// (get) Token: 0x06001E6F RID: 7791 RVA: 0x000D54EC File Offset: 0x000D38EC
	// (set) Token: 0x06001E70 RID: 7792 RVA: 0x000D54F4 File Offset: 0x000D38F4
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

	// Token: 0x04001C00 RID: 7168
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <SourceUnit>k__BackingField;
}
