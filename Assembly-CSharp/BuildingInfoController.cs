using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000262 RID: 610
public class BuildingInfoController : MonoBehaviour
{
	// Token: 0x06000FD3 RID: 4051 RVA: 0x00096254 File Offset: 0x00094654
	public BuildingInfoController()
	{
	}

	// Token: 0x06000FD4 RID: 4052 RVA: 0x0009625C File Offset: 0x0009465C
	public void Init(BuildingItem building)
	{
		if (building == null)
		{
			this.HideBuildingInfo();
		}
		else
		{
			this.InfoPanel.SetActive(true);
			this.BuildingImage.sprite = FilePath.GetBuildingImage(building.BuildingType);
			Description description = building.BuildingType.GetDescription();
			this.BuildingName.text = description.Title;
			this.BuildingDescription.text = description.Details1;
			this.BuildingPrice.text = building.Price.ToGameCurrency();
		}
	}

	// Token: 0x06000FD5 RID: 4053 RVA: 0x000962E0 File Offset: 0x000946E0
	public void HideBuildingInfo()
	{
		this.InfoPanel.SetActive(false);
	}

	// Token: 0x04001100 RID: 4352
	public GameObject InfoPanel;

	// Token: 0x04001101 RID: 4353
	public Image BuildingImage;

	// Token: 0x04001102 RID: 4354
	public TextMeshProUGUI BuildingName;

	// Token: 0x04001103 RID: 4355
	public TextMeshProUGUI BuildingPrice;

	// Token: 0x04001104 RID: 4356
	public TextMeshProUGUI BuildingDescription;

	// Token: 0x04001105 RID: 4357
	public Button BuildButton;
}
