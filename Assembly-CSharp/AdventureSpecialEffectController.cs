using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000150 RID: 336
public class AdventureSpecialEffectController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x0600091E RID: 2334 RVA: 0x00079B5F File Offset: 0x00077F5F
	public AdventureSpecialEffectController()
	{
	}

	// Token: 0x0600091F RID: 2335 RVA: 0x00079B67 File Offset: 0x00077F67
	public void Init(ISpecialEffectDataLoad specialEffect)
	{
		this._specialEffect = specialEffect;
		this.EffectIcon.sprite = FilePath.GetSpecialEffectIcon(specialEffect.GetSpecialEffectType());
	}

	// Token: 0x06000920 RID: 2336 RVA: 0x00079B88 File Offset: 0x00077F88
	public void OnPointerEnter(PointerEventData eventData)
	{
		Description description = this._specialEffect.GetDescription();
		if (description != null)
		{
			this.OpenTooltip(new TooltipItem
			{
				Title = description.Title,
				Description = description.Details1,
				Position = base.transform.position
			}, null, TooltipPosition.None, 0f, 0f);
		}
	}

	// Token: 0x06000921 RID: 2337 RVA: 0x00079BE9 File Offset: 0x00077FE9
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000BD0 RID: 3024
	public Image EffectIcon;

	// Token: 0x04000BD1 RID: 3025
	private ISpecialEffectDataLoad _specialEffect;
}
