using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200019F RID: 415
public class TransferDisplayItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IItemControl, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000B00 RID: 2816 RVA: 0x000840E8 File Offset: 0x000824E8
	public TransferDisplayItemController()
	{
	}

	// Token: 0x06000B01 RID: 2817 RVA: 0x000840F0 File Offset: 0x000824F0
	public void Init(Item item, bool isFirstItem)
	{
		this._item = item;
		this._isFirstItem = isFirstItem;
		this.Image.sprite = FilePath.GetRecipeImage(item.Type);
		this.GradeImage.sprite = FilePath.GetItemGradeBackground(item.ItemGrade, item.IsStarItem());
	}

	// Token: 0x06000B02 RID: 2818 RVA: 0x00084140 File Offset: 0x00082540
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this._item == null)
		{
			return;
		}
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			if (this._isFirstItem)
			{
				base.GetComponentInParent<EffectTransferPanelController>().HideEquipment();
			}
			else
			{
				base.GetComponentInParent<EffectTransferPanelController>().HideScroll();
			}
			this._item = null;
		}
		this.CloseTooltip();
	}

	// Token: 0x06000B03 RID: 2819 RVA: 0x00084198 File Offset: 0x00082598
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._item == null)
		{
			return;
		}
		this.OpenTooltip(this.GetItemTooltip(this._item.ConvertToUiNormalItem()), null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000B04 RID: 2820 RVA: 0x000841C9 File Offset: 0x000825C9
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000D9C RID: 3484
	public Image Image;

	// Token: 0x04000D9D RID: 3485
	public Image GradeImage;

	// Token: 0x04000D9E RID: 3486
	private Item _item;

	// Token: 0x04000D9F RID: 3487
	private bool _isFirstItem;
}
