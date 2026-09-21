using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000197 RID: 407
public class QuickCombineItemController : MonoBehaviour
{
	// Token: 0x06000AD2 RID: 2770 RVA: 0x000830C7 File Offset: 0x000814C7
	public QuickCombineItemController()
	{
	}

	// Token: 0x06000AD3 RID: 2771 RVA: 0x000830D0 File Offset: 0x000814D0
	public void Init(QuickCombineItem item)
	{
		this.ItemImage.sprite = FilePath.GetRecipeImage(item.Resource);
		this.AmountText.text = "x " + item.Amount;
		this.AmountText.color = ((!item.InsufficientAmount) ? ColorPicker.PositiveGreen : ColorPicker.NagetiveRed);
		if (item.Resource.GetResourceCategory() == ResourceCategory.Gem)
		{
			this.GradeImage.color = Color.clear;
			this.LevelText.gameObject.SetActive(true);
			this.LevelText.text = item.Level.ToLevelText();
		}
		else
		{
			this.GradeImage.color = Color.white;
			this.LevelText.gameObject.SetActive(false);
			this.GradeImage.sprite = FilePath.GetItemGradeBackground(item.Grade, false);
		}
	}

	// Token: 0x04000D6B RID: 3435
	public TextMeshProUGUI AmountText;

	// Token: 0x04000D6C RID: 3436
	public Image GradeImage;

	// Token: 0x04000D6D RID: 3437
	public Image ItemImage;

	// Token: 0x04000D6E RID: 3438
	public TextMeshProUGUI LevelText;
}
