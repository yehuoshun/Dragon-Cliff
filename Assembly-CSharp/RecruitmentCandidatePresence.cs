using System;

// Token: 0x02000478 RID: 1144
[Serializable]
public class RecruitmentCandidatePresence : IPresentable
{
	// Token: 0x06002072 RID: 8306 RVA: 0x000E1564 File Offset: 0x000DF964
	public RecruitmentCandidatePresence()
	{
	}

	// Token: 0x06002073 RID: 8307 RVA: 0x000E156C File Offset: 0x000DF96C
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x04001CE1 RID: 7393
	public int Presence;

	// Token: 0x04001CE2 RID: 7394
	public UnitClass UnitClass;
}
