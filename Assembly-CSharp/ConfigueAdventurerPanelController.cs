using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020002E6 RID: 742
public class ConfigueAdventurerPanelController : MonoBehaviour
{
	// Token: 0x060013B7 RID: 5047 RVA: 0x000A4639 File Offset: 0x000A2A39
	public ConfigueAdventurerPanelController()
	{
	}

	// Token: 0x060013B8 RID: 5048 RVA: 0x000A464C File Offset: 0x000A2A4C
	private void OnEnable()
	{
		this.UpdateAdventurerContainers();
	}

	// Token: 0x060013B9 RID: 5049 RVA: 0x000A4654 File Offset: 0x000A2A54
	public void UpdatePickedHeros()
	{
		if (GameWorld.instance.PlayerProfile.GetSelectedBattleTeam() == null)
		{
			this._pickedAdventurers = new List<AdventurerProfile>();
		}
		else
		{
			this._pickedAdventurers = new List<AdventurerProfile>();
			this._pickedAdventurers.AddRange(GameWorld.instance.PlayerProfile.GetSelectedBattleTeam().Adventurers);
		}
	}

	// Token: 0x060013BA RID: 5050 RVA: 0x000A46B0 File Offset: 0x000A2AB0
	public void UpdateHeroPage()
	{
		List<PageWorldMenuHero> list = (from a in GameWorld.instance.PlayerProfile.AdventurerProfiles
		select new PageWorldMenuHero
		{
			Id = a.Id,
			AdventurerProfile = a,
			Selected = false
		}).ToList<PageWorldMenuHero>();
		List<AdventurerProfile> list2 = new List<AdventurerProfile>();
		foreach (AdventurerProfile adventurerProfile in this._pickedAdventurers)
		{
			if (adventurerProfile == null || !GameWorld.instance.PlayerProfile.AdventurerProfiles.Contains(adventurerProfile))
			{
				list2.Add(adventurerProfile);
			}
		}
		foreach (AdventurerProfile item in list2)
		{
			this._pickedAdventurers.Remove(item);
		}
		foreach (PageWorldMenuHero pageWorldMenuHero in list)
		{
			pageWorldMenuHero.Selected = this._pickedAdventurers.Contains(pageWorldMenuHero.AdventurerProfile);
		}
		list = (from p in list
		orderby p.AdventurerProfile.GetLevel() descending, p.AdventurerProfile.Grade descending
		select p).ToList<PageWorldMenuHero>();
		this.HeroPage.UpdateItems(list.Cast<PageElement>().ToList<PageElement>());
	}

	// Token: 0x060013BB RID: 5051 RVA: 0x000A4874 File Offset: 0x000A2C74
	public void JumpToHeroPage(AdventurerProfile profile)
	{
		PageElement pageElement = this.HeroPage.PageElements.FirstOrDefault((PageElement i) => i.Id == profile.Id);
		if (pageElement != null)
		{
			int pageNumberOfItem = this.HeroPage.GetPageNumberOfItem(pageElement);
			this.HeroPage.JumpToPage(pageNumberOfItem - 1);
		}
		this.HeroPage.SelectElement(profile.Id);
		this.HeroDetails.Init(profile);
	}

	// Token: 0x060013BC RID: 5052 RVA: 0x000A48F3 File Offset: 0x000A2CF3
	public void SelectHero(PageHero selectedHero)
	{
		if (selectedHero == null)
		{
			return;
		}
		this.HeroPage.SelectElement(selectedHero);
		this.HeroDetails.Init(selectedHero.AdventurerProfile);
	}

	// Token: 0x060013BD RID: 5053 RVA: 0x000A491C File Offset: 0x000A2D1C
	public void PickHero(PageWorldMenuHero hero)
	{
		int num = (!GameWorld.instance.PlayerProfile.AdvancedTeamEnabled()) ? 3 : 5;
		if (this._pickedAdventurers.Count < num)
		{
			this._pickedAdventurers.Add(hero.AdventurerProfile);
			this.UpdateAdventurerContainers();
			this.UpdateHeroPage();
		}
		else
		{
			this.DisplayWarningText(UIComponentType.WorldMapSelectHeroPanelFullWarning.GetName());
		}
	}

	// Token: 0x060013BE RID: 5054 RVA: 0x000A4988 File Offset: 0x000A2D88
	public void UnpickHero(AdventurerProfile hero)
	{
		this._pickedAdventurers.Remove(hero);
		this.UpdateAdventurerContainers();
		this.UpdateHeroPage();
	}

