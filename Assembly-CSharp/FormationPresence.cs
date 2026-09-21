using System;
using System.Collections.Generic;

// Token: 0x0200044C RID: 1100
[Serializable]
public class FormationPresence : IPresentable
{
	// Token: 0x06001F3C RID: 7996 RVA: 0x000DBF42 File Offset: 0x000DA342
	public FormationPresence()
	{
	}

	// Token: 0x06001F3D RID: 7997 RVA: 0x000DBF4A File Offset: 0x000DA34A
	public int GetPresence()
	{
		return this.Presence;
	}

	// Token: 0x04001C46 RID: 7238
	public int Presence;

	// Token: 0x04001C47 RID: 7239
	public UnitClass Boss;

	// Token: 0x04001C48 RID: 7240
	public List<UnitClass> Minions;
}
