using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000275 RID: 629
public class InventorySubPageController : MonoBehaviour
{
	// Token: 0x0600107A RID: 4218 RVA: 0x000978CC File Offset: 0x00095CCC
	public InventorySubPageController()
	{
	}

	// Token: 0x0600107B RID: 4219 RVA: 0x000978D4 File Offset: 0x00095CD4
	public void AddItems(List<NormalItem> items)
	{
		foreach (NormalItem item in items)
		{
			this.AddItem(item);
		}
	}

	// Token: 0x0600107C RID: 4220 RVA: 0x0009792C File Offset: 0x00095D2C
	public void UpdatePage(InventoryTabButton button)
	{
		this.GetPage(button).DisplayCurrentPage();
	}

	// Token: 0x0600107D RID: 4221 RVA: 0x0009793C File Offset: 0x00095D3C
	private ItemPaginationController GetPage(InventoryTabButton button)
	{
		switch (button)
		{
		case InventoryTabButton.Item:
			return this.ItemPage;
		case InventoryTabButton.Weapon:
			return this.WeaponPage;
		case InventoryTabButton.Armor:
			return this.ArmorPage;
		case InventoryTabButton.Accessory:
			return this.AccessoryPage;
		case InventoryTabButton.Scroll:
			return this.ScrollPage;
		case InventoryTabButton.Amulet:
			return this.AmuletPage;
		case InventoryTabButton.Device:
			return this.DevicePage;
		case InventoryTabButton.JustDropped:
			return this.JustDroppedPage;
		default:
			return this.WeaponPage;
		}
	}

	// Token: 0x0600107E RID: 4222 RVA: 0x000979B4 File Offset: 0x00095DB4
	public void AddItem(NormalItem item)
	{
		ResourceCategory resourceCategory = item.Item.Type.GetResourceCategory();
		if (resourceCategory == ResourceCategory.Usable)
		{
			if (this.ItemPage.ContainsSameTypeItem(item.ResourceType))
			{
				item.Amount = GameWorld.instance.PlayerProfile.GetResourceQuantity(item.ResourceType);
				this.ItemPage.UpdateItemAmount(item);
			}
			else
			{
				this.ItemPage.AddNewItem(item);
			}
		}
		if (resourceCategory == ResourceCategory.Scrolls)
		{
			this.ScrollPage.AddNewItem(item);
		}
		if (resourceCategory == ResourceCategory.Amulet)
		{
			this.AmuletPage.AddNewItem(item);
		}
		if (resourceCategory == ResourceCategory.Device)
		{
			this.DevicePage.AddNewItem(item);
		}
		if (resourceCategory == ResourceCategory.Gem)
		{
			this.ItemPage.AddNewItem(item);
		}
		else if (item.Item.IsEquipment())
		{
			switch (item.Item.SlotType)
			{
			case ItemType.Weapon:
				this.WeaponPage.AddNewItem(item);
				break;
			case ItemType.Armor:
				this.ArmorPage.AddNewItem(item);
				break;
			case ItemType.Accessory:
				this.AccessoryPage.AddNewItem(item);
				break;
			}
		}
	}

	// Token: 0x0600107F RID: 4223 RVA: 0x00097AEE File Offset: 0x00095EEE
	public void SelectItem(NormalItem item)
	{
		this.WeaponPage.SelectElement(item.Id);
		this.ArmorPage.SelectElement(item.Id);
		this.AccessoryPage.SelectElement(item.Id);
	}

