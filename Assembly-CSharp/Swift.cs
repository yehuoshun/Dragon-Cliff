using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000720 RID: 1824
public class Swift : SecondarySkillBase
{
	// Token: 0x060032D0 RID: 13008 RVA: 0x00157458 File Offset: 0x00155858
	public Swift()
	{
	}

	// Token: 0x170007B7 RID: 1975
	// (get) Token: 0x060032D1 RID: 13009 RVA: 0x00157473 File Offset: 0x00155873
	public override CastingStyle CastingStyle
	{
		get
		{
			return CastingStyle.Passive;
		}
	}

	// Token: 0x170007B8 RID: 1976
	// (get) Token: 0x060032D2 RID: 13010 RVA: 0x00157476 File Offset: 0x00155876
	public override SkillCategory SkillCategory
	{
		get
		{
			return SkillCategory.Supportive;
		}
	}

	// Token: 0x170007B9 RID: 1977
	// (get) Token: 0x060032D3 RID: 13011 RVA: 0x00157479 File Offset: 0x00155879
	public override OutputType SkillOutputType
	{
		get
		{
			return OutputType.None;
		}
	}

	// Token: 0x170007BA RID: 1978
	// (get) Token: 0x060032D4 RID: 13012 RVA: 0x0015747C File Offset: 0x0015587C
	public override TargetingType TargetingType
	{
		get
		{
			return TargetingType.None;
		}
	}

	// Token: 0x060032D5 RID: 13013 RVA: 0x00157480 File Offset: 0x00155880
	public override List<AdventureEventType> AdditionalRelatedEvents()
	{
		return new List<AdventureEventType>
		{
			AdventureEventType.UnitCompletesAction
		};
	}

	// Token: 0x170007BB RID: 1979
	// (get) Token: 0x060032D6 RID: 13014 RVA: 0x0015749C File Offset: 0x0015589C
	public override int? RequiredSchoolLevel
	{
		get
		{
			return this._requiredSchoolLevel;
		}
	}

	// Token: 0x170007BC RID: 1980
	// (get) Token: 0x060032D7 RID: 13015 RVA: 0x001574A4 File Offset: 0x001558A4
	public override SkillType SkillType
	{
		get
		{
			return SkillType.Swift;
		}
	}

	// Token: 0x170007BD RID: 1981
	// (get) Token: 0x060032D8 RID: 13016 RVA: 0x001574AB File Offset: 0x001558AB
	public override SkillCommandType SkillCommandType
	{
		get
		{
			return this._skillCommandType;
		}
	}

	// Token: 0x060032D9 RID: 13017 RVA: 0x001574B3 File Offset: 0x001558B3
	private double SwiftChance(Skill skill)
	{
		return 0.25 + (double)(skill.Level - 1) * 0.05;
	}

	// Token: 0x060032DA RID: 13018 RVA: 0x001574D2 File Offset: 0x001558D2
	public override Description ParseLogic(Description description, Skill skill)
	{
		description.Details1 = description.Details1.Replace(this.PossibilityKey, this.SwiftChance(skill).ToExpressionMultiply100());
		return description;
	}

