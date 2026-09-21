using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002BE RID: 702
public class CharacterAvatarController : MonoBehaviour
{
	// Token: 0x060012C9 RID: 4809 RVA: 0x000A0062 File Offset: 0x0009E462
	public CharacterAvatarController()
	{
	}

	// Token: 0x060012CA RID: 4810 RVA: 0x000A006C File Offset: 0x0009E46C
	public void Init(AdventurerProfile adventurer, BuildingType type)
	{
		this._originalBgColor = base.GetComponent<Image>().color;
		this._profile = adventurer;
		this.UpdateLocation();
		this._lastWorkingBuilding = adventurer.WorkingBuilding;
		this.Avatar.sprite = Resources.Load<Sprite>(FilePath.GetAdventurerAvatar(adventurer.UnitClass));
	}

	// Token: 0x060012CB RID: 4811 RVA: 0x000A00BE File Offset: 0x0009E4BE
	public void ChangeBgColor()
	{
		base.GetComponent<Image>().color = Color.grey;
	}

	// Token: 0x060012CC RID: 4812 RVA: 0x000A00D0 File Offset: 0x0009E4D0
	public void ClearBgColor()
	{
		base.GetComponent<Image>().color = this._originalBgColor;
	}

	// Token: 0x060012CD RID: 4813 RVA: 0x000A00E3 File Offset: 0x0009E4E3
	private void Update()
	{
		if (this._lastWorkingBuilding != this._profile.WorkingBuilding)
		{
			this.UpdateLocation();
		}
	}

	// Token: 0x060012CE RID: 4814 RVA: 0x000A0104 File Offset: 0x0009E504
	public void UpdateLocation()
	{
		BuildingType buildingType = BuildingType.None;
		IBuildingProfile value = GameWorld.instance.PlayerProfile.Buildings.FirstOrDefault((KeyValuePair<TownSlot, IBuildingProfile> b) => b.Key == this._profile.WorkingBuilding).Value;
		if (value is ProductionBuildingProfile)
		{
			buildingType = (value as ProductionBuildingProfile).BuildingType;
		}
		if (buildingType != BuildingType.None)
		{
			this.Frame.gameObject.SetActive(true);
			this.LocationImage.sprite = FilePath.GetStoreIcon(buildingType);
			this._lastWorkingBuilding = this._profile.WorkingBuilding;
		}
		else
		{
			this.Frame.gameObject.SetActive(false);
			this._lastWorkingBuilding = (TownSlot)0;
		}
	}

	// Token: 0x060012CF RID: 4815 RVA: 0x000A01A9 File Offset: 0x0009E5A9
	[CompilerGenerated]
	private bool <UpdateLocation>m__0(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Key == this._profile.WorkingBuilding;
	}

	// Token: 0x04001373 RID: 4979
	public Image Avatar;

	// Token: 0x04001374 RID: 4980
	public Text Matery;

	// Token: 0x04001375 RID: 4981
	public Image Frame;

	// Token: 0x04001376 RID: 4982
	public Image LocationImage;

	// Token: 0x04001377 RID: 4983
	private AdventurerProfile _profile;

	// Token: 0x04001378 RID: 4984
	private TownSlot _lastWorkingBuilding;

	// Token: 0x04001379 RID: 4985
	private Color _originalBgColor;
}
