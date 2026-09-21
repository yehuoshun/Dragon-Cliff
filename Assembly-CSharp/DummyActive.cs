using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006BF RID: 1727
public class DummyActive : ActiveSkillLogicBase
{
	// Token: 0x06002E26 RID: 11814 RVA: 0x00135093 File Offset: 0x00133493
	public DummyActive()
	{
	}

	// Token: 0x170005E6 RID: 1510
	// (get) Token: 0x06002E27 RID: 11815 RVA: 0x001350CB File Offset: 0x001334CB
	public override SkillCategory SkillCategory
	{
		get
		{
			return this._skillCategory;
		}
	}

	// Token: 0x170005E7 RID: 1511
	// (get) Token: 0x06002E28 RID: 11816 RVA: 0x001350D3 File Offset: 0x001334D3
	public override OutputType SkillOutputType
	{
		get
		{
			return this._skillOutputType;
		}
	}

	// Token: 0x170005E8 RID: 1512
	// (get) Token: 0x06002E29 RID: 11817 RVA: 0x001350DB File Offset: 0x001334DB
	public override TargetingType TargetingType
	{
		get
		{
			return this._targetingType;
		}
	}

	// Token: 0x170005E9 RID: 1513
	// (get) Token: 0x06002E2A RID: 11818 RVA: 0x001350E3 File Offset: 0x001334E3
	public override SkillType SkillType
	{
		get
		{
			return this._skillType;
		}
	}

	// Token: 0x06002E2B RID: 11819 RVA: 0x001350EB File Offset: 0x001334EB
	public override bool IsSelfResolvable(AdventurerProfile profile)
	{
		return ActiveSkillLogicBase.IsSelfResolvable<FriendlyAllStrategy>();
	}

	// Token: 0x06002E2C RID: 11820 RVA: 0x001350F2 File Offset: 0x001334F2
	public override double GetGaugeCost(Skill skill)
	{
		return 50.0;
	}

	// Token: 0x06002E2D RID: 11821 RVA: 0x001350FD File Offset: 0x001334FD
	public override float? CoolingDownSeconds(Skill skill)
	{
		return this._coolingDownSeconds;
	}

	// Token: 0x06002E2E RID: 11822 RVA: 0x00135105 File Offset: 0x00133505
	public override ActiveSkillTargetingStrategyBase InitiatingTargetingStrategy(AdventureUnitSkill skill)
	{
		return new FriendlyAllStrategy(skill);
	}

	// Token: 0x06002E2F RID: 11823 RVA: 0x0013510D File Offset: 0x0013350D
	public override List<AdventureEventType> ActiveAdditionalEvents()
	{
		return new List<AdventureEventType>();
	}

	// Token: 0x06002E30 RID: 11824 RVA: 0x00135114 File Offset: 0x00133514
	public override IEnumerable PassiveEffectApplies(AdventureUnitSkill skill)
	{
		UnityEngine.Debug.Log(skill.Skill.SkillType + " Gauge Fully charged, and benefits are provided!");
		yield break;
	}

	// Token: 0x06002E31 RID: 11825 RVA: 0x00135138 File Offset: 0x00133538
	public override IEnumerable PassiveEffectLooses(AdventureUnitSkill skill)
	{
		UnityEngine.Debug.Log(skill.Skill.SkillType + " Gauge released, and benefits are removed!");
		yield break;
	}

	// Token: 0x06002E32 RID: 11826 RVA: 0x0013515C File Offset: 0x0013355C
	public override IEnumerable CastSkillLogic(AdventureUnitSkill skill, ActiveSkillTargetingStrategyBase strategy)
	{
		UnityEngine.Debug.Log("Dummy skill is performed");
		yield break;
	}

	// Token: 0x040026F8 RID: 9976
	private SkillCategory _skillCategory = SkillCategory.Offensive;

	// Token: 0x040026F9 RID: 9977
	private OutputType _skillOutputType = OutputType.Physical;

	// Token: 0x040026FA RID: 9978
	private TargetingType _targetingType = TargetingType.Multiple;

	// Token: 0x040026FB RID: 9979
	private SkillType _skillType = SkillType.Dummy;

	// Token: 0x040026FC RID: 9980
	private float? _coolingDownSeconds = new float?(5f);

	// Token: 0x02000E05 RID: 3589
	[CompilerGenerated]
	private sealed class <PassiveEffectApplies>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A27 RID: 23079 RVA: 0x00135178 File Offset: 0x00133578
		[DebuggerHidden]
		public <PassiveEffectApplies>c__Iterator0()
		{
		}

