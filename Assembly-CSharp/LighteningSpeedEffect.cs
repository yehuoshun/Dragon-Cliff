using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000762 RID: 1890
public class LighteningSpeedEffect : BattleEffectBase
{
	// Token: 0x060036E3 RID: 14051 RVA: 0x0016AE00 File Offset: 0x00169200
	public LighteningSpeedEffect(AdventureUnitSkill causingSkill, string sourceIdentityCode)
	{
		this._effectSourceIdentityCode = sourceIdentityCode;
		this._effectSource = causingSkill;
		base.TurnEventsCollected = new List<AdventureEventType>();
		base.Description = BattleEffectType.LighteningSpeed.GetDescription();
		this._numberOfLastingTurns = new int?(1);
		this.CanBeDispersed = false;
	}

	// Token: 0x060036E4 RID: 14052 RVA: 0x0016AE4C File Offset: 0x0016924C
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitEntersTurn && eventTriggerUnit == listener)
		{
			IEnumerator enumerator = listener.LooseSkillEffect(this, EffectWearsOffType.Expiration).GetEnumerator();
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
		if (eventType == AdventureEventType.UnitReceivesDamage_CompleteSet && eventTriggerUnit == listener)
		{
			BattleDamage damage = data as BattleDamage;
			if (damage.Dealer == this.EffectSource.SourceUnit)
			{
				List<BattleDamage> extraDamages = new List<BattleDamage>();
				foreach (DamageComponent damageComponent in damage.Damages)
				{
					if (damageComponent.IsDirectDamage)
					{
						double damagePercentage = LightningSpeed.GetDamagePercentage(((AdventureUnitSkill)this.EffectSource).Skill);
						extraDamages.Add(new BattleDamage(listener, this, new List<DamageComponentValue>
						{
							new DamageComponentValue(new List<DamagePotionValue>
							{
								new DamagePotionValue(this.EffectSource.SourceUnit, listener, OutputType.Lightening, damagePercentage)
							}, listener, this.EffectSource.SourceUnit, false, false)
						}));
					}
				}
				if (extraDamages.Any<BattleDamage>())
				{
					ReleaseableDamage extraRelease = new ReleaseableDamage(extraDamages, damage.Dealer);
					IEnumerator enumerator3 = this.Triggered(listener).GetEnumerator();
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
					IEnumerator enumerator4 = extraRelease.Release().GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x170009D9 RID: 2521
	// (get) Token: 0x060036E5 RID: 14053 RVA: 0x0016AE8C File Offset: 0x0016928C
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170009DA RID: 2522
	// (get) Token: 0x060036E6 RID: 14054 RVA: 0x0016AE94 File Offset: 0x00169294
	// (set) Token: 0x060036E7 RID: 14055 RVA: 0x0016AE9C File Offset: 0x0016929C
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

	// Token: 0x170009DB RID: 2523
	// (get) Token: 0x060036E8 RID: 14056 RVA: 0x0016AEA5 File Offset: 0x001692A5
	public List<AttributeModifier> AdditionalModifiers
	{
		get
		{
			return new List<AttributeModifier>();
		}
	}

	// Token: 0x170009DC RID: 2524
	// (get) Token: 0x060036E9 RID: 14057 RVA: 0x0016AEAC File Offset: 0x001692AC
	public override bool IsThroughEffect
	{
		get
		{
			return false;
		}
	}

	// Token: 0x170009DD RID: 2525
	// (get) Token: 0x060036EA RID: 14058 RVA: 0x0016AEAF File Offset: 0x001692AF
	public override bool CanBeImmuned
	{
		get
		{
			return true;
		}
	}

	// Token: 0x170009DE RID: 2526
	// (get) Token: 0x060036EB RID: 14059 RVA: 0x0016AEB2 File Offset: 0x001692B2
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(1);
		}
	}

	// Token: 0x170009DF RID: 2527
	// (get) Token: 0x060036EC RID: 14060 RVA: 0x0016AEBA File Offset: 0x001692BA
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Neutral;
		}
	}

	// Token: 0x060036ED RID: 14061 RVA: 0x0016AEBD File Offset: 0x001692BD
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return this.AdditionalModifiers;
	}

	// Token: 0x170009E0 RID: 2528
	// (get) Token: 0x060036EE RID: 14062 RVA: 0x0016AEC5 File Offset: 0x001692C5
	// (set) Token: 0x060036EF RID: 14063 RVA: 0x0016AECD File Offset: 0x001692CD
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

	// Token: 0x060036F0 RID: 14064 RVA: 0x0016AED8 File Offset: 0x001692D8
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitEntersTurn,
			AdventureEventType.UnitReceivesDamage_CompleteSet
		};
	}

	// Token: 0x170009E1 RID: 2529
	// (get) Token: 0x060036F1 RID: 14065 RVA: 0x0016AEFB File Offset: 0x001692FB
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170009E2 RID: 2530
	// (get) Token: 0x060036F2 RID: 14066 RVA: 0x0016AF03 File Offset: 0x00169303
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return BattleEffectType.LighteningSpeed;
		}
	}

	// Token: 0x170009E3 RID: 2531
	// (get) Token: 0x060036F3 RID: 14067 RVA: 0x0016AF07 File Offset: 0x00169307
	// (set) Token: 0x060036F4 RID: 14068 RVA: 0x0016AF0F File Offset: 0x0016930F
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

	// Token: 0x04002A98 RID: 10904
	private string _effectSourceIdentityCode;

	// Token: 0x04002A99 RID: 10905
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002A9A RID: 10906
	private IBattleEffectSource _effectSource;

	// Token: 0x04002A9B RID: 10907
	private int? _numberOfLastingTurns;

	// Token: 0x04002A9C RID: 10908
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000EBE RID: 3774
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005F21 RID: 24353 RVA: 0x0016AF18 File Offset: 0x00169318
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005F22 RID: 24354 RVA: 0x0016AF20 File Offset: 0x00169320
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitEntersTurn || eventTriggerUnit != listener)
				{
					goto IL_EA;
				}
				enumerator = listener.LooseSkillEffect(this, EffectWearsOffType.Expiration).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				Block_10:
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
				enumerator4 = extraRelease.Release().GetEnumerator();
				num = 4294967293u;
				goto Block_11;
			case 3u:
				goto IL_316;
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
			IL_EA:
			if (eventType != AdventureEventType.UnitReceivesDamage_CompleteSet || eventTriggerUnit != listener)
			{
				goto IL_398;
			}
			damage = (data as BattleDamage);
			if (damage.Dealer != this.EffectSource.SourceUnit)
			{
				goto IL_398;
			}
			extraDamages = new List<BattleDamage>();
			enumerator2 = damage.Damages.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					DamageComponent damageComponent = enumerator2.Current;
					if (damageComponent.IsDirectDamage)
					{
						double damagePercentage = LightningSpeed.GetDamagePercentage(((AdventureUnitSkill)this.EffectSource).Skill);
						extraDamages.Add(new BattleDamage(listener, this, new List<DamageComponentValue>
						{
							new DamageComponentValue(new List<DamagePotionValue>
							{
								new DamagePotionValue(this.EffectSource.SourceUnit, listener, OutputType.Lightening, damagePercentage)
							}, listener, this.EffectSource.SourceUnit, false, false)
						}));
					}
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			if (extraDamages.Any<BattleDamage>())
			{
				extraRelease = new ReleaseableDamage(extraDamages, damage.Dealer);
				enumerator3 = this.Triggered(listener).GetEnumerator();
				num = 4294967293u;
				goto Block_10;
			}
			goto IL_398;
			Block_11:
			try
			{
				IL_316:
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
			IL_398:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013E2 RID: 5090
		// (get) Token: 0x06005F23 RID: 24355 RVA: 0x0016B304 File Offset: 0x00169704
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013E3 RID: 5091
		// (get) Token: 0x06005F24 RID: 24356 RVA: 0x0016B30C File Offset: 0x0016970C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005F25 RID: 24357 RVA: 0x0016B314 File Offset: 0x00169714
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

		// Token: 0x06005F26 RID: 24358 RVA: 0x0016B404 File Offset: 0x00169804
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005F27 RID: 24359 RVA: 0x0016B40B File Offset: 0x0016980B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005F28 RID: 24360 RVA: 0x0016B414 File Offset: 0x00169814
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LighteningSpeedEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new LighteningSpeedEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x0400537A RID: 21370
		internal AdventureEventType eventType;

		// Token: 0x0400537B RID: 21371
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400537C RID: 21372
		internal IBattleUnit listener;

		// Token: 0x0400537D RID: 21373
		internal IEnumerator $locvar0;

		// Token: 0x0400537E RID: 21374
		internal object <_>__1;

		// Token: 0x0400537F RID: 21375
		internal IDisposable $locvar1;

		// Token: 0x04005380 RID: 21376
		internal object data;

		// Token: 0x04005381 RID: 21377
		internal BattleDamage <damage>__2;

		// Token: 0x04005382 RID: 21378
		internal List<BattleDamage> <extraDamages>__3;

		// Token: 0x04005383 RID: 21379
		internal List<DamageComponent>.Enumerator $locvar2;

		// Token: 0x04005384 RID: 21380
		internal ReleaseableDamage <extraRelease>__4;

		// Token: 0x04005385 RID: 21381
		internal IEnumerator $locvar3;

		// Token: 0x04005386 RID: 21382
		internal object <_>__5;

		// Token: 0x04005387 RID: 21383
		internal IDisposable $locvar4;

		// Token: 0x04005388 RID: 21384
		internal IEnumerator $locvar5;

		// Token: 0x04005389 RID: 21385
		internal object <_>__6;

		// Token: 0x0400538A RID: 21386
		internal IDisposable $locvar6;

		// Token: 0x0400538B RID: 21387
		internal LighteningSpeedEffect $this;

		// Token: 0x0400538C RID: 21388
		internal object $current;

		// Token: 0x0400538D RID: 21389
		internal bool $disposing;

		// Token: 0x0400538E RID: 21390
		internal int $PC;
	}
}
