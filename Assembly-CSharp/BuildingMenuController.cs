using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000263 RID: 611
public class BuildingMenuController : MonoBehaviour
{
	// Token: 0x06000FD6 RID: 4054 RVA: 0x000962EE File Offset: 0x000946EE
	public BuildingMenuController()
	{
	}

	// Token: 0x06000FD7 RID: 4055 RVA: 0x000962F6 File Offset: 0x000946F6
	private void OnEnable()
	{
		this.BuildAnimator.SetBool("NewBuilding", false);
		this.Init();
	}

	// Token: 0x06000FD8 RID: 4056 RVA: 0x0009630F File Offset: 0x0009470F
	private void OnDisable()
	{
		this._selectedBuilding = null;
		this.BuildingPage.DiselectAllElement();
		this.BuildingInfo.HideBuildingInfo();
	}

	// Token: 0x06000FD9 RID: 4057 RVA: 0x00096330 File Offset: 0x00094730
	public void Init()
	{
		IEnumerable<BuildingItem> source = from b in GameWorld.instance.PlayerProfile.GetAvaliableBuildingTypes()
		select new BuildingItem
		{
			Id = b.ToString(),
			BuildingType = b,
			Price = GameWorld.instance.PlayerProfile.GetBuildingPrice(b)
		};
		this.BuildingPage.UpdateItems(source.Cast<PageElement>().ToList<PageElement>());
	}

	// Token: 0x06000FDA RID: 4058 RVA: 0x00096385 File Offset: 0x00094785
	public void SelectBuilding(BuildingItem building)
	{
		this._selectedBuilding = building;
		this.BuildingPage.SelectElement(building);
		this.BuildingInfo.Init(building);
	}

	// Token: 0x06000FDB RID: 4059 RVA: 0x000963A8 File Offset: 0x000947A8
	public void Build()
	{
		if (this._selectedBuilding == null)
		{
			return;
		}
		PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
		if (playerProfile.CanAfford((double)playerProfile.GetBuildingPrice(this._selectedBuilding.BuildingType)))
		{
			SlotPanelsController.Instance.SelectBuilding(this._selectedBuilding.BuildingType);
			this.BuildingPage.DiselectAllElement();
			this.BuildingInfo.HideBuildingInfo();
		}
		else
		{
			this.DisplayWarningText(UIComponentType.NotEnoughMoney.GetName());
		}
	}

	// Token: 0x06000FDC RID: 4060 RVA: 0x00096429 File Offset: 0x00094829
	public void NewBuildingAvailable()
	{
		if (!base.gameObject.activeSelf)
		{
			this.BuildAnimator.SetBool("NewBuilding", true);
		}
	}

	// Token: 0x06000FDD RID: 4061 RVA: 0x0009644C File Offset: 0x0009484C
	[CompilerGenerated]
	private static BuildingItem <Init>m__0(BuildingType b)
	{
		return new BuildingItem
		{
			Id = b.ToString(),
			BuildingType = b,
			Price = GameWorld.instance.PlayerProfile.GetBuildingPrice(b)
		};
	}

	// Token: 0x04001106 RID: 4358
	public BuildingPaginationController BuildingPage;

	// Token: 0x04001107 RID: 4359
	public BuildingInfoController BuildingInfo;

	// Token: 0x04001108 RID: 4360
	public Animator BuildAnimator;

	// Token: 0x04001109 RID: 4361
	private BuildingItem _selectedBuilding;

	// Token: 0x0400110A RID: 4362
	[CompilerGenerated]
	private static Func<BuildingType, BuildingItem> <>f__am$cache0;
}
