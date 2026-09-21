using System;
using UnityEngine;

// Token: 0x020009CC RID: 2508
[Serializable]
public class ResourceLocalization
{
	// Token: 0x06004507 RID: 17671 RVA: 0x001BEDF0 File Offset: 0x001BD1F0
	public ResourceLocalization()
	{
	}

	// Token: 0x04003409 RID: 13321
	public ResourceType ItemType;

	// Token: 0x0400340A RID: 13322
	public string Title;

	// Token: 0x0400340B RID: 13323
	[TextArea]
	public string Description;
}
