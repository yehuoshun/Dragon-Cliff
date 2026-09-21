using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;
using UnityEngine;

// Token: 0x02000746 RID: 1862
public class DamageNeutralizationEffect : BattleEffectBase
{
	// Token: 0x06003525 RID: 13605 RVA: 0x0016111C File Offset: 0x0015F51C
	public DamageNeutralizationEffect(int? numberOfLastingTurns, IBattleEffectSource effectSource, bool canbeDispersed = true)
	{
		this._effectSource = effectSource;
		this._effectSourceIdentityCode = "uniquedamageneutralshield";
		this._numberOfLastingTurns = numberOfLastingTurns;
		base.Description = this.BattleEffectType.GetDescription();
		this._canBeDispersed = canbeDispersed;
		base.TurnEventsCollected = new List<AdventureEventType>();
	}

	// Token: 0x06003526 RID: 13606 RVA: 0x00161180 File Offset: 0x0015F580
	public override List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		if (this.EffectSource is AdventureUnitSkill)
		{
			AdventureUnitSkill adventureUnitSkill = this.EffectSource as AdventureUnitSkill;
			if (adventureUnitSkill.Skill.SkillType == SkillType.ArmorOfWind && adventureUnitSkill.SourceUnit.SpecialEffects.OfType<ArmorOfWindAttributeEnhancementData>().Any<ArmorOfWindAttributeEnhancementData>())
			{
				return (from a in adventureUnitSkill.SourceUnit.SpecialEffects.OfType<ArmorOfWindAttributeEnhancementData>()
				select new AttributeModifier
				{
					AttributeType = a.Type,
					ModificationType = a.ModificationType,
					Value = a.Value,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}).ToList<AttributeModifier>();
			}
		}
		return new List<AttributeModifier>();
	}

	// Token: 0x06003527 RID: 13607 RVA: 0x00161218 File Offset: 0x0015F618
	public override List<AdventureEventType> CorrespondingEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitReceivesDamage_Single
		};
	}

	// Token: 0x170008CD RID: 2253
	// (get) Token: 0x06003528 RID: 13608 RVA: 0x00161234 File Offset: 0x0015F634
	public override string EffectSourceIdentityCode
	{
		get
		{
			return this._effectSourceIdentityCode;
		}
	}

	// Token: 0x170008CE RID: 2254
	// (get) Token: 0x06003529 RID: 13609 RVA: 0x0016123C File Offset: 0x0015F63C
	public sealed override BattleEffectType BattleEffectType
	{
		get
		{
			return this._battleEffectType;
		}
	}

	// Token: 0x170008CF RID: 2255
	// (get) Token: 0x0600352A RID: 13610 RVA: 0x00161244 File Offset: 0x0015F644
	// (set) Token: 0x0600352B RID: 13611 RVA: 0x0016124C File Offset: 0x0015F64C
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

	// Token: 0x170008D0 RID: 2256
	// (get) Token: 0x0600352C RID: 13612 RVA: 0x00161255 File Offset: 0x0015F655
	// (set) Token: 0x0600352D RID: 13613 RVA: 0x0016125D File Offset: 0x0015F65D
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

	// Token: 0x170008D1 RID: 2257
	// (get) Token: 0x0600352E RID: 13614 RVA: 0x00161266 File Offset: 0x0015F666
	public override bool IsThroughEffect
	{
		get
		{
			return this._isThroughEffect;
		}
	}

	// Token: 0x170008D2 RID: 2258
	// (get) Token: 0x0600352F RID: 13615 RVA: 0x0016126E File Offset: 0x0015F66E
	public override bool CanBeImmuned
	{
		get
		{
			return this._canBeImmuned;
		}
	}

	// Token: 0x170008D3 RID: 2259
	// (get) Token: 0x06003530 RID: 13616 RVA: 0x00161276 File Offset: 0x0015F676
	// (set) Token: 0x06003531 RID: 13617 RVA: 0x0016127E File Offset: 0x0015F67E
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

	// Token: 0x170008D4 RID: 2260
	// (get) Token: 0x06003532 RID: 13618 RVA: 0x00161287 File Offset: 0x0015F687
	public override int? MaxStackableInstances
	{
		get
		{
			return this._maxStackableInstances;
		}
	}

	// Token: 0x170008D5 RID: 2261
	// (get) Token: 0x06003533 RID: 13619 RVA: 0x0016128F File Offset: 0x0015F68F
	public override BattleEffectNature BattleEffectNatureForWearer
	{
		get
		{
			return this._battleEffectNatureForWearer;
		}
	}

	// Token: 0x06003534 RID: 13620 RVA: 0x00161298 File Offset: 0x0015F698
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReceivesDamage_Single && eventTriggerUnit == listener)
		{
			DamageComponent damage = data as DamageComponent;
			if (damage != null && !damage.HasFullyNeutralized())
			{
				foreach (DamageComponentPotion damageComponentPotion in damage.Potions)
				{
					damageComponentPotion.SetNeutralize(true);
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
				if (this.EffectSource.SourceUnit.GetUnitType() == UnitClass.ElementalWizard)
				{
					ElementalWizardStarHealShieldData star = this.EffectSource.SourceUnit.SpecialEffects.OfType<ElementalWizardStarHealShieldData>().FirstOrDefault<ElementalWizardStarHealShieldData>();
					if (star != null && (double)UnityEngine.Random.value <= star.Chance)
					{
						ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
						{
							new BattleHeal(listener, this.EffectSource, new List<HealComponentValue>
							{
								new HealComponentValue
								{
									IsDirectHeal = false,
									RawHeal = star.Rate * damage.GetTotalDamageSoFar_WithoutNeutralization(),
									HealType = OutputType.RealHeal
								}
							}, false)
						}, this.EffectSource.SourceUnit);
						IEnumerator enumerator4 = releaseableHeal.Release().GetEnumerator();
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
		}
		yield break;
	}

	// Token: 0x170008D6 RID: 2262
	// (get) Token: 0x06003535 RID: 13621 RVA: 0x001612D8 File Offset: 0x0015F6D8
	public override IBattleEffectSource EffectSource
	{
		get
		{
			return this._effectSource;
		}
	}

	// Token: 0x06003536 RID: 13622 RVA: 0x001612E0 File Offset: 0x0015F6E0
	[CompilerGenerated]
	private static AttributeModifier <GetAdditionalModifiers>m__0(ArmorOfWindAttributeEnhancementData a)
	{
		return new AttributeModifier
		{
			AttributeType = a.Type,
			ModificationType = a.ModificationType,
			Value = a.Value,
			Key = string.Empty,
			AttributeModifierType = AttributeModifierType.Skill
		};
	}

	// Token: 0x0400298A RID: 10634
	private string _effectSourceIdentityCode;

	// Token: 0x0400298B RID: 10635
	private BattleEffectType _battleEffectType = BattleEffectType.DamageNeutrualization;

	// Token: 0x0400298C RID: 10636
	private int? _numberOfLastingTurns;

	// Token: 0x0400298D RID: 10637
	private bool _isThroughEffect;

	// Token: 0x0400298E RID: 10638
	private bool _canBeImmuned;

	// Token: 0x0400298F RID: 10639
	private bool _canBeDispersed;

	// Token: 0x04002990 RID: 10640
	private int? _maxStackableInstances = new int?(15);

	// Token: 0x04002991 RID: 10641
	private BattleEffectNature _battleEffectNatureForWearer;

	// Token: 0x04002992 RID: 10642
	private float? _maxNumberOfLastingSeconds;

	// Token: 0x04002993 RID: 10643
	private IBattleEffectSource _effectSource;

	// Token: 0x04002994 RID: 10644
	[CompilerGenerated]
	private static Func<ArmorOfWindAttributeEnhancementData, AttributeModifier> <>f__am$cache0;

	// Token: 0x02000EA1 RID: 3745
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E5E RID: 24158 RVA: 0x0016132A File Offset: 0x0015F72A
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005E5F RID: 24159 RVA: 0x00161334 File Offset: 0x0015F734
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
					goto IL_397;
				}
				damage = (data as DamageComponent);
				if (damage == null || damage.HasFullyNeutralized())
				{
					goto IL_397;
				}
				enumerator = damage.Potions.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DamageComponentPotion damageComponentPotion = enumerator.Current;
						damageComponentPotion.SetNeutralize(true);
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
				goto IL_18B;
			case 3u:
				goto IL_315;
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
			enumerator3 = listener.LooseSkillEffect(this, EffectWearsOffType.Expiration).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_18B:
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
			if (this.EffectSource.SourceUnit.GetUnitType() != UnitClass.ElementalWizard)
			{
				goto IL_397;
			}
			star = this.EffectSource.SourceUnit.SpecialEffects.OfType<ElementalWizardStarHealShieldData>().FirstOrDefault<ElementalWizardStarHealShieldData>();
			if (star == null || (double)UnityEngine.Random.value > star.Chance)
			{
				goto IL_397;
			}
			releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(listener, this.EffectSource, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						IsDirectHeal = false,
						RawHeal = star.Rate * damage.GetTotalDamageSoFar_WithoutNeutralization(),
						HealType = OutputType.RealHeal
					}
				}, false)
			}, this.EffectSource.SourceUnit);
			enumerator4 = releaseableHeal.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_315:
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
			IL_397:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013B8 RID: 5048
		// (get) Token: 0x06005E60 RID: 24160 RVA: 0x00161718 File Offset: 0x0015FB18
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013B9 RID: 5049
		// (get) Token: 0x06005E61 RID: 24161 RVA: 0x00161720 File Offset: 0x0015FB20
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E62 RID: 24162 RVA: 0x00161728 File Offset: 0x0015FB28
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

		// Token: 0x06005E63 RID: 24163 RVA: 0x00161818 File Offset: 0x0015FC18
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E64 RID: 24164 RVA: 0x0016181F File Offset: 0x0015FC1F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E65 RID: 24165 RVA: 0x00161828 File Offset: 0x0015FC28
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DamageNeutralizationEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new DamageNeutralizationEffect.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.listener = listener;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040051EC RID: 20972
		internal AdventureEventType eventType;

		// Token: 0x040051ED RID: 20973
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040051EE RID: 20974
		internal IBattleUnit listener;

		// Token: 0x040051EF RID: 20975
		internal object data;

		// Token: 0x040051F0 RID: 20976
		internal DamageComponent <damage>__1;

		// Token: 0x040051F1 RID: 20977
		internal List<DamageComponentPotion>.Enumerator $locvar0;

		// Token: 0x040051F2 RID: 20978
		internal IEnumerator $locvar1;

		// Token: 0x040051F3 RID: 20979
		internal object <_>__2;

		// Token: 0x040051F4 RID: 20980
		internal IDisposable $locvar2;

		// Token: 0x040051F5 RID: 20981
		internal IEnumerator $locvar3;

		// Token: 0x040051F6 RID: 20982
		internal object <_>__3;

		// Token: 0x040051F7 RID: 20983
		internal IDisposable $locvar4;

		// Token: 0x040051F8 RID: 20984
		internal ElementalWizardStarHealShieldData <star>__4;

		// Token: 0x040051F9 RID: 20985
		internal ReleaseableHeal <releaseableHeal>__5;

		// Token: 0x040051FA RID: 20986
		internal IEnumerator $locvar5;

		// Token: 0x040051FB RID: 20987
		internal object <_>__6;

		// Token: 0x040051FC RID: 20988
		internal IDisposable $locvar6;

		// Token: 0x040051FD RID: 20989
		internal DamageNeutralizationEffect $this;

		// Token: 0x040051FE RID: 20990
		internal object $current;

		// Token: 0x040051FF RID: 20991
		internal bool $disposing;

		// Token: 0x04005200 RID: 20992
		internal int $PC;
	}
}
