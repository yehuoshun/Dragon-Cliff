using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000764 RID: 1892
public class PoisonBaitEffect : BattleEffectBase
{
	// Token: 0x0600370A RID: 14090 RVA: 0x0016CC3C File Offset: 0x0016B03C
	public PoisonBaitEffect(string effectSourceIdentityCode, IBattleEffectSource effectSource, float? maxNumberOfLastingSeconds, double damageRate)
	{
		Description description = BattleEffectType.PoisonBait.GetDescription();
		description.Details1 = description.Details1.Replace("{seconds}", maxNumberOfLastingSeconds.GetValueOrDefault().FloatToString()).Replace("{rate}", damageRate.ToExpressionMultiply100());
		this._effectSourceIdentityCode = effectSourceIdentityCode;
		this._battleEffectType = BattleEffectType.PoisonBait;
		this._effectSource = effectSource;
		this._isThroughEffect = false;
		this._canBeImmuned = true;
		this._canBeDispersed = true;
		this._maxStackableInstances = new int?(5);
		this._battleEffectNatureForWearer = BattleEffectNature.Negative;
		this.MaxNumberOfLastingSeconds = maxNumberOfLastingSeconds;
		this.NumberOfLastingTurns = null;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = description;
		this._damageRate = damageRate;
	}

	// Token: 0x0600370B RID: 14091 RVA: 0x0016CCF8 File Offset: 0x0016B0F8
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x170009EE RID: 2542
	// (get) Token: 0x0600370C RID: 14092 RVA: 0x0016CCFF File Offset: 0x0016B0FF
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170009EF RID: 2543
	// (get) Token: 0x0600370D RID: 14093 RVA: 0x0016CD07 File Offset: 0x0016B107
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170009F0 RID: 2544
	// (get) Token: 0x0600370E RID: 14094 RVA: 0x0016CD0F File Offset: 0x0016B10F
	// (set) Token: 0x0600370F RID: 14095 RVA: 0x0016CD17 File Offset: 0x0016B117
	public sealed override float? MaxNumberOfLastingSeconds
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

	// Token: 0x170009F1 RID: 2545
	// (get) Token: 0x06003710 RID: 14096 RVA: 0x0016CD20 File Offset: 0x0016B120
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170009F2 RID: 2546
	// (get) Token: 0x06003711 RID: 14097 RVA: 0x0016CD28 File Offset: 0x0016B128
	// (set) Token: 0x06003712 RID: 14098 RVA: 0x0016CD30 File Offset: 0x0016B130
	public sealed override int? NumberOfLastingTurns
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

	// Token: 0x170009F3 RID: 2547
	// (get) Token: 0x06003713 RID: 14099 RVA: 0x0016CD39 File Offset: 0x0016B139
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170009F4 RID: 2548
	// (get) Token: 0x06003714 RID: 14100 RVA: 0x0016CD41 File Offset: 0x0016B141
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170009F5 RID: 2549
	// (get) Token: 0x06003715 RID: 14101 RVA: 0x0016CD49 File Offset: 0x0016B149
	// (set) Token: 0x06003716 RID: 14102 RVA: 0x0016CD51 File Offset: 0x0016B151
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

