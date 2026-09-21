using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000264 RID: 612
public class BuildingTagController : MonoBehaviour
{
	// Token: 0x06000FDE RID: 4062 RVA: 0x00096490 File Offset: 0x00094890
	public BuildingTagController()
	{
	}

	// Token: 0x06000FDF RID: 4063 RVA: 0x00096498 File Offset: 0x00094898
	public void Init(BuildingType title, int price)
	{
		this._buildingType = title;
		this.Title.text = title.ToString();
		this.Gold.text = price.ToGameCurrency();
		this.Image.sprite = FilePath.GetBuildingImage(title);
	}

	// Token: 0x06000FE0 RID: 4064 RVA: 0x000964E6 File Offset: 0x000948E6
	public void SelectThisBuilding()
	{
		SlotPanelsController.Instance.SelectBuilding(this._buildingType);
	}

	// Token: 0x0400110B RID: 4363
	public Image Image;

	// Token: 0x0400110C RID: 4364
	public Text Title;

	// Token: 0x0400110D RID: 4365
	public Text Gold;

	// Token: 0x0400110E RID: 4366
	public Text Description;

	// Token: 0x0400110F RID: 4367
	private BuildingType _buildingType;
}
