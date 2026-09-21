using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001F1 RID: 497
public class JustDroppedItemController : ItemController, IPointerClickHandler, IGemControl, IEventSystemHandler
{
	// Token: 0x06000D31 RID: 3377 RVA: 0x0008D6A6 File Offset: 0x0008BAA6
	public JustDroppedItemController()
	{
	}

	// Token: 0x06000D32 RID: 3378 RVA: 0x0008D6B0 File Offset: 0x0008BAB0
	private void Update()
	{
		InventoryMenuController inventoryMenu = TownManager.Instance.Ui.InventoryMenu;
		if (inventoryMenu.IsUsingItem)
		{
			if (inventoryMenu.UsingGem())
			{
				this.Cover.SetActive(!this.NormalItem.Item.CanBeSocketedWith(inventoryMenu.SelectedItem.Item));
			}
			if (inventoryMenu.UsingBatcher())
			{
				this.Cover.SetActive(!this.NormalItem.Item.CanAddMoreManualSockets());
			}
		}
		else
		{
			this.Cover.SetActive(false);
		}
	}

	// Token: 0x06000D33 RID: 3379 RVA: 0x0008D748 File Offset: 0x0008BB48
	public override void Init(PageElement item)
	{
		base.Init(item);
		this.Amount.text = string.Empty;
		this.LockImage.SetActive(this.NormalItem.Item.Locked);
		this._amount = 1;
		NormalItem normalItem = item as NormalItem;
		if (normalItem != null && normalItem.Amount > 1.0)
		{
			this.Amount.text = normalItem.Amount.DoubleToString();
			this._amount = normalItem.Amount.DoubleToInt();
		}
	}

	// Token: 0x06000D34 RID: 3380 RVA: 0x0008D7D8 File Offset: 0x0008BBD8
	public override void OnPointerEnter(PointerEventData eventData)
	{
		if (this.IsEquipment())
		{
			this.OpenTooltip(base.SetupTooltipItem(), this.NormalItem.GetInventoryEquipmentSecondTooltip(), TooltipPosition.None, 0f, 0f);
		}
		else if (this.IsUsableOrGem())
		{
			if (this.NormalItem.Item.Type.GetResourceCategory() == ResourceCategory.Gem)
			{
				TooltipItem item = base.SetupTooltipItem();
				this.OpenTooltip(item, this.GetGemSecondTooltip(this.NormalItem.Item.Type), TooltipPosition.None, 0f, 0f);
			}
			else
			{
				base.OnPointerEnter(eventData);
			}
		}
	}

	// Token: 0x06000D35 RID: 3381 RVA: 0x0008D87C File Offset: 0x0008BC7C
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this.IsEquipment())
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				if (TownManager.Instance.Ui.HeroMenu.SelectedHero == null)
				{
					return;
				}
				TownManager.Instance.Ui.InventoryMenu.EquipItem(this.NormalItem.Item);
				TownManager.Instance.Ui.InventoryMenu.UpdateSelectedPage();
			}
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				InventoryMenuController componentInParent = base.GetComponentInParent<InventoryMenuController>();
				if (componentInParent.IsUsingItem)
				{
					componentInParent.UseItemOnEquipment(this.NormalItem);
				}
				else
				{
					componentInParent.OpenItemOperationPanel(this.NormalItem, base.transform.position);
				}
			}
		}
		else if (this.IsUsableOrGem())
		{
			InventoryMenuController componentInParent2 = base.GetComponentInParent<InventoryMenuController>();
			if (componentInParent2 == null)
			{
				return;
			}
			if (componentInParent2.IsUsingItem)
			{
				return;
			}
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				base.GetComponentInParent<InventoryMenuController>().OpenItemOperationPanel(this.NormalItem, base.transform.position);
			}
		}
		this.CloseTooltip();
	}

	// Token: 0x06000D36 RID: 3382 RVA: 0x0008D990 File Offset: 0x0008BD90
	private bool IsEquipment()
	{
		if (this.NormalItem == null)
		{
			return false;
		}
		ResourceCategory resourceCategory = this.NormalItem.Item.Type.GetResourceCategory();
		return this.NormalItem.Item.IsEquipment() || resourceCategory == ResourceCategory.Scrolls || resourceCategory == ResourceCategory.Amulet || resourceCategory == ResourceCategory.Device;
	}

	// Token: 0x06000D37 RID: 3383 RVA: 0x0008D9F0 File Offset: 0x0008BDF0
	private bool IsUsableOrGem()
	{
		if (this.NormalItem == null)
		{
			return false;
		}
		ResourceCategory resourceCategory = this.NormalItem.Item.Type.GetResourceCategory();
		return resourceCategory == ResourceCategory.Usable || resourceCategory == ResourceCategory.Gem;
	}

	// Token: 0x04000F3E RID: 3902
	public TextMeshProUGUI Amount;

	// Token: 0x04000F3F RID: 3903
	public GameObject LockImage;

	// Token: 0x04000F40 RID: 3904
	public GameObject Cover;

	// Token: 0x04000F41 RID: 3905
	private int _amount;
}
