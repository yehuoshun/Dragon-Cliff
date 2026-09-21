using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000735 RID: 1845
public class BattlePressureEffect : BattleEffectBase
{
	// Token: 0x0600340B RID: 13323 RVA: 0x0015E64C File Offset: 0x0015CA4C
	public BattlePressureEffect(int numberOfSecondsPerRate, double decreasedRate, double decreasePerRate, IBattleEffectSource source, string sourceIdentiyCode)
	{
		this._numberOfSecondsPerRate = numberOfSecondsPerRate;
		this._decreasedRate = decreasedRate;
		this._decreasePerRate = decreasePerRate;
		this._secondsPassedCurrentRound = 0;
		base.TurnEventsCollected = new List<AdventureEventType>();
		this._effectSource = source;
		base.Description = BattleEffectType.BattlePressure.GetDescription();
		base.Description.Details1 = base.Description.Details1.Replace("{rate}", decreasedRate.ToExpressionMultiply100());
		this._effectSourceIdentityCode = sourceIdentiyCode;
	}

	// Token: 0x0600340C RID: 13324 RVA: 0x0015E6E0 File Offset: 0x0015CAE0
	public override IEnumerable PerSecondLogic_ActiveUnit(IBattleUnit listener)
	{
		this._secondsPassedCurrentRound++;
		if (this._secondsPassedCurrentRound == this._numberOfSecondsPerRate)
		{
			if (this._decreasedRate + this._decreasePerRate < 1.0)
			{
				this._decreasedRate += this._decreasePerRate;
				if (this._decreasedRate > 1.0)
				{
					this._decreasedRate = 1.0;
				}
				base.Description = BattleEffectType.BattlePressure.GetDescription();
				base.Description.Details1 = base.Description.Details1.Replace("{rate}", this._decreasedRate.ToExpressionMultiply100());
			}
			else
			{
				this._decreasedRate = 1.0;
			}
			this._secondsPassedCurrentRound = 0;
		}
		yield break;
	}

