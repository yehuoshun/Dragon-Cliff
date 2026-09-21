using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000433 RID: 1075
public class SkillCastBattleEvent
{
	// Token: 0x06001E2B RID: 7723 RVA: 0x000D4D22 File Offset: 0x000D3122
	public SkillCastBattleEvent()
	{
	}

	// Token: 0x17000184 RID: 388
	// (get) Token: 0x06001E2C RID: 7724 RVA: 0x000D4D2A File Offset: 0x000D312A
	// (set) Token: 0x06001E2D RID: 7725 RVA: 0x000D4D32 File Offset: 0x000D3132
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

	// Token: 0x17000185 RID: 389
	// (get) Token: 0x06001E2E RID: 7726 RVA: 0x000D4D3B File Offset: 0x000D313B
	// (set) Token: 0x06001E2F RID: 7727 RVA: 0x000D4D43 File Offset: 0x000D3143
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

	// Token: 0x04001BDE RID: 7134
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventureUnitSkill <Skill>k__BackingField;

	// Token: 0x04001BDF RID: 7135
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SkillLogicBase <SkillLogic>k__BackingField;
}
