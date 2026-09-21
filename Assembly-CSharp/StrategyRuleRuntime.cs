using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020006D9 RID: 1753
public class StrategyRuleRuntime
{
	// Token: 0x06002F87 RID: 12167 RVA: 0x00144E87 File Offset: 0x00143287
	public StrategyRuleRuntime()
	{
	}

	// Token: 0x17000634 RID: 1588
	// (get) Token: 0x06002F88 RID: 12168 RVA: 0x00144E8F File Offset: 0x0014328F
	// (set) Token: 0x06002F89 RID: 12169 RVA: 0x00144E97 File Offset: 0x00143297
	public AdventureUnitSkill Skill
	{
		[CompilerGenerated]
		get
		{
			return this.<Skill>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Skill>k__BackingField = value;
		}
	}

	// Token: 0x17000635 RID: 1589
	// (get) Token: 0x06002F8A RID: 12170 RVA: 0x00144EA0 File Offset: 0x001432A0
	// (set) Token: 0x06002F8B RID: 12171 RVA: 0x00144EA8 File Offset: 0x001432A8
	public CandidateOrderringMetric CandidateOrderringMetric
	{
		[CompilerGenerated]
		get
		{
			return this.<CandidateOrderringMetric>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<CandidateOrderringMetric>k__BackingField = value;
		}
	}

	// Token: 0x17000636 RID: 1590
	// (get) Token: 0x06002F8C RID: 12172 RVA: 0x00144EB1 File Offset: 0x001432B1
	// (set) Token: 0x06002F8D RID: 12173 RVA: 0x00144EB9 File Offset: 0x001432B9
	public OrderingType OrderingType
	{
		[CompilerGenerated]
		get
		{
			return this.<OrderingType>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<OrderingType>k__BackingField = value;
		}
	}

	// Token: 0x06002F8E RID: 12174 RVA: 0x00144EC4 File Offset: 0x001432C4
	public static StrategyRuleRuntime CreateRuntimeRule(AdventurerBattleUnit unit, StrategyRule rule)
	{
		AdventureUnitSkill skill = unit.Skills.FirstOrDefault((AdventureUnitSkill sk) => sk.Skill.CommandType == SkillCommandType.Active);
		CandidateOrderringMetric candidateOrderringMetric = (rule.OrderringMetric == null) ? CandidateOrderringMetric.Random : rule.OrderringMetric.Value;
		OrderingType orderingType = (rule.OrderingType == null) ? OrderingType.Nature : rule.OrderingType.Value;
		return new StrategyRuleRuntime
		{
			Skill = skill,
			OrderingType = orderingType,
			CandidateOrderringMetric = candidateOrderringMetric
		};
	}

	// Token: 0x06002F8F RID: 12175 RVA: 0x00144F6F File Offset: 0x0014336F
	[CompilerGenerated]
	private static bool <CreateRuntimeRule>m__0(AdventureUnitSkill sk)
	{
		return sk.Skill.CommandType == SkillCommandType.Active;
	}

	// Token: 0x0400274C RID: 10060
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureUnitSkill <Skill>k__BackingField;

	// Token: 0x0400274D RID: 10061
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CandidateOrderringMetric <CandidateOrderringMetric>k__BackingField;

	// Token: 0x0400274E RID: 10062
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OrderingType <OrderingType>k__BackingField;

	// Token: 0x0400274F RID: 10063
	[CompilerGenerated]
	private static Func<AdventureUnitSkill, bool> <>f__am$cache0;
}
