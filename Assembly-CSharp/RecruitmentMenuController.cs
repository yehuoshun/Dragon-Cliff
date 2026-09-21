using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000285 RID: 645
public class RecruitmentMenuController : HeroManagementController
{
	// Token: 0x06001125 RID: 4389 RVA: 0x00099CCB File Offset: 0x000980CB
	public RecruitmentMenuController()
	{
	}

	// Token: 0x170000C1 RID: 193
	// (get) Token: 0x06001126 RID: 4390 RVA: 0x00099CD3 File Offset: 0x000980D3
	// (set) Token: 0x06001127 RID: 4391 RVA: 0x00099CEC File Offset: 0x000980EC
	public RecruitmentFacility Facility
	{
		get
		{
			return this._facility ?? UnityEngine.Object.FindObjectOfType<RecruitmentFacilityController>().Facility;
		}
		set
		{
			this._facility = value;
		}
	}

	// Token: 0x06001128 RID: 4392 RVA: 0x00099CF8 File Offset: 0x000980F8
	private void Awake()
	{
		this.InfoContent.SetActive(false);
		this.AutoHireAncientToggle.isOn = this.GetAdditionalData(UIAdditionalDataKey.AutoPickAncient, false);
		this.PowerCriteriaToggle.isOn = this.GetAdditionalData(UIAdditionalDataKey.AutoPickAncientPowerCriteria, false);
		this.AutoHireLegendaryToggle.isOn = this.GetAdditionalData(UIAdditionalDataKey.AutoPickLegendary, false);
		this.PowerCriteriaInput.text = this.GetAdditionalData(UIAdditionalDataKey.PickPowerCriteria, 1).ToString();
	}

	// Token: 0x06001129 RID: 4393 RVA: 0x00099D7B File Offset: 0x0009817B
	private void Update()
	{
		this.RefreshTime.text = UIComponentType.RecruitmentRefreshText.GetName().ReplaceToBuilder(UIComponentKey.RemainingDays, this.Facility.NumberOfDaysTillRefresh.ToString()).ToString();
	}

	// Token: 0x0600112A RID: 4394 RVA: 0x00099DB4 File Offset: 0x000981B4
	private void OnEnable()
	{
		RecruitmentFacilityController componentInChildren = TownManager.Instance.Slots.GetComponentInChildren<RecruitmentFacilityController>();
		if (componentInChildren != null)
		{
			componentInChildren.HideWidget();
		}
		this.SummonButton.interactable = this.Facility.CanGetNewAdventurer();
	}

	// Token: 0x0600112B RID: 4395 RVA: 0x00099DF9 File Offset: 0x000981F9
	private void OnDisable()
	{
		base.DeselectHero();
		this.InfoContent.SetActive(false);
	}

	// Token: 0x0600112C RID: 4396 RVA: 0x00099E10 File Offset: 0x00098210
	public bool CandidateExist(string id)
	{
		return this._currentAdventurers.Any((AdventurerProfile a) => a.Id == id);
	}

	// Token: 0x0600112D RID: 4397 RVA: 0x00099E44 File Offset: 0x00098244
	public override void UpdateHeroList(List<AdventurerProfile> adventurers)
	{
		this._currentAdventurers = adventurers;
		base.UpdateHeroList(adventurers);
		for (int i = 0; i < this.Heros.Count; i++)
		{
			if (adventurers.Count > i)
			{
				this.Heros[i].Init(adventurers[i]);
				this.Heros[i].gameObject.SetActive(true);
			}
			else
			{
				this.Heros[i].gameObject.SetActive(false);
			}
		}
		this.InfoContent.SetActive(false);
	}

	// Token: 0x0600112E RID: 4398 RVA: 0x00099EE0 File Offset: 0x000982E0
	public void Summon()
	{
		if (this.Facility.CanGetNewAdventurer())
		{
			this.Facility.RefreshNewAdventurer();
			this.InfoContent.SetActive(false);
		}
		this.OnMouseOverSummon(this.SummonButton.gameObject.transform.position);
	}

