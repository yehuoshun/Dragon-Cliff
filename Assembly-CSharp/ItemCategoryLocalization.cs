using System;
using UnityEngine;

// Token: 0x020009CD RID: 2509
[Serializable]
public class ItemCategoryLocalization
{
	// Token: 0x06004508 RID: 17672 RVA: 0x001BEDF8 File Offset: 0x001BD1F8
	public ItemCategoryLocalization()
	{
	}

	// Token: 0x0400340C RID: 13324
	public ResourceCategory ResourceCategory;

	// Token: 0x0400340D RID: 13325
	public string Title;

	// Token: 0x0400340E RID: 13326
	[TextArea]
	public string Description;
}
