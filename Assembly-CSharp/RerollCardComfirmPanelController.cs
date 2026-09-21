using System;
using TMPro;
using UnityEngine;

// Token: 0x020001D3 RID: 467
public class RerollCardComfirmPanelController : MonoBehaviour
{
	// Token: 0x06000CA0 RID: 3232 RVA: 0x0008AC9A File Offset: 0x0008909A
	public RerollCardComfirmPanelController()
	{
	}

	// Token: 0x06000CA1 RID: 3233 RVA: 0x0008ACA2 File Offset: 0x000890A2
	public void Init(string description)
	{
		this.Description.text = description;
	}

	// Token: 0x06000CA2 RID: 3234 RVA: 0x0008ACB0 File Offset: 0x000890B0
	public void ClosePanel()
	{
	}

	// Token: 0x04000EC4 RID: 3780
	public TextMeshProUGUI Description;
}
