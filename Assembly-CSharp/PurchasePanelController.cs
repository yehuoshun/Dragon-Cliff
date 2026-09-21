using System;
using UnityEngine;

// Token: 0x02000281 RID: 641
public class PurchasePanelController : MonoBehaviour
{
	// Token: 0x0600110B RID: 4363 RVA: 0x00099A5B File Offset: 0x00097E5B
	public PurchasePanelController()
	{
	}

	// Token: 0x0600110C RID: 4364 RVA: 0x00099A64 File Offset: 0x00097E64
	public void Init(Commodity commodity)
	{
		if (commodity.ResourceType.GetResourceCategory() == ResourceCategory.Accessory || commodity.ResourceType == ResourceType.ResidentsPack)
		{
			this.PurchaseButton.SetActive(true);
			this.PackPurchaseButton.SetActive(false);
		}
		else
		{
			this.PurchaseButton.SetActive(false);
			this.PackPurchaseButton.SetActive(true);
		}
	}

	// Token: 0x0600110D RID: 4365 RVA: 0x00099AC8 File Offset: 0x00097EC8
	public void Purchase()
	{
		base.GetComponentInParent<MyShopMenuController>().Purchase();
		base.gameObject.SetActive(false);
	}

	// Token: 0x0600110E RID: 4366 RVA: 0x00099AE1 File Offset: 0x00097EE1
	public void Cancel()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x04001204 RID: 4612
	public GameObject PurchaseButton;

	// Token: 0x04001205 RID: 4613
	public GameObject PackPurchaseButton;
}
