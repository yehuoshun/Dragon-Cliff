using System;
using UnityEngine;

// Token: 0x020009EF RID: 2543
[Serializable]
public class TripOutcomeLocalization
{
	// Token: 0x0600452A RID: 17706 RVA: 0x001BEF08 File Offset: 0x001BD308
	public TripOutcomeLocalization()
	{
	}

	// Token: 0x04003472 RID: 13426
	public TripEncounterOutcomeType Type;

	// Token: 0x04003473 RID: 13427
	public string Name;

	// Token: 0x04003474 RID: 13428
	[TextArea]
	public string Description;
}
