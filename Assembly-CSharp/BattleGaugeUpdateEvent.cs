using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000432 RID: 1074
public class BattleGaugeUpdateEvent
{
	// Token: 0x06001E24 RID: 7716 RVA: 0x000D4CE7 File Offset: 0x000D30E7
	public BattleGaugeUpdateEvent()
	{
	}

	// Token: 0x17000181 RID: 385
	// (get) Token: 0x06001E25 RID: 7717 RVA: 0x000D4CEF File Offset: 0x000D30EF
	// (set) Token: 0x06001E26 RID: 7718 RVA: 0x000D4CF7 File Offset: 0x000D30F7
	public double ChangeAmount
	{
		[CompilerGenerated]
		get
		{
			return this.<ChangeAmount>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ChangeAmount>k__BackingField = value;
		}
	}

	// Token: 0x17000182 RID: 386
	// (get) Token: 0x06001E27 RID: 7719 RVA: 0x000D4D00 File Offset: 0x000D3100
	// (set) Token: 0x06001E28 RID: 7720 RVA: 0x000D4D08 File Offset: 0x000D3108
	public IBattleEffectSource ChangeSource
	{
		[CompilerGenerated]
		get
		{
			return this.<ChangeSource>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<ChangeSource>k__BackingField = value;
		}
	}

	// Token: 0x17000183 RID: 387
	// (get) Token: 0x06001E29 RID: 7721 RVA: 0x000D4D11 File Offset: 0x000D3111
	// (set) Token: 0x06001E2A RID: 7722 RVA: 0x000D4D19 File Offset: 0x000D3119
	public double CurrentValue
	{
		[CompilerGenerated]
		get
		{
			return this.<CurrentValue>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CurrentValue>k__BackingField = value;
		}
	}

	// Token: 0x04001BDB RID: 7131
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <ChangeAmount>k__BackingField;

	// Token: 0x04001BDC RID: 7132
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleEffectSource <ChangeSource>k__BackingField;

	// Token: 0x04001BDD RID: 7133
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <CurrentValue>k__BackingField;
}
