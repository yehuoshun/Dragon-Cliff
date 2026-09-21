using System;
using UnityEngine;

// Token: 0x02000194 RID: 404
public class FurnanceItemOperationPanelController : MonoBehaviour
{
	// Token: 0x06000ABE RID: 2750 RVA: 0x00082C07 File Offset: 0x00081007
	public FurnanceItemOperationPanelController()
	{
	}

	// Token: 0x06000ABF RID: 2751 RVA: 0x00082C10 File Offset: 0x00081010
	public void Init(NormalItem selectedItem)
	{
		if (selectedItem == null)
		{
			return;
		}
		bool locked = selectedItem.Item.Locked;
		this.LockButton.SetActive(!locked);
		this.UnlockButton.SetActive(locked);
		SelectedFurnaceTab selectedTab = base.GetComponentInParent<FurnaceMenuController>().GetSelectedTab();
		this.CombineButton.SetActive(selectedTab == SelectedFurnaceTab.Combine && !locked);
		this.EnchantButton.SetActive(selectedTab == SelectedFurnaceTab.Enchant);
		this.BreakButton.SetActive(selectedTab == SelectedFurnaceTab.Break && !locked);
		this.TransferButton.SetActive(selectedTab == SelectedFurnaceTab.Transfer && !locked);
		this.ReforgeButton.SetActive(selectedTab == SelectedFurnaceTab.Reforge);
	}

	// Token: 0x04000D56 RID: 3414
	public GameObject CombineButton;

	// Token: 0x04000D57 RID: 3415
	public GameObject EnchantButton;

	// Token: 0x04000D58 RID: 3416
	public GameObject BreakButton;

	// Token: 0x04000D59 RID: 3417
	public GameObject ReforgeButton;

	// Token: 0x04000D5A RID: 3418
	public GameObject TransferButton;

	// Token: 0x04000D5B RID: 3419
	public GameObject LockButton;

	// Token: 0x04000D5C RID: 3420
	public GameObject UnlockButton;
}
