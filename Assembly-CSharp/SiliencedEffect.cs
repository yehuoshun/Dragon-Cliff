using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200076D RID: 1901
public sealed class SiliencedEffect : BattleEffectBase
{
	// Token: 0x060037A0 RID: 14240 RVA: 0x0016F998 File Offset: 0x0016DD98
	public SiliencedEffect(int? lastingTurns, int? maxSeconds, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = "siliencedcode";
		this._battleEffectType = BattleEffectType.Silienced;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = true;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Negative;
		this.MaxNumberOfLastingSeconds = ((maxSeconds == null) ? null : new float?((float)maxSeconds.Value));
		this.NumberOfLastingTurns = lastingTurns;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.Silienced.GetDescription();
		this.CanBeDispersed = true;
	}

	// Token: 0x060037A1 RID: 14241 RVA: 0x0016FA39 File Offset: 0x0016DE39
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000A48 RID: 2632
	// (get) Token: 0x060037A2 RID: 14242 RVA: 0x0016FA40 File Offset: 0x0016DE40
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A49 RID: 2633
	// (get) Token: 0x060037A3 RID: 14243 RVA: 0x0016FA48 File Offset: 0x0016DE48
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A4A RID: 2634
	// (get) Token: 0x060037A4 RID: 14244 RVA: 0x0016FA50 File Offset: 0x0016DE50
	// (set) Token: 0x060037A5 RID: 14245 RVA: 0x0016FA58 File Offset: 0x0016DE58
	public override float? MaxNumberOfLastingSeconds
	{
		[CompilerGenerated]
		get
		{
			return this.<MaxNumberOfLastingSeconds>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<MaxNumberOfLastingSeconds>k__BackingField = value;
		}
	}

	// Token: 0x17000A4B RID: 2635
	// (get) Token: 0x060037A6 RID: 14246 RVA: 0x0016FA61 File Offset: 0x0016DE61
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A4C RID: 2636
	// (get) Token: 0x060037A7 RID: 14247 RVA: 0x0016FA69 File Offset: 0x0016DE69
	// (set) Token: 0x060037A8 RID: 14248 RVA: 0x0016FA71 File Offset: 0x0016DE71
	public override int? NumberOfLastingTurns
	{
		[CompilerGenerated]
		get
		{
			return this.<NumberOfLastingTurns>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<NumberOfLastingTurns>k__BackingField = value;
		}
	}

	// Token: 0x17000A4D RID: 2637
	// (get) Token: 0x060037A9 RID: 14249 RVA: 0x0016FA7A File Offset: 0x0016DE7A
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A4E RID: 2638
	// (get) Token: 0x060037AA RID: 14250 RVA: 0x0016FA82 File Offset: 0x0016DE82
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A4F RID: 2639
	// (get) Token: 0x060037AB RID: 14251 RVA: 0x0016FA8A File Offset: 0x0016DE8A
	// (set) Token: 0x060037AC RID: 14252 RVA: 0x0016FA92 File Offset: 0x0016DE92
	public override bool CanBeDispersed
	{
		[CompilerGenerated]
		get
		{
			return this.<CanBeDispersed>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CanBeDispersed>k__BackingField = value;
		}
	}

	// Token: 0x17000A50 RID: 2640
	// (get) Token: 0x060037AD RID: 14253 RVA: 0x0016FA9B File Offset: 0x0016DE9B
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A51 RID: 2641
	// (get) Token: 0x060037AE RID: 14254 RVA: 0x0016FAA3 File Offset: 0x0016DEA3
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002B11 RID: 11025
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002B12 RID: 11026
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002B13 RID: 11027
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002B14 RID: 11028
	private readonly bool _isThroughEffect;

	// Token: 0x04002B15 RID: 11029
	private readonly bool _canBeImmuned;

	// Token: 0x04002B16 RID: 11030
	private readonly int? _maxStackableInstances;

	// Token: 0x04002B17 RID: 11031
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002B18 RID: 11032
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002B19 RID: 11033
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002B1A RID: 11034
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
