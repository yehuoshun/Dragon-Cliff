using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001C6 RID: 454
public class HeroStarEffectController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000C14 RID: 3092 RVA: 0x00088D29 File Offset: 0x00087129
	public HeroStarEffectController()
	{
	}

	// Token: 0x06000C15 RID: 3093 RVA: 0x00088D31 File Offset: 0x00087131
	public void Init(List<ISpecialEffectDataLoad> effects)
	{
		this._starEffects = effects;
	}

	// Token: 0x06000C16 RID: 3094 RVA: 0x00088D3C File Offset: 0x0008713C
	public void OnPointerEnter(PointerEventData eventData)
	{
		string text = string.Empty;
		foreach (ISpecialEffectDataLoad specialEffectDataLoad in this._starEffects)
		{
			text = text + specialEffectDataLoad.GetDescription().Details1 + "\n";
		}
		this.OpenTooltip(new TooltipItem
		{
			Title = ((this._starEffects.Count <= 0) ? UIComponentType.HeroStarEffectTitle.GetName() : this._starEffects[0].GetDescription().Title),
			Description = text,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000C17 RID: 3095 RVA: 0x00088E1C File Offset: 0x0008721C
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000E6E RID: 3694
	private List<ISpecialEffectDataLoad> _starEffects;
}
