using System;
using UnityEngine;

// Token: 0x020009F4 RID: 2548
[Serializable]
public class TownEffectLocalization
{
	// Token: 0x0600452F RID: 17711 RVA: 0x001BEF30 File Offset: 0x001BD330
	public TownEffectLocalization()
	{
	}

	// Token: 0x04003481 RID: 13441
	public TownEffectType Type;

	// Token: 0x04003482 RID: 13442
	public string Name;

	// Token: 0x04003483 RID: 13443
	[TextArea]
	public string Description;
}
