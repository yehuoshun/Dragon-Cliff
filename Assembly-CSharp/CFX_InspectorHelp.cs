using System;
using UnityEngine;

// Token: 0x020000C5 RID: 197
public class CFX_InspectorHelp : MonoBehaviour
{
	// Token: 0x0600060C RID: 1548 RVA: 0x00061315 File Offset: 0x0005F715
	public CFX_InspectorHelp()
	{
	}

	// Token: 0x0600060D RID: 1549 RVA: 0x0006131D File Offset: 0x0005F71D
	[ContextMenu("Unlock editing")]
	private void Unlock()
	{
		this.Locked = false;
	}

	// Token: 0x0400090C RID: 2316
	public bool Locked;

	// Token: 0x0400090D RID: 2317
	public string Title;

	// Token: 0x0400090E RID: 2318
	public string HelpText;

	// Token: 0x0400090F RID: 2319
	public int MsgType;
}
