using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000744 RID: 1860
public class DamageAbsorbShieldEffect : BattleEffectBase
{
	// Token: 0x06003502 RID: 13570 RVA: 0x001602CF File Offset: 0x0015E6CF
	private DamageAbsorbShieldEffect()
	{
	}

	// Token: 0x06003503 RID: 13571 RVA: 0x001602D8 File Offset: 0x0015E6D8
	public static IEnumerable AddAborbShieldToTarget(IBattleUnit target, IBattleEffectSource src, double value)
	{
		DamageAbsorbShieldEffect existing = target.BattleEffects.OfType<DamageAbsorbShieldEffect>().FirstOrDefault<DamageAbsorbShieldEffect>();
		double maxPossibleHeal = target.GetMaxLife(AttributeRetrievalLevel.Skill);
		if (target.IsPlayer)
		{
			IBattleUnit battleUnit = target.GetAllLiveFriendlyTargetsIncSelf(false).FirstOrDefault((IBattleUnit c) => c.GetUnitType() == UnitClass.ChubbyLady);
			if (battleUnit != null)
			{
				EnhancedChubbyLadyData enhancedChubbyLadyData = battleUnit.SpecialEffects.OfType<EnhancedChubbyLadyData>().FirstOrDefault<EnhancedChubbyLadyData>();
				if (enhancedChubbyLadyData != null)
				{
					maxPossibleHeal *= enhancedChubbyLadyData.ShieldBoost + 1.0;
				}
			}
		}
		if (existing != null)
		{
			existing._absorbDamageValue += value;
			if (existing._absorbDamageValue > maxPossibleHeal)
			{
				existing._absorbDamageValue = maxPossibleHeal;
			}
			existing.TurnEventsCollected = new List<AdventureEventType>();
			Description description2 = BattleEffectType.DamageAbsorbShield.GetDescription();
			description2.Details1 = description2.Details1.Replace("{value}", existing._absorbDamageValue.ToExpression());
			existing.Description = description2;
		}
		else
		{
			if (value > maxPossibleHeal)
			{
				value = maxPossibleHeal;
			}
			Description description = BattleEffectType.DamageAbsorbShield.GetDescription();
			description.Details1 = description.Details1.Replace("{value}", value.ToExpression());
			DamageAbsorbShieldEffect ef = new DamageAbsorbShieldEffect
			{
				_effectSource = src,
				_absorbDamageValue = value,
				_battleEffectNatureForWearer = BattleEffectNature.Positive,
				_battleEffectType = BattleEffectType.DamageAbsorbShield,
				_canBeDispersed = false,
				_canBeImmuned = false,
				_isThroughEffect = false,
				_effectSourceIdentityCode = "healshield",
				_maxStackableInstances = new int?(1),
				TurnEventsCollected = new List<AdventureEventType>(),
				Description = description,
				MaxNumberOfLastingSeconds = null,
				NumberOfLastingTurns = new int?(2)
			};
			IEnumerator enumerator = target.ApplySkillEffect(ef, false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06003504 RID: 13572 RVA: 0x00160310 File Offset: 0x0015E710
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReceivesDamage_Single && eventTriggerUnit == listener)
		{
			DamageComponent damage = data as DamageComponent;
			if (damage != null && !damage.HasFullyNeutralized())
			{
				foreach (DamageComponentPotion damageComponentPotion in damage.Potions)
				{
					if (this._absorbDamageValue > 0.0)
					{
						double finalDamageSoFar = damageComponentPotion.GetFinalDamageSoFar();
						double num = this._absorbDamageValue;
						if (num > finalDamageSoFar)
						{
							num = finalDamageSoFar;
						}
						damageComponentPotion.ReduceDamageValue(num);
						this._absorbDamageValue -= num;
					}
				}
				IEnumerator enumerator2 = this.Triggered(listener).GetEnumerator();
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
				if (this._absorbDamageValue <= 0.0)
				{
					IEnumerator enumerator3 = listener.LooseSkillEffect(this, EffectWearsOffType.Expiration).GetEnumerator();
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
				else
				{
					Description description = BattleEffectType.DamageAbsorbShield.GetDescription();
					description.Details1 = description.Details1.Replace("{value}", this._absorbDamageValue.ToExpression());
					base.Description = description;
				}
			}
		}
		yield break;
	}

	// Token: 0x06003505 RID: 13573 RVA: 0x00160350 File Offset: 0x0015E750
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitReceivesDamage_Single
		};
	}

