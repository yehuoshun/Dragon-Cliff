using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020002C4 RID: 708
public class DustPanelItemControler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060012DF RID: 4831 RVA: 0x000A037E File Offset: 0x0009E77E
	public DustPanelItemControler()
	{
	}

	// Token: 0x060012E0 RID: 4832 RVA: 0x000A0386 File Offset: 0x0009E786
	public void Init(int amount, int needAmount, bool selected)
	{
		this.UpdateAmount(amount, needAmount);
		this.Cover.SetActive(!selected);
	}

	// Token: 0x060012E1 RID: 4833 RVA: 0x000A03A0 File Offset: 0x0009E7A0
	public void UpdateAmount(int amount, int needAmount)
	{
		this.Amount.text = amount.ToString();
		if (needAmount == 0)
		{
			this.NeedAmount.text = string.Empty;
		}
		else
		{
			this.NeedAmount.text = needAmount.ToString();
		}
		if (needAmount <= amount)
		{
			this.Amount.color = ColorPicker.PositiveGreen;
			this.NeedAmount.color = ColorPicker.PositiveGreen;
		}
		else
		{
			this.Amount.color = ColorPicker.NagetiveRed;
			this.NeedAmount.color = ColorPicker.NagetiveRed;
		}
		this._amount = amount;
	}

	// Token: 0x060012E2 RID: 4834 RVA: 0x000A044B File Offset: 0x0009E84B
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this._amount <= 0)
		{
			this.DisplayWarningText(UIComponentType.InventoryMenuLackOfDust.GetName());
		}
	}

	// Token: 0x04001386 RID: 4998
	public ResourceType DustType;

	// Token: 0x04001387 RID: 4999
	public TextMeshProUGUI Amount;

	// Token: 0x04001388 RID: 5000
	public TextMeshProUGUI NeedAmount;

	// Token: 0x04001389 RID: 5001
	public GameObject Cover;

	// Token: 0x0400138A RID: 5002
	private int _amount;
}
