using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200075B RID: 1883
public sealed class GuiltEffect : BattleEffectBase
{
	// Token: 0x0600368F RID: 13967 RVA: 0x00169698 File Offset: 0x00167A98
	public GuiltEffect(double hitRateBoost, double directDamageBoostRate, double effectReduction, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = "guiltunique";
		this._battleEffectType = BattleEffectType.GuiltEffect;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this.CanBeDispersed = false;
		this.MaxNumberOfLastingSeconds = null;
		this.NumberOfLastingTurns = null;
		base.Description = this._battleEffectType.GetDescription();
		base.Description.Details1 = base.Description.Details1.Replace("{hitrate}", hitRateBoost.ToExpressionMultiply100()).Replace("{directrate}", directDamageBoostRate.ToExpressionMultiply100()).Replace("{reductionrate}", this.EffectReductionRate.ToExpressionMultiply100());
		this.HitRateBoost = hitRateBoost;
		this.EffectReductionRate = effectReduction;
		this.DirectDamageBoostRate = directDamageBoostRate;
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x06003690 RID: 13968 RVA: 0x00169788 File Offset: 0x00167B88
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				Value = this.HitRateBoost,
				ModificationType = ModificationType.Addition,
				Key = string.Empty,
				AttributeType = AttributeType.HitRateAdjustment,
				AttributeModifierType = AttributeModifierType.Skill
			},
			new AttributeModifier
			{
				Value = -this.EffectReductionRate,
				AttributeType = AttributeType.EffectHitRating,
				ModificationType = ModificationType.Multiplication,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			}
		};
	}

	// Token: 0x06003691 RID: 13969 RVA: 0x00169817 File Offset: 0x00167C17
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x170009A6 RID: 2470
	// (get) Token: 0x06003692 RID: 13970 RVA: 0x0016981E File Offset: 0x00167C1E
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170009A7 RID: 2471
	// (get) Token: 0x06003693 RID: 13971 RVA: 0x00169826 File Offset: 0x00167C26
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170009A8 RID: 2472
	// (get) Token: 0x06003694 RID: 13972 RVA: 0x0016982E File Offset: 0x00167C2E
	// (set) Token: 0x06003695 RID: 13973 RVA: 0x00169836 File Offset: 0x00167C36
	public override float? MaxNumberOfLastingSeconds
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

	// Token: 0x170009A9 RID: 2473
	// (get) Token: 0x06003696 RID: 13974 RVA: 0x0016983F File Offset: 0x00167C3F
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170009AA RID: 2474
	// (get) Token: 0x06003697 RID: 13975 RVA: 0x00169847 File Offset: 0x00167C47
	// (set) Token: 0x06003698 RID: 13976 RVA: 0x0016984F File Offset: 0x00167C4F
	public override int? NumberOfLastingTurns
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

	// Token: 0x170009AB RID: 2475
	// (get) Token: 0x06003699 RID: 13977 RVA: 0x00169858 File Offset: 0x00167C58
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170009AC RID: 2476
	// (get) Token: 0x0600369A RID: 13978 RVA: 0x00169860 File Offset: 0x00167C60
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170009AD RID: 2477
	// (get) Token: 0x0600369B RID: 13979 RVA: 0x00169868 File Offset: 0x00167C68
	// (set) Token: 0x0600369C RID: 13980 RVA: 0x00169870 File Offset: 0x00167C70
	public override bool CanBeDispersed
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

	// Token: 0x170009AE RID: 2478
	// (get) Token: 0x0600369D RID: 13981 RVA: 0x00169879 File Offset: 0x00167C79
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170009AF RID: 2479
	// (get) Token: 0x0600369E RID: 13982 RVA: 0x00169881 File Offset: 0x00167C81
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002A5B RID: 10843
	private string _effectSourceIdentityCode;

	// Token: 0x04002A5C RID: 10844
	private BattleEffectType _battleEffectType;

	// Token: 0x04002A5D RID: 10845
	private IBattleEffectSource _effectSource;

	// Token: 0x04002A5E RID: 10846
	private bool _isThroughEffect;

	// Token: 0x04002A5F RID: 10847
	private bool _canBeImmuned;

	// Token: 0x04002A60 RID: 10848
	private int? _maxStackableInstances;

	// Token: 0x04002A61 RID: 10849
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002A62 RID: 10850
	public double HitRateBoost;

	// Token: 0x04002A63 RID: 10851
	public double DirectDamageBoostRate;

	// Token: 0x04002A64 RID: 10852
	public double EffectReductionRate;

	// Token: 0x04002A65 RID: 10853
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002A66 RID: 10854
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002A67 RID: 10855
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;
}
