using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200024B RID: 587
public class ResidentEffectItemController : MonoBehaviour
{
	// Token: 0x06000F28 RID: 3880 RVA: 0x000937D7 File Offset: 0x00091BD7
	public ResidentEffectItemController()
	{
	}

	// Token: 0x06000F29 RID: 3881 RVA: 0x000937DF File Offset: 0x00091BDF
	public void Init(IResidentEffect effect)
	{
		this.EffectIcon.sprite = FilePath.GetResidentEffectIcon(effect.CorrespondingEffectType);
		this.EffectText.text = effect.GetDescription().Details1;
	}

	// Token: 0x04001086 RID: 4230
	public Image EffectIcon;

	// Token: 0x04001087 RID: 4231
	public TextMeshProUGUI EffectText;
}
