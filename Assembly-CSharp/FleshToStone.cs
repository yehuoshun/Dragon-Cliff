using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000713 RID: 1811
public class FleshToStone : SecondarySkillBase
{
	// Token: 0x0600323A RID: 12858 RVA: 0x001548C4 File Offset: 0x00152CC4
	public FleshToStone()
	{
	}

	// Token: 0x17000760 RID: 1888
	// (get) Token: 0x0600323B RID: 12859 RVA: 0x001548DF File Offset: 0x00152CDF
	public override SkillType SkillType
	{
		get
		{
			return SkillType.FleshToStone;
		}
	}

	// Token: 0x17000761 RID: 1889
	// (get) Token: 0x0600323C RID: 12860 RVA: 0x001548E6 File Offset: 0x00152CE6
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x0600323D RID: 12861 RVA: 0x001548EE File Offset: 0x00152CEE
	private double GetChance()
	{
		return 0.3;
	}

	// Token: 0x0600323E RID: 12862 RVA: 0x001548F9 File Offset: 0x00152CF9
	private double GetDamageReductionRate(Skill skill)
	{
		return 0.4 + (double)(skill.Level - 1) * 0.04;
	}

	// Token: 0x0600323F RID: 12863 RVA: 0x00154918 File Offset: 0x00152D18
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.PossibilityKey, (this.GetChance() * 100.0).ToExpression()).Replace(this.DamageReceivedReductionRateKey, this.GetDamageReductionRate(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x06003240 RID: 12864 RVA: 0x0015496C File Offset: 0x00152D6C
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitPostReceivesDamage && eventTriggerUnit == processingSkill.SourceUnit)
		{
			double possibility = this.GetChance();
			if ((double)UnityEngine.Random.value <= possibility)
			{
				double rate = this.GetDamageReductionRate(processingSkill.Skill);
				IEnumerator enumerator = processingSkill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateStoneEffect(processingSkill, rate, base.GetType().FullName), false).GetEnumerator();
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

	// Token: 0x17000762 RID: 1890
	// (get) Token: 0x06003241 RID: 12865 RVA: 0x001549A5 File Offset: 0x00152DA5
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Defensive;
		}
	}

	// Token: 0x17000763 RID: 1891
	// (get) Token: 0x06003242 RID: 12866 RVA: 0x001549A8 File Offset: 0x00152DA8
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x17000764 RID: 1892
	// (get) Token: 0x06003243 RID: 12867 RVA: 0x001549AB File Offset: 0x00152DAB
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.None;
		}
	}

	// Token: 0x06003244 RID: 12868 RVA: 0x001549B0 File Offset: 0x00152DB0
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitPostReceivesDamage
		};
	}

	// Token: 0x17000765 RID: 1893
	// (get) Token: 0x06003245 RID: 12869 RVA: 0x001549CC File Offset: 0x00152DCC
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x17000766 RID: 1894
	// (get) Token: 0x06003246 RID: 12870 RVA: 0x001549D4 File Offset: 0x00152DD4
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x040027BB RID: 10171
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027BC RID: 10172
	private int? _requiredSchoolLevel = new int?(2);

	// Token: 0x02000E76 RID: 3702
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D2B RID: 23851 RVA: 0x001549D7 File Offset: 0x00152DD7
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D2C RID: 23852 RVA: 0x001549E0 File Offset: 0x00152DE0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitPostReceivesDamage || eventTriggerUnit != processingSkill.SourceUnit)
				{
					goto IL_146;
				}
				possibility = base.GetChance();
				if ((double)UnityEngine.Random.value > possibility)
				{
					goto IL_146;
				}
				rate = base.GetDamageReductionRate(processingSkill.Skill);
				enumerator = processingSkill.SourceUnit.ApplySkillEffect(AttributeModificationEffect.CreateStoneEffect(processingSkill, rate, base.GetType().FullName), false).GetEnumerator();
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
			IL_146:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001372 RID: 4978
		// (get) Token: 0x06005D2D RID: 23853 RVA: 0x00154B50 File Offset: 0x00152F50
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001373 RID: 4979
		// (get) Token: 0x06005D2E RID: 23854 RVA: 0x00154B58 File Offset: 0x00152F58
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D2F RID: 23855 RVA: 0x00154B60 File Offset: 0x00152F60
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

		// Token: 0x06005D30 RID: 23856 RVA: 0x00154BD0 File Offset: 0x00152FD0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D31 RID: 23857 RVA: 0x00154BD7 File Offset: 0x00152FD7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D32 RID: 23858 RVA: 0x00154BE0 File Offset: 0x00152FE0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			FleshToStone.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new FleshToStone.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x0400503B RID: 20539
		internal AdventureEventType eventType;

		// Token: 0x0400503C RID: 20540
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x0400503D RID: 20541
		internal AdventureUnitSkill processingSkill;

		// Token: 0x0400503E RID: 20542
		internal double <possibility>__1;

		// Token: 0x0400503F RID: 20543
		internal double <rate>__2;

		// Token: 0x04005040 RID: 20544
		internal IEnumerator $locvar0;

		// Token: 0x04005041 RID: 20545
		internal object <_>__3;

		// Token: 0x04005042 RID: 20546
		internal IDisposable $locvar1;

		// Token: 0x04005043 RID: 20547
		internal FleshToStone $this;

		// Token: 0x04005044 RID: 20548
		internal object $current;

		// Token: 0x04005045 RID: 20549
		internal bool $disposing;

		// Token: 0x04005046 RID: 20550
		internal int $PC;
	}
}
