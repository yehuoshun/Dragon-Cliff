using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200045F RID: 1119
public class NormalAttackSource : IBattleEffectSource
{
	// Token: 0x06001FBF RID: 8127 RVA: 0x000DEB8D File Offset: 0x000DCF8D
	public NormalAttackSource(IBattleUnit sourceUnit)
	{
		this.SourceUnit = sourceUnit;
	}

	// Token: 0x170001E2 RID: 482
	// (get) Token: 0x06001FC0 RID: 8128 RVA: 0x000DEB9C File Offset: 0x000DCF9C
	// (set) Token: 0x06001FC1 RID: 8129 RVA: 0x000DEBA4 File Offset: 0x000DCFA4
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

	// Token: 0x04001C67 RID: 7271
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <SourceUnit>k__BackingField;
}
