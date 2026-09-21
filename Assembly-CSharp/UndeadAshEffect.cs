using System;
using System.Collections.Generic;

// Token: 0x0200073C RID: 1852
public class UndeadAshEffect : BattleEffectBase
{
	// Token: 0x06003486 RID: 13446 RVA: 0x0015F26C File Offset: 0x0015D66C
	public UndeadAshEffect(string effectSourceIdentityCode, float? maxNumberOfLastingSeconds, IBattleEffectSource effectSource, int? numberOfLastingTurns, double inRate)
	{
		Description description = this.BattleEffectType.GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", inRate.ToExpressionMultiply100());
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		this._maxNumberOfLastingSeconds = maxNumberOfLastingSeconds;
		this._effectSource = effectSource;
		this._numberOfLastingTurns = numberOfLastingTurns;
		this.increaseRate = inRate;
		base.Description = description;
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x06003487 RID: 13447 RVA: 0x0015F2FC File Offset: 0x0015D6FC
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Addition,
				AttributeType = AttributeType.CritDamage,
				Value = this.increaseRate,
				AttributeModifierType = AttributeModifierType.Skill,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06003488 RID: 13448 RVA: 0x0015F349 File Offset: 0x0015D749
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000876 RID: 2166
	// (get) Token: 0x06003489 RID: 13449 RVA: 0x0015F350 File Offset: 0x0015D750
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000877 RID: 2167
	// (get) Token: 0x0600348A RID: 13450 RVA: 0x0015F358 File Offset: 0x0015D758
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000878 RID: 2168
	// (get) Token: 0x0600348B RID: 13451 RVA: 0x0015F360 File Offset: 0x0015D760
	// (set) Token: 0x0600348C RID: 13452 RVA: 0x0015F368 File Offset: 0x0015D768
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

	// Token: 0x17000879 RID: 2169
	// (get) Token: 0x0600348D RID: 13453 RVA: 0x0015F371 File Offset: 0x0015D771
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x1700087A RID: 2170
	// (get) Token: 0x0600348E RID: 13454 RVA: 0x0015F379 File Offset: 0x0015D779
	// (set) Token: 0x0600348F RID: 13455 RVA: 0x0015F381 File Offset: 0x0015D781
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

	// Token: 0x1700087B RID: 2171
	// (get) Token: 0x06003490 RID: 13456 RVA: 0x0015F38A File Offset: 0x0015D78A
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x1700087C RID: 2172
	// (get) Token: 0x06003491 RID: 13457 RVA: 0x0015F392 File Offset: 0x0015D792
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x1700087D RID: 2173
	// (get) Token: 0x06003492 RID: 13458 RVA: 0x0015F39A File Offset: 0x0015D79A
	// (set) Token: 0x06003493 RID: 13459 RVA: 0x0015F3A2 File Offset: 0x0015D7A2
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

	// Token: 0x1700087E RID: 2174
	// (get) Token: 0x06003494 RID: 13460 RVA: 0x0015F3AB File Offset: 0x0015D7AB
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x1700087F RID: 2175
	// (get) Token: 0x06003495 RID: 13461 RVA: 0x0015F3B3 File Offset: 0x0015D7B3
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x040028BE RID: 10430
	private string _effectSourceIdentityCode;

	// Token: 0x040028BF RID: 10431
	private BattleEffectType _battleEffectType = BattleEffectType.UndeadAsh;

	// Token: 0x040028C0 RID: 10432
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x040028C1 RID: 10433
	private IBattleEffectSource _effectSource;

	// Token: 0x040028C2 RID: 10434
	private int? _numberOfLastingTurns;

	// Token: 0x040028C3 RID: 10435
	private bool _isThroughEffect;

	// Token: 0x040028C4 RID: 10436
	private bool _canBeImmuned;

	// Token: 0x040028C5 RID: 10437
	private bool _canBeDispersed = true;

	// Token: 0x040028C6 RID: 10438
	private int? _maxStackableInstances = new int?(5);

	// Token: 0x040028C7 RID: 10439
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x040028C8 RID: 10440
	private double increaseRate;
}
