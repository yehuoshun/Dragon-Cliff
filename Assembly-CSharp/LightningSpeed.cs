using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000717 RID: 1815
public class LightningSpeed : SecondarySkillBase
{
	// Token: 0x0600326B RID: 12907 RVA: 0x00155688 File Offset: 0x00153A88
	public LightningSpeed()
	{
	}

	// Token: 0x1700077C RID: 1916
	// (get) Token: 0x0600326C RID: 12908 RVA: 0x001556A3 File Offset: 0x00153AA3
	public override SkillType SkillType
	{
		get
		{
			return SkillType.LightningSpeed;
		}
	}

	// Token: 0x1700077D RID: 1917
	// (get) Token: 0x0600326D RID: 12909 RVA: 0x001556AA File Offset: 0x00153AAA
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x0600326E RID: 12910 RVA: 0x001556B2 File Offset: 0x00153AB2
	public static double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x0600326F RID: 12911 RVA: 0x001556D1 File Offset: 0x00153AD1
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainDamageRateKey, LightningSpeed.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003270 RID: 12912 RVA: 0x001556FC File Offset: 0x00153AFC
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPostReceivesDamage)
		{
			BattleDamage battleDamage = data as BattleDamage;
			if (battleDamage.Dealer == processingSkill.SourceUnit)
			{
				foreach (DamageComponent damage in battleDamage.Damages)
				{
					IBattleUnit target = battleDamage.Target;
					IEnumerator enumerator2 = target.ApplySkillEffect(new LighteningSpeedEffect(processingSkill, base.GetType().FullName), false).GetEnumerator();
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
		yield break;
	}

	// Token: 0x1700077E RID: 1918
	// (get) Token: 0x06003271 RID: 12913 RVA: 0x00155736 File Offset: 0x00153B36
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700077F RID: 1919
	// (get) Token: 0x06003272 RID: 12914 RVA: 0x00155739 File Offset: 0x00153B39
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Lightening;
		}
	}

	// Token: 0x17000780 RID: 1920
	// (get) Token: 0x06003273 RID: 12915 RVA: 0x0015573C File Offset: 0x00153B3C
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.Single;
		}
	}

	// Token: 0x06003274 RID: 12916 RVA: 0x00155740 File Offset: 0x00153B40
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage
		};
	}

	// Token: 0x17000781 RID: 1921
	// (get) Token: 0x06003275 RID: 12917 RVA: 0x0015575C File Offset: 0x00153B5C
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x17000782 RID: 1922
	// (get) Token: 0x06003276 RID: 12918 RVA: 0x00155764 File Offset: 0x00153B64
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x040027C3 RID: 10179
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027C4 RID: 10180
	private int? _requiredSchoolLevel = new int?(1);

	// Token: 0x02000E7A RID: 3706
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D4B RID: 23883 RVA: 0x00155767 File Offset: 0x00153B67
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D4C RID: 23884 RVA: 0x00155770 File Offset: 0x00153B70
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPostReceivesDamage)
				{
					goto IL_18A;
				}
				battleDamage = (data as BattleDamage);
				if (battleDamage.Dealer != processingSkill.SourceUnit)
				{
					goto IL_18A;
				}
				enumerator = battleDamage.Damages.GetEnumerator();
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
					damage = enumerator.Current;
					target = battleDamage.Target;
					enumerator2 = target.ApplySkillEffect(new LighteningSpeedEffect(processingSkill, base.GetType().FullName), false).GetEnumerator();
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
			IL_18A:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700137A RID: 4986
		// (get) Token: 0x06005D4D RID: 23885 RVA: 0x00155930 File Offset: 0x00153D30
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700137B RID: 4987
		// (get) Token: 0x06005D4E RID: 23886 RVA: 0x00155938 File Offset: 0x00153D38
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D4F RID: 23887 RVA: 0x00155940 File Offset: 0x00153D40
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

		// Token: 0x06005D50 RID: 23888 RVA: 0x001559D4 File Offset: 0x00153DD4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D51 RID: 23889 RVA: 0x001559DB File Offset: 0x00153DDB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D52 RID: 23890 RVA: 0x001559E4 File Offset: 0x00153DE4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			LightningSpeed.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new LightningSpeed.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x0400506D RID: 20589
		internal AdventureEventType eventType;

		// Token: 0x0400506E RID: 20590
		internal object data;

		// Token: 0x0400506F RID: 20591
		internal BattleDamage <battleDamage>__1;

		// Token: 0x04005070 RID: 20592
		internal AdventureUnitSkill processingSkill;

		// Token: 0x04005071 RID: 20593
		internal List<DamageComponent>.Enumerator $locvar0;

		// Token: 0x04005072 RID: 20594
		internal DamageComponent <damage>__2;

		// Token: 0x04005073 RID: 20595
		internal IBattleUnit <target>__3;

		// Token: 0x04005074 RID: 20596
		internal IEnumerator $locvar1;

		// Token: 0x04005075 RID: 20597
		internal object <_>__4;

		// Token: 0x04005076 RID: 20598
		internal IDisposable $locvar2;

		// Token: 0x04005077 RID: 20599
		internal LightningSpeed $this;

		// Token: 0x04005078 RID: 20600
		internal object $current;

		// Token: 0x04005079 RID: 20601
		internal bool $disposing;

		// Token: 0x0400507A RID: 20602
		internal int $PC;
	}
}
