using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000755 RID: 1877
public class FireySoulEffect : BattleEffectBase
{
	// Token: 0x0600362C RID: 13868 RVA: 0x00167B90 File Offset: 0x00165F90
	public FireySoulEffect(int maxStack, IBattleUnit caster, string sourceIdentityCode)
	{
		this._effectSourceIdentityCode = sourceIdentityCode;
		this.StackCount = 1;
		this.MaxStack = maxStack;
		this._effectSource = caster;
		base.TurnEventsCollected = new List<AdventureEventType>();
		Description description = BattleEffectType.FierySoul.GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{maxstack}", maxStack.ToString()).Replace("{stack}", this.StackCount.ToString()).Replace("{healrate}", this.GetHealLifeRate().ToExpressionMultiply100()).ToString();
		base.Description = description;
		this._numberOfLastingTurns = null;
		this.CanBeDispersed = true;
	}

	// Token: 0x0600362D RID: 13869 RVA: 0x00167C48 File Offset: 0x00166048
	public void AddCount()
	{
		this.StackCount++;
		if (this.StackCount >= this.MaxStack)
		{
			this.StackCount = this.MaxStack;
		}
		Description description = this.BattleEffectType.GetDescription();
		description.Details1 = description.Details1.ReplaceToBuilder("{maxstack}", this.MaxStack.ToString()).Replace("{stack}", this.StackCount.ToString()).Replace("{healrate}", this.GetHealLifeRate().ToExpressionMultiply100()).ToString();
		base.Description = description;
	}