	// Token: 0x170009F6 RID: 2550
	// (get) Token: 0x06003717 RID: 14103 RVA: 0x0016CD5A File Offset: 0x0016B15A
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170009F7 RID: 2551
	// (get) Token: 0x06003718 RID: 14104 RVA: 0x0016CD62 File Offset: 0x0016B162
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x06003719 RID: 14105 RVA: 0x0016CD6C File Offset: 0x0016B16C
	public override IEnumerable PosWearsOffProcess_ActiveUnit(IBattleUnit effectWearer, EffectWearsOffType wearsOffType)
	{
		if (wearsOffType == EffectWearsOffType.Expiration)
		{
			List<IBattleUnit> targets = effectWearer.GetAllLiveFriendlyTargetsIncSelf(true);
			double damage = effectWearer.GetMaxLife(AttributeRetrievalLevel.Skill) * this._damageRate;
			if (targets.Any<IBattleUnit>())
			{
				ReleaseableDamage releaseable = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, this.$this, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(t, effectWearer, OutputType.RealDamage, damage)
					}, t, effectWearer, false, false)
				})).ToList<BattleDamage>(), effectWearer);
				IEnumerator enumerator = releaseable.Release().GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x04002AAF RID: 10927
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002AB0 RID: 10928
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002AB1 RID: 10929
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002AB2 RID: 10930
	private readonly bool _isThroughEffect;

	// Token: 0x04002AB3 RID: 10931
	private readonly bool _canBeImmuned;

	// Token: 0x04002AB4 RID: 10932
	private bool _canBeDispersed;

	// Token: 0x04002AB5 RID: 10933
	private readonly int? _maxStackableInstances;

	// Token: 0x04002AB6 RID: 10934
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002AB7 RID: 10935
	private double _damageRate;

	// Token: 0x04002AB8 RID: 10936
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002AB9 RID: 10937
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x02000EC7 RID: 3783
	[CompilerGenerated]
	private sealed class <PosWearsOffProcess_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F51 RID: 24401 RVA: 0x0016CD9D File Offset: 0x0016B19D
		[DebuggerHidden]
		public <PosWearsOffProcess_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005F52 RID: 24402 RVA: 0x0016CDA8 File Offset: 0x0016B1A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				<PosWearsOffProcess_ActiveUnit>c__AnonStorey = new PoisonBaitEffect.<PosWearsOffProcess_ActiveUnit>c__Iterator0.<PosWearsOffProcess_ActiveUnit>c__AnonStorey1();
				<PosWearsOffProcess_ActiveUnit>c__AnonStorey.effectWearer = effectWearer;
				if (wearsOffType != EffectWearsOffType.Expiration)
				{
					goto IL_194;
				}
				targets = <PosWearsOffProcess_ActiveUnit>c__AnonStorey.effectWearer.GetAllLiveFriendlyTargetsIncSelf(true);
				double damage = <PosWearsOffProcess_ActiveUnit>c__AnonStorey.effectWearer.GetMaxLife(AttributeRetrievalLevel.Skill) * this._damageRate;
				if (!targets.Any<IBattleUnit>())
				{
					goto IL_194;
				}
				releaseable = new ReleaseableDamage((from t in targets
				select new BattleDamage(t, this.$this, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(t, <PosWearsOffProcess_ActiveUnit>c__AnonStorey.effectWearer, OutputType.RealDamage, damage)
					}, t, <PosWearsOffProcess_ActiveUnit>c__AnonStorey.effectWearer, false, false)
				})).ToList<BattleDamage>(), <PosWearsOffProcess_ActiveUnit>c__AnonStorey.effectWearer);
				enumerator = releaseable.Release().GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
				break;
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
			IL_194:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013EC RID: 5100
		// (get) Token: 0x06005F53 RID: 24403 RVA: 0x0016CF64 File Offset: 0x0016B364
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013ED RID: 5101
		// (get) Token: 0x06005F54 RID: 24404 RVA: 0x0016CF6C File Offset: 0x0016B36C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F55 RID: 24405 RVA: 0x0016CF74 File Offset: 0x0016B374
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
			}
		}

		// Token: 0x06005F56 RID: 24406 RVA: 0x0016CFE4 File Offset: 0x0016B3E4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F57 RID: 24407 RVA: 0x0016CFEB File Offset: 0x0016B3EB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F58 RID: 24408 RVA: 0x0016CFF4 File Offset: 0x0016B3F4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			PoisonBaitEffect.<PosWearsOffProcess_ActiveUnit>c__Iterator0 <PosWearsOffProcess_ActiveUnit>c__Iterator = new PoisonBaitEffect.<PosWearsOffProcess_ActiveUnit>c__Iterator0();
			<PosWearsOffProcess_ActiveUnit>c__Iterator.$this = this;
			<PosWearsOffProcess_ActiveUnit>c__Iterator.wearsOffType = wearsOffType;
			<PosWearsOffProcess_ActiveUnit>c__Iterator.effectWearer = effectWearer;
			return <PosWearsOffProcess_ActiveUnit>c__Iterator;
		}

		// Token: 0x040053D7 RID: 21463
		internal EffectWearsOffType wearsOffType;

		// Token: 0x040053D8 RID: 21464
		internal IBattleUnit effectWearer;

		// Token: 0x040053D9 RID: 21465
		internal List<IBattleUnit> <targets>__1;

		// Token: 0x040053DA RID: 21466
		internal ReleaseableDamage <releaseable>__2;

		// Token: 0x040053DB RID: 21467
		internal IEnumerator $locvar0;

		// Token: 0x040053DC RID: 21468
		internal object <_>__3;

		// Token: 0x040053DD RID: 21469
		internal IDisposable $locvar1;

		// Token: 0x040053DE RID: 21470
		internal PoisonBaitEffect $this;

		// Token: 0x040053DF RID: 21471
		internal object $current;

		// Token: 0x040053E0 RID: 21472
		internal bool $disposing;

		// Token: 0x040053E1 RID: 21473
		internal int $PC;

		// Token: 0x040053E2 RID: 21474
		private PoisonBaitEffect.<PosWearsOffProcess_ActiveUnit>c__Iterator0.<PosWearsOffProcess_ActiveUnit>c__AnonStorey1 $locvar2;

		// Token: 0x040053E3 RID: 21475
		private PoisonBaitEffect.<PosWearsOffProcess_ActiveUnit>c__Iterator0.<PosWearsOffProcess_ActiveUnit>c__AnonStorey2 $locvar3;

		// Token: 0x02000EC8 RID: 3784
		private sealed class <PosWearsOffProcess_ActiveUnit>c__AnonStorey1
		{
			// Token: 0x06005F59 RID: 24409 RVA: 0x0016D040 File Offset: 0x0016B440
			public <PosWearsOffProcess_ActiveUnit>c__AnonStorey1()
			{
			}

			// Token: 0x040053E4 RID: 21476
			internal IBattleUnit effectWearer;
		}

		// Token: 0x02000EC9 RID: 3785
		private sealed class <PosWearsOffProcess_ActiveUnit>c__AnonStorey2
		{
			// Token: 0x06005F5A RID: 24410 RVA: 0x0016D048 File Offset: 0x0016B448
			public <PosWearsOffProcess_ActiveUnit>c__AnonStorey2()
			{
			}

			// Token: 0x06005F5B RID: 24411 RVA: 0x0016D050 File Offset: 0x0016B450
			internal BattleDamage <>m__0(IBattleUnit t)
			{
				return new BattleDamage(t, this.<>f__ref$0.$this, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(t, this.<>f__ref$1.effectWearer, OutputType.RealDamage, this.damage)
					}, t, this.<>f__ref$1.effectWearer, false, false)
				});
			}

			// Token: 0x040053E5 RID: 21477
			internal double damage;

			// Token: 0x040053E6 RID: 21478
			internal PoisonBaitEffect.<PosWearsOffProcess_ActiveUnit>c__Iterator0 <>f__ref$0;

			// Token: 0x040053E7 RID: 21479
			internal PoisonBaitEffect.<PosWearsOffProcess_ActiveUnit>c__Iterator0.<PosWearsOffProcess_ActiveUnit>c__AnonStorey1 <>f__ref$1;
		}
	}
}
