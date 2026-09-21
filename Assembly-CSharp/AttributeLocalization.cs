using System;
using UnityEngine;

// Token: 0x020009D8 RID: 2520
[Serializable]
public class AttributeLocalization
{
	// Token: 0x06004513 RID: 17683 RVA: 0x001BEE50 File Offset: 0x001BD250
	public AttributeLocalization()
	{
	}

	// Token: 0x0400342B RID: 13355
	public AttributeType AttributeType;

	// Token: 0x0400342C RID: 13356
	public string Name;

	// Token: 0x0400342D RID: 13357
	public string Short;

	// Token: 0x0400342E RID: 13358
	[TextArea]
	public string Description;
}
