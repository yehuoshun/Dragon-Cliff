using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x020004A8 RID: 1192
public class EffectDispersedEvent
{
	// Token: 0x0600236B RID: 9067 RVA: 0x00102EB7 File Offset: 0x001012B7
	public EffectDispersedEvent()
	{
	}

	// Token: 0x17000244 RID: 580
	// (get) Token: 0x0600236C RID: 9068 RVA: 0x00102EBF File Offset: 0x001012BF
	// (set) Token: 0x0600236D RID: 9069 RVA: 0x00102EC7 File Offset: 0x001012C7
	public BattleEffectBase BattleEffect
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleEffect>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BattleEffect>k__BackingField = value;
		}
	}

	// Token: 0x17000245 RID: 581
	// (get) Token: 0x0600236E RID: 9070 RVA: 0x00102ED0 File Offset: 0x001012D0
	// (set) Token: 0x0600236F RID: 9071 RVA: 0x00102ED8 File Offset: 0x001012D8
	public IBattleUnit DispersedBy
	{
		[CompilerGenerated]
		get
		{
			return this.<DispersedBy>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<DispersedBy>k__BackingField = value;
		}
	}

	// Token: 0x04001E67 RID: 7783
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BattleEffectBase <BattleEffect>k__BackingField;

	// Token: 0x04001E68 RID: 7784
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <DispersedBy>k__BackingField;
}
