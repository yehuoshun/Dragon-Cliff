using System;
using UnityEngine;

// Token: 0x020009F1 RID: 2545
[Serializable]
public class UnitStyleLocalization
{
	// Token: 0x0600452C RID: 17708 RVA: 0x001BEF18 File Offset: 0x001BD318
	public UnitStyleLocalization()
	{
	}

	// Token: 0x04003478 RID: 13432
	public UnitClassStyle Type;

	// Token: 0x04003479 RID: 13433
	public string Name;

	// Token: 0x0400347A RID: 13434
	[TextArea]
	public string Description;
}
