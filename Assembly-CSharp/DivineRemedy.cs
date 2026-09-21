using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x020006BD RID: 1725
public class DivineRemedy : ActiveSkillLogicBase
{
	// Token: 0x06002E04 RID: 11780 RVA: 0x00133E58 File Offset: 0x00132258
	public DivineRemedy()
	{
	}

	// Token: 0x06002E05 RID: 11781 RVA: 0x00133E84 File Offset: 0x00132284
	public override List<IAdventurerTalent> CreateSkillTalents()
	{
		return new List<IAdventurerTalent>
		{
			new TargetSelectionBuffTalent(SkillType.DivineRemedy, 1),
			new TargetSelectionBuffTalent(SkillType.DivineRemedy, 2),
			new TargetSelectionBuffTalent(SkillType.DivineRemedy, 3)
		};
	}

	// Token: 0x170005DE RID: 1502
	// (get) Token: 0x06002E06 RID: 11782 RVA: 0x00133ECB File Offset: 0x001322CB
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005DF RID: 1503
	// (get) Token: 0x06002E07 RID: 11783 RVA: 0x00133ED3 File Offset: 0x001322D3
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005E0 RID: 1504
	// (get) Token: 0x06002E08 RID: 11784 RVA: 0x00133EDB File Offset: 0x001322DB
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005E1 RID: 1505
	// (get) Token: 0x06002E09 RID: 11785 RVA: 0x00133EE3 File Offset: 0x001322E3
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002E0A RID: 11786 RVA: 0x00133EEB File Offset: 0x001322EB
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<FriendlyAllStrategy>();
	}

	// Token: 0x06002E0B RID: 11787 RVA: 0x00133EF2 File Offset: 0x001322F2
	public override double GetGaugeCost(Skill skill)
	{
		return 60.0;
	}

	// Token: 0x06002E0C RID: 11788 RVA: 0x00133EFD File Offset: 0x001322FD
	public override float? CoolingDownSeconds(Skill skill)
	{
		return new float?(1f);
	}

	// Token: 0x06002E0D RID: 11789 RVA: 0x00133F09 File Offset: 0x00132309
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new FriendlyAllStrategy(skill);
	}

	// Token: 0x06002E0E RID: 11790 RVA: 0x00133F11 File Offset: 0x00132311
	private double ActiveHealRate(Skill skill)
	{
		return 1.5 + (double)(skill.Level - 1) * 1.0;
	}

	// Token: 0x06002E0F RID: 11791 RVA: 0x00133F30 File Offset: 0x00132330
	private double PassiveHealRate(Skill skill)
	{
		return 0.2 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06002E10 RID: 11792 RVA: 0x00133F50 File Offset: 0x00132350
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.HealRateKey, this.ActiveHealRate(skill).ToExpressionMultiply100());
		description.Details2 = description.Details2.Replace(this.HealRateKey, this.PassiveHealRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06002E11 RID: 11793 RVA: 0x00133FA4 File Offset: 0x001323A4
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitRegularTurnStarts
		};
	}

	// Token: 0x06002E12 RID: 11794 RVA: 0x00133FC0 File Offset: 0x001323C0
	protected override IEnumerable PassiveBeingActiveEventProcess(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitRegularTurnStarts && eventTriggerUnit == skillOwner)
		{
			List<IBattleUnit> friendlyUnits = skillOwner.GetAllLiveFriendlyTargetsIncSelf(true);
			UnitOutputCapacity castp = skillOwner.GetOutputCapacity(AttributeRetrievalLevel.Skill);
			List<BattleHeal> heals = new List<BattleHeal>();
			foreach (IBattleUnit target in friendlyUnits)
			{
				heals.Add(new BattleHeal(target, processingSkill, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = castp.Value * this.PassiveHealRate(processingSkill.Skill),
						HealType = OutputType.Heal,
						IsDirectHeal = true
					}
				}, false));
			}
			ReleaseableHeal rs = new ReleaseableHeal(heals, skillOwner);
			IEnumerator enumerator2 = rs.Release().GetEnumerator();
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

	// Token: 0x06002E13 RID: 11795 RVA: 0x00134000 File Offset: 0x00132400
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		List<BattleHeal> heals = new List<BattleHeal>();
		UnitOutputCapacity casterp = skill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill);
		foreach (IBattleUnit target in strategy.Selections)
		{
			heals.Add(new BattleHeal(target, skill, new List<HealComponentValue>
			{
				new HealComponentValue
				{
					RawHeal = casterp.Value * this.ActiveHealRate(skill.Skill),
					HealType = OutputType.Heal,
					IsDirectHeal = true
				}
			}, false));
		}
		ReleaseableHeal rs = new ReleaseableHeal(heals, skill.SourceUnit);
		IEnumerator enumerator2 = rs.Release().GetEnumerator();
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
		yield break;
	}

	// Token: 0x040026F0 RID: 9968
	private SkillCategory _skillCategory = SkillCategory.Defensive;

	// Token: 0x040026F1 RID: 9969
	private OutputType _skillOutputType = OutputType.Heal;

	// Token: 0x040026F2 RID: 9970
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x040026F3 RID: 9971
	private SkillType _skillType = SkillType.DivineRemedy;

	// Token: 0x02000E00 RID: 3584
	[CompilerGenerated]
	private sealed class <PassiveBeingActiveEventProcess>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x060059FD RID: 23037 RVA: 0x00134031 File Offset: 0x00132431
		[DebuggerHidden]
		public <PassiveBeingActiveEventProcess>c__Iterator0()
		{
		}

		// Token: 0x060059FE RID: 23038 RVA: 0x0013403C File Offset: 0x0013243C
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
					goto IL_1D4;
				}
				friendlyUnits = skillOwner.GetAllLiveFriendlyTargetsIncSelf(true);
				castp = skillOwner.GetOutputCapacity(AttributeRetrievalLevel.Skill);
				heals = new List<BattleHeal>();
				enumerator = friendlyUnits.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						IBattleUnit target = enumerator.Current;
						heals.Add(new BattleHeal(target, processingSkill, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								RawHeal = castp.Value * base.PassiveHealRate(processingSkill.Skill),
								HealType = OutputType.Heal,
								IsDirectHeal = true
							}
						}, false));
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				rs = new ReleaseableHeal(heals, skillOwner);
				enumerator2 = rs.Release().GetEnumerator();
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
			IL_1D4:
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012C2 RID: 4802
		// (get) Token: 0x060059FF RID: 23039 RVA: 0x00134244 File Offset: 0x00132644
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012C3 RID: 4803
		// (get) Token: 0x06005A00 RID: 23040 RVA: 0x0013424C File Offset: 0x0013264C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A01 RID: 23041 RVA: 0x00134254 File Offset: 0x00132654
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
			}
		}

		// Token: 0x06005A02 RID: 23042 RVA: 0x001342C4 File Offset: 0x001326C4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A03 RID: 23043 RVA: 0x001342CB File Offset: 0x001326CB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A04 RID: 23044 RVA: 0x001342D4 File Offset: 0x001326D4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DivineRemedy.<PassiveBeingActiveEventProcess>c__Iterator0 <PassiveBeingActiveEventProcess>c__Iterator = new DivineRemedy.<PassiveBeingActiveEventProcess>c__Iterator0();
			<PassiveBeingActiveEventProcess>c__Iterator.$this = this;
			<PassiveBeingActiveEventProcess>c__Iterator.eventType = eventType;
			<PassiveBeingActiveEventProcess>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<PassiveBeingActiveEventProcess>c__Iterator.skillOwner = skillOwner;
			<PassiveBeingActiveEventProcess>c__Iterator.processingSkill = processingSkill;
			return <PassiveBeingActiveEventProcess>c__Iterator;
		}

		// Token: 0x04004A7F RID: 19071
		internal AdventureEventType eventType;

		// Token: 0x04004A80 RID: 19072
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04004A81 RID: 19073
		internal IBattleUnit skillOwner;

		// Token: 0x04004A82 RID: 19074
		internal List<IBattleUnit> <friendlyUnits>__1;

		// Token: 0x04004A83 RID: 19075
		internal UnitOutputCapacity <castp>__1;

		// Token: 0x04004A84 RID: 19076
		internal List<BattleHeal> <heals>__1;

		// Token: 0x04004A85 RID: 19077
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004A86 RID: 19078
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04004A87 RID: 19079
		internal ReleaseableHeal <rs>__1;

		// Token: 0x04004A88 RID: 19080
		internal IEnumerator $locvar1;

		// Token: 0x04004A89 RID: 19081
		internal object <_>__2;

		// Token: 0x04004A8A RID: 19082
		internal IDisposable $locvar2;

		// Token: 0x04004A8B RID: 19083
		internal DivineRemedy $this;

		// Token: 0x04004A8C RID: 19084
		internal object $current;

		// Token: 0x04004A8D RID: 19085
		internal bool $disposing;

		// Token: 0x04004A8E RID: 19086
		internal int $PC;
	}

	// Token: 0x02000E01 RID: 3585
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A05 RID: 23045 RVA: 0x00134338 File Offset: 0x00132738
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator1()
		{
		}

		// Token: 0x06005A06 RID: 23046 RVA: 0x00134340 File Offset: 0x00132740
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				heals = new List<BattleHeal>();
				casterp = skill.SourceUnit.GetOutputCapacity(AttributeRetrievalLevel.Skill);
				enumerator = strategy.Selections.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						IBattleUnit target = enumerator.Current;
						heals.Add(new BattleHeal(target, skill, new List<HealComponentValue>
						{
							new HealComponentValue
							{
								RawHeal = casterp.Value * base.ActiveHealRate(skill.Skill),
								HealType = OutputType.Heal,
								IsDirectHeal = true
							}
						}, false));
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				rs = new ReleaseableHeal(heals, skill.SourceUnit);
				enumerator2 = rs.Release().GetEnumerator();
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
			this.$PC = -1;
			return false;
		}

		// Token: 0x170012C4 RID: 4804
		// (get) Token: 0x06005A07 RID: 23047 RVA: 0x00134528 File Offset: 0x00132928
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012C5 RID: 4805
		// (get) Token: 0x06005A08 RID: 23048 RVA: 0x00134530 File Offset: 0x00132930
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A09 RID: 23049 RVA: 0x00134538 File Offset: 0x00132938
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
			}
		}

		// Token: 0x06005A0A RID: 23050 RVA: 0x001345A8 File Offset: 0x001329A8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A0B RID: 23051 RVA: 0x001345AF File Offset: 0x001329AF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A0C RID: 23052 RVA: 0x001345B8 File Offset: 0x001329B8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DivineRemedy.<CastSkillLogic>c__Iterator1 <CastSkillLogic>c__Iterator = new DivineRemedy.<CastSkillLogic>c__Iterator1();
			<CastSkillLogic>c__Iterator.$this = this;
			<CastSkillLogic>c__Iterator.skill = skill;
			<CastSkillLogic>c__Iterator.strategy = strategy;
			return <CastSkillLogic>c__Iterator;
		}

		// Token: 0x04004A8F RID: 19087
		internal List<BattleHeal> <heals>__0;

		// Token: 0x04004A90 RID: 19088
		internal AdventureUnitSkill skill;

		// Token: 0x04004A91 RID: 19089
		internal UnitOutputCapacity <casterp>__0;

		// Token: 0x04004A92 RID: 19090
		internal ActiveSkillTargetingStrategyBase strategy;

		// Token: 0x04004A93 RID: 19091
		internal List<IBattleUnit>.Enumerator $locvar0;

		// Token: 0x04004A94 RID: 19092
		internal ReleaseableHeal <rs>__0;

		// Token: 0x04004A95 RID: 19093
		internal IEnumerator $locvar1;

		// Token: 0x04004A96 RID: 19094
		internal object <_>__1;

		// Token: 0x04004A97 RID: 19095
		internal IDisposable $locvar2;

		// Token: 0x04004A98 RID: 19096
		internal DivineRemedy $this;

		// Token: 0x04004A99 RID: 19097
		internal object $current;

		// Token: 0x04004A9A RID: 19098
		internal bool $disposing;

		// Token: 0x04004A9B RID: 19099
		internal int $PC;
	}
}
