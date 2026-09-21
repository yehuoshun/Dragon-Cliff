using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000261 RID: 609
public class BuidlingListPanelController : MonoBehaviour
{
	// Token: 0x06000FD0 RID: 4048 RVA: 0x00096135 File Offset: 0x00094535
	public BuidlingListPanelController()
	{
	}

	// Token: 0x06000FD1 RID: 4049 RVA: 0x00096140 File Offset: 0x00094540
	public void Init()
	{
		this.Clear();
		PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
		foreach (BuildingType buildingType in playerProfile.GetAvaliableBuildingTypes())
		{
			BuildingTagController component = UnityEngine.Object.Instantiate<GameObject>(this.BuildingTag).GetComponent<BuildingTagController>();
			component.Init(buildingType, playerProfile.GetBuildingPrice(buildingType));
			component.transform.SetParent(this.BuildingsContainer);
			component.transform.localScale = Vector3.one;
		}
	}

	// Token: 0x06000FD2 RID: 4050 RVA: 0x000961E8 File Offset: 0x000945E8
	public void Clear()
	{
		IEnumerator enumerator = this.BuildingsContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x040010FD RID: 4349
	public Transform BuildingsContainer;

	// Token: 0x040010FE RID: 4350
	public GameObject BuildingTag;

	// Token: 0x040010FF RID: 4351
	public SlotPanelsController SlotController;
}
