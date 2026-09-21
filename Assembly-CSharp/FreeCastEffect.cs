using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000757 RID: 1879
public sealed class FreeCastEffect : BattleEffectBase
{
	// Token: 0x0600364E RID: 13902 RVA: 0x001683F0 File Offset: 0x001667F0
	public FreeCastEffect(IBattleEffectSource effectsource, int? seconds, int? turns, int maxStackable, string code)
	{
		this._effectSourceIdentityCode = code;
		this._battleEffectType = BattleEffectType.FreeCast;
		this._effectSource = effectsource;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(maxStackable);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this.MaxNumberOfLastingSeconds = ((seconds == null) ? null : new float?((float)seconds.Value));
		this.NumberOfLastingTurns = turns;
		this.CanBeDispersed = true;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.FreeCast.GetDescription();
	}

	// Token: 0x0600364F RID: 13903 RVA: 0x0016848F File Offset: 0x0016688F
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x1700097D RID: 2429
	// (get) Token: 0x06003650 RID: 13904 RVA: 0x00168496 File Offset: 0x00166896
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x1700097E RID: 2430
	// (get) Token: 0x06003651 RID: 13905 RVA: 0x0016849E File Offset: 0x0016689E
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x1700097F RID: 2431
	// (get) Token: 0x06003652 RID: 13906 RVA: 0x001684A6 File Offset: 0x001668A6
	// (set) Token: 0x06003653 RID: 13907 RVA: 0x001684AE File Offset: 0x001668AE
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

	// Token: 0x17000980 RID: 2432
	// (get) Token: 0x06003654 RID: 13908 RVA: 0x001684B7 File Offset: 0x001668B7
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000981 RID: 2433
	// (get) Token: 0x06003655 RID: 13909 RVA: 0x001684BF File Offset: 0x001668BF
	// (set) Token: 0x06003656 RID: 13910 RVA: 0x001684C7 File Offset: 0x001668C7
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

	// Token: 0x17000982 RID: 2434
	// (get) Token: 0x06003657 RID: 13911 RVA: 0x001684D0 File Offset: 0x001668D0
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000983 RID: 2435
	// (get) Token: 0x06003658 RID: 13912 RVA: 0x001684D8 File Offset: 0x001668D8
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000984 RID: 2436
	// (get) Token: 0x06003659 RID: 13913 RVA: 0x001684E0 File Offset: 0x001668E0
	// (set) Token: 0x0600365A RID: 13914 RVA: 0x001684E8 File Offset: 0x001668E8
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

	// Token: 0x17000985 RID: 2437
	// (get) Token: 0x0600365B RID: 13915 RVA: 0x001684F1 File Offset: 0x001668F1
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000986 RID: 2438
	// (get) Token: 0x0600365C RID: 13916 RVA: 0x001684F9 File Offset: 0x001668F9
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002A36 RID: 10806
	private string _effectSourceIdentityCode;

	// Token: 0x04002A37 RID: 10807
	private BattleEffectType _battleEffectType;

	// Token: 0x04002A38 RID: 10808
	private IBattleEffectSource _effectSource;

	// Token: 0x04002A39 RID: 10809
	private bool _isThroughEffect;

	// Token: 0x04002A3A RID: 10810
	private bool _canBeImmuned;

	// Token: 0x04002A3B RID: 10811
	private int? _maxStackableInstances;

	// Token: 0x04002A3C RID: 10812
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002A3D RID: 10813
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002A3E RID: 10814
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002A3F RID: 10815
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
