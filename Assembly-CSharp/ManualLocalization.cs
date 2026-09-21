using System;
using UnityEngine;

// Token: 0x020009D7 RID: 2519
[Serializable]
public class ManualLocalization
{
	// Token: 0x06004512 RID: 17682 RVA: 0x001BEE48 File Offset: 0x001BD248
	public ManualLocalization()
	{
	}

	// Token: 0x04003428 RID: 13352
	public ManualType ManualType;

	// Token: 0x04003429 RID: 13353
	public string Name;

	// Token: 0x0400342A RID: 13354
	[TextArea]
	public string Description;
}
