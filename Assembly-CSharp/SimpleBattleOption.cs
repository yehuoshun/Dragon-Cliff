using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000439 RID: 1081
public class SimpleBattleOption : IBattleOption
{
	// Token: 0x06001E49 RID: 7753 RVA: 0x000D5268 File Offset: 0x000D3668
	public SimpleBattleOption()
	{
	}

	// Token: 0x1700018E RID: 398
	// (get) Token: 0x06001E4A RID: 7754 RVA: 0x000D5270 File Offset: 0x000D3670
	// (set) Token: 0x06001E4B RID: 7755 RVA: 0x000D5278 File Offset: 0x000D3678
	public BattleOptionType BattleOptionType
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleOptionType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BattleOptionType>k__BackingField = value;
		}
	}

	// Token: 0x06001E4C RID: 7756 RVA: 0x000D5281 File Offset: 0x000D3681
	public BattleOptionType GetBattleOptionType()
	{
		return this.BattleOptionType;
	}

	// Token: 0x04001BEC RID: 7148
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BattleOptionType <BattleOptionType>k__BackingField;
}
