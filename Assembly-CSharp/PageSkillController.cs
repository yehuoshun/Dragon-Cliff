using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000255 RID: 597
public class PageSkillController : PageElementController, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, ISkillItemController, IEventSystemHandler
{
	// Token: 0x06000F7C RID: 3964 RVA: 0x00094A7E File Offset: 0x00092E7E
	public PageSkillController()
	{
	}

	// Token: 0x1700009C RID: 156
	// (get) Token: 0x06000F7D RID: 3965 RVA: 0x00094A86 File Offset: 0x00092E86
	// (set) Token: 0x06000F7E RID: 3966 RVA: 0x00094A8E File Offset: 0x00092E8E
	public PageSkill PageSkill
	{
		[CompilerGenerated]
		get
		{
			return this.<PageSkill>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<PageSkill>k__BackingField = value;
		}
	}

	// Token: 0x06000F7F RID: 3967 RVA: 0x00094A97 File Offset: 0x00092E97
	private void Awake()
	{
		this._schoolMenu = TownManager.Instance.Ui.SchoolMenu;
		this.UpgradeButton.interactable = false;
	}

	// Token: 0x06000F80 RID: 3968 RVA: 0x00094ABC File Offset: 0x00092EBC
	public override void Init(PageElement item)
	{
		this._schoolMenu = TownManager.Instance.Ui.SchoolMenu;
		base.PageElement = item;
		this.PageSkill = (item as PageSkill);
		this.SkillImage.sprite = FilePath.GetSkillIconImage(this.PageSkill.SkillProfile.SkillType);
		this.SkillName.text = this.PageSkill.SkillProfile.SkillType.GetDescription().Title;
		this.SkillLevel.gameObject.SetActive(true);
		this.SkillLevel.text = "Lv. " + this.PageSkill.SkillProfile.Level;
		this.NewText.SetActive(this.PageSkill.IsNew);
		this.UpgradeButton.interactable = this._schoolMenu.CanUpgradeSkill(this.PageSkill.SkillProfile);
		SkillLogicBase skillLogic = this.PageSkill.SkillProfile.SkillType.GetSkillLogic();
		this.SkillTargetingType.text = FilePath.GetTargetingTypeText(skillLogic.TargetingType);
		this.SkillCategory.sprite = FilePath.GetSkillCategoryImage(skillLogic.SkillCategory);
		this.LevelBar.Init(this.PageSkill.SkillProfile.Level, this._schoolMenu.GetSkillMaxLevel(this.PageSkill.SkillProfile));
		this.Cover.SetActive(false);
	}

