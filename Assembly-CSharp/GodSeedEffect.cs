using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200075A RID: 1882
public class GodSeedEffect : BattleEffectBase
{
	// Token: 0x0600367C RID: 13948 RVA: 0x00169110 File Offset: 0x00167510
	public GodSeedEffect(double healValue, IBattleEffectSource effectSource, string sourceIdentityCode)
	{
		this._effectSourceIdentityCode = sourceIdentityCode;
		this.HealValue = healValue;
		this._effectSource = effectSource;
		base.TurnEventsCollected = new List<AdventureEventType>();
		Description description = BattleEffectType.GodSeed.GetDescription();
		description.Details1 = description.Details1.Replace("{healvalue}", healValue.ToExpression());
		base.Description = description;
		this._numberOfLastingTurns = null;
		this._maxNumberOfLastingSeconds = new float?(6f);
		if (effectSource is AdventureUnitSkill && (effectSource as AdventureUnitSkill).GetActiveTalents().OfType<GodSeedStablizeTalent>().Any<GodSeedStablizeTalent>())
		{
			this.CanBeDispersed = false;
		}
		else
		{
			this.CanBeDispersed = true;
		}
	}

	// Token: 0x1700099B RID: 2459
	// (get) Token: 0x0600367D RID: 13949 RVA: 0x001691C5 File Offset: 0x001675C5
	// (set) Token: 0x0600367E RID: 13950 RVA: 0x001691CD File Offset: 0x001675CD
	public double HealValue
	{
		[CompilerGenerated]
		get
		{
			return this.<HealValue>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<HealValue>k__BackingField = value;
		}
	}

