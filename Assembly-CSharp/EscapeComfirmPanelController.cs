using System;
using UnityEngine;

// Token: 0x02000157 RID: 343
public class EscapeComfirmPanelController : MonoBehaviour
{
	// Token: 0x06000947 RID: 2375 RVA: 0x0007A59B File Offset: 0x0007899B
	public EscapeComfirmPanelController()
	{
	}

	// Token: 0x06000948 RID: 2376 RVA: 0x0007A5A3 File Offset: 0x000789A3
	public void ComfirmToEscape()
	{
		base.GetComponentInParent<AdventureUIController>().Escape();
	}

	// Token: 0x06000949 RID: 2377 RVA: 0x0007A5B0 File Offset: 0x000789B0
	public void ClosePanel()
	{
		base.gameObject.SetActive(false);
	}
}
