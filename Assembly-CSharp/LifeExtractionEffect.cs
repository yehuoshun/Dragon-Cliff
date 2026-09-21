using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000749 RID: 1865
public class LifeExtractionEffect : BattleEffectBase, IDamageInstantlyReleaseable, ISpreadableDamageOverTime
{
	// Token: 0x06003556 RID: 13654 RVA: 0x00164F98 File Offset: 0x00163398
	private LifeExtractionEffect()
	{
	}

	// Token: 0x170008E5 RID: 2277
	// (get) Token: 0x06003557 RID: 13655 RVA: 0x00164FA0 File Offset: 0x001633A0
	// (set) Token: 0x06003558 RID: 13656 RVA: 0x00164FA8 File Offset: 0x001633A8
	public IBattleUnit EffectCausedCaster
	{
		[CompilerGenerated]
		get
		{
			return this.<EffectCausedCaster>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<EffectCausedCaster>k__BackingField = value;
		}
	}

	// Token: 0x170008E6 RID: 2278
	// (get) Token: 0x06003559 RID: 13657 RVA: 0x00164FB1 File Offset: 0x001633B1
	// (set) Token: 0x0600355A RID: 13658 RVA: 0x00164FB9 File Offset: 0x001633B9
	public double DamageRawPerTick
	{
		[CompilerGenerated]
		get
		{
			return this.<DamageRawPerTick>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<DamageRawPerTick>k__BackingField = value;
		}
	}

	// Token: 0x170008E7 RID: 2279
	// (get) Token: 0x0600355B RID: 13659 RVA: 0x00164FC2 File Offset: 0x001633C2
	// (set) Token: 0x0600355C RID: 13660 RVA: 0x00164FCA File Offset: 0x001633CA
	public double HealPercentageOfDamagePerTick
	{
		[CompilerGenerated]
		get
		{
			return this.<HealPercentageOfDamagePerTick>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<HealPercentageOfDamagePerTick>k__BackingField = value;
		}
	}

