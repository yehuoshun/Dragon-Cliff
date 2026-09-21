using System;
using System.Collections.Generic;

// Token: 0x020006D2 RID: 1746
public class FriendlyAllStrategy : ActiveSkillTargetingStrategyBase
{
	// Token: 0x06002F6E RID: 12142 RVA: 0x00144A20 File Offset: 0x00142E20
	public FriendlyAllStrategy(AdventureUnitSkill skill) : base(skill)
	{
		base.Selections = new List<IBattleUnit>();
		base.IsResolved = false;
		BattleEncounter battleEncounter = skill.SourceUnit.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			base.Selections = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
			base.IsResolved = true;
		}
	}

	// Token: 0x06002F6F RID: 12143 RVA: 0x00144A76 File Offset: 0x00142E76
	public override List<IBattleUnit> GetCandidates()
	{
		return base.Selections;
	}

	// Token: 0x06002F70 RID: 12144 RVA: 0x00144A7E File Offset: 0x00142E7E
	protected override bool SelectionValidate(List<IBattleUnit> selections)
	{
		return true;
	}
}
