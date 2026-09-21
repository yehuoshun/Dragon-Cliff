using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000259 RID: 601
public class SchoolMenuController : MonoBehaviour
{
	// Token: 0x06000F95 RID: 3989 RVA: 0x0009543C File Offset: 0x0009383C
	public SchoolMenuController()
	{
	}

	// Token: 0x1700009D RID: 157
	// (get) Token: 0x06000F96 RID: 3990 RVA: 0x00095444 File Offset: 0x00093844
	// (set) Token: 0x06000F97 RID: 3991 RVA: 0x0009544C File Offset: 0x0009384C
	public School School
	{
		[CompilerGenerated]
		get
		{
			return this.<School>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<School>k__BackingField = value;
		}
	}

	// Token: 0x06000F98 RID: 3992 RVA: 0x00095455 File Offset: 0x00093855
	public void Init(School school, List<SkillType> newSkills)
	{
		this.School = school;
		this.UpdatePages(newSkills);
		this.OnMainSkill();
	}

	// Token: 0x06000F99 RID: 3993 RVA: 0x0009546B File Offset: 0x0009386B
	private void Start()
	{
		this.ToAdventurerPanel();
	}

	// Token: 0x06000F9A RID: 3994 RVA: 0x00095473 File Offset: 0x00093873
	private void OnEnable()
	{
		this.LevelPanel.UpdateLevel(this.School.GetLevel());
		this.ToAdventurerPanel();
	}

	// Token: 0x06000F9B RID: 3995 RVA: 0x00095491 File Offset: 0x00093891
	private void OnDisable()
	{
		this.MainSkillPage.DiselectAllSkill();
		this.SecondarySkillPage.DiselectAllSkill();
		this.ActiveSkillPage.DiselectAllSkill();
		this.ScrollResults.gameObject.SetActive(false);
	}

	// Token: 0x06000F9C RID: 3996 RVA: 0x000954C5 File Offset: 0x000938C5
	public void ToAdventurerPanel()
	{
		this.AdventurerPanel.SetActive(true);
		this.ScrollPanel.gameObject.SetActive(false);
		this.CreateScrollButton.interactable = true;
		this.SkillButton.interactable = false;
	}

	// Token: 0x06000F9D RID: 3997 RVA: 0x000954FC File Offset: 0x000938FC
	public void ToScrollPanel()
	{
		this.ScrollPanel.gameObject.SetActive(true);
		this.ScrollPanel.Init(this.School.GetCostForCombineScroll());
		this.AdventurerPanel.SetActive(false);
		this.CreateScrollButton.interactable = false;
		this.SkillButton.interactable = true;
	}

	// Token: 0x06000F9E RID: 3998 RVA: 0x00095554 File Offset: 0x00093954
	public void SwitchPanel()
	{
		if (this.AdventurerPanel.activeSelf)
		{
			this.ToScrollPanel();
		}
		else
		{
			this.ToAdventurerPanel();
		}
	}

	// Token: 0x06000F9F RID: 3999 RVA: 0x00095578 File Offset: 0x00093978
	public void CreateScroll()
	{
		List<Item> list = new List<Item>();
		for (int j = 0; j < this.ScrollPanel.CreateAmount; j++)
		{
			list.Add(this.School.CombineScroll());
		}
		list = (from r in list
		orderby r.IsStarItem() descending, r.Type
		select r).ToList<Item>();
		this.ScrollResults.Init((from i in list
		select new ResourceUpdate
		{
			ChangeAmount = 1.0,
			RelatedItems = new List<Item>
			{
				i
			},
			ResourceType = i.Type
		}).ToList<ResourceUpdate>());
		this.ScrollResults.gameObject.SetActive(true);
		this.ScrollPanel.Init(this.School.GetCostForCombineScroll());
	}

	// Token: 0x06000FA0 RID: 4000 RVA: 0x0009565D File Offset: 0x00093A5D
	public void CloseScrollResults()
	{
		this.ScrollResults.gameObject.SetActive(false);
	}

	// Token: 0x06000FA1 RID: 4001 RVA: 0x00095670 File Offset: 0x00093A70
	public string GetSkillUpgradeCostText(SkillType type)
	{
		int skillUpgradeCost = this.School.GetSkillUpgradeCost(type, ResourceType.Money);
		double money = GameWorld.instance.PlayerProfile.GetMoney();
		string text = skillUpgradeCost + "/" + money.DoubleToString();
		if ((double)skillUpgradeCost <= money)
		{
			text = ColorPicker.GetPositiveColoredString(text);
		}
		else
		{
			text = ColorPicker.GetNegativeColoredString(text);
		}
		return text;
	}

