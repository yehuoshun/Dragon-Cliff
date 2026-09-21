using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006BE RID: 1726
public class Drunkenness : ActiveSkillLogicBase
{
	// Token: 0x06002E14 RID: 11796 RVA: 0x00134604 File Offset: 0x00132A04
	public Drunkenness()
	{
	}

	// Token: 0x06002E15 RID: 11797 RVA: 0x00134628 File Offset: 0x00132A28
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new DrunknessExtraEnhancementTalent(SkillType.Drunkenness, 1),
			new TargetSelectionBuffTalent(SkillType.Drunkenness, 2),
			new TargetSelectionBuffTalent(SkillType.Drunkenness, 3)
		};
	}

	// Token: 0x170005E2 RID: 1506
	// (get) Token: 0x06002E16 RID: 11798 RVA: 0x0013466F File Offset: 0x00132A6F
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005E3 RID: 1507
	// (get) Token: 0x06002E17 RID: 11799 RVA: 0x00134677 File Offset: 0x00132A77
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005E4 RID: 1508
	// (get) Token: 0x06002E18 RID: 11800 RVA: 0x0013467F File Offset: 0x00132A7F
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005E5 RID: 1509
	// (get) Token: 0x06002E19 RID: 11801 RVA: 0x00134687 File Offset: 0x00132A87
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002E1A RID: 11802 RVA: 0x0013468F File Offset: 0x00132A8F
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<FriendlyAllStrategy>();
	}

	// Token: 0x06002E1B RID: 11803 RVA: 0x00134696 File Offset: 0x00132A96
	public override double GetGaugeCost(Skill skill)
	{
		return 40.0;
	}

	// Token: 0x06002E1C RID: 11804 RVA: 0x001346A1 File Offset: 0x00132AA1
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002E1D RID: 11805 RVA: 0x001346AD File Offset: 0x00132AAD
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new FriendlyAllStrategy(skill);
	}

	// Token: 0x06002E1E RID: 11806 RVA: 0x001346B5 File Offset: 0x00132AB5
	private int? GetNumberOfAdditionalTargets(Skill skill)
	{
		if (skill.Level == 1)
		{
			return new int?(1);
		}
		if (skill.Level == 2)
		{
			return new int?(2);
		}
		return new int?(3);
	}

	// Token: 0x06002E1F RID: 11807 RVA: 0x001346E4 File Offset: 0x00132AE4
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.NumberOfAdditionalTargets, this.GetNumberOfAdditionalTargets(skill).ToString());
		description.Details2 = description.Details2.Replace(this.PossibilityKey, this.PassiveChance(skill).ToExpressionMultiply100()).Replace(this.NumberOfAdditionalTargets, this.PassveNumberOfAdditionalTargets(skill).ToString());
		return description;
	}

	// Token: 0x06002E20 RID: 11808 RVA: 0x00134764 File Offset: 0x00132B64
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		foreach (IBattleUnit strategySelection in strategy.Selections)
		{
			IBattleUnit unit = strategySelection;
			string effectSourceIdentityCode = base.GetType().FullName + "active";
			float? maxNumberOfLastingSeconds = null;
			int? numberOfLastingTurns = new int?(2);
			int? numberOfAdditionalTargets = this.GetNumberOfAdditionalTargets(skill.Skill);
			int? additionalNumber;
			if (numberOfAdditionalTargets != null)
			{
				additionalNumber = new int?(numberOfAdditionalTargets.GetValueOrDefault() + skill.SourceUnit.SpecialEffects.OfType<DrunknessExtraTargetEnhancementData>().Sum((DrunknessExtraTargetEnhancementData s) => s.Extra));
			}
			else
			{
				additionalNumber = null;
			}
			IEnumerator enumerator2 = unit.ApplySkillEffect(new AdditionaTargetEffect(effectSourceIdentityCode, maxNumberOfLastingSeconds, numberOfLastingTurns, additionalNumber, skill), false).GetEnumerator();
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

	// Token: 0x06002E21 RID: 11809 RVA: 0x00134795 File Offset: 0x00132B95
	private double PassiveChance(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x06002E22 RID: 11810 RVA: 0x001347B4 File Offset: 0x00132BB4
	private int PassveNumberOfAdditionalTargets(Skill skill)
	{
		return 1;
	}

	// Token: 0x06002E23 RID: 11811 RVA: 0x001347B8 File Offset: 0x00132BB8
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitRegularTurnStarts
		};
	}

	// Token: 0x06002E24 RID: 11812 RVA: 0x001347D4 File Offset: 0x00132BD4
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitRegularTurnStarts && eventTriggerUnit == skillOwner && (double)UnityEngine.Random.value <= this.PassiveChance(processingSkill.Skill))
		{
			IEnumerator enumerator = skillOwner.ApplySkillEffect(new AdditionaTargetEffect(base.GetType().FullName + "passive", null, null, new int?(this.PassveNumberOfAdditionalTargets(processingSkill.Skill)), processingSkill), false).GetEnumerator();
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

	// Token: 0x06002E25 RID: 11813 RVA: 0x00134814 File Offset: 0x00132C14
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		List<AdditionaTargetEffect> toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AdditionaTargetEffect>()
		where ef.EffectSourceIdentityCode == base.GetType().FullName + "passive"
		select ef).ToList<AdditionaTargetEffect>();
		foreach (AdditionaTargetEffect remove in toRemove)
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

	// Token: 0x040026F4 RID: 9972
	private SkillCategory _skillCategory = SkillCategory.Supportive;

	// Token: 0x040026F5 RID: 9973
	private OutputType _skillOutputType;

	// Token: 0x040026F6 RID: 9974
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x040026F7 RID: 9975
	private SkillType _skillType = SkillType.Drunkenness;

	// Token: 0x02000E02 RID: 3586
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A0D RID: 23053 RVA: 0x0013483E File Offset: 0x00132C3E
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005A0E RID: 23054 RVA: 0x00134848 File Offset: 0x00132C48
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
					Block_6:
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
					IBattleUnit unit = strategySelection;
					string effectSourceIdentityCode = base.GetType().FullName + "active";
					float? maxNumberOfLastingSeconds = null;
					int? numberOfLastingTurns = new int?(2);
					int? numberOfAdditionalTargets = base.GetNumberOfAdditionalTargets(skill.Skill);
					int? additionalNumber;
					if (numberOfAdditionalTargets != null)
					{
						additionalNumber = new int?(numberOfAdditionalTargets.GetValueOrDefault() + skill.SourceUnit.SpecialEffects.OfType<DrunknessExtraTargetEnhancementData>().Sum((DrunknessExtraTargetEnhancementData s) => s.Extra));
					}
					else
					{
						additionalNumber = null;
					}
					enumerator2 = unit.ApplySkillEffect(new AdditionaTargetEffect(effectSourceIdentityCode, maxNumberOfLastingSeconds, numberOfLastingTurns, additionalNumber, skill), false).GetEnumerator();
					num = 4294967293u;
					goto Block_6;
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

		// Token: 0x170012C6 RID: 4806
		// (get) Token: 0x06005A0F RID: 23055 RVA: 0x00134A64 File Offset: 0x00132E64
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012C7 RID: 4807
		// (get) Token: 0x06005A10 RID: 23056 RVA: 0x00134A6C File Offset: 0x00132E6C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A11 RID: 23057 RVA: 0x00134A74 File Offset: 0x00132E74
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

		// Token: 0x06005A12 RID: 23058 RVA: 0x00134B08 File Offset: 0x00132F08
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A13 RID: 23059 RVA: 0x00134B0F File Offset: 0x00132F0F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A14 RID: 23060 RVA: 0x00134B18 File Offset: 0x00132F18
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Drunkenness.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new Drunkenness.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			<CastSkillLogic>c__Iterator.skill = skill;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x06005A15 RID: 23061 RVA: 0x00134B64 File Offset: 0x00132F64
		private static int <>m__0(DrunknessExtraTargetEnhancementData s)
		{
			return s.Extra;
		}

		// Token: 0x04004A9C RID: 19100
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004A9D RID: 19101
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004A9E RID: 19102
		internal IBattleUnit <strategySelection>__1;

		// Token: 0x04004A9F RID: 19103
		internal AdventureUnitSkill skill;

		// Token: 0x04004AA0 RID: 19104
		internal IEnumerator $locvar1;

		// Token: 0x04004AA1 RID: 19105
		internal object <_>__2;

		// Token: 0x04004AA2 RID: 19106
		internal IDisposable $locvar2;

		// Token: 0x04004AA3 RID: 19107
		internal Drunkenness $this;

		// Token: 0x04004AA4 RID: 19108
		internal object $current;

		// Token: 0x04004AA5 RID: 19109
		internal bool $disposing;

		// Token: 0x04004AA6 RID: 19110
		internal int $PC;

		// Token: 0x04004AA7 RID: 19111
		private static Func<DrunknessExtraTargetEnhancementData, int> <>f__am$cache0;
	}

	// Token: 0x02000E03 RID: 3587
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A16 RID: 23062 RVA: 0x00134B6C File Offset: 0x00132F6C
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator1()
		{
		}

		// Token: 0x06005A17 RID: 23063 RVA: 0x00134B74 File Offset: 0x00132F74
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitRegularTurnStarts || eventTriggerUnit != skillOwner || (double)UnityEngine.Random.value > base.PassiveChance(processingSkill.Skill))
				{
					goto IL_151;
				}
				enumerator = skillOwner.ApplySkillEffect(new AdditionaTargetEffect(base.GetType().FullName + "passive", null, null, new int?(base.PassveNumberOfAdditionalTargets(processingSkill.Skill)), processingSkill), false).GetEnumerator();
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
			IL_151:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012C8 RID: 4808
		// (get) Token: 0x06005A18 RID: 23064 RVA: 0x00134CEC File Offset: 0x001330EC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012C9 RID: 4809
		// (get) Token: 0x06005A19 RID: 23065 RVA: 0x00134CF4 File Offset: 0x001330F4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A1A RID: 23066 RVA: 0x00134CFC File Offset: 0x001330FC
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

		// Token: 0x06005A1B RID: 23067 RVA: 0x00134D6C File Offset: 0x0013316C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A1C RID: 23068 RVA: 0x00134D73 File Offset: 0x00133173
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A1D RID: 23069 RVA: 0x00134D7C File Offset: 0x0013317C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Drunkenness.<PassiveBeingActiveEventProcess>c__Iterator1 <PassiveBeingActiveEventProcess>c__Iterator = new Drunkenness.<PassiveBeingActiveEventProcess>c__Iterator1();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<PassiveBeingActiveEventProcess>c__Iterator.skillOwner = skillOwner;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x04004AA8 RID: 19112
		internal AdventureEventType eventType;

		// Token: 0x04004AA9 RID: 19113
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004AAA RID: 19114
		internal IBattleUnit skillOwner;

		// Token: 0x04004AAB RID: 19115
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004AAC RID: 19116
		internal IEnumerator $locvar0;

		// Token: 0x04004AAD RID: 19117
		internal object <_>__1;

		// Token: 0x04004AAE RID: 19118
		internal IDisposable $locvar1;

		// Token: 0x04004AAF RID: 19119
		internal Drunkenness $this;

		// Token: 0x04004AB0 RID: 19120
		internal object $current;

		// Token: 0x04004AB1 RID: 19121
		internal bool $disposing;

		// Token: 0x04004AB2 RID: 19122
		internal int $PC;
	}

	// Token: 0x02000E04 RID: 3588
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A1E RID: 23070 RVA: 0x00134DE0 File Offset: 0x001331E0
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator2()
		{
		}

		// Token: 0x06005A1F RID: 23071 RVA: 0x00134DE8 File Offset: 0x001331E8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				toRemove = (from ef in skill.SourceUnit.BattleEffects.OfType<AdditionaTargetEffect>()
				where ef.EffectSourceIdentityCode == base.GetType().FullName + "passive"
				select ef).ToList<AdditionaTargetEffect>();
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

		// Token: 0x170012CA RID: 4810
		// (get) Token: 0x06005A20 RID: 23072 RVA: 0x00134F78 File Offset: 0x00133378
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012CB RID: 4811
		// (get) Token: 0x06005A21 RID: 23073 RVA: 0x00134F80 File Offset: 0x00133380
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A22 RID: 23074 RVA: 0x00134F88 File Offset: 0x00133388
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

		// Token: 0x06005A23 RID: 23075 RVA: 0x0013501C File Offset: 0x0013341C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A24 RID: 23076 RVA: 0x00135023 File Offset: 0x00133423
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A25 RID: 23077 RVA: 0x0013502C File Offset: 0x0013342C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Drunkenness.<PassiveEffectLooses>c__Iterator2 <PassiveEffectLooses>c__Iterator = new Drunkenness.<PassiveEffectLooses>c__Iterator2();
			<PassiveEffectLooses>c__Iterator.$this = this;
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x06005A26 RID: 23078 RVA: 0x0013506C File Offset: 0x0013346C
		internal bool <>m__0(AdditionaTargetEffect ef)
		{
			return ef.EffectSourceIdentityCode == base.GetType().FullName + "passive";
		}

		// Token: 0x04004AB3 RID: 19123
		internal AdventureUnitSkill skill;

		// Token: 0x04004AB4 RID: 19124
		internal List<AdditionaTargetEffect> <toRemove>__0;

		// Token: 0x04004AB5 RID: 19125
		internal List<AdditionaTargetEffect>.Enumerator $locvar0;

		// Token: 0x04004AB6 RID: 19126
		internal AdditionaTargetEffect <remove>__1;

		// Token: 0x04004AB7 RID: 19127
		internal IEnumerator $locvar1;

		// Token: 0x04004AB8 RID: 19128
		internal object <_>__2;

		// Token: 0x04004AB9 RID: 19129
		internal IDisposable $locvar2;

		// Token: 0x04004ABA RID: 19130
		internal Drunkenness $this;

		// Token: 0x04004ABB RID: 19131
		internal object $current;

		// Token: 0x04004ABC RID: 19132
		internal bool $disposing;

		// Token: 0x04004ABD RID: 19133
		internal int $PC;
	}
}
