using System;
using UnityEngine;

// Token: 0x020009D0 RID: 2512
[Serializable]
public class AdventureLocalization
{
	// Token: 0x0600450B RID: 17675 RVA: 0x001BEE10 File Offset: 0x001BD210
	public AdventureLocalization()
	{
	}

	// Token: 0x04003415 RID: 13333
	public AdventureType AdventureType;

	// Token: 0x04003416 RID: 13334
	public string Title;

	// Token: 0x04003417 RID: 13335
	[TextArea]
	public string Description;
}
