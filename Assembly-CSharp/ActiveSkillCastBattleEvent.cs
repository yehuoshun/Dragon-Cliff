using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000431 RID: 1073
public class ActiveSkillCastBattleEvent
{
	// Token: 0x06001E1D RID: 7709 RVA: 0x000D4CAC File Offset: 0x000D30AC
	public ActiveSkillCastBattleEvent()
	{
	}

	// Token: 0x1700017E RID: 382
	// (get) Token: 0x06001E1E RID: 7710 RVA: 0x000D4CB4 File Offset: 0x000D30B4
	// (set) Token: 0x06001E1F RID: 7711 RVA: 0x000D4CBC File Offset: 0x000D30BC
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

	// Token: 0x1700017F RID: 383
	// (get) Token: 0x06001E20 RID: 7712 RVA: 0x000D4CC5 File Offset: 0x000D30C5
	// (set) Token: 0x06001E21 RID: 7713 RVA: 0x000D4CCD File Offset: 0x000D30CD
	public SkillLogicBase SkillLogic
	{
		[CompilerGenerated]
		get
		{
			return this.<SkillLogic>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SkillLogic>k__BackingField = value;
		}
	}

	// Token: 0x17000180 RID: 384
	// (get) Token: 0x06001E22 RID: 7714 RVA: 0x000D4CD6 File Offset: 0x000D30D6
	// (set) Token: 0x06001E23 RID: 7715 RVA: 0x000D4CDE File Offset: 0x000D30DE
	public ActiveSkillTargetingStrategyBase TargetingStrategy
	{
		[CompilerGenerated]
		get
		{
			return this.<TargetingStrategy>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<TargetingStrategy>k__BackingField = value;
		}
	}

	// Token: 0x04001BD8 RID: 7128
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureUnitSkill <Skill>k__BackingField;

	// Token: 0x04001BD9 RID: 7129
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SkillLogicBase <SkillLogic>k__BackingField;

	// Token: 0x04001BDA RID: 7130
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ActiveSkillTargetingStrategyBase <TargetingStrategy>k__BackingField;
}
