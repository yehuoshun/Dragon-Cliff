using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000779 RID: 1913
public sealed class UndeadEffect : BattleEffectBase
{
	// Token: 0x06003863 RID: 14435 RVA: 0x00171C68 File Offset: 0x00170068
	public UndeadEffect(int? seconds, int? turns, IBattleEffectSource effectSource, double healrate)
	{
		this._effectSourceIdentityCode = "undeaddrunkreader";
		this.MaxNumberOfLastingSeconds = ((seconds == null) ? null : new float?((float)seconds.Value));
		this.NumberOfLastingTurns = turns;
		base.TurnEventsCollected = new List<AdventureEventType>();
		this._battleEffectType = BattleEffectType.Undead;
		this._effectSource = effectSource;
		this._isThroughEffect = true;
		this._canBeImmuned = false;
		this._maxStackableInstances = new int?(2);
		this._battleEffectNatureForWearer = BattleEffectNature.Positive;
		this.CanBeDispersed = false;
		base.Description = BattleEffectType.Undead.GetDescription();
		this._heal = healrate;
	}

	// Token: 0x06003864 RID: 14436 RVA: 0x00171D14 File Offset: 0x00170114
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPreKilled && eventTriggerUnit == listener && data is BattleDamage && listener.HealthPoints <= 0.0)
		{
			BattleDamage damage = data as BattleDamage;
			double healRate = this._heal;
			double heal = healRate * eventTriggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
			ReleaseableHeal releaseable = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(eventTriggerUnit, damage.Dealer, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = heal,
						IsDirectHeal = false,
						HealType = OutputType.RealHeal
					}
				}, true)
			}, damage.Dealer);
			IEnumerator enumerator = this.Triggered(eventTriggerUnit).GetEnumerator();
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
			IEnumerator enumerator2 = releaseable.Release().GetEnumerator();
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
			IEnumerator enumerator3 = listener.LooseSkillEffect(this, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

	// Token: 0x06003865 RID: 14437 RVA: 0x00171D54 File Offset: 0x00170154
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPreKilled
		};
	}

	// Token: 0x17000AC2 RID: 2754
	// (get) Token: 0x06003866 RID: 14438 RVA: 0x00171D70 File Offset: 0x00170170
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x17000AC3 RID: 2755
	// (get) Token: 0x06003867 RID: 14439 RVA: 0x00171D78 File Offset: 0x00170178
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x17000AC4 RID: 2756
	// (get) Token: 0x06003868 RID: 14440 RVA: 0x00171D80 File Offset: 0x00170180
	// (set) Token: 0x06003869 RID: 14441 RVA: 0x00171D88 File Offset: 0x00170188
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

	// Token: 0x17000AC5 RID: 2757
	// (get) Token: 0x0600386A RID: 14442 RVA: 0x00171D91 File Offset: 0x00170191
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x17000AC6 RID: 2758
	// (get) Token: 0x0600386B RID: 14443 RVA: 0x00171D99 File Offset: 0x00170199
	// (set) Token: 0x0600386C RID: 14444 RVA: 0x00171DA1 File Offset: 0x001701A1
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

	// Token: 0x17000AC7 RID: 2759
	// (get) Token: 0x0600386D RID: 14445 RVA: 0x00171DAA File Offset: 0x001701AA
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x17000AC8 RID: 2760
	// (get) Token: 0x0600386E RID: 14446 RVA: 0x00171DB2 File Offset: 0x001701B2
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x17000AC9 RID: 2761
	// (get) Token: 0x0600386F RID: 14447 RVA: 0x00171DBA File Offset: 0x001701BA
	// (set) Token: 0x06003870 RID: 14448 RVA: 0x00171DC2 File Offset: 0x001701C2
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

	// Token: 0x17000ACA RID: 2762
	// (get) Token: 0x06003871 RID: 14449 RVA: 0x00171DCB File Offset: 0x001701CB
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x17000ACB RID: 2763
	// (get) Token: 0x06003872 RID: 14450 RVA: 0x00171DD3 File Offset: 0x001701D3
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002B94 RID: 11156
	private readonly string _effectSourceIdentityCode;

	// Token: 0x04002B95 RID: 11157
	private readonly BattleEffectType _battleEffectType;

	// Token: 0x04002B96 RID: 11158
	private readonly IBattleEffectSource _effectSource;

	// Token: 0x04002B97 RID: 11159
	private readonly bool _isThroughEffect;

	// Token: 0x04002B98 RID: 11160
	private readonly bool _canBeImmuned;

	// Token: 0x04002B99 RID: 11161
	private readonly int? _maxStackableInstances;

	// Token: 0x04002B9A RID: 11162
	private readonly BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002B9B RID: 11163
	private double _heal;

	// Token: 0x04002B9C RID: 11164
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x04002B9D RID: 11165
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x04002B9E RID: 11166
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000ED9 RID: 3801
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005FD3 RID: 24531 RVA: 0x00171DDB File Offset: 0x001701DB
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005FD4 RID: 24532 RVA: 0x00171DE4 File Offset: 0x001701E4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPreKilled || eventTriggerUnit != listener || !(data is BattleDamage) || listener.HealthPoints > 0.0)
				{
					goto IL_2FF;
				}
				damage = (data as BattleDamage);
				healRate = this._heal;
				heal = healRate * eventTriggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
				releaseable = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(eventTriggerUnit, damage.Dealer, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = heal,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, true)
				}, damage.Dealer);
				enumerator = this.Triggered(eventTriggerUnit).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1D7;
			case 3u:
				goto IL_27B;
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
			enumerator2 = releaseable.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1D7:
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
			enumerator3 = listener.LooseSkillEffect(this, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_27B:
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
			IL_2FF:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700140A RID: 5130
		// (get) Token: 0x06005FD5 RID: 24533 RVA: 0x00172124 File Offset: 0x00170524
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700140B RID: 5131
		// (get) Token: 0x06005FD6 RID: 24534 RVA: 0x0017212C File Offset: 0x0017052C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005FD7 RID: 24535 RVA: 0x00172134 File Offset: 0x00170534
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

		// Token: 0x06005FD8 RID: 24536 RVA: 0x00172224 File Offset: 0x00170624
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005FD9 RID: 24537 RVA: 0x0017222B File Offset: 0x0017062B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005FDA RID: 24538 RVA: 0x00172234 File Offset: 0x00170634
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			UndeadEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new UndeadEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040054A9 RID: 21673
		internal AdventureEventType eventType;

		// Token: 0x040054AA RID: 21674
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040054AB RID: 21675
		internal IBattleUnit listener;

		// Token: 0x040054AC RID: 21676
		internal object data;

		// Token: 0x040054AD RID: 21677
		internal BattleDamage <damage>__1;

		// Token: 0x040054AE RID: 21678
		internal double <healRate>__1;

		// Token: 0x040054AF RID: 21679
		internal double <heal>__1;

		// Token: 0x040054B0 RID: 21680
		internal ReleaseableHeal <releaseable>__1;

		// Token: 0x040054B1 RID: 21681
		internal IEnumerator $locvar0;

		// Token: 0x040054B2 RID: 21682
		internal object <_>__2;

		// Token: 0x040054B3 RID: 21683
		internal IDisposable $locvar1;

		// Token: 0x040054B4 RID: 21684
		internal IEnumerator $locvar2;

		// Token: 0x040054B5 RID: 21685
		internal object <_>__3;

		// Token: 0x040054B6 RID: 21686
		internal IDisposable $locvar3;

		// Token: 0x040054B7 RID: 21687
		internal IEnumerator $locvar4;

		// Token: 0x040054B8 RID: 21688
		internal object <_>__4;

		// Token: 0x040054B9 RID: 21689
		internal IDisposable $locvar5;

		// Token: 0x040054BA RID: 21690
		internal UndeadEffect $this;

		// Token: 0x040054BB RID: 21691
		internal object $current;

		// Token: 0x040054BC RID: 21692
		internal bool $disposing;

		// Token: 0x040054BD RID: 21693
		internal int $PC;
	}
}
