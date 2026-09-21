using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000163 RID: 355
public class BoostedItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000973 RID: 2419 RVA: 0x0007B0D5 File Offset: 0x000794D5
	public BoostedItemController()
	{
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x0007B0DD File Offset: 0x000794DD
	public void Init(double amount, double exceededAmount, double maxAmount)
	{
		this._amount = amount;
		this._exceededAmount = exceededAmount;
		this._maxAmount = maxAmount;
		this.AmountText.text = amount.ToExpressionMultiply100() + "%";
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x0007B110 File Offset: 0x00079510
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.OpenTooltip(new TooltipItem
		{
			Title = this.Title.GetName(),
			Description = this.Description.GetName().ReplaceToBuilder(UIComponentKey.Amount, ColorPicker.GetHaxString(ColorPicker.PositiveGreen, this._amount.ToExpressionMultiply100() + "%. ")).ToString() + ((this._exceededAmount <= 0.0) ? string.Empty : UIComponentType.CurrentlyExceedAmount.GetName().ReplaceToBuilder(UIComponentKey.Amount, (this._exceededAmount.ToExpressionMultiply100() + "%").ToColor(ColorPicker.NagetiveRed)).ToString()) + ((this._maxAmount <= 0.0) ? string.Empty : string.Concat(new string[]
			{
				"  (",
				UIComponentType.TownBoostedStateMaxAmountText.GetName(),
				": ",
				this._maxAmount.ToExpressionMultiply100(),
				"%)"
			})),
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000976 RID: 2422 RVA: 0x0007B24E File Offset: 0x0007964E
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000C23 RID: 3107
	public TextMeshProUGUI AmountText;

	// Token: 0x04000C24 RID: 3108
	public UIComponentType Title;

	// Token: 0x04000C25 RID: 3109
	public UIComponentType Description;

	// Token: 0x04000C26 RID: 3110
	private double _amount;

	// Token: 0x04000C27 RID: 3111
	private double _exceededAmount;

	// Token: 0x04000C28 RID: 3112
	private double _maxAmount;
}
