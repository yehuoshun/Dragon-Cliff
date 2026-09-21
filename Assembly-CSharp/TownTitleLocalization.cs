using System;
using UnityEngine;

// Token: 0x020009E4 RID: 2532
[Serializable]
public class TownTitleLocalization
{
	// Token: 0x0600451F RID: 17695 RVA: 0x001BEEB0 File Offset: 0x001BD2B0
	public TownTitleLocalization()
	{
	}

	// Token: 0x04003451 RID: 13393
	public TownTitleType TownTitleType;

	// Token: 0x04003452 RID: 13394
	public string Name;

	// Token: 0x04003453 RID: 13395
	[TextArea]
	public string Description;
}
