using System;
using UnityEngine;

// Token: 0x020009F5 RID: 2549
[Serializable]
public class CandidateOrderMetricLocalization
{
	// Token: 0x06004530 RID: 17712 RVA: 0x001BEF38 File Offset: 0x001BD338
	public CandidateOrderMetricLocalization()
	{
	}

	// Token: 0x04003484 RID: 13444
	public CandidateOrderringMetric Type;

	// Token: 0x04003485 RID: 13445
	public string Name;

	// Token: 0x04003486 RID: 13446
	[TextArea]
	public string Description;
}
