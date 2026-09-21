using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200036A RID: 874
public class CompetitonRewardObj : MonoBehaviour
{
	// Token: 0x0600178A RID: 6026 RVA: 0x000B65A8 File Offset: 0x000B49A8
	public CompetitonRewardObj()
	{
	}

	// Token: 0x0600178B RID: 6027 RVA: 0x000B65B0 File Offset: 0x000B49B0
	public void SetReward(ResourceUpdate resouceUpdate1)
	{
		this.Resource1Image.sprite = FilePath.GetRecipeImage(resouceUpdate1.ResourceType);
		this.ResourceType1.text = resouceUpdate1.ResourceType.GetDescription().Title + " * " + resouceUpdate1.ChangeAmount;
	}

	// Token: 0x0600178C RID: 6028 RVA: 0x000B6604 File Offset: 0x000B4A04
	public void SetTwoRewards(ResourceUpdate resouceUpdate1, ResourceUpdate resourceUpdate2)
	{
		this.Resource1Image.sprite = FilePath.GetRecipeImage(resouceUpdate1.ResourceType);
		this.ResourceType1.text = resouceUpdate1.ResourceType.GetDescription().Title + " * " + resouceUpdate1.ChangeAmount;
		if (resourceUpdate2 != null)
		{
			this.Resource2Image.sprite = FilePath.GetRecipeImage(resourceUpdate2.ResourceType);
			this.ResourceType2.text = resourceUpdate2.ResourceType.GetDescription().Title + " * " + resourceUpdate2.ChangeAmount;
			this.DoesRewardTwo(true);
		}
		else
		{
			this.DoesRewardTwo(false);
		}
	}

	// Token: 0x0600178D RID: 6029 RVA: 0x000B66B6 File Offset: 0x000B4AB6
	private void DoesRewardTwo(bool status)
	{
		this.Resource2Image.gameObject.SetActive(status);
		this.ResourceType2.gameObject.SetActive(status);
	}

	// Token: 0x04001778 RID: 6008
	public Image Resource1Image;

	// Token: 0x04001779 RID: 6009
	public Text ResourceType1;

	// Token: 0x0400177A RID: 6010
	public Image Resource2Image;

	// Token: 0x0400177B RID: 6011
	public Text ResourceType2;
}
