using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000773 RID: 1907
public class TargettedEffect : BattleEffectBase
{
	// Token: 0x060037FF RID: 14335 RVA: 0x00170AAC File Offset: 0x0016EEAC
	public TargettedEffect(float? maxSeconds, IBattleEffectSource effectSource)
	{
		this._effectSource = effectSource;
		this._effectSourceIdentityCode = "unique";
		this._battleEffectType = BattleEffectType.Targetted;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Negative;
		this.MaxNumberOfLastingSeconds = maxSeconds;
		this.CanBeDispersed = true;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.Targetted.GetDescription();
	}

	// Token: 0x06003800 RID: 14336 RVA: 0x00170B20 File Offset: 0x0016EF20
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000A84 RID: 2692
	// (get) Token: 0x06003801 RID: 14337 RVA: 0x00170B27 File Offset: 0x0016EF27
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A85 RID: 2693
	// (get) Token: 0x06003802 RID: 14338 RVA: 0x00170B2F File Offset: 0x0016EF2F
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A86 RID: 2694
	// (get) Token: 0x06003803 RID: 14339 RVA: 0x00170B37 File Offset: 0x0016EF37
	// (set) Token: 0x06003804 RID: 14340 RVA: 0x00170B3F File Offset: 0x0016EF3F
	public sealed override float? MaxNumberOfLastingSeconds
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

	// Token: 0x17000A87 RID: 2695
	// (get) Token: 0x06003805 RID: 14341 RVA: 0x00170B48 File Offset: 0x0016EF48
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A88 RID: 2696
	// (get) Token: 0x06003806 RID: 14342 RVA: 0x00170B50 File Offset: 0x0016EF50
	// (set) Token: 0x06003807 RID: 14343 RVA: 0x00170B58 File Offset: 0x0016EF58
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

	// Token: 0x17000A89 RID: 2697
	// (get) Token: 0x06003808 RID: 14344 RVA: 0x00170B61 File Offset: 0x0016EF61
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A8A RID: 2698
	// (get) Token: 0x06003809 RID: 14345 RVA: 0x00170B69 File Offset: 0x0016EF69
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A8B RID: 2699
	// (get) Token: 0x0600380A RID: 14346 RVA: 0x00170B71 File Offset: 0x0016EF71
	// (set) Token: 0x0600380B RID: 14347 RVA: 0x00170B79 File Offset: 0x0016EF79
	public sealed override bool CanBeDispersed
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

	// Token: 0x17000A8C RID: 2700
	// (get) Token: 0x0600380C RID: 14348 RVA: 0x00170B82 File Offset: 0x0016EF82
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A8D RID: 2701
	// (get) Token: 0x0600380D RID: 14349 RVA: 0x00170B8A File Offset: 0x0016EF8A
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002B53 RID: 11091
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002B54 RID: 11092
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002B55 RID: 11093
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002B56 RID: 11094
	private readonly bool _isThroughEffect;

	// Token: 0x04002B57 RID: 11095
	private readonly bool _canBeImmuned;

	// Token: 0x04002B58 RID: 11096
	private readonly int? _maxStackableInstances;

	// Token: 0x04002B59 RID: 11097
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002B5A RID: 11098
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002B5B RID: 11099
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002B5C RID: 11100
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
