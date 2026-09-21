using System;
using UnityEngine;

// Token: 0x020009F0 RID: 2544
[Serializable]
public class DestinationLocalization
{
	// Token: 0x0600452B RID: 17707 RVA: 0x001BEF10 File Offset: 0x001BD310
	public DestinationLocalization()
	{
	}

	// Token: 0x04003475 RID: 13429
	public DestinationType Type;

	// Token: 0x04003476 RID: 13430
	public string Name;

	// Token: 0x04003477 RID: 13431
	[TextArea]
	public string Description;
}
