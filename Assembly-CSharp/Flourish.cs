using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000714 RID: 1812
public class Flourish : SecondarySkillBase
{
	// Token: 0x06003247 RID: 12871 RVA: 0x00154C38 File Offset: 0x00153038
	public Flourish()
	{
	}

	// Token: 0x17000767 RID: 1895
	// (get) Token: 0x06003248 RID: 12872 RVA: 0x00154C53 File Offset: 0x00153053
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Flourish;
		}
	}

	// Token: 0x17000768 RID: 1896
	// (get) Token: 0x06003249 RID: 12873 RVA: 0x00154C5A File Offset: 0x0015305A
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x0600324A RID: 12874 RVA: 0x00154C62 File Offset: 0x00153062
	private double GetBoostRate(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.2;
	}

	// Token: 0x0600324B RID: 12875 RVA: 0x00154C81 File Offset: 0x00153081
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.BoostRateKey, this.GetBoostRate(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x0600324C RID: 12876 RVA: 0x00154CAC File Offset: 0x001530AC
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReceivesHeal)
		{
			BattleHeal heal = data as BattleHeal;
			if (processingSkill.SourceUnit == heal.Healer)
			{
				foreach (HealComponent healComponent in heal.Heals)
				{
					if (healComponent.IsCrit && !healComponent.IsNeutralized)
					{
						double rate = this.GetBoostRate(processingSkill.Skill);
						IEnumerator enumerator2 = eventTriggerUnit.ApplySkillEffect(AttributeModificationEffect.CreateFlourishEffect(processingSkill, rate, base.GetType().FullName), false).GetEnumerator();
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
				}
			}
		}
		yield break;
	}

	// Token: 0x17000769 RID: 1897
	// (get) Token: 0x0600324D RID: 12877 RVA: 0x00154CED File Offset: 0x001530ED
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Defensive;
		}
	}

	// Token: 0x1700076A RID: 1898
	// (get) Token: 0x0600324E RID: 12878 RVA: 0x00154CF0 File Offset: 0x001530F0
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x1700076B RID: 1899
	// (get) Token: 0x0600324F RID: 12879 RVA: 0x00154CF3 File Offset: 0x001530F3
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.None;
		}
	}

	// Token: 0x06003250 RID: 12880 RVA: 0x00154CF8 File Offset: 0x001530F8
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitReceivesHeal
		};
	}

	// Token: 0x1700076C RID: 1900
	// (get) Token: 0x06003251 RID: 12881 RVA: 0x00154D14 File Offset: 0x00153114
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x1700076D RID: 1901
	// (get) Token: 0x06003252 RID: 12882 RVA: 0x00154D1C File Offset: 0x0015311C
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x040027BD RID: 10173
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027BE RID: 10174
	private int? _requiredSchoolLevel = new int?(1);

	// Token: 0x02000E77 RID: 3703
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D33 RID: 23859 RVA: 0x00154D1F File Offset: 0x0015311F
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D34 RID: 23860 RVA: 0x00154D28 File Offset: 0x00153128
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitReceivesHeal)
				{
					goto IL_1C7;
				}
				heal = (data as BattleHeal);
				if (processingSkill.SourceUnit != heal.Healer)
				{
					goto IL_1C7;
				}
				enumerator = heal.Heals.GetEnumerator();
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
					Block_8:
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
				while (enumerator.MoveNext())
				{
					healComponent = enumerator.Current;
					if (healComponent.IsCrit && !healComponent.IsNeutralized)
					{
						IBattleUnit target = eventTriggerUnit;
						rate = base.GetBoostRate(processingSkill.Skill);
						enumerator2 = target.ApplySkillEffect(AttributeModificationEffect.CreateFlourishEffect(processingSkill, rate, base.GetType().FullName), false).GetEnumerator();
						num = 4294967293u;
						goto Block_8;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IL_1C7:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001374 RID: 4980
		// (get) Token: 0x06005D35 RID: 23861 RVA: 0x00154F3C File Offset: 0x0015333C
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001375 RID: 4981
		// (get) Token: 0x06005D36 RID: 23862 RVA: 0x00154F44 File Offset: 0x00153344
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D37 RID: 23863 RVA: 0x00154F4C File Offset: 0x0015334C
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

		// Token: 0x06005D38 RID: 23864 RVA: 0x00154FE0 File Offset: 0x001533E0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D39 RID: 23865 RVA: 0x00154FE7 File Offset: 0x001533E7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D3A RID: 23866 RVA: 0x00154FF0 File Offset: 0x001533F0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Flourish.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new Flourish.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x04005047 RID: 20551
		internal AdventureEventType eventType;

		// Token: 0x04005048 RID: 20552
		internal object data;

		// Token: 0x04005049 RID: 20553
		internal BattleHeal <heal>__1;

		// Token: 0x0400504A RID: 20554
		internal AdventureUnitSkill processingSkill;

		// Token: 0x0400504B RID: 20555
		internal List<HealComponent>.Enumerator $locvar0;

		// Token: 0x0400504C RID: 20556
		internal HealComponent <healComponent>__2;

		// Token: 0x0400504D RID: 20557
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400504E RID: 20558
		internal IBattleUnit <target>__3;

		// Token: 0x0400504F RID: 20559
		internal double <rate>__3;

		// Token: 0x04005050 RID: 20560
		internal IEnumerator $locvar1;

		// Token: 0x04005051 RID: 20561
		internal object <_>__4;

		// Token: 0x04005052 RID: 20562
		internal IDisposable $locvar2;

		// Token: 0x04005053 RID: 20563
		internal Flourish $this;

		// Token: 0x04005054 RID: 20564
		internal object $current;

		// Token: 0x04005055 RID: 20565
		internal bool $disposing;

		// Token: 0x04005056 RID: 20566
		internal int $PC;
	}
}
