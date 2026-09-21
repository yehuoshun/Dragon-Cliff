using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000233 RID: 563
public class RequirementItemController : PageItemController
{
	// Token: 0x06000EB0 RID: 3760 RVA: 0x000918E7 File Offset: 0x0008FCE7
	public RequirementItemController()
	{
	}

	// Token: 0x06000EB1 RID: 3761 RVA: 0x000918F0 File Offset: 0x0008FCF0
	public override void Init(PageElement item)
	{
		this.MyItem = (PageItem)item;
		this.ResourceImage.sprite = FilePath.GetRecipeImage(this.MyItem.ResourceType);
		this.AmountText.text = this.MyItem.Amount.ToString();
	}

	// Token: 0x06000EB2 RID: 3762 RVA: 0x00091948 File Offset: 0x0008FD48
	public override void OnPointerEnter(PointerEventData eventData)
	{
		this.OpenTooltip(new TooltipItem
		{
			Title = this.MyItem.ResourceType.ToString(),
			Image = FilePath.GetRecipeImage(this.MyItem.ResourceType)
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000EB3 RID: 3763 RVA: 0x000919A3 File Offset: 0x0008FDA3
	public override void OnPointerExit(PointerEventData eventData)
	{
	}

	// Token: 0x04001022 RID: 4130
	public Text AmountText;
}
