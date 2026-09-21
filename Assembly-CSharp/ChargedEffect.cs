using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000737 RID: 1847
public class ChargedEffect : BattleEffectBase
{
	// Token: 0x0600342D RID: 13357 RVA: 0x0015EAD0 File Offset: 0x0015CED0
	public ChargedEffect(string effectSourceIdentityCode, List<OutputType> damageTypes, AttributeType boostAttributeType, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		this.DamageTypes = damageTypes;
		this.BoostAttributeType = boostAttributeType;
		this._effectSource = effectSource;
		base.Description = BattleEffectType.Charged.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
		this.BoostValue = 0.0;
	}

	// Token: 0x17000840 RID: 2112
	// (get) Token: 0x0600342E RID: 13358 RVA: 0x0015EB49 File Offset: 0x0015CF49
	// (set) Token: 0x0600342F RID: 13359 RVA: 0x0015EB51 File Offset: 0x0015CF51
	public List<OutputType> DamageTypes
	{
		[CompilerGenerated]
		get
		{
			return this.<DamageTypes>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<DamageTypes>k__BackingField = value;
		}
	}

	// Token: 0x17000841 RID: 2113
	// (get) Token: 0x06003430 RID: 13360 RVA: 0x0015EB5A File Offset: 0x0015CF5A
	// (set) Token: 0x06003431 RID: 13361 RVA: 0x0015EB62 File Offset: 0x0015CF62
	public double BoostValue
	{
		[CompilerGenerated]
		get
		{
			return this.<BoostValue>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<BoostValue>k__BackingField = value;
		}
	}

	// Token: 0x17000842 RID: 2114
	// (get) Token: 0x06003432 RID: 13362 RVA: 0x0015EB6B File Offset: 0x0015CF6B
	// (set) Token: 0x06003433 RID: 13363 RVA: 0x0015EB73 File Offset: 0x0015CF73
	public AttributeType BoostAttributeType
	{
		[CompilerGenerated]
		get
		{
			return this.<BoostAttributeType>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<BoostAttributeType>k__BackingField = value;
		}
	}

	// Token: 0x06003434 RID: 13364 RVA: 0x0015EB7C File Offset: 0x0015CF7C
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				AttributeType = this.BoostAttributeType,
				Value = this.BoostValue,
				AttributeModifierType = AttributeModifierType.Skill,
				ModificationType = ModificationType.Addition,
				Key = string.Empty
			}
		};
	}

	// Token: 0x06003435 RID: 13365 RVA: 0x0015EBCE File Offset: 0x0015CFCE
	public void UpdateBoostValue(double value)
	{
		this.BoostValue = value;
	}

	// Token: 0x06003436 RID: 13366 RVA: 0x0015EBD7 File Offset: 0x0015CFD7
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000843 RID: 2115
	// (get) Token: 0x06003437 RID: 13367 RVA: 0x0015EBDE File Offset: 0x0015CFDE
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000844 RID: 2116
	// (get) Token: 0x06003438 RID: 13368 RVA: 0x0015EBE6 File Offset: 0x0015CFE6
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000845 RID: 2117
	// (get) Token: 0x06003439 RID: 13369 RVA: 0x0015EBEE File Offset: 0x0015CFEE
	// (set) Token: 0x0600343A RID: 13370 RVA: 0x0015EBF6 File Offset: 0x0015CFF6
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

	// Token: 0x17000846 RID: 2118
	// (get) Token: 0x0600343B RID: 13371 RVA: 0x0015EBFF File Offset: 0x0015CFFF
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000847 RID: 2119
	// (get) Token: 0x0600343C RID: 13372 RVA: 0x0015EC07 File Offset: 0x0015D007
	// (set) Token: 0x0600343D RID: 13373 RVA: 0x0015EC0F File Offset: 0x0015D00F
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

	// Token: 0x17000848 RID: 2120
	// (get) Token: 0x0600343E RID: 13374 RVA: 0x0015EC18 File Offset: 0x0015D018
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000849 RID: 2121
	// (get) Token: 0x0600343F RID: 13375 RVA: 0x0015EC20 File Offset: 0x0015D020
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x1700084A RID: 2122
	// (get) Token: 0x06003440 RID: 13376 RVA: 0x0015EC28 File Offset: 0x0015D028
	// (set) Token: 0x06003441 RID: 13377 RVA: 0x0015EC30 File Offset: 0x0015D030
	public override bool CanBeDispersed
	{
		get
		{
			return this._canBeDispersed;
		}
		set
		{
			this._canBeDispersed = true;
		}
	}

	// Token: 0x1700084B RID: 2123
	// (get) Token: 0x06003442 RID: 13378 RVA: 0x0015EC39 File Offset: 0x0015D039
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(this._maxStackableInstances);
		}
	}

	// Token: 0x1700084C RID: 2124
	// (get) Token: 0x06003443 RID: 13379 RVA: 0x0015EC46 File Offset: 0x0015D046
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x0400288F RID: 10383
	private string _effectSourceIdentityCode;

	// Token: 0x04002890 RID: 10384
	private BattleEffectType _battleEffectType = BattleEffectType.Charged;

	// Token: 0x04002891 RID: 10385
	private int? _numberOfLastingTurns = new int?(1);

	// Token: 0x04002892 RID: 10386
	private bool _isThroughEffect;

	// Token: 0x04002893 RID: 10387
	private bool _canBeImmuned;

	// Token: 0x04002894 RID: 10388
	private bool _canBeDispersed = true;

	// Token: 0x04002895 RID: 10389
	private int _maxStackableInstances = 1;

	// Token: 0x04002896 RID: 10390
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002897 RID: 10391
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002898 RID: 10392
	private IBattleEffectSource _effectSource;

	// Token: 0x04002899 RID: 10393
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<OutputType> <DamageTypes>k__BackingField;

	// Token: 0x0400289A RID: 10394
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <BoostValue>k__BackingField;

	// Token: 0x0400289B RID: 10395
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AttributeType <BoostAttributeType>k__BackingField;
}