	// Token: 0x060013BF RID: 5055 RVA: 0x000A49A3 File Offset: 0x000A2DA3
	public void UnpickAll()
	{
		this._pickedAdventurers.Clear();
		this.UpdateAdventurerContainers();
		this.UpdateHeroPage();
	}

	// Token: 0x060013C0 RID: 5056 RVA: 0x000A49BC File Offset: 0x000A2DBC
	public void UpdateAdventurerContainers()
	{
		foreach (WorldMapHeroAvatarController worldMapHeroAvatarController in this.AdventurerAvatars)
		{
			worldMapHeroAvatarController.Reset();
		}
		for (int i = 0; i < this._pickedAdventurers.Count; i++)
		{
			this.AdventurerAvatars[i].Init(this._pickedAdventurers[i], i);
		}
		bool active = GameWorld.instance.PlayerProfile.AdvancedTeamEnabled();
		this.AdventurerAvatars[3].gameObject.SetActive(active);
		this.AdventurerAvatars[4].gameObject.SetActive(active);
	}

	// Token: 0x060013C1 RID: 5057 RVA: 0x000A4A90 File Offset: 0x000A2E90
	public void DeselectHero()
	{
		this.HeroPage.DiselectAllElement();
	}

	// Token: 0x060013C2 RID: 5058 RVA: 0x000A4A9D File Offset: 0x000A2E9D
	public void MouseOverHero(PageHero selectedHero)
	{
		if (selectedHero == null)
		{
			return;
		}
		this.HeroDetails.Init(selectedHero.AdventurerProfile);
	}

	// Token: 0x060013C3 RID: 5059 RVA: 0x000A4AB7 File Offset: 0x000A2EB7
	public void MouseExitHero()
	{
		this.HeroDetails.Reset();
	}

	// Token: 0x060013C4 RID: 5060 RVA: 0x000A4AC4 File Offset: 0x000A2EC4
	public void Confirm()
	{
		this.HeroPage.DiselectAllElement();
		base.GetComponentInParent<WorldMapController>().PickHeros(this._pickedAdventurers);
	}

	// Token: 0x060013C5 RID: 5061 RVA: 0x000A4AE4 File Offset: 0x000A2EE4
	[CompilerGenerated]
	private static PageWorldMenuHero <UpdateHeroPage>m__0(AdventurerProfile a)
	{
		return new PageWorldMenuHero
		{
			Id = a.Id,
			AdventurerProfile = a,
			Selected = false
		};
	}

	// Token: 0x060013C6 RID: 5062 RVA: 0x000A4B12 File Offset: 0x000A2F12
	[CompilerGenerated]
	private static int <UpdateHeroPage>m__1(PageWorldMenuHero p)
	{
		return p.AdventurerProfile.GetLevel();
	}

	// Token: 0x060013C7 RID: 5063 RVA: 0x000A4B1F File Offset: 0x000A2F1F
	[CompilerGenerated]
	private static QualityGrade <UpdateHeroPage>m__2(PageWorldMenuHero p)
	{
		return p.AdventurerProfile.Grade;
	}

	// Token: 0x0400142E RID: 5166
	public HeroPaginationController HeroPage;

	// Token: 0x0400142F RID: 5167
	public WorldMapHeroDetailsController HeroDetails;

	// Token: 0x04001430 RID: 5168
	public List<WorldMapHeroAvatarController> AdventurerAvatars;

	// Token: 0x04001431 RID: 5169
	private List<AdventurerProfile> _pickedAdventurers = new List<AdventurerProfile>();

	// Token: 0x04001432 RID: 5170
	[CompilerGenerated]
	private static Func<AdventurerProfile, PageWorldMenuHero> <>f__am$cache0;

	// Token: 0x04001433 RID: 5171
	[CompilerGenerated]
	private static Func<PageWorldMenuHero, int> <>f__am$cache1;

	// Token: 0x04001434 RID: 5172
	[CompilerGenerated]
	private static Func<PageWorldMenuHero, QualityGrade> <>f__am$cache2;

	// Token: 0x02000C78 RID: 3192
	[CompilerGenerated]
	private sealed class <JumpToHeroPage>c__AnonStorey0
	{
		// Token: 0x06005300 RID: 21248 RVA: 0x000A4B2C File Offset: 0x000A2F2C
		public <JumpToHeroPage>c__AnonStorey0()
		{
		}

		// Token: 0x06005301 RID: 21249 RVA: 0x000A4B34 File Offset: 0x000A2F34
		internal bool <>m__0(PageElement i)
		{
			return i.Id == this.profile.Id;
		}

		// Token: 0x040040A9 RID: 16553
		internal AdventurerProfile profile;
	}
}
