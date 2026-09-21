using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000770 RID: 1904
public class StrangeGhostEffect : BattleEffectBase
{
	// Token: 0x060037D1 RID: 14289 RVA: 0x001703DC File Offset: 0x0016E7DC
	public StrangeGhostEffect(float lastingSeconds, IBattleEffectSource battleEffectSource, double heal, int maxNumberOfStacks)
	{
		this._effectSourceIdentityCode = BattleEffectType.StrangeGhost.ToString();
		this._battleEffectType = BattleEffectType.StrangeGhost;
		this._maxNumberOfLastingSeconds = new float?(lastingSeconds);
		this._effectSource = battleEffectSource;
		this._numberOfLastingTurns = null;
		this._isThroughEffect = false;
		this._canBeImmuned = false;
		this._canBeDispersed = false;
		this._maxStackableInstances = new int?(maxNumberOfStacks);
		this._battleEffectNatureForWearer = BattleEffectNature.Negative;
		this._healValue = heal;
		base.Description = BattleEffectType.StrangeGhost.GetDescription();
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x060037D2 RID: 14290 RVA: 0x00170478 File Offset: 0x0016E878
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage_Single
		};
	}

	// Token: 0x17000A66 RID: 2662
	// (get) Token: 0x060037D3 RID: 14291 RVA: 0x00170494 File Offset: 0x0016E894
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000A67 RID: 2663
	// (get) Token: 0x060037D4 RID: 14292 RVA: 0x0017049C File Offset: 0x0016E89C
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000A68 RID: 2664
	// (get) Token: 0x060037D5 RID: 14293 RVA: 0x001704A4 File Offset: 0x0016E8A4
	// (set) Token: 0x060037D6 RID: 14294 RVA: 0x001704AC File Offset: 0x0016E8AC
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

	// Token: 0x17000A69 RID: 2665
	// (get) Token: 0x060037D7 RID: 14295 RVA: 0x001704B5 File Offset: 0x0016E8B5
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000A6A RID: 2666
	// (get) Token: 0x060037D8 RID: 14296 RVA: 0x001704BD File Offset: 0x0016E8BD
	// (set) Token: 0x060037D9 RID: 14297 RVA: 0x001704C5 File Offset: 0x0016E8C5
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

	// Token: 0x17000A6B RID: 2667
	// (get) Token: 0x060037DA RID: 14298 RVA: 0x001704CE File Offset: 0x0016E8CE
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000A6C RID: 2668
	// (get) Token: 0x060037DB RID: 14299 RVA: 0x001704D6 File Offset: 0x0016E8D6
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000A6D RID: 2669
	// (get) Token: 0x060037DC RID: 14300 RVA: 0x001704DE File Offset: 0x0016E8DE
	// (set) Token: 0x060037DD RID: 14301 RVA: 0x001704E6 File Offset: 0x0016E8E6
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

	// Token: 0x17000A6E RID: 2670
	// (get) Token: 0x060037DE RID: 14302 RVA: 0x001704EF File Offset: 0x0016E8EF
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000A6F RID: 2671
	// (get) Token: 0x060037DF RID: 14303 RVA: 0x001704F7 File Offset: 0x0016E8F7
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x060037E0 RID: 14304 RVA: 0x00170500 File Offset: 0x0016E900
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPostReceivesDamage_Single && eventTriggerUnit == this.EffectSource.SourceUnit)
		{
			DamageComponent damage = data as DamageComponent;
			if (damage != null && damage.Target == this.EffectSource.SourceUnit && damage.IsDirectDamage && !damage.IsMissed)
			{
				ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(this.EffectSource.SourceUnit, this, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = this._healValue,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, false)
				}, eventTriggerUnit);
				IEnumerator enumerator = releaseableHeal.Release().GetEnumerator();
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

	// Token: 0x04002B34 RID: 11060
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002B35 RID: 11061
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002B36 RID: 11062
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002B37 RID: 11063
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002B38 RID: 11064
	private int? _numberOfLastingTurns;

	// Token: 0x04002B39 RID: 11065
	private readonly bool _isThroughEffect;

	// Token: 0x04002B3A RID: 11066
	private readonly bool _canBeImmuned;

	// Token: 0x04002B3B RID: 11067
	private bool _canBeDispersed;

	// Token: 0x04002B3C RID: 11068
	private readonly int? _maxStackableInstances;

	// Token: 0x04002B3D RID: 11069
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002B3E RID: 11070
	private double _healValue;

	// Token: 0x02000ED4 RID: 3796
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005FAF RID: 24495 RVA: 0x00170540 File Offset: 0x0016E940
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005FB0 RID: 24496 RVA: 0x00170548 File Offset: 0x0016E948
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPostReceivesDamage_Single || eventTriggerUnit != this.EffectSource.SourceUnit)
				{
					goto IL_25E;
				}
				damage = (data as DamageComponent);
				if (damage == null || damage.Target != this.EffectSource.SourceUnit || !damage.IsDirectDamage || damage.IsMissed)
				{
					goto IL_25E;
				}
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(this.EffectSource.SourceUnit, this, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = this._healValue,
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, false)
				}, eventTriggerUnit);
				enumerator = releaseableHeal.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1DA;
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
				IL_1DA:
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
			IL_25E:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001402 RID: 5122
		// (get) Token: 0x06005FB1 RID: 24497 RVA: 0x001707DC File Offset: 0x0016EBDC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001403 RID: 5123
		// (get) Token: 0x06005FB2 RID: 24498 RVA: 0x001707E4 File Offset: 0x0016EBE4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005FB3 RID: 24499 RVA: 0x001707EC File Offset: 0x0016EBEC
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

		// Token: 0x06005FB4 RID: 24500 RVA: 0x0017089C File Offset: 0x0016EC9C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005FB5 RID: 24501 RVA: 0x001708A3 File Offset: 0x0016ECA3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005FB6 RID: 24502 RVA: 0x001708AC File Offset: 0x0016ECAC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			StrangeGhostEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new StrangeGhostEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x04005478 RID: 21624
		internal AdventureEventType eventType;

		// Token: 0x04005479 RID: 21625
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400547A RID: 21626
		internal object data;

		// Token: 0x0400547B RID: 21627
		internal DamageComponent <damage>__1;

		// Token: 0x0400547C RID: 21628
		internal ReleaseableHeal <releaseableHeal>__2;

		// Token: 0x0400547D RID: 21629
		internal IEnumerator $locvar0;

		// Token: 0x0400547E RID: 21630
		internal object <_>__3;

		// Token: 0x0400547F RID: 21631
		internal IDisposable $locvar1;

		// Token: 0x04005480 RID: 21632
		internal IBattleUnit listener;

		// Token: 0x04005481 RID: 21633
		internal IEnumerator $locvar2;

		// Token: 0x04005482 RID: 21634
		internal object <_>__4;

		// Token: 0x04005483 RID: 21635
		internal IDisposable $locvar3;

		// Token: 0x04005484 RID: 21636
		internal StrangeGhostEffect $this;

		// Token: 0x04005485 RID: 21637
		internal object $current;

		// Token: 0x04005486 RID: 21638
		internal bool $disposing;

		// Token: 0x04005487 RID: 21639
		internal int $PC;
	}
}
