using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200071D RID: 1821
public class SoulSeeker : SecondarySkillBase
{
	// Token: 0x060032AB RID: 12971 RVA: 0x00156AA0 File Offset: 0x00154EA0
	public SoulSeeker()
	{
	}

	// Token: 0x170007A2 RID: 1954
	// (get) Token: 0x060032AC RID: 12972 RVA: 0x00156ABB File Offset: 0x00154EBB
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x170007A3 RID: 1955
	// (get) Token: 0x060032AD RID: 12973 RVA: 0x00156ABE File Offset: 0x00154EBE
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Defensive;
		}
	}

	// Token: 0x170007A4 RID: 1956
	// (get) Token: 0x060032AE RID: 12974 RVA: 0x00156AC1 File Offset: 0x00154EC1
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x170007A5 RID: 1957
	// (get) Token: 0x060032AF RID: 12975 RVA: 0x00156AC4 File Offset: 0x00154EC4
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x060032B0 RID: 12976 RVA: 0x00156AC8 File Offset: 0x00154EC8
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitKilled
		};
	}

	// Token: 0x170007A6 RID: 1958
	// (get) Token: 0x060032B1 RID: 12977 RVA: 0x00156AE4 File Offset: 0x00154EE4
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x170007A7 RID: 1959
	// (get) Token: 0x060032B2 RID: 12978 RVA: 0x00156AEC File Offset: 0x00154EEC
	public override SkillType SkillType
	{
		get
		{
			return SkillType.SoulSeeker;
		}
	}

	// Token: 0x170007A8 RID: 1960
	// (get) Token: 0x060032B3 RID: 12979 RVA: 0x00156AF3 File Offset: 0x00154EF3
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060032B4 RID: 12980 RVA: 0x00156AFB File Offset: 0x00154EFB
	private double HealRate(Skill skill)
	{
		return 0.25 + (double)(skill.Level - 1) * 0.02;
	}

	// Token: 0x060032B5 RID: 12981 RVA: 0x00156B1A File Offset: 0x00154F1A
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.HealRateKey, this.HealRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x060032B6 RID: 12982 RVA: 0x00156B48 File Offset: 0x00154F48
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitKilled && eventTriggerUnit != skillOwner)
		{
			double heal = eventTriggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * this.HealRate(processingSkill.Skill);
			ReleaseableHeal releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
			{
				new BattleHeal(skillOwner, processingSkill, new List<HealComponentValue>
				{
					new HealComponentValue
					{
						RawHeal = heal,
						IsDirectHeal = false,
						HealType = OutputType.RealHeal
					}
				}, false)
			}, skillOwner);
			IEnumerator enumerator = releaseableHeal.Release().GetEnumerator();
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

	// Token: 0x040027CF RID: 10191
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027D0 RID: 10192
	private int? _requiredSchoolLevel = new int?(1);

	// Token: 0x02000E81 RID: 3713
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D78 RID: 23928 RVA: 0x00156B88 File Offset: 0x00154F88
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D79 RID: 23929 RVA: 0x00156B90 File Offset: 0x00154F90
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitKilled || eventTriggerUnit == skillOwner)
				{
					goto IL_16B;
				}
				heal = eventTriggerUnit.GetMaxLife(AttributeRetrievalLevel.Skill) * base.HealRate(processingSkill.Skill);
				releaseableHeal = new ReleaseableHeal(new List<BattleHeal>
				{
					new BattleHeal(skillOwner, processingSkill, new List<HealComponentValue>
					{
						new HealComponentValue
						{
							RawHeal = heal,
							IsDirectHeal = false,
							HealType = OutputType.RealHeal
						}
					}, false)
				}, skillOwner);
				enumerator = releaseableHeal.Release().GetEnumerator();
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
			IL_16B:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001384 RID: 4996
		// (get) Token: 0x06005D7A RID: 23930 RVA: 0x00156D24 File Offset: 0x00155124
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001385 RID: 4997
		// (get) Token: 0x06005D7B RID: 23931 RVA: 0x00156D2C File Offset: 0x0015512C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D7C RID: 23932 RVA: 0x00156D34 File Offset: 0x00155134
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

		// Token: 0x06005D7D RID: 23933 RVA: 0x00156DA4 File Offset: 0x001551A4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D7E RID: 23934 RVA: 0x00156DAB File Offset: 0x001551AB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D7F RID: 23935 RVA: 0x00156DB4 File Offset: 0x001551B4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			SoulSeeker.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new SoulSeeker.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.skillOwner = skillOwner;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040050BC RID: 20668
		internal AdventureEventType eventType;

		// Token: 0x040050BD RID: 20669
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040050BE RID: 20670
		internal IBattleUnit skillOwner;

		// Token: 0x040050BF RID: 20671
		internal AdventureUnitSkill processingSkill;

		// Token: 0x040050C0 RID: 20672
		internal double <heal>__1;

		// Token: 0x040050C1 RID: 20673
		internal ReleaseableHeal <releaseableHeal>__1;

		// Token: 0x040050C2 RID: 20674
		internal IEnumerator $locvar0;

		// Token: 0x040050C3 RID: 20675
		internal object <_>__2;

		// Token: 0x040050C4 RID: 20676
		internal IDisposable $locvar1;

		// Token: 0x040050C5 RID: 20677
		internal SoulSeeker $this;

		// Token: 0x040050C6 RID: 20678
		internal object $current;

		// Token: 0x040050C7 RID: 20679
		internal bool $disposing;

		// Token: 0x040050C8 RID: 20680
		internal int $PC;
	}
}
