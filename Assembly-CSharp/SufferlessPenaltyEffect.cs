using System;
using System.Collections.Generic;

// Token: 0x02000771 RID: 1905
public class SufferlessPenaltyEffect : BattleEffectBase
{
	// Token: 0x060037E1 RID: 14305 RVA: 0x00170910 File Offset: 0x0016ED10
	public SufferlessPenaltyEffect(string effectSourceIdentityCode, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		this._effectSource = effectSource;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.SufferlessPenalty.GetDescription();
	}

	// Token: 0x060037E2 RID: 14306 RVA: 0x0017094D File Offset: 0x0016ED4D
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000A70 RID: 2672
	// (get) Token: 0x060037E3 RID: 14307 RVA: 0x00170954 File Offset: 0x0016ED54
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A71 RID: 2673
	// (get) Token: 0x060037E4 RID: 14308 RVA: 0x0017095C File Offset: 0x0016ED5C
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A72 RID: 2674
	// (get) Token: 0x060037E5 RID: 14309 RVA: 0x00170964 File Offset: 0x0016ED64
	// (set) Token: 0x060037E6 RID: 14310 RVA: 0x0017096C File Offset: 0x0016ED6C
	public override float? MaxNumberOfLastingSeconds
	{
		get
		{
			return this._maxNumberOfLastingSeconds;
		}
		set
		{
			this._maxNumberOfLastingSeconds = value;
		}
	}

	// Token: 0x17000A73 RID: 2675
	// (get) Token: 0x060037E7 RID: 14311 RVA: 0x00170975 File Offset: 0x0016ED75
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A74 RID: 2676
	// (get) Token: 0x060037E8 RID: 14312 RVA: 0x0017097D File Offset: 0x0016ED7D
	// (set) Token: 0x060037E9 RID: 14313 RVA: 0x00170985 File Offset: 0x0016ED85
	public override int? NumberOfLastingTurns
	{
		get
		{
			return this._numberOfLastingTurns;
		}
		set
		{
			this._numberOfLastingTurns = value;
		}
	}

	// Token: 0x17000A75 RID: 2677
	// (get) Token: 0x060037EA RID: 14314 RVA: 0x0017098E File Offset: 0x0016ED8E
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A76 RID: 2678
	// (get) Token: 0x060037EB RID: 14315 RVA: 0x00170996 File Offset: 0x0016ED96
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A77 RID: 2679
	// (get) Token: 0x060037EC RID: 14316 RVA: 0x0017099E File Offset: 0x0016ED9E
	// (set) Token: 0x060037ED RID: 14317 RVA: 0x001709A6 File Offset: 0x0016EDA6
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

	// Token: 0x17000A78 RID: 2680
	// (get) Token: 0x060037EE RID: 14318 RVA: 0x001709AF File Offset: 0x0016EDAF
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A79 RID: 2681
	// (get) Token: 0x060037EF RID: 14319 RVA: 0x001709B7 File Offset: 0x0016EDB7
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002B3F RID: 11071
	private string _effectSourceIdentityCode;

	// Token: 0x04002B40 RID: 11072
	private BattleEffectType _battleEffectType = BattleEffectType.SufferlessPenalty;

	// Token: 0x04002B41 RID: 11073
	private int? _numberOfLastingTurns;

	// Token: 0x04002B42 RID: 11074
	private bool _isThroughEffect;

	// Token: 0x04002B43 RID: 11075
	private bool _canBeImmuned;

	// Token: 0x04002B44 RID: 11076
	private bool _canBeDispersed;

	// Token: 0x04002B45 RID: 11077
	private int? _maxStackableInstances;

	// Token: 0x04002B46 RID: 11078
	private BattleEffectNature _battleEffectNatureForWearer = BattleEffectNature.Negative;

	// Token: 0x04002B47 RID: 11079
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002B48 RID: 11080
	private IBattleEffectSource _effectSource;
}