	// Token: 0x1700082B RID: 2091
	// (get) Token: 0x0600340D RID: 13325 RVA: 0x0015E703 File Offset: 0x0015CB03
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x0600340E RID: 13326 RVA: 0x0015E70C File Offset: 0x0015CB0C
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>
		{
			new AttributeModifier
			{
				Value = -this._decreasedRate,
				AttributeType = AttributeType.ReceivedHealEffectivenessChangeRate,
				AttributeModifierType = AttributeModifierType.Skill,
				Key = string.Empty,
				ModificationType = ModificationType.Addition
			}
		};
	}

	// Token: 0x0600340F RID: 13327 RVA: 0x0015E75E File Offset: 0x0015CB5E
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x1700082C RID: 2092
	// (get) Token: 0x06003410 RID: 13328 RVA: 0x0015E765 File Offset: 0x0015CB65
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x1700082D RID: 2093
	// (get) Token: 0x06003411 RID: 13329 RVA: 0x0015E76D File Offset: 0x0015CB6D
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x1700082E RID: 2094
	// (get) Token: 0x06003412 RID: 13330 RVA: 0x0015E775 File Offset: 0x0015CB75
	// (set) Token: 0x06003413 RID: 13331 RVA: 0x0015E77D File Offset: 0x0015CB7D
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

	// Token: 0x1700082F RID: 2095
	// (get) Token: 0x06003414 RID: 13332 RVA: 0x0015E786 File Offset: 0x0015CB86
	// (set) Token: 0x06003415 RID: 13333 RVA: 0x0015E78E File Offset: 0x0015CB8E
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

	// Token: 0x17000830 RID: 2096
	// (get) Token: 0x06003416 RID: 13334 RVA: 0x0015E797 File Offset: 0x0015CB97
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000831 RID: 2097
	// (get) Token: 0x06003417 RID: 13335 RVA: 0x0015E79F File Offset: 0x0015CB9F
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000832 RID: 2098
	// (get) Token: 0x06003418 RID: 13336 RVA: 0x0015E7A7 File Offset: 0x0015CBA7
	// (set) Token: 0x06003419 RID: 13337 RVA: 0x0015E7AF File Offset: 0x0015CBAF
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

	// Token: 0x17000833 RID: 2099
	// (get) Token: 0x0600341A RID: 13338 RVA: 0x0015E7B8 File Offset: 0x0015CBB8
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(this._maxStackableInstances);
		}
	}

	// Token: 0x17000834 RID: 2100
	// (get) Token: 0x0600341B RID: 13339 RVA: 0x0015E7C5 File Offset: 0x0015CBC5
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x17000835 RID: 2101
	// (get) Token: 0x0600341C RID: 13340 RVA: 0x0015E7CD File Offset: 0x0015CBCD
	public override List<string> EffectBattlePopupDetails
	{
		get
		{
			return new List<string>();
		}
	}

	// Token: 0x0400287B RID: 10363
	private BattleEffectType _battleEffectType = BattleEffectType.BattlePressure;

	// Token: 0x0400287C RID: 10364
	private int? _numberOfLastingTurns;

	// Token: 0x0400287D RID: 10365
	private bool _isThroughEffect;

	// Token: 0x0400287E RID: 10366
	private bool _canBeImmuned;

	// Token: 0x0400287F RID: 10367
	private bool _canBeDispersed;

	// Token: 0x04002880 RID: 10368
	private int _maxStackableInstances = 1;

	// Token: 0x04002881 RID: 10369
	private BattleEffectNature _battleEffectNatureForWearer = BattleEffectNature.Negative;

	// Token: 0x04002882 RID: 10370
	private int _numberOfSecondsPerRate;

	// Token: 0x04002883 RID: 10371
	private double _decreasedRate;

	// Token: 0x04002884 RID: 10372
	private double _decreasePerRate;

	// Token: 0x04002885 RID: 10373
	private int _secondsPassedCurrentRound;

	// Token: 0x04002886 RID: 10374
	private string _effectSourceIdentityCode;

	// Token: 0x04002887 RID: 10375
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002888 RID: 10376
	private IBattleEffectSource _effectSource;

	// Token: 0x02000E8F RID: 3727
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005DD0 RID: 24016 RVA: 0x0015E7D4 File Offset: 0x0015CBD4
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005DD1 RID: 24017 RVA: 0x0015E7DC File Offset: 0x0015CBDC
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				this._secondsPassedCurrentRound++;
				if (this._secondsPassedCurrentRound == this._numberOfSecondsPerRate)
				{
					if (this._decreasedRate + this._decreasePerRate < 1.0)
					{
						this._decreasedRate += this._decreasePerRate;
						if (this._decreasedRate > 1.0)
						{
							this._decreasedRate = 1.0;
						}
						base.Description = BattleEffectType.BattlePressure.GetDescription();
						base.Description.Details1 = base.Description.Details1.Replace("{rate}", this._decreasedRate.ToExpressionMultiply100());
					}
					else
					{
						this._decreasedRate = 1.0;
					}
					this._secondsPassedCurrentRound = 0;
				}
			}
			return false;
		}

		// Token: 0x17001396 RID: 5014
		// (get) Token: 0x06005DD2 RID: 24018 RVA: 0x0015E90F File Offset: 0x0015CD0F
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001397 RID: 5015
		// (get) Token: 0x06005DD3 RID: 24019 RVA: 0x0015E917 File Offset: 0x0015CD17
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005DD4 RID: 24020 RVA: 0x0015E91F File Offset: 0x0015CD1F
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005DD5 RID: 24021 RVA: 0x0015E921 File Offset: 0x0015CD21
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005DD6 RID: 24022 RVA: 0x0015E928 File Offset: 0x0015CD28
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005DD7 RID: 24023 RVA: 0x0015E930 File Offset: 0x0015CD30
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattlePressureEffect.<PerSecondLogic_ActiveUnit>c__Iterator0 <PerSecondLogic_ActiveUnit>c__Iterator = new BattlePressureEffect.<PerSecondLogic_ActiveUnit>c__Iterator0();
			<PerSecondLogic_ActiveUnit>c__Iterator.$this = this;
			return <PerSecondLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x04005162 RID: 20834
		internal BattlePressureEffect $this;

		// Token: 0x04005163 RID: 20835
		internal object $current;

		// Token: 0x04005164 RID: 20836
		internal bool $disposing;

		// Token: 0x04005165 RID: 20837
		internal int $PC;
	}
}
