using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000165 RID: 357
public class CasinoPrizeController : MonoBehaviour
{
	// Token: 0x0600097B RID: 2427 RVA: 0x0007B2A0 File Offset: 0x000796A0
	public CasinoPrizeController()
	{
	}

	// Token: 0x0600097C RID: 2428 RVA: 0x0007B2A8 File Offset: 0x000796A8
	public void Init(ResourceUpdate resource)
	{
		this.PrizeImage.sprite = FilePath.GetRecipeImage(resource.ResourceType);
		this.PrizeTitle.text = resource.ResourceType.GetDescription().Title;
		this.PrizeAmount.text = resource.ChangeAmount.DoubleToString();
	}

	// Token: 0x04000C2B RID: 3115
	public Image PrizeImage;

	// Token: 0x04000C2C RID: 3116
	public TextMeshProUGUI PrizeTitle;

	// Token: 0x04000C2D RID: 3117
	public TextMeshProUGUI PrizeAmount;
}