	// Token: 0x0600112F RID: 4399 RVA: 0x00099F2F File Offset: 0x0009832F
	public void PreClearHeros()
	{
		this.ClearHeroConfirmPanel.SetActive(true);
	}

	// Token: 0x06001130 RID: 4400 RVA: 0x00099F40 File Offset: 0x00098340
	public void ClearHeros()
	{
		this.Facility.ResetCandidates();
		this.UpdateHeroList((from c in this.Facility.Candidates
		select c.Profile).ToList<AdventurerProfile>());
		this.CloseClearHeroPanel();
	}

	// Token: 0x06001131 RID: 4401 RVA: 0x00099F96 File Offset: 0x00098396
	public void CloseClearHeroPanel()
	{
		this.ClearHeroConfirmPanel.SetActive(false);
	}

	// Token: 0x06001132 RID: 4402 RVA: 0x00099FA4 File Offset: 0x000983A4
	public void TryAutoHire(AdventurerProfile hero)
	{
		if (hero.Grade == QualityGrade.Ancient && this.GetAdditionalData(UIAdditionalDataKey.AutoPickAncient, false))
		{
			if (this.GetAdditionalData(UIAdditionalDataKey.AutoPickAncientPowerCriteria, false))
			{
				if (hero.GetRating() >= (double)this.GetAdditionalData(UIAdditionalDataKey.PickPowerCriteria, 1))
				{
					this.Hire(hero);
				}
			}
			else
			{
				this.Hire(hero);
			}
		}
		if (hero.Grade == QualityGrade.Legendary && this.GetAdditionalData(UIAdditionalDataKey.AutoPickLegendary, false))
		{
			this.Hire(hero);
		}
	}

