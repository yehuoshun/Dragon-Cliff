using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000772 RID: 1906
public class TargetEffect : BattleEffectBase
{
	// Token: 0x060037F0 RID: 14320 RVA: 0x001709C0 File Offset: 0x0016EDC0
	public TargetEffect(string effectSourceIdentityCode, IBattleEffectSource effectSource, float? maxNumberOfLastingSeconds, int? numberOfLastingTurns)
	{
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		this._effectSource = effectSource;
		this.MaxNumberOfLastingSeconds = maxNumberOfLastingSeconds;
		this.NumberOfLastingTurns = numberOfLastingTurns;
		this._battleEffectNatureForWearer = BattleEffectNature.Negative;
		this._battleEffectType = BattleEffectType.TargettedEffect;
		this._isThroughEffect = false;
		this._canBeImmuned = true;
		this._canBeDispersed = true;
		this._maxStackableInstances = new int?(10);
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.TargettedEffect.GetDescription();
	}

	// Token: 0x060037F1 RID: 14321 RVA: 0x00170A39 File Offset: 0x0016EE39
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000A7A RID: 2682
	// (get) Token: 0x060037F2 RID: 14322 RVA: 0x00170A40 File Offset: 0x0016EE40
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A7B RID: 2683
	// (get) Token: 0x060037F3 RID: 14323 RVA: 0x00170A48 File Offset: 0x0016EE48
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A7C RID: 2684
	// (get) Token: 0x060037F4 RID: 14324 RVA: 0x00170A50 File Offset: 0x0016EE50
	// (set) Token: 0x060037F5 RID: 14325 RVA: 0x00170A58 File Offset: 0x0016EE58
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

	// Token: 0x17000A7D RID: 2685
	// (get) Token: 0x060037F6 RID: 14326 RVA: 0x00170A61 File Offset: 0x0016EE61
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A7E RID: 2686
	// (get) Token: 0x060037F7 RID: 14327 RVA: 0x00170A69 File Offset: 0x0016EE69
	// (set) Token: 0x060037F8 RID: 14328 RVA: 0x00170A71 File Offset: 0x0016EE71
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

	// Token: 0x17000A7F RID: 2687
	// (get) Token: 0x060037F9 RID: 14329 RVA: 0x00170A7A File Offset: 0x0016EE7A
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A80 RID: 2688
	// (get) Token: 0x060037FA RID: 14330 RVA: 0x00170A82 File Offset: 0x0016EE82
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A81 RID: 2689
	// (get) Token: 0x060037FB RID: 14331 RVA: 0x00170A8A File Offset: 0x0016EE8A
	// (set) Token: 0x060037FC RID: 14332 RVA: 0x00170A92 File Offset: 0x0016EE92
	public override bool CanBeDispersed
	{
		get
		{
			return this._canBeDispersed;
		}
		set
		{
			this._canBeDispersed = value;
		}
	}

	// Token: 0x17000A82 RID: 2690
	// (get) Token: 0x060037FD RID: 14333 RVA: 0x00170A9B File Offset: 0x0016EE9B
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A83 RID: 2691
	// (get) Token: 0x060037FE RID: 14334 RVA: 0x00170AA3 File Offset: 0x0016EEA3
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002B49 RID: 11081
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002B4A RID: 11082
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002B4B RID: 11083
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002B4C RID: 11084
	private readonly bool _isThroughEffect;

	// Token: 0x04002B4D RID: 11085
	private readonly bool _canBeImmuned;

	// Token: 0x04002B4E RID: 11086
	private bool _canBeDispersed;

	// Token: 0x04002B4F RID: 11087
	private readonly int? _maxStackableInstances;

	// Token: 0x04002B50 RID: 11088
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002B51 RID: 11089
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002B52 RID: 11090
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;
}