	// Token: 0x06000FA2 RID: 4002 RVA: 0x000956D4 File Offset: 0x00093AD4
	public string GetSkillUpgradeRequiredSchoolLevel(SkillType type)
	{
		int skillRequiredSchoolLevel = this.School.GetSkillRequiredSchoolLevel(type);
		string text = skillRequiredSchoolLevel.ToLevelText() + "/" + this.School.GetLevel().ToLevelText();
		if (skillRequiredSchoolLevel <= this.School.GetLevel())
		{
			text = ColorPicker.GetPositiveColoredString(text);
		}
		else
		{
			text = ColorPicker.GetNegativeColoredString(text);
		}
		return text;
	}

	// Token: 0x06000FA3 RID: 4003 RVA: 0x00095734 File Offset: 0x00093B34
	public string GetSkillUpgradeRequired(SkillType type, ResourceType resourceType)
	{
		int skillUpgradeCost = this.School.GetSkillUpgradeCost(type, resourceType);
		double resourceQuantity = GameWorld.instance.PlayerProfile.GetResourceQuantity(resourceType);
		string text = skillUpgradeCost + "/" + resourceQuantity.DoubleToString();
		if ((double)skillUpgradeCost <= resourceQuantity)
		{
			text = ColorPicker.GetPositiveColoredString(text);
		}
		else
		{
			text = ColorPicker.GetNegativeColoredString(text);
		}
		return text;
	}

	// Token: 0x06000FA4 RID: 4004 RVA: 0x00095793 File Offset: 0x00093B93
	public int GetSkillUpgradeCost(SkillType type, ResourceType resourceType)
	{
		return this.School.GetSkillUpgradeCost(type, resourceType);
	}

	// Token: 0x06000FA5 RID: 4005 RVA: 0x000957A4 File Offset: 0x00093BA4
	public string PreviewNextLevel(SkillType type)
	{
		Skill skill = this.School.PreviewNextLevel(type);
		if (skill != null)
		{
			return skill.GetDescription().Details1;
		}
		return string.Empty;
	}

	// Token: 0x06000FA6 RID: 4006 RVA: 0x000957D5 File Offset: 0x00093BD5
	public bool CanUpgradeSkill(SkillType type)
	{
		return this.School.CanUpgradeSkill(type);
	}

	// Token: 0x06000FA7 RID: 4007 RVA: 0x000957E4 File Offset: 0x00093BE4
	private void UpdatePages(List<SkillType> newSkills = null)
	{
		this.LevelPanel.UpdateLevel(this.School.GetLevel());
		if (newSkills != null)
		{
			bool active = false;
			bool active2 = false;
			bool active3 = false;
			foreach (SkillType type in newSkills)
			{
				SkillCommandType skillCommandType = type.GetSkillLogic().SkillCommandType;
				if (skillCommandType == SkillCommandType.Main)
				{
					active = true;
				}
				if (skillCommandType == SkillCommandType.Secondary)
				{
					active2 = true;
				}
				if (skillCommandType == SkillCommandType.Active)
				{
					active3 = true;
				}
			}
			this.MainNotifyDot.SetActive(active);
			this.SecondaryNotifyDot.SetActive(active2);
			this.ActiveNotifyDot.SetActive(active3);
		}
		this.MainSkillPage.UpdateItems((from p in this.School.GetAllSkillProfiles(new SkillCommandType?(SkillCommandType.Main))
		select this.GetFormattedPageSkill(p, newSkills)).Cast<PageElement>().ToList<PageElement>());
		this.SecondarySkillPage.UpdateItems((from p in this.School.GetAllSkillProfiles(new SkillCommandType?(SkillCommandType.Secondary))
		select this.GetFormattedPageSkill(p, newSkills)).Cast<PageElement>().ToList<PageElement>());
		this.ActiveSkillPage.UpdateItems((from p in this.School.GetAllSkillProfiles(new SkillCommandType?(SkillCommandType.Active))
		select this.GetFormattedPageSkill(p, newSkills)).Cast<PageElement>().ToList<PageElement>());
	}

	// Token: 0x06000FA8 RID: 4008 RVA: 0x0009596C File Offset: 0x00093D6C
	private PageSkill GetFormattedPageSkill(Skill skill, List<SkillType> newSkills = null)
	{
		return new PageSkill
		{
			Id = skill.SkillType.ToString(),
			SkillProfile = skill,
			IsNew = (newSkills != null && newSkills.Contains(skill.SkillType))
		};
	}

	// Token: 0x06000FA9 RID: 4009 RVA: 0x000959B9 File Offset: 0x00093DB9
	public void OnMainSkill()
	{
		this.ShowPage(SchoolMenuSkillType.Main);
		this.MainNotifyDot.SetActive(false);
	}

	// Token: 0x06000FAA RID: 4010 RVA: 0x000959CE File Offset: 0x00093DCE
	public void OnSecondarySkill()
	{
		this.ShowPage(SchoolMenuSkillType.Secondary);
		this.SecondaryNotifyDot.SetActive(false);
	}

