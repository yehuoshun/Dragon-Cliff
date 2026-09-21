using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200025A RID: 602
public class SchoolScrollResultItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IItemControl, IEventSystemHandler
{
	// Token: 0x06000FB9 RID: 4025 RVA: 0x00095D1F File Offset: 0x0009411F
	public SchoolScrollResultItemController()
	{
	}

	// Token: 0x06000FBA RID: 4026 RVA: 0x00095D28 File Offset: 0x00094128
	public void Init(Item item)
	{
		this._resultItem = item;
		this.ResultImage.sprite = FilePath.GetRecipeImage(item.Type);
		this.ResultName.text = item.Type.GetDescription().Title;
		this.ResultAmount.text = "x 1";
	}

	// Token: 0x06000FBB RID: 4027 RVA: 0x00095D7D File Offset: 0x0009417D
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._resultItem == null)
		{
			return;
		}
		this.OpenTooltip(this.GetItemTooltip(this._resultItem.ConvertToUiNormalItem()), null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000FBC RID: 4028 RVA: 0x00095DAE File Offset: 0x000941AE
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x040010F2 RID: 4338
	public Image ResultImage;

	// Token: 0x040010F3 RID: 4339
	public TextMeshProUGUI ResultName;

	// Token: 0x040010F4 RID: 4340
	public TextMeshProUGUI ResultAmount;

	// Token: 0x040010F5 RID: 4341
	private Item _resultItem;
}
