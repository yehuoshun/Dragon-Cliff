using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000715 RID: 1813
public class Harmony : SecondarySkillBase
{
	// Token: 0x06003253 RID: 12883 RVA: 0x00155054 File Offset: 0x00153454
	public Harmony()
	{
	}

	// Token: 0x1700076E RID: 1902
	// (get) Token: 0x06003254 RID: 12884 RVA: 0x0015506F File Offset: 0x0015346F
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Harmony;
		}
	}

	// Token: 0x1700076F RID: 1903
	// (get) Token: 0x06003255 RID: 12885 RVA: 0x00155076 File Offset: 0x00153476
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003256 RID: 12886 RVA: 0x0015507E File Offset: 0x0015347E
	private double GetBoostRate(Skill skill)
	{
		return 0.3 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06003257 RID: 12887 RVA: 0x0015509D File Offset: 0x0015349D
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.BoostRateKey, this.GetBoostRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003258 RID: 12888 RVA: 0x001550C4 File Offset: 0x001534C4
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReadyInBattle && processingSkill.SourceUnit == eventTriggerUnit)
		{
			double rate = this.GetBoostRate(processingSkill.Skill);
			IEnumerator enumerator = processingSkill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateHarmonyEffect(processingSkill, rate, base.GetType().FullName, processingSkill.SourceUnit), false).GetEnumerator();
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

	// Token: 0x17000770 RID: 1904
	// (get) Token: 0x06003259 RID: 12889 RVA: 0x001550FD File Offset: 0x001534FD
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x17000771 RID: 1905
	// (get) Token: 0x0600325A RID: 12890 RVA: 0x00155100 File Offset: 0x00153500
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x17000772 RID: 1906
	// (get) Token: 0x0600325B RID: 12891 RVA: 0x00155103 File Offset: 0x00153503
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x0600325C RID: 12892 RVA: 0x00155108 File Offset: 0x00153508
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitReadyInBattle
		};
	}

	// Token: 0x17000773 RID: 1907
	// (get) Token: 0x0600325D RID: 12893 RVA: 0x00155124 File Offset: 0x00153524
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x17000774 RID: 1908
	// (get) Token: 0x0600325E RID: 12894 RVA: 0x0015512C File Offset: 0x0015352C
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x040027BF RID: 10175
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027C0 RID: 10176
	private int? _requiredSchoolLevel = new int?(1);

	// Token: 0x02000E78 RID: 3704
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D3B RID: 23867 RVA: 0x0015512F File Offset: 0x0015352F
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D3C RID: 23868 RVA: 0x00155138 File Offset: 0x00153538
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitReadyInBattle || processingSkill.SourceUnit != eventTriggerUnit)
				{
					goto IL_12F;
				}
				rate = base.GetBoostRate(processingSkill.Skill);
				enumerator = processingSkill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateHarmonyEffect(processingSkill, rate, base.GetType().FullName, processingSkill.SourceUnit), false).GetEnumerator();
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
			IL_12F:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001376 RID: 4982
		// (get) Token: 0x06005D3D RID: 23869 RVA: 0x00155290 File Offset: 0x00153690
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001377 RID: 4983
		// (get) Token: 0x06005D3E RID: 23870 RVA: 0x00155298 File Offset: 0x00153698
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D3F RID: 23871 RVA: 0x001552A0 File Offset: 0x001536A0
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

		// Token: 0x06005D40 RID: 23872 RVA: 0x00155310 File Offset: 0x00153710
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D41 RID: 23873 RVA: 0x00155317 File Offset: 0x00153717
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D42 RID: 23874 RVA: 0x00155320 File Offset: 0x00153720
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Harmony.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new Harmony.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x04005057 RID: 20567
		internal AdventureEventType eventType;

		// Token: 0x04005058 RID: 20568
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04005059 RID: 20569
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400505A RID: 20570
		internal double <rate>__1;

		// Token: 0x0400505B RID: 20571
		internal IEnumerator $locvar0;

		// Token: 0x0400505C RID: 20572
		internal object <_>__2;

		// Token: 0x0400505D RID: 20573
		internal IDisposable $locvar1;

		// Token: 0x0400505E RID: 20574
		internal Harmony $this;

		// Token: 0x0400505F RID: 20575
		internal object $current;

		// Token: 0x04005060 RID: 20576
		internal bool $disposing;

		// Token: 0x04005061 RID: 20577
		internal int $PC;
	}
}