	// Token: 0x170008B9 RID: 2233
	// (get) Token: 0x06003506 RID: 13574 RVA: 0x0016036C File Offset: 0x0015E76C
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170008BA RID: 2234
	// (get) Token: 0x06003507 RID: 13575 RVA: 0x00160374 File Offset: 0x0015E774
	public override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170008BB RID: 2235
	// (get) Token: 0x06003508 RID: 13576 RVA: 0x0016037C File Offset: 0x0015E77C
	// (set) Token: 0x06003509 RID: 13577 RVA: 0x00160384 File Offset: 0x0015E784
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

	// Token: 0x170008BC RID: 2236
	// (get) Token: 0x0600350A RID: 13578 RVA: 0x0016038D File Offset: 0x0015E78D
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x170008BD RID: 2237
	// (get) Token: 0x0600350B RID: 13579 RVA: 0x00160395 File Offset: 0x0015E795
	// (set) Token: 0x0600350C RID: 13580 RVA: 0x0016039D File Offset: 0x0015E79D
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

	// Token: 0x170008BE RID: 2238
	// (get) Token: 0x0600350D RID: 13581 RVA: 0x001603A6 File Offset: 0x0015E7A6
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170008BF RID: 2239
	// (get) Token: 0x0600350E RID: 13582 RVA: 0x001603AE File Offset: 0x0015E7AE
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170008C0 RID: 2240
	// (get) Token: 0x0600350F RID: 13583 RVA: 0x001603B6 File Offset: 0x0015E7B6
	// (set) Token: 0x06003510 RID: 13584 RVA: 0x001603BE File Offset: 0x0015E7BE
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

	// Token: 0x170008C1 RID: 2241
	// (get) Token: 0x06003511 RID: 13585 RVA: 0x001603C7 File Offset: 0x0015E7C7
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170008C2 RID: 2242
	// (get) Token: 0x06003512 RID: 13586 RVA: 0x001603CF File Offset: 0x0015E7CF
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x04002971 RID: 10609
	private string _effectSourceIdentityCode;

	// Token: 0x04002972 RID: 10610
	private BattleEffectType _battleEffectType;

	// Token: 0x04002973 RID: 10611
	private IBattleEffectSource _effectSource;

	// Token: 0x04002974 RID: 10612
	private bool _isThroughEffect;

	// Token: 0x04002975 RID: 10613
	private bool _canBeImmuned;

	// Token: 0x04002976 RID: 10614
	private bool _canBeDispersed;

	// Token: 0x04002977 RID: 10615
	private int? _maxStackableInstances;

	// Token: 0x04002978 RID: 10616
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002979 RID: 10617
	private double _absorbDamageValue;

	// Token: 0x0400297A RID: 10618
	private double? _maxValue;

	// Token: 0x0400297B RID: 10619
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float? <MaxNumberOfLastingSeconds>k__BackingField;

	// Token: 0x0400297C RID: 10620
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? <NumberOfLastingTurns>k__BackingField;

	// Token: 0x02000E9D RID: 3741
	[CompilerGenerated]
	private sealed class <AddAborbShieldToTarget>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E43 RID: 24131 RVA: 0x001603D7 File Offset: 0x0015E7D7
		[DebuggerHidden]
		public <AddAborbShieldToTarget>c__Iterator0()
		{
		}

