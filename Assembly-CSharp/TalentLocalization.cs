using System;
using UnityEngine;

// Token: 0x020009F2 RID: 2546
[Serializable]
public class TalentLocalization
{
	// Token: 0x0600452D RID: 17709 RVA: 0x001BEF20 File Offset: 0x001BD320
	public TalentLocalization()
	{
	}

	// Token: 0x0400347B RID: 13435
	public AdventurerTalentType Type;

	// Token: 0x0400347C RID: 13436
	public string Name;

	// Token: 0x0400347D RID: 13437
	[TextArea]
	public string Description;
}
