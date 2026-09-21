using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000191 RID: 401
public class FurnaceMenuController : InventoryMenuManager, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000A67 RID: 2663 RVA: 0x00081836 File Offset: 0x0007FC36
	public FurnaceMenuController()
	{
	}

	// Token: 0x06000A68 RID: 2664 RVA: 0x0008183E File Offset: 0x0007FC3E
	public void Init(ForgingFacility furnace)
	{
		this._furnace = furnace;
		this.LevelPanel.UpdateLevel(this._furnace.GetLevel());
	}

	// Token: 0x06000A69 RID: 2665 RVA: 0x0008185D File Offset: 0x0007FC5D
	private new void Start()
	{
		this.OnCombine();
		if (this.OrderTypeDropDown == null)
		{
			return;
		}
		this.OrderTypeDropDown.Dropdown.onValueChanged.AddListener(delegate(int A_1)
		{
			GameWorld.instance.PlayerProfile.ChangeItemOrderType(this.OrderTypeDropDown.DropdownValues.Single((OrderTypeDropdownValue d) => d.Value == this.OrderTypeDropDown.Dropdown.value).Type);
			this.OrderTypeDropDown.Init();
			this.UpdateStoragePages();
		});
	}

	// Token: 0x06000A6A RID: 2666 RVA: 0x00081898 File Offset: 0x0007FC98
	private void OnEnable()
	{
		base.OnWeapon();
		this.OnInventory();
		this.UpdateStoragePages();
	}

	// Token: 0x06000A6B RID: 2667 RVA: 0x000818AC File Offset: 0x0007FCAC
	private void OnDisable()
	{
		this.ResetSelectItemState();
	}

	// Token: 0x06000A6C RID: 2668 RVA: 0x000818B4 File Offset: 0x0007FCB4
	public override void TabPressed(InventoryTabButton button)
	{
		base.TabPressed(button);
		this.FilterSocketObj.SetActive(base.SelectedTab == InventoryTabButton.Item && (this._selectedFurnaceTab == SelectedFurnaceTab.Combine || this._selectedFurnaceTab == SelectedFurnaceTab.Break));
		this.FilterPanel.SwitchOnSocket(SocketType.All);
		this.UpdateStoragePages();
	}

	// Token: 0x06000A6D RID: 2669 RVA: 0x0008190C File Offset: 0x0007FD0C
	public void OnInventory()
	{
		this.InventoryPanel.SetActive(true);
		this.HeroPanel.gameObject.SetActive(false);
		this.InventoryTab.interactable = false;
		this.HeroTab.interactable = true;
		this._onInventory = true;
		if (this._selectedFurnaceTab != SelectedFurnaceTab.Transfer)
		{
			this.SelecteFurnaceTab(SelectedFurnaceTab.Combine);
		}
		this.ItemOperationPanel.gameObject.SetActive(false);
		this.BreakCover.SetActive(false);
		this.CombineCover.SetActive(false);
	}

	// Token: 0x06000A6E RID: 2670 RVA: 0x00081994 File Offset: 0x0007FD94
	public void OnHero()
	{
		this.InventoryPanel.SetActive(false);
		this.HeroPanel.gameObject.SetActive(true);
		this.InventoryTab.interactable = true;
		this.HeroTab.interactable = false;
		this._onInventory = false;
		if (this._selectedFurnaceTab == SelectedFurnaceTab.Combine || this._selectedFurnaceTab == SelectedFurnaceTab.Break)
		{
			this.SelecteFurnaceTab(SelectedFurnaceTab.Enchant);
		}
		this.ItemOperationPanel.gameObject.SetActive(false);
		this.BreakCover.SetActive(true);
		this.CombineCover.SetActive(true);
	}

	// Token: 0x06000A6F RID: 2671 RVA: 0x00081A24 File Offset: 0x0007FE24
	public void PreBatchCombine()
	{
		this.BatchCombineConfirmPanel.SetActive(true);
	}

	// Token: 0x06000A70 RID: 2672 RVA: 0x00081A32 File Offset: 0x0007FE32
	public void CloseBatchCombineConfirmPanel()
	{
		this.BatchCombineConfirmPanel.SetActive(false);
	}

	// Token: 0x06000A71 RID: 2673 RVA: 0x00081A40 File Offset: 0x0007FE40
	public void BatchCombine()
	{
		List<Item> items = (from i in this.GetStorageSelectedList()
		where !i.Item.Locked
		select i.Item).ToList<Item>();
		List<ResourceUpdate> list = (base.SelectedTab != InventoryTabButton.Item) ? BuildingExtensions.BatchCombine_Equipment(items) : BuildingExtensions.BatchCombine_Gem(items);
		if (list.Count > 0)
		{
			this.UpdateStoragePages();
			this.DisplyMovingNotification(new FlyingText
			{
				DisplyingText = UIComponentType.SuccessfulText.GetName(),
				Textcolor = ColorPicker.PositiveGreen
			});
		}
		else
		{
			this.DisplyMovingNotification(new FlyingText
			{
				DisplyingText = UIComponentType.BatchCombineNothingHappened.GetName(),
				Textcolor = ColorPicker.White
			});
		}
		this.CloseBatchCombineConfirmPanel();
	}

	// Token: 0x06000A72 RID: 2674 RVA: 0x00081B28 File Offset: 0x0007FF28
	public SelectedFurnaceTab GetSelectedTab()
	{
		return this._selectedFurnaceTab;
	}

	// Token: 0x06000A73 RID: 2675 RVA: 0x00081B30 File Offset: 0x0007FF30
	public void OnCombine()
	{
		this.SelecteFurnaceTab(SelectedFurnaceTab.Combine);
	}

	// Token: 0x06000A74 RID: 2676 RVA: 0x00081B39 File Offset: 0x0007FF39
	public void OnEnchant()
	{
		this.SelecteFurnaceTab(SelectedFurnaceTab.Enchant);
	}

	// Token: 0x06000A75 RID: 2677 RVA: 0x00081B42 File Offset: 0x0007FF42
	public void OnBreak()
	{
		this.SelecteFurnaceTab(SelectedFurnaceTab.Break);
	}

	// Token: 0x06000A76 RID: 2678 RVA: 0x00081B4B File Offset: 0x0007FF4B
	public void OnReforge()
	{
		this.SelecteFurnaceTab(SelectedFurnaceTab.Reforge);
	}

	// Token: 0x06000A77 RID: 2679 RVA: 0x00081B54 File Offset: 0x0007FF54
	public void OnTransfer()
	{
		this.SelecteFurnaceTab(SelectedFurnaceTab.Transfer);
	}

	// Token: 0x06000A78 RID: 2680 RVA: 0x00081B60 File Offset: 0x0007FF60
	public void SelecteFurnaceTab(SelectedFurnaceTab selectedTab)
	{
		this._selectedFurnaceTab = selectedTab;
		this.CombineButton.interactable = (selectedTab != SelectedFurnaceTab.Combine);
		this.EnchantButton.interactable = (selectedTab != SelectedFurnaceTab.Enchant);
		this.BreakButton.interactable = (selectedTab != SelectedFurnaceTab.Break);
		this.ReforgeButton.interactable = (selectedTab != SelectedFurnaceTab.Reforge);
		this.TransferButton.interactable = (selectedTab != SelectedFurnaceTab.Transfer);
		this.FurnacePanel.SetActive(selectedTab == SelectedFurnaceTab.Combine);
		this.EnchantPanel.gameObject.SetActive(selectedTab == SelectedFurnaceTab.Enchant);
		this.BreakPanel.gameObject.SetActive(selectedTab == SelectedFurnaceTab.Break);
		this.ReforgePanel.gameObject.SetActive(selectedTab == SelectedFurnaceTab.Reforge);
		this.TransferPanel.gameObject.SetActive(selectedTab == SelectedFurnaceTab.Transfer);
		this.GemTab.SetActive(selectedTab == SelectedFurnaceTab.Break || selectedTab == SelectedFurnaceTab.Combine);
		this.ScrollTab.SetActive(selectedTab == SelectedFurnaceTab.Transfer);
		this.DeviceTab.SetActive(selectedTab == SelectedFurnaceTab.Reforge || selectedTab == SelectedFurnaceTab.Enchant);
		if (selectedTab != SelectedFurnaceTab.Break && base.SelectedTab == InventoryTabButton.Item)
		{
			base.OnWeapon();
		}
		if (selectedTab != SelectedFurnaceTab.Transfer && base.SelectedTab == InventoryTabButton.Scroll)
		{
			base.OnWeapon();
		}
		this.HeroPanel.SelectFarnaceTab(selectedTab);
		this.UpdateStoragePages();
		this.CloseTransferConfirmPanel();
		this.ResetSelectItemState();
		this.ItemOperationPanel.gameObject.SetActive(false);
		this.StoragePages.ResetPagesToFirstPage();
	}

	// Token: 0x06000A79 RID: 2681 RVA: 0x00081CDA File Offset: 0x000800DA
	public void SelectItem(NormalItem item, Vector3 position)
	{
		base.SelectedItem = item;
		this.ItemOperationPanel.Init(base.SelectedItem);
		this.ItemOperationPanel.transform.position = position;
		this.ItemOperationPanel.gameObject.SetActive(true);
	}

	// Token: 0x06000A7A RID: 2682 RVA: 0x00081D16 File Offset: 0x00080116
	public void LockItem()
	{
		if (base.SelectedItem != null)
		{
			base.SelectedItem.Item.Locked = true;
			base.UpdateSelectedPage();
			this.HeroPanel.UpdateEquipments();
			this.ResetSelectItemState();
		}
	}

	// Token: 0x06000A7B RID: 2683 RVA: 0x00081D4B File Offset: 0x0008014B
	public void UnLockItem()
	{
		if (base.SelectedItem != null)
		{
			base.SelectedItem.Item.Locked = false;
			base.UpdateSelectedPage();
			this.HeroPanel.UpdateEquipments();
			this.ResetSelectItemState();
		}
	}

	// Token: 0x06000A7C RID: 2684 RVA: 0x00081D80 File Offset: 0x00080180
	public void SelectEquipmentForTransfer(Item item)
	{
		if (item != null)
		{
			this.TransferPanel.SelectedEquipment(item);
		}
	}

	// Token: 0x06000A7D RID: 2685 RVA: 0x00081D94 File Offset: 0x00080194
	public void SelectScrollForTransfer(Item item)
	{
		if (item != null)
		{
			this.TransferPanel.SelectedScroll(item);
		}
	}

	// Token: 0x06000A7E RID: 2686 RVA: 0x00081DA8 File Offset: 0x000801A8
	public void PreTransfer()
	{
		this.TransferConfirmPanel.SetActive(true);
	}

	// Token: 0x06000A7F RID: 2687 RVA: 0x00081DB8 File Offset: 0x000801B8
	public void Transfer()
	{
		bool flag = this.TransferPanel.Transfer();
		if (flag)
		{
			this.UpdateStoragePages();
		}
		this.CloseTransferConfirmPanel();
	}

	// Token: 0x06000A80 RID: 2688 RVA: 0x00081DE3 File Offset: 0x000801E3
	public void CloseTransferConfirmPanel()
	{
		this.TransferConfirmPanel.SetActive(false);
	}

	// Token: 0x06000A81 RID: 2689 RVA: 0x00081DF1 File Offset: 0x000801F1
	public void PreBreakAll()
	{
		if (this._onInventory)
		{
			this.BreakAllConfirmPanel.SetActive(true);
		}
	}

	// Token: 0x06000A82 RID: 2690 RVA: 0x00081E0C File Offset: 0x0008020C
	public void BreakAll()
	{
		List<NormalItem> storageSelectedList = this.GetStorageSelectedList();
		this.Disamble((from t in storageSelectedList
		select t.Item).ToList<Item>());
		this.BreakAllConfirmPanel.SetActive(false);
	}

	// Token: 0x06000A83 RID: 2691 RVA: 0x00081E5A File Offset: 0x0008025A
	public void Break2PropertiesGems()
	{
		this.BreakGemByNumOfProperties(2);
	}

	// Token: 0x06000A84 RID: 2692 RVA: 0x00081E63 File Offset: 0x00080263
	public void Break3PropertiesGems()
	{
		this.BreakGemByNumOfProperties(3);
	}

	// Token: 0x06000A85 RID: 2693 RVA: 0x00081E6C File Offset: 0x0008026C
	public void Break4PropertiesGems()
	{
		this.BreakGemByNumOfProperties(4);
	}

	// Token: 0x06000A86 RID: 2694 RVA: 0x00081E78 File Offset: 0x00080278
	private void BreakGemByNumOfProperties(int number)
	{
		List<Item> items = (from i in this.GetStorageSelectedList()
		where i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.PrimaryAttributeModifiers.Count == number
		select i.Item).ToList<Item>();
		this.Disamble(items);
		this.BreakPanel.CloseAllPanel();
	}

	// Token: 0x06000A87 RID: 2695 RVA: 0x00081EE4 File Offset: 0x000802E4
	public void BreakByLevel(int level)
	{
		List<NormalItem> storageSelectedList = this.GetStorageSelectedList();
		this.Disamble((from r in storageSelectedList
		where r.Item.Level <= level
		select r into i
		select i.Item).ToList<Item>());
	}

	// Token: 0x06000A88 RID: 2696 RVA: 0x00081F44 File Offset: 0x00080344
	public void Disamble(List<Item> items)
	{
		List<ResourceUpdate> results = items.DisambleItems();
		this.DisplayRestructedBreakResults(results);
		this.UpdateStoragePages();
	}

	// Token: 0x06000A89 RID: 2697 RVA: 0x00081F68 File Offset: 0x00080368
	private void DisplayRestructedBreakResults(List<ResourceUpdate> results)
	{
		List<ResourceUpdate> list = new List<ResourceUpdate>();
		using (List<ResourceUpdate>.Enumerator enumerator = results.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ResourceUpdate result = enumerator.Current;
				ResourceUpdate resourceUpdate = list.FirstOrDefault((ResourceUpdate r) => r.ResourceType == result.ResourceType);
				if (resourceUpdate != null)
				{
					resourceUpdate.ChangeAmount += result.ChangeAmount;
				}
				else
				{
					list.Add(result);
				}
			}
		}
		this.BreakPanel.ShowResult(list);
	}

	// Token: 0x06000A8A RID: 2698 RVA: 0x00082018 File Offset: 0x00080418
	public void CloseBreakAllConfirmPanel()
	{
		this.BreakAllConfirmPanel.SetActive(false);
	}

	// Token: 0x06000A8B RID: 2699 RVA: 0x00082026 File Offset: 0x00080426
	public List<NormalItem> GetStorageSelectedList()
	{
		return (from i in this.StoragePages.GetSelectedList(base.SelectedTab)
		where !i.Item.Locked
		select i).ToList<NormalItem>();
	}

	// Token: 0x06000A8C RID: 2700 RVA: 0x00082060 File Offset: 0x00080460
	public void AddItemToFurnace(Item item)
	{
		if (item == null)
		{
			return;
		}
		List<Item> listByFurnaceTab = this.GetListByFurnaceTab(new List<Item>
		{
			item
		});
		this.StoragePages.AddItems((from i in listByFurnaceTab
		select i.ConvertToUiNormalItem()).ToList<NormalItem>());
	}

	// Token: 0x06000A8D RID: 2701 RVA: 0x000820BC File Offset: 0x000804BC
	public void FilterItems()
	{
		this.UpdateStoragePages();
		this.StoragePages.ResetPagesToFirstPage();
	}

	// Token: 0x06000A8E RID: 2702 RVA: 0x000820D0 File Offset: 0x000804D0
	public void UpdateStoragePages()
	{
		List<Item> source = this.GetListByFurnaceTab(GameWorld.instance.PlayerProfile.Items);
		source = (from i in base.FilterItemsFromFilterPanel((from i in source
		select i.ConvertToUiNormalItem()).ToList<NormalItem>())
		select i.Item).ToList<Item>();
		List<NormalItem> newItems;
		if (this.FilterPanel.Filters.SortBySpecialEffect)
		{
			newItems = base.OrderItemsBySpecialEffect((from i in source
			select i.ConvertToUiNormalItem()).ToList<NormalItem>());
		}
		else
		{
			newItems = (from i in source
			select i.ConvertToUiNormalItem()).ToList<NormalItem>().OrderItems(this.OrderTypeDropDown.GetSlectedOrderType());
		}
		this.StoragePages.UpdateItems(newItems);
		base.RefreshCurrentPage();
	}

	// Token: 0x06000A8F RID: 2703 RVA: 0x000821E0 File Offset: 0x000805E0
	public List<Item> GetListByFurnaceTab(List<Item> items)
	{
		SelectedFurnaceTab selectedFurnaceTab = this._selectedFurnaceTab;
		switch (selectedFurnaceTab)
		{
		case SelectedFurnaceTab.Combine:
		{
			bool canMakeLed = this._furnace.Level >= 2;
			return (from i in items
			where (i.ItemStatus == ItemStatus.Reserved && (i.Type.GetResourceCategory().IsArmor() || i.Type.GetResourceCategory().IsWeapon()) && ((!canMakeLed) ? (i.ItemGrade != QualityGrade.Legendary && i.ItemGrade != QualityGrade.Ancient) : (i.ItemGrade != QualityGrade.Ancient))) || i.Type.GetResourceCategory() == ResourceCategory.Gem
			select i).ToList<Item>();
		}
		case SelectedFurnaceTab.Enchant:
			return (from i in items
			where (i.ItemStatus == ItemStatus.Reserved && i.ItemGrade == QualityGrade.Ancient && (i.Type.GetResourceCategory().IsArmor() || i.Type.GetResourceCategory().IsWeapon())) || i.Type.GetResourceCategory() == ResourceCategory.Device
			select i).ToList<Item>();
		case SelectedFurnaceTab.Break:
			return (from i in items
			where i.ItemStatus == ItemStatus.Reserved && (i.Type.GetResourceCategory().IsArmor() || i.Type.GetResourceCategory().IsWeapon() || i.Type.GetResourceCategory() == ResourceCategory.Gem)
			where (i.IsEquipment() && i.ItemGrade == QualityGrade.Ancient && i.Level >= 8) || (i.Type.GetResourceCategory() == ResourceCategory.Gem && i.Level >= 7)
			select i).ToList<Item>();
		case SelectedFurnaceTab.Transfer:
			return (from i in items
			where ((i.Type.GetResourceCategory().IsWeapon() || i.Type.GetResourceCategory().IsArmor()) && i.Level >= 8) || i.Type.GetResourceCategory() == ResourceCategory.Scrolls
			select i).ToList<Item>();
		case SelectedFurnaceTab.Reforge:
			return (from i in items
			where i.IsReforgeable_quick()
			select i).ToList<Item>();
		default:
			return items;
		}
	}

	// Token: 0x06000A90 RID: 2704 RVA: 0x0008230F File Offset: 0x0008070F
	public void SelectCombineItem()
	{
		if (base.SelectedItem != null)
		{
			this.AddItemToQuickFurnace(base.SelectedItem);
			this.ResetSelectItemState();
		}
	}

	// Token: 0x06000A91 RID: 2705 RVA: 0x00082330 File Offset: 0x00080730
	public void RightClickItem(NormalItem item)
	{
		if (this._selectedFurnaceTab == SelectedFurnaceTab.Combine)
		{
			this.AddItemToQuickFurnace(item);
		}
		else if (this._selectedFurnaceTab == SelectedFurnaceTab.Enchant)
		{
			base.SelectedItem = item;
			this.ReadyForEnchanting();
		}
		else if (this._selectedFurnaceTab == SelectedFurnaceTab.Reforge)
		{
			base.SelectedItem = item;
			this.ReadyForReforging();
		}
		else if (this._selectedFurnaceTab == SelectedFurnaceTab.Break)
		{
			this.Break(item.Item);
		}
		else
		{
			this.SelectTransferItem(item.Item);
		}
	}

	// Token: 0x06000A92 RID: 2706 RVA: 0x000823BC File Offset: 0x000807BC
	public void RightClickItemFromHero(NormalItem item)
	{
		if (this._selectedFurnaceTab == SelectedFurnaceTab.Combine)
		{
			this.DisplayWarningText(UIComponentType.CannotCombineThisItem.GetName());
		}
		else if (this._selectedFurnaceTab == SelectedFurnaceTab.Enchant)
		{
			base.SelectedItem = item;
			this.ReadyForEnchanting();
		}
		else if (this._selectedFurnaceTab == SelectedFurnaceTab.Reforge)
		{
			base.SelectedItem = item;
			this.ReadyForReforging();
		}
		else if (this._selectedFurnaceTab == SelectedFurnaceTab.Transfer)
		{
			this.SelectTransferItem(item.Item);
		}
	}

	// Token: 0x06000A93 RID: 2707 RVA: 0x0008243D File Offset: 0x0008083D
	private bool CanBeReforgeOrEnchant(NormalItem item)
	{
		return item.Item.ItemGrade == QualityGrade.Ancient;
	}

	// Token: 0x06000A94 RID: 2708 RVA: 0x0008244D File Offset: 0x0008084D
	private bool CanTransfer(Item item)
	{
		return item.Level >= 8;
	}

	// Token: 0x06000A95 RID: 2709 RVA: 0x0008245B File Offset: 0x0008085B
	public void AddItemToQuickFurnace(NormalItem item)
	{
		this.QuickCombinePanel.SelectItem(item.Item);
	}

	// Token: 0x06000A96 RID: 2710 RVA: 0x0008246E File Offset: 0x0008086E
	public void SelectTransferItemFromButton()
	{
		if (base.SelectedItem != null)
		{
			this.SelectTransferItem(base.SelectedItem.Item);
		}
		this.ItemOperationPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000A97 RID: 2711 RVA: 0x000824A0 File Offset: 0x000808A0
	private void SelectTransferItem(Item item)
	{
		if (this.CanTransfer(item))
		{
			if (this.TransferPanel.FirstItemSelected())
			{
				this.TransferPanel.SelectedScroll(item);
			}
			else if (item.Locked)
			{
				this.DisplayWarningText(UIComponentType.FurnaceItemLockedWarning.GetName());
			}
			else
			{
				this.TransferPanel.SelectedEquipment(item);
			}
		}
		else
		{
			this.DisplayWarningText(UIComponentType.OnlyLevelItemCanBeTransferred.GetName());
		}
	}

	// Token: 0x06000A98 RID: 2712 RVA: 0x0008251B File Offset: 0x0008091B
	public void BreakItem()
	{
		if (base.SelectedItem == null)
		{
			return;
		}
		this.Break(base.SelectedItem.Item);
		this.ResetSelectItemState();
	}

	// Token: 0x06000A99 RID: 2713 RVA: 0x00082540 File Offset: 0x00080940
	private void Break(Item item)
	{
		if (!item.Locked)
		{
			this.BreakPanel.Init(item);
		}
		else
		{
			this.DisplayWarningText(UIComponentType.FurnaceItemLockedWarning.GetName());
		}
	}

	// Token: 0x06000A9A RID: 2714 RVA: 0x00082570 File Offset: 0x00080970
	public void ReadyForReforging()
	{
		if (base.SelectedItem.Item.IsReforgeable_quick())
		{
			if (base.SelectedItem != null && this.ReforgePanel.gameObject.activeSelf)
			{
				this.ReforgePanel.PutInItem(base.SelectedItem.Item);
			}
		}
		else
		{
			this.DisplayWarningText(UIComponentType.FurnacePanelNotReforgable.GetName());
		}
		this.ItemOperationPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000A9B RID: 2715 RVA: 0x000825F0 File Offset: 0x000809F0
	public void ReadyForEnchanting()
	{
		if (base.SelectedItem != null && this.EnchantPanel.gameObject.activeSelf)
		{
			if (base.SelectedItem.Item.ItemGrade == QualityGrade.Ancient)
			{
				this.EnchantPanel.PutInItem(base.SelectedItem.Item);
			}
			else
			{
				this.DisplayWarningText(UIComponentType.OnlyAncientEquipmentCanBeEnchant.GetName());
			}
		}
		this.ItemOperationPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000A9C RID: 2716 RVA: 0x0008266F File Offset: 0x00080A6F
	public void Make()
	{
		this.QuickCombinePanel.QuickMake();
		this.UpdateStoragePages();
	}

	// Token: 0x06000A9D RID: 2717 RVA: 0x00082682 File Offset: 0x00080A82
	public void ShowFinishMakingPanel(bool isSucceed, Item item, int amount)
	{
		this.FinishMakingPanel.Init(isSucceed, item, amount);
		this.FinishMakingPanel.gameObject.SetActive(true);
	}

	// Token: 0x06000A9E RID: 2718 RVA: 0x000826A4 File Offset: 0x00080AA4
	public void ResetSelectItemState()
	{
		base.SelectedItem = null;
		this.BreakOperationPanel.SetActive(false);
		this.ItemOperationPanel.gameObject.SetActive(false);
		this.BreakAllConfirmPanel.SetActive(false);
		this.TransferConfirmPanel.SetActive(false);
		this.BreakPanel.CloseAllPanel();
	}

	// Token: 0x06000A9F RID: 2719 RVA: 0x000826F8 File Offset: 0x00080AF8
	public void OnPointerClick(PointerEventData eventData)
	{
		this.ResetSelectItemState();
	}

	// Token: 0x06000AA0 RID: 2720 RVA: 0x00082700 File Offset: 0x00080B00
	[CompilerGenerated]
	private void <Start>m__0(int A_1)
	{
		GameWorld.instance.PlayerProfile.ChangeItemOrderType(this.OrderTypeDropDown.DropdownValues.Single((OrderTypeDropdownValue d) => d.Value == this.OrderTypeDropDown.Dropdown.value).Type);
		this.OrderTypeDropDown.Init();
		this.UpdateStoragePages();
	}

	// Token: 0x06000AA1 RID: 2721 RVA: 0x0008274E File Offset: 0x00080B4E
	[CompilerGenerated]
	private static bool <BatchCombine>m__1(NormalItem i)
	{
		return !i.Item.Locked;
	}

	// Token: 0x06000AA2 RID: 2722 RVA: 0x0008275E File Offset: 0x00080B5E
	[CompilerGenerated]
	private static Item <BatchCombine>m__2(NormalItem i)
	{
		return i.Item;
	}

	// Token: 0x06000AA3 RID: 2723 RVA: 0x00082766 File Offset: 0x00080B66
	[CompilerGenerated]
	private static Item <BreakAll>m__3(NormalItem t)
	{
		return t.Item;
	}

	// Token: 0x06000AA4 RID: 2724 RVA: 0x0008276E File Offset: 0x00080B6E
	[CompilerGenerated]
	private static Item <BreakGemByNumOfProperties>m__4(NormalItem i)
	{
		return i.Item;
	}

	// Token: 0x06000AA5 RID: 2725 RVA: 0x00082776 File Offset: 0x00080B76
	[CompilerGenerated]
	private static Item <BreakByLevel>m__5(NormalItem i)
	{
		return i.Item;
	}

	// Token: 0x06000AA6 RID: 2726 RVA: 0x0008277E File Offset: 0x00080B7E
	[CompilerGenerated]
	private static bool <GetStorageSelectedList>m__6(NormalItem i)
	{
		return !i.Item.Locked;
	}

	// Token: 0x06000AA7 RID: 2727 RVA: 0x0008278E File Offset: 0x00080B8E
	[CompilerGenerated]
	private static NormalItem <AddItemToFurnace>m__7(Item i)
	{
		return i.ConvertToUiNormalItem();
	}

	// Token: 0x06000AA8 RID: 2728 RVA: 0x00082796 File Offset: 0x00080B96
	[CompilerGenerated]
	private static NormalItem <UpdateStoragePages>m__8(Item i)
	{
		return i.ConvertToUiNormalItem();
	}

	// Token: 0x06000AA9 RID: 2729 RVA: 0x0008279E File Offset: 0x00080B9E
	[CompilerGenerated]
	private static Item <UpdateStoragePages>m__9(NormalItem i)
	{
		return i.Item;
	}

	// Token: 0x06000AAA RID: 2730 RVA: 0x000827A6 File Offset: 0x00080BA6
	[CompilerGenerated]
	private static NormalItem <UpdateStoragePages>m__A(Item i)
	{
		return i.ConvertToUiNormalItem();
	}

	// Token: 0x06000AAB RID: 2731 RVA: 0x000827AE File Offset: 0x00080BAE
	[CompilerGenerated]
	private static NormalItem <UpdateStoragePages>m__B(Item i)
	{
		return i.ConvertToUiNormalItem();
	}

	// Token: 0x06000AAC RID: 2732 RVA: 0x000827B8 File Offset: 0x00080BB8
	[CompilerGenerated]
	private static bool <GetListByFurnaceTab>m__C(Item i)
	{
		return (i.ItemStatus == ItemStatus.Reserved && i.ItemGrade == QualityGrade.Ancient && (i.Type.GetResourceCategory().IsArmor() || i.Type.GetResourceCategory().IsWeapon())) || i.Type.GetResourceCategory() == ResourceCategory.Device;
	}

	// Token: 0x06000AAD RID: 2733 RVA: 0x0008281C File Offset: 0x00080C1C
	[CompilerGenerated]
	private static bool <GetListByFurnaceTab>m__D(Item i)
	{
		return i.ItemStatus == ItemStatus.Reserved && (i.Type.GetResourceCategory().IsArmor() || i.Type.GetResourceCategory().IsWeapon() || i.Type.GetResourceCategory() == ResourceCategory.Gem);
	}

	// Token: 0x06000AAE RID: 2734 RVA: 0x00082874 File Offset: 0x00080C74
	[CompilerGenerated]
	private static bool <GetListByFurnaceTab>m__E(Item i)
	{
		return (i.IsEquipment() && i.ItemGrade == QualityGrade.Ancient && i.Level >= 8) || (i.Type.GetResourceCategory() == ResourceCategory.Gem && i.Level >= 7);
	}

	// Token: 0x06000AAF RID: 2735 RVA: 0x000828C8 File Offset: 0x00080CC8
	[CompilerGenerated]
	private static bool <GetListByFurnaceTab>m__F(Item i)
	{
		return ((i.Type.GetResourceCategory().IsWeapon() || i.Type.GetResourceCategory().IsArmor()) && i.Level >= 8) || i.Type.GetResourceCategory() == ResourceCategory.Scrolls;
	}

	// Token: 0x06000AB0 RID: 2736 RVA: 0x0008291D File Offset: 0x00080D1D
	[CompilerGenerated]
	private static bool <GetListByFurnaceTab>m__10(Item i)
	{
		return i.IsReforgeable_quick();
	}

	// Token: 0x06000AB1 RID: 2737 RVA: 0x00082925 File Offset: 0x00080D25
	[CompilerGenerated]
	private bool <Start>m__11(OrderTypeDropdownValue d)
	{
		return d.Value == this.OrderTypeDropDown.Dropdown.value;
	}

	// Token: 0x04000D1F RID: 3359
	public FurnaceHeroPanelController HeroPanel;

	// Token: 0x04000D20 RID: 3360
	public GameObject InventoryPanel;

	// Token: 0x04000D21 RID: 3361
	public FinishMakingPanelController FinishMakingPanel;

	// Token: 0x04000D22 RID: 3362
	public GameObject BreakOperationPanel;

	// Token: 0x04000D23 RID: 3363
	public FurnanceItemOperationPanelController ItemOperationPanel;

	// Token: 0x04000D24 RID: 3364
	public BuildingLevelPanelController LevelPanel;

	// Token: 0x04000D25 RID: 3365
	public TextMeshProUGUI MoneyText;

	// Token: 0x04000D26 RID: 3366
	public GameObject FurnacePanel;

	// Token: 0x04000D27 RID: 3367
	public EnchantPanelController EnchantPanel;

	// Token: 0x04000D28 RID: 3368
	public ReforgePanelController ReforgePanel;

	// Token: 0x04000D29 RID: 3369
	public BreakPanelController BreakPanel;

	// Token: 0x04000D2A RID: 3370
	public EffectTransferPanelController TransferPanel;

	// Token: 0x04000D2B RID: 3371
	public QuickCombinePanelController QuickCombinePanel;

	// Token: 0x04000D2C RID: 3372
	public GameObject FilterSocketObj;

	// Token: 0x04000D2D RID: 3373
	public GameObject GemTab;

	// Token: 0x04000D2E RID: 3374
	public GameObject ScrollTab;

	// Token: 0x04000D2F RID: 3375
	public GameObject DeviceTab;

	// Token: 0x04000D30 RID: 3376
	public GameObject TransferConfirmPanel;

	// Token: 0x04000D31 RID: 3377
	public GameObject BreakAllConfirmPanel;

	// Token: 0x04000D32 RID: 3378
	public GameObject BatchCombineConfirmPanel;

	// Token: 0x04000D33 RID: 3379
	public Button CombineButton;

	// Token: 0x04000D34 RID: 3380
	public Button EnchantButton;

	// Token: 0x04000D35 RID: 3381
	public Button BreakButton;

	// Token: 0x04000D36 RID: 3382
	public Button ReforgeButton;

	// Token: 0x04000D37 RID: 3383
	public Button TransferButton;

	// Token: 0x04000D38 RID: 3384
	public Button InventoryTab;

	// Token: 0x04000D39 RID: 3385
	public Button HeroTab;

	// Token: 0x04000D3A RID: 3386
	public GameObject BreakCover;

	// Token: 0x04000D3B RID: 3387
	public GameObject CombineCover;

	// Token: 0x04000D3C RID: 3388
	private ForgingFacility _furnace;

	// Token: 0x04000D3D RID: 3389
	private SelectedFurnaceTab _selectedFurnaceTab;

	// Token: 0x04000D3E RID: 3390
	private bool _onInventory;

	// Token: 0x04000D3F RID: 3391
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache0;

	// Token: 0x04000D40 RID: 3392
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cache1;

	// Token: 0x04000D41 RID: 3393
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cache2;

	// Token: 0x04000D42 RID: 3394
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cache3;

	// Token: 0x04000D43 RID: 3395
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cache4;

	// Token: 0x04000D44 RID: 3396
	[CompilerGenerated]
	private static Func<NormalItem, bool> <>f__am$cache5;

	// Token: 0x04000D45 RID: 3397
	[CompilerGenerated]
	private static Func<Item, NormalItem> <>f__am$cache6;

	// Token: 0x04000D46 RID: 3398
	[CompilerGenerated]
	private static Func<Item, NormalItem> <>f__am$cache7;

	// Token: 0x04000D47 RID: 3399
	[CompilerGenerated]
	private static Func<NormalItem, Item> <>f__am$cache8;

	// Token: 0x04000D48 RID: 3400
	[CompilerGenerated]
	private static Func<Item, NormalItem> <>f__am$cache9;

	// Token: 0x04000D49 RID: 3401
	[CompilerGenerated]
	private static Func<Item, NormalItem> <>f__am$cacheA;

	// Token: 0x04000D4A RID: 3402
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cacheB;

	// Token: 0x04000D4B RID: 3403
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cacheC;

	// Token: 0x04000D4C RID: 3404
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cacheD;

	// Token: 0x04000D4D RID: 3405
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cacheE;

	// Token: 0x04000D4E RID: 3406
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cacheF;

	// Token: 0x02000C23 RID: 3107
	[CompilerGenerated]
	private sealed class <BreakGemByNumOfProperties>c__AnonStorey0
	{
		// Token: 0x06005213 RID: 21011 RVA: 0x0008293F File Offset: 0x00080D3F
		public <BreakGemByNumOfProperties>c__AnonStorey0()
		{
		}

		// Token: 0x06005214 RID: 21012 RVA: 0x00082947 File Offset: 0x00080D47
		internal bool <>m__0(NormalItem i)
		{
			return i.Item.Type.GetResourceCategory() == ResourceCategory.Gem && i.Item.PrimaryAttributeModifiers.Count == this.number;
		}

		// Token: 0x0400401A RID: 16410
		internal int number;
	}

	// Token: 0x02000C24 RID: 3108
	[CompilerGenerated]
	private sealed class <BreakByLevel>c__AnonStorey1
	{
		// Token: 0x06005215 RID: 21013 RVA: 0x0008297B File Offset: 0x00080D7B
		public <BreakByLevel>c__AnonStorey1()
		{
		}

		// Token: 0x06005216 RID: 21014 RVA: 0x00082983 File Offset: 0x00080D83
		internal bool <>m__0(NormalItem r)
		{
			return r.Item.Level <= this.level;
		}

		// Token: 0x0400401B RID: 16411
		internal int level;
	}

	// Token: 0x02000C25 RID: 3109
	[CompilerGenerated]
	private sealed class <DisplayRestructedBreakResults>c__AnonStorey2
	{
		// Token: 0x06005217 RID: 21015 RVA: 0x0008299B File Offset: 0x00080D9B
		public <DisplayRestructedBreakResults>c__AnonStorey2()
		{
		}

		// Token: 0x06005218 RID: 21016 RVA: 0x000829A3 File Offset: 0x00080DA3
		internal bool <>m__0(ResourceUpdate r)
		{
			return r.ResourceType == this.result.ResourceType;
		}

		// Token: 0x0400401C RID: 16412
		internal ResourceUpdate result;
	}

	// Token: 0x02000C26 RID: 3110
	[CompilerGenerated]
	private sealed class <GetListByFurnaceTab>c__AnonStorey3
	{
		// Token: 0x06005219 RID: 21017 RVA: 0x000829B8 File Offset: 0x00080DB8
		public <GetListByFurnaceTab>c__AnonStorey3()
		{
		}

		// Token: 0x0600521A RID: 21018 RVA: 0x000829C0 File Offset: 0x00080DC0
		internal bool <>m__0(Item i)
		{
			return (i.ItemStatus == ItemStatus.Reserved && (i.Type.GetResourceCategory().IsArmor() || i.Type.GetResourceCategory().IsWeapon()) && ((!this.canMakeLed) ? (i.ItemGrade != QualityGrade.Legendary && i.ItemGrade != QualityGrade.Ancient) : (i.ItemGrade != QualityGrade.Ancient))) || i.Type.GetResourceCategory() == ResourceCategory.Gem;
		}

		// Token: 0x0400401D RID: 16413
		internal bool canMakeLed;
	}
}
