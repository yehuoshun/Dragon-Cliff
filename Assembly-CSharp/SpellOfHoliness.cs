using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006CC RID: 1740
public class SpellOfHoliness : ActiveSkillLogicBase
{
	// Token: 0x06002F09 RID: 12041 RVA: 0x0013F7F4 File Offset: 0x0013DBF4
	public SpellOfHoliness()
	{
	}

	// Token: 0x06002F0A RID: 12042 RVA: 0x0013F818 File Offset: 0x0013DC18
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new TargetSelectionBuffTalent(SkillType.SpellOfHoliness, 1),
			new SpellOfHolinessDispelHealTalent(SkillType.SpellOfHoliness, 2),
			new SpellOfHolinessDamageTalent(SkillType.SpellOfHoliness, 3)
		};
	}

	// Token: 0x1700061A RID: 1562
	// (get) Token: 0x06002F0B RID: 12043 RVA: 0x0013F85F File Offset: 0x0013DC5F
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x1700061B RID: 1563
	// (get) Token: 0x06002F0C RID: 12044 RVA: 0x0013F867 File Offset: 0x0013DC67
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x1700061C RID: 1564
	// (get) Token: 0x06002F0D RID: 12045 RVA: 0x0013F86F File Offset: 0x0013DC6F
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x1700061D RID: 1565
	// (get) Token: 0x06002F0E RID: 12046 RVA: 0x0013F877 File Offset: 0x0013DC77
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002F0F RID: 12047 RVA: 0x0013F880 File Offset: 0x0013DC80
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		SpellOfHolinessDamageData spellOfHolinessDamageData = profile.GetSpecialEffects().OfType<SpellOfHolinessDamageData>().FirstOrDefault<SpellOfHolinessDamageData>();
		if (spellOfHolinessDamageData != null)
		{
			return ActiveSkillLogicBase.IsSelfResolvable<HostileAllStrategy>();
		}
		return ActiveSkillLogicBase.IsSelfResolvable<FriendlyAllStrategy>();
	}

	// Token: 0x06002F10 RID: 12048 RVA: 0x0013F8AF File Offset: 0x0013DCAF
	public override double GetGaugeCost(Skill skill)
	{
		return 45.0;
	}

	// Token: 0x06002F11 RID: 12049 RVA: 0x0013F8BA File Offset: 0x0013DCBA
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002F12 RID: 12050 RVA: 0x0013F8C6 File Offset: 0x0013DCC6
	private double GetPassiveCleaningChance(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.4;
	}

	// Token: 0x06002F13 RID: 12051 RVA: 0x0013F8E5 File Offset: 0x0013DCE5
	private int NumberOfPassiveCleanings(Skill skill)
	{
		return 2;
	}

	// Token: 0x06002F14 RID: 12052 RVA: 0x0013F8E8 File Offset: 0x0013DCE8
	public int? NumberOfActiveCleanings(Skill skill)
	{
		if (skill.Level == 1)
		{
			return new int?(2);
		}
		if (skill.Level == 2)
		{
			return new int?(5);
		}
		return new int?(8);
	}

	// Token: 0x06002F15 RID: 12053 RVA: 0x0013F918 File Offset: 0x0013DD18
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		SpellOfHolinessDamageData spellOfHolinessDamageData = skill.SourceUnit.SpecialEffects.OfType<SpellOfHolinessDamageData>().FirstOrDefault<SpellOfHolinessDamageData>();
		if (spellOfHolinessDamageData != null)
		{
			return new HostileAllStrategy(skill);
		}
		return new FriendlyAllStrategy(skill);
	}

	// Token: 0x06002F16 RID: 12054 RVA: 0x0013F950 File Offset: 0x0013DD50
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.NumberOfActiveTriggers, this.NumberOfActiveCleanings(skill).GetValueOrDefault().ToString());
		description.Details2 = description.Details2.ReplaceToBuilder(this.PossibilityKey, this.GetPassiveCleaningChance(skill).ToExpressionMultiply100()).Replace(this.NumberOfPassiveTriggersKey, this.NumberOfPassiveCleanings(skill).ToString()).ToString();
		return description;
	}

	// Token: 0x06002F17 RID: 12055 RVA: 0x0013F9DC File Offset: 0x0013DDDC
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitRegularTurnStarts
		};
	}

	// Token: 0x06002F18 RID: 12056 RVA: 0x0013F9F8 File Offset: 0x0013DDF8
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitRegularTurnStarts && eventTriggerUnit == skillOwner)
		{
			BattleEncounter battleEncounter = skillOwner.CurrentEncounter as BattleEncounter;
			if (battleEncounter != null)
			{
				List<IBattleUnit> friendlyUnits = (from u in skillOwner.GetAllLiveFriendlyTargetsIncSelf(true)
				where u.Status == BattleUnitStatus.Active
				select u).ToList<IBattleUnit>();
				if (friendlyUnits.Any<IBattleUnit>() && (double)UnityEngine.Random.value <= this.GetPassiveCleaningChance(processingSkill.Skill))
				{
					IBattleUnit selectedUnit = friendlyUnits[UnityEngine.Random.Range(0, friendlyUnits.Count)];
					List<BattleEffectBase> tobeRemoved = selectedUnit.BattleEffects.GetHarmfulEffects().GetDesperseableEffects().Take(this.NumberOfPassiveCleanings(processingSkill.Skill)).ToList<BattleEffectBase>();
					foreach (BattleEffectBase battleEffectBase in tobeRemoved)
					{
						IEnumerator enumerator2 = selectedUnit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
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
			}
		}
		yield break;
	}

	// Token: 0x06002F19 RID: 12057 RVA: 0x0013FA38 File Offset: 0x0013DE38
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		SpellOfHolinessDamageData damageEnhance = skill.SourceUnit.SpecialEffects.OfType<SpellOfHolinessDamageData>().FirstOrDefault<SpellOfHolinessDamageData>();
		if (damageEnhance != null)
		{
			ReleaseableDamage releaseable = new ReleaseableDamage((from s in strategy.Selections
			select new BattleDamage(s, skill, new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(skill.SourceUnit, s, skill.SourceUnit.GetOutputType(), damageEnhance.DamageRate)
				}, s, skill.SourceUnit, true, false)
			})).ToList<BattleDamage>(), skill.SourceUnit);
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
			foreach (IBattleUnit strategySelection in strategy.Selections)
			{
				if (strategySelection.IsAliveInBattle())
				{
					IEnumerator enumerator3 = UnitStyleConfigurationBase.DispelPositiveEffects(strategySelection.SourceUnit, new int?(damageEnhance.NumberOfDispels)).GetEnumerator();
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
			}
		}
		else
		{
			List<BattleHeal> heals = new List<BattleHeal>();
			foreach (IBattleUnit unit in strategy.Selections)
			{
				int? numberOfCleanings = this.NumberOfActiveCleanings(skill.Skill);
				List<BattleEffectBase> negativesTobeRemoved = new List<BattleEffectBase>();
				if (numberOfCleanings != null)
				{
					negativesTobeRemoved.AddRange(unit.BattleEffects.GetHarmfulEffects().GetDesperseableEffects().Take(numberOfCleanings.Value).ToList<BattleEffectBase>());
				}
				else
				{
					negativesTobeRemoved.AddRange(unit.BattleEffects.GetHarmfulEffects().GetDesperseableEffects().ToList<BattleEffectBase>());
				}
				int totalActual = negativesTobeRemoved.Count;
				foreach (BattleEffectBase battleEffectBase in negativesTobeRemoved)
				{
					IEnumerator enumerator6 = unit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
					try
					{
						while (enumerator6.MoveNext())
						{
							object _3 = enumerator6.Current;
							yield return _3;
						}
					}
					finally
					{
						IDisposable disposable3;
						if ((disposable3 = (enumerator6 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				SpellOfHolinessHealData spellOfHolinessHeal = skill.SourceUnit.SpecialEffects.OfType<SpellOfHolinessHealData>().FirstOrDefault<SpellOfHolinessHealData>();
				if (spellOfHolinessHeal != null && totalActual > 0)
				{
					heals.Add(new BattleHeal(unit, skill, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = (double)totalActual * spellOfHolinessHeal.HealRate * unit.GetMaxLife(AttributeRetrievalLevel.Skill),
							IsDirectHeal = true,
							HealType = OutputType.RealHeal
						}
					}, false));
				}
			}
			if (heals.Any<BattleHeal>())
			{
				IEnumerator enumerator7 = new ReleaseableHeal(heals, skill.SourceUnit).Release().GetEnumerator();
				try
				{
					while (enumerator7.MoveNext())
					{
						object _4 = enumerator7.Current;
						yield return _4;
					}
				}
				finally
				{
					IDisposable disposable4;
					if ((disposable4 = (enumerator7 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x04002732 RID: 10034
	private SkillCategory _skillCategory = SkillCategory.Supportive;

	// Token: 0x04002733 RID: 10035
	private OutputType _skillOutputType;

	// Token: 0x04002734 RID: 10036
	private TargetingType _targetingType = TargetingType.Single;

	// Token: 0x04002735 RID: 10037
	private SkillType _skillType = SkillType.SpellOfHoliness;

	// Token: 0x02000E2C RID: 3628
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B4A RID: 23370 RVA: 0x0013FA69 File Offset: 0x0013DE69
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator0()
		{
		}

		// Token: 0x06005B4B RID: 23371 RVA: 0x0013FA74 File Offset: 0x0013DE74
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitRegularTurnStarts || eventTriggerUnit != skillOwner)
				{
					goto IL_22B;
				}
				battleEncounter = (skillOwner.CurrentEncounter as BattleEncounter);
				if (battleEncounter == null)
				{
					goto IL_22B;
				}
				friendlyUnits = (from u in skillOwner.GetAllLiveFriendlyTargetsIncSelf(true)
				where u.Status == BattleUnitStatus.Active
				select u).ToList<IBattleUnit>();
				if (!friendlyUnits.Any<IBattleUnit>() || (double)UnityEngine.Random.value > base.GetPassiveCleaningChance(processingSkill.Skill))
				{
					goto IL_22B;
				}
				selectedUnit = friendlyUnits[UnityEngine.Random.Range(0, friendlyUnits.Count)];
				tobeRemoved = selectedUnit.BattleEffects.GetHarmfulEffects().GetDesperseableEffects().Take(base.NumberOfPassiveCleanings(processingSkill.Skill)).ToList<BattleEffectBase>();
				enumerator = tobeRemoved.GetEnumerator();
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
					Block_10:
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
					battleEffectBase = enumerator.Current;
					enumerator2 = selectedUnit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
					num = 4294967293u;
					goto Block_10;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_22B:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700130E RID: 4878
		// (get) Token: 0x06005B4C RID: 23372 RVA: 0x0013FCD4 File Offset: 0x0013E0D4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700130F RID: 4879
		// (get) Token: 0x06005B4D RID: 23373 RVA: 0x0013FCDC File Offset: 0x0013E0DC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B4E RID: 23374 RVA: 0x0013FCE4 File Offset: 0x0013E0E4
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

		// Token: 0x06005B4F RID: 23375 RVA: 0x0013FD78 File Offset: 0x0013E178
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B50 RID: 23376 RVA: 0x0013FD7F File Offset: 0x0013E17F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B51 RID: 23377 RVA: 0x0013FD88 File Offset: 0x0013E188
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpellOfHoliness.<PassiveBeingActiveEventProcess>c__Iterator0 <PassiveBeingActiveEventProcess>c__Iterator = new SpellOfHoliness.<PassiveBeingActiveEventProcess>c__Iterator0();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<PassiveBeingActiveEventProcess>c__Iterator.skillOwner = skillOwner;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x06005B52 RID: 23378 RVA: 0x0013FDEC File Offset: 0x0013E1EC
		private static bool <>m__0(IBattleUnit u)
		{
			return u.Status == BattleUnitStatus.Active;
		}

		// Token: 0x04004CD7 RID: 19671
		internal AdventureEventType eventType;

		// Token: 0x04004CD8 RID: 19672
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004CD9 RID: 19673
		internal IBattleUnit skillOwner;

		// Token: 0x04004CDA RID: 19674
		internal BattleEncounter <battleEncounter>__1;

		// Token: 0x04004CDB RID: 19675
		internal List<IBattleUnit> <friendlyUnits>__2;

		// Token: 0x04004CDC RID: 19676
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004CDD RID: 19677
		internal IBattleUnit <selectedUnit>__3;

		// Token: 0x04004CDE RID: 19678
		internal List<BattleEffectBase> <tobeRemoved>__3;

		// Token: 0x04004CDF RID: 19679
		internal List<BattleEffectBase>.Enumerator $locvar0;

		// Token: 0x04004CE0 RID: 19680
		internal BattleEffectBase <battleEffectBase>__4;

		// Token: 0x04004CE1 RID: 19681
		internal IEnumerator $locvar1;

		// Token: 0x04004CE2 RID: 19682
		internal object <_>__5;

		// Token: 0x04004CE3 RID: 19683
		internal IDisposable $locvar2;

		// Token: 0x04004CE4 RID: 19684
		internal SpellOfHoliness $this;

		// Token: 0x04004CE5 RID: 19685
		internal object $current;

		// Token: 0x04004CE6 RID: 19686
		internal bool $disposing;

		// Token: 0x04004CE7 RID: 19687
		internal int $PC;

		// Token: 0x04004CE8 RID: 19688
		private static Func<IBattleUnit, bool> <>f__am$cache0;
	}

	// Token: 0x02000E2D RID: 3629
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B53 RID: 23379 RVA: 0x0013FDF7 File Offset: 0x0013E1F7
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator1()
		{
		}

		// Token: 0x06005B54 RID: 23380 RVA: 0x0013FE00 File Offset: 0x0013E200
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				SpellOfHolinessDamageData damageEnhance = skill.SourceUnit.SpecialEffects.OfType<SpellOfHolinessDamageData>().FirstOrDefault<SpellOfHolinessDamageData>();
				if (damageEnhance == null)
				{
					heals = new List<BattleHeal>();
					enumerator4 = strategy.Selections.GetEnumerator();
					num = 4294967293u;
					goto Block_5;
				}
				releaseable = new ReleaseableDamage((from s in strategy.Selections
				select new BattleDamage(s, skill, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(skill.SourceUnit, s, skill.SourceUnit.GetOutputType(), damageEnhance.DamageRate)
					}, s, skill.SourceUnit, true, false)
				})).ToList<BattleDamage>(), skill.SourceUnit);
				enumerator = releaseable.Release().GetEnumerator();
				num = 4294967293u;
				break;
			}
			case 1u:
				break;
			case 2u:
				goto IL_186;
			case 3u:
				goto IL_2C1;
			case 4u:
				goto IL_5A7;
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
			enumerator2 = strategy.Selections.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_186:
				switch (num)
				{
				case 2u:
					Block_16:
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
					break;
				}
				while (enumerator2.MoveNext())
				{
					strategySelection = enumerator2.Current;
					if (strategySelection.IsAliveInBattle())
					{
						enumerator3 = UnitStyleConfigurationBase.DispelPositiveEffects(strategySelection.SourceUnit, new int?(<CastSkillLogic>c__AnonStorey.damageEnhance.NumberOfDispels)).GetEnumerator();
						num = 4294967293u;
						goto Block_16;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			goto IL_629;
			Block_5:
			try
			{
				IL_2C1:
				switch (num)
				{
				case 3u:
					Block_28:
					try
					{
						switch (num)
						{
						case 3u:
							Block_33:
							try
							{
								switch (num)
								{
								}
								if (enumerator6.MoveNext())
								{
									_3 = enumerator6.Current;
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
									if ((disposable3 = (enumerator6 as IDisposable)) != null)
									{
										disposable3.Dispose();
									}
								}
							}
							break;
						}
						if (enumerator5.MoveNext())
						{
							battleEffectBase = enumerator5.Current;
							enumerator6 = unit.LooseSkillEffect(battleEffectBase, EffectWearsOffType.Dispersed).GetEnumerator();
							num = 4294967293u;
							goto Block_33;
						}
					}
					finally
					{
						if (!flag)
						{
							((IDisposable)enumerator5).Dispose();
						}
					}
					spellOfHolinessHeal = <CastSkillLogic>c__AnonStorey.skill.SourceUnit.SpecialEffects.OfType<SpellOfHolinessHealData>().FirstOrDefault<SpellOfHolinessHealData>();
					if (spellOfHolinessHeal != null && totalActual > 0)
					{
						heals.Add(new BattleHeal(unit, <CastSkillLogic>c__AnonStorey.skill, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								RawHeal = (double)totalActual * spellOfHolinessHeal.HealRate * unit.GetMaxLife(AttributeRetrievalLevel.Skill),
								IsDirectHeal = true,
								HealType = OutputType.RealHeal
							}
						}, false));
					}
					break;
				}
				if (enumerator4.MoveNext())
				{
					unit = enumerator4.Current;
					numberOfCleanings = base.NumberOfActiveCleanings(<CastSkillLogic>c__AnonStorey.skill.Skill);
					negativesTobeRemoved = new List<BattleEffectBase>();
					if (numberOfCleanings != null)
					{
						negativesTobeRemoved.AddRange(unit.BattleEffects.GetHarmfulEffects().GetDesperseableEffects().Take(numberOfCleanings.Value).ToList<BattleEffectBase>());
					}
					else
					{
						negativesTobeRemoved.AddRange(unit.BattleEffects.GetHarmfulEffects().GetDesperseableEffects().ToList<BattleEffectBase>());
					}
					totalActual = negativesTobeRemoved.Count;
					enumerator5 = negativesTobeRemoved.GetEnumerator();
					num = 4294967293u;
					goto Block_28;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator4).Dispose();
				}
			}
			if (!heals.Any<BattleHeal>())
			{
				goto IL_629;
			}
			enumerator7 = new ReleaseableHeal(heals, <CastSkillLogic>c__AnonStorey.skill.SourceUnit).Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_5A7:
				switch (num)
				{
				}
				if (enumerator7.MoveNext())
				{
					_4 = enumerator7.Current;
					this.$current = _4;
					if (!this.$disposing)
					{
						this.$PC = 4;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable4 = (enumerator7 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			IL_629:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001310 RID: 4880
		// (get) Token: 0x06005B55 RID: 23381 RVA: 0x001404EC File Offset: 0x0013E8EC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001311 RID: 4881
		// (get) Token: 0x06005B56 RID: 23382 RVA: 0x001404F4 File Offset: 0x0013E8F4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B57 RID: 23383 RVA: 0x001404FC File Offset: 0x0013E8FC
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
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			case 3u:
				try
				{
					try
					{
						try
						{
						}
						finally
						{
							if ((disposable3 = (enumerator6 as IDisposable)) != null)
							{
								disposable3.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator5).Dispose();
					}
				}
				finally
				{
					((IDisposable)enumerator4).Dispose();
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator7 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005B58 RID: 23384 RVA: 0x00140694 File Offset: 0x0013EA94
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B59 RID: 23385 RVA: 0x0014069B File Offset: 0x0013EA9B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B5A RID: 23386 RVA: 0x001406A4 File Offset: 0x0013EAA4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SpellOfHoliness.<CastSkillLogic>c__Iterator1 <CastSkillLogic>c__Iterator = new SpellOfHoliness.<CastSkillLogic>c__Iterator1();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x04004CE9 RID: 19689
		internal AdventureUnitSkill skill;

		// Token: 0x04004CEA RID: 19690
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004CEB RID: 19691
		internal ReleaseableDamage <releaseable>__1;

		// Token: 0x04004CEC RID: 19692
		internal IEnumerator $locvar0;

		// Token: 0x04004CED RID: 19693
		internal object <_>__2;

		// Token: 0x04004CEE RID: 19694
		internal IDisposable $locvar1;

		// Token: 0x04004CEF RID: 19695
		internal List<IBattleUnit>.Enumerator $locvar2;

		// Token: 0x04004CF0 RID: 19696
		internal IBattleUnit <strategySelection>__3;

		// Token: 0x04004CF1 RID: 19697
		internal IEnumerator $locvar3;

		// Token: 0x04004CF2 RID: 19698
		internal object <_>__4;

		// Token: 0x04004CF3 RID: 19699
		internal IDisposable $locvar4;

		// Token: 0x04004CF4 RID: 19700
		internal List<BattleHeal> <heals>__5;

		// Token: 0x04004CF5 RID: 19701
		internal List<IBattleUnit>.Enumerator $locvar5;

		// Token: 0x04004CF6 RID: 19702
		internal IBattleUnit <unit>__6;

		// Token: 0x04004CF7 RID: 19703
		internal int? <numberOfCleanings>__7;

		// Token: 0x04004CF8 RID: 19704
		internal List<BattleEffectBase> <negativesTobeRemoved>__7;

		// Token: 0x04004CF9 RID: 19705
		internal int <totalActual>__7;

		// Token: 0x04004CFA RID: 19706
		internal List<BattleEffectBase>.Enumerator $locvar6;

		// Token: 0x04004CFB RID: 19707
		internal BattleEffectBase <battleEffectBase>__8;

		// Token: 0x04004CFC RID: 19708
		internal IEnumerator $locvar7;

		// Token: 0x04004CFD RID: 19709
		internal object <_>__9;

		// Token: 0x04004CFE RID: 19710
		internal IDisposable $locvar8;

		// Token: 0x04004CFF RID: 19711
		internal SpellOfHolinessHealData <spellOfHolinessHeal>__7;

		// Token: 0x04004D00 RID: 19712
		internal IEnumerator $locvar9;

		// Token: 0x04004D01 RID: 19713
		internal object <_>__10;

		// Token: 0x04004D02 RID: 19714
		internal IDisposable $locvarA;

		// Token: 0x04004D03 RID: 19715
		internal SpellOfHoliness $this;

		// Token: 0x04004D04 RID: 19716
		internal object $current;

		// Token: 0x04004D05 RID: 19717
		internal bool $disposing;

		// Token: 0x04004D06 RID: 19718
		internal int $PC;

		// Token: 0x04004D07 RID: 19719
		private SpellOfHoliness.<CastSkillLogic>c__Iterator1.<CastSkillLogic>c__AnonStorey2 $locvarB;

		// Token: 0x02000E2E RID: 3630
		private sealed class <CastSkillLogic>c__AnonStorey2
		{
			// Token: 0x06005B5B RID: 23387 RVA: 0x001406F0 File Offset: 0x0013EAF0
			public <CastSkillLogic>c__AnonStorey2()
			{
			}

			// Token: 0x06005B5C RID: 23388 RVA: 0x001406F8 File Offset: 0x0013EAF8
			internal BattleDamage <>m__0(IBattleUnit s)
			{
				return new BattleDamage(s, this.skill, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(this.skill.SourceUnit, s, this.skill.SourceUnit.GetOutputType(), this.damageEnhance.DamageRate)
					}, s, this.skill.SourceUnit, true, false)
				});
			}

			// Token: 0x04004D08 RID: 19720
			internal AdventureUnitSkill skill;

			// Token: 0x04004D09 RID: 19721
			internal SpellOfHolinessDamageData damageEnhance;

			// Token: 0x04004D0A RID: 19722
			internal SpellOfHoliness.<CastSkillLogic>c__Iterator1 <>f__ref$1;
		}
	}
}
