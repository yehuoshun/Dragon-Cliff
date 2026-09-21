using System;
using UnityEngine;

// Token: 0x020009D3 RID: 2515
[Serializable]
public class QuestLocalization
{
	// Token: 0x0600450E RID: 17678 RVA: 0x001BEE28 File Offset: 0x001BD228
	public QuestLocalization()
	{
	}

	// Token: 0x0400341E RID: 13342
	public QuestIdentifier QuestIdentifier;

	// Token: 0x0400341F RID: 13343
	public string Title;

	// Token: 0x04003420 RID: 13344
	[TextArea]
	public string Description;
}
