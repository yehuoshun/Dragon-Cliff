using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002C9 RID: 713
public class QuickAssignmentController : MonoBehaviour
{
	// Token: 0x0600130E RID: 4878 RVA: 0x000A1361 File Offset: 0x0009F761
	public QuickAssignmentController()
	{
	}

	// Token: 0x0600130F RID: 4879 RVA: 0x000A136C File Offset: 0x0009F76C
	public void Init(List<AdventurerProfile> adventurers, ProductionBuildingProfile profile)
	{
		this.ResetList();
		this._profile = profile;
		this._inPageAdventurers = adventurers;
		TownSlot buildingSlot = GameWorld.instance.PlayerProfile.Buildings.FirstOrDefault((KeyValuePair<TownSlot, IBuildingProfile> b) => b.Value != null && b.Value.BuildingType == profile.BuildingType).Key;
		AdventurerProfile adventurerProfile = adventurers.Find((AdventurerProfile a) => a.WorkingBuilding == buildingSlot);
		List<AdventurerProfile> list = adventurers.Take(10).ToList<AdventurerProfile>();
		List<AdventurerProfile> list2 = new List<AdventurerProfile>();
		if (adventurerProfile != null && list.Contains(adventurerProfile))
		{
			list2.Add(adventurerProfile);
			list.Remove(adventurerProfile);
			list2.AddRange(list);
		}
		else if (adventurerProfile != null && !list.Contains(adventurerProfile))
		{
			list2.Add(adventurerProfile);
			list2.AddRange(list.Take(9));
		}
		else
		{
			list2.AddRange(list);
		}
		foreach (AdventurerProfile adventurer in list2)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.CharacterAvatarPre);
			gameObject.GetComponent<CharacterAvatarController>().Init(adventurer, profile.BuildingType);
			gameObject.transform.SetParent(this.AvatartList, false);
		}
	}

	// Token: 0x06001310 RID: 4880 RVA: 0x000A14DC File Offset: 0x0009F8DC
	private void ResetList()
	{
		IEnumerator enumerator = this.AvatartList.GetEnumerator();
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

	// Token: 0x06001311 RID: 4881 RVA: 0x000A1548 File Offset: 0x0009F948
	public void OpenConfirmPanel(string text)
	{
		this.ConfirmPanelText.text = text;
		this.ConfirmPanel.SetActive(true);
	}

	// Token: 0x06001312 RID: 4882 RVA: 0x000A1562 File Offset: 0x0009F962
	public void CloseConfirmPanel()
	{
		this.ConfirmPanel.SetActive(false);
	}

	// Token: 0x06001313 RID: 4883 RVA: 0x000A1570 File Offset: 0x0009F970
	public void ClearAvatarsBgColor()
	{
		IEnumerator enumerator = this.AvatartList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				transform.GetComponent<CharacterAvatarController>().ClearBgColor();
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

	// Token: 0x040013AC RID: 5036
	public GameObject CharacterAvatarPre;

	// Token: 0x040013AD RID: 5037
	public GameObject ConfirmPanel;

	// Token: 0x040013AE RID: 5038
	public Text ConfirmPanelText;

	// Token: 0x040013AF RID: 5039
	public Transform AvatartList;

	// Token: 0x040013B0 RID: 5040
	public ProductionBuildingProfile _profile;

	// Token: 0x040013B1 RID: 5041
	private AdventurerProfile _selectedAdventurer;

	// Token: 0x040013B2 RID: 5042
	private List<AdventurerProfile> _inPageAdventurers;

	// Token: 0x02000C6E RID: 3182
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x060052EA RID: 21226 RVA: 0x000A15DC File Offset: 0x0009F9DC
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x060052EB RID: 21227 RVA: 0x000A15E4 File Offset: 0x0009F9E4
		internal bool <>m__0(KeyValuePair<TownSlot, IBuildingProfile> b)
		{
			return b.Value != null && b.Value.BuildingType == this.profile.BuildingType;
		}

		// Token: 0x060052EC RID: 21228 RVA: 0x000A160E File Offset: 0x0009FA0E
		internal bool <>m__1(AdventurerProfile a)
		{
			return a.WorkingBuilding == this.buildingSlot;
		}

		// Token: 0x0400409E RID: 16542
		internal ProductionBuildingProfile profile;

		// Token: 0x0400409F RID: 16543
		internal TownSlot buildingSlot;
	}
}
