using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000334 RID: 820
public class MultipleRewardsObjWithImageOnly : MonoBehaviour
{
	// Token: 0x060015C8 RID: 5576 RVA: 0x000ACBCE File Offset: 0x000AAFCE
	public MultipleRewardsObjWithImageOnly()
	{
	}

	// Token: 0x060015C9 RID: 5577 RVA: 0x000ACBD8 File Offset: 0x000AAFD8
	public void SetPotentialRewards(List<DropTableParameter> DropTables)
	{
		for (int i = 0; i < this.Images.Length; i++)
		{
			Image image = this.Images[i];
			if (i < DropTables.Count)
			{
				DropTableParameter dropTableParameter = DropTables[i];
				image.gameObject.transform.parent.gameObject.SetActive(true);
				image.sprite = FilePath.GetRecipeImage(dropTableParameter.ResourceType);
				image.GetComponent<ResourceTypeHoverController>().SetResourceType(dropTableParameter.ResourceType);
			}
			else
			{
				image.gameObject.transform.parent.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x060015CA RID: 5578 RVA: 0x000ACC78 File Offset: 0x000AB078
	public void SetRewardsCategories(List<ResourceCategory> respiResourceCategories)
	{
		for (int i = 0; i < this.Images.Length; i++)
		{
			Image image = this.Images[i];
			if (i < respiResourceCategories.Count)
			{
				ResourceCategory resourceCategory = respiResourceCategories[i];
				image.gameObject.transform.parent.gameObject.SetActive(true);
				image.sprite = FilePath.GetResourceCategoryIcon(resourceCategory);
				image.GetComponent<ResourceCategoryHoverController>().SetResourceType(resourceCategory);
			}
			else
			{
				image.gameObject.transform.parent.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x040015E6 RID: 5606
	public Image[] Images;
}
