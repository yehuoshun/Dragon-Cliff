using System;
using System.Collections.Generic;

// Token: 0x020006D5 RID: 1749
public class HostileAllStrategy : ActiveSkillTargetingStrategyBase
{
	// Token: 0x06002F77 RID: 12151 RVA: 0x00144C50 File Offset: 0x00143050
	public HostileAllStrategy(AdventureUnitSkill skill) : base(skill)
	{
		base.Selections = new List<IBattleUnit>();
		base.IsResolved = false;
		BattleEncounter battleEncounter = skill.SourceUnit.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			base.Selections = skill.SourceUnit.GetLiveEnemyTargets(false, true);
			base.IsResolved = true;
		}
	}

	// Token: 0x06002F78 RID: 12152 RVA: 0x00144CA7 File Offset: 0x001430A7
	public override List<IBattleUnit> GetCandidates()
	{
		return base.Selections;
	}

	// Token: 0x06002F79 RID: 12153 RVA: 0x00144CAF File Offset: 0x001430AF
	protected override bool SelectionValidate(List<IBattleUnit> selections)
	{
		return true;
	}
}
