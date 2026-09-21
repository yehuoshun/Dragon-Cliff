using System;
using UnityEngine;

// Token: 0x020009DA RID: 2522
[Serializable]
public class SpecialEffectLocalization
{
	// Token: 0x06004515 RID: 17685 RVA: 0x001BEE60 File Offset: 0x001BD260
	public SpecialEffectLocalization()
	{
	}

	// Token: 0x04003432 RID: 13362
	public SpecialEffectType SpecialEffectType;

	// Token: 0x04003433 RID: 13363
	public string Name;

	// Token: 0x04003434 RID: 13364
	[TextArea]
	public string Description;

	// Token: 0x04003435 RID: 13365
	[TextArea]
	public string GeneralInfo;
}
