using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200018D RID: 397
public class FurnaceEquipedItemController : ItemController, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x06000A57 RID: 2647 RVA: 0x0007F2B4 File Offset: 0x0007D6B4
	public FurnaceEquipedItemController()
	{
	}

	// Token: 0x06000A58 RID: 2648 RVA: 0x0007F2BC File Offset: 0x0007D6BC
	public override void Init(PageElement item)
	{
		base.Init(item);
		this.LockObj.SetActive(this.NormalItem.Item.Locked);
	}

	// Token: 0x06000A59 RID: 2649 RVA: 0x0007F2E0 File Offset: 0x0007D6E0
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			this.CloseTooltip();
			base.GetComponentInParent<FurnaceMenuController>().RightClickItemFromHero(this.NormalItem);
		}
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			this.CloseTooltip();
			base.GetComponentInParent<FurnaceMenuController>().SelectItem(this.NormalItem, base.transform.position);
		}
	}

	// Token: 0x06000A5A RID: 2650 RVA: 0x0007F340 File Offset: 0x0007D740
	public override void OnPointerEnter(PointerEventData eventData)
	{
		FurnaceHeroPanelController componentInParent = base.GetComponentInParent<FurnaceHeroPanelController>();
		if (componentInParent != null)
		{
			this.OpenTooltip(base.SetupTooltipItem(), componentInParent.GetGemSetTooltip(), TooltipPosition.None, 0f, 0f);
		}
	}

	// Token: 0x06000A5B RID: 2651 RVA: 0x0007F37D File Offset: 0x0007D77D
	public void OnPointerDown(PointerEventData eventData)
	{
	}

	// Token: 0x06000A5C RID: 2652 RVA: 0x0007F37F File Offset: 0x0007D77F
	public void OnPointerUp(PointerEventData eventData)
	{
	}

	// Token: 0x04000D12 RID: 3346
	public GameObject LockObj;
}
