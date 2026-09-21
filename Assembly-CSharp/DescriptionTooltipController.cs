using System;
using TMPro;
using UnityEngine;

// Token: 0x020002D4 RID: 724
public class DescriptionTooltipController : MonoBehaviour, ITooltip
{
	// Token: 0x0600134E RID: 4942 RVA: 0x000A2298 File Offset: 0x000A0698
	public DescriptionTooltipController()
	{
	}

	// Token: 0x0600134F RID: 4943 RVA: 0x000A22A0 File Offset: 0x000A06A0
	public void DisplayContent(TooltipItem tooltipItem)
	{
		Vector2 pivot = default(Vector2);
		switch (this.CalculatePivot())
		{
		case TooltipPosition.BottomLeft:
			pivot = new Vector2(-0.07f, 0f);
			break;
		case TooltipPosition.TopLeft:
			pivot = new Vector2(-0.07f, 1f);
			break;
		case TooltipPosition.BottomRight:
			pivot = new Vector2(1.07f, 0f);
			break;
		case TooltipPosition.TopRight:
			pivot = new Vector2(1.07f, 1f);
			break;
		}
		base.GetComponent<RectTransform>().pivot = pivot;
		this.Description.text = tooltipItem.Description;
		base.transform.position = tooltipItem.Position;
	}

	// Token: 0x06001350 RID: 4944 RVA: 0x000A235F File Offset: 0x000A075F
	public void Hide()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x040013D4 RID: 5076
	public TextMeshProUGUI Description;
}
