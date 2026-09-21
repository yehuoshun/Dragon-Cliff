using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000186 RID: 390
public class EnchantItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IItemControl, IEventSystemHandler
{
	// Token: 0x06000A3A RID: 2618 RVA: 0x0007EAB4 File Offset: 0x0007CEB4
	public EnchantItemController()
	{
	}

	// Token: 0x06000A3B RID: 2619 RVA: 0x0007EABC File Offset: 0x0007CEBC
	public void Init(Item item)
	{
		if (item != null)
		{
			this._item = item;
			this.GradeImage.sprite = FilePath.GetItemGradeBackground(item.ItemGrade, item.IsStarItem());
			this.ItemImage.sprite = FilePath.GetRecipeImage(item.Type);
			this.GradeImage.gameObject.SetActive(true);
			this.ItemImage.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000A3C RID: 2620 RVA: 0x0007EB2A File Offset: 0x0007CF2A
	public void HideIcon()
	{
		this._item = null;
		this.GradeImage.gameObject.SetActive(false);
		this.ItemImage.gameObject.SetActive(false);
	}

	// Token: 0x06000A3D RID: 2621 RVA: 0x0007EB55 File Offset: 0x0007CF55
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._item == null)
		{
			return;
		}
		this.OpenTooltip(this.GetItemTooltip(this._item.ConvertToUiNormalItem()), null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000A3E RID: 2622 RVA: 0x0007EB86 File Offset: 0x0007CF86
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x06000A3F RID: 2623 RVA: 0x0007EB90 File Offset: 0x0007CF90
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			EnchantPanelController componentInParent = base.GetComponentInParent<EnchantPanelController>();
			if (componentInParent != null)
			{
				componentInParent.TakeOffItem();
			}
			ReforgePanelController componentInParent2 = base.GetComponentInParent<ReforgePanelController>();
			if (componentInParent2 != null)
			{
				componentInParent2.TakeOffItem();
			}
		}
	}

	// Token: 0x04000CFA RID: 3322
	public Image ItemImage;

	// Token: 0x04000CFB RID: 3323
	public Image GradeImage;

	// Token: 0x04000CFC RID: 3324
	private Item _item;
}
