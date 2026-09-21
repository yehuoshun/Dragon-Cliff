using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200075C RID: 1884
public class HealOverTimeEffect : BattleEffectBase
{
	// Token: 0x0600369F RID: 13983 RVA: 0x00169889 File Offset: 0x00167C89
	public HealOverTimeEffect()
	{
	}

	// Token: 0x060036A0 RID: 13984 RVA: 0x00169894 File Offset: 0x00167C94
	private double GetHealValue()
	{
		double? heal = this._heal;
		return (heal == null) ? (this._healRate.GetValueOrDefault() * this._effectWearer.GetMaxLife(AttributeRetrievalLevel.Skill)) : heal.Value;
	}

	// Token: 0x060036A1 RID: 13985 RVA: 0x001698D8 File Offset: 0x00167CD8
	public static HealOverTimeEffect CreateSecondHealEffect(double? healValue, double? healRate, OutputType healType, IBattleUnit effectWearer, IBattleEffectSource effectSource, string identityCode, int? lastingSeconds, bool isThroughEffect, bool canBeImmuned, bool canbeDispersed, int? maxStackableInstances)
	{
		return new HealOverTimeEffect
		{
			_effectSourceIdentityCode = identityCode,
			_battleEffectType = BattleEffectType.HealPerSecond,
			_maxNumberOfLastingSeconds = ((lastingSeconds == null) ? null : new float?((float)lastingSeconds.Value)),
			_effectSource = effectSource,
			_numberOfLastingTurns = null,
			_isThroughEffect = isThroughEffect,
			_canBeImmuned = canBeImmuned,
			_canBeDispersed = canbeDispersed,
			_maxStackableInstances = maxStackableInstances,
			_battleEffectNatureForWearer = BattleEffectNature.Positive,
			_style = EffectOverTimeStyle.PerSecond,
			_heal = healValue,
			_healType = healType,
			_effectWearer = effectWearer,
			_healRate = healRate,
			Description = BattleEffectType.HealPerSecond.GetDescription(),
			TurnEventsCollected = new List<AdventureEventType>()
		};
	}

