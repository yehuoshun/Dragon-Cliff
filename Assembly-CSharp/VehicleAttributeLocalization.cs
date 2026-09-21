using System;
using UnityEngine;

// Token: 0x020009ED RID: 2541
[Serializable]
public class VehicleAttributeLocalization
{
	// Token: 0x06004528 RID: 17704 RVA: 0x001BEEF8 File Offset: 0x001BD2F8
	public VehicleAttributeLocalization()
	{
	}

	// Token: 0x0400346C RID: 13420
	public VehicleAttributeType Type;

	// Token: 0x0400346D RID: 13421
	public string Name;

	// Token: 0x0400346E RID: 13422
	[TextArea]
	public string Description;
}
