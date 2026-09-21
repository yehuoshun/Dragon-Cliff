using System;
using UnityEngine;

// Token: 0x020001B7 RID: 439
public class GemLogButtonController : MonoBehaviour
{
	// Token: 0x06000B78 RID: 2936 RVA: 0x00086684 File Offset: 0x00084A84
	public GemLogButtonController()
	{
	}

	// Token: 0x06000B79 RID: 2937 RVA: 0x0008668C File Offset: 0x00084A8C
	public void OpenGemLogPanel()
	{
		this.GemLogPanel.SetActive(true);
	}

	// Token: 0x04000DEA RID: 3562
	public GameObject GemLogPanel;
}
