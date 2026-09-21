using System;
using UnityEngine;

// Token: 0x020009E9 RID: 2537
[Serializable]
public class UpgradeCardLocalization
{
	// Token: 0x06004524 RID: 17700 RVA: 0x001BEED8 File Offset: 0x001BD2D8
	public UpgradeCardLocalization()
	{
	}

	// Token: 0x04003460 RID: 13408
	public UpgradeCardType Type;

	// Token: 0x04003461 RID: 13409
	public string Name;

	// Token: 0x04003462 RID: 13410
	[TextArea]
	public string Description;
}
