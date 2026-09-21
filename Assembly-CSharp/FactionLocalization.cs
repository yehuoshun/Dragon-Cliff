using System;
using UnityEngine;

// Token: 0x020009D1 RID: 2513
[Serializable]
public class FactionLocalization
{
	// Token: 0x0600450C RID: 17676 RVA: 0x001BEE18 File Offset: 0x001BD218
	public FactionLocalization()
	{
	}

	// Token: 0x04003418 RID: 13336
	public GameFactionType FactionType;

	// Token: 0x04003419 RID: 13337
	public string Title;

	// Token: 0x0400341A RID: 13338
	[TextArea]
	public string Description;
}
