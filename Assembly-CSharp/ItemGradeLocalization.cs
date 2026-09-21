using System;
using UnityEngine;

// Token: 0x020009DC RID: 2524
[Serializable]
public class ItemGradeLocalization
{
	// Token: 0x06004517 RID: 17687 RVA: 0x001BEE70 File Offset: 0x001BD270
	public ItemGradeLocalization()
	{
	}

	// Token: 0x04003439 RID: 13369
	public QualityGrade Grade;

	// Token: 0x0400343A RID: 13370
	public string Name;

	// Token: 0x0400343B RID: 13371
	[TextArea]
	public string Description;
}
