using System;
using UnityEngine;

// Token: 0x020009F3 RID: 2547
[Serializable]
public class TownEventLocalizaiton
{
	// Token: 0x0600452E RID: 17710 RVA: 0x001BEF28 File Offset: 0x001BD328
	public TownEventLocalizaiton()
	{
	}

	// Token: 0x0400347E RID: 13438
	public TownEventType Type;

	// Token: 0x0400347F RID: 13439
	public string Name;

	// Token: 0x04003480 RID: 13440
	[TextArea]
	public string Description;
}
