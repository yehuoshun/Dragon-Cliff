using System;
using System.Collections.Generic;
using System.Linq;

// Token: 0x0200073B RID: 1851
public class SoulCollectedBoostEffect : BattleEffectBase
{
	// Token: 0x06003476 RID: 13430 RVA: 0x0015F140 File Offset: 0x0015D540
	public SoulCollectedBoostEffect(AttributeType boostType, double boostValue, IBattleUnit sourceUnit, string sourceIdentityCode)
	{
		this._effectSourceIdentityCode = sourceIdentityCode;
		this._modifiers = new List<AttributeModifier>
		{
			new AttributeModifier
			{
				AttributeType = boostType,
				Value = boostValue,
				AttributeModifierType = AttributeModifierType.Skill,
				ModificationType = ModificationType.Addition,
				Key = string.Empty
			}
		};
		this._canBeDispersed = !sourceUnit.SpecialEffects.OfType<SoulCollectionUndispellableData>().Any<SoulCollectionUndispellableData>();
		this._effectSource = sourceUnit;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.SoulCollectedBoost.GetDescription();
	}

	// Token: 0x06003477 RID: 13431 RVA: 0x0015F1EA File Offset: 0x0015D5EA
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return this._modifiers;
	}

	// Token: 0x06003478 RID: 13432 RVA: 0x0015F1F2 File Offset: 0x0015D5F2
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x1700086C RID: 2156
	// (get) Token: 0x06003479 RID: 13433 RVA: 0x0015F1F9 File Offset: 0x0015D5F9
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x1700086D RID: 2157
	// (get) Token: 0x0600347A RID: 13434 RVA: 0x0015F201 File Offset: 0x0015D601
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x1700086E RID: 2158
	// (get) Token: 0x0600347B RID: 13435 RVA: 0x0015F209 File Offset: 0x0015D609
	// (set) Token: 0x0600347C RID: 13436 RVA: 0x0015F211 File Offset: 0x0015D611
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

	// Token: 0x1700086F RID: 2159
	// (get) Token: 0x0600347D RID: 13437 RVA: 0x0015F21A File Offset: 0x0015D61A
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000870 RID: 2160
	// (get) Token: 0x0600347E RID: 13438 RVA: 0x0015F222 File Offset: 0x0015D622
	// (set) Token: 0x0600347F RID: 13439 RVA: 0x0015F22A File Offset: 0x0015D62A
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

	// Token: 0x17000871 RID: 2161
	// (get) Token: 0x06003480 RID: 13440 RVA: 0x0015F233 File Offset: 0x0015D633
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000872 RID: 2162
	// (get) Token: 0x06003481 RID: 13441 RVA: 0x0015F23B File Offset: 0x0015D63B
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000873 RID: 2163
	// (get) Token: 0x06003482 RID: 13442 RVA: 0x0015F243 File Offset: 0x0015D643
	// (set) Token: 0x06003483 RID: 13443 RVA: 0x0015F24B File Offset: 0x0015D64B
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

	// Token: 0x17000874 RID: 2164
	// (get) Token: 0x06003484 RID: 13444 RVA: 0x0015F254 File Offset: 0x0015D654
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(this._maxStackableInstances);
		}
	}

	// Token: 0x17000875 RID: 2165
	// (get) Token: 0x06003485 RID: 13445 RVA: 0x0015F261 File Offset: 0x0015D661
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x040028B3 RID: 10419
	private BattleEffectType _battleEffectType = BattleEffectType.SoulCollectedBoost;

	// Token: 0x040028B4 RID: 10420
	private int? _numberOfLastingTurns;

	// Token: 0x040028B5 RID: 10421
	private bool _isThroughEffect = true;

	// Token: 0x040028B6 RID: 10422
	private bool _canBeImmuned;

	// Token: 0x040028B7 RID: 10423
	private bool _canBeDispersed;

	// Token: 0x040028B8 RID: 10424
	private int _maxStackableInstances = 5;

	// Token: 0x040028B9 RID: 10425
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x040028BA RID: 10426
	private List<AttributeModifier> _modifiers;

	// Token: 0x040028BB RID: 10427
	private string _effectSourceIdentityCode;

	// Token: 0x040028BC RID: 10428
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x040028BD RID: 10429
	private IBattleEffectSource _effectSource;
}
