using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000738 RID: 1848
public class CorruptedPowerEffect : BattleEffectBase
{
	// Token: 0x06003444 RID: 13380 RVA: 0x0015EC50 File Offset: 0x0015D050
	public CorruptedPowerEffect(AdventureUnitSkill causingSkill, double strengthReductionRate, string sourceIdentityCode)
	{
		this._numberOfLastingTurns = null;
		this._maxNumberOfLastingSeconds = new float?(4f);
		this._effectSourceIdentityCode = sourceIdentityCode;
		this._effectSource = causingSkill;
		base.TurnEventsCollected = new List<AdventureEventType>();
		this._modifiers = new List<AttributeModifier>
		{
			new AttributeModifier
			{
				Value = -strengthReductionRate,
				AttributeType = AttributeType.Strength,
				ModificationType = ModificationType.Multiplication,
				AttributeModifierType = AttributeModifierType.Skill
			}
		};
		Description description = BattleEffectType.CorruptedPowerEffect.GetDescription();
		description.Details1 = description.Details1.Replace("{strengthreductionrate}", strengthReductionRate.ToExpressionMultiply100());
		base.Description = description;
		this.CanBeDispersed = true;
	}

	// Token: 0x1700084D RID: 2125
	// (get) Token: 0x06003445 RID: 13381 RVA: 0x0015ED04 File Offset: 0x0015D104
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x1700084E RID: 2126
	// (get) Token: 0x06003446 RID: 13382 RVA: 0x0015ED0C File Offset: 0x0015D10C
	// (set) Token: 0x06003447 RID: 13383 RVA: 0x0015ED14 File Offset: 0x0015D114
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

	// Token: 0x06003448 RID: 13384 RVA: 0x0015ED1D File Offset: 0x0015D11D
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return this._modifiers;
	}

	// Token: 0x1700084F RID: 2127
	// (get) Token: 0x06003449 RID: 13385 RVA: 0x0015ED25 File Offset: 0x0015D125
	public override bool IsThroughEffect
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000850 RID: 2128
	// (get) Token: 0x0600344A RID: 13386 RVA: 0x0015ED28 File Offset: 0x0015D128
	public override bool CanBeImmuned
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000851 RID: 2129
	// (get) Token: 0x0600344B RID: 13387 RVA: 0x0015ED2B File Offset: 0x0015D12B
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(1);
		}
	}

	// Token: 0x17000852 RID: 2130
	// (get) Token: 0x0600344C RID: 13388 RVA: 0x0015ED33 File Offset: 0x0015D133
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Negative;
		}
	}

	// Token: 0x17000853 RID: 2131
	// (get) Token: 0x0600344D RID: 13389 RVA: 0x0015ED36 File Offset: 0x0015D136
	// (set) Token: 0x0600344E RID: 13390 RVA: 0x0015ED3E File Offset: 0x0015D13E
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

	// Token: 0x0600344F RID: 13391 RVA: 0x0015ED47 File Offset: 0x0015D147
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000854 RID: 2132
	// (get) Token: 0x06003450 RID: 13392 RVA: 0x0015ED4E File Offset: 0x0015D14E
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000855 RID: 2133
	// (get) Token: 0x06003451 RID: 13393 RVA: 0x0015ED56 File Offset: 0x0015D156
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return BattleEffectType.CorruptedPowerEffect;
		}
	}

	// Token: 0x17000856 RID: 2134
	// (get) Token: 0x06003452 RID: 13394 RVA: 0x0015ED5A File Offset: 0x0015D15A
	// (set) Token: 0x06003453 RID: 13395 RVA: 0x0015ED62 File Offset: 0x0015D162
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

	// Token: 0x0400289C RID: 10396
	private List<AttributeModifier> _modifiers;

	// Token: 0x0400289D RID: 10397
	private string _effectSourceIdentityCode;

	// Token: 0x0400289E RID: 10398
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x0400289F RID: 10399
	private IBattleEffectSource _effectSource;

	// Token: 0x040028A0 RID: 10400
	private int? _numberOfLastingTurns;

	// Token: 0x040028A1 RID: 10401
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
