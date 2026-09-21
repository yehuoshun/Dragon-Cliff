using System;
using UnityEngine;

// Token: 0x020009E1 RID: 2529
[Serializable]
public class OutputTypeLocalization
{
	// Token: 0x0600451C RID: 17692 RVA: 0x001BEE98 File Offset: 0x001BD298
	public OutputTypeLocalization()
	{
	}

	// Token: 0x04003448 RID: 13384
	public OutputType OutputType;

	// Token: 0x04003449 RID: 13385
	public string Name;

	// Token: 0x0400344A RID: 13386
	[TextArea]
	public string Description;
}