	// Token: 0x06001133 RID: 4403 RVA: 0x0009A030 File Offset: 0x00098430
	public void ToggleAutoHireAncient()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.AutoPickAncient, this.AutoHireAncientToggle.isOn);
		this.PowerCriteriaToggle.gameObject.SetActive(this.AutoHireAncientToggle.isOn);
	}

	// Token: 0x06001134 RID: 4404 RVA: 0x0009A07C File Offset: 0x0009847C
	public void ToggleAutoHireLegendary()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.AutoPickLegendary, this.AutoHireLegendaryToggle.isOn);
	}

	// Token: 0x06001135 RID: 4405 RVA: 0x0009A0A2 File Offset: 0x000984A2
	public void TogglePowerCriteria()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.AutoPickAncientPowerCriteria, this.PowerCriteriaToggle.isOn);
	}

	// Token: 0x06001136 RID: 4406 RVA: 0x0009A0C8 File Offset: 0x000984C8
	public void SetPowerCriteria()
	{
		int value = this.GetAdditionalData(UIAdditionalDataKey.PickPowerCriteria, 1);
		Regex regex = new Regex("^[1-9]\\d*$");
		if (regex.IsMatch(this.PowerCriteriaInput.text))
		{
			int num;
			if (string.IsNullOrEmpty(this.PowerCriteriaInput.text))
			{
				num = 1;
			}
			else
			{
				int.TryParse(this.PowerCriteriaInput.text, out num);
			}
			if (num >= 1 && num <= 404)
			{
				value = num;
			}
			if (num > 404)
			{
				value = 404;
			}
		}
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.PickPowerCriteria, value);
		this.PowerCriteriaInput.text = value.ToString();
	}

	// Token: 0x06001137 RID: 4407 RVA: 0x0009A18C File Offset: 0x0009858C
	public void OnMouseOverSummon(Vector3 position)
	{
		this.OpenTooltip(new TooltipItem
		{
			Title = UIComponentType.RecruitmentSummonButtonTooltipTitle.GetName(),
			Description = string.Concat(new object[]
			{
				UIComponentType.RecruitmentSummonButtonTooltipDescription.GetName().ReplaceToBuilder(UIComponentKey.Amount, ColorPicker.GetPosNegColor(this.Facility.CanGetNewAdventurer(), this.Facility.GetRollPointsRequired().ToString())),
				"\n\n",
				UIComponentType.RemainingPracticePointTitle.GetName(),
				": ",
				GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.PracticePoints).DoubleToString()
			}),
			Position = position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06001138 RID: 4408 RVA: 0x0009A254 File Offset: 0x00098654
	public void Hire()
	{
		PageHero selectedHero = TownManager.Instance.Ui.RecruitmentMenu.SelectedHero;
		if (selectedHero == null)
		{
			return;
		}
		this.Hire(selectedHero.AdventurerProfile);
		base.DeselectHero();
		this.InfoContent.SetActive(false);
	}

	// Token: 0x06001139 RID: 4409 RVA: 0x0009A29C File Offset: 0x0009869C
	public void Hire(AdventurerProfile hero)
	{
		if (hero == null)
		{
			return;
		}
		if (!this.Facility.HaveEnoughMoneyToPurchase(hero))
		{
			this.DisplayWarningText(UIComponentType.NotEnoughMoney.GetName());
			return;
		}
		if (GameWorld.instance.PlayerProfile.AdventurerProfiles.Count >= GameWorld.instance.PlayerProfile.GetMaxNumberOfAdventurers())
		{
			this.DisplayWarningText(UIComponentType.RecruitmentMenuReachMaxNumberOfAdventurers.GetName());
			return;
		}
		this.Facility.Purchase(hero);
	}

	// Token: 0x0600113A RID: 4410 RVA: 0x0009A318 File Offset: 0x00098718
	public override void SelectHero(PageHero hero)
	{
		base.SelectedHero = hero;
		this.HeroPriceText.text = this.Facility.GetCandidatePrice(base.SelectedHero.AdventurerProfile).ToGameCurrency();
		this.HeroPage.SelectElement(base.SelectedHero);
		if (this.HeroInfo != null)
		{
			this.HeroInfo.UpdateInfo(hero.AdventurerProfile, null);
		}
		if (!this.InfoContent.activeSelf)
		{
			this.InfoContent.SetActive(true);
		}
	}

	// Token: 0x0600113B RID: 4411 RVA: 0x0009A3A2 File Offset: 0x000987A2
	[CompilerGenerated]
	private static AdventurerProfile <ClearHeros>m__0(AdventurerCandidate c)
	{
		return c.Profile;
	}

	// Token: 0x0400120F RID: 4623
	public TextMeshProUGUI HeroPriceText;

	// Token: 0x04001210 RID: 4624
	public TextMeshProUGUI RefreshTime;

	// Token: 0x04001211 RID: 4625
	public GameObject InfoContent;

	// Token: 0x04001212 RID: 4626
	public Button SummonButton;

	// Token: 0x04001213 RID: 4627
	public Toggle AutoHireAncientToggle;

	// Token: 0x04001214 RID: 4628
	public Toggle AutoHireLegendaryToggle;

	// Token: 0x04001215 RID: 4629
	public Toggle PowerCriteriaToggle;

	// Token: 0x04001216 RID: 4630
	public TMP_InputField PowerCriteriaInput;

	// Token: 0x04001217 RID: 4631
	public GameObject ClearHeroConfirmPanel;

	// Token: 0x04001218 RID: 4632
	public List<MenuMovingHeroController> Heros;

	// Token: 0x04001219 RID: 4633
	private List<AdventurerProfile> _currentAdventurers;

	// Token: 0x0400121A RID: 4634
	private RecruitmentFacility _facility;

	// Token: 0x0400121B RID: 4635
	[CompilerGenerated]
	private static Func<AdventurerCandidate, AdventurerProfile> <>f__am$cache0;

	// Token: 0x02000C61 RID: 3169
	[CompilerGenerated]
	private sealed class <CandidateExist>c__AnonStorey0
	{
		// Token: 0x060052CB RID: 21195 RVA: 0x0009A3AA File Offset: 0x000987AA
		public <CandidateExist>c__AnonStorey0()
		{
		}

		// Token: 0x060052CC RID: 21196 RVA: 0x0009A3B2 File Offset: 0x000987B2
		internal bool <>m__0(AdventurerProfile a)
		{
			return a.Id == this.id;
		}

		// Token: 0x0400408D RID: 16525
		internal string id;
	}
}
