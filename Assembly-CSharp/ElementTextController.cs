using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001AD RID: 429
public class ElementTextController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000B4D RID: 2893 RVA: 0x000858BB File Offset: 0x00083CBB
	public ElementTextController()
	{
	}

	// Token: 0x06000B4E RID: 2894 RVA: 0x000858C4 File Offset: 0x00083CC4
	public void Init(AdventurerProfile adventurer)
	{
		this.OutputTypeTitleText.text = UIComponentType.HeroMenuOutputTypeTitle.GetName();
		this._adventurer = adventurer;
		OutputType outputType = adventurer.GetOutputType();
		this.OutputTypeText.text = outputType.GetDescription().Title;
		this.OutputTypeText.color = ColorPicker.GetOutputTypeColor(outputType);
	}

	// Token: 0x06000B4F RID: 2895 RVA: 0x0008591B File Offset: 0x00083D1B
	public void Clear()
	{
		this._adventurer = null;
		this.OutputTypeTitleText.text = string.Empty;
		this.OutputTypeText.text = string.Empty;
	}

	// Token: 0x06000B50 RID: 2896 RVA: 0x00085944 File Offset: 0x00083D44
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._adventurer == null)
		{
			return;
		}
		List<ElementEffectDetails> outputElementDetails = this._adventurer.GetOutputElementDetails();
		string text = string.Empty;
		foreach (ElementEffectDetails elementEffectDetails in outputElementDetails)
		{
			string str = (!elementEffectDetails.Unlocked) ? ColorPicker.GetHaxString(ColorPicker.Grey, elementEffectDetails.Description + " " + UIComponentType.ElementNotYetUnlock.GetName()) : elementEffectDetails.Description;
			text = text + str + "<size=7>\n</size>";
		}
		this.OpenTooltip(new TooltipItem
		{
			Title = UIComponentType.HeroMenuOutputTypeTitle.GetName(),
			Description = text,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000B51 RID: 2897 RVA: 0x00085A44 File Offset: 0x00083E44
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000DD3 RID: 3539
	public TextMeshProUGUI OutputTypeTitleText;

	// Token: 0x04000DD4 RID: 3540
	public TextMeshProUGUI OutputTypeText;

	// Token: 0x04000DD5 RID: 3541
	private AdventurerProfile _adventurer;
}
