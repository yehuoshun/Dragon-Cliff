using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200025E RID: 606
public class AssignmentPanelController : MonoBehaviour
{
	// Token: 0x06000FC7 RID: 4039 RVA: 0x00095F02 File Offset: 0x00094302
	public AssignmentPanelController()
	{
	}

	// Token: 0x06000FC8 RID: 4040 RVA: 0x00095F0C File Offset: 0x0009430C
	private void Start()
	{
		List<ProductionBuildingProfile> list = new List<ProductionBuildingProfile>();
		foreach (KeyValuePair<TownSlot, IBuildingProfile> keyValuePair in GameWorld.instance.PlayerProfile.Buildings)
		{
			if (keyValuePair.Value is ProductionBuildingProfile)
			{
				ProductionBuildingProfile profile = keyValuePair.Value as ProductionBuildingProfile;
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load(FilePath.UiPath + "AssignmentPageButton") as GameObject);
				int num = list.Count((ProductionBuildingProfile b) => b.BuildingType == profile.BuildingType);
				gameObject.GetComponentInChildren<Text>().text = ((num != 0) ? (profile.BuildingType.ToString() + (num + 1)) : profile.BuildingType.ToString());
				gameObject.transform.SetParent(this.ButtonPanel);
				gameObject.transform.localScale = Vector3.one;
				list.Add(profile);
			}
		}
		list.Clear();
	}

	// Token: 0x06000FC9 RID: 4041 RVA: 0x00096068 File Offset: 0x00094468
	public void CloseAssignmentPage()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x040010F9 RID: 4345
	public Transform ButtonPanel;

	// Token: 0x02000C55 RID: 3157
	[CompilerGenerated]
	private sealed class <Start>c__AnonStorey0
	{
		// Token: 0x060052AD RID: 21165 RVA: 0x00096076 File Offset: 0x00094476
		public <Start>c__AnonStorey0()
		{
		}

		// Token: 0x060052AE RID: 21166 RVA: 0x0009607E File Offset: 0x0009447E
		internal bool <>m__0(ProductionBuildingProfile b)
		{
			return b.BuildingType == this.profile.BuildingType;
		}

		// Token: 0x0400407C RID: 16508
		internal ProductionBuildingProfile profile;
	}
}
