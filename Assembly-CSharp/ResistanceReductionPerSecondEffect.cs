using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200076A RID: 1898
public sealed class ResistanceReductionPerSecondEffect : BattleEffectBase
{
	// Token: 0x0600376F RID: 14191 RVA: 0x0016F2A4 File Offset: 0x0016D6A4
	public ResistanceReductionPerSecondEffect(double reductionvalue, double reductionPerSecond, IBattleEffectSource effectSource, int? lastingTurns, int? lastingSeconds)
	{
		this._effectSourceIdentityCode = "uniqueresistancereduction";
		this._battleEffectType = BattleEffectType.ResistanceReductionPerSecond;
		this._effectSource = effectSource;
		this._isThroughEffect = true;
		this._canBeImmuned = true;
		this._maxStackableInstances = new int?(4);
		this._battleEffectNatureForWearer = BattleEffectNature.Negative;
		this._reductionRate = reductionPerSecond;
		this._reductionValue = reductionvalue;
		this.MaxNumberOfLastingSeconds = ((lastingSeconds == null) ? null : new float?((float)lastingSeconds.Value));
		this.NumberOfLastingTurns = lastingTurns;
		base.TurnEventsCollected = new List<AdventureEventType>();
		this.CanBeDispersed = true;
		base.Description = BattleEffectType.ResistanceReductionPerSecond.GetDescription();
	}

	// Token: 0x06003770 RID: 14192 RVA: 0x0016F354 File Offset: 0x0016D754
	public override IEnumerable PerSecondLogic_ActiveUnit(IBattleUnit listener)
	{
		this._reductionValue += this._reductionRate;
		yield break;
	}

	// Token: 0x06003771 RID: 14193 RVA: 0x0016F377 File Offset: 0x0016D777
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return (from r in UnitExtensions.GetAllResistances()
		select new AttributeModifier
		{
			AttributeType = r,
			ModificationType = ModificationType.Addition,
			Value = -this._reductionValue,
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Skill
		}).ToList<AttributeModifier>();
	}

	// Token: 0x06003772 RID: 14194 RVA: 0x0016F394 File Offset: 0x0016D794
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000A2A RID: 2602
	// (get) Token: 0x06003773 RID: 14195 RVA: 0x0016F39B File Offset: 0x0016D79B
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A2B RID: 2603
	// (get) Token: 0x06003774 RID: 14196 RVA: 0x0016F3A3 File Offset: 0x0016D7A3
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A2C RID: 2604
	// (get) Token: 0x06003775 RID: 14197 RVA: 0x0016F3AB File Offset: 0x0016D7AB
	// (set) Token: 0x06003776 RID: 14198 RVA: 0x0016F3B3 File Offset: 0x0016D7B3
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

	// Token: 0x17000A2D RID: 2605
	// (get) Token: 0x06003777 RID: 14199 RVA: 0x0016F3BC File Offset: 0x0016D7BC
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A2E RID: 2606
	// (get) Token: 0x06003778 RID: 14200 RVA: 0x0016F3C4 File Offset: 0x0016D7C4
	// (set) Token: 0x06003779 RID: 14201 RVA: 0x0016F3CC File Offset: 0x0016D7CC
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

	// Token: 0x17000A2F RID: 2607
	// (get) Token: 0x0600377A RID: 14202 RVA: 0x0016F3D5 File Offset: 0x0016D7D5
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A30 RID: 2608
	// (get) Token: 0x0600377B RID: 14203 RVA: 0x0016F3DD File Offset: 0x0016D7DD
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A31 RID: 2609
	// (get) Token: 0x0600377C RID: 14204 RVA: 0x0016F3E5 File Offset: 0x0016D7E5
	// (set) Token: 0x0600377D RID: 14205 RVA: 0x0016F3ED File Offset: 0x0016D7ED
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

	// Token: 0x17000A32 RID: 2610
	// (get) Token: 0x0600377E RID: 14206 RVA: 0x0016F3F6 File Offset: 0x0016D7F6
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A33 RID: 2611
	// (get) Token: 0x0600377F RID: 14207 RVA: 0x0016F3FE File Offset: 0x0016D7FE
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x06003780 RID: 14208 RVA: 0x0016F408 File Offset: 0x0016D808
	[CompilerGenerated]
	private AttributeModifier <GetAdditionalModifiers>m__0(AttributeType r)
	{
		return new AttributeModifier
		{
			AttributeType = r,
			ModificationType = ModificationType.Addition,
			Value = -this._reductionValue,
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Skill
		};
	}

	// Token: 0x04002AEF RID: 10991
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002AF0 RID: 10992
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002AF1 RID: 10993
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002AF2 RID: 10994
	private readonly bool _isThroughEffect;

	// Token: 0x04002AF3 RID: 10995
	private readonly bool _canBeImmuned;

	// Token: 0x04002AF4 RID: 10996
	private readonly int? _maxStackableInstances;

	// Token: 0x04002AF5 RID: 10997
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002AF6 RID: 10998
	private double _reductionValue;

	// Token: 0x04002AF7 RID: 10999
	private double _reductionRate;

	// Token: 0x04002AF8 RID: 11000
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002AF9 RID: 11001
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002AFA RID: 11002
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000ED1 RID: 3793
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F97 RID: 24471 RVA: 0x0016F449 File Offset: 0x0016D849
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005F98 RID: 24472 RVA: 0x0016F451 File Offset: 0x0016D851
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				this._reductionValue += this._reductionRate;
			}
			return false;
		}

		// Token: 0x170013FC RID: 5116
		// (get) Token: 0x06005F99 RID: 24473 RVA: 0x0016F488 File Offset: 0x0016D888
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013FD RID: 5117
		// (get) Token: 0x06005F9A RID: 24474 RVA: 0x0016F490 File Offset: 0x0016D890
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F9B RID: 24475 RVA: 0x0016F498 File Offset: 0x0016D898
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005F9C RID: 24476 RVA: 0x0016F49A File Offset: 0x0016D89A
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F9D RID: 24477 RVA: 0x0016F4A1 File Offset: 0x0016D8A1
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F9E RID: 24478 RVA: 0x0016F4AC File Offset: 0x0016D8AC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ResistanceReductionPerSecondEffect.<PerSecondLogic_ActiveUnit>c__Iterator0 <PerSecondLogic_ActiveUnit>c__Iterator = new ResistanceReductionPerSecondEffect.<PerSecondLogic_ActiveUnit>c__Iterator0();
			<PerSecondLogic_ActiveUnit>c__Iterator.$this = this;
			return <PerSecondLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x0400544F RID: 21583
		internal ResistanceReductionPerSecondEffect $this;

		// Token: 0x04005450 RID: 21584
		internal object $current;

		// Token: 0x04005451 RID: 21585
		internal bool $disposing;

		// Token: 0x04005452 RID: 21586
		internal int $PC;
	}
}
