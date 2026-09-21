using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000721 RID: 1825
public class Wave : SecondarySkillBase
{
	// Token: 0x060032DC RID: 13020 RVA: 0x00157807 File Offset: 0x00155C07
	public Wave()
	{
	}

	// Token: 0x170007BE RID: 1982
	// (get) Token: 0x060032DD RID: 13021 RVA: 0x00157822 File Offset: 0x00155C22
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Wave;
		}
	}

	// Token: 0x170007BF RID: 1983
	// (get) Token: 0x060032DE RID: 13022 RVA: 0x00157829 File Offset: 0x00155C29
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060032DF RID: 13023 RVA: 0x00157831 File Offset: 0x00155C31
	private double GetHealRate(Skill skill)
	{
		return 0.15 + (double)(skill.Level - 1) * 0.02;
	}

	// Token: 0x060032E0 RID: 13024 RVA: 0x00157850 File Offset: 0x00155C50
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.HealRateKey, this.GetHealRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x060032E1 RID: 13025 RVA: 0x00157878 File Offset: 0x00155C78
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitEntersTurn && eventTriggerUnit == processingSkill.SourceUnit && eventTriggerUnit.Status == BattleUnitStatus.Active)
		{
			double healpercentage = this.GetHealRate(processingSkill.Skill);
			double heal = healpercentage * eventTriggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
			ReleaseableHeal releaseable = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(eventTriggerUnit, processingSkill, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = heal,
						IsDirectHeal = false,
						HealType = OutputType.RealHeal
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
		yield break;
	}

	// Token: 0x170007C0 RID: 1984
	// (get) Token: 0x060032E2 RID: 13026 RVA: 0x001578B1 File Offset: 0x00155CB1
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Defensive;
		}
	}

	// Token: 0x170007C1 RID: 1985
	// (get) Token: 0x060032E3 RID: 13027 RVA: 0x001578B4 File Offset: 0x00155CB4
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x170007C2 RID: 1986
	// (get) Token: 0x060032E4 RID: 13028 RVA: 0x001578B7 File Offset: 0x00155CB7
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x060032E5 RID: 13029 RVA: 0x001578BC File Offset: 0x00155CBC
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitEntersTurn
		};
	}

	// Token: 0x170007C3 RID: 1987
	// (get) Token: 0x060032E6 RID: 13030 RVA: 0x001578D7 File Offset: 0x00155CD7
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x170007C4 RID: 1988
	// (get) Token: 0x060032E7 RID: 13031 RVA: 0x001578DF File Offset: 0x00155CDF
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x040027D7 RID: 10199
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027D8 RID: 10200
	private int? _requiredSchoolLevel = new int?(1);

	// Token: 0x02000E86 RID: 3718
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D9A RID: 23962 RVA: 0x001578E2 File Offset: 0x00155CE2
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D9B RID: 23963 RVA: 0x001578EC File Offset: 0x00155CEC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitEntersTurn || eventTriggerUnit != processingSkill.SourceUnit || eventTriggerUnit.Status != BattleUnitStatus.Active)
				{
					goto IL_191;
				}
				healpercentage = base.GetHealRate(processingSkill.Skill);
				heal = healpercentage * eventTriggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill);
				releaseable = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(eventTriggerUnit, processingSkill, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = heal,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
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
			IL_191:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700138C RID: 5004
		// (get) Token: 0x06005D9C RID: 23964 RVA: 0x00157AA4 File Offset: 0x00155EA4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700138D RID: 5005
		// (get) Token: 0x06005D9D RID: 23965 RVA: 0x00157AAC File Offset: 0x00155EAC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D9E RID: 23966 RVA: 0x00157AB4 File Offset: 0x00155EB4
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

		// Token: 0x06005D9F RID: 23967 RVA: 0x00157B24 File Offset: 0x00155F24
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005DA0 RID: 23968 RVA: 0x00157B2B File Offset: 0x00155F2B
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005DA1 RID: 23969 RVA: 0x00157B34 File Offset: 0x00155F34
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Wave.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new Wave.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040050EE RID: 20718
		internal AdventureEventType eventType;

		// Token: 0x040050EF RID: 20719
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040050F0 RID: 20720
		internal AdventureUnitSkill processingSkill;

		// Token: 0x040050F1 RID: 20721
		internal double <healpercentage>__1;

		// Token: 0x040050F2 RID: 20722
		internal double <heal>__1;

		// Token: 0x040050F3 RID: 20723
		internal ReleaseableHeal <releaseable>__1;

		// Token: 0x040050F4 RID: 20724
		internal IEnumerator $locvar0;

		// Token: 0x040050F5 RID: 20725
		internal object <_>__2;

		// Token: 0x040050F6 RID: 20726
		internal IDisposable $locvar1;

		// Token: 0x040050F7 RID: 20727
		internal Wave $this;

		// Token: 0x040050F8 RID: 20728
		internal object $current;

		// Token: 0x040050F9 RID: 20729
		internal bool $disposing;

		// Token: 0x040050FA RID: 20730
		internal int $PC;
	}
}