	// Token: 0x06000FAB RID: 4011 RVA: 0x000959E3 File Offset: 0x00093DE3
	public void OnActiveSkill()
	{
		this.ShowPage(SchoolMenuSkillType.Active);
		this.ActiveNotifyDot.SetActive(false);
	}

	// Token: 0x06000FAC RID: 4012 RVA: 0x000959F8 File Offset: 0x00093DF8
	private void ShowPage(SchoolMenuSkillType type)
	{
		this.MainSkillPage.gameObject.SetActive(type == SchoolMenuSkillType.Main);
		this.SecondarySkillPage.gameObject.SetActive(type == SchoolMenuSkillType.Secondary);
		this.ActiveSkillPage.gameObject.SetActive(type == SchoolMenuSkillType.Active);
		this.MainSkillButton.interactable = (type != SchoolMenuSkillType.Main);
		this.SecondarySkillButton.interactable = (type != SchoolMenuSkillType.Secondary);
		this.ActiveSkillButton.interactable = (type != SchoolMenuSkillType.Active);
		this._selectedPage = type;
	}

	// Token: 0x06000FAD RID: 4013 RVA: 0x00095A80 File Offset: 0x00093E80
	public void SelectSkill(PageSkill pageSkill)
	{
		if (this._selectedSkill == pageSkill.SkillProfile)
		{
			return;
		}
		this._selectedSkill = pageSkill.SkillProfile;
		this.HeroPage.UpdateItems((from h in this.School.GetImpactedAdventurers(pageSkill.SkillProfile.SkillType)
		select new PageHero
		{
			Id = h.Id,
			AdventurerProfile = h
		}).Cast<PageElement>().ToList<PageElement>());
		this.MainSkillPage.DiselectAllSkill();
		this.SecondarySkillPage.DiselectAllSkill();
		this.ActiveSkillPage.DiselectAllSkill();
		this.MainSkillPage.DiselectAllElement();
		this.SecondarySkillPage.DiselectAllElement();
		this.ActiveSkillPage.DiselectAllElement();
		SchoolMenuSkillType selectedPage = this._selectedPage;
		if (selectedPage != SchoolMenuSkillType.Main)
		{
			if (selectedPage != SchoolMenuSkillType.Secondary)
			{
				if (selectedPage == SchoolMenuSkillType.Active)
				{
					this.ActiveSkillPage.SelectElement(pageSkill.Id);
				}
			}
			else
			{
				this.SecondarySkillPage.SelectElement(pageSkill.Id);
			}
		}
		else
		{
			this.MainSkillPage.SelectElement(pageSkill.Id);
		}
	}

	// Token: 0x06000FAE RID: 4014 RVA: 0x00095B9C File Offset: 0x00093F9C
	public void UpgradeSkill(Skill profile)
	{
		this.School.UpgradeSkill(profile.SkillType);
		this.ReturnToCurrentState();
	}

	// Token: 0x06000FAF RID: 4015 RVA: 0x00095BB5 File Offset: 0x00093FB5
	public float GetSkillPrice(SkillType type)
	{
		return (float)this.School.GetSkillUpgradeCost(type, ResourceType.Money);
	}

	// Token: 0x06000FB0 RID: 4016 RVA: 0x00095BC9 File Offset: 0x00093FC9
	public void UnlockSkill(Skill profile)
	{
	}

	// Token: 0x06000FB1 RID: 4017 RVA: 0x00095BCC File Offset: 0x00093FCC
	private void ReturnToCurrentState()
	{
		int currentPage = this.MainSkillPage.CurrentPage;
		int currentPage2 = this.SecondarySkillPage.CurrentPage;
		int currentPage3 = this.ActiveSkillPage.CurrentPage;
		this.UpdatePages(null);
		this.ShowPage(this._selectedPage);
		this.MainSkillPage.JumpToPage(currentPage);
		this.SecondarySkillPage.JumpToPage(currentPage2);
		this.ActiveSkillPage.JumpToPage(currentPage3);
	}

	// Token: 0x06000FB2 RID: 4018 RVA: 0x00095C34 File Offset: 0x00094034
	public bool CanPurchaseSkill(Skill profile)
	{
		return true;
	}

	// Token: 0x06000FB3 RID: 4019 RVA: 0x00095C37 File Offset: 0x00094037
	public bool CanUpgradeSkill(Skill profile)
	{
		return this.School.CanUpgradeSkill(profile.SkillType);
	}

	// Token: 0x06000FB4 RID: 4020 RVA: 0x00095C4A File Offset: 0x0009404A
	public int GetSkillMaxLevel(Skill profile)
	{
		return this.School.GetSkillMaxLevel(profile.SkillType);
	}

