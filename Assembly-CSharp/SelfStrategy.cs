using System;
using System.Collections.Generic;

// Token: 0x020006D7 RID: 1751
public class SelfStrategy : ActiveSkillTargetingStrategyBase
{
	// Token: 0x06002F7D RID: 12157 RVA: 0x00144DF0 File Offset: 0x001431F0
	public SelfStrategy(AdventureUnitSkill skill) : base(skill)
	{
		base.IsResolved = true;
		base.Selections = new List<IBattleUnit>
		{
			skill.SourceUnit
		};
	}

	// Token: 0x06002F7E RID: 12158 RVA: 0x00144E24 File Offset: 0x00143224
	public override List<IBattleUnit> GetCandidates()
	{
		return new List<IBattleUnit>
		{
			base.Skill.SourceUnit
		};
	}

	// Token: 0x06002F7F RID: 12159 RVA: 0x00144E49 File Offset: 0x00143249
	protected override bool SelectionValidate(List<IBattleUnit> selections)
	{
		return true;
	}
}
