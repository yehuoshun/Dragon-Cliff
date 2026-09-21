using System;
using UnityEngine;

// Token: 0x020009EB RID: 2539
[Serializable]
public class VehicleLocalization
{
	// Token: 0x06004526 RID: 17702 RVA: 0x001BEEE8 File Offset: 0x001BD2E8
	public VehicleLocalization()
	{
	}

	// Token: 0x04003466 RID: 13414
	public VehicleType Type;

	// Token: 0x04003467 RID: 13415
	public string Name;

	// Token: 0x04003468 RID: 13416
	[TextArea]
	public string Description;
}
