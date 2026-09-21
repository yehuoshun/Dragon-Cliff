using System;
using System.Collections.Generic;

// Token: 0x02000A41 RID: 2625
public class SkillPresence : IPresentable
{
	// Token: 0x06004781 RID: 18305 RVA: 0x001D82DA File Offset: 0x001D66DA
	public SkillPresence()
	{
	}

	// Token: 0x06004782 RID: 18306 RVA: 0x001D82E2 File Offset: 0x001D66E2
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x04003965 RID: 14693
	public int Presence;

	// Token: 0x04003966 RID: 14694
	public List<SkillType> Skills;
}