	// Token: 0x060036A2 RID: 13986 RVA: 0x001699A4 File Offset: 0x00167DA4
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitEntersTurn && eventType == AdventureEventType.UnitEntersTurn && eventTriggerUnit == listener && eventTriggerUnit == this._effectWearer && this._effectWearer.Status == BattleUnitStatus.Active && this._style == EffectOverTimeStyle.PerTurn)
		{
			ReleaseableHeal heal = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(eventTriggerUnit, this, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = this.GetHealValue(),
						HealType = this._healType,
						IsDirectHeal = false
					}
				}, false)
			}, this.EffectSource.SourceUnit);
			IEnumerator enumerator = heal.Release().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object _ = enumerator.Current;
					yield return _;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			IEnumerator enumerator2 = this.Triggered(this._effectWearer).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object _2 = enumerator2.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x060036A3 RID: 13987 RVA: 0x001699DC File Offset: 0x00167DDC
	public override IEnumerable PerSecondLogic_ActiveUnit(IBattleUnit listener)
	{
		if (this._style == EffectOverTimeStyle.PerSecond && listener == this._effectWearer && listener.Status == BattleUnitStatus.Active)
		{
			ReleaseableHeal heal = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(listener, this, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = this.GetHealValue(),
						HealType = this._healType,
						IsDirectHeal = false
					}
				}, false)
			}, this.EffectSource.SourceUnit);
			IEnumerator enumerator = heal.Release().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object _ = enumerator.Current;
					yield return _;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			IEnumerator enumerator2 = this.Triggered(this._effectWearer).GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object _2 = enumerator2.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator2 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x060036A4 RID: 13988 RVA: 0x00169A08 File Offset: 0x00167E08
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitEntersTurn
		};
	}

	// Token: 0x170009B0 RID: 2480
	// (get) Token: 0x060036A5 RID: 13989 RVA: 0x00169A23 File Offset: 0x00167E23
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170009B1 RID: 2481
	// (get) Token: 0x060036A6 RID: 13990 RVA: 0x00169A2B File Offset: 0x00167E2B
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170009B2 RID: 2482
	// (get) Token: 0x060036A7 RID: 13991 RVA: 0x00169A33 File Offset: 0x00167E33
	// (set) Token: 0x060036A8 RID: 13992 RVA: 0x00169A3B File Offset: 0x00167E3B
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

	// Token: 0x170009B3 RID: 2483
	// (get) Token: 0x060036A9 RID: 13993 RVA: 0x00169A44 File Offset: 0x00167E44
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170009B4 RID: 2484
	// (get) Token: 0x060036AA RID: 13994 RVA: 0x00169A4C File Offset: 0x00167E4C
	// (set) Token: 0x060036AB RID: 13995 RVA: 0x00169A54 File Offset: 0x00167E54
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

	// Token: 0x170009B5 RID: 2485
	// (get) Token: 0x060036AC RID: 13996 RVA: 0x00169A5D File Offset: 0x00167E5D
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170009B6 RID: 2486
	// (get) Token: 0x060036AD RID: 13997 RVA: 0x00169A65 File Offset: 0x00167E65
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170009B7 RID: 2487
	// (get) Token: 0x060036AE RID: 13998 RVA: 0x00169A6D File Offset: 0x00167E6D
	// (set) Token: 0x060036AF RID: 13999 RVA: 0x00169A75 File Offset: 0x00167E75
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

	// Token: 0x170009B8 RID: 2488
	// (get) Token: 0x060036B0 RID: 14000 RVA: 0x00169A7E File Offset: 0x00167E7E
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170009B9 RID: 2489
	// (get) Token: 0x060036B1 RID: 14001 RVA: 0x00169A86 File Offset: 0x00167E86
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002A68 RID: 10856
	private string _effectSourceIdentityCode;

	// Token: 0x04002A69 RID: 10857
	private BattleEffectType _battleEffectType;

	// Token: 0x04002A6A RID: 10858
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002A6B RID: 10859
	private IBattleEffectSource _effectSource;

	// Token: 0x04002A6C RID: 10860
	private int? _numberOfLastingTurns;

	// Token: 0x04002A6D RID: 10861
	private bool _isThroughEffect;

	// Token: 0x04002A6E RID: 10862
	private bool _canBeImmuned;

	// Token: 0x04002A6F RID: 10863
	private bool _canBeDispersed;

	// Token: 0x04002A70 RID: 10864
	private int? _maxStackableInstances;

	// Token: 0x04002A71 RID: 10865
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002A72 RID: 10866
	private EffectOverTimeStyle _style;

	// Token: 0x04002A73 RID: 10867
	private double? _heal;

	// Token: 0x04002A74 RID: 10868
	private double? _healRate;

	// Token: 0x04002A75 RID: 10869
	private OutputType _healType;

	// Token: 0x04002A76 RID: 10870
	private IBattleUnit _effectWearer;

	// Token: 0x02000EBA RID: 3770
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F00 RID: 24320 RVA: 0x00169A8E File Offset: 0x00167E8E
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005F01 RID: 24321 RVA: 0x00169A98 File Offset: 0x00167E98
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitEntersTurn || eventType != AdventureEventType.UnitEntersTurn || eventTriggerUnit != listener || eventTriggerUnit != this._effectWearer || this._effectWearer.Status != BattleUnitStatus.Active || this._style != EffectOverTimeStyle.PerTurn)
				{
					goto IL_24D;
				}
				heal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(eventTriggerUnit, this, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = base.GetHealValue(),
							HealType = this._healType,
							IsDirectHeal = false
						}
					}, false)
				}, this.EffectSource.SourceUnit);
				enumerator = heal.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1C9;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			enumerator2 = this.Triggered(this._effectWearer).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1C9:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
					this.$current = _2;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_24D:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013DA RID: 5082
		// (get) Token: 0x06005F02 RID: 24322 RVA: 0x00169D18 File Offset: 0x00168118
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013DB RID: 5083
		// (get) Token: 0x06005F03 RID: 24323 RVA: 0x00169D20 File Offset: 0x00168120
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F04 RID: 24324 RVA: 0x00169D28 File Offset: 0x00168128
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005F05 RID: 24325 RVA: 0x00169DD8 File Offset: 0x001681D8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F06 RID: 24326 RVA: 0x00169DDF File Offset: 0x001681DF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F07 RID: 24327 RVA: 0x00169DE8 File Offset: 0x001681E8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HealOverTimeEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new HealOverTimeEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x0400533C RID: 21308
		internal AdventureEventType eventType;

		// Token: 0x0400533D RID: 21309
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400533E RID: 21310
		internal IBattleUnit listener;

		// Token: 0x0400533F RID: 21311
		internal ReleaseableHeal <heal>__1;

		// Token: 0x04005340 RID: 21312
		internal IEnumerator $locvar0;

		// Token: 0x04005341 RID: 21313
		internal object <_>__2;

		// Token: 0x04005342 RID: 21314
		internal IDisposable $locvar1;

		// Token: 0x04005343 RID: 21315
		internal IEnumerator $locvar2;

		// Token: 0x04005344 RID: 21316
		internal object <_>__3;

		// Token: 0x04005345 RID: 21317
		internal IDisposable $locvar3;

		// Token: 0x04005346 RID: 21318
		internal HealOverTimeEffect $this;

		// Token: 0x04005347 RID: 21319
		internal object $current;

		// Token: 0x04005348 RID: 21320
		internal bool $disposing;

		// Token: 0x04005349 RID: 21321
		internal int $PC;
	}

	// Token: 0x02000EBB RID: 3771
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F08 RID: 24328 RVA: 0x00169E40 File Offset: 0x00168240
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator1()
		{
		}

		// Token: 0x06005F09 RID: 24329 RVA: 0x00169E48 File Offset: 0x00168248
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (this._style != EffectOverTimeStyle.PerSecond || listener != this._effectWearer || listener.Status != BattleUnitStatus.Active)
				{
					goto IL_220;
				}
				heal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(listener, this, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = base.GetHealValue(),
							HealType = this._healType,
							IsDirectHeal = false
						}
					}, false)
				}, this.EffectSource.SourceUnit);
				enumerator = heal.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_19C;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			enumerator2 = this.Triggered(this._effectWearer).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_19C:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
					this.$current = _2;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_220:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013DC RID: 5084
		// (get) Token: 0x06005F0A RID: 24330 RVA: 0x0016A09C File Offset: 0x0016849C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013DD RID: 5085
		// (get) Token: 0x06005F0B RID: 24331 RVA: 0x0016A0A4 File Offset: 0x001684A4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F0C RID: 24332 RVA: 0x0016A0AC File Offset: 0x001684AC
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005F0D RID: 24333 RVA: 0x0016A15C File Offset: 0x0016855C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F0E RID: 24334 RVA: 0x0016A163 File Offset: 0x00168563
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F0F RID: 24335 RVA: 0x0016A16C File Offset: 0x0016856C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HealOverTimeEffect.<PerSecondLogic_ActiveUnit>c__Iterator1 <PerSecondLogic_ActiveUnit>c__Iterator = new HealOverTimeEffect.<PerSecondLogic_ActiveUnit>c__Iterator1();
			<PerSecondLogic_ActiveUnit>c__Iterator.$this = this;
			<PerSecondLogic_ActiveUnit>c__Iterator.listener = listener;
			return <PerSecondLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x0400534A RID: 21322
		internal IBattleUnit listener;

		// Token: 0x0400534B RID: 21323
		internal ReleaseableHeal <heal>__1;

		// Token: 0x0400534C RID: 21324
		internal IEnumerator $locvar0;

		// Token: 0x0400534D RID: 21325
		internal object <_>__2;

		// Token: 0x0400534E RID: 21326
		internal IDisposable $locvar1;

		// Token: 0x0400534F RID: 21327
		internal IEnumerator $locvar2;

		// Token: 0x04005350 RID: 21328
		internal object <_>__3;

		// Token: 0x04005351 RID: 21329
		internal IDisposable $locvar3;

		// Token: 0x04005352 RID: 21330
		internal HealOverTimeEffect $this;

		// Token: 0x04005353 RID: 21331
		internal object $current;

		// Token: 0x04005354 RID: 21332
		internal bool $disposing;

		// Token: 0x04005355 RID: 21333
		internal int $PC;
	}
}
