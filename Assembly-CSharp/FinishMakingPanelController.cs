using System;
using TMPro;
using UnityEngine;

// Token: 0x0200018C RID: 396
public class FinishMakingPanelController : MonoBehaviour
{
	// Token: 0x06000A54 RID: 2644 RVA: 0x0007F0D4 File Offset: 0x0007D4D4
	public FinishMakingPanelController()
	{
	}

	// Token: 0x06000A55 RID: 2645 RVA: 0x0007F0DC File Offset: 0x0007D4DC
	public void Init(bool isSucceed, Item item, int amount)
	{
		this.Title.text = ((!isSucceed) ? UIComponentType.FurnaceCombineFailed.GetName() : UIComponentType.FurnaceCombineSuccess.GetName());
		this.Title.color = ((!isSucceed) ? this.FailedColor : this.SuccessColor);
		if (item != null)
		{
			this.ItemController.Init(item.ConvertToUiNormalItem());
		}
		this.AmountText.text = ((amount <= 1) ? string.Empty : amount.ToString());
		this.FailedImage.SetActive(!isSucceed);
	}

	// Token: 0x06000A56 RID: 2646 RVA: 0x0007F184 File Offset: 0x0007D584
	public void Close()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x04000D0C RID: 3340
	public TextMeshProUGUI Title;

	// Token: 0x04000D0D RID: 3341
	public Color SuccessColor;

	// Token: 0x04000D0E RID: 3342
	public Color FailedColor;

	// Token: 0x04000D0F RID: 3343
	public ItemController ItemController;

	// Token: 0x04000D10 RID: 3344
	public TextMeshProUGUI AmountText;

	// Token: 0x04000D11 RID: 3345
	public GameObject FailedImage;
}