	// Token: 0x06000F81 RID: 3969 RVA: 0x00094C27 File Offset: 0x00093027
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.DisplayTooltip();
	}

	// Token: 0x06000F82 RID: 3970 RVA: 0x00094C30 File Offset: 0x00093030
	private void DisplayTooltip()
	{
		Skill skill = this.PageSkill.SkillProfile.SkillType.CreatePlayerSkill();
		TooltipItem skillItemTooltip = this.GetSkillItemTooltip(skill, false, null);
		string text = "\n";
		string value = this._schoolMenu.PreviewNextLevel(this.PageSkill.SkillProfile.SkillType);
		if (!string.IsNullOrEmpty(value))
		{
			text = text + "\n<b>" + UIComponentType.SchoolMenuSkillNextLevelTitle.GetName() + ": </b>\n";
			text += this._schoolMenu.PreviewNextLevel(this.PageSkill.SkillProfile.SkillType);
			text = ColorPicker.ReplaceSkillTag(text);
			text = ColorPicker.GetHaxString(ColorPicker.Grey, text);
		}
		text = text + "\n\n" + UIComponentType.SchoolMenuSkillUpgradeRequirementText.GetName();
		text = text + "\n" + UIComponentType.SchoolMenuSkillUpgradeRequiredMoney.GetName() + ": ";
		text += this._schoolMenu.GetSkillUpgradeCostText(this.PageSkill.SkillProfile.SkillType);
		text = text + "\n" + UIComponentType.SchoolMenuSkillUpgradeRequiredSchoolLevel.GetName() + ": ";
		text += this._schoolMenu.GetSkillUpgradeRequiredSchoolLevel(this.PageSkill.SkillProfile.SkillType);
		if (this._schoolMenu.GetSkillUpgradeCost(this.PageSkill.SkillProfile.SkillType, ResourceType.BookFragments) > 0)
		{
			text = text + "\n" + UIComponentType.SchoolMenuSkillUpgradeRequiredBookFragment.GetName() + ": ";
			text += this._schoolMenu.GetSkillUpgradeRequired(this.PageSkill.SkillProfile.SkillType, ResourceType.BookFragments);
		}
		if (this._schoolMenu.GetSkillUpgradeCost(this.PageSkill.SkillProfile.SkillType, ResourceType.PracticePoints) > 0)
		{
			text = text + "\n" + UIComponentType.SchoolMenuSkillUpgradeRequiredPracticePoint.GetName() + ": ";
			text += this._schoolMenu.GetSkillUpgradeRequired(this.PageSkill.SkillProfile.SkillType, ResourceType.PracticePoints);
		}
		TooltipItem tooltipItem = skillItemTooltip;
		tooltipItem.Description += text;
		skillItemTooltip.Position = base.transform.position + Vector3.right * base.GetComponent<RectTransform>().rect.width / 2f * base.GetComponentInParent<Canvas>().scaleFactor;
		this.OpenTooltip(skillItemTooltip, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000F83 RID: 3971 RVA: 0x00094EAD File Offset: 0x000932AD
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x06000F84 RID: 3972 RVA: 0x00094EB5 File Offset: 0x000932B5
	public void Deselect()
	{
	}

	// Token: 0x06000F85 RID: 3973 RVA: 0x00094EB7 File Offset: 0x000932B7
	public void OnPointerClick(PointerEventData eventData)
	{
		this._schoolMenu.SelectSkill(this.PageSkill);
		this.UpdateButtonState();
		this.NewText.SetActive(false);
	}

	// Token: 0x06000F86 RID: 3974 RVA: 0x00094EDC File Offset: 0x000932DC
	public void UpdateButtonState()
	{
		this.UpgradeButton.interactable = this._schoolMenu.CanUpgradeSkill(this.PageSkill.SkillProfile);
		this.SkillLevel.gameObject.SetActive(true);
	}

	// Token: 0x06000F87 RID: 3975 RVA: 0x00094F10 File Offset: 0x00093310
	public void UpdgradeSkill()
	{
		this._schoolMenu.UpgradeSkill(this.PageSkill.SkillProfile);
		this.DisplayTooltip();
		this.UpdateButtonState();
		this.LevelUpParticle.Play();
		this.LevelUpAnimator.SetTrigger("LevelUp");
	}

	// Token: 0x06000F88 RID: 3976 RVA: 0x00094F4F File Offset: 0x0009334F
	public void UnlockSkill()
	{
		this._schoolMenu.UnlockSkill(this.PageSkill.SkillProfile);
		this.DisplayTooltip();
		this.UpdateButtonState();
	}

	// Token: 0x040010BE RID: 4286
	public Image SkillImage;

	// Token: 0x040010BF RID: 4287
	public TextMeshProUGUI SkillName;

	// Token: 0x040010C0 RID: 4288
	public TextMeshProUGUI SkillLevel;

	// Token: 0x040010C1 RID: 4289
	public TextMeshProUGUI SkillTargetingType;

	// Token: 0x040010C2 RID: 4290
	public Image SkillCategory;

	// Token: 0x040010C3 RID: 4291
	public GameObject Cover;

	// Token: 0x040010C4 RID: 4292
	public Button UpgradeButton;

	// Token: 0x040010C5 RID: 4293
	public ParticleTransController LevelUpParticle;

	// Token: 0x040010C6 RID: 4294
	public Animator LevelUpAnimator;

	// Token: 0x040010C7 RID: 4295
	public LevelBarController LevelBar;

	// Token: 0x040010C8 RID: 4296
	public GameObject NewText;

	// Token: 0x040010C9 RID: 4297
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PageSkill <PageSkill>k__BackingField;

	// Token: 0x040010CA RID: 4298
	private SchoolMenuController _schoolMenu;
}
