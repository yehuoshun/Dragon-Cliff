using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000712 RID: 1810
public class Flame : SecondarySkillBase
{
	// Token: 0x0600322D RID: 12845 RVA: 0x001544A8 File Offset: 0x001528A8
	public Flame()
	{
	}

	// Token: 0x17000759 RID: 1881
	// (get) Token: 0x0600322E RID: 12846 RVA: 0x001544C3 File Offset: 0x001528C3
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Flame;
		}
	}

	// Token: 0x1700075A RID: 1882
	// (get) Token: 0x0600322F RID: 12847 RVA: 0x001544CA File Offset: 0x001528CA
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x06003230 RID: 12848 RVA: 0x001544D2 File Offset: 0x001528D2
	private double GetDamagePercentage(Skill skill)
	{
		return 1.0 + (double)(skill.Level - 1) * 0.1;
	}

	// Token: 0x06003231 RID: 12849 RVA: 0x001544F1 File Offset: 0x001528F1
	private double GetDamageRaw(AdventureUnitSkill skill)
	{
		return base.CalculateDamageRaw(this.GetDamagePercentage(skill.Skill), skill);
	}

	// Token: 0x06003232 RID: 12850 RVA: 0x00154506 File Offset: 0x00152906
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.ReplaceToBuilder(this.MainOvertimeDamageRatekey, this.GetDamagePercentage(skill).ToExpressionMultiply100()).ToString();
		return description;
	}

	// Token: 0x06003233 RID: 12851 RVA: 0x00154534 File Offset: 0x00152934
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPostReceivesDamage)
		{
			BattleDamage battleDamage = data as BattleDamage;
			if (battleDamage.Dealer == processingSkill.SourceUnit)
			{
				foreach (DamageComponent damage in battleDamage.Damages)
				{
					if (damage.IsCrit && !damage.IsMissed)
					{
						double damageValue = this.GetDamageRaw(processingSkill);
						IEnumerator enumerator2 = DamageOverTimeEffect.AddDamageOverTurn(eventTriggerUnit, processingSkill, damageValue, 2, OutputType.Fire).GetEnumerator();
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

	// Token: 0x1700075B RID: 1883
	// (get) Token: 0x06003234 RID: 12852 RVA: 0x00154575 File Offset: 0x00152975
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Offensive;
		}
	}

	// Token: 0x1700075C RID: 1884
	// (get) Token: 0x06003235 RID: 12853 RVA: 0x00154578 File Offset: 0x00152978
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.Fire;
		}
	}

	// Token: 0x1700075D RID: 1885
	// (get) Token: 0x06003236 RID: 12854 RVA: 0x0015457B File Offset: 0x0015297B
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.None;
		}
	}

	// Token: 0x06003237 RID: 12855 RVA: 0x00154580 File Offset: 0x00152980
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage
		};
	}

	// Token: 0x1700075E RID: 1886
	// (get) Token: 0x06003238 RID: 12856 RVA: 0x0015459C File Offset: 0x0015299C
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x1700075F RID: 1887
	// (get) Token: 0x06003239 RID: 12857 RVA: 0x001545A4 File Offset: 0x001529A4
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x040027B9 RID: 10169
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027BA RID: 10170
	private int? _requiredSchoolLevel = new int?(2);

	// Token: 0x02000E75 RID: 3701
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D23 RID: 23843 RVA: 0x001545A7 File Offset: 0x001529A7
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D24 RID: 23844 RVA: 0x001545B0 File Offset: 0x001529B0
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
					goto IL_1AE;
				}
				battleDamage = (data as BattleDamage);
				if (battleDamage.Dealer != processingSkill.SourceUnit)
				{
					goto IL_1AE;
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
					damage = enumerator.Current;
					if (damage.IsCrit && !damage.IsMissed)
					{
						IBattleUnit target = eventTriggerUnit;
						damageValue = base.GetDamageRaw(processingSkill);
						enumerator2 = DamageOverTimeEffect.AddDamageOverTurn(target, processingSkill, damageValue, 2, OutputType.Fire).GetEnumerator();
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
			IL_1AE:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001370 RID: 4976
		// (get) Token: 0x06005D25 RID: 23845 RVA: 0x001547AC File Offset: 0x00152BAC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001371 RID: 4977
		// (get) Token: 0x06005D26 RID: 23846 RVA: 0x001547B4 File Offset: 0x00152BB4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D27 RID: 23847 RVA: 0x001547BC File Offset: 0x00152BBC
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

		// Token: 0x06005D28 RID: 23848 RVA: 0x00154850 File Offset: 0x00152C50
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D29 RID: 23849 RVA: 0x00154857 File Offset: 0x00152C57
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D2A RID: 23850 RVA: 0x00154860 File Offset: 0x00152C60
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Flame.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new Flame.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.data = data;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x0400502B RID: 20523
		internal AdventureEventType eventType;

		// Token: 0x0400502C RID: 20524
		internal object data;

		// Token: 0x0400502D RID: 20525
		internal BattleDamage <battleDamage>__1;

		// Token: 0x0400502E RID: 20526
		internal AdventureUnitSkill processingSkill;

		// Token: 0x0400502F RID: 20527
		internal List<DamageComponent>.Enumerator $locvar0;

		// Token: 0x04005030 RID: 20528
		internal DamageComponent <damage>__2;

		// Token: 0x04005031 RID: 20529
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04005032 RID: 20530
		internal IBattleUnit <target>__3;

		// Token: 0x04005033 RID: 20531
		internal double <damageValue>__3;

		// Token: 0x04005034 RID: 20532
		internal IEnumerator $locvar1;

		// Token: 0x04005035 RID: 20533
		internal object <_>__4;

		// Token: 0x04005036 RID: 20534
		internal IDisposable $locvar2;

		// Token: 0x04005037 RID: 20535
		internal Flame $this;

		// Token: 0x04005038 RID: 20536
		internal object $current;

		// Token: 0x04005039 RID: 20537
		internal bool $disposing;

		// Token: 0x0400503A RID: 20538
		internal int $PC;
	}
}
