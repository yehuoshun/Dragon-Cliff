using System;
using TMPro;
using UnityEngine.EventSystems;

// Token: 0x02000236 RID: 566
public class ResourceItemController : PageItemController
{
	// Token: 0x06000EB9 RID: 3769 RVA: 0x000919C7 File Offset: 0x0008FDC7
	public ResourceItemController()
	{
	}

	// Token: 0x06000EBA RID: 3770 RVA: 0x000919D0 File Offset: 0x0008FDD0
	public override void Init(PageElement item)
	{
		this.MyItem = (PageItem)item;
		this.ResourceImage.sprite = FilePath.GetRecipeImage(this.MyItem.ResourceType);
		Description description = this.MyItem.ResourceType.GetDescription();
		this.Name.text = description.Title;
		this.Amount.text = this.MyItem.Amount.DoubleToString();
	}

	// Token: 0x06000EBB RID: 3771 RVA: 0x00091A41 File Offset: 0x0008FE41
	public override void OnPointerEnter(PointerEventData eventData)
	{
	}

	// Token: 0x06000EBC RID: 3772 RVA: 0x00091A43 File Offset: 0x0008FE43
	public override void OnPointerExit(PointerEventData eventData)
	{
	}

	// Token: 0x04001026 RID: 4134
	public TextMeshProUGUI Name;

	// Token: 0x04001027 RID: 4135
	public TextMeshProUGUI Amount;
}
