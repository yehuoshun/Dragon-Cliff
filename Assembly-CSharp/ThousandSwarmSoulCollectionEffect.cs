using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000776 RID: 1910
public class ThousandSwarmSoulCollectionEffect : BattleEffectBase
{
	// Token: 0x06003834 RID: 14388 RVA: 0x00171258 File Offset: 0x0016F658
	public ThousandSwarmSoulCollectionEffect(float lastingSeconds, IBattleEffectSource effectSource, double suctionValue, OutputType damageType, IBattleUnit effectWearer)
	{
		this._effectSourceIdentityCode = base.GetType().FullName;
		this._battleEffectType = BattleEffectType.ThousandSwarmSoulCollection;
		this._maxNumberOfLastingSeconds = new float?(lastingSeconds);
		this._effectSource = effectSource;
		this._numberOfLastingTurns = null;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._canBeDispersed = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this._suctionValue = suctionValue;
		this._damageType = damageType;
		this._effectWearer = effectWearer;
		base.Description = BattleEffectType.ThousandSwarmSoulCollection.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x06003835 RID: 14389 RVA: 0x00171300 File Offset: 0x0016F700
	public override IEnumerable PerSecondLogic_ActiveUnit(IBattleUnit listener)
	{
		ReleaseableDamage damage = new ReleaseableDamage((from t in this._effectWearer.GetLiveEnemyTargets(false, true)
		select new BattleDamage(t, this, new List<DamageComponentValue>
		{
			new DamageComponentValue(new List<DamagePotionValue>
			{
				DamagePotionValue.CreateRawValuedDamageComponent(t, this._effectWearer, this._damageType, this._suctionValue)
			}, t, this._effectWearer, false, false)
		})).ToList<BattleDamage>(), this._effectWearer);
		ReleaseableHeal heal = new ReleaseableHeal(new List<BattleHeal>
		{
			new BattleHeal(this._effectWearer, this, new List<HealComponentValue>
			{
				new HealComponentValue
				{
					RawHeal = this._suctionValue,
					HealType = OutputType.RealHeal,
					IsDirectHeal = false
				}
			}, false)
		}, this._effectWearer);
		IEnumerator enumerator = damage.Release().GetEnumerator();
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
		IEnumerator enumerator2 = heal.Release().GetEnumerator();
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
		IEnumerator enumerator3 = this.Triggered(this._effectWearer).GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				object _3 = enumerator3.Current;
				yield return _3;
			}
		}
		finally
		{
			IDisposable disposable3;
			if ((disposable3 = (enumerator3 as IDisposable)) != null)
			{
				disposable3.Dispose();
			}
		}
		yield break;
	}

	// Token: 0x06003836 RID: 14390 RVA: 0x00171323 File Offset: 0x0016F723
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000AA4 RID: 2724
	// (get) Token: 0x06003837 RID: 14391 RVA: 0x0017132A File Offset: 0x0016F72A
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000AA5 RID: 2725
	// (get) Token: 0x06003838 RID: 14392 RVA: 0x00171332 File Offset: 0x0016F732
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000AA6 RID: 2726
	// (get) Token: 0x06003839 RID: 14393 RVA: 0x0017133A File Offset: 0x0016F73A
	// (set) Token: 0x0600383A RID: 14394 RVA: 0x00171342 File Offset: 0x0016F742
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

	// Token: 0x17000AA7 RID: 2727
	// (get) Token: 0x0600383B RID: 14395 RVA: 0x0017134B File Offset: 0x0016F74B
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000AA8 RID: 2728
	// (get) Token: 0x0600383C RID: 14396 RVA: 0x00171353 File Offset: 0x0016F753
	// (set) Token: 0x0600383D RID: 14397 RVA: 0x0017135B File Offset: 0x0016F75B
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

	// Token: 0x17000AA9 RID: 2729
	// (get) Token: 0x0600383E RID: 14398 RVA: 0x00171364 File Offset: 0x0016F764
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000AAA RID: 2730
	// (get) Token: 0x0600383F RID: 14399 RVA: 0x0017136C File Offset: 0x0016F76C
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000AAB RID: 2731
	// (get) Token: 0x06003840 RID: 14400 RVA: 0x00171374 File Offset: 0x0016F774
	// (set) Token: 0x06003841 RID: 14401 RVA: 0x0017137C File Offset: 0x0016F77C
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

	// Token: 0x17000AAC RID: 2732
	// (get) Token: 0x06003842 RID: 14402 RVA: 0x00171385 File Offset: 0x0016F785
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000AAD RID: 2733
	// (get) Token: 0x06003843 RID: 14403 RVA: 0x0017138D File Offset: 0x0016F78D
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002B71 RID: 11121
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002B72 RID: 11122
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002B73 RID: 11123
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002B74 RID: 11124
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002B75 RID: 11125
	private int? _numberOfLastingTurns;

	// Token: 0x04002B76 RID: 11126
	private readonly bool _isThroughEffect;

	// Token: 0x04002B77 RID: 11127
	private readonly bool _canBeImmuned;

	// Token: 0x04002B78 RID: 11128
	private bool _canBeDispersed;

	// Token: 0x04002B79 RID: 11129
	private readonly int? _maxStackableInstances;

	// Token: 0x04002B7A RID: 11130
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002B7B RID: 11131
	private double _suctionValue;

	// Token: 0x04002B7C RID: 11132
	private OutputType _damageType;

	// Token: 0x04002B7D RID: 11133
	private IBattleUnit _effectWearer;

	// Token: 0x02000ED7 RID: 3799
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005FC2 RID: 24514 RVA: 0x00171395 File Offset: 0x0016F795
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005FC3 RID: 24515 RVA: 0x001713A0 File Offset: 0x0016F7A0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damage = new ReleaseableDamage((from t in this._effectWearer.GetLiveEnemyTargets(false, true)
				select new BattleDamage(t, this, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(t, this._effectWearer, this._damageType, this._suctionValue)
					}, t, this._effectWearer, false, false)
				})).ToList<BattleDamage>(), this._effectWearer);
				heal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(this._effectWearer, this, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = this._suctionValue,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, false)
				}, this._effectWearer);
				enumerator = damage.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_192;
			case 3u:
				goto IL_23A;
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
			enumerator2 = heal.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_192:
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
			enumerator3 = this.Triggered(this._effectWearer).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_23A:
				switch (num)
				{
				}
				if (enumerator3.MoveNext())
				{
					_3 = enumerator3.Current;
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
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001406 RID: 5126
		// (get) Token: 0x06005FC4 RID: 24516 RVA: 0x001716A0 File Offset: 0x0016FAA0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001407 RID: 5127
		// (get) Token: 0x06005FC5 RID: 24517 RVA: 0x001716A8 File Offset: 0x0016FAA8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005FC6 RID: 24518 RVA: 0x001716B0 File Offset: 0x0016FAB0
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
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005FC7 RID: 24519 RVA: 0x001717A0 File Offset: 0x0016FBA0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005FC8 RID: 24520 RVA: 0x001717A7 File Offset: 0x0016FBA7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005FC9 RID: 24521 RVA: 0x001717B0 File Offset: 0x0016FBB0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ThousandSwarmSoulCollectionEffect.<PerSecondLogic_ActiveUnit>c__Iterator0 <PerSecondLogic_ActiveUnit>c__Iterator = new ThousandSwarmSoulCollectionEffect.<PerSecondLogic_ActiveUnit>c__Iterator0();
			<PerSecondLogic_ActiveUnit>c__Iterator.$this = this;
			return <PerSecondLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x06005FCA RID: 24522 RVA: 0x001717E4 File Offset: 0x0016FBE4
		internal BattleDamage <>m__0(IBattleUnit t)
		{
			return new BattleDamage(t, this, new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					DamagePotionValue.CreateRawValuedDamageComponent(t, this._effectWearer, this._damageType, this._suctionValue)
				}, t, this._effectWearer, false, false)
			});
		}

		// Token: 0x04005492 RID: 21650
		internal ReleaseableDamage <damage>__0;

		// Token: 0x04005493 RID: 21651
		internal ReleaseableHeal <heal>__0;

		// Token: 0x04005494 RID: 21652
		internal IEnumerator $locvar0;

		// Token: 0x04005495 RID: 21653
		internal object <_>__1;

		// Token: 0x04005496 RID: 21654
		internal IDisposable $locvar1;

		// Token: 0x04005497 RID: 21655
		internal IEnumerator $locvar2;

		// Token: 0x04005498 RID: 21656
		internal object <_>__2;

		// Token: 0x04005499 RID: 21657
		internal IDisposable $locvar3;

		// Token: 0x0400549A RID: 21658
		internal IEnumerator $locvar4;

		// Token: 0x0400549B RID: 21659
		internal object <_>__3;

		// Token: 0x0400549C RID: 21660
		internal IDisposable $locvar5;

		// Token: 0x0400549D RID: 21661
		internal ThousandSwarmSoulCollectionEffect $this;

		// Token: 0x0400549E RID: 21662
		internal object $current;

		// Token: 0x0400549F RID: 21663
		internal bool $disposing;

		// Token: 0x040054A0 RID: 21664
		internal int $PC;
	}
}
