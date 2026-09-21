using System;
using UnityEngine.EventSystems;

// Token: 0x02000174 RID: 372
public class EquipmentSlotController : EquipmentSlotDisplayController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060009C0 RID: 2496 RVA: 0x0007CB52 File Offset: 0x0007AF52
	public EquipmentSlotController()
	{
	}

	// Token: 0x060009C1 RID: 2497 RVA: 0x0007CB5C File Offset: 0x0007AF5C
	public void Disrobe()
	{
		base.GetComponentInParent<HeroMenuController>().DisorbEquipment(this.SlotType);
		switch (this.SlotType)
		{
		case UiSlotType.Weapon:
			this.OnWeapon();
			break;
		case UiSlotType.Armor:
			this.OnArmor();
			break;
		case UiSlotType.Accessory1:
			this.OnAccessory();
			break;
		case UiSlotType.Scroll:
			this.OnScroll();
			break;
		case UiSlotType.Amulet:
			this.OnAmulet();
			break;
		case UiSlotType.Device:
			this.OnDevice();
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	// Token: 0x060009C2 RID: 2498 RVA: 0x0007CBEC File Offset: 0x0007AFEC
	public void UpdateStatus()
	{
		if (this.EquipedItem != null)
		{
			base.Init(this.EquipedItem);
		}
	}

	// Token: 0x060009C3 RID: 2499 RVA: 0x0007CC05 File Offset: 0x0007B005
	public void OnWeapon()
	{
		base.GetComponentInParent<HeroMenuController>().InventoryPanel.OnWeapon();
	}

	// Token: 0x060009C4 RID: 2500 RVA: 0x0007CC17 File Offset: 0x0007B017
	public void OnArmor()
	{
		base.GetComponentInParent<HeroMenuController>().InventoryPanel.OnArmor();
	}

	// Token: 0x060009C5 RID: 2501 RVA: 0x0007CC29 File Offset: 0x0007B029
	public void OnAccessory()
	{
		base.GetComponentInParent<HeroMenuController>().InventoryPanel.OnAccessory();
	}

	// Token: 0x060009C6 RID: 2502 RVA: 0x0007CC3B File Offset: 0x0007B03B
	public void OnScroll()
	{
		base.GetComponentInParent<HeroMenuController>().InventoryPanel.OnScroll();
	}

	// Token: 0x060009C7 RID: 2503 RVA: 0x0007CC4D File Offset: 0x0007B04D
	public void OnAmulet()
	{
		base.GetComponentInParent<HeroMenuController>().InventoryPanel.OnAmulet();
	}

	// Token: 0x060009C8 RID: 2504 RVA: 0x0007CC5F File Offset: 0x0007B05F
	public void OnDevice()
	{
		base.GetComponentInParent<HeroMenuController>().InventoryPanel.OnDevice();
	}

	// Token: 0x060009C9 RID: 2505 RVA: 0x0007CC71 File Offset: 0x0007B071
	public void OnPointerClick(PointerEventData eventData)
	{
	}

	// Token: 0x060009CA RID: 2506 RVA: 0x0007CC73 File Offset: 0x0007B073
	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	// Token: 0x060009CB RID: 2507 RVA: 0x0007CC75 File Offset: 0x0007B075
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}
}
