using System;
using UnityEngine;

// Token: 0x020009E0 RID: 2528
[Serializable]
public class BattleEventLocalization
{
	// Token: 0x0600451B RID: 17691 RVA: 0x001BEE90 File Offset: 0x001BD290
	public BattleEventLocalization()
	{
	}

	// Token: 0x04003445 RID: 13381
	public AdventureEventType EventType;

	// Token: 0x04003446 RID: 13382
	public string Name;

	// Token: 0x04003447 RID: 13383
	[TextArea]
	public string Description;
}
