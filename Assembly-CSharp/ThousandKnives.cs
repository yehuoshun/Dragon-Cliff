using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Core.SpecialEffect.AdventurerStarEffects.Data;

// Token: 0x020006DA RID: 1754
public class ThousandKnives : ActiveSkillLogicBase
{
	// Token: 0x06002F90 RID: 12176 RVA: 0x00144F7F File Offset: 0x0014337F
	public ThousandKnives()
	{
	}

	// Token: 0x06002F91 RID: 12177 RVA: 0x00144FA8 File Offset: 0x001433A8
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new ThousandKnivesDebuffTalent(SkillType.ThousandKnives, 1),
			new ThousandKnivesDamageBoostTalent(SkillType.ThousandKnives, 2),
			new ThousandKnivesDispelTalent(SkillType.ThousandKnives, 3)
		};
	}

	// Token: 0x17000637 RID: 1591
	// (get) Token: 0x06002F92 RID: 12178 RVA: 0x00144FEF File Offset: 0x001433EF
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x17000638 RID: 1592
	// (get) Token: 0x06002F93 RID: 12179 RVA: 0x00144FF7 File Offset: 0x001433F7
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x17000639 RID: 1593
	// (get) Token: 0x06002F94 RID: 12180 RVA: 0x00144FFF File Offset: 0x001433FF
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x1700063A RID: 1594
	// (get) Token: 0x06002F95 RID: 12181 RVA: 0x00145007 File Offset: 0x00143407
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002F96 RID: 12182 RVA: 0x0014500F File Offset: 0x0014340F
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<HostileAllStrategy>();
	}

	// Token: 0x06002F97 RID: 12183 RVA: 0x00145016 File Offset: 0x00143416
	public override double GetGaugeCost(Skill skill)
	{
		return 85.0;
	}

	// Token: 0x06002F98 RID: 12184 RVA: 0x00145021 File Offset: 0x00143421
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002F99 RID: 12185 RVA: 0x0014502D File Offset: 0x0014342D
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new HostileAllStrategy(skill);
	}

	// Token: 0x06002F9A RID: 12186 RVA: 0x00145035 File Offset: 0x00143435
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002F9B RID: 12187 RVA: 0x0014503C File Offset: 0x0014343C
	private double ActiveDamageRate(Skill skill)
	{
		if (skill.Level == 1)
		{
			return 1.25;
		}
		if (skill.Level == 2)
		{
			return 1.75;
		}
		return 2.5;
	}

	// Token: 0x06002F9C RID: 12188 RVA: 0x00145073 File Offset: 0x00143473
	private double PassiveBoostRate(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x06002F9D RID: 12189 RVA: 0x00145094 File Offset: 0x00143494
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.MainDamageRateKey, this.ActiveDamageRate(skill).ToExpressionMultiply100()).Replace(this.CasterDamageRateKey, this.ActiveDamageRate(skill).ToExpressionMultiply100());
		description.Details2 = description.Details2.Replace(this.BoostRateKey, this.PassiveBoostRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002F9E RID: 12190 RVA: 0x00145100 File Offset: 0x00143500
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		List<BattleDamage> damages = new List<BattleDamage>();
		ThousandKnivesDepressionEnhancementData optDepressionRate = skill.SourceUnit.SpecialEffects.OfType<ThousandKnivesDepressionEnhancementData>().FirstOrDefault<ThousandKnivesDepressionEnhancementData>();
		ThousandKnivesDamageEnhancementData damageEnhancement = skill.SourceUnit.SpecialEffects.OfType<ThousandKnivesDamageEnhancementData>().FirstOrDefault<ThousandKnivesDamageEnhancementData>();
		ThousandKnivesDispelEnhancementData dispelEnhancement = skill.SourceUnit.SpecialEffects.OfType<ThousandKnivesDispelEnhancementData>().FirstOrDefault<ThousandKnivesDispelEnhancementData>();
		double damageRate = this.ActiveDamageRate(skill.Skill);
		if (damageEnhancement != null)
		{
			damageRate = damageEnhancement.DamageRate;
		}
		if (dispelEnhancement != null)
		{
			damageRate *= 1.0 - dispelEnhancement.DamageReductionRate;
		}
		ThousandKnivesExtremeDamageEnhancementData additionalEnhancedDamageRate = skill.SourceUnit.SpecialEffects.OfType<ThousandKnivesExtremeDamageEnhancementData>().FirstOrDefault<ThousandKnivesExtremeDamageEnhancementData>();
		foreach (IBattleUnit unit in strategy.Selections)
		{
			if (optDepressionRate == null && damageEnhancement == null)
			{
				IEnumerator enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(unit, new int?((dispelEnhancement != null) ? dispelEnhancement.NumberOfDispels : 1)).GetEnumerator();
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
			if (optDepressionRate != null)
			{
				IEnumerator enumerator3 = unit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = unit.GetOutputAttributeType(),
						ModificationType = ModificationType.Multiplication,
						Value = -optDepressionRate.OutputDepressionRate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "thousandknivesoutputdepression", new int?(1), new float?((float)optDepressionRate.Seconds), null, true, true), false).GetEnumerator();
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
			double hitDamageRate = damageRate;
			if (additionalEnhancedDamageRate != null)
			{
				int num = unit.BattleEffects.GetPositiveEffects().GetDesperseableEffects().Count<BattleEffectBase>();
				double num2 = 0.25 * (double)num;
				double num3 = additionalEnhancedDamageRate.ExtraDamageRate * (1.0 - num2);
				if (num3 > 0.0)
				{
					hitDamageRate += num3;
				}
			}
			damages.Add(new BattleDamage(unit, skill, new List<DamageComponentValue>
			{
				new DamageComponentValue(new List<DamagePotionValue>
				{
					new DamagePotionValue(skill.SourceUnit, unit, OutputType.Physical, hitDamageRate),
					new DamagePotionValue(skill.SourceUnit, unit, skill.SourceUnit.GetOutputType(), hitDamageRate)
				}, unit, skill.SourceUnit, true, false)
			}));
		}
		if (damages.Any<BattleDamage>())
		{
			ReleaseableDamage releaseable = new ReleaseableDamage(damages, skill.SourceUnit);
			IEnumerator enumerator4 = releaseable.Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x06002F9F RID: 12191 RVA: 0x00145134 File Offset: 0x00143534
	public override IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		IEnumerator enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateStrengthBoostEffect(skill, this.PassiveBoostRate(skill.Skill) * skill.SourceUnit.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill), base.GetType().FullName, null), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x06002FA0 RID: 12192 RVA: 0x00145160 File Offset: 0x00143560
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		List<AttributeModificationEffect> toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
		where ef.EffectSourceIdentityCode == base.GetType().FullName
		select ef).ToList<AttributeModificationEffect>();
		foreach (AttributeModificationEffect remove in toRemove)
		{
			IEnumerator enumerator2 = skill.SourceUnit.LooseSkillEffect(remove, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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
		yield break;
	}

	// Token: 0x04002750 RID: 10064
	private SkillCategory _skillCategory = SkillCategory.Offensive;

	// Token: 0x04002751 RID: 10065
	private OutputType _skillOutputType = OutputType.Physical;

	// Token: 0x04002752 RID: 10066
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x04002753 RID: 10067
	private SkillType _skillType = SkillType.ThousandKnives;

	// Token: 0x02000E43 RID: 3651
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005BCC RID: 23500 RVA: 0x0014518A File Offset: 0x0014358A
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005BCD RID: 23501 RVA: 0x00145194 File Offset: 0x00143594
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				damages = new List<BattleDamage>();
				optDepressionRate = skill.SourceUnit.SpecialEffects.OfType<ThousandKnivesDepressionEnhancementData>().FirstOrDefault<ThousandKnivesDepressionEnhancementData>();
				damageEnhancement = skill.SourceUnit.SpecialEffects.OfType<ThousandKnivesDamageEnhancementData>().FirstOrDefault<ThousandKnivesDamageEnhancementData>();
				dispelEnhancement = skill.SourceUnit.SpecialEffects.OfType<ThousandKnivesDispelEnhancementData>().FirstOrDefault<ThousandKnivesDispelEnhancementData>();
				damageRate = base.ActiveDamageRate(skill.Skill);
				if (damageEnhancement != null)
				{
					damageRate = damageEnhancement.DamageRate;
				}
				if (dispelEnhancement != null)
				{
					damageRate *= 1.0 - dispelEnhancement.DamageReductionRate;
				}
				additionalEnhancedDamageRate = skill.SourceUnit.SpecialEffects.OfType<ThousandKnivesExtremeDamageEnhancementData>().FirstOrDefault<ThousandKnivesExtremeDamageEnhancementData>();
				enumerator = strategy.Selections.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
				break;
			case 3u:
				goto IL_4F1;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				case 1u:
					Block_11:
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
				case 2u:
					Block_13:
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
					goto IL_362;
				default:
					goto IL_481;
				}
				IL_22C:
				if (optDepressionRate != null)
				{
					enumerator3 = unit.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = unit.GetOutputAttributeType(),
							ModificationType = ModificationType.Multiplication,
							Value = -optDepressionRate.OutputDepressionRate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "thousandknivesoutputdepression", new int?(1), new float?((float)optDepressionRate.Seconds), null, true, true), false).GetEnumerator();
					num = 4294967293u;
					goto Block_13;
				}
				IL_362:
				hitDamageRate = damageRate;
				if (additionalEnhancedDamageRate != null)
				{
					int num2 = unit.BattleEffects.GetPositiveEffects().GetDesperseableEffects().Count<BattleEffectBase>();
					double num3 = 0.25 * (double)num2;
					double num4 = additionalEnhancedDamageRate.ExtraDamageRate * (1.0 - num3);
					if (num4 > 0.0)
					{
						hitDamageRate += num4;
					}
				}
				damages.Add(new BattleDamage(unit, skill, new List<DamageComponentValue>
				{
					new DamageComponentValue(new List<DamagePotionValue>
					{
						new DamagePotionValue(skill.SourceUnit, unit, OutputType.Physical, hitDamageRate),
						new DamagePotionValue(skill.SourceUnit, unit, skill.SourceUnit.GetOutputType(), hitDamageRate)
					}, unit, skill.SourceUnit, true, false)
				}));
				IL_481:
				if (enumerator.MoveNext())
				{
					unit = enumerator.Current;
					if (optDepressionRate == null && damageEnhancement == null)
					{
						enumerator2 = UnitStyleConfigurationBase.DispelPositiveEffects(unit, new int?((dispelEnhancement != null) ? dispelEnhancement.NumberOfDispels : 1)).GetEnumerator();
						num = 4294967293u;
						goto Block_11;
					}
					goto IL_22C;
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			if (!damages.Any<BattleDamage>())
			{
				goto IL_573;
			}
			releaseable = new ReleaseableDamage(damages, skill.SourceUnit);
			enumerator4 = releaseable.Release().GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_4F1:
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
			IL_573:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001328 RID: 4904
		// (get) Token: 0x06005BCE RID: 23502 RVA: 0x00145784 File Offset: 0x00143B84
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001329 RID: 4905
		// (get) Token: 0x06005BCF RID: 23503 RVA: 0x0014578C File Offset: 0x00143B8C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005BD0 RID: 23504 RVA: 0x00145794 File Offset: 0x00143B94
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
				try
				{
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
				finally
				{
					((IDisposable)enumerator).Dispose();
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

		// Token: 0x06005BD1 RID: 23505 RVA: 0x001458BC File Offset: 0x00143CBC
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005BD2 RID: 23506 RVA: 0x001458C3 File Offset: 0x00143CC3
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005BD3 RID: 23507 RVA: 0x001458CC File Offset: 0x00143CCC
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ThousandKnives.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new ThousandKnives.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x04004DDC RID: 19932
		internal List<BattleDamage> <damages>__0;

		// Token: 0x04004DDD RID: 19933
		internal AdventureUnitSkill skill;

		// Token: 0x04004DDE RID: 19934
		internal ThousandKnivesDepressionEnhancementData <optDepressionRate>__0;

		// Token: 0x04004DDF RID: 19935
		internal ThousandKnivesDamageEnhancementData <damageEnhancement>__0;

		// Token: 0x04004DE0 RID: 19936
		internal ThousandKnivesDispelEnhancementData <dispelEnhancement>__0;

		// Token: 0x04004DE1 RID: 19937
		internal double <damageRate>__0;

		// Token: 0x04004DE2 RID: 19938
		internal ThousandKnivesExtremeDamageEnhancementData <additionalEnhancedDamageRate>__0;

		// Token: 0x04004DE3 RID: 19939
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004DE4 RID: 19940
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004DE5 RID: 19941
		internal IBattleUnit <unit>__1;

		// Token: 0x04004DE6 RID: 19942
		internal IEnumerator $locvar1;

		// Token: 0x04004DE7 RID: 19943
		internal object <_>__2;

		// Token: 0x04004DE8 RID: 19944
		internal IDisposable $locvar2;

		// Token: 0x04004DE9 RID: 19945
		internal IEnumerator $locvar3;

		// Token: 0x04004DEA RID: 19946
		internal object <_>__3;

		// Token: 0x04004DEB RID: 19947
		internal IDisposable $locvar4;

		// Token: 0x04004DEC RID: 19948
		internal double <hitDamageRate>__4;

		// Token: 0x04004DED RID: 19949
		internal ReleaseableDamage <releaseable>__5;

		// Token: 0x04004DEE RID: 19950
		internal IEnumerator $locvar5;

		// Token: 0x04004DEF RID: 19951
		internal object <_>__6;

		// Token: 0x04004DF0 RID: 19952
		internal IDisposable $locvar6;

		// Token: 0x04004DF1 RID: 19953
		internal ThousandKnives $this;

		// Token: 0x04004DF2 RID: 19954
		internal object $current;

		// Token: 0x04004DF3 RID: 19955
		internal bool $disposing;

		// Token: 0x04004DF4 RID: 19956
		internal int $PC;
	}

	// Token: 0x02000E44 RID: 3652
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005BD4 RID: 23508 RVA: 0x00145918 File Offset: 0x00143D18
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator1()
		{
		}

		// Token: 0x06005BD5 RID: 23509 RVA: 0x00145920 File Offset: 0x00143D20
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateStrengthBoostEffect(skill, base.PassiveBoostRate(skill.Skill) * skill.SourceUnit.GetAttributeValue_Final(AttributeType.Strength, AttributeRetrievalLevel.Skill), base.GetType().FullName, null), false).GetEnumerator();
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700132A RID: 4906
		// (get) Token: 0x06005BD6 RID: 23510 RVA: 0x00145A58 File Offset: 0x00143E58
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700132B RID: 4907
		// (get) Token: 0x06005BD7 RID: 23511 RVA: 0x00145A60 File Offset: 0x00143E60
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005BD8 RID: 23512 RVA: 0x00145A68 File Offset: 0x00143E68
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

		// Token: 0x06005BD9 RID: 23513 RVA: 0x00145AD8 File Offset: 0x00143ED8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005BDA RID: 23514 RVA: 0x00145ADF File Offset: 0x00143EDF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005BDB RID: 23515 RVA: 0x00145AE8 File Offset: 0x00143EE8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ThousandKnives.<PassiveEffectApplies>c__Iterator1 <PassiveEffectApplies>c__Iterator = new ThousandKnives.<PassiveEffectApplies>c__Iterator1();
			<PassiveEffectApplies>c__Iterator.$this = this;
			<PassiveEffectApplies>c__Iterator.skill = skill;
			return <PassiveEffectApplies>c__Iterator;
		}

		// Token: 0x04004DF5 RID: 19957
		internal AdventureUnitSkill skill;

		// Token: 0x04004DF6 RID: 19958
		internal IEnumerator $locvar0;

		// Token: 0x04004DF7 RID: 19959
		internal object <_>__1;

		// Token: 0x04004DF8 RID: 19960
		internal IDisposable $locvar1;

		// Token: 0x04004DF9 RID: 19961
		internal ThousandKnives $this;

		// Token: 0x04004DFA RID: 19962
		internal object $current;

		// Token: 0x04004DFB RID: 19963
		internal bool $disposing;

		// Token: 0x04004DFC RID: 19964
		internal int $PC;
	}

	// Token: 0x02000E45 RID: 3653
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005BDC RID: 23516 RVA: 0x00145B28 File Offset: 0x00143F28
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator2()
		{
		}

		// Token: 0x06005BDD RID: 23517 RVA: 0x00145B30 File Offset: 0x00143F30
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
				where ef.EffectSourceIdentityCode == base.GetType().FullName
				select ef).ToList<AttributeModificationEffect>();
				enumerator = toRemove.GetEnumerator();
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
					Block_4:
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
					remove = enumerator.Current;
					enumerator2 = skill.SourceUnit.LooseSkillEffect(remove, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
					num = 4294967293u;
					goto Block_4;
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

		// Token: 0x1700132C RID: 4908
		// (get) Token: 0x06005BDE RID: 23518 RVA: 0x00145CC0 File Offset: 0x001440C0
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700132D RID: 4909
		// (get) Token: 0x06005BDF RID: 23519 RVA: 0x00145CC8 File Offset: 0x001440C8
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005BE0 RID: 23520 RVA: 0x00145CD0 File Offset: 0x001440D0
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

		// Token: 0x06005BE1 RID: 23521 RVA: 0x00145D64 File Offset: 0x00144164
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005BE2 RID: 23522 RVA: 0x00145D6B File Offset: 0x0014416B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005BE3 RID: 23523 RVA: 0x00145D74 File Offset: 0x00144174
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ThousandKnives.<PassiveEffectLooses>c__Iterator2 <PassiveEffectLooses>c__Iterator = new ThousandKnives.<PassiveEffectLooses>c__Iterator2();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x06005BE4 RID: 23524 RVA: 0x00145DB4 File Offset: 0x001441B4
		internal bool <>m__0(AttributeModificationEffect ef)
		{
			return ef.EffectSourceIdentityCode == base.GetType().FullName;
		}

		// Token: 0x04004DFD RID: 19965
		internal AdventureUnitSkill skill;

		// Token: 0x04004DFE RID: 19966
		internal List<AttributeModificationEffect> <toRemove>__0;

		// Token: 0x04004DFF RID: 19967
		internal List<AttributeModificationEffect>.Enumerator $locvar0;

		// Token: 0x04004E00 RID: 19968
		internal AttributeModificationEffect <remove>__1;

		// Token: 0x04004E01 RID: 19969
		internal IEnumerator $locvar1;

		// Token: 0x04004E02 RID: 19970
		internal object <_>__2;

		// Token: 0x04004E03 RID: 19971
		internal IDisposable $locvar2;

		// Token: 0x04004E04 RID: 19972
		internal ThousandKnives $this;

		// Token: 0x04004E05 RID: 19973
		internal object $current;

		// Token: 0x04004E06 RID: 19974
		internal bool $disposing;

		// Token: 0x04004E07 RID: 19975
		internal int $PC;
	}
}
