using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001F0 RID: 496
public class InventoryGemPanelController : MonoBehaviour
{
	// Token: 0x06000D2A RID: 3370 RVA: 0x0008D531 File Offset: 0x0008B931
	public InventoryGemPanelController()
	{
	}

	// Token: 0x06000D2B RID: 3371 RVA: 0x0008D539 File Offset: 0x0008B939
	private void OnDisable()
	{
		this.GemPage.DiselectAllElement();
		this._selectedGem = null;
		this.EmbedButton.interactable = (this._selectedGem != null);
	}

	// Token: 0x06000D2C RID: 3372 RVA: 0x0008D564 File Offset: 0x0008B964
	public void Init(Item selectedEquipment)
	{
		this._selectedEquipment = selectedEquipment;
		List<Item> socketableGems = this._selectedEquipment.GetSocketableGems();
		this.GemPage.UpdateItems((from g in socketableGems
		select new GemItem
		{
			Id = g.Id,
			Gem = g,
			ResourceType = g.Type,
			Amount = GameWorld.instance.PlayerProfile.GetResourceQuantity(g.Type)
		}).Cast<PageElement>().ToList<PageElement>());
		this.EmbedButton.interactable = (this._selectedGem != null);
	}

	// Token: 0x06000D2D RID: 3373 RVA: 0x0008D5D3 File Offset: 0x0008B9D3
	public void Embed()
	{
		if (this._selectedGem != null && this._selectedEquipment != null)
		{
			this._selectedEquipment.Socket(this._selectedGem);
			base.GetComponentInParent<InventoryMenuController>().RefreshCurrentPage();
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000D2E RID: 3374 RVA: 0x0008D613 File Offset: 0x0008BA13
	public void SelectGem(GemItem gem)
	{
		this._selectedGem = gem.Gem;
		this.EmbedButton.interactable = (this._selectedGem != null);
		this.GemPage.SelectElement(gem.Id);
	}

	// Token: 0x06000D2F RID: 3375 RVA: 0x0008D649 File Offset: 0x0008BA49
	public void ClosePanel()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x06000D30 RID: 3376 RVA: 0x0008D658 File Offset: 0x0008BA58
	[CompilerGenerated]
	private static GemItem <Init>m__0(Item g)
	{
		return new GemItem
		{
			Id = g.Id,
			Gem = g,
			ResourceType = g.Type,
			Amount = GameWorld.instance.PlayerProfile.GetResourceQuantity(g.Type)
		};
	}

	// Token: 0x04000F39 RID: 3897
	public ItemPaginationController GemPage;

	// Token: 0x04000F3A RID: 3898
	public Button EmbedButton;

	// Token: 0x04000F3B RID: 3899
	private Item _selectedEquipment;

	// Token: 0x04000F3C RID: 3900
	private Item _selectedGem;

	// Token: 0x04000F3D RID: 3901
	[CompilerGenerated]
	private static Func<Item, GemItem> <>f__am$cache0;
}
