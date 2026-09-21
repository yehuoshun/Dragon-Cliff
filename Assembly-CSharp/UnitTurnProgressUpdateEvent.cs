using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000434 RID: 1076
public class UnitTurnProgressUpdateEvent
{
	// Token: 0x06001E30 RID: 7728 RVA: 0x000D4D4C File Offset: 0x000D314C
	public UnitTurnProgressUpdateEvent()
	{
	}

	// Token: 0x17000186 RID: 390
	// (get) Token: 0x06001E31 RID: 7729 RVA: 0x000D4D54 File Offset: 0x000D3154
	// (set) Token: 0x06001E32 RID: 7730 RVA: 0x000D4D5C File Offset: 0x000D315C
	public double ChangePercentage
	{
		[CompilerGenerated]
		get
		{
			return this.<ChangePercentage>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ChangePercentage>k__BackingField = value;
		}
	}

	// Token: 0x17000187 RID: 391
	// (get) Token: 0x06001E33 RID: 7731 RVA: 0x000D4D65 File Offset: 0x000D3165
	// (set) Token: 0x06001E34 RID: 7732 RVA: 0x000D4D6D File Offset: 0x000D316D
	public IBattleUnit Dealer
	{
		[CompilerGenerated]
		get
		{
			return this.<Dealer>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Dealer>k__BackingField = value;
		}
	}

	// Token: 0x17000188 RID: 392
	// (get) Token: 0x06001E35 RID: 7733 RVA: 0x000D4D76 File Offset: 0x000D3176
	// (set) Token: 0x06001E36 RID: 7734 RVA: 0x000D4D7E File Offset: 0x000D317E
	public IBattleEffectSource CausingSource
	{
		[CompilerGenerated]
		get
		{
			return this.<CausingSource>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CausingSource>k__BackingField = value;
		}
	}

	// Token: 0x04001BE0 RID: 7136
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <ChangePercentage>k__BackingField;

	// Token: 0x04001BE1 RID: 7137
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Dealer>k__BackingField;

	// Token: 0x04001BE2 RID: 7138
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleEffectSource <CausingSource>k__BackingField;
}
