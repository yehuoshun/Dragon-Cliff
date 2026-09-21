using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200071E RID: 1822
public class Stamina : SecondarySkillBase
{
	// Token: 0x060032B7 RID: 12983 RVA: 0x00156E18 File Offset: 0x00155218
	public Stamina()
	{
	}

	// Token: 0x170007A9 RID: 1961
	// (get) Token: 0x060032B8 RID: 12984 RVA: 0x00156E33 File Offset: 0x00155233
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Stamina;
		}
	}

	// Token: 0x170007AA RID: 1962
	// (get) Token: 0x060032B9 RID: 12985 RVA: 0x00156E3A File Offset: 0x0015523A
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060032BA RID: 12986 RVA: 0x00156E42 File Offset: 0x00155242
	private double GetBoostValue(Skill skill)
	{
		return 0.3 + (double)(skill.Level - 1) * 0.015;
	}

	// Token: 0x060032BB RID: 12987 RVA: 0x00156E61 File Offset: 0x00155261
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.BoostValueKey, this.GetBoostValue(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060032BC RID: 12988 RVA: 0x00156E8C File Offset: 0x0015528C
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReadyInBattle && processingSkill.SourceUnit == eventTriggerUnit && eventTriggerUnit.Status == BattleUnitStatus.Active)
		{
			double amount = this.GetBoostValue(processingSkill.Skill);
			IEnumerator enumerator = eventTriggerUnit.ApplySkillEffect(AttributeModificationEffect.CreateStaminaEffect(processingSkill, amount, base.GetType().FullName), false).GetEnumerator();
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

	// Token: 0x170007AB RID: 1963
	// (get) Token: 0x060032BD RID: 12989 RVA: 0x00156EC5 File Offset: 0x001552C5
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Defensive;
		}
	}

	// Token: 0x170007AC RID: 1964
	// (get) Token: 0x060032BE RID: 12990 RVA: 0x00156EC8 File Offset: 0x001552C8
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x170007AD RID: 1965
	// (get) Token: 0x060032BF RID: 12991 RVA: 0x00156ECB File Offset: 0x001552CB
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x060032C0 RID: 12992 RVA: 0x00156ED0 File Offset: 0x001552D0
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitReadyInBattle
		};
	}

	// Token: 0x170007AE RID: 1966
	// (get) Token: 0x060032C1 RID: 12993 RVA: 0x00156EEC File Offset: 0x001552EC
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x170007AF RID: 1967
	// (get) Token: 0x060032C2 RID: 12994 RVA: 0x00156EF4 File Offset: 0x001552F4
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x040027D1 RID: 10193
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027D2 RID: 10194
	private int? _requiredSchoolLevel = new int?(1);

	// Token: 0x02000E82 RID: 3714
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D80 RID: 23936 RVA: 0x00156EF7 File Offset: 0x001552F7
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D81 RID: 23937 RVA: 0x00156F00 File Offset: 0x00155300
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitReadyInBattle || processingSkill.SourceUnit != eventTriggerUnit || eventTriggerUnit.Status != BattleUnitStatus.Active)
				{
					goto IL_130;
				}
				amount = base.GetBoostValue(processingSkill.Skill);
				enumerator = eventTriggerUnit.ApplySkillEffect(AttributeModificationEffect.CreateStaminaEffect(processingSkill, amount, base.GetType().FullName), false).GetEnumerator();
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
			IL_130:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001386 RID: 4998
		// (get) Token: 0x06005D82 RID: 23938 RVA: 0x00157058 File Offset: 0x00155458
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001387 RID: 4999
		// (get) Token: 0x06005D83 RID: 23939 RVA: 0x00157060 File Offset: 0x00155460
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D84 RID: 23940 RVA: 0x00157068 File Offset: 0x00155468
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

		// Token: 0x06005D85 RID: 23941 RVA: 0x001570D8 File Offset: 0x001554D8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D86 RID: 23942 RVA: 0x001570DF File Offset: 0x001554DF
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D87 RID: 23943 RVA: 0x001570E8 File Offset: 0x001554E8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Stamina.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new Stamina.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040050C9 RID: 20681
		internal AdventureEventType eventType;

		// Token: 0x040050CA RID: 20682
		internal AdventureUnitSkill processingSkill;

		// Token: 0x040050CB RID: 20683
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040050CC RID: 20684
		internal double <amount>__1;

		// Token: 0x040050CD RID: 20685
		internal IEnumerator $locvar0;

		// Token: 0x040050CE RID: 20686
		internal object <_>__2;

		// Token: 0x040050CF RID: 20687
		internal IDisposable $locvar1;

		// Token: 0x040050D0 RID: 20688
		internal Stamina $this;

		// Token: 0x040050D1 RID: 20689
		internal object $current;

		// Token: 0x040050D2 RID: 20690
		internal bool $disposing;

		// Token: 0x040050D3 RID: 20691
		internal int $PC;
	}
}
