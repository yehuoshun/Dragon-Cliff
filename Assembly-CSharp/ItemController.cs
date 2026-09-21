using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000276 RID: 630
public class ItemController : PageItemController, IItemControl
{
	// Token: 0x0600108C RID: 4236 RVA: 0x0007F19A File Offset: 0x0007D59A
	public ItemController()
	{
	}

	// Token: 0x0600108D RID: 4237 RVA: 0x0007F1A4 File Offset: 0x0007D5A4
	public override void Init(PageElement item)
	{
		base.PageElement = item;
		this.MyItem = (PageItem)item;
		NormalItem normalItem = item as NormalItem;
		this.NormalItem = normalItem;
		this.ResourceImage.sprite = FilePath.GetRecipeImage(this.MyItem.ResourceType);
		if (this.NormalItem.Item != null)
		{
			this.Background.sprite = FilePath.GetItemGradeBackground(this.NormalItem.Item.ItemGrade, this.NormalItem.Item.IsStarItem());
		}
		else
		{
			this.Background.sprite = FilePath.GetItemGradeBackground(this.NormalItem.ItemGrade, false);
		}
	}

	// Token: 0x0600108E RID: 4238 RVA: 0x0007F24E File Offset: 0x0007D64E
	public void SetDefaultImage(ItemType type)
	{
		this.ResourceImage.sprite = FilePath.GetDefaultEquipmentIcon(type);
		this.Background.color = Color.white;
		this.NormalItem = null;
	}

	// Token: 0x0600108F RID: 4239 RVA: 0x0007F278 File Offset: 0x0007D678
	public override void OnPointerEnter(PointerEventData eventData)
	{
		if (this.NormalItem == null)
		{
			return;
		}
		this.OpenTooltip(this.SetupTooltipItem(), null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06001090 RID: 4240 RVA: 0x0007F29E File Offset: 0x0007D69E
	public TooltipItem SetupTooltipItem()
	{
		return this.GetItemTooltip(this.NormalItem);
	}

	// Token: 0x06001091 RID: 4241 RVA: 0x0007F2AC File Offset: 0x0007D6AC
	public override void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x040011B9 RID: 4537
	public NormalItem NormalItem;

	// Token: 0x040011BA RID: 4538
	public Image Background;
}
