using System;
using System.Collections.Generic;

// Token: 0x02000739 RID: 1849
public class FlyingFeatherEffect : BattleEffectBase
{
	// Token: 0x06003454 RID: 13396 RVA: 0x0015ED6C File Offset: 0x0015D16C
	public FlyingFeatherEffect(IBattleEffectSource effectSource, double increaseRate)
	{
		this._effectSource = effectSource;
		this._effectSourceIdentityCode = "UNIQUE";
		base.Description = BattleEffectType.FlyingFeatherEffect.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description.Details1 = base.Description.Details1.Replace("{rate}", increaseRate.ToExpressionMultiply100());
		this._increaseRate = increaseRate;
	}

	// Token: 0x06003455 RID: 13397 RVA: 0x0015EDEC File Offset: 0x0015D1EC
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.PhysicalResistance,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = this._increaseRate,
				Key = string.Empty
			},
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.FireResistanceResistance,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = this._increaseRate,
				Key = string.Empty
			},
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.ShadowResistance,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = this._increaseRate,
				Key = string.Empty
			},
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.IceResistance,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = this._increaseRate,
				Key = string.Empty
			},
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.PoisonResistance,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = this._increaseRate,
				Key = string.Empty
			},
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.DivineResistance,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = this._increaseRate,
				Key = string.Empty
			},
			new AttributeModifier
			{
				ModificationType = ModificationType.Multiplication,
				AttributeType = AttributeType.LightningResistance,
				AttributeModifierType = AttributeModifierType.SetBonus,
				Value = this._increaseRate,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06003456 RID: 13398 RVA: 0x0015EF94 File Offset: 0x0015D394
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000857 RID: 2135
	// (get) Token: 0x06003457 RID: 13399 RVA: 0x0015EF9B File Offset: 0x0015D39B
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000858 RID: 2136
	// (get) Token: 0x06003458 RID: 13400 RVA: 0x0015EFA3 File Offset: 0x0015D3A3
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000859 RID: 2137
	// (get) Token: 0x06003459 RID: 13401 RVA: 0x0015EFAB File Offset: 0x0015D3AB
	// (set) Token: 0x0600345A RID: 13402 RVA: 0x0015EFB3 File Offset: 0x0015D3B3
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

	// Token: 0x1700085A RID: 2138
	// (get) Token: 0x0600345B RID: 13403 RVA: 0x0015EFBC File Offset: 0x0015D3BC
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x1700085B RID: 2139
	// (get) Token: 0x0600345C RID: 13404 RVA: 0x0015EFC4 File Offset: 0x0015D3C4
	// (set) Token: 0x0600345D RID: 13405 RVA: 0x0015EFCC File Offset: 0x0015D3CC
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

	// Token: 0x1700085C RID: 2140
	// (get) Token: 0x0600345E RID: 13406 RVA: 0x0015EFD5 File Offset: 0x0015D3D5
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x1700085D RID: 2141
	// (get) Token: 0x0600345F RID: 13407 RVA: 0x0015EFDD File Offset: 0x0015D3DD
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x1700085E RID: 2142
	// (get) Token: 0x06003460 RID: 13408 RVA: 0x0015EFE5 File Offset: 0x0015D3E5
	// (set) Token: 0x06003461 RID: 13409 RVA: 0x0015EFED File Offset: 0x0015D3ED
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

	// Token: 0x1700085F RID: 2143
	// (get) Token: 0x06003462 RID: 13410 RVA: 0x0015EFF6 File Offset: 0x0015D3F6
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000860 RID: 2144
	// (get) Token: 0x06003463 RID: 13411 RVA: 0x0015EFFE File Offset: 0x0015D3FE
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x040028A2 RID: 10402
	private string _effectSourceIdentityCode;

	// Token: 0x040028A3 RID: 10403
	private BattleEffectType _battleEffectType = BattleEffectType.FlyingFeatherEffect;

	// Token: 0x040028A4 RID: 10404
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x040028A5 RID: 10405
	private IBattleEffectSource _effectSource;

	// Token: 0x040028A6 RID: 10406
	private int? _numberOfLastingTurns;

	// Token: 0x040028A7 RID: 10407
	private bool _isThroughEffect;

	// Token: 0x040028A8 RID: 10408
	private bool _canBeImmuned;

	// Token: 0x040028A9 RID: 10409
	private bool _canBeDispersed;

	// Token: 0x040028AA RID: 10410
	private int? _maxStackableInstances = new int?(1);

	// Token: 0x040028AB RID: 10411
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x040028AC RID: 10412
	private double _increaseRate;
}
