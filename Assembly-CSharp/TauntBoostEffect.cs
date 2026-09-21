using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000774 RID: 1908
public sealed class TauntBoostEffect : BattleEffectBase
{
	// Token: 0x0600380E RID: 14350 RVA: 0x00170B94 File Offset: 0x0016EF94
	public TauntBoostEffect(double damageReflectionRate, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = "tauntboosteffectunique";
		this._maxStackableInstances = new int?(1);
		this.MaxNumberOfLastingSeconds = null;
		this.NumberOfLastingTurns = null;
		this._battleEffectType = BattleEffectType.TauntBoost;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this.CanBeDispersed = false;
		base.Description = BattleEffectType.TauntBoost.GetDescription();
		base.Description.Details1 = base.Description.Details1.Replace("{damagereflection}", damageReflectionRate.ToExpressionMultiply100());
		base.TurnEventsCollected = new List<AdventureEventType>();
		this.DamageReflectionRate = damageReflectionRate;
	}

	// Token: 0x0600380F RID: 14351 RVA: 0x00170C4C File Offset: 0x0016F04C
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06003810 RID: 14352 RVA: 0x00170C54 File Offset: 0x0016F054
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		List<IBattleUnit> source = wearer.CurrentEncounter.EnemyUnits;
		if (!wearer.IsPlayer)
		{
			source = wearer.CurrentEncounter.PlayerUnits;
		}
		int num = source.Count((IBattleUnit t) => t.BattleEffects.OfType<TauntEffect>().Any((TauntEffect tt) => tt.Caster == wearer));
		if (num > 0)
		{
			return new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.ReflectiveDamage,
					Value = (double)num * this.DamageReflectionRate,
					ModificationType = ModificationType.Addition,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			};
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x17000A8E RID: 2702
	// (get) Token: 0x06003811 RID: 14353 RVA: 0x00170D0E File Offset: 0x0016F10E
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A8F RID: 2703
	// (get) Token: 0x06003812 RID: 14354 RVA: 0x00170D16 File Offset: 0x0016F116
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A90 RID: 2704
	// (get) Token: 0x06003813 RID: 14355 RVA: 0x00170D1E File Offset: 0x0016F11E
	// (set) Token: 0x06003814 RID: 14356 RVA: 0x00170D26 File Offset: 0x0016F126
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

	// Token: 0x17000A91 RID: 2705
	// (get) Token: 0x06003815 RID: 14357 RVA: 0x00170D2F File Offset: 0x0016F12F
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A92 RID: 2706
	// (get) Token: 0x06003816 RID: 14358 RVA: 0x00170D37 File Offset: 0x0016F137
	// (set) Token: 0x06003817 RID: 14359 RVA: 0x00170D3F File Offset: 0x0016F13F
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

	// Token: 0x17000A93 RID: 2707
	// (get) Token: 0x06003818 RID: 14360 RVA: 0x00170D48 File Offset: 0x0016F148
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A94 RID: 2708
	// (get) Token: 0x06003819 RID: 14361 RVA: 0x00170D50 File Offset: 0x0016F150
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A95 RID: 2709
	// (get) Token: 0x0600381A RID: 14362 RVA: 0x00170D58 File Offset: 0x0016F158
	// (set) Token: 0x0600381B RID: 14363 RVA: 0x00170D60 File Offset: 0x0016F160
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

	// Token: 0x17000A96 RID: 2710
	// (get) Token: 0x0600381C RID: 14364 RVA: 0x00170D69 File Offset: 0x0016F169
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A97 RID: 2711
	// (get) Token: 0x0600381D RID: 14365 RVA: 0x00170D71 File Offset: 0x0016F171
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002B5D RID: 11101
	private string _effectSourceIdentityCode;

	// Token: 0x04002B5E RID: 11102
	private BattleEffectType _battleEffectType;

	// Token: 0x04002B5F RID: 11103
	private IBattleEffectSource _effectSource;

	// Token: 0x04002B60 RID: 11104
	private bool _isThroughEffect;

	// Token: 0x04002B61 RID: 11105
	private bool _canBeImmuned;

	// Token: 0x04002B62 RID: 11106
	private int? _maxStackableInstances;

	// Token: 0x04002B63 RID: 11107
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002B64 RID: 11108
	private double DamageReflectionRate;

	// Token: 0x04002B65 RID: 11109
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002B66 RID: 11110
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002B67 RID: 11111
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000ED5 RID: 3797
	[CompilerGenerated]
	private sealed class <GetAdditionalModifiers>c__AnonStorey0
	{
		// Token: 0x06005FB7 RID: 24503 RVA: 0x00170D79 File Offset: 0x0016F179
		public <GetAdditionalModifiers>c__AnonStorey0()
		{
		}

		// Token: 0x06005FB8 RID: 24504 RVA: 0x00170D81 File Offset: 0x0016F181
		internal bool <>m__0(IBattleUnit t)
		{
			return t.BattleEffects.OfType<TauntEffect>().Any((TauntEffect tt) => tt.Caster == this.wearer);
		}

		// Token: 0x06005FB9 RID: 24505 RVA: 0x00170D9F File Offset: 0x0016F19F
		internal bool <>m__1(TauntEffect tt)
		{
			return tt.Caster == this.wearer;
		}

		// Token: 0x04005488 RID: 21640
		internal IBattleUnit wearer;
	}
}
