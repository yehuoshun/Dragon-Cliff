using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020002A6 RID: 678
public class JourneyContributionTextController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x0600123C RID: 4668 RVA: 0x0009D874 File Offset: 0x0009BC74
	public JourneyContributionTextController()
	{
	}

	// Token: 0x0600123D RID: 4669 RVA: 0x0009D87C File Offset: 0x0009BC7C
	public void OnPointerEnter(PointerEventData eventData)
	{
		Description description = this.Type.GetDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = description.Details1,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x0600123E RID: 4670 RVA: 0x0009D8D7 File Offset: 0x0009BCD7
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04001307 RID: 4871
	public JourneyContributeType Type;
}
