using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001D2 RID: 466
public class RemoveHeroButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000C9D RID: 3229 RVA: 0x0008AC10 File Offset: 0x00089010
	public RemoveHeroButtonController()
	{
	}

	// Token: 0x06000C9E RID: 3230 RVA: 0x0008AC18 File Offset: 0x00089018
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.OpenTooltip(new TooltipItem
		{
			Title = UIComponentType.HeroMenuRemoveHeroButtonTitle.GetName(),
			Description = UIComponentType.HeroMenuRemoveHeroButtonDescription.GetName().ReplaceToBuilder(UIComponentKey.PracticePoint, PlayerProfile.ReleaseAdventurerGainPointsRatio.ToExpressionMultiply100() + "%").ToString(),
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000C9F RID: 3231 RVA: 0x0008AC92 File Offset: 0x00089092
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}
}
