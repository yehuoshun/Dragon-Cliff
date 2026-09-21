using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000758 RID: 1880
public class FrenzyEffect : BattleEffectBase
{
	// Token: 0x0600365D RID: 13917 RVA: 0x00168504 File Offset: 0x00166904
	public FrenzyEffect(string effectSourceIdentityCode, float? maxNumberOfLastingSeconds, int? numberOfLastingTurns, double damageRate, IBattleEffectSource effectSource)
	{
		Description description = this.BattleEffectType.GetDescription();
		description.Details1 = description.Details1.Replace("{rate}", damageRate.ToExpressionMultiply100());
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		this._maxNumberOfLastingSeconds = maxNumberOfLastingSeconds;
		this._numberOfLastingTurns = numberOfLastingTurns;
		this._damageRate = damageRate;
		base.Description = description;
		base.TurnEventsCollected = new List<AdventureEventType>();
		this._effectSource = effectSource;
	}

	// Token: 0x0600365E RID: 13918 RVA: 0x00168594 File Offset: 0x00166994
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.DamageReleased && data is ReleaseableDamage && eventTriggerUnit == listener)
		{
			ReleaseableDamage damage = data as ReleaseableDamage;
			if (listener == damage.Dealer)
			{
				FrenzyDispelEnhancementData dispelEnhancement = this.EffectSource.SourceUnit.SpecialEffects.OfType<FrenzyDispelEnhancementData>().FirstOrDefault<FrenzyDispelEnhancementData>();
				FrenzyPushEnhancementData pushEnhancement = this.EffectSource.SourceUnit.SpecialEffects.OfType<FrenzyPushEnhancementData>().FirstOrDefault<FrenzyPushEnhancementData>();
				FrenzyStunEnhancementData stunEnhancement = this.EffectSource.SourceUnit.SpecialEffects.OfType<FrenzyStunEnhancementData>().FirstOrDefault<FrenzyStunEnhancementData>();
				List<BattleDamage> extraDamages = new List<BattleDamage>();
				foreach (BattleDamage battleDamage in damage.BattleDamages)
				{
					double damageValue = (from d in battleDamage.Damages
					where d.IsDirectDamage
					select d).Sum((DamageComponent d) => d.GetTotalDamageSoFar());
					int totalDamageHits = (from d in battleDamage.Damages
					where d.IsDirectDamage && !d.IsMissed
					select d).Count<DamageComponent>();
					if (damageValue > 0.0)
					{
						if (dispelEnhancement != null)
						{
							IEnumerator enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(battleDamage.Target, new int?(dispelEnhancement.NumberOfDispels * totalDamageHits)).GetEnumerator();
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
						if (pushEnhancement != null)
						{
							UnitTurnProgressUpdateEvent push = new UnitTurnProgressUpdateEvent
							{
								Dealer = this.EffectSource.SourceUnit,
								ChangePercentage = -pushEnhancement.PushRate * (double)totalDamageHits,
								CausingSource = this.EffectSource
							};
							IEnumerator enumerator3 = battleDamage.Target.ChangeTurnCounterProgress(push).GetEnumerator();
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
						if (stunEnhancement != null)
						{
							IEnumerator enumerator4 = LockTimeEffect.AddStunSeconds(battleDamage.Target, (float)(stunEnhancement.Seconds * totalDamageHits), this.EffectSource, false).GetEnumerator();
							try
							{
								while (enumerator4.MoveNext())
								{
									object _3 = enumerator4.Current;
									yield return _3;
								}
							}
							finally
							{
								IDisposable disposable3;
								if ((disposable3 = (enumerator4 as IDisposable)) != null)
								{
									disposable3.Dispose();
								}
							}
						}
						extraDamages.Add(new BattleDamage(battleDamage.Target, this, new List<DamageComponentValue>
						{
							new DamageComponentValue(new List<DamagePotionValue>
							{
								DamagePotionValue.CreateRawValuedDamageComponent(battleDamage.Target, damage.Dealer, OutputType.RealDamage, damageValue * this._damageRate)
							}, battleDamage.Target, damage.Dealer, false, false)
						}));
					}
				}
				if (extraDamages.Any<BattleDamage>())
				{
					IEnumerator enumerator5 = this.Triggered(listener).GetEnumerator();
					try
					{
						while (enumerator5.MoveNext())
						{
							object _4 = enumerator5.Current;
							yield return _4;
						}
					}
					finally
					{
						IDisposable disposable4;
						if ((disposable4 = (enumerator5 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
					ReleaseableDamage releaseable = new ReleaseableDamage(extraDamages, damage.Dealer);
					IEnumerator enumerator6 = releaseable.Release().GetEnumerator();
					try
					{
						while (enumerator6.MoveNext())
						{
							object _5 = enumerator6.Current;
							yield return _5;
						}
					}
					finally
					{
						IDisposable disposable5;
						if ((disposable5 = (enumerator6 as IDisposable)) != null)
						{
							disposable5.Dispose();
						}
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x17000987 RID: 2439
	// (get) Token: 0x0600365F RID: 13919 RVA: 0x001685D4 File Offset: 0x001669D4
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x06003660 RID: 13920 RVA: 0x001685DC File Offset: 0x001669DC
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.DamageReleased
		};
	}

	// Token: 0x17000988 RID: 2440
	// (get) Token: 0x06003661 RID: 13921 RVA: 0x001685F8 File Offset: 0x001669F8
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000989 RID: 2441
	// (get) Token: 0x06003662 RID: 13922 RVA: 0x00168600 File Offset: 0x00166A00
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x1700098A RID: 2442
	// (get) Token: 0x06003663 RID: 13923 RVA: 0x00168608 File Offset: 0x00166A08
	// (set) Token: 0x06003664 RID: 13924 RVA: 0x00168610 File Offset: 0x00166A10
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

	// Token: 0x1700098B RID: 2443
	// (get) Token: 0x06003665 RID: 13925 RVA: 0x00168619 File Offset: 0x00166A19
	// (set) Token: 0x06003666 RID: 13926 RVA: 0x00168621 File Offset: 0x00166A21
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

	// Token: 0x1700098C RID: 2444
	// (get) Token: 0x06003667 RID: 13927 RVA: 0x0016862A File Offset: 0x00166A2A
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x1700098D RID: 2445
	// (get) Token: 0x06003668 RID: 13928 RVA: 0x00168632 File Offset: 0x00166A32
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x1700098E RID: 2446
	// (get) Token: 0x06003669 RID: 13929 RVA: 0x0016863A File Offset: 0x00166A3A
	// (set) Token: 0x0600366A RID: 13930 RVA: 0x00168642 File Offset: 0x00166A42
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

	// Token: 0x1700098F RID: 2447
	// (get) Token: 0x0600366B RID: 13931 RVA: 0x0016864B File Offset: 0x00166A4B
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000990 RID: 2448
	// (get) Token: 0x0600366C RID: 13932 RVA: 0x00168653 File Offset: 0x00166A53
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002A40 RID: 10816
	private string _effectSourceIdentityCode;

	// Token: 0x04002A41 RID: 10817
	private BattleEffectType _battleEffectType = BattleEffectType.Frenzy;

	// Token: 0x04002A42 RID: 10818
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002A43 RID: 10819
	private int? _numberOfLastingTurns;

	// Token: 0x04002A44 RID: 10820
	private bool _isThroughEffect;

	// Token: 0x04002A45 RID: 10821
	private bool _canBeImmuned;

	// Token: 0x04002A46 RID: 10822
	private bool _canBeDispersed = true;

	// Token: 0x04002A47 RID: 10823
	private int? _maxStackableInstances = new int?(1);

	// Token: 0x04002A48 RID: 10824
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002A49 RID: 10825
	private double _damageRate;

	// Token: 0x04002A4A RID: 10826
	private IBattleEffectSource _effectSource;

	// Token: 0x02000EB8 RID: 3768
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005EED RID: 24301 RVA: 0x0016865B File Offset: 0x00166A5B
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005EEE RID: 24302 RVA: 0x00168664 File Offset: 0x00166A64
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.DamageReleased || !(data is ReleaseableDamage) || eventTriggerUnit != listener)
				{
					goto IL_690;
				}
				damage = (data as ReleaseableDamage);
				if (listener != damage.Dealer)
				{
					goto IL_690;
				}
				dispelEnhancement = this.EffectSource.SourceUnit.SpecialEffects.OfType<FrenzyDispelEnhancementData>().FirstOrDefault<FrenzyDispelEnhancementData>();
				pushEnhancement = this.EffectSource.SourceUnit.SpecialEffects.OfType<FrenzyPushEnhancementData>().FirstOrDefault<FrenzyPushEnhancementData>();
				stunEnhancement = this.EffectSource.SourceUnit.SpecialEffects.OfType<FrenzyStunEnhancementData>().FirstOrDefault<FrenzyStunEnhancementData>();
				extraDamages = new List<BattleDamage>();
				enumerator = damage.BattleDamages.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
			case 3u:
				break;
			case 4u:
				goto IL_557;
			case 5u:
				goto IL_60E;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_16:
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
					goto IL_2A8;
				case 2u:
					Block_18:
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
					goto IL_3A7;
				case 3u:
					Block_20:
					try
					{
						switch (num)
						{
						}
						if (enumerator4.MoveNext())
						{
							_3 = enumerator4.Current;
							this.$current = _3;
							if (!this.$disposing)
							{
								this.$PC = 3;
							}
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if ((disposable3 = (enumerator4 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
					goto IL_471;
				}
				IL_4FD:
				while (enumerator.MoveNext())
				{
					battleDamage = enumerator.Current;
					damageValue = (from d in battleDamage.Damages
					where d.IsDirectDamage
					select d).Sum((DamageComponent d) => d.GetTotalDamageSoFar());
					totalDamageHits = (from d in battleDamage.Damages
					where d.IsDirectDamage && !d.IsMissed
					select d).Count<DamageComponent>();
					if (damageValue > 0.0)
					{
						if (dispelEnhancement != null)
						{
							enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(battleDamage.Target, new int?(dispelEnhancement.NumberOfDispels * totalDamageHits)).GetEnumerator();
							num = 4294967293u;
							goto Block_16;
						}
						goto IL_2A8;
					}
				}
				goto IL_528;
				IL_2A8:
				if (pushEnhancement != null)
				{
					push = new UnitTurnProgressUpdateEvent
					{
						Dealer = this.EffectSource.SourceUnit,
						ChangePercentage = -pushEnhancement.PushRate * (double)totalDamageHits,
						CausingSource = this.EffectSource
					};
					enumerator3 = battleDamage.Target.ChangeTurnCounterProgress(push).GetEnumerator();
					num = 4294967293u;
					goto Block_18;
				}
				IL_3A7:
				if (stunEnhancement != null)
				{
					enumerator4 = LockTimeEffect.AddStunSeconds(battleDamage.Target, (float)(stunEnhancement.Seconds * totalDamageHits), this.EffectSource, false).GetEnumerator();
					num = 4294967293u;
					goto Block_20;
				}
				IL_471:
				extraDamages.Add(new BattleDamage(battleDamage.Target, this, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(battleDamage.Target, damage.Dealer, OutputType.RealDamage, damageValue * this._damageRate)
					}, battleDamage.Target, damage.Dealer, false, false)
				}));
				goto IL_4FD;
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_528:
			if (!extraDamages.Any<BattleDamage>())
			{
				goto IL_690;
			}
			enumerator5 = this.Triggered(listener).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_557:
				switch (num)
				{
				}
				if (enumerator5.MoveNext())
				{
					_4 = enumerator5.Current;
					this.$current = _4;
					if (!this.$disposing)
					{
						this.$PC = 4;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			releaseable = new ReleaseableDamage(extraDamages, damage.Dealer);
			enumerator6 = releaseable.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_60E:
				switch (num)
				{
				}
				if (enumerator6.MoveNext())
				{
					_5 = enumerator6.Current;
					this.$current = _5;
					if (!this.$disposing)
					{
						this.$PC = 5;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable5 = (enumerator6 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
			}
			IL_690:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013D6 RID: 5078
		// (get) Token: 0x06005EEF RID: 24303 RVA: 0x00168DA0 File Offset: 0x001671A0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013D7 RID: 5079
		// (get) Token: 0x06005EF0 RID: 24304 RVA: 0x00168DA8 File Offset: 0x001671A8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005EF1 RID: 24305 RVA: 0x00168DB0 File Offset: 0x001671B0
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
			case 3u:
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
					case 3u:
						try
						{
						}
						finally
						{
							if ((disposable3 = (enumerator4 as IDisposable)) != null)
							{
								disposable3.Dispose();
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
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			case 5u:
				try
				{
				}
				finally
				{
					if ((disposable5 = (enumerator6 as IDisposable)) != null)
					{
						disposable5.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005EF2 RID: 24306 RVA: 0x00168F58 File Offset: 0x00167358
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005EF3 RID: 24307 RVA: 0x00168F5F File Offset: 0x0016735F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005EF4 RID: 24308 RVA: 0x00168F68 File Offset: 0x00167368
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FrenzyEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new FrenzyEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x06005EF5 RID: 24309 RVA: 0x00168FCC File Offset: 0x001673CC
		private static bool <>m__0(DamageComponent d)
		{
			return d.IsDirectDamage;
		}

		// Token: 0x06005EF6 RID: 24310 RVA: 0x00168FD4 File Offset: 0x001673D4
		private static double <>m__1(DamageComponent d)
		{
			return d.GetTotalDamageSoFar();
		}

		// Token: 0x06005EF7 RID: 24311 RVA: 0x00168FDC File Offset: 0x001673DC
		private static bool <>m__2(DamageComponent d)
		{
			return d.IsDirectDamage && !d.IsMissed;
		}

		// Token: 0x04005305 RID: 21253
		internal AdventureEventType eventType;

		// Token: 0x04005306 RID: 21254
		internal object data;

		// Token: 0x04005307 RID: 21255
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04005308 RID: 21256
		internal IBattleUnit listener;

		// Token: 0x04005309 RID: 21257
		internal ReleaseableDamage <damage>__1;

		// Token: 0x0400530A RID: 21258
		internal FrenzyDispelEnhancementData <dispelEnhancement>__2;

		// Token: 0x0400530B RID: 21259
		internal FrenzyPushEnhancementData <pushEnhancement>__2;

		// Token: 0x0400530C RID: 21260
		internal FrenzyStunEnhancementData <stunEnhancement>__2;

		// Token: 0x0400530D RID: 21261
		internal List<BattleDamage> <extraDamages>__2;

		// Token: 0x0400530E RID: 21262
		internal List<BattleDamage>.Enumerator $locvar0;

		// Token: 0x0400530F RID: 21263
		internal BattleDamage <battleDamage>__3;

		// Token: 0x04005310 RID: 21264
		internal double <damageValue>__4;

		// Token: 0x04005311 RID: 21265
		internal int <totalDamageHits>__4;

		// Token: 0x04005312 RID: 21266
		internal IEnumerator $locvar1;

		// Token: 0x04005313 RID: 21267
		internal object <_>__5;

		// Token: 0x04005314 RID: 21268
		internal IDisposable $locvar2;

		// Token: 0x04005315 RID: 21269
		internal UnitTurnProgressUpdateEvent <push>__6;

		// Token: 0x04005316 RID: 21270
		internal IEnumerator $locvar3;

		// Token: 0x04005317 RID: 21271
		internal object <_>__7;

		// Token: 0x04005318 RID: 21272
		internal IDisposable $locvar4;

		// Token: 0x04005319 RID: 21273
		internal IEnumerator $locvar5;

		// Token: 0x0400531A RID: 21274
		internal object <_>__8;

		// Token: 0x0400531B RID: 21275
		internal IDisposable $locvar6;

		// Token: 0x0400531C RID: 21276
		internal IEnumerator $locvar7;

		// Token: 0x0400531D RID: 21277
		internal object <_>__9;

		// Token: 0x0400531E RID: 21278
		internal IDisposable $locvar8;

		// Token: 0x0400531F RID: 21279
		internal ReleaseableDamage <releaseable>__10;

		// Token: 0x04005320 RID: 21280
		internal IEnumerator $locvar9;

		// Token: 0x04005321 RID: 21281
		internal object <_>__11;

		// Token: 0x04005322 RID: 21282
		internal IDisposable $locvarA;

		// Token: 0x04005323 RID: 21283
		internal FrenzyEffect $this;

		// Token: 0x04005324 RID: 21284
		internal object $current;

		// Token: 0x04005325 RID: 21285
		internal bool $disposing;

		// Token: 0x04005326 RID: 21286
		internal int $PC;

		// Token: 0x04005327 RID: 21287
		private static Func<DamageComponent, bool> <>f__am$cache0;

		// Token: 0x04005328 RID: 21288
		private static Func<DamageComponent, double> <>f__am$cache1;

		// Token: 0x04005329 RID: 21289
		private static Func<DamageComponent, bool> <>f__am$cache2;
	}
}
