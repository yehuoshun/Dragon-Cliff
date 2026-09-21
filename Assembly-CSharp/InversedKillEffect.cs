using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200075F RID: 1887
public class InversedKillEffect : BattleEffectBase
{
	// Token: 0x060036B4 RID: 14004 RVA: 0x0016A1AC File Offset: 0x001685AC
	public InversedKillEffect(IBattleEffectSource effectSource, double damageRate, OutputType damageType, float lastingSeconds)
	{
		this._effectSourceIdentityCode = BattleEffectType.InversedKill.ToString();
		this._battleEffectType = BattleEffectType.InversedKill;
		this._maxNumberOfLastingSeconds = new float?(lastingSeconds);
		this._effectSource = effectSource;
		this._numberOfLastingTurns = null;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._canBeDispersed = false;
		this._maxStackableInstances = new int?(1);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this._finalDamageRate = damageRate;
		this._damageType = damageType;
		base.Description = BattleEffectType.InversedKill.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x060036B5 RID: 14005 RVA: 0x0016A250 File Offset: 0x00168650
	public override IEnumerable PosWearsOffProcess_ActiveUnit(IBattleUnit effectWearer, EffectWearsOffType wearsOffType)
	{
		if (wearsOffType == EffectWearsOffType.Expiration)
		{
			List<IBattleUnit> enemies = effectWearer.GetLiveEnemyTargets(false, true);
			if (enemies.Any<IBattleUnit>())
			{
				IBattleUnit selectedEnemey = enemies[UnityEngine.Random.Range(0, enemies.Count)];
				ReleaseableDamage releaseableDamage = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(selectedEnemey, this, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(effectWearer, selectedEnemey, this._damageType, this._finalDamageRate)
						}, selectedEnemey, effectWearer, true, false)
					})
				}, effectWearer);
				IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(effectWearer, AdventureEventType.InversedKillPerformed, selectedEnemey)).GetEnumerator();
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
				IEnumerator enumerator2 = releaseableDamage.Release().GetEnumerator();
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
				IEnumerator enumerator3 = this.Triggered(effectWearer).GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x060036B6 RID: 14006 RVA: 0x0016A281 File Offset: 0x00168681
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x170009BB RID: 2491
	// (get) Token: 0x060036B7 RID: 14007 RVA: 0x0016A288 File Offset: 0x00168688
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170009BC RID: 2492
	// (get) Token: 0x060036B8 RID: 14008 RVA: 0x0016A290 File Offset: 0x00168690
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170009BD RID: 2493
	// (get) Token: 0x060036B9 RID: 14009 RVA: 0x0016A298 File Offset: 0x00168698
	// (set) Token: 0x060036BA RID: 14010 RVA: 0x0016A2A0 File Offset: 0x001686A0
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

	// Token: 0x170009BE RID: 2494
	// (get) Token: 0x060036BB RID: 14011 RVA: 0x0016A2A9 File Offset: 0x001686A9
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170009BF RID: 2495
	// (get) Token: 0x060036BC RID: 14012 RVA: 0x0016A2B1 File Offset: 0x001686B1
	// (set) Token: 0x060036BD RID: 14013 RVA: 0x0016A2B9 File Offset: 0x001686B9
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

	// Token: 0x170009C0 RID: 2496
	// (get) Token: 0x060036BE RID: 14014 RVA: 0x0016A2C2 File Offset: 0x001686C2
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170009C1 RID: 2497
	// (get) Token: 0x060036BF RID: 14015 RVA: 0x0016A2CA File Offset: 0x001686CA
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170009C2 RID: 2498
	// (get) Token: 0x060036C0 RID: 14016 RVA: 0x0016A2D2 File Offset: 0x001686D2
	// (set) Token: 0x060036C1 RID: 14017 RVA: 0x0016A2DA File Offset: 0x001686DA
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

	// Token: 0x170009C3 RID: 2499
	// (get) Token: 0x060036C2 RID: 14018 RVA: 0x0016A2E3 File Offset: 0x001686E3
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170009C4 RID: 2500
	// (get) Token: 0x060036C3 RID: 14019 RVA: 0x0016A2EB File Offset: 0x001686EB
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002A77 RID: 10871
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002A78 RID: 10872
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002A79 RID: 10873
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002A7A RID: 10874
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002A7B RID: 10875
	private int? _numberOfLastingTurns;

	// Token: 0x04002A7C RID: 10876
	private readonly bool _isThroughEffect;

	// Token: 0x04002A7D RID: 10877
	private readonly bool _canBeImmuned;

	// Token: 0x04002A7E RID: 10878
	private bool _canBeDispersed;

	// Token: 0x04002A7F RID: 10879
	private readonly int? _maxStackableInstances;

	// Token: 0x04002A80 RID: 10880
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002A81 RID: 10881
	private double _finalDamageRate;

	// Token: 0x04002A82 RID: 10882
	private OutputType _damageType;

	// Token: 0x02000EBC RID: 3772
	[CompilerGenerated]
	private sealed class <PosWearsOffProcess_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F10 RID: 24336 RVA: 0x0016A2F3 File Offset: 0x001686F3
		[DebuggerHidden]
		public <PosWearsOffProcess_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005F11 RID: 24337 RVA: 0x0016A2FC File Offset: 0x001686FC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (wearsOffType != EffectWearsOffType.Expiration)
				{
					goto IL_2F1;
				}
				enemies = effectWearer.GetLiveEnemyTargets(false, true);
				if (!enemies.Any<IBattleUnit>())
				{
					goto IL_2F1;
				}
				selectedEnemey = enemies[UnityEngine.Random.Range(0, enemies.Count)];
				releaseableDamage = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(selectedEnemey, this, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							new DamagePotionValue(effectWearer, selectedEnemey, this._damageType, this._finalDamageRate)
						}, selectedEnemey, effectWearer, true, false)
					})
				}, effectWearer);
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(effectWearer, AdventureEventType.InversedKillPerformed, selectedEnemey)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1CA;
			case 3u:
				goto IL_26D;
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
			enumerator2 = releaseableDamage.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1CA:
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
			enumerator3 = this.Triggered(effectWearer).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_26D:
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
			IL_2F1:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013DE RID: 5086
		// (get) Token: 0x06005F12 RID: 24338 RVA: 0x0016A62C File Offset: 0x00168A2C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013DF RID: 5087
		// (get) Token: 0x06005F13 RID: 24339 RVA: 0x0016A634 File Offset: 0x00168A34
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F14 RID: 24340 RVA: 0x0016A63C File Offset: 0x00168A3C
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

		// Token: 0x06005F15 RID: 24341 RVA: 0x0016A72C File Offset: 0x00168B2C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F16 RID: 24342 RVA: 0x0016A733 File Offset: 0x00168B33
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F17 RID: 24343 RVA: 0x0016A73C File Offset: 0x00168B3C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			InversedKillEffect.<PosWearsOffProcess_ActiveUnit>c__Iterator0 <PosWearsOffProcess_ActiveUnit>c__Iterator = new InversedKillEffect.<PosWearsOffProcess_ActiveUnit>c__Iterator0();
			<PosWearsOffProcess_ActiveUnit>c__Iterator.$this = this;
			<PosWearsOffProcess_ActiveUnit>c__Iterator.wearsOffType = wearsOffType;
			<PosWearsOffProcess_ActiveUnit>c__Iterator.effectWearer = effectWearer;
			return <PosWearsOffProcess_ActiveUnit>c__Iterator;
		}

		// Token: 0x04005356 RID: 21334
		internal EffectWearsOffType wearsOffType;

		// Token: 0x04005357 RID: 21335
		internal IBattleUnit effectWearer;

		// Token: 0x04005358 RID: 21336
		internal List<IBattleUnit> <enemies>__1;

		// Token: 0x04005359 RID: 21337
		internal IBattleUnit <selectedEnemey>__2;

		// Token: 0x0400535A RID: 21338
		internal ReleaseableDamage <releaseableDamage>__2;

		// Token: 0x0400535B RID: 21339
		internal IEnumerator $locvar0;

		// Token: 0x0400535C RID: 21340
		internal object <_>__3;

		// Token: 0x0400535D RID: 21341
		internal IDisposable $locvar1;

		// Token: 0x0400535E RID: 21342
		internal IEnumerator $locvar2;

		// Token: 0x0400535F RID: 21343
		internal object <_>__4;

		// Token: 0x04005360 RID: 21344
		internal IDisposable $locvar3;

		// Token: 0x04005361 RID: 21345
		internal IEnumerator $locvar4;

		// Token: 0x04005362 RID: 21346
		internal object <_>__5;

		// Token: 0x04005363 RID: 21347
		internal IDisposable $locvar5;

		// Token: 0x04005364 RID: 21348
		internal InversedKillEffect $this;

		// Token: 0x04005365 RID: 21349
		internal object $current;

		// Token: 0x04005366 RID: 21350
		internal bool $disposing;

		// Token: 0x04005367 RID: 21351
		internal int $PC;
	}
}
