using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000143 RID: 323
public class PurchasedItemController : MonoBehaviour
{
	// Token: 0x060008DB RID: 2267 RVA: 0x000786D0 File Offset: 0x00076AD0
	public PurchasedItemController()
	{
	}

	// Token: 0x060008DC RID: 2268 RVA: 0x000786D8 File Offset: 0x00076AD8
	public void Init(ResourceUpdate update)
	{
		this.Image.sprite = FilePath.GetRecipeImage(update.ResourceType);
		if (update.ChangeAmount >= 0.0)
		{
			this.ChangedText.color = this.PositiveColor;
			this.ChangedText.text = "+" + update.ChangeAmount;
		}
		else
		{
			this.ChangedText.color = this.NagetiveColor;
			this.ChangedText.text = update.ChangeAmount.ToString();
		}
	}

	// Token: 0x04000B6E RID: 2926
	public Image Image;

	// Token: 0x04000B6F RID: 2927
	public Text ChangedText;

	// Token: 0x04000B70 RID: 2928
	public Color PositiveColor;

	// Token: 0x04000B71 RID: 2929
	public Color NagetiveColor;
}
