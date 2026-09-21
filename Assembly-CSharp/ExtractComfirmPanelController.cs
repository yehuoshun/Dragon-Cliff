using System;
using TMPro;
using UnityEngine;

// Token: 0x020001B5 RID: 437
public class ExtractComfirmPanelController : MonoBehaviour
{
	// Token: 0x06000B72 RID: 2930 RVA: 0x00086305 File Offset: 0x00084705
	public ExtractComfirmPanelController()
	{
	}

	// Token: 0x06000B73 RID: 2931 RVA: 0x0008630D File Offset: 0x0008470D
	public void Init(string description)
	{
		this.Description.text = description;
	}

	// Token: 0x06000B74 RID: 2932 RVA: 0x0008631B File Offset: 0x0008471B
	public void Comfirm()
	{
		base.GetComponentInParent<HeroMenuController>().InventoryPanel.ExtractGem();
	}

	// Token: 0x06000B75 RID: 2933 RVA: 0x0008632D File Offset: 0x0008472D
	public void Close()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x04000DE4 RID: 3556
	public TextMeshProUGUI Description;
}
