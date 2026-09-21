using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006C0 RID: 1728
public class EmbracedShield : ActiveSkillLogicBase
{
	// Token: 0x06002E33 RID: 11827 RVA: 0x00135318 File Offset: 0x00133718
	public EmbracedShield()
	{
	}

	// Token: 0x06002E34 RID: 11828 RVA: 0x0013533C File Offset: 0x0013373C
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new EmbracedShieldExtraTalent(SkillType.EmbracedShield, 1),
			new EmbracedShieldDispelTalent(SkillType.EmbracedShield, 2),
			new EmbracedShieldStunTalent(SkillType.EmbracedShield, 3)
		};
	}

	// Token: 0x170005EA RID: 1514
	// (get) Token: 0x06002E35 RID: 11829 RVA: 0x00135383 File Offset: 0x00133783
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005EB RID: 1515
	// (get) Token: 0x06002E36 RID: 11830 RVA: 0x0013538B File Offset: 0x0013378B
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005EC RID: 1516
	// (get) Token: 0x06002E37 RID: 11831 RVA: 0x00135393 File Offset: 0x00133793
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005ED RID: 1517
	// (get) Token: 0x06002E38 RID: 11832 RVA: 0x0013539B File Offset: 0x0013379B
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002E39 RID: 11833 RVA: 0x001353A3 File Offset: 0x001337A3
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<FriendlyOrderbyStrategy>();
	}

	// Token: 0x06002E3A RID: 11834 RVA: 0x001353AA File Offset: 0x001337AA
	public override double GetGaugeCost(Skill skill)
	{
		return 60.0;
	}

	// Token: 0x06002E3B RID: 11835 RVA: 0x001353B5 File Offset: 0x001337B5
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002E3C RID: 11836 RVA: 0x001353C1 File Offset: 0x001337C1
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new FriendlyOrderbyStrategy(skill, this.MaxNumberOfShields(skill.Skill), (IBattleUnit u) => u.HealthPoints / u.GetMaxLife(AttributeRetrievalLevel.Skill), true);
	}

	// Token: 0x06002E3D RID: 11837 RVA: 0x001353F3 File Offset: 0x001337F3
	private int MaxNumberOfShields(Skill skill)
	{
		return 2 + skill.Level;
	}

	// Token: 0x06002E3E RID: 11838 RVA: 0x00135400 File Offset: 0x00133800
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.NumberOfActiveShields, this.MaxNumberOfShields(skill).ToString());
		description.Details2 = description.Details2.Replace(this.PossibilityKey, this.PassiveChance(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002E3F RID: 11839 RVA: 0x00135460 File Offset: 0x00133860
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		List<IBattleUnit> candidates = strategy.Selections;
		foreach (IBattleUnit battleUnit in candidates)
		{
			int i = 0;
			for (;;)
			{
				if (i >= 3 + skill.SourceUnit.SpecialEffects.OfType<EmbracedShieldNumberEnhancementData>().Sum((EmbracedShieldNumberEnhancementData s) => s.Extra))
				{
					break;
				}
				IEnumerator enumerator2 = battleUnit.ApplySkillEffect(new ReflectiveShieldEffect(base.GetType().FullName, new int?(1), skill), false).GetEnumerator();
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
				i++;
			}
		}
		yield break;
	}

	// Token: 0x06002E40 RID: 11840 RVA: 0x00135491 File Offset: 0x00133891
	private double PassiveChance(Skill skill)
	{
		return 0.3 + (double)(skill.Level - 1) * 0.2;
	}

	// Token: 0x06002E41 RID: 11841 RVA: 0x001354B0 File Offset: 0x001338B0
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitRegularTurnStarts
		};
	}

	// Token: 0x06002E42 RID: 11842 RVA: 0x001354CC File Offset: 0x001338CC
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventTriggerUnit == skillOwner && eventType == AdventureEventType.UnitRegularTurnStarts)
		{
			List<IBattleUnit> friendlyUnits = skillOwner.GetAllLiveFriendlyTargetsIncSelf(true);
			if ((double)UnityEngine.Random.value <= this.PassiveChance(processingSkill.Skill) && friendlyUnits.Any<IBattleUnit>())
			{
				IBattleUnit selected = friendlyUnits[UnityEngine.Random.Range(0, friendlyUnits.Count)];
				IEnumerator enumerator = selected.ApplySkillEffect(new ReflectiveShieldEffect(base.GetType().FullName, new int?(1), processingSkill), false).GetEnumerator();
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

	// Token: 0x06002E43 RID: 11843 RVA: 0x0013550C File Offset: 0x0013390C
	[CompilerGenerated]
	private static double <InitiatingTargetingStrategy>m__0(IBattleUnit u)
	{
		return u.HealthPoints / u.GetMaxLife(AttributeRetrievalLevel.Skill);
	}

	// Token: 0x040026FD RID: 9981
	private SkillCategory _skillCategory = SkillCategory.Defensive;

	// Token: 0x040026FE RID: 9982
	private OutputType _skillOutputType;

	// Token: 0x040026FF RID: 9983
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x04002700 RID: 9984
	private SkillType _skillType = SkillType.EmbracedShield;

	// Token: 0x04002701 RID: 9985
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cache0;

	// Token: 0x02000E08 RID: 3592
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A3F RID: 23103 RVA: 0x0013551C File Offset: 0x0013391C
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator0()
		{
		}

		// Token: 0x06005A40 RID: 23104 RVA: 0x00135524 File Offset: 0x00133924
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				candidates = strategy.Selections;
				enumerator = candidates.GetEnumerator();
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
					i++;
					break;
				default:
					goto IL_185;
				}
				IL_141:
				if (i < 3 + skill.SourceUnit.SpecialEffects.OfType<EmbracedShieldNumberEnhancementData>().Sum((EmbracedShieldNumberEnhancementData s) => s.Extra))
				{
					enumerator2 = battleUnit.ApplySkillEffect(new ReflectiveShieldEffect(base.GetType().FullName, new int?(1), skill), false).GetEnumerator();
					num = 4294967293u;
					goto Block_4;
				}
				IL_185:
				if (enumerator.MoveNext())
				{
					battleUnit = enumerator.Current;
					i = 0;
					goto IL_141;
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

		// Token: 0x170012D2 RID: 4818
		// (get) Token: 0x06005A41 RID: 23105 RVA: 0x00135720 File Offset: 0x00133B20
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012D3 RID: 4819
		// (get) Token: 0x06005A42 RID: 23106 RVA: 0x00135728 File Offset: 0x00133B28
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A43 RID: 23107 RVA: 0x00135730 File Offset: 0x00133B30
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

		// Token: 0x06005A44 RID: 23108 RVA: 0x001357C4 File Offset: 0x00133BC4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A45 RID: 23109 RVA: 0x001357CB File Offset: 0x00133BCB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A46 RID: 23110 RVA: 0x001357D4 File Offset: 0x00133BD4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EmbracedShield.<CastSkillLogic>c__Iterator0 <CastSkillLogic>c__Iterator = new EmbracedShield.<CastSkillLogic>c__Iterator0();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			<CastSkillLogic>c__Iterator.skill = skill;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x06005A47 RID: 23111 RVA: 0x00135820 File Offset: 0x00133C20
		private static int <>m__0(EmbracedShieldNumberEnhancementData s)
		{
			return s.Extra;
		}

		// Token: 0x04004AC9 RID: 19145
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004ACA RID: 19146
		internal List<IBattleUnit> <candidates>__0;

		// Token: 0x04004ACB RID: 19147
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004ACC RID: 19148
		internal IBattleUnit <battleUnit>__1;

		// Token: 0x04004ACD RID: 19149
		internal int <i>__2;

		// Token: 0x04004ACE RID: 19150
		internal AdventureUnitSkill skill;

		// Token: 0x04004ACF RID: 19151
		internal IEnumerator $locvar1;

		// Token: 0x04004AD0 RID: 19152
		internal object <_>__3;

		// Token: 0x04004AD1 RID: 19153
		internal IDisposable $locvar2;

		// Token: 0x04004AD2 RID: 19154
		internal EmbracedShield $this;

		// Token: 0x04004AD3 RID: 19155
		internal object $current;

		// Token: 0x04004AD4 RID: 19156
		internal bool $disposing;

		// Token: 0x04004AD5 RID: 19157
		internal int $PC;

		// Token: 0x04004AD6 RID: 19158
		private static Func<EmbracedShieldNumberEnhancementData, int> <>f__am$cache0;
	}

	// Token: 0x02000E09 RID: 3593
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A48 RID: 23112 RVA: 0x00135828 File Offset: 0x00133C28
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator1()
		{
		}

		// Token: 0x06005A49 RID: 23113 RVA: 0x00135830 File Offset: 0x00133C30
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventTriggerUnit != skillOwner || eventType != AdventureEventType.UnitRegularTurnStarts)
				{
					goto IL_162;
				}
				friendlyUnits = skillOwner.GetAllLiveFriendlyTargetsIncSelf(true);
				if ((double)UnityEngine.Random.value > base.PassiveChance(processingSkill.Skill) || !friendlyUnits.Any<IBattleUnit>())
				{
					goto IL_162;
				}
				selected = friendlyUnits[UnityEngine.Random.Range(0, friendlyUnits.Count)];
				enumerator = selected.ApplySkillEffect(new ReflectiveShieldEffect(base.GetType().FullName, new int?(1), processingSkill), false).GetEnumerator();
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
			IL_162:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012D4 RID: 4820
		// (get) Token: 0x06005A4A RID: 23114 RVA: 0x001359BC File Offset: 0x00133DBC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012D5 RID: 4821
		// (get) Token: 0x06005A4B RID: 23115 RVA: 0x001359C4 File Offset: 0x00133DC4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A4C RID: 23116 RVA: 0x001359CC File Offset: 0x00133DCC
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

		// Token: 0x06005A4D RID: 23117 RVA: 0x00135A3C File Offset: 0x00133E3C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A4E RID: 23118 RVA: 0x00135A43 File Offset: 0x00133E43
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A4F RID: 23119 RVA: 0x00135A4C File Offset: 0x00133E4C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			EmbracedShield.<PassiveBeingActiveEventProcess>c__Iterator1 <PassiveBeingActiveEventProcess>c__Iterator = new EmbracedShield.<PassiveBeingActiveEventProcess>c__Iterator1();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<PassiveBeingActiveEventProcess>c__Iterator.skillOwner = skillOwner;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x04004AD7 RID: 19159
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004AD8 RID: 19160
		internal IBattleUnit skillOwner;

		// Token: 0x04004AD9 RID: 19161
		internal AdventureEventType eventType;

		// Token: 0x04004ADA RID: 19162
		internal List<IBattleUnit> <friendlyUnits>__1;

		// Token: 0x04004ADB RID: 19163
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004ADC RID: 19164
		internal IBattleUnit <selected>__2;

		// Token: 0x04004ADD RID: 19165
		internal IEnumerator $locvar0;

		// Token: 0x04004ADE RID: 19166
		internal object <_>__3;

		// Token: 0x04004ADF RID: 19167
		internal IDisposable $locvar1;

		// Token: 0x04004AE0 RID: 19168
		internal EmbracedShield $this;

		// Token: 0x04004AE1 RID: 19169
		internal object $current;

		// Token: 0x04004AE2 RID: 19170
		internal bool $disposing;

		// Token: 0x04004AE3 RID: 19171
		internal int $PC;
	}
}
