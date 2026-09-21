using System;
using UnityEngine.EventSystems;

// Token: 0x02000232 RID: 562
public class RecruitmentPageHeroController : HeroPageCardController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000EAE RID: 3758 RVA: 0x000918CC File Offset: 0x0008FCCC
	public RecruitmentPageHeroController()
	{
	}

	// Token: 0x06000EAF RID: 3759 RVA: 0x000918D4 File Offset: 0x0008FCD4
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<RecruitmentMenuController>().SelectHero(base.PageHero);
	}
}
