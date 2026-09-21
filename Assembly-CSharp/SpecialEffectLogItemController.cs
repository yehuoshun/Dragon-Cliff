using System;
using TMPro;
using UnityEngine;

// Token: 0x020001D7 RID: 471
public class SpecialEffectLogItemController : MonoBehaviour
{
	// Token: 0x06000CB2 RID: 3250 RVA: 0x0008AF40 File Offset: 0x00089340
	public SpecialEffectLogItemController()
	{
	}

	// Token: 0x06000CB3 RID: 3251 RVA: 0x0008AF48 File Offset: 0x00089348
	public void Init(SpecialEffectDetails effect)
	{
		this.Title.text = effect.Type.GetDescription().Title;
		this.Title.color = ((!effect.IsUnlocked) ? ColorPicker.Grey : ColorPicker.SpecialEffectTextColor);
		this.Description.text = ((!effect.IsUnlocked) ? UIComponentType.SpecialEffectLockedText.GetName() : effect.Details);
		this.Description.color = ((!effect.IsUnlocked) ? ColorPicker.Grey : Color.white);
	}

	// Token: 0x04000ECB RID: 3787
	public TextMeshProUGUI Title;

	// Token: 0x04000ECC RID: 3788
	public TextMeshProUGUI Description;
}
