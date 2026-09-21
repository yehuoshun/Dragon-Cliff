using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006BC RID: 1724
public class CurseOfTheDead : ActiveSkillLogicBase
{
	// Token: 0x06002DF1 RID: 11761 RVA: 0x00133353 File Offset: 0x00131753
	public CurseOfTheDead()
	{
	}

	// Token: 0x06002DF2 RID: 11762 RVA: 0x0013337C File Offset: 0x0013177C
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new CurseOfTheDeadEnhancementTalent(SkillType.CurseOfTheDead, 1),
			new TacticTargetAttributeDebuffTalent(SkillType.CurseOfTheDead, 2),
			new TacticTargetAttributeDebuffTalent(SkillType.CurseOfTheDead, 3)
		};
	}

	// Token: 0x170005DA RID: 1498
	// (get) Token: 0x06002DF3 RID: 11763 RVA: 0x001333C3 File Offset: 0x001317C3
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005DB RID: 1499
	// (get) Token: 0x06002DF4 RID: 11764 RVA: 0x001333CB File Offset: 0x001317CB
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005DC RID: 1500
	// (get) Token: 0x06002DF5 RID: 11765 RVA: 0x001333D3 File Offset: 0x001317D3
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005DD RID: 1501
	// (get) Token: 0x06002DF6 RID: 11766 RVA: 0x001333DB File Offset: 0x001317DB
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002DF7 RID: 11767 RVA: 0x001333E3 File Offset: 0x001317E3
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<HostileAllStrategy>();
	}

	// Token: 0x06002DF8 RID: 11768 RVA: 0x001333EA File Offset: 0x001317EA
	public override double GetGaugeCost(Skill skill)
	{
		return 65.0;
	}

	// Token: 0x06002DF9 RID: 11769 RVA: 0x001333F5 File Offset: 0x001317F5
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1.5f);
	}

	// Token: 0x06002DFA RID: 11770 RVA: 0x00133401 File Offset: 0x00131801
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new HostileAllStrategy(skill);
	}

	// Token: 0x06002DFB RID: 11771 RVA: 0x00133409 File Offset: 0x00131809
	private double AdditionalDamageRatePerDeath(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 1.0;
	}

	// Token: 0x06002DFC RID: 11772 RVA: 0x00133428 File Offset: 0x00131828
	private double AdditinalCasterDamageRatePerDeath(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 1.0;
	}

	// Token: 0x06002DFD RID: 11773 RVA: 0x00133447 File Offset: 0x00131847
	private double ActiveInitialDamageRate(Skill skill)
	{
		return 0.3;
	}

	// Token: 0x06002DFE RID: 11774 RVA: 0x00133452 File Offset: 0x00131852
	private double ActiveInitialCasterDamageRate(Skill skill)
	{
		return 0.2;
	}

	// Token: 0x06002DFF RID: 11775 RVA: 0x00133460 File Offset: 0x00131860
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		List<BattleDamage> damages = new List<BattleDamage>();
		int totalDeathUnits = skill.SourceUnit.GetDeadEnemyTargets().Count;
		double totalDamageRateFromSkill = this.ActiveInitialDamageRate(skill.Skill) + this.AdditionalDamageRatePerDeath(skill.Skill) * (double)totalDeathUnits;
		double totalDamageRateFromCaster = this.ActiveInitialCasterDamageRate(skill.Skill) + (this.AdditinalCasterDamageRatePerDeath(skill.Skill) + skill.SourceUnit.SpecialEffects.OfType<CurseOfTheDeadDamageBoostData>().Sum((CurseOfTheDeadDamageBoostData s) => s.ExtraDamageRate)) * (double)totalDeathUnits;
		foreach (IBattleUnit target in strategy.Selections)
		{
			damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(skill.SourceUnit, target, OutputType.Shadow, totalDamageRateFromSkill),
					new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), totalDamageRateFromCaster)
				}, target, skill.SourceUnit, true, false)
			}));
		}
		ReleaseableDamage releaseable = new ReleaseableDamage(damages, skill.SourceUnit);
		IEnumerator enumerator2 = releaseable.Release().GetEnumerator();
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
		DevilSpellData devilSpell = skill.SourceUnit.SpecialEffects.OfType<DevilSpellData>().FirstOrDefault<DevilSpellData>();
		if (devilSpell != null)
		{
			if (releaseable.BattleDamages.All((BattleDamage d) => d.Damages.All((DamageComponent dd) => dd.IsFatal == null || !dd.IsFatal.Value)))
			{
				IEnumerator enumerator3 = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = AttributeType.Intelligience,
						ModificationType = ModificationType.Multiplication,
						Value = devilSpell.Rate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "devilspellexclusive", new int?(5), null, null, false, false, false), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06002E00 RID: 11776 RVA: 0x00133494 File Offset: 0x00131894
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, this.ActiveInitialDamageRate(skill).ToExpressionMultiply100()).Replace(this.MainDamagePerLayer, this.AdditionalDamageRatePerDeath(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.ActiveInitialCasterDamageRate(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRatePerLayer, this.AdditinalCasterDamageRatePerDeath(skill).ToExpressionMultiply100()).ToString();
		description.Details2 = description.Details2.Replace(this.HealRateKey, this.PassiveHealRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002E01 RID: 11777 RVA: 0x00133532 File Offset: 0x00131932
	private double PassiveHealRate(Skill skill)
	{
		return 0.06 + (double)(skill.Level - 1) * 0.02;
	}

	// Token: 0x06002E02 RID: 11778 RVA: 0x00133554 File Offset: 0x00131954
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitRegularTurnStarts
		};
	}

	// Token: 0x06002E03 RID: 11779 RVA: 0x00133570 File Offset: 0x00131970
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitRegularTurnStarts && skillOwner == eventTriggerUnit)
		{
			int totalDeaths = processingSkill.SourceUnit.GetDeadEnemyTargets().Count;
			if (totalDeaths > 0)
			{
				double totalHeal = Convert.ToDouble(totalDeaths) * this.PassiveHealRate(processingSkill.Skill);
				ReleaseableHeal releaseable = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(skillOwner, processingSkill, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = totalHeal * processingSkill.SourceUnit.GetMaxLife(AttributeRetrievalLevel.Skill),
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, false)
				}, processingSkill.SourceUnit);
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
			}
		}
		yield break;
	}

	// Token: 0x040026EC RID: 9964
	private SkillCategory _skillCategory = SkillCategory.Offensive;

	// Token: 0x040026ED RID: 9965
	private OutputType _skillOutputType = OutputType.Shadow;

	// Token: 0x040026EE RID: 9966
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x040026EF RID: 9967
	private SkillType _skillType = SkillType.CurseOfTheDead;

	// Token: 0x02000DFE RID: 3582
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060059EA RID: 23018 RVA: 0x001335B0 File Offset: 0x001319B0
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x060059EB RID: 23019 RVA: 0x001335B8 File Offset: 0x001319B8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damages = new List<BattleDamage>();
				totalDeathUnits = skill.SourceUnit.GetDeadEnemyTargets().Count;
				totalDamageRateFromSkill = base.ActiveInitialDamageRate(skill.Skill) + base.AdditionalDamageRatePerDeath(skill.Skill) * (double)totalDeathUnits;
				totalDamageRateFromCaster = base.ActiveInitialCasterDamageRate(skill.Skill) + (base.AdditinalCasterDamageRatePerDeath(skill.Skill) + skill.SourceUnit.SpecialEffects.OfType<CurseOfTheDeadDamageBoostData>().Sum((CurseOfTheDeadDamageBoostData s) => s.ExtraDamageRate)) * (double)totalDeathUnits;
				enumerator = strategy.Selections.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						IBattleUnit target = enumerator.Current;
						damages.Add(new BattleDamage(target, skill, new List<DamageComponentValue>
						{
							new DamageComponentValue(new List<DamagePotionValue>
							{
								new DamagePotionValue(skill.SourceUnit, target, OutputType.Shadow, totalDamageRateFromSkill),
								new DamagePotionValue(skill.SourceUnit, target, skill.SourceUnit.GetOutputType(), totalDamageRateFromCaster)
							}, target, skill.SourceUnit, true, false)
						}));
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				releaseable = new ReleaseableDamage(damages, skill.SourceUnit);
				enumerator2 = releaseable.Release().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_38C;
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
			devilSpell = skill.SourceUnit.SpecialEffects.OfType<DevilSpellData>().FirstOrDefault<DevilSpellData>();
			if (devilSpell == null)
			{
				goto IL_410;
			}
			if (!releaseable.BattleDamages.All((BattleDamage d) => d.Damages.All((DamageComponent dd) => dd.IsFatal == null || !dd.IsFatal.Value)))
			{
				goto IL_410;
			}
			enumerator3 = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.Intelligience,
					ModificationType = ModificationType.Multiplication,
					Value = devilSpell.Rate,
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			}, "devilspellexclusive", new int?(5), null, null, false, false, false), false).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_38C:
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
			IL_410:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012BE RID: 4798
		// (get) Token: 0x060059EC RID: 23020 RVA: 0x00133A08 File Offset: 0x00131E08
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012BF RID: 4799
		// (get) Token: 0x060059ED RID: 23021 RVA: 0x00133A10 File Offset: 0x00131E10
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060059EE RID: 23022 RVA: 0x00133A18 File Offset: 0x00131E18
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

		// Token: 0x060059EF RID: 23023 RVA: 0x00133AC8 File Offset: 0x00131EC8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060059F0 RID: 23024 RVA: 0x00133ACF File Offset: 0x00131ECF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060059F1 RID: 23025 RVA: 0x00133AD8 File Offset: 0x00131ED8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CurseOfTheDead.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new CurseOfTheDead.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x060059F2 RID: 23026 RVA: 0x00133B24 File Offset: 0x00131F24
		private static double <>m__0(CurseOfTheDeadDamageBoostData s)
		{
			return s.ExtraDamageRate;
		}

		// Token: 0x060059F3 RID: 23027 RVA: 0x00133B2C File Offset: 0x00131F2C
		private static bool <>m__1(BattleDamage d)
		{
			return d.Damages.All((DamageComponent dd) => dd.IsFatal == null || !dd.IsFatal.Value);
		}

		// Token: 0x060059F4 RID: 23028 RVA: 0x00133B58 File Offset: 0x00131F58
		private static bool <>m__2(DamageComponent dd)
		{
			return dd.IsFatal == null || !dd.IsFatal.Value;
		}

		// Token: 0x04004A5B RID: 19035
		internal List<BattleDamage> <damages>__0;

		// Token: 0x04004A5C RID: 19036
		internal AdventureUnitSkill skill;

		// Token: 0x04004A5D RID: 19037
		internal int <totalDeathUnits>__0;

		// Token: 0x04004A5E RID: 19038
		internal double <totalDamageRateFromSkill>__0;

		// Token: 0x04004A5F RID: 19039
		internal double <totalDamageRateFromCaster>__0;

		// Token: 0x04004A60 RID: 19040
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004A61 RID: 19041
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004A62 RID: 19042
		internal ReleaseableDamage <releaseable>__0;

		// Token: 0x04004A63 RID: 19043
		internal IEnumerator $locvar1;

		// Token: 0x04004A64 RID: 19044
		internal object <_>__1;

		// Token: 0x04004A65 RID: 19045
		internal IDisposable $locvar2;

		// Token: 0x04004A66 RID: 19046
		internal DevilSpellData <devilSpell>__0;

		// Token: 0x04004A67 RID: 19047
		internal IEnumerator $locvar3;

		// Token: 0x04004A68 RID: 19048
		internal object <_>__2;

		// Token: 0x04004A69 RID: 19049
		internal IDisposable $locvar4;

		// Token: 0x04004A6A RID: 19050
		internal CurseOfTheDead $this;

		// Token: 0x04004A6B RID: 19051
		internal object $current;

		// Token: 0x04004A6C RID: 19052
		internal bool $disposing;

		// Token: 0x04004A6D RID: 19053
		internal int $PC;

		// Token: 0x04004A6E RID: 19054
		private static Func<CurseOfTheDeadDamageBoostData, double> <>f__am$cache0;

		// Token: 0x04004A6F RID: 19055
		private static Func<BattleDamage, bool> <>f__am$cache1;

		// Token: 0x04004A70 RID: 19056
		private static Func<DamageComponent, bool> <>f__am$cache2;
	}

	// Token: 0x02000DFF RID: 3583
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060059F5 RID: 23029 RVA: 0x00133B8C File Offset: 0x00131F8C
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator1()
		{
		}

		// Token: 0x060059F6 RID: 23030 RVA: 0x00133B94 File Offset: 0x00131F94
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitRegularTurnStarts || skillOwner != eventTriggerUnit)
				{
					goto IL_1A7;
				}
				totalDeaths = processingSkill.SourceUnit.GetDeadEnemyTargets().Count;
				if (totalDeaths <= 0)
				{
					goto IL_1A7;
				}
				totalHeal = Convert.ToDouble(totalDeaths) * base.PassiveHealRate(processingSkill.Skill);
				releaseable = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(skillOwner, processingSkill, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = totalHeal * processingSkill.SourceUnit.GetMaxLife(AttributeRetrievalLevel.Skill),
							HealType = OutputType.RealHeal,
							IsDirectHeal = false
						}
					}, false)
				}, processingSkill.SourceUnit);
				enumerator = releaseable.Release().GetEnumerator();
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
			IL_1A7:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012C0 RID: 4800
		// (get) Token: 0x060059F7 RID: 23031 RVA: 0x00133D64 File Offset: 0x00132164
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012C1 RID: 4801
		// (get) Token: 0x060059F8 RID: 23032 RVA: 0x00133D6C File Offset: 0x0013216C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060059F9 RID: 23033 RVA: 0x00133D74 File Offset: 0x00132174
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

		// Token: 0x060059FA RID: 23034 RVA: 0x00133DE4 File Offset: 0x001321E4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060059FB RID: 23035 RVA: 0x00133DEB File Offset: 0x001321EB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x060059FC RID: 23036 RVA: 0x00133DF4 File Offset: 0x001321F4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			CurseOfTheDead.<PassiveBeingActiveEventProcess>c__Iterator1 <PassiveBeingActiveEventProcess>c__Iterator = new CurseOfTheDead.<PassiveBeingActiveEventProcess>c__Iterator1();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.skillOwner = skillOwner;
			<PassiveBeingActiveEventProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x04004A71 RID: 19057
		internal AdventureEventType eventType;

		// Token: 0x04004A72 RID: 19058
		internal IBattleUnit skillOwner;

		// Token: 0x04004A73 RID: 19059
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004A74 RID: 19060
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004A75 RID: 19061
		internal int <totalDeaths>__1;

		// Token: 0x04004A76 RID: 19062
		internal double <totalHeal>__2;

		// Token: 0x04004A77 RID: 19063
		internal ReleaseableHeal <releaseable>__2;

		// Token: 0x04004A78 RID: 19064
		internal IEnumerator $locvar0;

		// Token: 0x04004A79 RID: 19065
		internal object <_>__3;

		// Token: 0x04004A7A RID: 19066
		internal IDisposable $locvar1;

		// Token: 0x04004A7B RID: 19067
		internal CurseOfTheDead $this;

		// Token: 0x04004A7C RID: 19068
		internal object $current;

		// Token: 0x04004A7D RID: 19069
		internal bool $disposing;

		// Token: 0x04004A7E RID: 19070
		internal int $PC;
	}
}