	// Token: 0x060032DB RID: 13019 RVA: 0x001574F8 File Offset: 0x001558F8
	public override IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(AdventureUnitSkill processingSkill, IBattleUnit eventTriggerUnit, IBattleUnit skillOwner, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitCompletesAction && skillOwner.Status != BattleUnitStatus.Dead)
		{
			List<IBattleUnit> enemies = skillOwner.GetLiveEnemyTargets(false, false);
			if (enemies.Any((IBattleUnit e) => e == eventTriggerUnit) && (double)UnityEngine.Random.value <= this.SwiftChance(processingSkill.Skill))
			{
				UnitTurnProgressUpdateEvent pushEffect = new UnitTurnProgressUpdateEvent
				{
					CausingSource = processingSkill,
					Dealer = processingSkill.SourceUnit,
					ChangePercentage = 0.2
				};
				IEnumerator enumerator = skillOwner.ChangeTurnCounterProgress(pushEffect).GetEnumerator();
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

	// Token: 0x040027D5 RID: 10197
	private SkillCommandType _skillCommandType = SkillCommandType.Secondary;

	// Token: 0x040027D6 RID: 10198
	private int? _requiredSchoolLevel = new int?(1);

	// Token: 0x02000E84 RID: 3716
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005D90 RID: 23952 RVA: 0x00157538 File Offset: 0x00155938
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0()
		{
		}

		// Token: 0x06005D91 RID: 23953 RVA: 0x00157540 File Offset: 0x00155940
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType != AdventureEventType.UnitCompletesAction || skillOwner.Status == BattleUnitStatus.Dead)
				{
					goto IL_198;
				}
				enemies = skillOwner.GetLiveEnemyTargets(false, false);
				if (!enemies.Any((IBattleUnit e) => e == eventTriggerUnit) || (double)UnityEngine.Random.value > base.SwiftChance(processingSkill.Skill))
				{
					goto IL_198;
				}
				pushEffect = new UnitTurnProgressUpdateEvent
				{
					CausingSource = processingSkill,
					Dealer = processingSkill.SourceUnit,
					ChangePercentage = 0.2
				};
				enumerator = skillOwner.ChangeTurnCounterProgress(pushEffect).GetEnumerator();
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
			IL_198:
			this.$PC = -1;
			return false;
		}

		// Token: 0x1700138A RID: 5002
		// (get) Token: 0x06005D92 RID: 23954 RVA: 0x00157700 File Offset: 0x00155B00
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700138B RID: 5003
		// (get) Token: 0x06005D93 RID: 23955 RVA: 0x00157708 File Offset: 0x00155B08
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005D94 RID: 23956 RVA: 0x00157710 File Offset: 0x00155B10
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

		// Token: 0x06005D95 RID: 23957 RVA: 0x00157780 File Offset: 0x00155B80
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005D96 RID: 23958 RVA: 0x00157787 File Offset: 0x00155B87
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005D97 RID: 23959 RVA: 0x00157790 File Offset: 0x00155B90
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			Swift.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator = new Swift.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0();
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.$this = this;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventType = eventType;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.skillOwner = skillOwner;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator.processingSkill = processingSkill;
			return <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator;
		}

		// Token: 0x040050DE RID: 20702
		internal AdventureEventType eventType;

		// Token: 0x040050DF RID: 20703
		internal IBattleUnit skillOwner;

		// Token: 0x040050E0 RID: 20704
		internal List<IBattleUnit> <enemies>__1;

		// Token: 0x040050E1 RID: 20705
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x040050E2 RID: 20706
		internal AdventureUnitSkill processingSkill;

		// Token: 0x040050E3 RID: 20707
		internal UnitTurnProgressUpdateEvent <pushEffect>__2;

		// Token: 0x040050E4 RID: 20708
		internal IEnumerator $locvar0;

		// Token: 0x040050E5 RID: 20709
		internal object <_>__3;

		// Token: 0x040050E6 RID: 20710
		internal IDisposable $locvar1;

		// Token: 0x040050E7 RID: 20711
		internal Swift $this;

		// Token: 0x040050E8 RID: 20712
		internal object $current;

		// Token: 0x040050E9 RID: 20713
		internal bool $disposing;

		// Token: 0x040050EA RID: 20714
		internal int $PC;

		// Token: 0x040050EB RID: 20715
		private Swift.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0.<ProcessEvent_ExtraLogic_ActiveUnit>c__AnonStorey1 $locvar2;

		// Token: 0x02000E85 RID: 3717
		private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__AnonStorey1
		{
			// Token: 0x06005D98 RID: 23960 RVA: 0x001577F4 File Offset: 0x00155BF4
			public <ProcessEvent_ExtraLogic_ActiveUnit>c__AnonStorey1()
			{
			}

			// Token: 0x06005D99 RID: 23961 RVA: 0x001577FC File Offset: 0x00155BFC
			internal bool <>m__0(IBattleUnit e)
			{
				return e == this.eventTriggerUnit;
			}

			// Token: 0x040050EC RID: 20716
			internal IBattleUnit eventTriggerUnit;

			// Token: 0x040050ED RID: 20717
			internal Swift.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator0 <>f__ref$0;
		}
	}
}
