using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000435 RID: 1077
public class UnitTurnProgressUpdateResultEvent
{
	// Token: 0x06001E37 RID: 7735 RVA: 0x000D4D87 File Offset: 0x000D3187
	public UnitTurnProgressUpdateResultEvent()
	{
	}

	// Token: 0x17000189 RID: 393
	// (get) Token: 0x06001E38 RID: 7736 RVA: 0x000D4D8F File Offset: 0x000D318F
	// (set) Token: 0x06001E39 RID: 7737 RVA: 0x000D4D97 File Offset: 0x000D3197
	public IBattleUnit BattleUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleUnit>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BattleUnit>k__BackingField = value;
		}
	}

	// Token: 0x1700018A RID: 394
	// (get) Token: 0x06001E3A RID: 7738 RVA: 0x000D4DA0 File Offset: 0x000D31A0
	// (set) Token: 0x06001E3B RID: 7739 RVA: 0x000D4DA8 File Offset: 0x000D31A8
	public double ProposedChangePercentage
	{
		[CompilerGenerated]
		get
		{
			return this.<ProposedChangePercentage>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ProposedChangePercentage>k__BackingField = value;
		}
	}

	// Token: 0x1700018B RID: 395
	// (get) Token: 0x06001E3C RID: 7740 RVA: 0x000D4DB1 File Offset: 0x000D31B1
	// (set) Token: 0x06001E3D RID: 7741 RVA: 0x000D4DB9 File Offset: 0x000D31B9
	public double ActualChangePercentage
	{
		[CompilerGenerated]
		get
		{
			return this.<ActualChangePercentage>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ActualChangePercentage>k__BackingField = value;
		}
	}

	// Token: 0x1700018C RID: 396
	// (get) Token: 0x06001E3E RID: 7742 RVA: 0x000D4DC2 File Offset: 0x000D31C2
	// (set) Token: 0x06001E3F RID: 7743 RVA: 0x000D4DCA File Offset: 0x000D31CA
	public IBattleUnit CausedByUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<CausedByUnit>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CausedByUnit>k__BackingField = value;
		}
	}

	// Token: 0x1700018D RID: 397
	// (get) Token: 0x06001E40 RID: 7744 RVA: 0x000D4DD3 File Offset: 0x000D31D3
	// (set) Token: 0x06001E41 RID: 7745 RVA: 0x000D4DDB File Offset: 0x000D31DB
	public IBattleEffectSource CausingSkill
	{
		[CompilerGenerated]
		get
		{
			return this.<CausingSkill>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CausingSkill>k__BackingField = value;
		}
	}

	// Token: 0x04001BE3 RID: 7139
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <BattleUnit>k__BackingField;

	// Token: 0x04001BE4 RID: 7140
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <ProposedChangePercentage>k__BackingField;

	// Token: 0x04001BE5 RID: 7141
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <ActualChangePercentage>k__BackingField;

	// Token: 0x04001BE6 RID: 7142
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <CausedByUnit>k__BackingField;

	// Token: 0x04001BE7 RID: 7143
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleEffectSource <CausingSkill>k__BackingField;
}
