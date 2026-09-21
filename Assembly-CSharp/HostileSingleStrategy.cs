using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x020006D6 RID: 1750
public class HostileSingleStrategy : ActiveSkillTargetingStrategyBase
{
	// Token: 0x06002F7A RID: 12154 RVA: 0x00144CB4 File Offset: 0x001430B4
	public HostileSingleStrategy(AdventureUnitSkill skill) : base(skill)
	{
		IBattleUnit sourceUnit = base.Skill.SourceUnit;
		BattleEncounter battleEncounter = sourceUnit.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			List<IBattleUnit> liveEnemyTargets = sourceUnit.GetLiveEnemyTargets(false, true);
			if (liveEnemyTargets.Count == 1)
			{
				base.Selections = liveEnemyTargets;
				base.IsResolved = true;
			}
			else
			{
				base.Selections = new List<IBattleUnit>();
				base.IsResolved = false;
			}
		}
	}

	// Token: 0x06002F7B RID: 12155 RVA: 0x00144D20 File Offset: 0x00143120
	public override List<IBattleUnit> GetCandidates()
	{
		IBattleUnit sourceUnit = base.Skill.SourceUnit;
		BattleEncounter battleEncounter = sourceUnit.CurrentEncounter as BattleEncounter;
		if (battleEncounter != null)
		{
			return sourceUnit.GetLiveEnemyTargets(false, true);
		}
		return new List<IBattleUnit>();
	}

	// Token: 0x06002F7C RID: 12156 RVA: 0x00144D5C File Offset: 0x0014315C
	protected override bool SelectionValidate(List<IBattleUnit> selections)
	{
		List<IBattleUnit> candidates = this.GetCandidates();
		return selections.Count == 1 && selections.All((IBattleUnit s) => candidates.Any((IBattleUnit c) => c == s));
	}

	// Token: 0x02000E41 RID: 3649
	[CompilerGenerated]
	private sealed class <SelectionValidate>c__AnonStorey0
	{
		// Token: 0x06005BC8 RID: 23496 RVA: 0x00144D9C File Offset: 0x0014319C
		public <SelectionValidate>c__AnonStorey0()
		{
		}

		// Token: 0x06005BC9 RID: 23497 RVA: 0x00144DA4 File Offset: 0x001431A4
		internal bool <>m__0(IBattleUnit s)
		{
			return this.candidates.Any((IBattleUnit c) => c == s);
		}

		// Token: 0x04004DD9 RID: 19929
		internal List<IBattleUnit> candidates;

		// Token: 0x02000E42 RID: 3650
		private sealed class <SelectionValidate>c__AnonStorey1
		{
			// Token: 0x06005BCA RID: 23498 RVA: 0x00144DDC File Offset: 0x001431DC
			public <SelectionValidate>c__AnonStorey1()
			{
			}

			// Token: 0x06005BCB RID: 23499 RVA: 0x00144DE4 File Offset: 0x001431E4
			internal bool <>m__0(IBattleUnit c)
			{
				return c == this.s;
			}

			// Token: 0x04004DDA RID: 19930
			internal IBattleUnit s;

			// Token: 0x04004DDB RID: 19931
			internal HostileSingleStrategy.<SelectionValidate>c__AnonStorey0 <>f__ref$0;
		}
	}
}
