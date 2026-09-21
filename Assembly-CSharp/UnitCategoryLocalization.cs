using System;
using UnityEngine;

// Token: 0x020009DF RID: 2527
[Serializable]
public class UnitCategoryLocalization
{
	// Token: 0x0600451A RID: 17690 RVA: 0x001BEE88 File Offset: 0x001BD288
	public UnitCategoryLocalization()
	{
	}

	// Token: 0x04003442 RID: 13378
	public ClassCategory ClassCategoryIdentifier;

	// Token: 0x04003443 RID: 13379
	public string Name;

	// Token: 0x04003444 RID: 13380
	[TextArea]
	public string Description;
}
