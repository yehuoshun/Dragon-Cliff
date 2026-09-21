using System;
using System.Collections.Generic;

// Token: 0x02000A2F RID: 2607
public class AffixPresence : IPresentable
{
	// Token: 0x06004729 RID: 18217 RVA: 0x001D1741 File Offset: 0x001CFB41
	public AffixPresence()
	{
	}

	// Token: 0x0600472A RID: 18218 RVA: 0x001D1749 File Offset: 0x001CFB49
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x04003956 RID: 14678
	public int Presence;

	// Token: 0x04003957 RID: 14679
	public List<AffixType> Affixs;
}
