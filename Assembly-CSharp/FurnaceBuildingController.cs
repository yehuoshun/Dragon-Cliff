using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020000FB RID: 251
public class FurnaceBuildingController : MonoBehaviour
{
	// Token: 0x060006E4 RID: 1764 RVA: 0x0006A693 File Offset: 0x00068A93
	public FurnaceBuildingController()
	{
	}

	// Token: 0x060006E5 RID: 1765 RVA: 0x0006A69B File Offset: 0x00068A9B
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.F) && TownManager.Instance.Ui.CanUseHotKey())
		{
			TownManager.Instance.Ui.OpenFurnaceMenu();
		}
	}

	// Token: 0x060006E6 RID: 1766 RVA: 0x0006A6CC File Offset: 0x00068ACC
	public void OnMouseUp()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		TownManager.Instance.Ui.OpenFurnaceMenu();
	}
}
