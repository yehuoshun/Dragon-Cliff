using System;
using UnityEngine;

// Token: 0x020009D9 RID: 2521
[Serializable]
public class ResidentLocalization
{
	// Token: 0x06004514 RID: 17684 RVA: 0x001BEE58 File Offset: 0x001BD258
	public ResidentLocalization()
	{
	}

	// Token: 0x0400342F RID: 13359
	public ResidentType ResidentType;

	// Token: 0x04003430 RID: 13360
	public string Name;

	// Token: 0x04003431 RID: 13361
	[TextArea]
	public string Description;
}
