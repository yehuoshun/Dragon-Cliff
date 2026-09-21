using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006C1 RID: 1729
public class Encouragement : ActiveSkillLogicBase
{
	// Token: 0x06002E44 RID: 11844 RVA: 0x00135AB0 File Offset: 0x00133EB0
	public Encouragement()
	{
	}

	// Token: 0x06002E45 RID: 11845 RVA: 0x00135AD4 File Offset: 0x00133ED4
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new TargetSelectionBuffTalent(SkillType.Encouragement, 1),
			new TargetSelectionBuffTalent(SkillType.Encouragement, 2),
			new TargetSelectionBuffTalent(SkillType.Encouragement, 3)
		};
	}

	// Token: 0x170005EE RID: 1518
	// (get) Token: 0x06002E46 RID: 11846 RVA: 0x00135B1B File Offset: 0x00133F1B
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005EF RID: 1519
	// (get) Token: 0x06002E47 RID: 11847 RVA: 0x00135B23 File Offset: 0x00133F23
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005F0 RID: 1520
	// (get) Token: 0x06002E48 RID: 11848 RVA: 0x00135B2B File Offset: 0x00133F2B
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005F1 RID: 1521
	// (get) Token: 0x06002E49 RID: 11849 RVA: 0x00135B33 File Offset: 0x00133F33
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002E4A RID: 11850 RVA: 0x00135B3B File Offset: 0x00133F3B
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<FriendlyAllStrategy>();
	}

	// Token: 0x06002E4B RID: 11851 RVA: 0x00135B42 File Offset: 0x00133F42
	public override double GetGaugeCost(Skill skill)
	{
		return 50.0;
	}

	// Token: 0x06002E4C RID: 11852 RVA: 0x00135B4D File Offset: 0x00133F4D
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002E4D RID: 11853 RVA: 0x00135B59 File Offset: 0x00133F59
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new FriendlyAllStrategy(skill);
	}

	// Token: 0x06002E4E RID: 11854 RVA: 0x00135B61 File Offset: 0x00133F61
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002E4F RID: 11855 RVA: 0x00135B68 File Offset: 0x00133F68
	private double ActiveEffectResistanceBoostRate(Skill skill)
	{
		return (double)(200 + (skill.Level - 1) * 200);
	}

	// Token: 0x06002E50 RID: 11856 RVA: 0x00135B7F File Offset: 0x00133F7F
	private float ActiveLastingSeconds(Skill skill)
	{
		return 10f;
	}

	// Token: 0x06002E51 RID: 11857 RVA: 0x00135B86 File Offset: 0x00133F86
	private double PassiveBoostRate(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.2;
	}

	// Token: 0x06002E52 RID: 11858 RVA: 0x00135BA8 File Offset: 0x00133FA8
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.LastingSecondsKey, this.ActiveLastingSeconds(skill).FloatToString()).Replace(this.BoostRateKey, this.ActiveEffectResistanceBoostRate(skill).ToExpression()).ToString();
		description.Details2 = description.Details2.Replace(this.BoostRateKey, this.PassiveBoostRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002E53 RID: 11859 RVA: 0x00135C18 File Offset: 0x00134018
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		foreach (IBattleUnit strategySelection in strategy.Selections)
		{
			IEnumerator enumerator2 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
			{
				new AttributeModifier
				{
					AttributeType = AttributeType.EffectResistanceRating,
					ModificationType = ModificationType.Addition,
					Value = this.ActiveEffectResistanceBoostRate(skill.Skill),
					Key = string.Empty,
					AttributeModifierType = AttributeModifierType.Skill
				}
			}, "encouragementunique", new int?(1), new float?(this.ActiveLastingSeconds(skill.Skill)), null, false, false, false), false).GetEnumerator();
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

	// Token: 0x06002E54 RID: 11860 RVA: 0x00135C4C File Offset: 0x0013404C
	public override IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		IEnumerator enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArmorEnhancementEffect(base.GetType().FullName + "passive", this.PassiveBoostRate(skill.Skill), ModificationType.Multiplication, null, null, skill), false).GetEnumerator();
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

	// Token: 0x06002E55 RID: 11861 RVA: 0x00135C78 File Offset: 0x00134078
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		List<AttributeModificationEffect> toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
		where ef.EffectSourceIdentityCode == base.GetType().FullName + "passive"
		select ef).ToList<AttributeModificationEffect>();
		foreach (AttributeModificationEffect effect in toRemove)
		{
			IEnumerator enumerator2 = skill.SourceUnit.LooseSkillEffect(effect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

	// Token: 0x04002702 RID: 9986
	private SkillCategory _skillCategory = SkillCategory.Defensive;

	// Token: 0x04002703 RID: 9987
	private OutputType _skillOutputType;

	// Token: 0x04002704 RID: 9988
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x04002705 RID: 9989
	private SkillType _skillType = SkillType.Encouragement;

	// Token: 0x02000E0A RID: 3594
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A50 RID: 23120 RVA: 0x00135CA2 File Offset: 0x001340A2
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005A51 RID: 23121 RVA: 0x00135CAC File Offset: 0x001340AC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = strategy.Selections.GetEnumerator();
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
					strategySelection = enumerator.Current;
					enumerator2 = strategySelection.ApplySkillEffect(AttributeModificationEffect.CreateArbitraryPostiveAttributeModificationEffect(skill.SourceUnit, new List<AttributeModifier>
					{
						new AttributeModifier
						{
							AttributeType = AttributeType.EffectResistanceRating,
							ModificationType = ModificationType.Addition,
							Value = base.ActiveEffectResistanceBoostRate(skill.Skill),
							Key = string.Empty,
							AttributeModifierType = AttributeModifierType.Skill
						}
					}, "encouragementunique", new int?(1), new float?(base.ActiveLastingSeconds(skill.Skill)), null, false, false, false), false).GetEnumerator();
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

		// Token: 0x170012D6 RID: 4822
		// (get) Token: 0x06005A52 RID: 23122 RVA: 0x00135EB8 File Offset: 0x001342B8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012D7 RID: 4823
		// (get) Token: 0x06005A53 RID: 23123 RVA: 0x00135EC0 File Offset: 0x001342C0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A54 RID: 23124 RVA: 0x00135EC8 File Offset: 0x001342C8
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

		// Token: 0x06005A55 RID: 23125 RVA: 0x00135F5C File Offset: 0x0013435C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A56 RID: 23126 RVA: 0x00135F63 File Offset: 0x00134363
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A57 RID: 23127 RVA: 0x00135F6C File Offset: 0x0013436C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Encouragement.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new Encouragement.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			<CastSkillLogic>c__Iterator.skill = skill;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x04004AE4 RID: 19172
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004AE5 RID: 19173
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004AE6 RID: 19174
		internal IBattleUnit <strategySelection>__1;

		// Token: 0x04004AE7 RID: 19175
		internal AdventureUnitSkill skill;

		// Token: 0x04004AE8 RID: 19176
		internal IEnumerator $locvar1;

		// Token: 0x04004AE9 RID: 19177
		internal object <_>__2;

		// Token: 0x04004AEA RID: 19178
		internal IDisposable $locvar2;

		// Token: 0x04004AEB RID: 19179
		internal Encouragement $this;

		// Token: 0x04004AEC RID: 19180
		internal object $current;

		// Token: 0x04004AED RID: 19181
		internal bool $disposing;

		// Token: 0x04004AEE RID: 19182
		internal int $PC;
	}

	// Token: 0x02000E0B RID: 3595
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A58 RID: 23128 RVA: 0x00135FB8 File Offset: 0x001343B8
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator1()
		{
		}

		// Token: 0x06005A59 RID: 23129 RVA: 0x00135FC0 File Offset: 0x001343C0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = skill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateArmorEnhancementEffect(base.GetType().FullName + "passive", base.PassiveBoostRate(skill.Skill), ModificationType.Multiplication, null, null, skill), false).GetEnumerator();
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

		// Token: 0x170012D8 RID: 4824
		// (get) Token: 0x06005A5A RID: 23130 RVA: 0x001360FC File Offset: 0x001344FC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012D9 RID: 4825
		// (get) Token: 0x06005A5B RID: 23131 RVA: 0x00136104 File Offset: 0x00134504
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A5C RID: 23132 RVA: 0x0013610C File Offset: 0x0013450C
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

		// Token: 0x06005A5D RID: 23133 RVA: 0x0013617C File Offset: 0x0013457C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A5E RID: 23134 RVA: 0x00136183 File Offset: 0x00134583
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A5F RID: 23135 RVA: 0x0013618C File Offset: 0x0013458C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Encouragement.<PassiveEffectApplies>c__Iterator1 <PassiveEffectApplies>c__Iterator = new Encouragement.<PassiveEffectApplies>c__Iterator1();
			<PassiveEffectApplies>c__Iterator.$this = this;
			<PassiveEffectApplies>c__Iterator.skill = skill;
			return <PassiveEffectApplies>c__Iterator;
		}

		// Token: 0x04004AEF RID: 19183
		internal AdventureUnitSkill skill;

		// Token: 0x04004AF0 RID: 19184
		internal IEnumerator $locvar0;

		// Token: 0x04004AF1 RID: 19185
		internal object <_>__1;

		// Token: 0x04004AF2 RID: 19186
		internal IDisposable $locvar1;

		// Token: 0x04004AF3 RID: 19187
		internal Encouragement $this;

		// Token: 0x04004AF4 RID: 19188
		internal object $current;

		// Token: 0x04004AF5 RID: 19189
		internal bool $disposing;

		// Token: 0x04004AF6 RID: 19190
		internal int $PC;
	}

	// Token: 0x02000E0C RID: 3596
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A60 RID: 23136 RVA: 0x001361CC File Offset: 0x001345CC
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator2()
		{
		}

		// Token: 0x06005A61 RID: 23137 RVA: 0x001361D4 File Offset: 0x001345D4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AttributeModificationEffect>()
				where ef.EffectSourceIdentityCode == base.GetType().FullName + "passive"
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
					effect = enumerator.Current;
					enumerator2 = skill.SourceUnit.LooseSkillEffect(effect, EffectWearsOffType.EffectTriggerInEffected).GetEnumerator();
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

		// Token: 0x170012DA RID: 4826
		// (get) Token: 0x06005A62 RID: 23138 RVA: 0x00136364 File Offset: 0x00134764
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012DB RID: 4827
		// (get) Token: 0x06005A63 RID: 23139 RVA: 0x0013636C File Offset: 0x0013476C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A64 RID: 23140 RVA: 0x00136374 File Offset: 0x00134774
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

		// Token: 0x06005A65 RID: 23141 RVA: 0x00136408 File Offset: 0x00134808
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A66 RID: 23142 RVA: 0x0013640F File Offset: 0x0013480F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A67 RID: 23143 RVA: 0x00136418 File Offset: 0x00134818
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Encouragement.<PassiveEffectLooses>c__Iterator2 <PassiveEffectLooses>c__Iterator = new Encouragement.<PassiveEffectLooses>c__Iterator2();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x06005A68 RID: 23144 RVA: 0x00136458 File Offset: 0x00134858
		internal bool <>m__0(AttributeModificationEffect ef)
		{
			return ef.EffectSourceIdentityCode == base.GetType().FullName + "passive";
		}

		// Token: 0x04004AF7 RID: 19191
		internal AdventureUnitSkill skill;

		// Token: 0x04004AF8 RID: 19192
		internal List<AttributeModificationEffect> <toRemove>__0;

		// Token: 0x04004AF9 RID: 19193
		internal List<AttributeModificationEffect>.Enumerator $locvar0;

		// Token: 0x04004AFA RID: 19194
		internal AttributeModificationEffect <effect>__1;

		// Token: 0x04004AFB RID: 19195
		internal IEnumerator $locvar1;

		// Token: 0x04004AFC RID: 19196
		internal object <_>__2;

		// Token: 0x04004AFD RID: 19197
		internal IDisposable $locvar2;

		// Token: 0x04004AFE RID: 19198
		internal Encouragement $this;

		// Token: 0x04004AFF RID: 19199
		internal object $current;

		// Token: 0x04004B00 RID: 19200
		internal bool $disposing;

		// Token: 0x04004B01 RID: 19201
		internal int $PC;
	}
}
