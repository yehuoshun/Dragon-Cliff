using System;
using UnityEngine;

// Token: 0x020009CE RID: 2510
[Serializable]
public class UnitLocalization
{
	// Token: 0x06004509 RID: 17673 RVA: 0x001BEE00 File Offset: 0x001BD200
	public UnitLocalization()
	{
	}

	// Token: 0x0400340F RID: 13327
	public UnitClass UnitClass;

	// Token: 0x04003410 RID: 13328
	public string Title;

	// Token: 0x04003411 RID: 13329
	[TextArea]
	public string Description;
}
