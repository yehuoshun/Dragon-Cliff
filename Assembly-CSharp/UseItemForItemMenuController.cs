using System;
using System.Collections.Generic;
using UnityEngine.UI;

// Token: 0x020001F5 RID: 501
public class UseItemForItemMenuController : InventoryMenuManager
{
	// Token: 0x06000D41 RID: 3393 RVA: 0x0008DB30 File Offset: 0x0008BF30
	public UseItemForItemMenuController()
	{
	}

	// Token: 0x06000D42 RID: 3394 RVA: 0x0008DB38 File Offset: 0x0008BF38
	public void Init(List<NormalItem> reservedItems, Item selectedItem)
	{
		this._selectedGem = selectedItem;
		this.StoragePages.UpdateItems(reservedItems);
		base.OnWeapon();
		this.UseButton.interactable = (base.SelectedItem != null);
	}

	// Token: 0x06000D43 RID: 3395 RVA: 0x0008DB6A File Offset: 0x0008BF6A
	public void SelectItem(NormalItem item)
	{
		base.SelectedItem = item;
		this.UseButton.interactable = (base.SelectedItem != null);
		this.StoragePages.SelectItem(item);
	}

	// Token: 0x06000D44 RID: 3396 RVA: 0x0008DB96 File Offset: 0x0008BF96
	public void UseItem()
	{
		base.SelectedItem.Item.Socket(this._selectedGem);
	}

	// Token: 0x06000D45 RID: 3397 RVA: 0x0008DBAE File Offset: 0x0008BFAE
	public void ClosePanel()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x04000F4B RID: 3915
	public Button UseButton;

	// Token: 0x04000F4C RID: 3916
	private Item _selectedGem;
}
