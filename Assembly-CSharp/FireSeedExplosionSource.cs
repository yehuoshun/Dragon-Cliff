using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000444 RID: 1092
public class FireSeedExplosionSource : IBattleEffectSource
{
	// Token: 0x06001E71 RID: 7793 RVA: 0x000D54FD File Offset: 0x000D38FD
	public FireSeedExplosionSource(IBattleUnit sourceUnit)
	{
		this.SourceUnit = sourceUnit;
	}

	// Token: 0x1700019B RID: 411
	// (get) Token: 0x06001E72 RID: 7794 RVA: 0x000D550C File Offset: 0x000D390C
	// (set) Token: 0x06001E73 RID: 7795 RVA: 0x000D5514 File Offset: 0x000D3914
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

	// Token: 0x04001C01 RID: 7169
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <SourceUnit>k__BackingField;
}