		// Token: 0x06005E44 RID: 24132 RVA: 0x001603E0 File Offset: 0x0015E7E0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				existing = target.BattleEffects.OfType<DamageAbsorbShieldEffect>().FirstOrDefault<DamageAbsorbShieldEffect>();
				maxPossibleHeal = target.GetMaxLife(AttributeRetrievalLevel.Skill);
				if (target.IsPlayer)
				{
					IBattleUnit battleUnit = target.GetAllLiveFriendlyTargetsIncSelf(false).FirstOrDefault((IBattleUnit c) => c.GetUnitType() == UnitClass.ChubbyLady);
					if (battleUnit != null)
					{
						EnhancedChubbyLadyData enhancedChubbyLadyData = battleUnit.SpecialEffects.OfType<EnhancedChubbyLadyData>().FirstOrDefault<EnhancedChubbyLadyData>();
						if (enhancedChubbyLadyData != null)
						{
							maxPossibleHeal *= enhancedChubbyLadyData.ShieldBoost + 1.0;
						}
					}
				}
				if (existing != null)
				{
					existing._absorbDamageValue += value;
					if (existing._absorbDamageValue > maxPossibleHeal)
					{
						existing._absorbDamageValue = maxPossibleHeal;
					}
					existing.TurnEventsCollected = new List<AdventureEventType>();
					Description description2 = BattleEffectType.DamageAbsorbShield.GetDescription();
					description2.Details1 = description2.Details1.Replace("{value}", existing._absorbDamageValue.ToExpression());
					existing.Description = description2;
					goto IL_301;
				}
				if (value > maxPossibleHeal)
				{
					value = maxPossibleHeal;
				}
				description = BattleEffectType.DamageAbsorbShield.GetDescription();
				description.Details1 = description.Details1.Replace("{value}", value.ToExpression());
				ef = new DamageAbsorbShieldEffect
				{
					_effectSource = src,
					_absorbDamageValue = value,
					_battleEffectNatureForWearer = BattleEffectNature.Positive,
					_battleEffectType = BattleEffectType.DamageAbsorbShield,
					_canBeDispersed = false,
					_canBeImmuned = false,
					_isThroughEffect = false,
					_effectSourceIdentityCode = "healshield",
					_maxStackableInstances = new int?(1),
					TurnEventsCollected = new List<AdventureEventType>(),
					Description = description,
					MaxNumberOfLastingSeconds = null,
					NumberOfLastingTurns = new int?(2)
				};
				enumerator = target.ApplySkillEffect(ef, false).GetEnumerator();
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
			IL_301:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013B2 RID: 5042
		// (get) Token: 0x06005E45 RID: 24133 RVA: 0x00160708 File Offset: 0x0015EB08
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013B3 RID: 5043
		// (get) Token: 0x06005E46 RID: 24134 RVA: 0x00160710 File Offset: 0x0015EB10
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E47 RID: 24135 RVA: 0x00160718 File Offset: 0x0015EB18
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

