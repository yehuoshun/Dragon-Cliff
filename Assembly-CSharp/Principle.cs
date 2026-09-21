using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000718 RID: 1816
public class Principle : SecondarySkillBase
{
	// Token: 0x06003277 RID: 12919 RVA: 0x00155A3C File Offset: 0x00153E3C
	public Principle()
	{
	}

	// Token: 0x17000783 RID: 1923
	// (get) Token: 0x06003278 RID: 12920 RVA: 0x00155A57 File Offset: 0x00153E57
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Principle;
		}
	}

	// Token: 0x17000784 RID: 1924
	// (get) Token: 0x06003279 RID: 12921 RVA: 0x00155A5E File Offset: 0x00153E5E
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x0600327A RID: 12922 RVA: 0x00155A66 File Offset: 0x00153E66
	private double GetDefenceBoostRate(Skill skill)
	{
		return 0.1 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x0600327B RID: 12923 RVA: 0x00155A85 File Offset: 0x00153E85
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.BoostRateKey, this.GetDefenceBoostRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x0600327C RID: 12924 RVA: 0x00155AB0 File Offset: 0x00153EB0
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReceivesHeal && processingSkill.SourceUnit == eventTriggerUnit)
		{
			double rate = this.GetDefenceBoostRate(processingSkill.Skill);
			IEnumerator enumerator = processingSkill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreatePrincepleEffect(processingSkill, rate, base.GetType().FullName), false).GetEnumerator();
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

	// Token: 0x17000785 RID: 1925
	// (get) Token: 0x0600327D RID: 12925 RVA: 0x00155AE9 File Offset: 0x00153EE9
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Defensive;
		}
	}

	// Token: 0x17000786 RID: 1926
	// (get) Token: 0x0600327E RID: 12926 RVA: 0x00155AEC File Offset: 0x00153EEC
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x17000787 RID: 1927
	// (get) Token: 0x0600327F RID: 12927 RVA: 0x00155AEF File Offset: 0x00153EEF
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.None;
		}
	}

	// Token: 0x06003280 RID: 12928 RVA: 0x00155AF4 File Offset: 0x00153EF4
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitReceivesHeal
		};
	}

	// Token: 0x17000788 RID: 1928
	// (get) Token: 0x06003281 RID: 12929 RVA: 0x00155B10 File Offset: 0x00153F10
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x17000789 RID: 1929
	// (get) Token: 0x06003282 RID: 12930 RVA: 0x00155B18 File Offset: 0x00153F18
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x040027C5 RID: 10181
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027C6 RID: 10182
	private int? _requiredSchoolLevel = new int?(1);

	// Token: 0x02000E7B RID: 3707
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D53 RID: 23891 RVA: 0x00155B1B File Offset: 0x00153F1B
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D54 RID: 23892 RVA: 0x00155B24 File Offset: 0x00153F24
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitReceivesHeal || processingSkill.SourceUnit != eventTriggerUnit)
				{
					goto IL_124;
				}
				rate = base.GetDefenceBoostRate(processingSkill.Skill);
				enumerator = processingSkill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreatePrincepleEffect(processingSkill, rate, base.GetType().FullName), false).GetEnumerator();
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
			IL_124:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700137C RID: 4988
		// (get) Token: 0x06005D55 RID: 23893 RVA: 0x00155C70 File Offset: 0x00154070
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700137D RID: 4989
		// (get) Token: 0x06005D56 RID: 23894 RVA: 0x00155C78 File Offset: 0x00154078
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D57 RID: 23895 RVA: 0x00155C80 File Offset: 0x00154080
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

		// Token: 0x06005D58 RID: 23896 RVA: 0x00155CF0 File Offset: 0x001540F0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D59 RID: 23897 RVA: 0x00155CF7 File Offset: 0x001540F7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D5A RID: 23898 RVA: 0x00155D00 File Offset: 0x00154100
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Principle.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new Principle.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x0400507B RID: 20603
		internal AdventureEventType eventType;

		// Token: 0x0400507C RID: 20604
		internal AdventureUnitSkill processingSkill;

		// Token: 0x0400507D RID: 20605
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400507E RID: 20606
		internal double <rate>__1;

		// Token: 0x0400507F RID: 20607
		internal IEnumerator $locvar0;

		// Token: 0x04005080 RID: 20608
		internal object <_>__2;

		// Token: 0x04005081 RID: 20609
		internal IDisposable $locvar1;

		// Token: 0x04005082 RID: 20610
		internal Principle $this;

		// Token: 0x04005083 RID: 20611
		internal object $current;

		// Token: 0x04005084 RID: 20612
		internal bool $disposing;

		// Token: 0x04005085 RID: 20613
		internal int $PC;
	}
}
