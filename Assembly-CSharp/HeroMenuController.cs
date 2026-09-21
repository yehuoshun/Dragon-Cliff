using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020001C0 RID: 448
public class HeroMenuController : HeroManagementController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000BD2 RID: 3026 RVA: 0x0008741F File Offset: 0x0008581F
	public HeroMenuController()
	{
	}

	// Token: 0x06000BD3 RID: 3027 RVA: 0x00087428 File Offset: 0x00085828
	private void Start()
	{
		this.HeroInfo.ClearOldData();
		TMP_Dropdown dropdown = this.HeroOrderDropdown.GetComponent<TMP_Dropdown>();
		dropdown.onValueChanged.AddListener(delegate(int A_1)
		{
			GameWorld.instance.PlayerProfile.AdventurerOrderType = this.HeroOrderDropdown.DropdownValues.Single((HeroOrderTypeDropdownValue d) => d.Value == dropdown.value).Type;
			this.HeroOrderDropdown.Init();
			this.UpdateHeroList(GameWorld.instance.PlayerProfile.AdventurerProfiles);
		});
	}

	// Token: 0x06000BD4 RID: 3028 RVA: 0x0008747A File Offset: 0x0008587A
	private void OnEnable()
	{
		this.Init();
	}

	// Token: 0x06000BD5 RID: 3029 RVA: 0x00087482 File Offset: 0x00085882
	public override void UpdateHeroList(List<AdventurerProfile> adventurers)
	{
		adventurers = base.OrderHeroList(adventurers);
		base.UpdateHeroList(adventurers);
	}

	// Token: 0x06000BD6 RID: 3030 RVA: 0x00087494 File Offset: 0x00085894
	public override void Init()
	{
		base.Init();
		if (base.SelectedHero == null)
		{
			return;
		}
		this.UpdateHeroLevelUpPanel();
	}

	// Token: 0x06000BD7 RID: 3031 RVA: 0x000874AE File Offset: 0x000858AE
	private void OnDisable()
	{
		this.ImiHideSlidePanel();
		this.ChooseCardPanel.gameObject.SetActive(false);
		this.SkillPanel.gameObject.SetActive(false);
		this.FireComfirmPanel.SetActive(false);
	}

	// Token: 0x06000BD8 RID: 3032 RVA: 0x000874E4 File Offset: 0x000858E4
	private void Update()
	{
		PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
		this.LevelUpPoints.text = playerProfile.GetResourceQuantity(ResourceType.PracticePoints).ToString("N0");
		this.InventoryCapasityText.text = playerProfile.Items.Count + "/" + PlayerProfile.InventoryCapacity;
		this.InventoryCapasityText.color = ((!playerProfile.IsInventoryFull()) ? ColorPicker.PositiveGreen : ColorPicker.NagetiveRed);
		int count = playerProfile.AdventurerProfiles.Count;
		int maxNumberOfAdventurers = playerProfile.GetMaxNumberOfAdventurers();
		this.NumberOfHeros.text = count + "/" + maxNumberOfAdventurers;
		this.NumberOfHeros.color = ((maxNumberOfAdventurers > count) ? Color.white : ColorPicker.NagetiveRed);
		if (base.SelectedHero != null)
		{
			this.RemoveHeroButton.SetActive(!base.SelectedHero.AdventurerProfile.IsInBattle());
		}
	}

	// Token: 0x06000BD9 RID: 3033 RVA: 0x000875F1 File Offset: 0x000859F1
	public void PreSetHeroName()
	{
		if (base.SelectedHero == null)
		{
			return;
		}
		this.TitleInput.gameObject.SetActive(true);
		this.TitleInput.Init(base.SelectedHero.AdventurerProfile);
	}

	// Token: 0x06000BDA RID: 3034 RVA: 0x00087628 File Offset: 0x00085A28
	public void SetHeroName(string newName)
	{
		if (base.SelectedHero != null)
		{
			if (newName.Length <= 15)
			{
				base.SelectedHero.AdventurerProfile.SetUnitName(newName);
				base.UpdateCurrentHeroInfo();
				this.TitleInput.gameObject.SetActive(false);
			}
			else
			{
				this.DisplayWarningText(UIComponentType.HeroNameTooLongWarning.GetName());
			}
		}
	}

	// Token: 0x06000BDB RID: 3035 RVA: 0x0008768A File Offset: 0x00085A8A
	public void ReassignCard()
	{
		if (base.SelectedHero == null)
		{
			return;
		}
	}

	// Token: 0x06000BDC RID: 3036 RVA: 0x00087698 File Offset: 0x00085A98
	public void Equip(Item item)
	{
		base.SelectedHero.AdventurerProfile.Equip(item);
		base.UpdateCurrentHeroInfo();
	}

	// Token: 0x06000BDD RID: 3037 RVA: 0x000876B1 File Offset: 0x00085AB1
	public void Disrobe(Item item)
	{
		base.SelectedHero.AdventurerProfile.Disrobe(item, true);
	}

	// Token: 0x06000BDE RID: 3038 RVA: 0x000876C5 File Offset: 0x00085AC5
	public void CloseChooseCardPanel()
	{
		this.ChooseCardPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000BDF RID: 3039 RVA: 0x000876D8 File Offset: 0x00085AD8
	public void PreResetTalent()
	{
		if (base.SelectedHero == null)
		{
			return;
		}
		this.ResetTalentConfirmPanel.gameObject.SetActive(true);
		this.ResetTalentConfirmPanel.Init((double)base.SelectedHero.AdventurerProfile.GetTalentResetCost());
	}

	// Token: 0x06000BE0 RID: 3040 RVA: 0x00087714 File Offset: 0x00085B14
	public void ResetTalent()
	{
		if (base.SelectedHero != null)
		{
			if ((double)base.SelectedHero.AdventurerProfile.GetTalentResetCost() > GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.PracticePoints))
			{
				this.DisplayWarningText(UIComponentType.NotEnoughPracticePoint.GetName());
			}
			else
			{
				base.SelectedHero.AdventurerProfile.ResetTalent();
				this.UpdateTalentPanel();
				base.UpdateCurrentHeroInfo();
			}
		}
		this.ResetTalentConfirmPanel.ClosePanel();
	}

	// Token: 0x06000BE1 RID: 3041 RVA: 0x00087792 File Offset: 0x00085B92
	public void ToggleTalentCardPanel()
	{
		if (this._talentPanelOpened)
		{
			this.HideTalentPanel();
		}
		else
		{
			this.ShowTalentPanel();
		}
	}

	// Token: 0x06000BE2 RID: 3042 RVA: 0x000877B0 File Offset: 0x00085BB0
	public void ShowTalentPanel()
	{
		this.UpdateTalentPanel();
		if (!this._talentPanelOpened)
		{
			this.TalentPanel.GetComponent<Animator>().SetTrigger("Show");
		}
		this._talentPanelOpened = true;
		this.TalentButton.GetComponent<Image>().color = Color.grey;
		if (this._elementPanelOpened)
		{
			this.HideElementPanel();
		}
	}

	// Token: 0x06000BE3 RID: 3043 RVA: 0x00087810 File Offset: 0x00085C10
	public void HideTalentPanel()
	{
		this.TalentPanel.GetComponent<Animator>().SetTrigger("Hide");
		this._talentPanelOpened = false;
		this.TalentButton.GetComponent<Image>().color = Color.white;
	}

	// Token: 0x06000BE4 RID: 3044 RVA: 0x00087843 File Offset: 0x00085C43
	public void UpdateTalentPanel()
	{
		if (base.SelectedHero == null)
		{
			return;
		}
		this.TalentPanel.Init(base.SelectedHero.AdventurerProfile);
	}

	// Token: 0x06000BE5 RID: 3045 RVA: 0x00087867 File Offset: 0x00085C67
	public void ToggleElementPanel()
	{
		if (this._elementPanelOpened)
		{
			this.HideElementPanel();
		}
		else
		{
			this.ShowElementPanel();
		}
	}

	// Token: 0x06000BE6 RID: 3046 RVA: 0x00087888 File Offset: 0x00085C88
	public void ShowElementPanel()
	{
		this.ElementTexts.ForEach(delegate(ElementTextItemController e)
		{
			e.Init(base.SelectedHero.AdventurerProfile);
		});
		if (!this._elementPanelOpened)
		{
			this.ElementDetailsPanel.GetComponent<Animator>().SetTrigger("Show");
		}
		this._elementPanelOpened = true;
		this.ElementButton.GetComponent<Image>().color = Color.grey;
		if (this._talentPanelOpened)
		{
			this.HideTalentPanel();
		}
	}

	// Token: 0x06000BE7 RID: 3047 RVA: 0x000878F9 File Offset: 0x00085CF9
	public void HideElementPanel()
	{
		this.ElementDetailsPanel.GetComponent<Animator>().SetTrigger("Hide");
		this._elementPanelOpened = false;
		this.ElementButton.GetComponent<Image>().color = Color.white;
	}

	// Token: 0x06000BE8 RID: 3048 RVA: 0x0008792C File Offset: 0x00085D2C
	private void ImiHideSlidePanel()
	{
		this.ElementDetailsPanel.GetComponent<RectTransform>().pivot = new Vector2(2.1f, 0f);
		this.TalentPanel.GetComponent<RectTransform>().pivot = new Vector2(2.1f, 0f);
		this._elementPanelOpened = false;
		this._talentPanelOpened = false;
		this.ElementButton.GetComponent<Image>().color = Color.white;
		this.TalentButton.GetComponent<Image>().color = Color.white;
	}

	// Token: 0x06000BE9 RID: 3049 RVA: 0x000879AF File Offset: 0x00085DAF
	public void OpenSkillPanel()
	{
		this.SkillPanel.Init();
		this.SkillPanel.gameObject.SetActive(true);
	}

	// Token: 0x06000BEA RID: 3050 RVA: 0x000879CD File Offset: 0x00085DCD
	public void ChangeSecondSkill(Skill skill)
	{
		if (base.SelectedHero != null)
		{
			base.SelectedHero.AdventurerProfile.DirectlyEnableSkill(skill);
			this.InventoryPanel.UpdateSelectedHeroInfo();
			base.UpdateCurrentHeroInfo();
		}
		this.SkillPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000BEB RID: 3051 RVA: 0x00087A0D File Offset: 0x00085E0D
	public void DisorbEquipment()
	{
		this.DisorbEquipment(this._selectedSlot);
	}

	// Token: 0x06000BEC RID: 3052 RVA: 0x00087A1B File Offset: 0x00085E1B
	public void DisorbEquipment(UiSlotType item)
	{
		if (base.SelectedHero.AdventurerProfile.IsInBattle())
		{
			this.DisplayWarningText(UIComponentType.HeroMenuChangeEquipInBattleWarning.GetName());
		}
		else
		{
			this.InventoryPanel.Disrobe(item);
		}
	}

	// Token: 0x06000BED RID: 3053 RVA: 0x00087A54 File Offset: 0x00085E54
	public override void SelectHero(PageHero hero)
	{
		base.SelectHero(hero);
		this.TitleInput.gameObject.SetActive(false);
		this.InventoryPanel.UpdateSelectedHeroInfo();
		this.UpdateButtonStatus();
		if (this._elementPanelOpened)
		{
			this.ShowElementPanel();
		}
		if (this._talentPanelOpened)
		{
			this.ShowTalentPanel();
		}
	}

	// Token: 0x06000BEE RID: 3054 RVA: 0x00087AAC File Offset: 0x00085EAC
	public void FireHeroPreComfirm()
	{
		this.FireComfirmPanel.SetActive(true);
	}

	// Token: 0x06000BEF RID: 3055 RVA: 0x00087ABA File Offset: 0x00085EBA
	public void CloseFireComfirmPanel()
	{
		this.FireComfirmPanel.SetActive(false);
	}

	// Token: 0x06000BF0 RID: 3056 RVA: 0x00087AC8 File Offset: 0x00085EC8
	public void FireHero()
	{
		if (base.SelectedHero == null)
		{
			return;
		}
		if (GameWorld.instance.PlayerProfile.AdventurerProfiles.Count <= 1)
		{
			this.DisplayWarningText(UIComponentType.HeroMenuLastAdventurerWarning.GetName());
		}
		else
		{
			List<ITraveller> currentTravellers = GameWorld.instance.PlayerProfile.GetCurrentTravellers();
			if (currentTravellers.Any((ITraveller t) => t is AdventurerProfile && ((AdventurerProfile)t).Id == base.SelectedHero.AdventurerProfile.Id))
			{
				this.DisplayWarningText(UIComponentType.HeroMenuFireHeroOnTripWarning.GetName());
			}
			else
			{
				GameWorld.instance.PlayerProfile.RemoveFiredTraveller(base.SelectedHero.AdventurerProfile);
				GameWorld.instance.PlayerProfile.ReleaseAdventurer(base.SelectedHero.AdventurerProfile);
				this.Init();
			}
		}
		this.CloseFireComfirmPanel();
		this.InventoryPanel.UpdateSelectedHeroInfo();
		TownManager.Instance.Ui.WorldMap.UpdateHeroPanel();
	}

	// Token: 0x06000BF1 RID: 3057 RVA: 0x00087BAB File Offset: 0x00085FAB
	public void UpdateHeroLevelUpPanel()
	{
		base.UpdateCurrentHeroInfo();
		this.UpdateButtonStatus();
	}

	// Token: 0x06000BF2 RID: 3058 RVA: 0x00087BBC File Offset: 0x00085FBC
	private void UpdateButtonStatus()
	{
		this.FireButton.interactable = (GameWorld.instance.PlayerProfile.AdventurerProfiles.Count > 1);
		bool interactable = base.SelectedHero.AdventurerProfile.CanUpgradeLevel();
		this.LevelUpButton.interactable = interactable;
		this.LevelTenUpButton.interactable = interactable;
		this.HeroInfo.ShowCanLevelUpFrame();
		if (base.SelectedHero != null)
		{
			AdventurerProfile profile = base.SelectedHero.AdventurerProfile;
			this.TalentLight.SetActive(profile.Talents.Any((IAdventurerTalent t) => t.IsAvaliable(profile) && t.CostMet(profile)));
		}
	}

	// Token: 0x06000BF3 RID: 3059 RVA: 0x00087C68 File Offset: 0x00086068
	public void SelectCard(CardUpgrade card)
	{
		base.UpdateCurrentHeroInfo();
		this.UpdateButtonStatus();
	}

	// Token: 0x06000BF4 RID: 3060 RVA: 0x00087C78 File Offset: 0x00086078
	public void UpgradeTalent(IAdventurerTalent talent)
	{
		if (base.SelectedHero == null)
		{
			return;
		}
		if (talent.IsAvaliable(base.SelectedHero.AdventurerProfile))
		{
			talent.Upgrade(base.SelectedHero.AdventurerProfile);
			this.TalentPanel.Init(base.SelectedHero.AdventurerProfile);
			this.UpdateHeroLevelUpPanel();
		}
	}

	// Token: 0x06000BF5 RID: 3061 RVA: 0x00087CD4 File Offset: 0x000860D4
	public void HeroTenLevelUp()
	{
		base.SelectedHero.AdventurerProfile.TryUpgrade10Level();
		this.LevelUpParticle.Play();
		this.UpdateButtonStatus();
		if (this._elementPanelOpened)
		{
			this.ElementTexts.ForEach(delegate(ElementTextItemController e)
			{
				e.Init(base.SelectedHero.AdventurerProfile);
			});
		}
		if (this._talentPanelOpened)
		{
			this.UpdateTalentPanel();
		}
		base.UpdateCurrentHeroInfo();
	}

	// Token: 0x06000BF6 RID: 3062 RVA: 0x00087D3C File Offset: 0x0008613C
	public void HeroLevelUp()
	{
		base.SelectedHero.AdventurerProfile.UpgradeLevel();
		this.LevelUpParticle.Play();
		this.DisplayLevelUpTooltip();
		this.UpdateButtonStatus();
		if (this._elementPanelOpened)
		{
			this.ElementTexts.ForEach(delegate(ElementTextItemController e)
			{
				e.Init(base.SelectedHero.AdventurerProfile);
			});
		}
		if (this._talentPanelOpened)
		{
			this.UpdateTalentPanel();
		}
	}

	// Token: 0x06000BF7 RID: 3063 RVA: 0x00087DA3 File Offset: 0x000861A3
	private void ShowChooseCardPanel(List<CardUpgrade> cards)
	{
		this.ChooseCardPanel.gameObject.SetActive(true);
		this.ChooseCardPanel.Init(cards);
	}

	// Token: 0x06000BF8 RID: 3064 RVA: 0x00087DC2 File Offset: 0x000861C2
	public void HeroUpgradeStage()
	{
		this.UpgradeParticle.Play();
		this.UpdateHeroLevelUpPanel();
	}

	// Token: 0x06000BF9 RID: 3065 RVA: 0x00087DD8 File Offset: 0x000861D8
	public void DisplayLevelUpTooltip()
	{
		if (base.SelectedHero == null)
		{
			return;
		}
		string text = string.Empty;
		if (base.SelectedHero.AdventurerProfile.GetLevel() < UnitExtensions.MaxAdventurerLevel)
		{
			double resourceQuantity = GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.PracticePoints);
			int levelUpRequiredExp = base.SelectedHero.AdventurerProfile.GetLevelUpRequiredExp();
			if (resourceQuantity >= (double)levelUpRequiredExp)
			{
				text = ColorPicker.GetPositiveColoredString(levelUpRequiredExp.ToString());
			}
			else
			{
				text = ColorPicker.GetNegativeColoredString(levelUpRequiredExp.ToString());
			}
			text = UIComponentType.HeroMenuNextLevelExpRequiredTitle.GetName() + ": " + text;
		}
		else
		{
			text = UIComponentType.HeroMenuReachedMaxLevelNotice.GetName();
		}
		this.OpenTooltip(new TooltipItem
		{
			Title = UIComponentType.HeroMenuLevelUpRequirementTitle.GetName(),
			Position = this.LevelUpButton.transform.position,
			Description = text
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000BFA RID: 3066 RVA: 0x00087ED6 File Offset: 0x000862D6
	public void ShutTooltip()
	{
		this.CloseTooltip();
	}

	// Token: 0x06000BFB RID: 3067 RVA: 0x00087EDE File Offset: 0x000862DE
	public void OnPointerClick(PointerEventData eventData)
	{
		this.InventoryPanel.ResetInventoryPanel();
		this.TitleInput.gameObject.SetActive(false);
	}

	// Token: 0x06000BFC RID: 3068 RVA: 0x00087EFC File Offset: 0x000862FC
	[CompilerGenerated]
	private void <ShowElementPanel>m__0(ElementTextItemController e)
	{
		e.Init(base.SelectedHero.AdventurerProfile);
	}

	// Token: 0x06000BFD RID: 3069 RVA: 0x00087F0F File Offset: 0x0008630F
	[CompilerGenerated]
	private bool <FireHero>m__1(ITraveller t)
	{
		return t is AdventurerProfile && ((AdventurerProfile)t).Id == base.SelectedHero.AdventurerProfile.Id;
	}

	// Token: 0x06000BFE RID: 3070 RVA: 0x00087F3F File Offset: 0x0008633F
	[CompilerGenerated]
	private void <HeroTenLevelUp>m__2(ElementTextItemController e)
	{
		e.Init(base.SelectedHero.AdventurerProfile);
	}

	// Token: 0x06000BFF RID: 3071 RVA: 0x00087F52 File Offset: 0x00086352
	[CompilerGenerated]
	private void <HeroLevelUp>m__3(ElementTextItemController e)
	{
		e.Init(base.SelectedHero.AdventurerProfile);
	}

	// Token: 0x04000E44 RID: 3652
	public InventoryMenuController InventoryPanel;

	// Token: 0x04000E45 RID: 3653
	public ChooseCardPanelController ChooseCardPanel;

	// Token: 0x04000E46 RID: 3654
	public Button LevelUpButton;

	// Token: 0x04000E47 RID: 3655
	public Button LevelTenUpButton;

	// Token: 0x04000E48 RID: 3656
	public Button ElementButton;

	// Token: 0x04000E49 RID: 3657
	public Button TalentButton;

	// Token: 0x04000E4A RID: 3658
	public Button UpgradeButton;

	// Token: 0x04000E4B RID: 3659
	public Button FireButton;

	// Token: 0x04000E4C RID: 3660
	public GameObject CardLight;

	// Token: 0x04000E4D RID: 3661
	public GameObject TalentLight;

	// Token: 0x04000E4E RID: 3662
	public GameObject ElementDetailsPanel;

	// Token: 0x04000E4F RID: 3663
	public TextMeshProUGUI NumberOfHeros;

	// Token: 0x04000E50 RID: 3664
	public TextMeshProUGUI LevelUpPoints;

	// Token: 0x04000E51 RID: 3665
	public TextMeshProUGUI InventoryCapasityText;

	// Token: 0x04000E52 RID: 3666
	public ParticleTransController LevelUpParticle;

	// Token: 0x04000E53 RID: 3667
	public ParticleTransController UpgradeParticle;

	// Token: 0x04000E54 RID: 3668
	public HeroDropdownController HeroOrderDropdown;

	// Token: 0x04000E55 RID: 3669
	public HeroSkillPanelController SkillPanel;

	// Token: 0x04000E56 RID: 3670
	public TalentPointPanelController TalentPanel;

	// Token: 0x04000E57 RID: 3671
	public ResetTalentConfirmPanelController ResetTalentConfirmPanel;

	// Token: 0x04000E58 RID: 3672
	public TitleInputController TitleInput;

	// Token: 0x04000E59 RID: 3673
	public GameObject FireComfirmPanel;

	// Token: 0x04000E5A RID: 3674
	public GameObject RemoveHeroButton;

	// Token: 0x04000E5B RID: 3675
	public List<ElementTextItemController> ElementTexts;

	// Token: 0x04000E5C RID: 3676
	private UiSlotType _selectedSlot;

	// Token: 0x04000E5D RID: 3677
	private bool _elementPanelOpened;

	// Token: 0x04000E5E RID: 3678
	private bool _talentPanelOpened;

	// Token: 0x02000C31 RID: 3121
	[CompilerGenerated]
	private sealed class <Start>c__AnonStorey0
	{
		// Token: 0x0600523A RID: 21050 RVA: 0x00087F65 File Offset: 0x00086365
		public <Start>c__AnonStorey0()
		{
		}

		// Token: 0x0600523B RID: 21051 RVA: 0x00087F70 File Offset: 0x00086370
		internal void <>m__0(int A_1)
		{
			GameWorld.instance.PlayerProfile.AdventurerOrderType = this.$this.HeroOrderDropdown.DropdownValues.Single((HeroOrderTypeDropdownValue d) => d.Value == this.dropdown.value).Type;
			this.$this.HeroOrderDropdown.Init();
			this.$this.UpdateHeroList(GameWorld.instance.PlayerProfile.AdventurerProfiles);
		}

		// Token: 0x0600523C RID: 21052 RVA: 0x00087FDC File Offset: 0x000863DC
		internal bool <>m__1(HeroOrderTypeDropdownValue d)
		{
			return d.Value == this.dropdown.value;
		}

		// Token: 0x04004039 RID: 16441
		internal TMP_Dropdown dropdown;

		// Token: 0x0400403A RID: 16442
		internal HeroMenuController $this;
	}

	// Token: 0x02000C32 RID: 3122
	[CompilerGenerated]
	private sealed class <UpdateButtonStatus>c__AnonStorey1
	{
		// Token: 0x0600523D RID: 21053 RVA: 0x00087FF1 File Offset: 0x000863F1
		public <UpdateButtonStatus>c__AnonStorey1()
		{
		}

		// Token: 0x0600523E RID: 21054 RVA: 0x00087FF9 File Offset: 0x000863F9
		internal bool <>m__0(IAdventurerTalent t)
		{
			return t.IsAvaliable(this.profile) && t.CostMet(this.profile);
		}

		// Token: 0x0400403B RID: 16443
		internal AdventurerProfile profile;
	}
}
