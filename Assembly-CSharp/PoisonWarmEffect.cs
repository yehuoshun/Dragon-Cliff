using System;
using System.Collections.Generic;

// Token: 0x02000766 RID: 1894
public class PoisonWarmEffect : BattleEffectBase
{
	// Token: 0x0600372C RID: 14124 RVA: 0x0016D3B4 File Offset: 0x0016B7B4
	public PoisonWarmEffect(string code, int maxNumberOfSwarms, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = code;
		this._battleEffectType = BattleEffectType.PoisonWarm;
		this._maxNumberOfLastingSeconds = null;
		this._effectSource = effectSource;
		this._numberOfLastingTurns = null;
		this._isThroughEffect = false;
		this._canBeImmuned = true;
		this._canBeDispersed = true;
		this._maxStackableInstances = new int?(maxNumberOfSwarms);
		this._battleEffectNatureForWearer = BattleEffectNature.Negative;
		base.Description = BattleEffectType.PoisonWarm.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x0600372D RID: 14125 RVA: 0x0016D43B File Offset: 0x0016B83B
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000A02 RID: 2562
	// (get) Token: 0x0600372E RID: 14126 RVA: 0x0016D442 File Offset: 0x0016B842
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A03 RID: 2563
	// (get) Token: 0x0600372F RID: 14127 RVA: 0x0016D44A File Offset: 0x0016B84A
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A04 RID: 2564
	// (get) Token: 0x06003730 RID: 14128 RVA: 0x0016D452 File Offset: 0x0016B852
	// (set) Token: 0x06003731 RID: 14129 RVA: 0x0016D45A File Offset: 0x0016B85A
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

	// Token: 0x17000A05 RID: 2565
	// (get) Token: 0x06003732 RID: 14130 RVA: 0x0016D463 File Offset: 0x0016B863
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A06 RID: 2566
	// (get) Token: 0x06003733 RID: 14131 RVA: 0x0016D46B File Offset: 0x0016B86B
	// (set) Token: 0x06003734 RID: 14132 RVA: 0x0016D473 File Offset: 0x0016B873
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

	// Token: 0x17000A07 RID: 2567
	// (get) Token: 0x06003735 RID: 14133 RVA: 0x0016D47C File Offset: 0x0016B87C
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A08 RID: 2568
	// (get) Token: 0x06003736 RID: 14134 RVA: 0x0016D484 File Offset: 0x0016B884
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A09 RID: 2569
	// (get) Token: 0x06003737 RID: 14135 RVA: 0x0016D48C File Offset: 0x0016B88C
	// (set) Token: 0x06003738 RID: 14136 RVA: 0x0016D494 File Offset: 0x0016B894
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

	// Token: 0x17000A0A RID: 2570
	// (get) Token: 0x06003739 RID: 14137 RVA: 0x0016D49D File Offset: 0x0016B89D
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A0B RID: 2571
	// (get) Token: 0x0600373A RID: 14138 RVA: 0x0016D4A5 File Offset: 0x0016B8A5
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002AC5 RID: 10949
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002AC6 RID: 10950
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002AC7 RID: 10951
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002AC8 RID: 10952
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002AC9 RID: 10953
	private int? _numberOfLastingTurns;

	// Token: 0x04002ACA RID: 10954
	private readonly bool _isThroughEffect;

	// Token: 0x04002ACB RID: 10955
	private readonly bool _canBeImmuned;

	// Token: 0x04002ACC RID: 10956
	private bool _canBeDispersed;

	// Token: 0x04002ACD RID: 10957
	private readonly int? _maxStackableInstances;

	// Token: 0x04002ACE RID: 10958
	private readonly BattleEffectNature _battleEffectNatureForWearer;
}
