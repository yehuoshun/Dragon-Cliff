using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001B0 RID: 432
public class EquipedItemController : ItemController, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x06000B56 RID: 2902 RVA: 0x00085BB4 File Offset: 0x00083FB4
	public EquipedItemController()
	{
	}

	// Token: 0x06000B57 RID: 2903 RVA: 0x00085BBC File Offset: 0x00083FBC
	public override void Init(PageElement item)
	{
		base.Init(item);
		this.LockObj.SetActive(this.NormalItem.Item.Locked);
	}

	// Token: 0x06000B58 RID: 2904 RVA: 0x00085BE0 File Offset: 0x00083FE0
	public void Disorb()
	{
		EquipmentSlotController componentInParent = base.GetComponentInParent<EquipmentSlotController>();
		if (componentInParent != null)
		{
			componentInParent.Disrobe();
		}
	}

	// Token: 0x06000B59 RID: 2905 RVA: 0x00085C08 File Offset: 0x00084008
	public void UseItemOnEquipment()
	{
		InventoryMenuController inventoryMenu = TownManager.Instance.Ui.InventoryMenu;
		if (inventoryMenu.IsUsingItem)
		{
			inventoryMenu.UseItemOnEquipment(this.NormalItem);
		}
	}

	// Token: 0x06000B5A RID: 2906 RVA: 0x00085C3C File Offset: 0x0008403C
	public void OnPointerClick(PointerEventData eventData)
	{
		HeroMenuController componentInParent = base.GetComponentInParent<HeroMenuController>();
		if (componentInParent == null)
		{
			return;
		}
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			InventoryMenuController inventoryMenu = TownManager.Instance.Ui.InventoryMenu;
			if (inventoryMenu.IsUsingItem)
			{
				inventoryMenu.UseItemOnEquipment(this.NormalItem);
			}
			else
			{
				componentInParent.InventoryPanel.OpenEquipmentOperationPanel(this.NormalItem, base.transform.position);
				this.CloseTooltip();
			}
		}
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			this.Disorb();
		}
	}

	// Token: 0x06000B5B RID: 2907 RVA: 0x00085CC8 File Offset: 0x000840C8
	public override void OnPointerEnter(PointerEventData eventData)
	{
		WorldMapHeroDetailsController componentInParent = base.GetComponentInParent<WorldMapHeroDetailsController>();
		HeroMenuController componentInParent2 = base.GetComponentInParent<HeroMenuController>();
		ResourceCategory resourceCategory = this.NormalItem.Item.Type.GetResourceCategory();
		if (componentInParent != null)
		{
			if (resourceCategory != ResourceCategory.Amulet && resourceCategory != ResourceCategory.Device)
			{
				this.OpenTooltip(base.SetupTooltipItem(), componentInParent.GetGemSetTooltip(), TooltipPosition.None, 0f, 0f);
			}
			else
			{
				this.OpenTooltip(base.SetupTooltipItem(), null, TooltipPosition.None, 0f, 0f);
			}
		}
		else if (componentInParent2 != null)
		{
			if (resourceCategory != ResourceCategory.Amulet && resourceCategory != ResourceCategory.Device)
			{
				this.OpenTooltip(base.SetupTooltipItem(), componentInParent2.InventoryPanel.GetGemSetTooltip(), TooltipPosition.None, 0f, 0f);
			}
			else
			{
				this.OpenTooltip(base.SetupTooltipItem(), null, TooltipPosition.None, 0f, 0f);
			}
		}
	}

	// Token: 0x06000B5C RID: 2908 RVA: 0x00085DAF File Offset: 0x000841AF
	public void OnPointerDown(PointerEventData eventData)
	{
	}

	// Token: 0x06000B5D RID: 2909 RVA: 0x00085DB1 File Offset: 0x000841B1
	public void OnPointerUp(PointerEventData eventData)
	{
	}

	// Token: 0x04000DD9 RID: 3545
	public GameObject LockObj;
}
