using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000237 RID: 567
public class UsableItemController : ItemController, IPointerClickHandler, IGemControl, IEventSystemHandler
{
	// Token: 0x06000EBD RID: 3773 RVA: 0x00091A45 File Offset: 0x0008FE45
	public UsableItemController()
	{
	}

	// Token: 0x06000EBE RID: 3774 RVA: 0x00091A50 File Offset: 0x0008FE50
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

	// Token: 0x06000EBF RID: 3775 RVA: 0x00091AE0 File Offset: 0x0008FEE0
	public void OnPointerClick(PointerEventData eventData)
	{
		InventoryMenuController componentInParent = base.GetComponentInParent<InventoryMenuController>();
		if (componentInParent == null)
		{
			return;
		}
		if (componentInParent.IsUsingItem)
		{
			return;
		}
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			this.CloseTooltip();
			base.GetComponentInParent<InventoryMenuController>().OpenItemOperationPanel(this.NormalItem, base.transform.position);
		}
	}

	// Token: 0x06000EC0 RID: 3776 RVA: 0x00091B3C File Offset: 0x0008FF3C
	public override void OnPointerEnter(PointerEventData eventData)
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

	// Token: 0x04001028 RID: 4136
	public TextMeshProUGUI Amount;

	// Token: 0x04001029 RID: 4137
	public GameObject LockImage;

	// Token: 0x0400102A RID: 4138
	private int _amount;
}
