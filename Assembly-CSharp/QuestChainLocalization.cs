using System;
using UnityEngine;

// Token: 0x020009DE RID: 2526
[Serializable]
public class QuestChainLocalization
{
	// Token: 0x06004519 RID: 17689 RVA: 0x001BEE80 File Offset: 0x001BD280
	public QuestChainLocalization()
	{
	}

	// Token: 0x0400343F RID: 13375
	public QuestChainIdentifier QuestChainIdentifier;

	// Token: 0x04003440 RID: 13376
	public string Name;

	// Token: 0x04003441 RID: 13377
	[TextArea]
	public string Description;
}
