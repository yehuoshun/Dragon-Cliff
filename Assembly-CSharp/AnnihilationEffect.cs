using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000732 RID: 1842
public sealed class AnnihilationEffect : BattleEffectBase
{
	// Token: 0x060033B2 RID: 13234 RVA: 0x0015B3DC File Offset: 0x001597DC
	public AnnihilationEffect(double effectresistanceReduction, double outputReduction, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = "annihilationeffectunique";
		this._maxStackableInstances = new int?(1);
		this.MaxNumberOfLastingSeconds = null;
		this.NumberOfLastingTurns = null;
		this._battleEffectType = BattleEffectType.AnnihilationEffect;
		this.CanBeDispersed = false;
		this._effectSource = effectSource;
		this._battleEffectNatureForWearer = BattleEffectNature.Negative;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this.EffectResistanceReduction = effectresistanceReduction;
		this.OutputReduction = outputReduction;
		base.Description = BattleEffectType.AnnihilationEffect.GetDescription();
		base.Description.Details1 = base.Description.Details1.Replace("{resistancereduction}", this.EffectResistanceReduction.ToExpressionMultiply100()).Replace("{output}", outputReduction.ToExpressionMultiply100());
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x060033B3 RID: 13235 RVA: 0x0015B4B0 File Offset: 0x001598B0
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		int num = wearer.BattleEffects.Count((BattleEffectBase ef) => ef.BattleEffectNatureForWearer == BattleEffectNature.Negative && !(ef is BattlePressureEffect));
		if (num > 0)
		{
			double num2 = this.EffectResistanceReduction * (double)num;
			if (num2 > 1.0)
			{
				num2 = 1.0;
			}
			double num3 = this.OutputReduction * (double)num;
			if (num3 > 0.5)
			{
				num3 = 0.5;
			}
			return new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeModifierType = AttributeModifierType.Skill,
					AttributeType = AttributeType.EffectResistanceRating,
					Key = string.Empty,
					ModificationType = ModificationType.Multiplication,
					Value = -num2
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.Allresistances,
					Value = -num3,
					ModificationType = ModificationType.Multiplication,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					AttributeType = AttributeType.Resilience,
					Value = -num3,
					ModificationType = ModificationType.Multiplication,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				},
				new AttributeModifier
				{
					AttributeType = wearer.GetOutputAttributeType(),
					Value = -num3,
					ModificationType = ModificationType.Multiplication,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			};
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x060033B4 RID: 13236 RVA: 0x0015B63E File Offset: 0x00159A3E
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x1700080D RID: 2061
	// (get) Token: 0x060033B5 RID: 13237 RVA: 0x0015B645 File Offset: 0x00159A45
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x1700080E RID: 2062
	// (get) Token: 0x060033B6 RID: 13238 RVA: 0x0015B64D File Offset: 0x00159A4D
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x1700080F RID: 2063
	// (get) Token: 0x060033B7 RID: 13239 RVA: 0x0015B655 File Offset: 0x00159A55
	// (set) Token: 0x060033B8 RID: 13240 RVA: 0x0015B65D File Offset: 0x00159A5D
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

	// Token: 0x17000810 RID: 2064
	// (get) Token: 0x060033B9 RID: 13241 RVA: 0x0015B666 File Offset: 0x00159A66
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000811 RID: 2065
	// (get) Token: 0x060033BA RID: 13242 RVA: 0x0015B66E File Offset: 0x00159A6E
	// (set) Token: 0x060033BB RID: 13243 RVA: 0x0015B676 File Offset: 0x00159A76
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

	// Token: 0x17000812 RID: 2066
	// (get) Token: 0x060033BC RID: 13244 RVA: 0x0015B67F File Offset: 0x00159A7F
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000813 RID: 2067
	// (get) Token: 0x060033BD RID: 13245 RVA: 0x0015B687 File Offset: 0x00159A87
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000814 RID: 2068
	// (get) Token: 0x060033BE RID: 13246 RVA: 0x0015B68F File Offset: 0x00159A8F
	// (set) Token: 0x060033BF RID: 13247 RVA: 0x0015B697 File Offset: 0x00159A97
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

	// Token: 0x17000815 RID: 2069
	// (get) Token: 0x060033C0 RID: 13248 RVA: 0x0015B6A0 File Offset: 0x00159AA0
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000816 RID: 2070
	// (get) Token: 0x060033C1 RID: 13249 RVA: 0x0015B6A8 File Offset: 0x00159AA8
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x060033C2 RID: 13250 RVA: 0x0015B6B0 File Offset: 0x00159AB0
	[CompilerGenerated]
	private static bool <GetAdditionalModifiers>m__0(BattleEffectBase ef)
	{
		return ef.BattleEffectNatureForWearer == BattleEffectNature.Negative && !(ef is BattlePressureEffect);
	}

	// Token: 0x0400284F RID: 10319
	private string _effectSourceIdentityCode;

	// Token: 0x04002850 RID: 10320
	private BattleEffectType _battleEffectType;

	// Token: 0x04002851 RID: 10321
	private IBattleEffectSource _effectSource;

	// Token: 0x04002852 RID: 10322
	private bool _isThroughEffect;

	// Token: 0x04002853 RID: 10323
	private bool _canBeImmuned;

	// Token: 0x04002854 RID: 10324
	private int? _maxStackableInstances;

	// Token: 0x04002855 RID: 10325
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002856 RID: 10326
	private double EffectResistanceReduction;

	// Token: 0x04002857 RID: 10327
	private double OutputReduction;

	// Token: 0x04002858 RID: 10328
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002859 RID: 10329
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x0400285A RID: 10330
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x0400285B RID: 10331
	[CompilerGenerated]
	private static Func<BattleEffectBase, bool> <>f__am$cache0;
}