		// Token: 0x06005A28 RID: 23080 RVA: 0x00135180 File Offset: 0x00133580
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				UnityEngine.Debug.Log(skill.Skill.SkillType + " Gauge Fully charged, and benefits are provided!");
			}
			return false;
		}

		// Token: 0x170012CC RID: 4812
		// (get) Token: 0x06005A29 RID: 23081 RVA: 0x001351BE File Offset: 0x001335BE
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012CD RID: 4813
		// (get) Token: 0x06005A2A RID: 23082 RVA: 0x001351C6 File Offset: 0x001335C6
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A2B RID: 23083 RVA: 0x001351CE File Offset: 0x001335CE
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005A2C RID: 23084 RVA: 0x001351D0 File Offset: 0x001335D0
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A2D RID: 23085 RVA: 0x001351D7 File Offset: 0x001335D7
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A2E RID: 23086 RVA: 0x001351E0 File Offset: 0x001335E0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DummyActive.<PassiveEffectApplies>c__Iterator0 <PassiveEffectApplies>c__Iterator = new DummyActive.<PassiveEffectApplies>c__Iterator0();
			<PassiveEffectApplies>c__Iterator.skill = skill;
			return <PassiveEffectApplies>c__Iterator;
		}

		// Token: 0x04004ABE RID: 19134
		internal AdventureUnitSkill skill;

		// Token: 0x04004ABF RID: 19135
		internal object $current;

		// Token: 0x04004AC0 RID: 19136
		internal bool $disposing;

		// Token: 0x04004AC1 RID: 19137
		internal int $PC;
	}

	// Token: 0x02000E06 RID: 3590
	[CompilerGenerated]
	private sealed class <PassiveEffectLooses>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A2F RID: 23087 RVA: 0x00135214 File Offset: 0x00133614
		[DebuggerHidden]
		public <PassiveEffectLooses>c__Iterator1()
		{
		}

		// Token: 0x06005A30 RID: 23088 RVA: 0x0013521C File Offset: 0x0013361C
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				UnityEngine.Debug.Log(skill.Skill.SkillType + " Gauge released, and benefits are removed!");
			}
			return false;
		}

		// Token: 0x170012CE RID: 4814
		// (get) Token: 0x06005A31 RID: 23089 RVA: 0x0013525A File Offset: 0x0013365A
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012CF RID: 4815
		// (get) Token: 0x06005A32 RID: 23090 RVA: 0x00135262 File Offset: 0x00133662
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A33 RID: 23091 RVA: 0x0013526A File Offset: 0x0013366A
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005A34 RID: 23092 RVA: 0x0013526C File Offset: 0x0013366C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A35 RID: 23093 RVA: 0x00135273 File Offset: 0x00133673
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A36 RID: 23094 RVA: 0x0013527C File Offset: 0x0013367C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			DummyActive.<PassiveEffectLooses>c__Iterator1 <PassiveEffectLooses>c__Iterator = new DummyActive.<PassiveEffectLooses>c__Iterator1();
			<PassiveEffectLooses>c__Iterator.skill = skill;
			return <PassiveEffectLooses>c__Iterator;
		}

		// Token: 0x04004AC2 RID: 19138
		internal AdventureUnitSkill skill;

		// Token: 0x04004AC3 RID: 19139
		internal object $current;

		// Token: 0x04004AC4 RID: 19140
		internal bool $disposing;

		// Token: 0x04004AC5 RID: 19141
		internal int $PC;
	}

	// Token: 0x02000E07 RID: 3591
	[CompilerGenerated]
	private sealed class <CastSkillLogic>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005A37 RID: 23095 RVA: 0x001352B0 File Offset: 0x001336B0
		[DebuggerHidden]
		public <CastSkillLogic>c__Iterator2()
		{
		}

		// Token: 0x06005A38 RID: 23096 RVA: 0x001352B8 File Offset: 0x001336B8
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				UnityEngine.Debug.Log("Dummy skill is performed");
			}
			return false;
		}

		// Token: 0x170012D0 RID: 4816
		// (get) Token: 0x06005A39 RID: 23097 RVA: 0x001352DC File Offset: 0x001336DC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170012D1 RID: 4817
		// (get) Token: 0x06005A3A RID: 23098 RVA: 0x001352E4 File Offset: 0x001336E4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005A3B RID: 23099 RVA: 0x001352EC File Offset: 0x001336EC
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005A3C RID: 23100 RVA: 0x001352EE File Offset: 0x001336EE
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005A3D RID: 23101 RVA: 0x001352F5 File Offset: 0x001336F5
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005A3E RID: 23102 RVA: 0x001352FD File Offset: 0x001336FD
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new DummyActive.<CastSkillLogic>c__Iterator2();
		}

		// Token: 0x04004AC6 RID: 19142
		internal object $current;

		// Token: 0x04004AC7 RID: 19143
		internal bool $disposing;

		// Token: 0x04004AC8 RID: 19144
		internal int $PC;
	}
}
