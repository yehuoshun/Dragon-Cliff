using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000777 RID: 1911
public class TimelyCowardActiveEffect : BattleEffectBase
{
	// Token: 0x06003844 RID: 14404 RVA: 0x00171854 File Offset: 0x0016FC54
	public TimelyCowardActiveEffect(int maxStayingSeconds, IBattleUnit caster, string sourceIdentityCode)
	{
		this._maxStayingSeconds = maxStayingSeconds;
		this._effectSourceIdentityCode = sourceIdentityCode;
		this._effectSource = caster;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.TimelyCoward.GetDescription();
		base.Description.Details1 = base.Description.Details1.Replace("{seconds}", maxStayingSeconds.ToString());
		this._stayedSecondsSoFar = 0;
	}

	// Token: 0x06003845 RID: 14405 RVA: 0x001718E0 File Offset: 0x0016FCE0
	public override IEnumerable PerSecondLogic_ActiveUnit(IBattleUnit listener)
	{
		if (listener.Status == BattleUnitStatus.Active)
		{
			this._stayedSecondsSoFar++;
			if (this._stayedSecondsSoFar >= this._maxStayingSeconds)
			{
				IEnumerator enumerator = listener.Escape().GetEnumerator();
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

	// Token: 0x17000AAE RID: 2734
	// (get) Token: 0x06003846 RID: 14406 RVA: 0x0017190A File Offset: 0x0016FD0A
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x06003847 RID: 14407 RVA: 0x00171912 File Offset: 0x0016FD12
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x17000AAF RID: 2735
	// (get) Token: 0x06003848 RID: 14408 RVA: 0x00171919 File Offset: 0x0016FD19
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000AB0 RID: 2736
	// (get) Token: 0x06003849 RID: 14409 RVA: 0x00171921 File Offset: 0x0016FD21
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000AB1 RID: 2737
	// (get) Token: 0x0600384A RID: 14410 RVA: 0x00171929 File Offset: 0x0016FD29
	// (set) Token: 0x0600384B RID: 14411 RVA: 0x00171931 File Offset: 0x0016FD31
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

	// Token: 0x17000AB2 RID: 2738
	// (get) Token: 0x0600384C RID: 14412 RVA: 0x0017193A File Offset: 0x0016FD3A
	// (set) Token: 0x0600384D RID: 14413 RVA: 0x00171942 File Offset: 0x0016FD42
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

	// Token: 0x17000AB3 RID: 2739
	// (get) Token: 0x0600384E RID: 14414 RVA: 0x0017194B File Offset: 0x0016FD4B
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000AB4 RID: 2740
	// (get) Token: 0x0600384F RID: 14415 RVA: 0x00171953 File Offset: 0x0016FD53
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000AB5 RID: 2741
	// (get) Token: 0x06003850 RID: 14416 RVA: 0x0017195B File Offset: 0x0016FD5B
	// (set) Token: 0x06003851 RID: 14417 RVA: 0x00171963 File Offset: 0x0016FD63
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

	// Token: 0x17000AB6 RID: 2742
	// (get) Token: 0x06003852 RID: 14418 RVA: 0x0017196C File Offset: 0x0016FD6C
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(this._maxStackableInstances);
		}
	}

	// Token: 0x17000AB7 RID: 2743
	// (get) Token: 0x06003853 RID: 14419 RVA: 0x00171979 File Offset: 0x0016FD79
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002B7E RID: 11134
	private BattleEffectType _battleEffectType = BattleEffectType.TimelyCoward;

	// Token: 0x04002B7F RID: 11135
	private int? _numberOfLastingTurns;

	// Token: 0x04002B80 RID: 11136
	private bool _isThroughEffect;

	// Token: 0x04002B81 RID: 11137
	private bool _canBeImmuned;

	// Token: 0x04002B82 RID: 11138
	private bool _canBeDispersed;

	// Token: 0x04002B83 RID: 11139
	private int _maxStackableInstances = 1;

	// Token: 0x04002B84 RID: 11140
	private BattleEffectNature _battleEffectNatureForWearer = BattleEffectNature.Neutral;

	// Token: 0x04002B85 RID: 11141
	private int _maxStayingSeconds;

	// Token: 0x04002B86 RID: 11142
	private int _stayedSecondsSoFar;

	// Token: 0x04002B87 RID: 11143
	private string _effectSourceIdentityCode;

	// Token: 0x04002B88 RID: 11144
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002B89 RID: 11145
	private IBattleEffectSource _effectSource;

	// Token: 0x02000ED8 RID: 3800
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005FCB RID: 24523 RVA: 0x00171981 File Offset: 0x0016FD81
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005FCC RID: 24524 RVA: 0x0017198C File Offset: 0x0016FD8C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (listener.Status != BattleUnitStatus.Active)
				{
					goto IL_FD;
				}
				this._stayedSecondsSoFar++;
				if (this._stayedSecondsSoFar < this._maxStayingSeconds)
				{
					goto IL_FD;
				}
				enumerator = listener.Escape().GetEnumerator();
				num = 4294967293u;
				break;
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
			IL_FD:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001408 RID: 5128
		// (get) Token: 0x06005FCD RID: 24525 RVA: 0x00171AB0 File Offset: 0x0016FEB0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001409 RID: 5129
		// (get) Token: 0x06005FCE RID: 24526 RVA: 0x00171AB8 File Offset: 0x0016FEB8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005FCF RID: 24527 RVA: 0x00171AC0 File Offset: 0x0016FEC0
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

		// Token: 0x06005FD0 RID: 24528 RVA: 0x00171B30 File Offset: 0x0016FF30
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005FD1 RID: 24529 RVA: 0x00171B37 File Offset: 0x0016FF37
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005FD2 RID: 24530 RVA: 0x00171B40 File Offset: 0x0016FF40
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			TimelyCowardActiveEffect.<PerSecondLogic_ActiveUnit>c__Iterator0 <PerSecondLogic_ActiveUnit>c__Iterator = new TimelyCowardActiveEffect.<PerSecondLogic_ActiveUnit>c__Iterator0();
			<PerSecondLogic_ActiveUnit>c__Iterator.$this = this;
			<PerSecondLogic_ActiveUnit>c__Iterator.listener = listener;
			return <PerSecondLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040054A1 RID: 21665
		internal IBattleUnit listener;

		// Token: 0x040054A2 RID: 21666
		internal IEnumerator $locvar0;

		// Token: 0x040054A3 RID: 21667
		internal object <_>__1;

		// Token: 0x040054A4 RID: 21668
		internal IDisposable $locvar1;

		// Token: 0x040054A5 RID: 21669
		internal TimelyCowardActiveEffect $this;

		// Token: 0x040054A6 RID: 21670
		internal object $current;

		// Token: 0x040054A7 RID: 21671
		internal bool $disposing;

		// Token: 0x040054A8 RID: 21672
		internal int $PC;
	}
}
