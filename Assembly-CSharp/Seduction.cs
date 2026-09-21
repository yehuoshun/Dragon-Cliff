using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006CB RID: 1739
public class Seduction : ActiveSkillLogicBase
{
	// Token: 0x06002EF8 RID: 12024 RVA: 0x0013E9C1 File Offset: 0x0013CDC1
	public Seduction()
	{
	}

	// Token: 0x06002EF9 RID: 12025 RVA: 0x0013E9E4 File Offset: 0x0013CDE4
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new SeductionExtraTargetTalent(SkillType.Seduction, 1),
			new SeductionDecayTalent(SkillType.Seduction, 2),
			new SeductionCleanTalent(SkillType.Seduction, 3)
		};
	}

	// Token: 0x17000616 RID: 1558
	// (get) Token: 0x06002EFA RID: 12026 RVA: 0x0013EA2B File Offset: 0x0013CE2B
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x17000617 RID: 1559
	// (get) Token: 0x06002EFB RID: 12027 RVA: 0x0013EA33 File Offset: 0x0013CE33
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x17000618 RID: 1560
	// (get) Token: 0x06002EFC RID: 12028 RVA: 0x0013EA3B File Offset: 0x0013CE3B
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x17000619 RID: 1561
	// (get) Token: 0x06002EFD RID: 12029 RVA: 0x0013EA43 File Offset: 0x0013CE43
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002EFE RID: 12030 RVA: 0x0013EA4B File Offset: 0x0013CE4B
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<HostileSingleStrategy>();
	}

	// Token: 0x06002EFF RID: 12031 RVA: 0x0013EA52 File Offset: 0x0013CE52
	public override double GetGaugeCost(Skill skill)
	{
		return 40.0;
	}

	// Token: 0x06002F00 RID: 12032 RVA: 0x0013EA5D File Offset: 0x0013CE5D
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002F01 RID: 12033 RVA: 0x0013EA69 File Offset: 0x0013CE69
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new HostileSingleStrategy(skill);
	}

	// Token: 0x06002F02 RID: 12034 RVA: 0x0013EA71 File Offset: 0x0013CE71
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002F03 RID: 12035 RVA: 0x0013EA78 File Offset: 0x0013CE78
	private float ActiveLastingSeconds(Skill skill)
	{
		return (float)(skill.Level * 2);
	}

	// Token: 0x06002F04 RID: 12036 RVA: 0x0013EA83 File Offset: 0x0013CE83
	private double PassiveBoostRate(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06002F05 RID: 12037 RVA: 0x0013EAA4 File Offset: 0x0013CEA4
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.LastingSecondsKey, Convert.ToInt32(this.ActiveLastingSeconds(skill)).ToString());
		description.Details2 = description.Details2.Replace(this.BoostRateKey, this.PassiveBoostRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002F06 RID: 12038 RVA: 0x0013EB08 File Offset: 0x0013CF08
	public override IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		IEnumerator enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateIntelligienceBoostEffect(base.GetType().FullName, this.PassiveBoostRate(skill.Skill), null, null, skill), false).GetEnumerator();
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

	// Token: 0x06002F07 RID: 12039 RVA: 0x0013EB34 File Offset: 0x0013CF34
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		List<AttributeModificationEffect> toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
		where ef.EffectSourceIdentityCode == base.GetType().FullName
		select ef).ToList<AttributeModificationEffect>();
		foreach (AttributeModificationEffect intelligienceBoostEffect in toRemove)
		{
			IEnumerator enumerator2 = skill.SourceUnit.LooseSkillEffect(intelligienceBoostEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

	// Token: 0x06002F08 RID: 12040 RVA: 0x0013EB60 File Offset: 0x0013CF60
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		SeductionExtraTargetData seductionExtraTarget = skill.SourceUnit.SpecialEffects.OfType<SeductionExtraTargetData>().FirstOrDefault<SeductionExtraTargetData>();
		if (seductionExtraTarget != null && strategy.Selections.Any<IBattleUnit>() && (double)UnityEngine.Random.value <= seductionExtraTarget.Chance)
		{
			List<IBattleUnit> list = (from u in strategy.Selections.First<IBattleUnit>().GetAllLiveFriendlyTargetsIncSelf(true)
			where u != strategy.Selections.First<IBattleUnit>()
			select u).ToList<IBattleUnit>();
			if (list.Any<IBattleUnit>())
			{
				strategy.Selections.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		SeductionAttributeDecayEnhancementData attributeDecayEnhancement = skill.SourceUnit.SpecialEffects.OfType<SeductionAttributeDecayEnhancementData>().FirstOrDefault<SeductionAttributeDecayEnhancementData>();
		foreach (IBattleUnit strategySelection in strategy.Selections)
		{
			IEnumerator enumerator2 = LockTimeEffect.AddStunSeconds(strategySelection, this.ActiveLastingSeconds(skill.Skill), skill, true).GetEnumerator();
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
			if (attributeDecayEnhancement != null)
			{
				IEnumerator enumerator3 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
				{
					new AttributeModifier
					{
						AttributeType = attributeDecayEnhancement.Type,
						ModificationType = attributeDecayEnhancement.ModificationType,
						Value = -attributeDecayEnhancement.Rate,
						Key = string.Empty,
						AttributeModifierType = AttributeModifierType.Skill
					}
				}, "seductionattributedecay", new int?(1), new float?((float)attributeDecayEnhancement.Seconds), null, true, true), false).GetEnumerator();
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
				IEnumerator enumerator4 = UnitStyleConfigurationBase.DispelPositiveEffects(strategySelection, null).GetEnumerator();
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
		if (skill.SourceUnit.SpecialEffects.OfType<SeductionSelfCleanEnhancementData>().Any<SeductionSelfCleanEnhancementData>())
		{
			IEnumerator enumerator5 = UnitStyleConfigurationBase.DispelNegativeEffects(skill.SourceUnit, null).GetEnumerator();
			try
			{
				while (enumerator5.MoveNext())
				{
					object _4 = enumerator5.Current;
					yield return _4;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator5 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x0400272E RID: 10030
	private SkillCategory _skillCategory = SkillCategory.Supportive;

	// Token: 0x0400272F RID: 10031
	private OutputType _skillOutputType;

	// Token: 0x04002730 RID: 10032
	private TargetingType _targetingType = TargetingType.Single;

	// Token: 0x04002731 RID: 10033
	private SkillType _skillType = SkillType.Seduction;

	// Token: 0x02000E28 RID: 3624
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B2F RID: 23343 RVA: 0x0013EB91 File Offset: 0x0013CF91
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator0()
		{
		}

		// Token: 0x06005B30 RID: 23344 RVA: 0x0013EB9C File Offset: 0x0013CF9C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateIntelligienceBoostEffect(base.GetType().FullName, base.PassiveBoostRate(skill.Skill), null, null, skill), false).GetEnumerator();
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

		// Token: 0x17001308 RID: 4872
		// (get) Token: 0x06005B31 RID: 23345 RVA: 0x0013ECCC File Offset: 0x0013D0CC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001309 RID: 4873
		// (get) Token: 0x06005B32 RID: 23346 RVA: 0x0013ECD4 File Offset: 0x0013D0D4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B33 RID: 23347 RVA: 0x0013ECDC File Offset: 0x0013D0DC
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

		// Token: 0x06005B34 RID: 23348 RVA: 0x0013ED4C File Offset: 0x0013D14C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B35 RID: 23349 RVA: 0x0013ED53 File Offset: 0x0013D153
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B36 RID: 23350 RVA: 0x0013ED5C File Offset: 0x0013D15C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Seduction.<PassiveEffectApplies>c__Iterator0 <PassiveEffectApplies>c__Iterator = new Seduction.<PassiveEffectApplies>c__Iterator0();
			<PassiveEffectApplies>c__Iterator.$this = this;
			<PassiveEffectApplies>c__Iterator.skill = skill;
			return <PassiveEffectApplies>c__Iterator;
		}

		// Token: 0x04004CAB RID: 19627
		internal AdventureUnitSkill skill;

		// Token: 0x04004CAC RID: 19628
		internal IEnumerator $locvar0;

		// Token: 0x04004CAD RID: 19629
		internal object <_>__1;

		// Token: 0x04004CAE RID: 19630
		internal IDisposable $locvar1;

		// Token: 0x04004CAF RID: 19631
		internal Seduction $this;

		// Token: 0x04004CB0 RID: 19632
		internal object $current;

		// Token: 0x04004CB1 RID: 19633
		internal bool $disposing;

		// Token: 0x04004CB2 RID: 19634
		internal int $PC;
	}

	// Token: 0x02000E29 RID: 3625
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B37 RID: 23351 RVA: 0x0013ED9C File Offset: 0x0013D19C
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator1()
		{
		}

		// Token: 0x06005B38 RID: 23352 RVA: 0x0013EDA4 File Offset: 0x0013D1A4
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
					intelligienceBoostEffect = enumerator.Current;
					enumerator2 = skill.SourceUnit.LooseSkillEffect(intelligienceBoostEffect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

		// Token: 0x1700130A RID: 4874
		// (get) Token: 0x06005B39 RID: 23353 RVA: 0x0013EF34 File Offset: 0x0013D334
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700130B RID: 4875
		// (get) Token: 0x06005B3A RID: 23354 RVA: 0x0013EF3C File Offset: 0x0013D33C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B3B RID: 23355 RVA: 0x0013EF44 File Offset: 0x0013D344
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

		// Token: 0x06005B3C RID: 23356 RVA: 0x0013EFD8 File Offset: 0x0013D3D8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B3D RID: 23357 RVA: 0x0013EFDF File Offset: 0x0013D3DF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B3E RID: 23358 RVA: 0x0013EFE8 File Offset: 0x0013D3E8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Seduction.<PassiveEffectLooses>c__Iterator1 <PassiveEffectLooses>c__Iterator = new Seduction.<PassiveEffectLooses>c__Iterator1();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x06005B3F RID: 23359 RVA: 0x0013F028 File Offset: 0x0013D428
		internal bool <>m__0(AttributeModificationEffect ef)
		{
			return ef.EffectSourceIdentityCode == base.GetType().FullName;
		}

		// Token: 0x04004CB3 RID: 19635
		internal AdventureUnitSkill skill;

		// Token: 0x04004CB4 RID: 19636
		internal List<AttributeModificationEffect> <toRemove>__0;

		// Token: 0x04004CB5 RID: 19637
		internal List<AttributeModificationEffect>.Enumerator $locvar0;

		// Token: 0x04004CB6 RID: 19638
		internal AttributeModificationEffect <intelligienceBoostEffect>__1;

		// Token: 0x04004CB7 RID: 19639
		internal IEnumerator $locvar1;

		// Token: 0x04004CB8 RID: 19640
		internal object <_>__2;

		// Token: 0x04004CB9 RID: 19641
		internal IDisposable $locvar2;

		// Token: 0x04004CBA RID: 19642
		internal Seduction $this;

		// Token: 0x04004CBB RID: 19643
		internal object $current;

		// Token: 0x04004CBC RID: 19644
		internal bool $disposing;

		// Token: 0x04004CBD RID: 19645
		internal int $PC;
	}

	// Token: 0x02000E2A RID: 3626
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005B40 RID: 23360 RVA: 0x0013F045 File Offset: 0x0013D445
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator2()
		{
		}

		// Token: 0x06005B41 RID: 23361 RVA: 0x0013F050 File Offset: 0x0013D450
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				seductionExtraTarget = skill.SourceUnit.SpecialEffects.OfType<SeductionExtraTargetData>().FirstOrDefault<SeductionExtraTargetData>();
				if (seductionExtraTarget != null && strategy.Selections.Any<IBattleUnit>() && (double)UnityEngine.Random.value <= seductionExtraTarget.Chance)
				{
					List<IBattleUnit> list = (from u in strategy.Selections.First<IBattleUnit>().GetAllLiveFriendlyTargetsIncSelf(true)
					where u != strategy.Selections.First<IBattleUnit>()
					select u).ToList<IBattleUnit>();
					if (list.Any<IBattleUnit>())
					{
						strategy.Selections.Add(list[UnityEngine.Random.Range(0, list.Count)]);
					}
				}
				attributeDecayEnhancement = skill.SourceUnit.SpecialEffects.OfType<SeductionAttributeDecayEnhancementData>().FirstOrDefault<SeductionAttributeDecayEnhancementData>();
				enumerator = strategy.Selections.GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
			case 2u:
			case 3u:
				break;
			case 4u:
				goto IL_49A;
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
					if (attributeDecayEnhancement == null)
					{
						enumerator4 = UnitStyleConfigurationBase.DispelPositiveEffects(strategySelection, null).GetEnumerator();
						num = 4294967293u;
						goto Block_13;
					}
					enumerator3 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryNegativeAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = attributeDecayEnhancement.Type,
							ModificationType = attributeDecayEnhancement.ModificationType,
							Value = -attributeDecayEnhancement.Rate,
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "seductionattributedecay", new int?(1), new float?((float)attributeDecayEnhancement.Seconds), null, true, true), false).GetEnumerator();
					num = 4294967293u;
					break;
				case 2u:
					break;
				case 3u:
					goto IL_3A6;
				default:
					goto IL_428;
				}
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
				goto IL_428;
				Block_13:
				try
				{
					IL_3A6:
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
				IL_428:
				if (enumerator.MoveNext())
				{
					strategySelection = enumerator.Current;
					enumerator2 = LockTimeEffect.AddStunSeconds(strategySelection, base.ActiveLastingSeconds(skill.Skill), skill, true).GetEnumerator();
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
			if (!skill.SourceUnit.SpecialEffects.OfType<SeductionSelfCleanEnhancementData>().Any<SeductionSelfCleanEnhancementData>())
			{
				goto IL_51C;
			}
			enumerator5 = UnitStyleConfigurationBase.DispelNegativeEffects(skill.SourceUnit, null).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_49A:
				switch (num)
				{
				}
				if (enumerator5.MoveNext())
				{
					_4 = enumerator5.Current;
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
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
			}
			IL_51C:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700130C RID: 4876
		// (get) Token: 0x06005B42 RID: 23362 RVA: 0x0013F600 File Offset: 0x0013DA00
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700130D RID: 4877
		// (get) Token: 0x06005B43 RID: 23363 RVA: 0x0013F608 File Offset: 0x0013DA08
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005B44 RID: 23364 RVA: 0x0013F610 File Offset: 0x0013DA10
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
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator5 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005B45 RID: 23365 RVA: 0x0013F778 File Offset: 0x0013DB78
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005B46 RID: 23366 RVA: 0x0013F77F File Offset: 0x0013DB7F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005B47 RID: 23367 RVA: 0x0013F788 File Offset: 0x0013DB88
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Seduction.<CastSkillLogic>c__Iterator2 <CastSkillLogic>c__Iterator = new Seduction.<CastSkillLogic>c__Iterator2();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x04004CBE RID: 19646
		internal AdventureUnitSkill skill;

		// Token: 0x04004CBF RID: 19647
		internal SeductionExtraTargetData <seductionExtraTarget>__0;

		// Token: 0x04004CC0 RID: 19648
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004CC1 RID: 19649
		internal SeductionAttributeDecayEnhancementData <attributeDecayEnhancement>__0;

		// Token: 0x04004CC2 RID: 19650
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004CC3 RID: 19651
		internal IBattleUnit <strategySelection>__1;

		// Token: 0x04004CC4 RID: 19652
		internal IEnumerator $locvar1;

		// Token: 0x04004CC5 RID: 19653
		internal object <_>__2;

		// Token: 0x04004CC6 RID: 19654
		internal IDisposable $locvar2;

		// Token: 0x04004CC7 RID: 19655
		internal IEnumerator $locvar3;

		// Token: 0x04004CC8 RID: 19656
		internal object <_>__3;

		// Token: 0x04004CC9 RID: 19657
		internal IDisposable $locvar4;

		// Token: 0x04004CCA RID: 19658
		internal IEnumerator $locvar5;

		// Token: 0x04004CCB RID: 19659
		internal object <_>__4;

		// Token: 0x04004CCC RID: 19660
		internal IDisposable $locvar6;

		// Token: 0x04004CCD RID: 19661
		internal IEnumerator $locvar7;

		// Token: 0x04004CCE RID: 19662
		internal object <_>__5;

		// Token: 0x04004CCF RID: 19663
		internal IDisposable $locvar8;

		// Token: 0x04004CD0 RID: 19664
		internal Seduction $this;

		// Token: 0x04004CD1 RID: 19665
		internal object $current;

		// Token: 0x04004CD2 RID: 19666
		internal bool $disposing;

		// Token: 0x04004CD3 RID: 19667
		internal int $PC;

		// Token: 0x04004CD4 RID: 19668
		private Seduction.<CastSkillLogic>c__Iterator2.<CastSkillLogic>c__AnonStorey3 $locvar9;

		// Token: 0x02000E2B RID: 3627
		private sealed class <CastSkillLogic>c__AnonStorey3
		{
			// Token: 0x06005B48 RID: 23368 RVA: 0x0013F7D4 File Offset: 0x0013DBD4
			public <CastSkillLogic>c__AnonStorey3()
			{
			}

			// Token: 0x06005B49 RID: 23369 RVA: 0x0013F7DC File Offset: 0x0013DBDC
			internal bool <>m__0(IBattleUnit u)
			{
				return u != this.strategy.Selections.First<IBattleUnit>();
			}

			// Token: 0x04004CD5 RID: 19669
			internal ActiveSkillTargetingStrategyBase strategy;

			// Token: 0x04004CD6 RID: 19670
			internal Seduction.<CastSkillLogic>c__Iterator2 <>f__ref$2;
		}
	}
}
