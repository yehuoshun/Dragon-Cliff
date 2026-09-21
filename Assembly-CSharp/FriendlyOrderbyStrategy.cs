using System;
using System.Collections.Generic;
using System.Linq;

// Token: 0x020006D3 RID: 1747
public class FriendlyOrderbyStrategy : ActiveSkillTargetingStrategyBase
{
	// Token: 0x06002F71 RID: 12145 RVA: 0x00144A84 File Offset: 0x00142E84
	public FriendlyOrderbyStrategy(AdventureUnitSkill skill, int take, Func<IBattleUnit, double> compareFunc, bool isAsc) : base(skill)
	{
		base.Selections = new List<IBattleUnit>();
		base.IsResolved = false;
		BattleEncounter battleEncounter = skill.SourceUnit.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			List<IBattleUnit> source = skill.SourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
			if (isAsc)
			{
				source = source.OrderBy(compareFunc).ToList<IBattleUnit>();
			}
			else
			{
				source = source.OrderByDescending(compareFunc).ToList<IBattleUnit>();
			}
			base.Selections = source.Take(take).ToList<IBattleUnit>();
			base.IsResolved = true;
		}
	}

	// Token: 0x06002F72 RID: 12146 RVA: 0x00144B0D File Offset: 0x00142F0D
	public override List<IBattleUnit> GetCandidates()
	{
		return base.Selections;
	}

	// Token: 0x06002F73 RID: 12147 RVA: 0x00144B15 File Offset: 0x00142F15
	protected override bool SelectionValidate(List<IBattleUnit> selections)
	{
		return true;
	}
}
