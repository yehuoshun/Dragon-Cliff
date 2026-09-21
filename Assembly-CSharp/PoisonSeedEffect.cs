using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000765 RID: 1893
public class PoisonSeedEffect : BattleEffectBase
{
	// Token: 0x0600371A RID: 14106 RVA: 0x0016D0B4 File Offset: 0x0016B4B4
	public PoisonSeedEffect(double healDecreaseValue, double resistanceDecreaseValue, int stableSeconds, IBattleEffectSource effectSource, string sourceidentityCode)
	{
		this._numberOfLastingTurns = null;
		this._effectSourceIdentityCode = sourceidentityCode;
		this._healDecreaseValue = healDecreaseValue;
		this._effectSource = effectSource;
		this._resistanceDecreaseValue = resistanceDecreaseValue;
		this._stableSeconds = stableSeconds;
		this.MaxNumberOfLastingSeconds = null;
		this._currentResistanceDecreaseValue = resistanceDecreaseValue;
		this._currenthealDecreaseValue = healDecreaseValue;
		this._isThroughEffect = true;
		base.TurnEventsCollected = new List<AdventureEventType>();
		Description description = BattleEffectType.PoisonSeed.GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{healdecreaserate}", this._healDecreaseValue.ToExpressionMultiply100()).Replace("{resistancedecreasevalue}", this._resistanceDecreaseValue.ToExpression()).Replace("{seconds}", stableSeconds.ToString()).ToString();
		this.CanBeDispersed = true;
		base.Description = description;
	}

	// Token: 0x0600371B RID: 14107 RVA: 0x0016D194 File Offset: 0x0016B594
	public override IEnumerable PerSecondLogic_ActiveUnit(IBattleUnit listener)
	{
		if (this.Timer >= (float)this._stableSeconds)
		{
			this.CanBeDispersed = false;
			yield break;
		}
		this._currentResistanceDecreaseValue += this._resistanceDecreaseValue;
		this._currenthealDecreaseValue += this._healDecreaseValue;
		yield break;
	}

	// Token: 0x170009F8 RID: 2552
	// (get) Token: 0x0600371C RID: 14108 RVA: 0x0016D1B7 File Offset: 0x0016B5B7
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170009F9 RID: 2553
	// (get) Token: 0x0600371D RID: 14109 RVA: 0x0016D1BF File Offset: 0x0016B5BF
	// (set) Token: 0x0600371E RID: 14110 RVA: 0x0016D1C7 File Offset: 0x0016B5C7
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

