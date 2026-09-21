using System;
using UnityEngine;

// Token: 0x020009E7 RID: 2535
[Serializable]
public class SocketTypeLocalization
{
	// Token: 0x06004522 RID: 17698 RVA: 0x001BEEC8 File Offset: 0x001BD2C8
	public SocketTypeLocalization()
	{
	}

	// Token: 0x0400345A RID: 13402
	public SocketType SocketType;

	// Token: 0x0400345B RID: 13403
	public string Name;

	// Token: 0x0400345C RID: 13404
	[TextArea]
	public string Description;
}
