using System;
using UnityEngine;

// Token: 0x020009DD RID: 2525
[Serializable]
public class RewardTypeLocalization
{
	// Token: 0x06004518 RID: 17688 RVA: 0x001BEE78 File Offset: 0x001BD278
	public RewardTypeLocalization()
	{
	}

	// Token: 0x0400343C RID: 13372
	public RewardType RewardType;

	// Token: 0x0400343D RID: 13373
	public string Name;

	// Token: 0x0400343E RID: 13374
	[TextArea]
	public string Description;
}
