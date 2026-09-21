using System;
using UnityEngine;

// Token: 0x020009D4 RID: 2516
[Serializable]
public class DialogDetails
{
	// Token: 0x0600450F RID: 17679 RVA: 0x001BEE30 File Offset: 0x001BD230
	public DialogDetails()
	{
	}

	// Token: 0x04003421 RID: 13345
	public DialogIdentifier Identifier;

	// Token: 0x04003422 RID: 13346
	public bool IsCriticalDialog;

	// Token: 0x04003423 RID: 13347
	[TextArea]
	public string Dialog;
}