	// Token: 0x06000FB5 RID: 4021 RVA: 0x00095C5D File Offset: 0x0009405D
	[CompilerGenerated]
	private static bool <CreateScroll>m__0(Item r)
	{
		return r.IsStarItem();
	}

	// Token: 0x06000FB6 RID: 4022 RVA: 0x00095C65 File Offset: 0x00094065
	[CompilerGenerated]
	private static ResourceType <CreateScroll>m__1(Item r)
	{
		return r.Type;
	}

	// Token: 0x06000FB7 RID: 4023 RVA: 0x00095C70 File Offset: 0x00094070
	[CompilerGenerated]
	private static ResourceUpdate <CreateScroll>m__2(Item i)
	{
		return new ResourceUpdate
		{
			ChangeAmount = 1.0,
			RelatedItems = new List<Item>
			{
				i
			},
			ResourceType = i.Type
		};
	}

	// Token: 0x06000FB8 RID: 4024 RVA: 0x00095CB4 File Offset: 0x000940B4
	[CompilerGenerated]
	private static PageHero <SelectSkill>m__3(AdventurerProfile h)
	{
		return new PageHero
		{
			Id = h.Id,
			AdventurerProfile = h
		};
	}

	// Token: 0x040010DB RID: 4315
	public SkillPaginationController MainSkillPage;

	// Token: 0x040010DC RID: 4316
	public SkillPaginationController SecondarySkillPage;

	// Token: 0x040010DD RID: 4317
	public SkillPaginationController ActiveSkillPage;

	// Token: 0x040010DE RID: 4318
	public Button MainSkillButton;

	// Token: 0x040010DF RID: 4319
	public Button SecondarySkillButton;

	// Token: 0x040010E0 RID: 4320
	public Button ActiveSkillButton;

	// Token: 0x040010E1 RID: 4321
	public GameObject MainNotifyDot;

	// Token: 0x040010E2 RID: 4322
	public GameObject SecondaryNotifyDot;

	// Token: 0x040010E3 RID: 4323
	public GameObject ActiveNotifyDot;

	// Token: 0x040010E4 RID: 4324
	public HeroPaginationController HeroPage;

	// Token: 0x040010E5 RID: 4325
	public BuildingLevelPanelController LevelPanel;

	// Token: 0x040010E6 RID: 4326
	public SchoolCreateScrollPanelController ScrollPanel;

	// Token: 0x040010E7 RID: 4327
	public ShopPackOpenedPanelController ScrollResults;

	// Token: 0x040010E8 RID: 4328
	public GameObject AdventurerPanel;

	// Token: 0x040010E9 RID: 4329
	public Button SkillButton;

	// Token: 0x040010EA RID: 4330
	public Button CreateScrollButton;

	// Token: 0x040010EB RID: 4331
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private School <School>k__BackingField;

	// Token: 0x040010EC RID: 4332
	private Skill _selectedSkill;

	// Token: 0x040010ED RID: 4333
	private SchoolMenuSkillType _selectedPage;

	// Token: 0x040010EE RID: 4334
	[CompilerGenerated]
	private static Func<Item, bool> <>f__am$cache0;

	// Token: 0x040010EF RID: 4335
	[CompilerGenerated]
	private static Func<Item, ResourceType> <>f__am$cache1;

	// Token: 0x040010F0 RID: 4336
	[CompilerGenerated]
	private static Func<Item, ResourceUpdate> <>f__am$cache2;

	// Token: 0x040010F1 RID: 4337
	[CompilerGenerated]
	private static Func<AdventurerProfile, PageHero> <>f__am$cache3;

	// Token: 0x02000C54 RID: 3156
	[CompilerGenerated]
	private sealed class <UpdatePages>c__AnonStorey0
	{
		// Token: 0x060052A9 RID: 21161 RVA: 0x00095CDB File Offset: 0x000940DB
		public <UpdatePages>c__AnonStorey0()
		{
		}

		// Token: 0x060052AA RID: 21162 RVA: 0x00095CE3 File Offset: 0x000940E3
		internal PageSkill <>m__0(Skill p)
		{
			return this.$this.GetFormattedPageSkill(p, this.newSkills);
		}

		// Token: 0x060052AB RID: 21163 RVA: 0x00095CF7 File Offset: 0x000940F7
		internal PageSkill <>m__1(Skill p)
		{
			return this.$this.GetFormattedPageSkill(p, this.newSkills);
		}

		// Token: 0x060052AC RID: 21164 RVA: 0x00095D0B File Offset: 0x0009410B
		internal PageSkill <>m__2(Skill p)
		{
			return this.$this.GetFormattedPageSkill(p, this.newSkills);
		}

		// Token: 0x0400407A RID: 16506
		internal List<SkillType> newSkills;

		// Token: 0x0400407B RID: 16507
		internal SchoolMenuController $this;
	}
}
