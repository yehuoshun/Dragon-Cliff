using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200042C RID: 1068
public class AdventureUnitSkill : IBattleEffectSource
{
	// Token: 0x06001D95 RID: 7573 RVA: 0x000CC63D File Offset: 0x000CAA3D
	public AdventureUnitSkill(Skill skill, IBattleUnit sourceCaster)
	{
		this.Skill = skill;
		this.SourceUnit = sourceCaster;
		this.PassiveHasBeenRecentlyApplied = false;
	}

	// Token: 0x17000155 RID: 341
	// (get) Token: 0x06001D96 RID: 7574 RVA: 0x000CC65A File Offset: 0x000CAA5A
	// (set) Token: 0x06001D97 RID: 7575 RVA: 0x000CC662 File Offset: 0x000CAA62
	public Skill Skill
	{
		[CompilerGenerated]
		get
		{
			return this.<Skill>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Skill>k__BackingField = value;
		}
	}

	// Token: 0x17000156 RID: 342
	// (get) Token: 0x06001D98 RID: 7576 RVA: 0x000CC66B File Offset: 0x000CAA6B
	// (set) Token: 0x06001D99 RID: 7577 RVA: 0x000CC673 File Offset: 0x000CAA73
	public IBattleUnit SourceUnit
	{
		[CompilerGenerated]
		get
		{
			return this.<SourceUnit>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<SourceUnit>k__BackingField = value;
		}
	}

	// Token: 0x06001D9A RID: 7578 RVA: 0x000CC67C File Offset: 0x000CAA7C
	public List<IAdventurerTalent> GetActiveTalents()
	{
		if (!(this.SourceUnit is AdventurerBattleUnit))
		{
			return new List<IAdventurerTalent>();
		}
		if (this.Skill.CommandType == SkillCommandType.Main)
		{
			return (from t in (this.SourceUnit as AdventurerBattleUnit).AdventurerProfile.Talents
			where t.GetTier() == AdventurerTalentTier.Second && t.GetCurrentLevel() > 0
			select t).ToList<IAdventurerTalent>();
		}
		if (this.Skill.CommandType == SkillCommandType.Active)
		{
			return (from t in (this.SourceUnit as AdventurerBattleUnit).AdventurerProfile.Talents
			where t.GetTier() == AdventurerTalentTier.Forth && t.GetCurrentLevel() > 0
			select t).ToList<IAdventurerTalent>();
		}
		return new List<IAdventurerTalent>();
	}

	// Token: 0x06001D9B RID: 7579 RVA: 0x000CC73F File Offset: 0x000CAB3F
	public int GetExtraSkillTargets()
	{
		return this.GetActiveTalents().OfType<SkillExtraTargetTalent>().Sum((SkillExtraTargetTalent t) => t.GetExtra());
	}

	// Token: 0x06001D9C RID: 7580 RVA: 0x000CC76E File Offset: 0x000CAB6E
	[CompilerGenerated]
	private static bool <GetActiveTalents>m__0(IAdventurerTalent t)
	{
		return t.GetTier() == AdventurerTalentTier.Second && t.GetCurrentLevel() > 0;
	}

	// Token: 0x06001D9D RID: 7581 RVA: 0x000CC788 File Offset: 0x000CAB88
	[CompilerGenerated]
	private static bool <GetActiveTalents>m__1(IAdventurerTalent t)
	{
		return t.GetTier() == AdventurerTalentTier.Forth && t.GetCurrentLevel() > 0;
	}

	// Token: 0x06001D9E RID: 7582 RVA: 0x000CC7A2 File Offset: 0x000CABA2
	[CompilerGenerated]
	private static int <GetExtraSkillTargets>m__2(SkillExtraTargetTalent t)
	{
		return t.GetExtra();
	}

	// Token: 0x04001B92 RID: 7058
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Skill <Skill>k__BackingField;

	// Token: 0x04001B93 RID: 7059
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <SourceUnit>k__BackingField;

	// Token: 0x04001B94 RID: 7060
	public float Timer;

	// Token: 0x04001B95 RID: 7061
	public float? RemainingCoolingDownSeconds;

	// Token: 0x04001B96 RID: 7062
	public bool PassiveHasBeenRecentlyApplied;

	// Token: 0x04001B97 RID: 7063
	public bool InProgress;

	// Token: 0x04001B98 RID: 7064
	[CompilerGenerated]
	private static Func<IAdventurerTalent, bool> <>f__am$cache0;

	// Token: 0x04001B99 RID: 7065
	[CompilerGenerated]
	private static Func<IAdventurerTalent, bool> <>f__am$cache1;

	// Token: 0x04001B9A RID: 7066
	[CompilerGenerated]
	private static Func<SkillExtraTargetTalent, int> <>f__am$cache2;
}
