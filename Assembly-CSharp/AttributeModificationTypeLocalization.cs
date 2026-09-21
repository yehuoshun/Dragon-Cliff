using System;
using UnityEngine;

// Token: 0x020009E6 RID: 2534
[Serializable]
public class AttributeModificationTypeLocalization
{
	// Token: 0x06004521 RID: 17697 RVA: 0x001BEEC0 File Offset: 0x001BD2C0
	public AttributeModificationTypeLocalization()
	{
	}

	// Token: 0x04003457 RID: 13399
	public ModificationType ModificationType;

	// Token: 0x04003458 RID: 13400
	public string Name;

	// Token: 0x04003459 RID: 13401
	[TextArea]
	public string Description;
}
