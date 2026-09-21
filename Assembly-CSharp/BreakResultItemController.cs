using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000181 RID: 385
public class BreakResultItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000A1E RID: 2590 RVA: 0x0007E220 File Offset: 0x0007C620
	public BreakResultItemController()
	{
	}

	// Token: 0x06000A1F RID: 2591 RVA: 0x0007E228 File Offset: 0x0007C628
	public void Init(ResourceUpdate resource)
	{
		this._resource = resource;
		this.ResultImage.sprite = FilePath.GetRecipeImage(resource.ResourceType);
		this.ResultName.text = resource.ResourceType.GetDescription().Title;
		this.ResultAmount.text = "x " + resource.ChangeAmount.DoubleToString();
	}

	// Token: 0x06000A20 RID: 2592 RVA: 0x0007E290 File Offset: 0x0007C690
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._resource == null)
		{
			return;
		}
		Description description = this._resource.ResourceType.GetDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = description.Details1,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000A21 RID: 2593 RVA: 0x0007E2FC File Offset: 0x0007C6FC
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000CE2 RID: 3298
	public Image ResultImage;

	// Token: 0x04000CE3 RID: 3299
	public TextMeshProUGUI ResultName;

	// Token: 0x04000CE4 RID: 3300
	public TextMeshProUGUI ResultAmount;

	// Token: 0x04000CE5 RID: 3301
	private ResourceUpdate _resource;
}
