using System;
using UnityEngine;

// Token: 0x020009E3 RID: 2531
[Serializable]
public class TargetCandidateTypeLocalization
{
	// Token: 0x0600451E RID: 17694 RVA: 0x001BEEA8 File Offset: 0x001BD2A8
	public TargetCandidateTypeLocalization()
	{
	}

	// Token: 0x0400344E RID: 13390
	public TargetCandidateType TargetCandidateType;

	// Token: 0x0400344F RID: 13391
	public string Name;

	// Token: 0x04003450 RID: 13392
	[TextArea]
	public string Description;
}
