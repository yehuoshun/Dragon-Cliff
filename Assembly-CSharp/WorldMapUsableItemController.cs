using System;
using TMPro;
using UnityEngine.EventSystems;

// Token: 0x02000308 RID: 776
public class WorldMapUsableItemController : ItemController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x0600149F RID: 5279 RVA: 0x000A8030 File Offset: 0x000A6430
	public WorldMapUsableItemController()
	{
	}

	// Token: 0x060014A0 RID: 5280 RVA: 0x000A8038 File Offset: 0x000A6438
	public override void Init(PageElement item)
	{
		base.Init(item);
		this.Amount.text = string.Empty;
		this._amount = 1;
		NormalItem normalItem = item as NormalItem;
		if (normalItem != null && normalItem.Amount > 1.0)
		{
			this.Amount.text = normalItem.Amount.DoubleToString();
			this._amount = normalItem.Amount.DoubleToInt();
		}
	}

	// Token: 0x060014A1 RID: 5281 RVA: 0x000A80AC File Offset: 0x000A64AC
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			base.GetComponentInParent<WorldSelectUsableItemPanelController>().LeftClickItem(this);
		}
		else if (eventData.button == PointerEventData.InputButton.Right)
		{
			base.GetComponentInParent<WorldSelectUsableItemPanelController>().RightClickItem(this.NormalItem.Item);
		}
		this.CloseTooltip();
	}

	// Token: 0x040014CC RID: 5324
	public TextMeshProUGUI Amount;

	// Token: 0x040014CD RID: 5325
	private int _amount;
}
