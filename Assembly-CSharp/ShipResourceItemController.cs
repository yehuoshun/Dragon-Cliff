using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002B7 RID: 695
public class ShipResourceItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x060012A7 RID: 4775 RVA: 0x0009F925 File Offset: 0x0009DD25
	public ShipResourceItemController()
	{
	}

	// Token: 0x060012A8 RID: 4776 RVA: 0x0009F930 File Offset: 0x0009DD30
	public void Init(ResourceConsumptionRequirement requirement)
	{
		this._requirement = requirement;
		this.ResourceImage.sprite = FilePath.GetRecipeImage(requirement.ResourceType);
		this.ResourceAmount.text = requirement.AmountRequired.ToString();
		this.ResourceAmount.color = ((!requirement.MetRequirement()) ? ColorPicker.NagetiveRed : ColorPicker.PositiveGreen);
	}

	// Token: 0x060012A9 RID: 4777 RVA: 0x0009F9A0 File Offset: 0x0009DDA0
	public void OnPointerEnter(PointerEventData eventData)
	{
		Description description = this._requirement.ResourceType.GetDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = description.Details1,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x060012AA RID: 4778 RVA: 0x0009FA00 File Offset: 0x0009DE00
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04001360 RID: 4960
	public Image ResourceImage;

	// Token: 0x04001361 RID: 4961
	public TextMeshProUGUI ResourceAmount;

	// Token: 0x04001362 RID: 4962
	private ResourceConsumptionRequirement _requirement;
}
