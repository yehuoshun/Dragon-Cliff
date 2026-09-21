using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000175 RID: 373
public class ConsumptionItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x060009CC RID: 2508 RVA: 0x0007CC7D File Offset: 0x0007B07D
	public ConsumptionItemController()
	{
	}

	// Token: 0x060009CD RID: 2509 RVA: 0x0007CC88 File Offset: 0x0007B088
	public void Init(ResourceConsumptionRequirement consumpation)
	{
		this._consumption = consumpation;
		this.ItemIcon.sprite = FilePath.GetRecipeImage(consumpation.ResourceType);
		this.ItemTitle.text = consumpation.ResourceType.GetDescription().Title;
		this.ItemAmount.text = " x " + consumpation.AmountRequired;
	}

	// Token: 0x060009CE RID: 2510 RVA: 0x0007CCF0 File Offset: 0x0007B0F0
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._consumption == null)
		{
			return;
		}
		Description description = this._consumption.ResourceType.GetDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = description.Details1,
			Position = this.ItemIcon.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x060009CF RID: 2511 RVA: 0x0007CD61 File Offset: 0x0007B161
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000C9A RID: 3226
	public Image ItemIcon;

	// Token: 0x04000C9B RID: 3227
	public TextMeshProUGUI ItemTitle;

	// Token: 0x04000C9C RID: 3228
	public TextMeshProUGUI ItemAmount;

	// Token: 0x04000C9D RID: 3229
	private ResourceConsumptionRequirement _consumption;
}
