using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002B8 RID: 696
public class TravellerContributionController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x060012AB RID: 4779 RVA: 0x0009FA08 File Offset: 0x0009DE08
	public TravellerContributionController()
	{
	}

	// Token: 0x060012AC RID: 4780 RVA: 0x0009FA10 File Offset: 0x0009DE10
	public void Init(JourneyContributionModifier contribution)
	{
		this._contribution = contribution;
		this.Icon.sprite = FilePath.GetTravelContributionIcon(contribution.Type);
		this.Amount.text = contribution.Value.DoubleToString();
	}

	// Token: 0x060012AD RID: 4781 RVA: 0x0009FA48 File Offset: 0x0009DE48
	public void OnPointerEnter(PointerEventData eventData)
	{
		Description description = this._contribution.Type.GetDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = description.Details1,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x060012AE RID: 4782 RVA: 0x0009FAA8 File Offset: 0x0009DEA8
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04001363 RID: 4963
	public Image Icon;

	// Token: 0x04001364 RID: 4964
	public TextMeshProUGUI Amount;

	// Token: 0x04001365 RID: 4965
	private JourneyContributionModifier _contribution;
}
