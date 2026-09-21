using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200021E RID: 542
public class MyShopItemController : CusItemController, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x06000E35 RID: 3637 RVA: 0x00091198 File Offset: 0x0008F598
	public MyShopItemController()
	{
	}

	// Token: 0x06000E36 RID: 3638 RVA: 0x000911A0 File Offset: 0x0008F5A0
	public new void Init(NormalItem item)
	{
		base.Init(item);
		if (item.Item != null)
		{
			this.Grade.sprite = FilePath.GetItemGradeBackground(item.Item.ItemGrade, item.Item.IsStarItem());
		}
		double? ashPerItem = item.Commodity.AshPerItem;
		if (ashPerItem != null && item.Commodity.AshPerItem > 0.0)
		{
			TMP_Text money = this.Money;
			double? ashPerItem2 = item.Commodity.AshPerItem;
			money.text = (ashPerItem2.Value * item.Amount).ToString("N0").ToAshCurrency();
		}
		else
		{
			this.Money.text = item.Price.ToString("N0").ToGameCurrency();
		}
		this.Amount.text = item.Amount.DoubleToString();
	}

	// Token: 0x06000E37 RID: 3639 RVA: 0x000912A5 File Offset: 0x0008F6A5
	public void OnPointerUp(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			base.GetComponentInParent<MyShopMenuController>().SelectItem(this);
		}
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			base.GetComponentInParent<MyShopMenuController>().DirectlyPurchase(this.NormalItem);
		}
		this.CloseTooltip();
	}

	// Token: 0x06000E38 RID: 3640 RVA: 0x000912E4 File Offset: 0x0008F6E4
	public override void OnPointerEnter(PointerEventData eventData)
	{
		if (this.NormalItem == null)
		{
			return;
		}
		TooltipItem tooltipItem = base.SetupTooltipItem();
		tooltipItem.Position = this.ResourceImage.transform.position;
		this.OpenTooltip(tooltipItem, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x04000FF0 RID: 4080
	public Image Grade;

	// Token: 0x04000FF1 RID: 4081
	public TextMeshProUGUI Money;

	// Token: 0x04000FF2 RID: 4082
	public TextMeshProUGUI Amount;
}
