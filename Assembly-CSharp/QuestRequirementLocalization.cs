using System;
using UnityEngine;

// Token: 0x020009D2 RID: 2514
[Serializable]
public class QuestRequirementLocalization
{
	// Token: 0x0600450D RID: 17677 RVA: 0x001BEE20 File Offset: 0x001BD220
	public QuestRequirementLocalization()
	{
	}

	// Token: 0x0400341B RID: 13339
	public QuestRequirementType QuestRequirementType;

	// Token: 0x0400341C RID: 13340
	public string Title;

	// Token: 0x0400341D RID: 13341
	[TextArea]
	public string Description;
}
