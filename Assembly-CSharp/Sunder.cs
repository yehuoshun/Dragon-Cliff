using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006CF RID: 1743
public class Sunder : ActiveSkillLogicBase
{
	// Token: 0x06002F3E RID: 12094 RVA: 0x00142E58 File Offset: 0x00141258
	public Sunder()
	{
	}

	// Token: 0x06002F3F RID: 12095 RVA: 0x00142E7C File Offset: 0x0014127C
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new SunderDecayTalent(SkillType.Sunder, 1),
			new SunderTauntTalent(SkillType.Sunder, 2),
			new TacticTargetAttributeDebuffTalent(SkillType.Sunder, 3)
		};
	}

	// Token: 0x17000626 RID: 1574
	// (get) Token: 0x06002F40 RID: 12096 RVA: 0x00142EC3 File Offset: 0x001412C3
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x17000627 RID: 1575
	// (get) Token: 0x06002F41 RID: 12097 RVA: 0x00142ECB File Offset: 0x001412CB
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x17000628 RID: 1576
	// (get) Token: 0x06002F42 RID: 12098 RVA: 0x00142ED3 File Offset: 0x001412D3
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x17000629 RID: 1577
	// (get) Token: 0x06002F43 RID: 12099 RVA: 0x00142EDB File Offset: 0x001412DB
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002F44 RID: 12100 RVA: 0x00142EE3 File Offset: 0x001412E3
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<HostileAllStrategy>();
	}

	// Token: 0x06002F45 RID: 12101 RVA: 0x00142EEA File Offset: 0x001412EA
	public override double GetGaugeCost(Skill skill)
	{
		return 50.0;
	}

	// Token: 0x06002F46 RID: 12102 RVA: 0x00142EF5 File Offset: 0x001412F5
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002F47 RID: 12103 RVA: 0x00142F01 File Offset: 0x00141301
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new HostileAllStrategy(skill);
	}

	// Token: 0x06002F48 RID: 12104 RVA: 0x00142F09 File Offset: 0x00141309
	private double ActiveArmorReductionValue(Skill skill)
	{
		return 0.25;
	}

	// Token: 0x06002F49 RID: 12105 RVA: 0x00142F14 File Offset: 0x00141314
	private int ActiveNumberOfDispel(Skill skill)
	{
		return skill.Level;
	}

	// Token: 0x06002F4A RID: 12106 RVA: 0x00142F1C File Offset: 0x0014131C
	private double PassiveArmorReductionValue(Skill skill)
	{
		return 0.1;
	}

	// Token: 0x06002F4B RID: 12107 RVA: 0x00142F27 File Offset: 0x00141327
	private float ActiveLastingSeconds(Skill skill)
	{
		return 7f;
	}

	// Token: 0x06002F4C RID: 12108 RVA: 0x00142F2E File Offset: 0x0014132E
	private float PassiveLastingSeconds(Skill skill)
	{
		return 3f;
	}

	// Token: 0x06002F4D RID: 12109 RVA: 0x00142F38 File Offset: 0x00141338
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.ArmorDecreaseValueKey, this.ActiveArmorReductionValue(skill).ToExpressionMultiply100()).Replace(this.NumberOfActiveTriggers, this.ActiveNumberOfDispel(skill).ToString()).Replace(this.LastingSecondsKey, ((int)this.ActiveLastingSeconds(skill)).ToString()).ToString();
		description.Details2 = description.Details2.ReplaceToBuilder(this.ArmorDecreaseValueKey, this.PassiveArmorReductionValue(skill).ToExpressionMultiply100()).Replace(this.LastingSecondsKey, ((int)this.PassiveLastingSeconds(skill)).ToString()).ToString();
		return description;
	}

	// Token: 0x06002F4E RID: 12110 RVA: 0x00142FF8 File Offset: 0x001413F8
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		double value = this.ActiveArmorReductionValue(skill.Skill);
		SunderDepressionEnhancementData extraRateEnhancement = skill.SourceUnit.SpecialEffects.OfType<SunderDepressionEnhancementData>().FirstOrDefault<SunderDepressionEnhancementData>();
		if (extraRateEnhancement != null)
		{
			value = extraRateEnhancement.Rate;
		}
		SunderTauntEnhancementData tauntEnhancement = skill.SourceUnit.SpecialEffects.OfType<SunderTauntEnhancementData>().FirstOrDefault<SunderTauntEnhancementData>();
		foreach (IBattleUnit strategySelection in strategy.Selections)
		{
			List<BattleEffectBase> positiveEffects = (from ef in strategySelection.BattleEffects
			where ef.BattleEffectNatureForWearer == BattleEffectNature.Positive && ef.CanBeDispersed
			select ef).ToList<BattleEffectBase>();
			if (positiveEffects.Any<BattleEffectBase>())
			{
				positiveEffects.Shuffle<BattleEffectBase>();
				positiveEffects = positiveEffects.Take(this.ActiveNumberOfDispel(skill.Skill)).ToList<BattleEffectBase>();
				foreach (BattleEffectBase battleEffectBase in positiveEffects)
				{
					IEnumerator enumerator3 = strategySelection.DisperseEffect(battleEffectBase, skill.SourceUnit).GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							object _ = enumerator3.Current;
							yield return _;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator3 as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
			IEnumerator enumerator4 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateShieldBurnEffect(skill, base.GetType().FullName + "active", null, new float?(this.ActiveLastingSeconds(skill.Skill)), (from r in UnitExtensions.GetAllResistances()
			select new AttributeModifier
			{
				AttributeType = r,
				ModificationType = ModificationType.Multiplication,
				Value = -value,
				Key = string.Empty,
				AttributeModifierType = AttributeModifierType.Skill
			}).ToList<AttributeModifier>()), false).GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					object _2 = enumerator4.Current;
					yield return _2;
				}
			}
			finally
			{
				IDisposable disposable2;
				if ((disposable2 = (enumerator4 as IDisposable)) != null)
				{
					disposable2.Dispose();
				}
			}
			if (tauntEnhancement != null && (double)UnityEngine.Random.value <= tauntEnhancement.Chance)
			{
				IEnumerator enumerator5 = strategySelection.ApplySkillEffect(new TauntEffect(skill.SourceUnit, strategySelection, skill, new int?(tauntEnhancement.Seconds), true), false).GetEnumerator();
				try
				{
					while (enumerator5.MoveNext())
					{
						object _3 = enumerator5.Current;
						yield return _3;
					}
				}
				finally
				{
					IDisposable disposable3;
					if ((disposable3 = (enumerator5 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06002F4F RID: 12111 RVA: 0x0014302C File Offset: 0x0014142C
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitReceivesDamage_Single
		};
	}

	// Token: 0x06002F50 RID: 12112 RVA: 0x00143048 File Offset: 0x00141448
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReceivesDamage_Single)
		{
			DamageComponent damage = data as DamageComponent;
			if (damage != null && !damage.IsMissed && damage.Dealer == processingSkill.SourceUnit && damage.IsDirectDamage)
			{
				double value = this.PassiveArmorReductionValue(processingSkill.Skill);
				IEnumerator enumerator = damage.Target.ApplySkillEffect(AttributeModificationEffect.CreateShieldBurnEffect(processingSkill, base.GetType().FullName + "passive", null, new float?(this.PassiveLastingSeconds(processingSkill.Skill)), (from r in UnitExtensions.GetAllResistances()
				select new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = -value,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}).ToList<AttributeModifier>()), false).GetEnumerator();
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

	// Token: 0x0400273E RID: 10046
	private SkillCategory _skillCategory = SkillCategory.Supportive;

	// Token: 0x0400273F RID: 10047
	private OutputType _skillOutputType;

	// Token: 0x04002740 RID: 10048
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x04002741 RID: 10049
	private SkillType _skillType = SkillType.Sunder;

	// Token: 0x02000E37 RID: 3639
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B94 RID: 23444 RVA: 0x00143082 File Offset: 0x00141482
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005B95 RID: 23445 RVA: 0x0014308C File Offset: 0x0014148C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				double value = base.ActiveArmorReductionValue(skill.Skill);
				extraRateEnhancement = skill.SourceUnit.SpecialEffects.OfType<SunderDepressionEnhancementData>().FirstOrDefault<SunderDepressionEnhancementData>();
				if (extraRateEnhancement != null)
				{
					value = extraRateEnhancement.Rate;
				}
				tauntEnhancement = skill.SourceUnit.SpecialEffects.OfType<SunderTauntEnhancementData>().FirstOrDefault<SunderTauntEnhancementData>();
				enumerator = strategy.Selections.GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
			case 2u:
			case 3u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_7:
					try
					{
						switch (num)
						{
						case 1u:
							Block_14:
							try
							{
								switch (num)
								{
								}
								if (enumerator3.MoveNext())
								{
									_ = enumerator3.Current;
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
									if ((disposable = (enumerator3 as IDisposable)) != null)
									{
										disposable.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator2.MoveNext())
						{
							battleEffectBase = enumerator2.Current;
							enumerator3 = strategySelection.DisperseEffect(battleEffectBase, skill.SourceUnit).GetEnumerator();
							num = 4294967293u;
							goto Block_14;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator2).Dispose();
						}
					}
					break;
				case 2u:
					Block_8:
					try
					{
						switch (num)
						{
						}
						if (enumerator4.MoveNext())
						{
							_2 = enumerator4.Current;
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
							if ((disposable2 = (enumerator4 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					if (tauntEnhancement != null && (double)UnityEngine.Random.value <= tauntEnhancement.Chance)
					{
						enumerator5 = strategySelection.ApplySkillEffect(new TauntEffect(skill.SourceUnit, strategySelection, skill, new int?(tauntEnhancement.Seconds), true), false).GetEnumerator();
						num = 4294967293u;
						goto Block_11;
					}
					goto IL_482;
				case 3u:
					goto IL_400;
				default:
					goto IL_482;
				}
				IL_293:
				enumerator4 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateShieldBurnEffect(skill, base.GetType().FullName + "active", null, new float?(base.ActiveLastingSeconds(skill.Skill)), (from r in UnitExtensions.GetAllResistances()
				select new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = -<CastSkillLogic>c__AnonStorey.value,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}).ToList<AttributeModifier>()), false).GetEnumerator();
				num = 4294967293u;
				goto Block_8;
				Block_11:
				try
				{
					IL_400:
					switch (num)
					{
					}
					if (enumerator5.MoveNext())
					{
						_3 = enumerator5.Current;
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
						if ((disposable3 = (enumerator5 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				IL_482:
				if (enumerator.MoveNext())
				{
					strategySelection = enumerator.Current;
					positiveEffects = (from ef in strategySelection.BattleEffects
					where ef.BattleEffectNatureForWearer == BattleEffectNature.Positive && ef.CanBeDispersed
					select ef).ToList<BattleEffectBase>();
					if (positiveEffects.Any<BattleEffectBase>())
					{
						positiveEffects.Shuffle<BattleEffectBase>();
						positiveEffects = positiveEffects.Take(base.ActiveNumberOfDispel(skill.Skill)).ToList<BattleEffectBase>();
						enumerator2 = positiveEffects.GetEnumerator();
						num = 4294967293u;
						goto Block_7;
					}
					goto IL_293;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700131E RID: 4894
		// (get) Token: 0x06005B96 RID: 23446 RVA: 0x001435CC File Offset: 0x001419CC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700131F RID: 4895
		// (get) Token: 0x06005B97 RID: 23447 RVA: 0x001435D4 File Offset: 0x001419D4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B98 RID: 23448 RVA: 0x001435DC File Offset: 0x001419DC
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
			case 2u:
			case 3u:
				try
				{
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
								if ((disposable = (enumerator3 as IDisposable)) != null)
								{
									disposable.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2).Dispose();
						}
						break;
					case 2u:
						try
						{
						}
						finally
						{
							if ((disposable2 = (enumerator4 as IDisposable)) != null)
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
							if ((disposable3 = (enumerator5 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06005B99 RID: 23449 RVA: 0x00143728 File Offset: 0x00141B28
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B9A RID: 23450 RVA: 0x0014372F File Offset: 0x00141B2F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B9B RID: 23451 RVA: 0x00143738 File Offset: 0x00141B38
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Sunder.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new Sunder.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x06005B9C RID: 23452 RVA: 0x00143784 File Offset: 0x00141B84
		private static bool <>m__0(BattleEffectBase ef)
		{
			return ef.BattleEffectNatureForWearer == BattleEffectNature.Positive && ef.CanBeDispersed;
		}

		// Token: 0x04004D80 RID: 19840
		internal AdventureUnitSkill skill;

		// Token: 0x04004D81 RID: 19841
		internal SunderDepressionEnhancementData <extraRateEnhancement>__0;

		// Token: 0x04004D82 RID: 19842
		internal SunderTauntEnhancementData <tauntEnhancement>__0;

		// Token: 0x04004D83 RID: 19843
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004D84 RID: 19844
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004D85 RID: 19845
		internal IBattleUnit <strategySelection>__1;

		// Token: 0x04004D86 RID: 19846
		internal List<BattleEffectBase> <positiveEffects>__2;

		// Token: 0x04004D87 RID: 19847
		internal List<BattleEffectBase>.Enumerator $locvar1;

		// Token: 0x04004D88 RID: 19848
		internal BattleEffectBase <battleEffectBase>__3;

		// Token: 0x04004D89 RID: 19849
		internal IEnumerator $locvar2;

		// Token: 0x04004D8A RID: 19850
		internal object <_>__4;

		// Token: 0x04004D8B RID: 19851
		internal IDisposable $locvar3;

		// Token: 0x04004D8C RID: 19852
		internal IEnumerator $locvar4;

		// Token: 0x04004D8D RID: 19853
		internal object <_>__5;

		// Token: 0x04004D8E RID: 19854
		internal IDisposable $locvar5;

		// Token: 0x04004D8F RID: 19855
		internal IEnumerator $locvar6;

		// Token: 0x04004D90 RID: 19856
		internal object <_>__6;

		// Token: 0x04004D91 RID: 19857
		internal IDisposable $locvar7;

		// Token: 0x04004D92 RID: 19858
		internal Sunder $this;

		// Token: 0x04004D93 RID: 19859
		internal object $current;

		// Token: 0x04004D94 RID: 19860
		internal bool $disposing;

		// Token: 0x04004D95 RID: 19861
		internal int $PC;

		// Token: 0x04004D96 RID: 19862
		private Sunder.<CastSkillLogic>c__Iterator0.<CastSkillLogic>c__AnonStorey2 $locvar8;

		// Token: 0x04004D97 RID: 19863
		private static Func<BattleEffectBase, bool> <>f__am$cache0;

		// Token: 0x02000E39 RID: 3641
		private sealed class <CastSkillLogic>c__AnonStorey2
		{
			// Token: 0x06005BA5 RID: 23461 RVA: 0x0014379A File Offset: 0x00141B9A
			public <CastSkillLogic>c__AnonStorey2()
			{
			}

			// Token: 0x06005BA6 RID: 23462 RVA: 0x001437A4 File Offset: 0x00141BA4
			internal AttributeModifier <>m__0(AttributeType r)
			{
				return new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = -this.value,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				};
			}

			// Token: 0x04004DA4 RID: 19876
			internal double value;

			// Token: 0x04004DA5 RID: 19877
			internal Sunder.<CastSkillLogic>c__Iterator0 <>f__ref$0;
		}
	}

	// Token: 0x02000E38 RID: 3640
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B9D RID: 23453 RVA: 0x001437E5 File Offset: 0x00141BE5
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator1()
		{
		}

		// Token: 0x06005B9E RID: 23454 RVA: 0x001437F0 File Offset: 0x00141BF0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				if (eventType != AdventureEventType.UnitReceivesDamage_Single)
				{
					goto IL_1C9;
				}
				damage = (data as DamageComponent);
				if (damage == null || damage.IsMissed || damage.Dealer != processingSkill.SourceUnit || !damage.IsDirectDamage)
				{
					goto IL_1C9;
				}
				double value = base.PassiveArmorReductionValue(processingSkill.Skill);
				enumerator = damage.Target.ApplySkillEffect(AttributeModificationEffect.CreateShieldBurnEffect(processingSkill, base.GetType().FullName + "passive", null, new float?(base.PassiveLastingSeconds(processingSkill.Skill)), (from r in UnitExtensions.GetAllResistances()
				select new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = -value,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}).ToList<AttributeModifier>()), false).GetEnumerator();
				num = 4294967293u;
				break;
			}
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
			IL_1C9:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001320 RID: 4896
		// (get) Token: 0x06005B9F RID: 23455 RVA: 0x001439E0 File Offset: 0x00141DE0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001321 RID: 4897
		// (get) Token: 0x06005BA0 RID: 23456 RVA: 0x001439E8 File Offset: 0x00141DE8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005BA1 RID: 23457 RVA: 0x001439F0 File Offset: 0x00141DF0
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

		// Token: 0x06005BA2 RID: 23458 RVA: 0x00143A60 File Offset: 0x00141E60
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005BA3 RID: 23459 RVA: 0x00143A67 File Offset: 0x00141E67
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005BA4 RID: 23460 RVA: 0x00143A70 File Offset: 0x00141E70
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Sunder.<PassiveBeingActiveEventProcess>c__Iterator1 <PassiveBeingActiveEventProcess>c__Iterator = new Sunder.<PassiveBeingActiveEventProcess>c__Iterator1();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.data = data;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x04004D98 RID: 19864
		internal AdventureEventType eventType;

		// Token: 0x04004D99 RID: 19865
		internal object data;

		// Token: 0x04004D9A RID: 19866
		internal DamageComponent <damage>__1;

		// Token: 0x04004D9B RID: 19867
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004D9C RID: 19868
		internal IEnumerator $locvar0;

		// Token: 0x04004D9D RID: 19869
		internal object <_>__3;

		// Token: 0x04004D9E RID: 19870
		internal IDisposable $locvar1;

		// Token: 0x04004D9F RID: 19871
		internal Sunder $this;

		// Token: 0x04004DA0 RID: 19872
		internal object $current;

		// Token: 0x04004DA1 RID: 19873
		internal bool $disposing;

		// Token: 0x04004DA2 RID: 19874
		internal int $PC;

		// Token: 0x04004DA3 RID: 19875
		private Sunder.<PassiveBeingActiveEventProcess>c__Iterator1.<PassiveBeingActiveEventProcess>c__AnonStorey3 $locvar2;

		// Token: 0x02000E3A RID: 3642
		private sealed class <PassiveBeingActiveEventProcess>c__AnonStorey3
		{
			// Token: 0x06005BA7 RID: 23463 RVA: 0x00143AC8 File Offset: 0x00141EC8
			public <PassiveBeingActiveEventProcess>c__AnonStorey3()
			{
			}

			// Token: 0x06005BA8 RID: 23464 RVA: 0x00143AD0 File Offset: 0x00141ED0
			internal AttributeModifier <>m__0(AttributeType r)
			{
				return new AttributeModifier
				{
					AttributeType = r,
					ModificationType = ModificationType.Multiplication,
					Value = -this.value,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				};
			}

			// Token: 0x04004DA6 RID: 19878
			internal double value;

			// Token: 0x04004DA7 RID: 19879
			internal Sunder.<PassiveBeingActiveEventProcess>c__Iterator1 <>f__ref$1;
		}
	}
}