	// Token: 0x0600371F RID: 14111 RVA: 0x0016D1D0 File Offset: 0x0016B5D0
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		List<AttributeModifier> list = (from r in UnitExtensions.GetAllResistances()
		select new AttributeModifier
		{
			AttributeType = r,
			ModificationType = ModificationType.Addition,
			Value = -this._currentResistanceDecreaseValue,
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Skill
		}).ToList<AttributeModifier>();
		list.Add(new AttributeModifier
		{
			AttributeType = AttributeType.ReceivedHealEffectivenessChangeRate,
			ModificationType = ModificationType.Addition,
			Value = -this._currenthealDecreaseValue,
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Skill
		});
		return list;
	}

	// Token: 0x170009FA RID: 2554
	// (get) Token: 0x06003720 RID: 14112 RVA: 0x0016D238 File Offset: 0x0016B638
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170009FB RID: 2555
	// (get) Token: 0x06003721 RID: 14113 RVA: 0x0016D240 File Offset: 0x0016B640
	public override bool CanBeImmuned
	{
		get
		{
			return true;
		}
	}

	// Token: 0x170009FC RID: 2556
	// (get) Token: 0x06003722 RID: 14114 RVA: 0x0016D243 File Offset: 0x0016B643
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(5);
		}
	}

	// Token: 0x170009FD RID: 2557
	// (get) Token: 0x06003723 RID: 14115 RVA: 0x0016D24B File Offset: 0x0016B64B
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Negative;
		}
	}

	// Token: 0x170009FE RID: 2558
	// (get) Token: 0x06003724 RID: 14116 RVA: 0x0016D24E File Offset: 0x0016B64E
	// (set) Token: 0x06003725 RID: 14117 RVA: 0x0016D256 File Offset: 0x0016B656
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

	// Token: 0x06003726 RID: 14118 RVA: 0x0016D25F File Offset: 0x0016B65F
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x170009FF RID: 2559
	// (get) Token: 0x06003727 RID: 14119 RVA: 0x0016D266 File Offset: 0x0016B666
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A00 RID: 2560
	// (get) Token: 0x06003728 RID: 14120 RVA: 0x0016D26E File Offset: 0x0016B66E
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return BattleEffectType.PoisonSeed;
		}
	}

	// Token: 0x17000A01 RID: 2561
	// (get) Token: 0x06003729 RID: 14121 RVA: 0x0016D272 File Offset: 0x0016B672
	// (set) Token: 0x0600372A RID: 14122 RVA: 0x0016D27A File Offset: 0x0016B67A
	public sealed override float? MaxNumberOfLastingSeconds
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

	// Token: 0x0600372B RID: 14123 RVA: 0x0016D284 File Offset: 0x0016B684
	[CompilerGenerated]
	private AttributeModifier <GetAdditionalModifiers>m__0(AttributeType r)
	{
		return new AttributeModifier
		{
			AttributeType = r,
			ModificationType = ModificationType.Addition,
			Value = -this._currentResistanceDecreaseValue,
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Skill
		};
	}

	// Token: 0x04002ABA RID: 10938
	private string _effectSourceIdentityCode;

	// Token: 0x04002ABB RID: 10939
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002ABC RID: 10940
	private IBattleEffectSource _effectSource;

	// Token: 0x04002ABD RID: 10941
	private double _healDecreaseValue;

	// Token: 0x04002ABE RID: 10942
	private double _resistanceDecreaseValue;

	// Token: 0x04002ABF RID: 10943
	private int _stableSeconds;

	// Token: 0x04002AC0 RID: 10944
	private double _currenthealDecreaseValue;

	// Token: 0x04002AC1 RID: 10945
	private double _currentResistanceDecreaseValue;

	// Token: 0x04002AC2 RID: 10946
	private int? _numberOfLastingTurns;

	// Token: 0x04002AC3 RID: 10947
	private bool _isThroughEffect;

	// Token: 0x04002AC4 RID: 10948
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000ECA RID: 3786
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F5C RID: 24412 RVA: 0x0016D2C5 File Offset: 0x0016B6C5
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005F5D RID: 24413 RVA: 0x0016D2D0 File Offset: 0x0016B6D0
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (this.Timer >= (float)this._stableSeconds)
				{
					this.CanBeDispersed = false;
				}
				else
				{
					this._currentResistanceDecreaseValue += this._resistanceDecreaseValue;
					this._currenthealDecreaseValue += this._healDecreaseValue;
				}
			}
			return false;
		}

		// Token: 0x170013EE RID: 5102
		// (get) Token: 0x06005F5E RID: 24414 RVA: 0x0016D35C File Offset: 0x0016B75C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013EF RID: 5103
		// (get) Token: 0x06005F5F RID: 24415 RVA: 0x0016D364 File Offset: 0x0016B764
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F60 RID: 24416 RVA: 0x0016D36C File Offset: 0x0016B76C
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005F61 RID: 24417 RVA: 0x0016D36E File Offset: 0x0016B76E
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F62 RID: 24418 RVA: 0x0016D375 File Offset: 0x0016B775
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F63 RID: 24419 RVA: 0x0016D380 File Offset: 0x0016B780
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PoisonSeedEffect.<PerSecondLogic_ActiveUnit>c__Iterator0 <PerSecondLogic_ActiveUnit>c__Iterator = new PoisonSeedEffect.<PerSecondLogic_ActiveUnit>c__Iterator0();
			<PerSecondLogic_ActiveUnit>c__Iterator.$this = this;
			return <PerSecondLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040053E8 RID: 21480
		internal PoisonSeedEffect $this;

		// Token: 0x040053E9 RID: 21481
		internal object $current;

		// Token: 0x040053EA RID: 21482
		internal bool $disposing;

		// Token: 0x040053EB RID: 21483
		internal int $PC;
	}
}
