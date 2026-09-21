using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020003A3 RID: 931
public class RewardsObj : MonoBehaviour
{
	// Token: 0x060018DF RID: 6367 RVA: 0x000BF886 File Offset: 0x000BDC86
	public RewardsObj()
	{
	}

	// Token: 0x060018E0 RID: 6368 RVA: 0x000BF890 File Offset: 0x000BDC90
	public void SetReward(ResourceUpdate resource)
	{
		this.ResourceAmount.text = resource.ResourceType.GetDescription().Title + " " + resource.ChangeAmount;
		this.ResourceImage.sprite = FilePath.GetRecipeImage(resource.ResourceType);
	}

	// Token: 0x040018B3 RID: 6323
	public Image ResourceImage;

	// Token: 0x040018B4 RID: 6324
	public Text ResourceAmount;
}
