using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000217 RID: 535
public class EquipmentItemController : ItemController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000E10 RID: 3600 RVA: 0x00090830 File Offset: 0x0008EC30
	public EquipmentItemController()
	{
	}

	// Token: 0x17000076 RID: 118
	// (get) Token: 0x06000E11 RID: 3601 RVA: 0x00090838 File Offset: 0x0008EC38
	// (set) Token: 0x06000E12 RID: 3602 RVA: 0x0009085D File Offset: 0x0008EC5D
	private InventoryMenuController ParentController
	{
		get
		{
			if (this._parentController == null)
			{
				this._parentController = base.GetComponentInParent<InventoryMenuController>();
			}
			return this._parentController;
		}
		set
		{
			this._parentController = value;
		}
	}

	// Token: 0x06000E13 RID: 3603 RVA: 0x00090868 File Offset: 0x0008EC68
	private void Update()
	{
		if (this.ParentController.IsUsingItem)
		{
			if (this.ParentController.UsingGem())
			{
				this.Cover.SetActive(!this.NormalItem.Item.CanBeSocketedWith(this.ParentController.SelectedItem.Item));
			}
			if (this.ParentController.UsingBatcher())
			{
				this.Cover.SetActive(!this.NormalItem.Item.CanAddMoreManualSockets());
			}
		}
		else
		{
			this.Cover.SetActive(false);
		}
	}

	// Token: 0x06000E14 RID: 3604 RVA: 0x00090902 File Offset: 0x0008ED02
	public override void Init(PageElement item)
	{
		base.Init(item);
		this.LockImage.SetActive(this.NormalItem.Item.Locked);
	}

	// Token: 0x06000E15 RID: 3605 RVA: 0x00090926 File Offset: 0x0008ED26
	public override void OnPointerEnter(PointerEventData eventData)
	{
		this.OpenTooltip(base.SetupTooltipItem(), this.NormalItem.GetInventoryEquipmentSecondTooltip(), TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000E16 RID: 3606 RVA: 0x0009094C File Offset: 0x0008ED4C
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			if (TownManager.Instance.Ui.HeroMenu.SelectedHero == null)
			{
				return;
			}
			this.ParentController.EquipItem(this.NormalItem.Item);
			this.ParentController.UpdateSelectedPage();
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
		this.CloseTooltip();
	}

	// Token: 0x04000FE5 RID: 4069
	public GameObject LockImage;

	// Token: 0x04000FE6 RID: 4070
	public GameObject Cover;

	// Token: 0x04000FE7 RID: 4071
	private InventoryMenuController _parentController;
}
