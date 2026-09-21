using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002AE RID: 686
public class ShipMenuButtonController : MonoBehaviour
{
	// Token: 0x06001261 RID: 4705 RVA: 0x0009E05C File Offset: 0x0009C45C
	public ShipMenuButtonController()
	{
	}

	// Token: 0x06001262 RID: 4706 RVA: 0x0009E064 File Offset: 0x0009C464
	public void OpenShipMenu()
	{
		if (GameWorld.instance.PlayerProfile.ExplorationEnabled())
		{
			if (GameWorld.instance.PlayerProfile.CurrentVehicles.Count == 0)
			{
				TownManager.Instance.Ui.ToggleBuildShipMenu();
			}
			else
			{
				TownManager.Instance.Ui.ToggleShipMenu();
			}
		}
	}

	// Token: 0x04001320 RID: 4896
	public Button ShipMenuButton;
}