		// Token: 0x06005E48 RID: 24136 RVA: 0x00160788 File Offset: 0x0015EB88
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E49 RID: 24137 RVA: 0x0016078F File Offset: 0x0015EB8F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E4A RID: 24138 RVA: 0x00160798 File Offset: 0x0015EB98
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageAbsorbShieldEffect.<AddAborbShieldToTarget>c__Iterator0 <AddAborbShieldToTarget>c__Iterator = new DamageAbsorbShieldEffect.<AddAborbShieldToTarget>c__Iterator0();
			<AddAborbShieldToTarget>c__Iterator.target = target;
			<AddAborbShieldToTarget>c__Iterator.value = value;
			<AddAborbShieldToTarget>c__Iterator.src = src;
			return <AddAborbShieldToTarget>c__Iterator;
		}

		// Token: 0x06005E4B RID: 24139 RVA: 0x001607E4 File Offset: 0x0015EBE4
		private static bool <>m__0(IBattleUnit c)
		{
			return c.GetUnitType() == UnitClass.ChubbyLady;
		}

		// Token: 0x040051BE RID: 20926
		internal IBattleUnit target;

		// Token: 0x040051BF RID: 20927
		internal DamageAbsorbShieldEffect <existing>__0;

		// Token: 0x040051C0 RID: 20928
		internal double <maxPossibleHeal>__0;

		// Token: 0x040051C1 RID: 20929
		internal double value;

		// Token: 0x040051C2 RID: 20930
		internal Description <description>__1;

		// Token: 0x040051C3 RID: 20931
		internal IBattleEffectSource src;

		// Token: 0x040051C4 RID: 20932
		internal DamageAbsorbShieldEffect <ef>__1;

		// Token: 0x040051C5 RID: 20933
		internal IEnumerator $locvar0;

		// Token: 0x040051C6 RID: 20934
		internal object <_>__2;

		// Token: 0x040051C7 RID: 20935
		internal IDisposable $locvar1;

		// Token: 0x040051C8 RID: 20936
		internal object $current;

		// Token: 0x040051C9 RID: 20937
		internal bool $disposing;

		// Token: 0x040051CA RID: 20938
		internal double <$>value;

		// Token: 0x040051CB RID: 20939
		internal int $PC;

		// Token: 0x040051CC RID: 20940
		private static Func<IBattleUnit, bool> <>f__am$cache0;
	}

	// Token: 0x02000E9E RID: 3742
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E4C RID: 24140 RVA: 0x001607F3 File Offset: 0x0015EBF3
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator1()
		{
		}

		// Token: 0x06005E4D RID: 24141 RVA: 0x001607FC File Offset: 0x0015EBFC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitReceivesDamage_Single || eventTriggerUnit != listener)
				{
					goto IL_2B6;
				}
				damage = (data as DamageComponent);
				if (damage == null || damage.HasFullyNeutralized())
				{
					goto IL_2B6;
				}
				enumerator = damage.Potions.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DamageComponentPotion damageComponentPotion = enumerator.Current;
						if (this._absorbDamageValue > 0.0)
						{
							double finalDamageSoFar = damageComponentPotion.GetFinalDamageSoFar();
							double num2 = this._absorbDamageValue;
							if (num2 > finalDamageSoFar)
							{
								num2 = finalDamageSoFar;
							}
							damageComponentPotion.ReduceDamageValue(num2);
							this._absorbDamageValue -= num2;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				enumerator2 = this.Triggered(listener).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_1EF;
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
			if (this._absorbDamageValue > 0.0)
			{
				Description description = BattleEffectType.DamageAbsorbShield.GetDescription();
				description.Details1 = description.Details1.Replace("{value}", this._absorbDamageValue.ToExpression());
				base.Description = description;
				goto IL_2B6;
			}
			enumerator3 = listener.LooseSkillEffect(this, EffectWearsOffType.Expiration).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_1EF:
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
			IL_2B6:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013B4 RID: 5044
		// (get) Token: 0x06005E4E RID: 24142 RVA: 0x00160AF4 File Offset: 0x0015EEF4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013B5 RID: 5045
		// (get) Token: 0x06005E4F RID: 24143 RVA: 0x00160AFC File Offset: 0x0015EEFC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E50 RID: 24144 RVA: 0x00160B04 File Offset: 0x0015EF04
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

		// Token: 0x06005E51 RID: 24145 RVA: 0x00160BB4 File Offset: 0x0015EFB4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E52 RID: 24146 RVA: 0x00160BBB File Offset: 0x0015EFBB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E53 RID: 24147 RVA: 0x00160BC4 File Offset: 0x0015EFC4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageAbsorbShieldEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator1 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new DamageAbsorbShieldEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator1();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040051CD RID: 20941
		internal AdventureEventType eventType;

		// Token: 0x040051CE RID: 20942
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040051CF RID: 20943
		internal IBattleUnit listener;

		// Token: 0x040051D0 RID: 20944
		internal object data;

		// Token: 0x040051D1 RID: 20945
		internal DamageComponent <damage>__1;

		// Token: 0x040051D2 RID: 20946
		internal List<DamageComponentPotion>.Enumerator $locvar0;

		// Token: 0x040051D3 RID: 20947
		internal IEnumerator $locvar1;

		// Token: 0x040051D4 RID: 20948
		internal object <_>__2;

		// Token: 0x040051D5 RID: 20949
		internal IDisposable $locvar2;

		// Token: 0x040051D6 RID: 20950
		internal IEnumerator $locvar3;

		// Token: 0x040051D7 RID: 20951
		internal object <_>__3;

		// Token: 0x040051D8 RID: 20952
		internal IDisposable $locvar4;

		// Token: 0x040051D9 RID: 20953
		internal DamageAbsorbShieldEffect $this;

		// Token: 0x040051DA RID: 20954
		internal object $current;

		// Token: 0x040051DB RID: 20955
		internal bool $disposing;

		// Token: 0x040051DC RID: 20956
		internal int $PC;
	}
}
