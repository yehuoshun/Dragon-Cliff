using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000192 RID: 402
public class FurnacePageItemController : ItemController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000AB2 RID: 2738 RVA: 0x00082A51 File Offset: 0x00080E51
	public FurnacePageItemController()
	{
	}

	// Token: 0x06000AB3 RID: 2739 RVA: 0x00082A59 File Offset: 0x00080E59
	public override void Init(PageElement item)
	{
		base.Init(item);
		this.LockImage.SetActive(this.NormalItem.Item.Locked);
	}

	// Token: 0x06000AB4 RID: 2740 RVA: 0x00082A80 File Offset: 0x00080E80
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			this.CloseTooltip();
			base.GetComponentInParent<FurnaceMenuController>().RightClickItem(this.NormalItem);
		}
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			this.CloseTooltip();
			base.GetComponentInParent<FurnaceMenuController>().SelectItem(this.NormalItem, base.transform.position);
		}
	}

	// Token: 0x04000D4F RID: 3407
	public GameObject LockImage;
}
