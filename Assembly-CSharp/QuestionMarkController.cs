using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020002C8 RID: 712
public class QuestionMarkController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x0600130B RID: 4875 RVA: 0x000A12F6 File Offset: 0x0009F6F6
	public QuestionMarkController()
	{
	}

	// Token: 0x0600130C RID: 4876 RVA: 0x000A1300 File Offset: 0x0009F700
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.OpenTooltip(new TooltipItem
		{
			Title = this.TooltipTitle.GetName(),
			Description = this.TooltipDescription.GetName(),
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x0600130D RID: 4877 RVA: 0x000A1359 File Offset: 0x0009F759
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x040013AA RID: 5034
	public UIComponentType TooltipTitle;

	// Token: 0x040013AB RID: 5035
	public UIComponentType TooltipDescription;
}
