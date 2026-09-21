using System;
using UnityEngine;

// Token: 0x020009EC RID: 2540
[Serializable]
public class JourneyContributionLocalization
{
	// Token: 0x06004527 RID: 17703 RVA: 0x001BEEF0 File Offset: 0x001BD2F0
	public JourneyContributionLocalization()
	{
	}

	// Token: 0x04003469 RID: 13417
	public JourneyContributeType Type;

	// Token: 0x0400346A RID: 13418
	public string Name;

	// Token: 0x0400346B RID: 13419
	[TextArea]
	public string Description;
}
