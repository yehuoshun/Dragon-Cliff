using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000286 RID: 646
public class RecruitmentSummonButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x0600113C RID: 4412 RVA: 0x0009A3C5 File Offset: 0x000987C5
	public RecruitmentSummonButtonController()
	{
	}

	// Token: 0x0600113D RID: 4413 RVA: 0x0009A3CD File Offset: 0x000987CD
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.RecruitmentMenu.OnMouseOverSummon(base.transform.position);
	}

	// Token: 0x0600113E RID: 4414 RVA: 0x0009A3E5 File Offset: 0x000987E5
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x0400121C RID: 4636
	public RecruitmentMenuController RecruitmentMenu;
}
