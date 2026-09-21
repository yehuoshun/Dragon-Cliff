using System;
using UnityEngine;

// Token: 0x020009DB RID: 2523
[Serializable]
public class GrowthSpecialEffectConditionLocalization
{
	// Token: 0x06004516 RID: 17686 RVA: 0x001BEE68 File Offset: 0x001BD268
	public GrowthSpecialEffectConditionLocalization()
	{
	}

	// Token: 0x04003436 RID: 13366
	public GrowthConditionType ConditionType;

	// Token: 0x04003437 RID: 13367
	public string Name;

	// Token: 0x04003438 RID: 13368
	[TextArea]
	public string Description;
}
