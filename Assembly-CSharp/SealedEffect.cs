using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200076C RID: 1900
public class SealedEffect : BattleEffectBase
{
	// Token: 0x06003791 RID: 14225 RVA: 0x0016F8A8 File Offset: 0x0016DCA8
	public SealedEffect(float? maxNumberOfSeconds, int? lastingTurns, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = "unique";
		this._battleEffectType = BattleEffectType.Sealed;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = true;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Negative;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.Sealed.GetDescription();
		this.MaxNumberOfLastingSeconds = maxNumberOfSeconds;
		this.NumberOfLastingTurns = lastingTurns;
		this.CanBeDispersed = true;
	}

	// Token: 0x06003792 RID: 14226 RVA: 0x0016F923 File Offset: 0x0016DD23
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000A3E RID: 2622
	// (get) Token: 0x06003793 RID: 14227 RVA: 0x0016F92A File Offset: 0x0016DD2A
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A3F RID: 2623
	// (get) Token: 0x06003794 RID: 14228 RVA: 0x0016F932 File Offset: 0x0016DD32
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A40 RID: 2624
	// (get) Token: 0x06003795 RID: 14229 RVA: 0x0016F93A File Offset: 0x0016DD3A
	// (set) Token: 0x06003796 RID: 14230 RVA: 0x0016F942 File Offset: 0x0016DD42
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

	// Token: 0x17000A41 RID: 2625
	// (get) Token: 0x06003797 RID: 14231 RVA: 0x0016F94B File Offset: 0x0016DD4B
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A42 RID: 2626
	// (get) Token: 0x06003798 RID: 14232 RVA: 0x0016F953 File Offset: 0x0016DD53
	// (set) Token: 0x06003799 RID: 14233 RVA: 0x0016F95B File Offset: 0x0016DD5B
	public sealed override int? NumberOfLastingTurns
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

	// Token: 0x17000A43 RID: 2627
	// (get) Token: 0x0600379A RID: 14234 RVA: 0x0016F964 File Offset: 0x0016DD64
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A44 RID: 2628
	// (get) Token: 0x0600379B RID: 14235 RVA: 0x0016F96C File Offset: 0x0016DD6C
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A45 RID: 2629
	// (get) Token: 0x0600379C RID: 14236 RVA: 0x0016F974 File Offset: 0x0016DD74
	// (set) Token: 0x0600379D RID: 14237 RVA: 0x0016F97C File Offset: 0x0016DD7C
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

	// Token: 0x17000A46 RID: 2630
	// (get) Token: 0x0600379E RID: 14238 RVA: 0x0016F985 File Offset: 0x0016DD85
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A47 RID: 2631
	// (get) Token: 0x0600379F RID: 14239 RVA: 0x0016F98D File Offset: 0x0016DD8D
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002B07 RID: 11015
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002B08 RID: 11016
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002B09 RID: 11017
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002B0A RID: 11018
	private readonly bool _isThroughEffect;

	// Token: 0x04002B0B RID: 11019
	private readonly bool _canBeImmuned;

	// Token: 0x04002B0C RID: 11020
	private readonly int? _maxStackableInstances;

	// Token: 0x04002B0D RID: 11021
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002B0E RID: 11022
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002B0F RID: 11023
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002B10 RID: 11024
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