	// Token: 0x0600367F RID: 13951 RVA: 0x001691D8 File Offset: 0x001675D8
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPostReceivesDamage && eventTriggerUnit == listener)
		{
			BattleDamage damage = data as BattleDamage;
			List<HealComponentValue> heals = new List<HealComponentValue>();
			foreach (DamageComponent damageComponent in damage.Damages)
			{
				if (damageComponent.IsDirectDamage && !damageComponent.HasFullyNeutralized())
				{
					heals.Add(new HealComponentValue
					{
						RawHeal = this.HealValue,
						IsDirectHeal = false,
						HealType = OutputType.RealHeal
					});
				}
			}
			ReleaseableHeal releaseable = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(damage.Dealer, this.EffectSource, heals, false)
			}, this.EffectSource.SourceUnit);
			IEnumerator enumerator2 = this.Triggered(eventTriggerUnit).GetEnumerator();
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
			IEnumerator enumerator3 = releaseable.Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x1700099C RID: 2460
	// (get) Token: 0x06003680 RID: 13952 RVA: 0x00169218 File Offset: 0x00167618
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x1700099D RID: 2461
	// (get) Token: 0x06003681 RID: 13953 RVA: 0x00169220 File Offset: 0x00167620
	// (set) Token: 0x06003682 RID: 13954 RVA: 0x00169228 File Offset: 0x00167628
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

	// Token: 0x06003683 RID: 13955 RVA: 0x00169231 File Offset: 0x00167631
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x1700099E RID: 2462
	// (get) Token: 0x06003684 RID: 13956 RVA: 0x00169238 File Offset: 0x00167638
	public override bool IsThroughEffect
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700099F RID: 2463
	// (get) Token: 0x06003685 RID: 13957 RVA: 0x0016923B File Offset: 0x0016763B
	public override bool CanBeImmuned
	{
		get
		{
			return false;
		}
	}

	// Token: 0x170009A0 RID: 2464
	// (get) Token: 0x06003686 RID: 13958 RVA: 0x0016923E File Offset: 0x0016763E
	public override int? MaxStackableInstances
	{
		get
		{
			return new int?(1);
		}
	}

	// Token: 0x170009A1 RID: 2465
	// (get) Token: 0x06003687 RID: 13959 RVA: 0x00169246 File Offset: 0x00167646
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Negative;
		}
	}

	// Token: 0x170009A2 RID: 2466
	// (get) Token: 0x06003688 RID: 13960 RVA: 0x00169249 File Offset: 0x00167649
	// (set) Token: 0x06003689 RID: 13961 RVA: 0x00169251 File Offset: 0x00167651
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

	// Token: 0x0600368A RID: 13962 RVA: 0x0016925C File Offset: 0x0016765C
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage
		};
	}

	// Token: 0x170009A3 RID: 2467
	// (get) Token: 0x0600368B RID: 13963 RVA: 0x00169278 File Offset: 0x00167678
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170009A4 RID: 2468
	// (get) Token: 0x0600368C RID: 13964 RVA: 0x00169280 File Offset: 0x00167680
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return BattleEffectType.GodSeed;
		}
	}

	// Token: 0x170009A5 RID: 2469
	// (get) Token: 0x0600368D RID: 13965 RVA: 0x00169284 File Offset: 0x00167684
	// (set) Token: 0x0600368E RID: 13966 RVA: 0x0016928C File Offset: 0x0016768C
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

	// Token: 0x04002A55 RID: 10837
	private string _effectSourceIdentityCode;

	// Token: 0x04002A56 RID: 10838
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002A57 RID: 10839
	private IBattleEffectSource _effectSource;

	// Token: 0x04002A58 RID: 10840
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <HealValue>k__BackingField;

	// Token: 0x04002A59 RID: 10841
	private int? _numberOfLastingTurns;

	// Token: 0x04002A5A RID: 10842
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000EB9 RID: 3769
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005EF8 RID: 24312 RVA: 0x00169295 File Offset: 0x00167695
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005EF9 RID: 24313 RVA: 0x001692A0 File Offset: 0x001676A0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPostReceivesDamage || eventTriggerUnit != listener)
				{
					goto IL_284;
				}
				damage = (data as BattleDamage);
				heals = new List<HealComponentValue>();
				enumerator = damage.Damages.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DamageComponent damageComponent = enumerator.Current;
						if (damageComponent.IsDirectDamage && !damageComponent.HasFullyNeutralized())
						{
							heals.Add(new HealComponentValue
							{
								RawHeal = base.HealValue,
								IsDirectHeal = false,
								HealType = OutputType.RealHeal
							});
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				releaseable = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(damage.Dealer, this.EffectSource, heals, false)
				}, this.EffectSource.SourceUnit);
				enumerator2 = this.Triggered(eventTriggerUnit).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_200;
			default:
				return false;
			}
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
			enumerator3 = releaseable.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_200:
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
			IL_284:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013D8 RID: 5080
		// (get) Token: 0x06005EFA RID: 24314 RVA: 0x00169564 File Offset: 0x00167964
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013D9 RID: 5081
		// (get) Token: 0x06005EFB RID: 24315 RVA: 0x0016956C File Offset: 0x0016796C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005EFC RID: 24316 RVA: 0x00169574 File Offset: 0x00167974
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
			}
		}

		// Token: 0x06005EFD RID: 24317 RVA: 0x00169624 File Offset: 0x00167A24
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005EFE RID: 24318 RVA: 0x0016962B File Offset: 0x00167A2B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005EFF RID: 24319 RVA: 0x00169634 File Offset: 0x00167A34
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GodSeedEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new GodSeedEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x0400532A RID: 21290
		internal AdventureEventType eventType;

		// Token: 0x0400532B RID: 21291
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400532C RID: 21292
		internal IBattleUnit listener;

		// Token: 0x0400532D RID: 21293
		internal object data;

		// Token: 0x0400532E RID: 21294
		internal BattleDamage <damage>__1;

		// Token: 0x0400532F RID: 21295
		internal List<HealComponentValue> <heals>__1;

		// Token: 0x04005330 RID: 21296
		internal List<DamageComponent>.Enumerator $locvar0;

		// Token: 0x04005331 RID: 21297
		internal ReleaseableHeal <releaseable>__1;

		// Token: 0x04005332 RID: 21298
		internal IEnumerator $locvar1;

		// Token: 0x04005333 RID: 21299
		internal object <_>__2;

		// Token: 0x04005334 RID: 21300
		internal IDisposable $locvar2;

		// Token: 0x04005335 RID: 21301
		internal IEnumerator $locvar3;

		// Token: 0x04005336 RID: 21302
		internal object <_>__3;

		// Token: 0x04005337 RID: 21303
		internal IDisposable $locvar4;

		// Token: 0x04005338 RID: 21304
		internal GodSeedEffect $this;

		// Token: 0x04005339 RID: 21305
		internal object $current;

		// Token: 0x0400533A RID: 21306
		internal bool $disposing;

		// Token: 0x0400533B RID: 21307
		internal int $PC;
	}
}
