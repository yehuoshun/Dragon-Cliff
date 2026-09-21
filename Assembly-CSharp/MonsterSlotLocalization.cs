using System;
using UnityEngine;

// Token: 0x020009E5 RID: 2533
[Serializable]
public class MonsterSlotLocalization
{
	// Token: 0x06004520 RID: 17696 RVA: 0x001BEEB8 File Offset: 0x001BD2B8
	public MonsterSlotLocalization()
	{
	}

	// Token: 0x04003454 RID: 13396
	public AdventureEncounterSlotType SlotType;

	// Token: 0x04003455 RID: 13397
	public string Name;

	// Token: 0x04003456 RID: 13398
	[TextArea]
	public string Description;
}
