using System;
using UnityEngine;

// Token: 0x020009E8 RID: 2536
[Serializable]
public class ResidentEffectLocalization
{
	// Token: 0x06004523 RID: 17699 RVA: 0x001BEED0 File Offset: 0x001BD2D0
	public ResidentEffectLocalization()
	{
	}

	// Token: 0x0400345D RID: 13405
	public ResidentEffectType EffectType;

	// Token: 0x0400345E RID: 13406
	public string Name;

	// Token: 0x0400345F RID: 13407
	[TextArea]
	public string Description;
}
