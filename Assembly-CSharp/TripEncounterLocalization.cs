using System;
using UnityEngine;

// Token: 0x020009EE RID: 2542
[Serializable]
public class TripEncounterLocalization
{
	// Token: 0x06004529 RID: 17705 RVA: 0x001BEF00 File Offset: 0x001BD300
	public TripEncounterLocalization()
	{
	}

	// Token: 0x0400346F RID: 13423
	public TripEncounterType Type;

	// Token: 0x04003470 RID: 13424
	public string Name;

	// Token: 0x04003471 RID: 13425
	[TextArea]
	public string Description;
}
