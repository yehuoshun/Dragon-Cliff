using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000736 RID: 1846
public class BurningHeartEffect : BattleEffectBase
{
	// Token: 0x0600341D RID: 13341 RVA: 0x0015E964 File Offset: 0x0015CD64
	public BurningHeartEffect(AdventureUnitSkill causingSkill, double intelligenceReductionRate, string sourceIdentityCode)
	{
		this._effectSource = causingSkill;
		base.TurnEventsCollected = new List<AdventureEventType>();
		this._numberOfLastingTurns = null;
		this._maxNumberOfLastingSeconds = new float?(4f);
		this._modifiers = new List<AttributeModifier>
		{
			new AttributeModifier
			{
				AttributeType = AttributeType.Intelligience,
				Value = -intelligenceReductionRate,
				ModificationType = ModificationType.Multiplication,
				AttributeModifierType = AttributeModifierType.Skill
			}
		};
		if (causingSkill.GetActiveTalents().OfType<BurningHeartStrengthBurnEnhancementTalent>().Any<BurningHeartStrengthBurnEnhancementTalent>())
		{
			this._modifiers.Add(new AttributeModifier
			{
				AttributeType = AttributeType.Strength,
				Value = -intelligenceReductionRate,
				ModificationType = ModificationType.Multiplication,
				AttributeModifierType = AttributeModifierType.Skill
			});
		}
		Description description = BattleEffectType.BurningHeartEffect.GetDescription();
		description.Details1 = description.Details1.Replace("{intelligencereductionrate}", (intelligenceReductionRate * 100.0).ToExpression());
		base.Description = description;
		this._effectSourceIdentityCode = sourceIdentityCode;
		this.CanBeDispersed = true;
	}

	// Token: 0x17000836 RID: 2102
	// (get) Token: 0x0600341E RID: 13342 RVA: 0x0015EA66 File Offset: 0x0015CE66
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000837 RID: 2103
	// (get) Token: 0x0600341F RID: 13343 RVA: 0x0015EA6E File Offset: 0x0015CE6E
	// (set) Token: 0x06003420 RID: 13344 RVA: 0x0015EA76 File Offset: 0x0015CE76
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

	// Token: 0x06003421 RID: 13345 RVA: 0x0015EA7F File Offset: 0x0015CE7F
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return this._modifiers;
	}

	// Token: 0x17000838 RID: 2104
	// (get) Token: 0x06003422 RID: 13346 RVA: 0x0015EA87 File Offset: 0x0015CE87
	public override bool IsThroughEffect
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000839 RID: 2105
	// (get) Token: 0x06003423 RID: 13347 RVA: 0x0015EA8A File Offset: 0x0015CE8A
	public override bool CanBeImmuned
	{
		get
		{
			return true;
		}
	}

	// Token: 0x1700083A RID: 2106
	// (get) Token: 0x06003424 RID: 13348 RVA: 0x0015EA8D File Offset: 0x0015CE8D
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(1);
		}
	}

	// Token: 0x1700083B RID: 2107
	// (get) Token: 0x06003425 RID: 13349 RVA: 0x0015EA95 File Offset: 0x0015CE95
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Negative;
		}
	}

	// Token: 0x1700083C RID: 2108
	// (get) Token: 0x06003426 RID: 13350 RVA: 0x0015EA98 File Offset: 0x0015CE98
	// (set) Token: 0x06003427 RID: 13351 RVA: 0x0015EAA0 File Offset: 0x0015CEA0
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

	// Token: 0x06003428 RID: 13352 RVA: 0x0015EAA9 File Offset: 0x0015CEA9
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x1700083D RID: 2109
	// (get) Token: 0x06003429 RID: 13353 RVA: 0x0015EAB0 File Offset: 0x0015CEB0
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x1700083E RID: 2110
	// (get) Token: 0x0600342A RID: 13354 RVA: 0x0015EAB8 File Offset: 0x0015CEB8
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return BattleEffectType.BurningHeartEffect;
		}
	}

	// Token: 0x1700083F RID: 2111
	// (get) Token: 0x0600342B RID: 13355 RVA: 0x0015EABC File Offset: 0x0015CEBC
	// (set) Token: 0x0600342C RID: 13356 RVA: 0x0015EAC4 File Offset: 0x0015CEC4
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

	// Token: 0x04002889 RID: 10377
	private List<AttributeModifier> _modifiers;

	// Token: 0x0400288A RID: 10378
	private string _effectSourceIdentityCode;

	// Token: 0x0400288B RID: 10379
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x0400288C RID: 10380
	private IBattleEffectSource _effectSource;

	// Token: 0x0400288D RID: 10381
	private int? _numberOfLastingTurns;

	// Token: 0x0400288E RID: 10382
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
