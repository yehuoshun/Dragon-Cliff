using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000760 RID: 1888
public class KillingIntentEffect : BattleEffectBase
{
	// Token: 0x060036C4 RID: 14020 RVA: 0x0016A788 File Offset: 0x00168B88
	public KillingIntentEffect(string effectSourceIdentityCode, IBattleEffectSource effectSource, int? numberOfLastingTurns)
	{
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		this._battleEffectType = BattleEffectType.KillingIntent;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._canBeDispersed = true;
		this._maxStackableInstances = new int?(10);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this.MaxNumberOfLastingSeconds = null;
		this.NumberOfLastingTurns = numberOfLastingTurns;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.KillingIntent.GetDescription();
	}

	// Token: 0x060036C5 RID: 14021 RVA: 0x0016A808 File Offset: 0x00168C08
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x170009C5 RID: 2501
	// (get) Token: 0x060036C6 RID: 14022 RVA: 0x0016A80F File Offset: 0x00168C0F
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170009C6 RID: 2502
	// (get) Token: 0x060036C7 RID: 14023 RVA: 0x0016A817 File Offset: 0x00168C17
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170009C7 RID: 2503
	// (get) Token: 0x060036C8 RID: 14024 RVA: 0x0016A81F File Offset: 0x00168C1F
	// (set) Token: 0x060036C9 RID: 14025 RVA: 0x0016A827 File Offset: 0x00168C27
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

	// Token: 0x170009C8 RID: 2504
	// (get) Token: 0x060036CA RID: 14026 RVA: 0x0016A830 File Offset: 0x00168C30
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170009C9 RID: 2505
	// (get) Token: 0x060036CB RID: 14027 RVA: 0x0016A838 File Offset: 0x00168C38
	// (set) Token: 0x060036CC RID: 14028 RVA: 0x0016A840 File Offset: 0x00168C40
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

	// Token: 0x170009CA RID: 2506
	// (get) Token: 0x060036CD RID: 14029 RVA: 0x0016A849 File Offset: 0x00168C49
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170009CB RID: 2507
	// (get) Token: 0x060036CE RID: 14030 RVA: 0x0016A851 File Offset: 0x00168C51
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170009CC RID: 2508
	// (get) Token: 0x060036CF RID: 14031 RVA: 0x0016A859 File Offset: 0x00168C59
	// (set) Token: 0x060036D0 RID: 14032 RVA: 0x0016A861 File Offset: 0x00168C61
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

	// Token: 0x170009CD RID: 2509
	// (get) Token: 0x060036D1 RID: 14033 RVA: 0x0016A86A File Offset: 0x00168C6A
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170009CE RID: 2510
	// (get) Token: 0x060036D2 RID: 14034 RVA: 0x0016A872 File Offset: 0x00168C72
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002A83 RID: 10883
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002A84 RID: 10884
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002A85 RID: 10885
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002A86 RID: 10886
	private readonly bool _isThroughEffect;

	// Token: 0x04002A87 RID: 10887
	private readonly bool _canBeImmuned;

	// Token: 0x04002A88 RID: 10888
	private bool _canBeDispersed;

	// Token: 0x04002A89 RID: 10889
	private readonly int? _maxStackableInstances;

	// Token: 0x04002A8A RID: 10890
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002A8B RID: 10891
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002A8C RID: 10892
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;
}
