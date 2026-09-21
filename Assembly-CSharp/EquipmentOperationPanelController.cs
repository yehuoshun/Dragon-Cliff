using System;
using UnityEngine;

// Token: 0x020001B4 RID: 436
public class EquipmentOperationPanelController : MonoBehaviour
{
	// Token: 0x06000B70 RID: 2928 RVA: 0x0008629F File Offset: 0x0008469F
	public EquipmentOperationPanelController()
	{
	}

	// Token: 0x06000B71 RID: 2929 RVA: 0x000862A8 File Offset: 0x000846A8
	public void Init(Item item)
	{
		this.LockButton.SetActive(!item.Locked);
		this.UnlockButton.SetActive(item.Locked);
		this.ExtractButton.SetActive(item.HasGemToExtract());
		this.UpgradeButton.SetActive(item.Type.GetResourceCategory() == ResourceCategory.Amulet);
	}

	// Token: 0x04000DE0 RID: 3552
	public GameObject LockButton;

	// Token: 0x04000DE1 RID: 3553
	public GameObject UnlockButton;

	// Token: 0x04000DE2 RID: 3554
	public GameObject ExtractButton;

	// Token: 0x04000DE3 RID: 3555
	public GameObject UpgradeButton;
}
