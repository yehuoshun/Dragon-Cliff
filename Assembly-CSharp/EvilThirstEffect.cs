using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000750 RID: 1872
public sealed class EvilThirstEffect : BattleEffectBase
{
	// Token: 0x060035D7 RID: 13783 RVA: 0x00166E1C File Offset: 0x0016521C
	public EvilThirstEffect(int swallowCount, double damageValue, int? lastingTurns, int? lastingSeconds, IBattleEffectSource effectSource)
	{
		this._effectSourceIdentityCode = "uniqueevilthirst";
		this._battleEffectType = BattleEffectType.EvilThirst;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = true;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Negative;
		this.CanBeDispersed = true;
		Description description = this._battleEffectType.GetDescription();
		base.Description = description;
		base.TurnEventsCollected = new List<AdventureEventType>();
		this.NumberOfLastingTurns = lastingTurns;
		this.MaxNumberOfLastingSeconds = ((lastingSeconds == null) ? null : new float?((float)lastingSeconds.Value));
		this._swallowPerSecond = swallowCount;
		this._damageValue = damageValue;
	}

	// Token: 0x060035D8 RID: 13784 RVA: 0x00166ED4 File Offset: 0x001652D4
	public override IEnumerable PerSecondLogic_ActiveUnit(IBattleUnit listener)
	{
		if (listener.BattleEffects.Count((BattleEffectBase ef) => ef.CanBeDispersed && ef.BattleEffectNatureForWearer == BattleEffectNature.Positive) >= this._swallowPerSecond)
		{
			IEnumerator enumerator = UnitStyleConfigurationBase.DispelPositiveEffects(listener, new int?(this._swallowPerSecond)).GetEnumerator();
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
		}
		else
		{
			IEnumerator enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(listener, null).GetEnumerator();
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
			ReleaseableDamage releaseable = new ReleaseableDamage(new List<BattleDamage>
			{
				new BattleDamage(listener, this, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(listener, this.EffectSource.SourceUnit, OutputType.RealDamage, this._damageValue)
					}, listener, this.EffectSource.SourceUnit, false, false)
				})
			}, this.EffectSource.SourceUnit);
			IEnumerator enumerator3 = releaseable.Release().GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x060035D9 RID: 13785 RVA: 0x00166EFE File Offset: 0x001652FE
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000934 RID: 2356
	// (get) Token: 0x060035DA RID: 13786 RVA: 0x00166F05 File Offset: 0x00165305
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000935 RID: 2357
	// (get) Token: 0x060035DB RID: 13787 RVA: 0x00166F0D File Offset: 0x0016530D
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000936 RID: 2358
	// (get) Token: 0x060035DC RID: 13788 RVA: 0x00166F15 File Offset: 0x00165315
	// (set) Token: 0x060035DD RID: 13789 RVA: 0x00166F1D File Offset: 0x0016531D
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

	// Token: 0x17000937 RID: 2359
	// (get) Token: 0x060035DE RID: 13790 RVA: 0x00166F26 File Offset: 0x00165326
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000938 RID: 2360
	// (get) Token: 0x060035DF RID: 13791 RVA: 0x00166F2E File Offset: 0x0016532E
	// (set) Token: 0x060035E0 RID: 13792 RVA: 0x00166F36 File Offset: 0x00165336
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

	// Token: 0x17000939 RID: 2361
	// (get) Token: 0x060035E1 RID: 13793 RVA: 0x00166F3F File Offset: 0x0016533F
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x1700093A RID: 2362
	// (get) Token: 0x060035E2 RID: 13794 RVA: 0x00166F47 File Offset: 0x00165347
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x1700093B RID: 2363
	// (get) Token: 0x060035E3 RID: 13795 RVA: 0x00166F4F File Offset: 0x0016534F
	// (set) Token: 0x060035E4 RID: 13796 RVA: 0x00166F57 File Offset: 0x00165357
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

	// Token: 0x1700093C RID: 2364
	// (get) Token: 0x060035E5 RID: 13797 RVA: 0x00166F60 File Offset: 0x00165360
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x1700093D RID: 2365
	// (get) Token: 0x060035E6 RID: 13798 RVA: 0x00166F68 File Offset: 0x00165368
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x040029F6 RID: 10742
	private readonly string _effectSourceIdentityCode;

	// Token: 0x040029F7 RID: 10743
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x040029F8 RID: 10744
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x040029F9 RID: 10745
	private readonly bool _isThroughEffect;

	// Token: 0x040029FA RID: 10746
	private readonly bool _canBeImmuned;

	// Token: 0x040029FB RID: 10747
	private readonly int? _maxStackableInstances;

	// Token: 0x040029FC RID: 10748
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x040029FD RID: 10749
	private int _swallowPerSecond;

	// Token: 0x040029FE RID: 10750
	private double _damageValue;

	// Token: 0x040029FF RID: 10751
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002A00 RID: 10752
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002A01 RID: 10753
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000EB5 RID: 3765
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005ED4 RID: 24276 RVA: 0x00166F70 File Offset: 0x00165370
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005ED5 RID: 24277 RVA: 0x00166F78 File Offset: 0x00165378
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (listener.BattleEffects.Count((BattleEffectBase ef) => ef.CanBeDispersed && ef.BattleEffectNatureForWearer == BattleEffectNature.Positive) < this._swallowPerSecond)
				{
					enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(listener, null).GetEnumerator();
					num = 4294967293u;
					goto Block_5;
				}
				enumerator = UnitStyleConfigurationBase.DispelPositiveEffects(listener, new int?(this._swallowPerSecond)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_13A;
			case 3u:
				goto IL_275;
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
			goto IL_2F7;
			Block_5:
			try
			{
				IL_13A:
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
			releaseable = new ReleaseableDamage(new List<BattleDamage>
			{
				new BattleDamage(listener, this, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(listener, this.EffectSource.SourceUnit, OutputType.RealDamage, this._damageValue)
					}, listener, this.EffectSource.SourceUnit, false, false)
				})
			}, this.EffectSource.SourceUnit);
			enumerator3 = releaseable.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_275:
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
			IL_2F7:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013D0 RID: 5072
		// (get) Token: 0x06005ED6 RID: 24278 RVA: 0x001672B0 File Offset: 0x001656B0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013D1 RID: 5073
		// (get) Token: 0x06005ED7 RID: 24279 RVA: 0x001672B8 File Offset: 0x001656B8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005ED8 RID: 24280 RVA: 0x001672C0 File Offset: 0x001656C0
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

		// Token: 0x06005ED9 RID: 24281 RVA: 0x001673B0 File Offset: 0x001657B0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005EDA RID: 24282 RVA: 0x001673B7 File Offset: 0x001657B7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005EDB RID: 24283 RVA: 0x001673C0 File Offset: 0x001657C0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EvilThirstEffect.<PerSecondLogic_ActiveUnit>c__Iterator0 <PerSecondLogic_ActiveUnit>c__Iterator = new EvilThirstEffect.<PerSecondLogic_ActiveUnit>c__Iterator0();
			<PerSecondLogic_ActiveUnit>c__Iterator.$this = this;
			<PerSecondLogic_ActiveUnit>c__Iterator.listener = listener;
			return <PerSecondLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x06005EDC RID: 24284 RVA: 0x00167400 File Offset: 0x00165800
		private static bool <>m__0(BattleEffectBase ef)
		{
			return ef.CanBeDispersed && ef.BattleEffectNatureForWearer == BattleEffectNature.Positive;
		}

		// Token: 0x040052D5 RID: 21205
		internal IBattleUnit listener;

		// Token: 0x040052D6 RID: 21206
		internal IEnumerator $locvar0;

		// Token: 0x040052D7 RID: 21207
		internal object <_>__1;

		// Token: 0x040052D8 RID: 21208
		internal IDisposable $locvar1;

		// Token: 0x040052D9 RID: 21209
		internal IEnumerator $locvar2;

		// Token: 0x040052DA RID: 21210
		internal object <_>__2;

		// Token: 0x040052DB RID: 21211
		internal IDisposable $locvar3;

		// Token: 0x040052DC RID: 21212
		internal ReleaseableDamage <releaseable>__3;

		// Token: 0x040052DD RID: 21213
		internal IEnumerator $locvar4;

		// Token: 0x040052DE RID: 21214
		internal object <_>__4;

		// Token: 0x040052DF RID: 21215
		internal IDisposable $locvar5;

		// Token: 0x040052E0 RID: 21216
		internal EvilThirstEffect $this;

		// Token: 0x040052E1 RID: 21217
		internal object $current;

		// Token: 0x040052E2 RID: 21218
		internal bool $disposing;

		// Token: 0x040052E3 RID: 21219
		internal int $PC;

		// Token: 0x040052E4 RID: 21220
		private static Func<BattleEffectBase, bool> <>f__am$cache0;
	}
}
