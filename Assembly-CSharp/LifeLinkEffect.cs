using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000761 RID: 1889
public class LifeLinkEffect : BattleEffectBase
{
	// Token: 0x060036D3 RID: 14035 RVA: 0x0016A87C File Offset: 0x00168C7C
	public LifeLinkEffect(IBattleEffectSource effectSource, double linkRate)
	{
		this._effectSourceIdentityCode = BattleEffectType.LifeLink.ToString();
		this._battleEffectType = BattleEffectType.LifeLink;
		this._maxNumberOfLastingSeconds = null;
		this._effectSource = effectSource;
		this._numberOfLastingTurns = null;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._canBeDispersed = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Neutral;
		this._linkRate = linkRate;
		base.Description = BattleEffectType.LifeLink.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x060036D4 RID: 14036 RVA: 0x0016A91C File Offset: 0x00168D1C
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPostReceivesDamage && eventTriggerUnit == listener && data is BattleDamage)
		{
			BattleDamage damage = data as BattleDamage;
			double damageValue = damage.Damages.Sum((DamageComponent d) => d.GetTotalDamageSoFar());
			if (damageValue > 0.0)
			{
				ReleaseableDamage releaseableDamage = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(this.EffectSource.SourceUnit, damage.Dealer, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(this.EffectSource.SourceUnit, damage.Dealer, OutputType.RealDamage, damageValue * this._linkRate)
						}, this.EffectSource.SourceUnit, damage.Dealer, false, false)
					})
				}, damage.Dealer);
				IEnumerator enumerator = releaseableDamage.Release().GetEnumerator();
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
				IEnumerator enumerator2 = this.Triggered(listener).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x060036D5 RID: 14037 RVA: 0x0016A95C File Offset: 0x00168D5C
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage
		};
	}

	// Token: 0x170009CF RID: 2511
	// (get) Token: 0x060036D6 RID: 14038 RVA: 0x0016A978 File Offset: 0x00168D78
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170009D0 RID: 2512
	// (get) Token: 0x060036D7 RID: 14039 RVA: 0x0016A980 File Offset: 0x00168D80
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170009D1 RID: 2513
	// (get) Token: 0x060036D8 RID: 14040 RVA: 0x0016A988 File Offset: 0x00168D88
	// (set) Token: 0x060036D9 RID: 14041 RVA: 0x0016A990 File Offset: 0x00168D90
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

	// Token: 0x170009D2 RID: 2514
	// (get) Token: 0x060036DA RID: 14042 RVA: 0x0016A999 File Offset: 0x00168D99
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170009D3 RID: 2515
	// (get) Token: 0x060036DB RID: 14043 RVA: 0x0016A9A1 File Offset: 0x00168DA1
	// (set) Token: 0x060036DC RID: 14044 RVA: 0x0016A9A9 File Offset: 0x00168DA9
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

	// Token: 0x170009D4 RID: 2516
	// (get) Token: 0x060036DD RID: 14045 RVA: 0x0016A9B2 File Offset: 0x00168DB2
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170009D5 RID: 2517
	// (get) Token: 0x060036DE RID: 14046 RVA: 0x0016A9BA File Offset: 0x00168DBA
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170009D6 RID: 2518
	// (get) Token: 0x060036DF RID: 14047 RVA: 0x0016A9C2 File Offset: 0x00168DC2
	// (set) Token: 0x060036E0 RID: 14048 RVA: 0x0016A9CA File Offset: 0x00168DCA
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

	// Token: 0x170009D7 RID: 2519
	// (get) Token: 0x060036E1 RID: 14049 RVA: 0x0016A9D3 File Offset: 0x00168DD3
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170009D8 RID: 2520
	// (get) Token: 0x060036E2 RID: 14050 RVA: 0x0016A9DB File Offset: 0x00168DDB
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002A8D RID: 10893
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002A8E RID: 10894
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002A8F RID: 10895
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002A90 RID: 10896
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002A91 RID: 10897
	private int? _numberOfLastingTurns;

	// Token: 0x04002A92 RID: 10898
	private readonly bool _isThroughEffect;

	// Token: 0x04002A93 RID: 10899
	private readonly bool _canBeImmuned;

	// Token: 0x04002A94 RID: 10900
	private bool _canBeDispersed;

	// Token: 0x04002A95 RID: 10901
	private readonly int? _maxStackableInstances;

	// Token: 0x04002A96 RID: 10902
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002A97 RID: 10903
	private double _linkRate;

	// Token: 0x02000EBD RID: 3773
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F18 RID: 24344 RVA: 0x0016A9E3 File Offset: 0x00168DE3
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005F19 RID: 24345 RVA: 0x0016A9EC File Offset: 0x00168DEC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPostReceivesDamage || eventTriggerUnit != listener || !(data is BattleDamage))
				{
					goto IL_2A2;
				}
				damage = (data as BattleDamage);
				damageValue = damage.Damages.Sum((DamageComponent d) => d.GetTotalDamageSoFar());
				if (damageValue <= 0.0)
				{
					goto IL_2A2;
				}
				releaseableDamage = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(this.EffectSource.SourceUnit, damage.Dealer, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(this.EffectSource.SourceUnit, damage.Dealer, OutputType.RealDamage, damageValue * this._linkRate)
						}, this.EffectSource.SourceUnit, damage.Dealer, false, false)
					})
				}, damage.Dealer);
				enumerator = releaseableDamage.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_21E;
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
			enumerator2 = this.Triggered(listener).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_21E:
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
			IL_2A2:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013E0 RID: 5088
		// (get) Token: 0x06005F1A RID: 24346 RVA: 0x0016ACC4 File Offset: 0x001690C4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013E1 RID: 5089
		// (get) Token: 0x06005F1B RID: 24347 RVA: 0x0016ACCC File Offset: 0x001690CC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F1C RID: 24348 RVA: 0x0016ACD4 File Offset: 0x001690D4
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

		// Token: 0x06005F1D RID: 24349 RVA: 0x0016AD84 File Offset: 0x00169184
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F1E RID: 24350 RVA: 0x0016AD8B File Offset: 0x0016918B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F1F RID: 24351 RVA: 0x0016AD94 File Offset: 0x00169194
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LifeLinkEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new LifeLinkEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x06005F20 RID: 24352 RVA: 0x0016ADF8 File Offset: 0x001691F8
		private static double <>m__0(DamageComponent d)
		{
			return d.GetTotalDamageSoFar();
		}

		// Token: 0x04005368 RID: 21352
		internal AdventureEventType eventType;

		// Token: 0x04005369 RID: 21353
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400536A RID: 21354
		internal IBattleUnit listener;

		// Token: 0x0400536B RID: 21355
		internal object data;

		// Token: 0x0400536C RID: 21356
		internal BattleDamage <damage>__1;

		// Token: 0x0400536D RID: 21357
		internal double <damageValue>__1;

		// Token: 0x0400536E RID: 21358
		internal ReleaseableDamage <releaseableDamage>__2;

		// Token: 0x0400536F RID: 21359
		internal IEnumerator $locvar0;

		// Token: 0x04005370 RID: 21360
		internal object <_>__3;

		// Token: 0x04005371 RID: 21361
		internal IDisposable $locvar1;

		// Token: 0x04005372 RID: 21362
		internal IEnumerator $locvar2;

		// Token: 0x04005373 RID: 21363
		internal object <_>__4;

		// Token: 0x04005374 RID: 21364
		internal IDisposable $locvar3;

		// Token: 0x04005375 RID: 21365
		internal LifeLinkEffect $this;

		// Token: 0x04005376 RID: 21366
		internal object $current;

		// Token: 0x04005377 RID: 21367
		internal bool $disposing;

		// Token: 0x04005378 RID: 21368
		internal int $PC;

		// Token: 0x04005379 RID: 21369
		private static Func<DamageComponent, double> <>f__am$cache0;
	}
}
