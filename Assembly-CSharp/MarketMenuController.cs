using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200027E RID: 638
public class MarketMenuController : MonoBehaviour
{
	// Token: 0x060010DC RID: 4316 RVA: 0x00098B08 File Offset: 0x00096F08
	public MarketMenuController()
	{
	}

	// Token: 0x060010DD RID: 4317 RVA: 0x00098B10 File Offset: 0x00096F10
	public void Init(List<NormalItem> items)
	{
		foreach (NormalItem item in items)
		{
			this.AddItem(item);
		}
	}

	// Token: 0x060010DE RID: 4318 RVA: 0x00098B68 File Offset: 0x00096F68
	public void AddItem(NormalItem item)
	{
		this.ItemPage.AddNewItem(item);
	}

	// Token: 0x060010DF RID: 4319 RVA: 0x00098B76 File Offset: 0x00096F76
	public void ItemSelected(Item item, Vector3 position)
	{
		this._selectedItem = item;
		this.ShowSelectKeys(position);
	}

	// Token: 0x060010E0 RID: 4320 RVA: 0x00098B86 File Offset: 0x00096F86
	public void ShowSelectKeys(Vector3 position)
	{
		this.ItemSelectKeys.transform.position = position;
		this.ItemSelectKeys.SetActive(true);
	}

	// Token: 0x060010E1 RID: 4321 RVA: 0x00098BA5 File Offset: 0x00096FA5
	public void ReserveAll()
	{
		this.ItemPage.PageElements.Cast<NormalItem>().ToList<NormalItem>().ForEach(delegate(NormalItem i)
		{
			GameWorld.instance.PlayerProfile.ItemReserve(i.Item);
		});
	}

	// Token: 0x060010E2 RID: 4322 RVA: 0x00098BDE File Offset: 0x00096FDE
	public void OnPointerUp(PointerEventData eventData)
	{
		this.HideSelectKeys();
		this._selectedItem = null;
	}

	// Token: 0x060010E3 RID: 4323 RVA: 0x00098BED File Offset: 0x00096FED
	public void HideSelectKeys()
	{
		this.ItemSelectKeys.SetActive(false);
	}

	// Token: 0x060010E4 RID: 4324 RVA: 0x00098BFB File Offset: 0x00096FFB
	public void ItemTakeOfSale()
	{
		if (this._selectedItem == null)
		{
			throw new Exception("Item not selected yet.");
		}
		GameWorld.instance.PlayerProfile.ItemReserve(this._selectedItem);
		this.HideSelectKeys();
	}

	// Token: 0x060010E5 RID: 4325 RVA: 0x00098C2E File Offset: 0x0009702E
	[CompilerGenerated]
	private static void <ReserveAll>m__0(NormalItem i)
	{
		GameWorld.instance.PlayerProfile.ItemReserve(i.Item);
	}

	// Token: 0x040011E7 RID: 4583
	private Item _selectedItem;

	// Token: 0x040011E8 RID: 4584
	public ItemPaginationController ItemPage;

	// Token: 0x040011E9 RID: 4585
	public GameObject ItemSelectKeys;

	// Token: 0x040011EA RID: 4586
	[CompilerGenerated]
	private static Action<NormalItem> <>f__am$cache0;
}
