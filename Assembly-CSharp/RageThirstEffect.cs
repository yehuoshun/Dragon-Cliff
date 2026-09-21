using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000768 RID: 1896
public sealed class RageThirstEffect : BattleEffectBase
{
	// Token: 0x0600374F RID: 14159 RVA: 0x0016E2BC File Offset: 0x0016C6BC
	public RageThirstEffect(double rageSuctionValue, int? lastingSeconds, int? lastingTurns, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = "uniqueragethirstef";
		this._battleEffectType = BattleEffectType.RageThirst;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this.MaxNumberOfLastingSeconds = ((lastingSeconds == null) ? null : new float?((float)lastingSeconds.Value));
		this.NumberOfLastingTurns = lastingTurns;
		this._rageSuctionValue = rageSuctionValue;
		base.TurnEventsCollected = new List<AdventureEventType>();
		this.CanBeDispersed = true;
		base.Description = this._battleEffectType.GetDescription();
	}

	// Token: 0x06003750 RID: 14160 RVA: 0x0016E36C File Offset: 0x0016C76C
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.DamageReleased && eventTriggerUnit == listener && data is ReleaseableDamage)
		{
			ReleaseableDamage damage = data as ReleaseableDamage;
			BattleEncounter battleEncounter = listener.CurrentEncounter as BattleEncounter;
			if (battleEncounter != null)
			{
				foreach (BattleDamage damageBattleDamage in damage.BattleDamages)
				{
					if (damageBattleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed))
					{
						if (damageBattleDamage.Target.IsPlayer)
						{
							IEnumerator enumerator2 = battleEncounter.UpdatePlayerGauge(-this._rageSuctionValue, listener).GetEnumerator();
							try
							{
								while (enumerator2.MoveNext())
								{
									object _ = enumerator2.Current;
									yield return _;
								}
							}
							finally
							{
								IDisposable disposable;
								if ((disposable = (enumerator2 as IDisposable)) != null)
								{
									disposable.Dispose();
								}
							}
						}
						else
						{
							IEnumerator enumerator3 = battleEncounter.UpdateEnemyGauge(-this._rageSuctionValue, listener).GetEnumerator();
							try
							{
								while (enumerator3.MoveNext())
								{
									object _2 = enumerator3.Current;
									yield return _2;
								}
							}
							finally
							{
								IDisposable disposable2;
								if ((disposable2 = (enumerator3 as IDisposable)) != null)
								{
									disposable2.Dispose();
								}
							}
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06003751 RID: 14161 RVA: 0x0016E3AC File Offset: 0x0016C7AC
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.DamageReleased
		};
	}

	// Token: 0x17000A16 RID: 2582
	// (get) Token: 0x06003752 RID: 14162 RVA: 0x0016E3C8 File Offset: 0x0016C7C8
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A17 RID: 2583
	// (get) Token: 0x06003753 RID: 14163 RVA: 0x0016E3D0 File Offset: 0x0016C7D0
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A18 RID: 2584
	// (get) Token: 0x06003754 RID: 14164 RVA: 0x0016E3D8 File Offset: 0x0016C7D8
	// (set) Token: 0x06003755 RID: 14165 RVA: 0x0016E3E0 File Offset: 0x0016C7E0
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

	// Token: 0x17000A19 RID: 2585
	// (get) Token: 0x06003756 RID: 14166 RVA: 0x0016E3E9 File Offset: 0x0016C7E9
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A1A RID: 2586
	// (get) Token: 0x06003757 RID: 14167 RVA: 0x0016E3F1 File Offset: 0x0016C7F1
	// (set) Token: 0x06003758 RID: 14168 RVA: 0x0016E3F9 File Offset: 0x0016C7F9
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

	// Token: 0x17000A1B RID: 2587
	// (get) Token: 0x06003759 RID: 14169 RVA: 0x0016E402 File Offset: 0x0016C802
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A1C RID: 2588
	// (get) Token: 0x0600375A RID: 14170 RVA: 0x0016E40A File Offset: 0x0016C80A
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A1D RID: 2589
	// (get) Token: 0x0600375B RID: 14171 RVA: 0x0016E412 File Offset: 0x0016C812
	// (set) Token: 0x0600375C RID: 14172 RVA: 0x0016E41A File Offset: 0x0016C81A
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

	// Token: 0x17000A1E RID: 2590
	// (get) Token: 0x0600375D RID: 14173 RVA: 0x0016E423 File Offset: 0x0016C823
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A1F RID: 2591
	// (get) Token: 0x0600375E RID: 14174 RVA: 0x0016E42B File Offset: 0x0016C82B
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002ADA RID: 10970
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002ADB RID: 10971
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002ADC RID: 10972
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002ADD RID: 10973
	private readonly bool _isThroughEffect;

	// Token: 0x04002ADE RID: 10974
	private readonly bool _canBeImmuned;

	// Token: 0x04002ADF RID: 10975
	private readonly int? _maxStackableInstances;

	// Token: 0x04002AE0 RID: 10976
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002AE1 RID: 10977
	private double _rageSuctionValue;

	// Token: 0x04002AE2 RID: 10978
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002AE3 RID: 10979
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002AE4 RID: 10980
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000ECF RID: 3791
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F84 RID: 24452 RVA: 0x0016E433 File Offset: 0x0016C833
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005F85 RID: 24453 RVA: 0x0016E43C File Offset: 0x0016C83C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.DamageReleased || eventTriggerUnit != listener || !(data is ReleaseableDamage))
				{
					goto IL_297;
				}
				damage = (data as ReleaseableDamage);
				battleEncounter = (listener.CurrentEncounter as BattleEncounter);
				if (battleEncounter == null)
				{
					goto IL_297;
				}
				enumerator = damage.BattleDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_11:
					try
					{
						switch (num)
						{
						}
						if (enumerator2.MoveNext())
						{
							_ = enumerator2.Current;
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
							if ((disposable = (enumerator2 as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					break;
				case 2u:
					Block_12:
					try
					{
						switch (num)
						{
						}
						if (enumerator3.MoveNext())
						{
							_2 = enumerator3.Current;
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
							if ((disposable2 = (enumerator3 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					break;
				}
				while (enumerator.MoveNext())
				{
					damageBattleDamage = enumerator.Current;
					if (damageBattleDamage.Damages.Any((DamageComponent d) => d.IsDirectDamage && !d.IsMissed))
					{
						if (damageBattleDamage.Target.IsPlayer)
						{
							enumerator2 = battleEncounter.UpdatePlayerGauge(-this._rageSuctionValue, listener).GetEnumerator();
							num = 4294967293u;
							goto Block_11;
						}
						enumerator3 = battleEncounter.UpdateEnemyGauge(-this._rageSuctionValue, listener).GetEnumerator();
						num = 4294967293u;
						goto Block_12;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_297:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013F8 RID: 5112
		// (get) Token: 0x06005F86 RID: 24454 RVA: 0x0016E738 File Offset: 0x0016CB38
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013F9 RID: 5113
		// (get) Token: 0x06005F87 RID: 24455 RVA: 0x0016E740 File Offset: 0x0016CB40
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F88 RID: 24456 RVA: 0x0016E748 File Offset: 0x0016CB48
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						try
						{
						}
						finally
						{
							if ((disposable = (enumerator2 as IDisposable)) != null)
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
							if ((disposable2 = (enumerator3 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005F89 RID: 24457 RVA: 0x0016E830 File Offset: 0x0016CC30
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F8A RID: 24458 RVA: 0x0016E837 File Offset: 0x0016CC37
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F8B RID: 24459 RVA: 0x0016E840 File Offset: 0x0016CC40
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			RageThirstEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new RageThirstEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x06005F8C RID: 24460 RVA: 0x0016E8A4 File Offset: 0x0016CCA4
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x0400541B RID: 21531
		internal AdventureEventType eventType;

		// Token: 0x0400541C RID: 21532
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400541D RID: 21533
		internal IBattleUnit listener;

		// Token: 0x0400541E RID: 21534
		internal object data;

		// Token: 0x0400541F RID: 21535
		internal ReleaseableDamage <damage>__1;

		// Token: 0x04005420 RID: 21536
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x04005421 RID: 21537
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x04005422 RID: 21538
		internal BattleDamage <damageBattleDamage>__2;

		// Token: 0x04005423 RID: 21539
		internal IEnumerator $locvar1;

		// Token: 0x04005424 RID: 21540
		internal object <_>__3;

		// Token: 0x04005425 RID: 21541
		internal IDisposable $locvar2;

		// Token: 0x04005426 RID: 21542
		internal IEnumerator $locvar3;

		// Token: 0x04005427 RID: 21543
		internal object <_>__4;

		// Token: 0x04005428 RID: 21544
		internal IDisposable $locvar4;

		// Token: 0x04005429 RID: 21545
		internal RageThirstEffect $this;

		// Token: 0x0400542A RID: 21546
		internal object $current;

		// Token: 0x0400542B RID: 21547
		internal bool $disposing;

		// Token: 0x0400542C RID: 21548
		internal int $PC;

		// Token: 0x0400542D RID: 21549
		private static Func<DamageComponent, bool> <>f__am$cache0;
	}
}
