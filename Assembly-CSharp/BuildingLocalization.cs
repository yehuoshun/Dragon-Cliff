using System;
using UnityEngine;

// Token: 0x020009CF RID: 2511
[Serializable]
public class BuildingLocalization
{
	// Token: 0x0600450A RID: 17674 RVA: 0x001BEE08 File Offset: 0x001BD208
	public BuildingLocalization()
	{
	}

	// Token: 0x04003412 RID: 13330
	public BuildingType BuildingType;

	// Token: 0x04003413 RID: 13331
	public string Title;

	// Token: 0x04003414 RID: 13332
	[TextArea]
	public string Description;
}
