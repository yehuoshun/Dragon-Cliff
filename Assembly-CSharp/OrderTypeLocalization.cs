using System;
using UnityEngine;

// Token: 0x020009F6 RID: 2550
[Serializable]
public class OrderTypeLocalization
{
	// Token: 0x06004531 RID: 17713 RVA: 0x001BEF40 File Offset: 0x001BD340
	public OrderTypeLocalization()
	{
	}

	// Token: 0x04003487 RID: 13447
	public OrderingType Type;

	// Token: 0x04003488 RID: 13448
	public string Name;

	// Token: 0x04003489 RID: 13449
	[TextArea]
	public string Description;
}
