using System;

// Token: 0x0200072E RID: 1838
[Serializable]
public class Skill
{
	// Token: 0x0600339F RID: 13215 RVA: 0x0015A628 File Offset: 0x00158A28
	public Skill()
	{
	}

	// Token: 0x060033A0 RID: 13216 RVA: 0x0015A630 File Offset: 0x00158A30
	public AdventureUnitSkill InitializeBattleUnitSkill(IBattleUnit casterUnit)
	{
		return new AdventureUnitSkill(this, casterUnit);
	}

	// Token: 0x04002837 RID: 10295
	public SkillType SkillType;

	// Token: 0x04002838 RID: 10296
	public int Level;

	// Token: 0x04002839 RID: 10297
	public SkillCommandType CommandType;

	// Token: 0x0400283A RID: 10298
	public bool IsEnabled;
}