	// Token: 0x06001080 RID: 4224 RVA: 0x00097B24 File Offset: 0x00095F24
	public void UpdateItems(List<NormalItem> newItems)
	{
		List<PageElement> list = new List<PageElement>();
		List<PageElement> list2 = new List<PageElement>();
		List<PageElement> list3 = new List<PageElement>();
		List<PageElement> list4 = new List<PageElement>();
		List<PageElement> list5 = new List<PageElement>();
		List<PageElement> list6 = new List<PageElement>();
		List<PageElement> list7 = new List<PageElement>();
		using (List<NormalItem>.Enumerator enumerator = newItems.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				NormalItem item = enumerator.Current;
				ResourceCategory resourceCategory = item.Item.Type.GetResourceCategory();
				if (resourceCategory == ResourceCategory.Usable)
				{
					NormalItem normalItem = list.OfType<NormalItem>().FirstOrDefault((NormalItem i) => i.ResourceType == item.ResourceType);
					if (normalItem != null)
					{
						item.Amount = GameWorld.instance.PlayerProfile.GetResourceQuantity(item.ResourceType);
						normalItem.Amount += 1.0;
					}
					else
					{
						item.Amount = 1.0;
						list.Add(item);
					}
				}
				else if (resourceCategory == ResourceCategory.Scrolls)
				{
					list4.Add(item);
				}
				else if (resourceCategory == ResourceCategory.Amulet)
				{
					list5.Add(item);
				}
				else if (resourceCategory == ResourceCategory.Device)
				{
					list6.Add(item);
				}
				if (resourceCategory == ResourceCategory.Gem)
				{
					list.Add(item);
				}
				else if (item.Item.IsEquipment())
				{
					switch (item.Item.SlotType)
					{
					case ItemType.Weapon:
						list2.Add(item);
						break;
					case ItemType.Armor:
						list3.Add(item);
						break;
					case ItemType.Accessory:
						list7.Add(item);
						break;
					}
				}
			}
		}
		list = (from i in list.OfType<NormalItem>()
		orderby i.Item.Type.GetResourceCategory() == ResourceCategory.Usable descending
		select i).Cast<PageElement>().ToList<PageElement>();
		this.ItemPage.UpdateItems(list);
		this.WeaponPage.UpdateItems(list2);
		this.ArmorPage.UpdateItems(list3);
		this.ScrollPage.UpdateItems(list4);
		this.AmuletPage.UpdateItems(list5);
		this.DevicePage.UpdateItems(list6);
		this.AccessoryPage.UpdateItems(list7);
	}

	// Token: 0x06001081 RID: 4225 RVA: 0x00097DE0 File Offset: 0x000961E0
	public void ResetPagesToFirstPage()
	{
		this.ItemPage.JumpToPage(0);
		this.WeaponPage.JumpToPage(0);
		this.ArmorPage.JumpToPage(0);
		this.ScrollPage.JumpToPage(0);
		this.AmuletPage.JumpToPage(0);
		this.DevicePage.JumpToPage(0);
		this.AccessoryPage.JumpToPage(0);
		this.JustDroppedPage.JumpToPage(0);
	}

	// Token: 0x06001082 RID: 4226 RVA: 0x00097E50 File Offset: 0x00096250
	public void RemoveItem(Item item)
	{
		List<string> ids = new List<string>
		{
			item.Id
		};
		ResourceCategory resourceCategory = item.Type.GetResourceCategory();
		if (resourceCategory.IsWeapon())
		{
			this.WeaponPage.TryRemoveItem(ids);
		}
		else if (resourceCategory.IsArmor())
		{
			this.ArmorPage.TryRemoveItem(ids);
		}
		else if (resourceCategory == ResourceCategory.Scrolls)
		{
			this.ScrollPage.TryRemoveItem(ids);
		}
		else if (resourceCategory == ResourceCategory.Amulet)
		{
			this.AmuletPage.TryRemoveItem(ids);
		}
		else if (resourceCategory == ResourceCategory.Device)
		{
			this.DevicePage.TryRemoveItem(ids);
		}
		else if (resourceCategory == ResourceCategory.Accessory)
		{
			this.AccessoryPage.TryRemoveItem(ids);
		}
		else if (resourceCategory == ResourceCategory.Usable || resourceCategory == ResourceCategory.Gem)
		{
			this.ItemPage.TryRemoveItem(ids);
		}
		else
		{
			this.WeaponPage.TryRemoveItem(ids);
			this.ArmorPage.TryRemoveItem(ids);
			this.ScrollPage.TryRemoveItem(ids);
			this.AmuletPage.TryRemoveItem(ids);
			this.DevicePage.TryRemoveItem(ids);
			this.AccessoryPage.TryRemoveItem(ids);
			this.ItemPage.TryRemoveItem(ids);
		}
		this.RemoveItemFromeJustDroppedPage(item.ConvertToUiNormalItem());
	}

	// Token: 0x06001083 RID: 4227 RVA: 0x00097F9C File Offset: 0x0009639C
	public List<NormalItem> GetSelectedList(InventoryTabButton selectedTab)
	{
		switch (selectedTab)
		{
		case InventoryTabButton.Item:
			return this.ItemPage.PageElements.Cast<NormalItem>().ToList<NormalItem>();
		case InventoryTabButton.Weapon:
			return this.WeaponPage.PageElements.Cast<NormalItem>().ToList<NormalItem>();
		case InventoryTabButton.Armor:
			return this.ArmorPage.PageElements.Cast<NormalItem>().ToList<NormalItem>();
		case InventoryTabButton.Accessory:
			return this.AccessoryPage.PageElements.Cast<NormalItem>().ToList<NormalItem>();
		case InventoryTabButton.Scroll:
			return this.ScrollPage.PageElements.Cast<NormalItem>().ToList<NormalItem>();
		case InventoryTabButton.Amulet:
			return this.AmuletPage.PageElements.Cast<NormalItem>().ToList<NormalItem>();
		case InventoryTabButton.Device:
			return this.DevicePage.PageElements.Cast<NormalItem>().ToList<NormalItem>();
		case InventoryTabButton.JustDropped:
			return this.JustDroppedPage.PageElements.Cast<NormalItem>().ToList<NormalItem>();
		default:
			return new List<NormalItem>();
		}
	}

	// Token: 0x06001084 RID: 4228 RVA: 0x0009808C File Offset: 0x0009648C
	public virtual void DisplayPage(InventoryTabButton button)
	{
		this.ItemPage.transform.parent.gameObject.SetActive(button == InventoryTabButton.Item);
		this.WeaponPage.transform.parent.gameObject.SetActive(button == InventoryTabButton.Weapon);
		this.ArmorPage.transform.parent.gameObject.SetActive(button == InventoryTabButton.Armor);
		this.AccessoryPage.transform.parent.gameObject.SetActive(button == InventoryTabButton.Accessory);
		this.ScrollPage.transform.parent.gameObject.SetActive(button == InventoryTabButton.Scroll);
		this.AmuletPage.transform.parent.gameObject.SetActive(button == InventoryTabButton.Amulet);
		this.DevicePage.transform.parent.gameObject.SetActive(button == InventoryTabButton.Device);
		this.JustDroppedPage.transform.parent.gameObject.SetActive(button == InventoryTabButton.JustDropped);
	}

	// Token: 0x06001085 RID: 4229 RVA: 0x0009818C File Offset: 0x0009658C
	public void RefreshPage(InventoryTabButton button)
	{
		switch (button)
		{
		case InventoryTabButton.Item:
			this.ItemPage.DisplayCurrentPage();
			break;
		case InventoryTabButton.Weapon:
			this.WeaponPage.DisplayCurrentPage();
			break;
		case InventoryTabButton.Armor:
			this.ArmorPage.DisplayCurrentPage();
			break;
		case InventoryTabButton.Accessory:
			this.AccessoryPage.DisplayCurrentPage();
			break;
		case InventoryTabButton.Scroll:
			this.ScrollPage.DisplayCurrentPage();
			break;
		case InventoryTabButton.Amulet:
			this.AmuletPage.DisplayCurrentPage();
			break;
		case InventoryTabButton.Device:
			this.DevicePage.DisplayCurrentPage();
			break;
		case InventoryTabButton.JustDropped:
			this.JustDroppedPage.DisplayCurrentPage();
			break;
		}
	}

	// Token: 0x06001086 RID: 4230 RVA: 0x00098246 File Offset: 0x00096646
	public void AddItemsToJustDroppedPage(List<NormalItem> items)
	{
		this.JustDroppedPage.AddNewItems(items.Cast<PageElement>().ToList<PageElement>());
	}

	// Token: 0x06001087 RID: 4231 RVA: 0x0009825E File Offset: 0x0009665E
	public void AddItemToJustDroppedPage(NormalItem item)
	{
		if (item == null)
		{
			return;
		}
		this.JustDroppedPage.AddNewItem(item);
	}

	// Token: 0x06001088 RID: 4232 RVA: 0x00098274 File Offset: 0x00096674
	public void RemoveItemFromeJustDroppedPage(NormalItem item)
	{
		if (item == null)
		{
			return;
		}
		this.JustDroppedPage.TryRemoveItem(new List<string>
		{
			item.Id
		});
	}

	// Token: 0x06001089 RID: 4233 RVA: 0x000982A6 File Offset: 0x000966A6
	public void UpdateItemsInJustDroppedPage(List<NormalItem> items)
	{
		this.JustDroppedPage.UpdateItems(items.Cast<PageElement>().ToList<PageElement>());
	}

	// Token: 0x0600108A RID: 4234 RVA: 0x000982BE File Offset: 0x000966BE
	public void ClearJustDroppedPage()
	{
		this.JustDroppedPage.ResetPage();
	}

	// Token: 0x0600108B RID: 4235 RVA: 0x000982CB File Offset: 0x000966CB
	[CompilerGenerated]
	private static bool <UpdateItems>m__0(NormalItem i)
	{
		return i.Item.Type.GetResourceCategory() == ResourceCategory.Usable;
	}

	// Token: 0x040011B0 RID: 4528
	public ItemPaginationController ItemPage;

	// Token: 0x040011B1 RID: 4529
	public ItemPaginationController WeaponPage;

	// Token: 0x040011B2 RID: 4530
	public ItemPaginationController ArmorPage;

	// Token: 0x040011B3 RID: 4531
	public ItemPaginationController AccessoryPage;

	// Token: 0x040011B4 RID: 4532
	public ItemPaginationController ScrollPage;

	// Token: 0x040011B5 RID: 4533
	public ItemPaginationController AmuletPage;

	// Token: 0x040011B6 RID: 4534
	public ItemPaginationController DevicePage;

	// Token: 0x040011B7 RID: 4535
	public ItemPaginationController JustDroppedPage;

	// Token: 0x040011B8 RID: 4536
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache0;

	// Token: 0x02000C5F RID: 3167
	[CompilerGenerated]
	private sealed class <UpdateItems>c__AnonStorey0
	{
		// Token: 0x060052C7 RID: 21191 RVA: 0x000982E1 File Offset: 0x000966E1
		public <UpdateItems>c__AnonStorey0()
		{
		}

		// Token: 0x060052C8 RID: 21192 RVA: 0x000982E9 File Offset: 0x000966E9
		internal bool <>m__0(NormalItem i)
		{
			return i.ResourceType == this.item.ResourceType;
		}

		// Token: 0x0400408B RID: 16523
		internal NormalItem item;
	}
}
