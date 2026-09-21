using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200036C RID: 876
public class ResourceUpdateObj : MonoBehaviour
{
	// Token: 0x06001791 RID: 6033 RVA: 0x000B672F File Offset: 0x000B4B2F
	public ResourceUpdateObj()
	{
	}

	// Token: 0x06001792 RID: 6034 RVA: 0x000B6738 File Offset: 0x000B4B38
	public void SetResourceUpdate(ResourceUpdate update, double amount)
	{
		if (update != null)
		{
			this.ResourceImage.sprite = FilePath.GetRecipeImage(update.ResourceType);
			this.ResourceType.text = update.ResourceType.GetDescription().Title + " * " + amount;
		}
		else
		{
			Debug.LogError("?");
		}
	}

	// Token: 0x04001782 RID: 6018
	public Image ResourceImage;

	// Token: 0x04001783 RID: 6019
	public Text ResourceType;
}
