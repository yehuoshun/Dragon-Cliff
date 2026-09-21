using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020006D4 RID: 1748
public class FriendlySingleStrategy : ActiveSkillTargetingStrategyBase
{
	// Token: 0x06002F74 RID: 12148 RVA: 0x00144B18 File Offset: 0x00142F18
	public FriendlySingleStrategy(AdventureUnitSkill skill) : base(skill)
	{
		IBattleUnit sourceUnit = base.Skill.SourceUnit;
		BattleEncounter battleEncounter = sourceUnit.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			List<IBattleUnit> allLiveFriendlyTargetsIncSelf = sourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
			if (allLiveFriendlyTargetsIncSelf.Count == 1)
			{
				base.Selections = allLiveFriendlyTargetsIncSelf;
				base.IsResolved = true;
			}
			else
			{
				base.Selections = new List<IBattleUnit>();
				base.IsResolved = false;
			}
		}
	}

	// Token: 0x06002F75 RID: 12149 RVA: 0x00144B84 File Offset: 0x00142F84
	public override List<IBattleUnit> GetCandidates()
	{
		IBattleUnit sourceUnit = base.Skill.SourceUnit;
		BattleEncounter battleEncounter = sourceUnit.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			return sourceUnit.GetAllLiveFriendlyTargetsIncSelf(true);
		}
		return new List<IBattleUnit>();
	}

	// Token: 0x06002F76 RID: 12150 RVA: 0x00144BBC File Offset: 0x00142FBC
	protected override bool SelectionValidate(List<IBattleUnit> selections)
	{
		List<IBattleUnit> candidates = this.GetCandidates();
		return selections.Count == 1 && selections.All((IBattleUnit s) => candidates.Any((IBattleUnit c) => c == s));
	}

	// Token: 0x02000E3F RID: 3647
	[CompilerGenerated]
	private sealed class <SelectionValidate>c__AnonStorey0
	{
		// Token: 0x06005BC4 RID: 23492 RVA: 0x00144BFC File Offset: 0x00142FFC
		public <SelectionValidate>c__AnonStorey0()
		{
		}

		// Token: 0x06005BC5 RID: 23493 RVA: 0x00144C04 File Offset: 0x00143004
		internal bool <>m__0(IBattleUnit s)
		{
			return this.candidates.Any((IBattleUnit c) => c == s);
		}

		// Token: 0x04004DD6 RID: 19926
		internal List<IBattleUnit> candidates;

		// Token: 0x02000E40 RID: 3648
		private sealed class <SelectionValidate>c__AnonStorey1
		{
			// Token: 0x06005BC6 RID: 23494 RVA: 0x00144C3C File Offset: 0x0014303C
			public <SelectionValidate>c__AnonStorey1()
			{
			}

			// Token: 0x06005BC7 RID: 23495 RVA: 0x00144C44 File Offset: 0x00143044
			internal bool <>m__0(IBattleUnit c)
			{
				return c == this.s;
			}

			// Token: 0x04004DD7 RID: 19927
			internal IBattleUnit s;

			// Token: 0x04004DD8 RID: 19928
			internal FriendlySingleStrategy.<SelectionValidate>c__AnonStorey0 <>f__ref$0;
		}
	}
}