	// Token: 0x0600355D RID: 13661 RVA: 0x00164FD4 File Offset: 0x001633D4
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitEntersTurn && eventTriggerUnit == this._effectCarrier && this._style == EffectOverTimeStyle.PerTurn && eventTriggerUnit.Status == BattleUnitStatus.Active)
		{
			ReleaseableDamage releaseable = new ReleaseableDamage(new List<BattleDamage>
			{
				new BattleDamage(this._effectCarrier, this, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						DamagePotionValue.CreateRawValuedDamageComponent(this._effectCarrier, this.EffectCausedCaster.SourceUnit, this._damageType, this.DamageRawPerTick)
					}, this._effectCarrier, this.EffectCausedCaster.SourceUnit, false, false)
				})
			}, this.EffectCausedCaster);
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
			double totalDamageValue = releaseable.BattleDamages.Sum((BattleDamage b) => b.Damages.Sum((DamageComponent d) => d.GetTotalDamageSoFar()));
			if (totalDamageValue > 0.0)
			{
				ReleaseableHeal heal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(this.EffectCausedCaster, this, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = this.HealPercentageOfDamagePerTick * totalDamageValue,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, false)
				}, this.EffectCausedCaster);
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
			}
			IEnumerator enumerator3 = this.Triggered(this.EffectCausedCaster).GetEnumerator();
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

	// Token: 0x170008E8 RID: 2280
	// (get) Token: 0x0600355E RID: 13662 RVA: 0x00165005 File Offset: 0x00163405
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x0600355F RID: 13663 RVA: 0x00165010 File Offset: 0x00163410
	public static LifeExtractionEffect CreateShadowProcEffect(IBattleEffectSource effectSource, double damagePerTick, double healRate, IBattleUnit effectCarrier, float numberOfSeconds, string code = "SHADOWPROC")
	{
		Description description = BattleEffectType.ShadowSpirit.GetDescription();
		description.Details1 = description.Details1.Replace("{turnspelldamageraw}", damagePerTick.ToExpression()).Replace("{turnhealraw}", healRate.ToExpressionMultiply100());
		return new LifeExtractionEffect
		{
			_effectSourceIdentityCode = code,
			_effectSource = effectSource,
			EffectCausedCaster = effectSource.SourceUnit,
			TurnEventsCollected = new List<AdventureEventType>(),
			_effectCarrier = effectCarrier,
			HealPercentageOfDamagePerTick = healRate,
			DamageRawPerTick = damagePerTick,
			_maxNumberOfLastingSeconds = new float?(numberOfSeconds),
			_damageType = OutputType.Shadow,
			_style = EffectOverTimeStyle.PerSecond,
			Description = description,
			_numberOfLastingTurns = null,
			_maxStackableInstances = new int?(3),
			_battleEffectType = BattleEffectType.ShadowSpirit,
			CanBeDispersed = true
		};
	}

	// Token: 0x170008E9 RID: 2281
	// (get) Token: 0x06003560 RID: 13664 RVA: 0x001650DF File Offset: 0x001634DF
	// (set) Token: 0x06003561 RID: 13665 RVA: 0x001650E7 File Offset: 0x001634E7
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

	// Token: 0x170008EA RID: 2282
	// (get) Token: 0x06003562 RID: 13666 RVA: 0x001650F0 File Offset: 0x001634F0
	public override bool IsThroughEffect
	{
		get
		{
			return false;
		}
	}

	// Token: 0x170008EB RID: 2283
	// (get) Token: 0x06003563 RID: 13667 RVA: 0x001650F3 File Offset: 0x001634F3
	public override bool CanBeImmuned
	{
		get
		{
			return true;
		}
	}

	// Token: 0x170008EC RID: 2284
	// (get) Token: 0x06003564 RID: 13668 RVA: 0x001650F6 File Offset: 0x001634F6
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170008ED RID: 2285
	// (get) Token: 0x06003565 RID: 13669 RVA: 0x001650FE File Offset: 0x001634FE
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return BattleEffectNature.Negative;
		}
	}

	// Token: 0x170008EE RID: 2286
	// (get) Token: 0x06003566 RID: 13670 RVA: 0x00165101 File Offset: 0x00163501
	// (set) Token: 0x06003567 RID: 13671 RVA: 0x00165109 File Offset: 0x00163509
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

	// Token: 0x06003568 RID: 13672 RVA: 0x00165114 File Offset: 0x00163514
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitEntersTurn
		};
	}

	// Token: 0x170008EF RID: 2287
	// (get) Token: 0x06003569 RID: 13673 RVA: 0x0016512F File Offset: 0x0016352F
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170008F0 RID: 2288
	// (get) Token: 0x0600356A RID: 13674 RVA: 0x00165137 File Offset: 0x00163537
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170008F1 RID: 2289
	// (get) Token: 0x0600356B RID: 13675 RVA: 0x0016513F File Offset: 0x0016353F
	// (set) Token: 0x0600356C RID: 13676 RVA: 0x00165147 File Offset: 0x00163547
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

	// Token: 0x0600356D RID: 13677 RVA: 0x00165150 File Offset: 0x00163550
	public double FilterDamageValue(double value, double maxRate)
	{
		double num = base.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill).Value * maxRate;
		if (value < num)
		{
			return value;
		}
		return num;
	}

	// Token: 0x0600356E RID: 13678 RVA: 0x0016517C File Offset: 0x0016357C
	public IEnumerable Spread(IBattleUnit fromUnit, List<IBattleUnit> tounits)
	{
		string code = "spreadedlifeextraction" + fromUnit.GetId();
		if (this._effectSourceIdentityCode != code)
		{
			foreach (IBattleUnit unit in tounits)
			{
				IBattleUnit unit2 = unit;
				LifeExtractionEffect lifeExtractionEffect = new LifeExtractionEffect();
				lifeExtractionEffect._effectSourceIdentityCode = code;
				lifeExtractionEffect._effectSource = this._effectSource;
				lifeExtractionEffect.EffectCausedCaster = this._effectSource.SourceUnit;
				lifeExtractionEffect.TurnEventsCollected = new List<AdventureEventType>();
				lifeExtractionEffect._effectCarrier = unit;
				lifeExtractionEffect.HealPercentageOfDamagePerTick = this.HealPercentageOfDamagePerTick;
				lifeExtractionEffect.DamageRawPerTick = this.DamageRawPerTick;
				LifeExtractionEffect lifeExtractionEffect2 = lifeExtractionEffect;
				int? num = (this._maxNumberOfLastingSeconds == null) ? null : new int?(3);
				lifeExtractionEffect2._maxNumberOfLastingSeconds = ((num == null) ? null : new float?((float)num.Value));
				lifeExtractionEffect._damageType = this._damageType;
				lifeExtractionEffect._style = this._style;
				lifeExtractionEffect.Description = base.Description;
				lifeExtractionEffect._numberOfLastingTurns = ((this._numberOfLastingTurns == null) ? null : new int?(2));
				lifeExtractionEffect._maxStackableInstances = new int?(1);
				lifeExtractionEffect._battleEffectType = this._battleEffectType;
				lifeExtractionEffect.CanBeDispersed = this.CanBeDispersed;
				IEnumerator enumerator2 = unit2.ApplySkillEffect(lifeExtractionEffect, false).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x170008F2 RID: 2290
	// (get) Token: 0x0600356F RID: 13679 RVA: 0x001651AD File Offset: 0x001635AD
	public OutputType? DamageOutputType
	{
		get
		{
			return new OutputType?(this._damageType);
		}
	}

	// Token: 0x040029AC RID: 10668
	private string _effectSourceIdentityCode;

	// Token: 0x040029AD RID: 10669
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x040029AE RID: 10670
	private IBattleEffectSource _effectSource;

	// Token: 0x040029AF RID: 10671
	public EffectOverTimeStyle _style;

	// Token: 0x040029B0 RID: 10672
	public OutputType _damageType;

	// Token: 0x040029B1 RID: 10673
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <EffectCausedCaster>k__BackingField;

	// Token: 0x040029B2 RID: 10674
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <DamageRawPerTick>k__BackingField;

	// Token: 0x040029B3 RID: 10675
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double <HealPercentageOfDamagePerTick>k__BackingField;

	// Token: 0x040029B4 RID: 10676
	public IBattleUnit _effectCarrier;

	// Token: 0x040029B5 RID: 10677
	private int? _numberOfLastingTurns;

	// Token: 0x040029B6 RID: 10678
	private int? _maxStackableInstances;

	// Token: 0x040029B7 RID: 10679
	private BattleEffectType _battleEffectType;

	// Token: 0x040029B8 RID: 10680
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <CanBeDispersed>k__BackingField;

	// Token: 0x02000EB0 RID: 3760
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005EA9 RID: 24233 RVA: 0x001651BA File Offset: 0x001635BA
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005EAA RID: 24234 RVA: 0x001651C4 File Offset: 0x001635C4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitEntersTurn || eventTriggerUnit != this._effectCarrier || this._style != EffectOverTimeStyle.PerTurn || eventTriggerUnit.Status != BattleUnitStatus.Active)
				{
					goto IL_3C5;
				}
				releaseable = new ReleaseableDamage(new List<BattleDamage>
				{
					new BattleDamage(this._effectCarrier, this, new List<DamageComponentValue>
					{
						new DamageComponentValue(new List<DamagePotionValue>
						{
							DamagePotionValue.CreateRawValuedDamageComponent(this._effectCarrier, base.EffectCausedCaster.SourceUnit, this._damageType, base.DamageRawPerTick)
						}, this._effectCarrier, base.EffectCausedCaster.SourceUnit, false, false)
					})
				}, base.EffectCausedCaster);
				enumerator = releaseable.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_299;
			case 3u:
				Block_10:
				try
				{
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
				goto IL_3C5;
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
			totalDamageValue = releaseable.BattleDamages.Sum((BattleDamage b) => b.Damages.Sum((DamageComponent d) => d.GetTotalDamageSoFar()));
			if (totalDamageValue <= 0.0)
			{
				goto IL_31D;
			}
			heal = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(base.EffectCausedCaster, this, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = base.HealPercentageOfDamagePerTick * totalDamageValue,
						IsDirectHeal = false,
						HealType = OutputType.RealHeal
					}
				}, false)
			}, base.EffectCausedCaster);
			enumerator2 = heal.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_299:
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
			IL_31D:
			enumerator3 = this.Triggered(base.EffectCausedCaster).GetEnumerator();
			num = 4294967293u;
			goto Block_10;
			IL_3C5:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013C6 RID: 5062
		// (get) Token: 0x06005EAB RID: 24235 RVA: 0x001655C8 File Offset: 0x001639C8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013C7 RID: 5063
		// (get) Token: 0x06005EAC RID: 24236 RVA: 0x001655D0 File Offset: 0x001639D0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005EAD RID: 24237 RVA: 0x001655D8 File Offset: 0x001639D8
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

		// Token: 0x06005EAE RID: 24238 RVA: 0x001656C8 File Offset: 0x00163AC8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005EAF RID: 24239 RVA: 0x001656CF File Offset: 0x00163ACF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005EB0 RID: 24240 RVA: 0x001656D8 File Offset: 0x00163AD8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LifeExtractionEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new LifeExtractionEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x06005EB1 RID: 24241 RVA: 0x00165724 File Offset: 0x00163B24
		private static double <>m__0(BattleDamage b)
		{
			return b.Damages.Sum((DamageComponent d) => d.GetTotalDamageSoFar());
		}

		// Token: 0x06005EB2 RID: 24242 RVA: 0x0016574E File Offset: 0x00163B4E
		private static double <>m__1(DamageComponent d)
		{
			return d.GetTotalDamageSoFar();
		}

		// Token: 0x04005290 RID: 21136
		internal AdventureEventType eventType;

		// Token: 0x04005291 RID: 21137
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04005292 RID: 21138
		internal ReleaseableDamage <releaseable>__1;

		// Token: 0x04005293 RID: 21139
		internal IEnumerator $locvar0;

		// Token: 0x04005294 RID: 21140
		internal object <_>__2;

		// Token: 0x04005295 RID: 21141
		internal IDisposable $locvar1;

		// Token: 0x04005296 RID: 21142
		internal double <totalDamageValue>__1;

		// Token: 0x04005297 RID: 21143
		internal ReleaseableHeal <heal>__3;

		// Token: 0x04005298 RID: 21144
		internal IEnumerator $locvar2;

		// Token: 0x04005299 RID: 21145
		internal object <_>__4;

		// Token: 0x0400529A RID: 21146
		internal IDisposable $locvar3;

		// Token: 0x0400529B RID: 21147
		internal IEnumerator $locvar4;

		// Token: 0x0400529C RID: 21148
		internal object <_>__5;

		// Token: 0x0400529D RID: 21149
		internal IDisposable $locvar5;

		// Token: 0x0400529E RID: 21150
		internal LifeExtractionEffect $this;

		// Token: 0x0400529F RID: 21151
		internal object $current;

		// Token: 0x040052A0 RID: 21152
		internal bool $disposing;

		// Token: 0x040052A1 RID: 21153
		internal int $PC;

		// Token: 0x040052A2 RID: 21154
		private static Func<BattleDamage, double> <>f__am$cache0;

		// Token: 0x040052A3 RID: 21155
		private static Func<DamageComponent, double> <>f__am$cache1;
	}

	// Token: 0x02000EB1 RID: 3761
	[CompilerGenerated]
	private sealed class <Spread>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005EB3 RID: 24243 RVA: 0x00165756 File Offset: 0x00163B56
		[DebuggerHidden]
		public <Spread>c__Iterator1()
		{
		}

		// Token: 0x06005EB4 RID: 24244 RVA: 0x00165760 File Offset: 0x00163B60
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				code = "spreadedlifeextraction" + fromUnit.GetId();
				if (!(this._effectSourceIdentityCode != code))
				{
					goto IL_2B4;
				}
				enumerator = tounits.GetEnumerator();
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
				case 1u:
					Block_8:
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
					break;
				}
				if (enumerator.MoveNext())
				{
					unit = enumerator.Current;
					IBattleUnit unit2 = unit;
					LifeExtractionEffect lifeExtractionEffect = new LifeExtractionEffect();
					lifeExtractionEffect._effectSourceIdentityCode = code;
					lifeExtractionEffect._effectSource = this._effectSource;
					lifeExtractionEffect.EffectCausedCaster = this._effectSource.SourceUnit;
					lifeExtractionEffect.TurnEventsCollected = new List<AdventureEventType>();
					lifeExtractionEffect._effectCarrier = unit;
					lifeExtractionEffect.HealPercentageOfDamagePerTick = base.HealPercentageOfDamagePerTick;
					lifeExtractionEffect.DamageRawPerTick = base.DamageRawPerTick;
					LifeExtractionEffect lifeExtractionEffect2 = lifeExtractionEffect;
					int? num2 = (this._maxNumberOfLastingSeconds == null) ? null : new int?(3);
					lifeExtractionEffect2._maxNumberOfLastingSeconds = ((num2 == null) ? null : new float?((float)num2.Value));
					lifeExtractionEffect._damageType = this._damageType;
					lifeExtractionEffect._style = this._style;
					lifeExtractionEffect.Description = base.Description;
					lifeExtractionEffect._numberOfLastingTurns = ((this._numberOfLastingTurns == null) ? null : new int?(2));
					lifeExtractionEffect._maxStackableInstances = new int?(1);
					lifeExtractionEffect._battleEffectType = this._battleEffectType;
					lifeExtractionEffect.CanBeDispersed = this.CanBeDispersed;
					enumerator2 = unit2.ApplySkillEffect(lifeExtractionEffect, false).GetEnumerator();
					num = 4294967293u;
					goto Block_8;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_2B4:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013C8 RID: 5064
		// (get) Token: 0x06005EB5 RID: 24245 RVA: 0x00165A60 File Offset: 0x00163E60
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013C9 RID: 5065
		// (get) Token: 0x06005EB6 RID: 24246 RVA: 0x00165A68 File Offset: 0x00163E68
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005EB7 RID: 24247 RVA: 0x00165A70 File Offset: 0x00163E70
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
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005EB8 RID: 24248 RVA: 0x00165B04 File Offset: 0x00163F04
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005EB9 RID: 24249 RVA: 0x00165B0B File Offset: 0x00163F0B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005EBA RID: 24250 RVA: 0x00165B14 File Offset: 0x00163F14
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LifeExtractionEffect.<Spread>c__Iterator1 <Spread>c__Iterator = new LifeExtractionEffect.<Spread>c__Iterator1();
			<Spread>c__Iterator.$this = this;
			<Spread>c__Iterator.fromUnit = fromUnit;
			<Spread>c__Iterator.tounits = tounits;
			return <Spread>c__Iterator;
		}

		// Token: 0x040052A4 RID: 21156
		internal IBattleUnit fromUnit;

		// Token: 0x040052A5 RID: 21157
		internal string <code>__0;

		// Token: 0x040052A6 RID: 21158
		internal List<IBattleUnit> tounits;

		// Token: 0x040052A7 RID: 21159
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x040052A8 RID: 21160
		internal IBattleUnit <unit>__1;

		// Token: 0x040052A9 RID: 21161
		internal IEnumerator $locvar1;

		// Token: 0x040052AA RID: 21162
		internal object <_>__2;

		// Token: 0x040052AB RID: 21163
		internal IDisposable $locvar2;

		// Token: 0x040052AC RID: 21164
		internal LifeExtractionEffect $this;

		// Token: 0x040052AD RID: 21165
		internal object $current;

		// Token: 0x040052AE RID: 21166
		internal bool $disposing;

		// Token: 0x040052AF RID: 21167
		internal int $PC;
	}
}
