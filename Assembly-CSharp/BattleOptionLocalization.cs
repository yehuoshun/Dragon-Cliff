using System;
using UnityEngine;

// Token: 0x020009EA RID: 2538
[Serializable]
public class BattleOptionLocalization
{
	// Token: 0x06004525 RID: 17701 RVA: 0x001BEEE0 File Offset: 0x001BD2E0
	public BattleOptionLocalization()
	{
	}

	// Token: 0x04003463 RID: 13411
	public BattleOptionType Type;

	// Token: 0x04003464 RID: 13412
	public string Name;

	// Token: 0x04003465 RID: 13413
	[TextArea]
	public string Description;
}
