using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200074B RID: 1867
public sealed class DamageReductionByValueEffect : BattleEffectBase
{
	// Token: 0x06003584 RID: 13700 RVA: 0x00166398 File Offset: 0x00164798
	public DamageReductionByValueEffect(double value, IBattleEffectSource effectSource, int? maxNumberOfLastingTurns, int? maxNumberOfSeconds, bool canbeDispersed)
	{
		this._effectSourceIdentityCode = "uniquedamagereductionbyvalue";
		this._battleEffectType = BattleEffectType.DamageReductionByValue;
		this._effectSource = effectSource;
		this.NumberOfLastingTurns = maxNumberOfLastingTurns;
		this.MaxNumberOfLastingSeconds = ((maxNumberOfSeconds == null) ? null : new float?((float)maxNumberOfSeconds.Value));
		this.ReductionValue = value;
		if (this.ReductionValue > 50000000.0)
		{
			this.ReductionValue = 50000000.0;
		}
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this.CanBeDispersed = canbeDispersed;
		base.Description = this.BattleEffectType.GetDescription();
		base.Description.Details1 = base.Description.Details1.Replace("{value}", this.ReductionValue.ToExpression());
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x06003585 RID: 13701 RVA: 0x00166493 File Offset: 0x00164893
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x170008FE RID: 2302
	// (get) Token: 0x06003586 RID: 13702 RVA: 0x0016649A File Offset: 0x0016489A
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170008FF RID: 2303
	// (get) Token: 0x06003587 RID: 13703 RVA: 0x001664A2 File Offset: 0x001648A2
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000900 RID: 2304
	// (get) Token: 0x06003588 RID: 13704 RVA: 0x001664AA File Offset: 0x001648AA
	// (set) Token: 0x06003589 RID: 13705 RVA: 0x001664B2 File Offset: 0x001648B2
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

	// Token: 0x17000901 RID: 2305
	// (get) Token: 0x0600358A RID: 13706 RVA: 0x001664BB File Offset: 0x001648BB
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000902 RID: 2306
	// (get) Token: 0x0600358B RID: 13707 RVA: 0x001664C3 File Offset: 0x001648C3
	// (set) Token: 0x0600358C RID: 13708 RVA: 0x001664CB File Offset: 0x001648CB
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

	// Token: 0x17000903 RID: 2307
	// (get) Token: 0x0600358D RID: 13709 RVA: 0x001664D4 File Offset: 0x001648D4
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000904 RID: 2308
	// (get) Token: 0x0600358E RID: 13710 RVA: 0x001664DC File Offset: 0x001648DC
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000905 RID: 2309
	// (get) Token: 0x0600358F RID: 13711 RVA: 0x001664E4 File Offset: 0x001648E4
	// (set) Token: 0x06003590 RID: 13712 RVA: 0x001664EC File Offset: 0x001648EC
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

	// Token: 0x17000906 RID: 2310
	// (get) Token: 0x06003591 RID: 13713 RVA: 0x001664F5 File Offset: 0x001648F5
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000907 RID: 2311
	// (get) Token: 0x06003592 RID: 13714 RVA: 0x001664FD File Offset: 0x001648FD
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x040029C1 RID: 10689
	private string _effectSourceIdentityCode;

	// Token: 0x040029C2 RID: 10690
	private BattleEffectType _battleEffectType;

	// Token: 0x040029C3 RID: 10691
	private IBattleEffectSource _effectSource;

	// Token: 0x040029C4 RID: 10692
	private bool _isThroughEffect;

	// Token: 0x040029C5 RID: 10693
	private bool _canBeImmuned;

	// Token: 0x040029C6 RID: 10694
	private int? _maxStackableInstances;

	// Token: 0x040029C7 RID: 10695
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x040029C8 RID: 10696
	public double ReductionValue;

	// Token: 0x040029C9 RID: 10697
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x040029CA RID: 10698
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x040029CB RID: 10699
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
