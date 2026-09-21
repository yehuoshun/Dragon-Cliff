using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000759 RID: 1881
public sealed class FrozenHeartEffect : BattleEffectBase
{
	// Token: 0x0600366D RID: 13933 RVA: 0x00168FF8 File Offset: 0x001673F8
	public FrozenHeartEffect(int? lastingSeconds, int? lastingTurns, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = "uniquefrozenheartcode";
		this._battleEffectType = BattleEffectType.FrozenHeart;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = true;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Negative;
		this.CanBeDispersed = true;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = this._battleEffectType.GetDescription();
		this.MaxNumberOfLastingSeconds = ((lastingSeconds == null) ? null : new float?((float)lastingSeconds.Value));
		this.NumberOfLastingTurns = lastingTurns;
	}

	// Token: 0x0600366E RID: 13934 RVA: 0x0016909D File Offset: 0x0016749D
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000991 RID: 2449
	// (get) Token: 0x0600366F RID: 13935 RVA: 0x001690A4 File Offset: 0x001674A4
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000992 RID: 2450
	// (get) Token: 0x06003670 RID: 13936 RVA: 0x001690AC File Offset: 0x001674AC
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000993 RID: 2451
	// (get) Token: 0x06003671 RID: 13937 RVA: 0x001690B4 File Offset: 0x001674B4
	// (set) Token: 0x06003672 RID: 13938 RVA: 0x001690BC File Offset: 0x001674BC
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

	// Token: 0x17000994 RID: 2452
	// (get) Token: 0x06003673 RID: 13939 RVA: 0x001690C5 File Offset: 0x001674C5
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000995 RID: 2453
	// (get) Token: 0x06003674 RID: 13940 RVA: 0x001690CD File Offset: 0x001674CD
	// (set) Token: 0x06003675 RID: 13941 RVA: 0x001690D5 File Offset: 0x001674D5
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

	// Token: 0x17000996 RID: 2454
	// (get) Token: 0x06003676 RID: 13942 RVA: 0x001690DE File Offset: 0x001674DE
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000997 RID: 2455
	// (get) Token: 0x06003677 RID: 13943 RVA: 0x001690E6 File Offset: 0x001674E6
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000998 RID: 2456
	// (get) Token: 0x06003678 RID: 13944 RVA: 0x001690EE File Offset: 0x001674EE
	// (set) Token: 0x06003679 RID: 13945 RVA: 0x001690F6 File Offset: 0x001674F6
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

	// Token: 0x17000999 RID: 2457
	// (get) Token: 0x0600367A RID: 13946 RVA: 0x001690FF File Offset: 0x001674FF
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x1700099A RID: 2458
	// (get) Token: 0x0600367B RID: 13947 RVA: 0x00169107 File Offset: 0x00167507
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002A4B RID: 10827
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002A4C RID: 10828
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002A4D RID: 10829
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002A4E RID: 10830
	private readonly bool _isThroughEffect;

	// Token: 0x04002A4F RID: 10831
	private readonly bool _canBeImmuned;

	// Token: 0x04002A50 RID: 10832
	private readonly int? _maxStackableInstances;

	// Token: 0x04002A51 RID: 10833
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002A52 RID: 10834
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002A53 RID: 10835
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002A54 RID: 10836
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
