using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020002D3 RID: 723
public class SingleDescriptionTooltipController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x0600134B RID: 4939 RVA: 0x000A224B File Offset: 0x000A064B
	public SingleDescriptionTooltipController()
	{
	}

	// Token: 0x0600134C RID: 4940 RVA: 0x000A2254 File Offset: 0x000A0654
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.OpenDescriptionTooltip(new TooltipItem
		{
			Description = this.TooltipDescription.GetName(),
			Position = base.transform.position
		});
	}

	// Token: 0x0600134D RID: 4941 RVA: 0x000A2290 File Offset: 0x000A0690
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseDescriptionTooltip();
	}

	// Token: 0x040013D3 RID: 5075
	public UIComponentType TooltipDescription;
}