	// Token: 0x0600362E RID: 13870 RVA: 0x00167CF0 File Offset: 0x001660F0
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPreKilled
		};
	}

	// Token: 0x17000969 RID: 2409
	// (get) Token: 0x0600362F RID: 13871 RVA: 0x00167D0C File Offset: 0x0016610C
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x1700096A RID: 2410
	// (get) Token: 0x06003630 RID: 13872 RVA: 0x00167D14 File Offset: 0x00166114
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return BattleEffectType.FierySoul;
		}
	}

	// Token: 0x1700096B RID: 2411
	// (get) Token: 0x06003631 RID: 13873 RVA: 0x00167D18 File Offset: 0x00166118
	// (set) Token: 0x06003632 RID: 13874 RVA: 0x00167D20 File Offset: 0x00166120
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

	// Token: 0x06003633 RID: 13875 RVA: 0x00167D2C File Offset: 0x0016612C
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPreKilled && this.StackCount >= this.MaxStack && eventTriggerUnit == listener && data is BattleDamage && listener.HealthPoints <= 0.0)
		{
			this.StackCount = 0;
			BattleDamage damage = data as BattleDamage;
			double healRate = this.GetHealLifeRate();
			double heal = healRate * eventTriggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill) - eventTriggerUnit.HealthPoints;
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
			IEnumerator enumerator3 = listener.LooseSkillEffect(this, EffectWearsOffType.Consumed).GetEnumerator();
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

	// Token: 0x1700096C RID: 2412
	// (get) Token: 0x06003634 RID: 13876 RVA: 0x00167D6C File Offset: 0x0016616C
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x06003635 RID: 13877 RVA: 0x00167D74 File Offset: 0x00166174
	private double GetHealLifeRate()
	{
		return 0.25;
	}

	// Token: 0x1700096D RID: 2413
	// (get) Token: 0x06003636 RID: 13878 RVA: 0x00167D7F File Offset: 0x0016617F
	// (set) Token: 0x06003637 RID: 13879 RVA: 0x00167D87 File Offset: 0x00166187
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

	// Token: 0x06003638 RID: 13880 RVA: 0x00167D90 File Offset: 0x00166190
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x1700096E RID: 2414
	// (get) Token: 0x06003639 RID: 13881 RVA: 0x00167D97 File Offset: 0x00166197
	public override bool IsThroughEffect
	{
		get
		{
			return true;
		}
	}

	// Token: 0x1700096F RID: 2415
	// (get) Token: 0x0600363A RID: 13882 RVA: 0x00167D9A File Offset: 0x0016619A
	public override bool CanBeImmuned
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000970 RID: 2416
	// (get) Token: 0x0600363B RID: 13883 RVA: 0x00167D9D File Offset: 0x0016619D
	// (set) Token: 0x0600363C RID: 13884 RVA: 0x00167DA5 File Offset: 0x001661A5
	public sealed override bool CanBeDispersed
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

	// Token: 0x17000971 RID: 2417
	// (get) Token: 0x0600363D RID: 13885 RVA: 0x00167DAE File Offset: 0x001661AE
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(1);
		}
	}

	// Token: 0x17000972 RID: 2418
	// (get) Token: 0x0600363E RID: 13886 RVA: 0x00167DB6 File Offset: 0x001661B6
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Positive;
		}
	}

	// Token: 0x04002A23 RID: 10787
	private int StackCount;

	// Token: 0x04002A24 RID: 10788
	private int MaxStack;

	// Token: 0x04002A25 RID: 10789
	private string _effectSourceIdentityCode;

	// Token: 0x04002A26 RID: 10790
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002A27 RID: 10791
	private IBattleEffectSource _effectSource;

	// Token: 0x04002A28 RID: 10792
	private int? _numberOfLastingTurns;

	// Token: 0x04002A29 RID: 10793
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000EB7 RID: 3767
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005EE5 RID: 24293 RVA: 0x00167DB9 File Offset: 0x001661B9
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005EE6 RID: 24294 RVA: 0x00167DC4 File Offset: 0x001661C4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPreKilled || this.StackCount < this.MaxStack || eventTriggerUnit != listener || !(data is BattleDamage) || listener.HealthPoints > 0.0)
				{
					goto IL_332;
				}
				this.StackCount = 0;
				damage = (data as BattleDamage);
				healRate = base.GetHealLifeRate();
				heal = healRate * eventTriggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill) - eventTriggerUnit.HealthPoints;
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
				goto IL_20A;
			case 3u:
				goto IL_2AE;
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
				IL_20A:
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
			enumerator3 = listener.LooseSkillEffect(this, EffectWearsOffType.Consumed).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_2AE:
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
			IL_332:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013D4 RID: 5076
		// (get) Token: 0x06005EE7 RID: 24295 RVA: 0x00168138 File Offset: 0x00166538
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013D5 RID: 5077
		// (get) Token: 0x06005EE8 RID: 24296 RVA: 0x00168140 File Offset: 0x00166540
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005EE9 RID: 24297 RVA: 0x00168148 File Offset: 0x00166548
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

		// Token: 0x06005EEA RID: 24298 RVA: 0x00168238 File Offset: 0x00166638
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005EEB RID: 24299 RVA: 0x0016823F File Offset: 0x0016663F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005EEC RID: 24300 RVA: 0x00168248 File Offset: 0x00166648
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FireySoulEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new FireySoulEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040052F0 RID: 21232
		internal AdventureEventType eventType;

		// Token: 0x040052F1 RID: 21233
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040052F2 RID: 21234
		internal IBattleUnit listener;

		// Token: 0x040052F3 RID: 21235
		internal object data;

		// Token: 0x040052F4 RID: 21236
		internal BattleDamage <damage>__1;

		// Token: 0x040052F5 RID: 21237
		internal double <healRate>__1;

		// Token: 0x040052F6 RID: 21238
		internal double <heal>__1;

		// Token: 0x040052F7 RID: 21239
		internal ReleaseableHeal <releaseable>__1;

		// Token: 0x040052F8 RID: 21240
		internal IEnumerator $locvar0;

		// Token: 0x040052F9 RID: 21241
		internal object <_>__2;

		// Token: 0x040052FA RID: 21242
		internal IDisposable $locvar1;

		// Token: 0x040052FB RID: 21243
		internal IEnumerator $locvar2;

		// Token: 0x040052FC RID: 21244
		internal object <_>__3;

		// Token: 0x040052FD RID: 21245
		internal IDisposable $locvar3;

		// Token: 0x040052FE RID: 21246
		internal IEnumerator $locvar4;

		// Token: 0x040052FF RID: 21247
		internal object <_>__4;

		// Token: 0x04005300 RID: 21248
		internal IDisposable $locvar5;

		// Token: 0x04005301 RID: 21249
		internal FireySoulEffect $this;

		// Token: 0x04005302 RID: 21250
		internal object $current;

		// Token: 0x04005303 RID: 21251
		internal bool $disposing;

		// Token: 0x04005304 RID: 21252
		internal int $PC;
	}
}
