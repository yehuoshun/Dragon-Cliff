using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200028F RID: 655
public class SkillIconController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISkillItemController, IEventSystemHandler
{
	// Token: 0x06001180 RID: 4480 RVA: 0x0009B766 File Offset: 0x00099B66
	public SkillIconController()
	{
	}

	// Token: 0x170000C5 RID: 197
	// (get) Token: 0x06001181 RID: 4481 RVA: 0x0009B76E File Offset: 0x00099B6E
	// (set) Token: 0x06001182 RID: 4482 RVA: 0x0009B776 File Offset: 0x00099B76
	public Skill Skill
	{
		[CompilerGenerated]
		get
		{
			return this.<Skill>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Skill>k__BackingField = value;
		}
	}

	// Token: 0x06001183 RID: 4483 RVA: 0x0009B77F File Offset: 0x00099B7F
	public virtual void Start()
	{
		this._pointerIn = false;
	}

	// Token: 0x06001184 RID: 4484 RVA: 0x0009B788 File Offset: 0x00099B88
	public void Init(Skill skill)
	{
		if (skill == null)
		{
			this.SkillIcon.sprite = this.DefaultSprite;
		}
		else
		{
			this.SkillIcon.sprite = FilePath.GetSkillIconImage(skill.SkillType);
			SkillLogicBase skillLogic = skill.SkillType.GetSkillLogic();
			this.TargetingType.text = FilePath.GetTargetingTypeText(skillLogic.TargetingType);
			this.SkillCategory.sprite = FilePath.GetSkillCategoryImage(skillLogic.SkillCategory);
			if (this.Cover != null)
			{
				this.Cover.SetActive(!skill.IsEnabled);
			}
		}
		this.Skill = skill;
	}

	// Token: 0x06001185 RID: 4485 RVA: 0x0009B82B File Offset: 0x00099C2B
	private void Update()
	{
		if (this._pointerIn && this.Skill != null)
		{
			this.UpdateSkillInfo();
		}
	}

	// Token: 0x06001186 RID: 4486 RVA: 0x0009B849 File Offset: 0x00099C49
	public void Finished()
	{
		this.CloseTooltip();
		this._pointerIn = false;
	}

	// Token: 0x06001187 RID: 4487 RVA: 0x0009B858 File Offset: 0x00099C58
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.UpdateSkillInfo();
	}

	// Token: 0x06001188 RID: 4488 RVA: 0x0009B860 File Offset: 0x00099C60
	private void UpdateSkillInfo()
	{
		TooltipItem skillItemTooltip = this.GetSkillItemTooltip(this.Skill, false, null);
		if (this.Skill.CommandType == SkillCommandType.Active)
		{
			ActiveSkillLogicBase activeSkillLogicBase = this.Skill.SkillType.GetSkillLogic() as ActiveSkillLogicBase;
			if (activeSkillLogicBase != null)
			{
				if (base.GetComponentInParent<HeroManagementController>() != null)
				{
					skillItemTooltip.Type = string.Concat(new object[]
					{
						UIComponentType.SkillIconGaugeCostTitle.GetName(),
						"： ",
						activeSkillLogicBase.GetGaugeCost(this.Skill, base.GetComponentInParent<HeroManagementController>().SelectedHero.AdventurerProfile).DoubleToString(),
						"\n",
						UIComponentType.SkillIconCoolingDownSecondesTitle.GetName(),
						"：",
						activeSkillLogicBase.CoolingDownSeconds(this.Skill)
					});
				}
				else
				{
					skillItemTooltip.Type = string.Concat(new object[]
					{
						UIComponentType.SkillIconGaugeCostTitle.GetName(),
						"： ",
						activeSkillLogicBase.GetGaugeCost(this.Skill).DoubleToString(),
						"\n",
						UIComponentType.SkillIconCoolingDownSecondesTitle.GetName(),
						"：",
						activeSkillLogicBase.CoolingDownSeconds(this.Skill)
					});
				}
			}
		}
		this.OpenTooltip(skillItemTooltip, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06001189 RID: 4489 RVA: 0x0009B9B8 File Offset: 0x00099DB8
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
		this._pointerIn = false;
	}

	// Token: 0x04001258 RID: 4696
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Skill <Skill>k__BackingField;

	// Token: 0x04001259 RID: 4697
	private bool _pointerIn;

	// Token: 0x0400125A RID: 4698
	public Image SkillIcon;

	// Token: 0x0400125B RID: 4699
	public TextMeshProUGUI TargetingType;

	// Token: 0x0400125C RID: 4700
	public Image SkillCategory;

	// Token: 0x0400125D RID: 4701
	public GameObject Cover;

	// Token: 0x0400125E RID: 4702
	public Sprite DefaultSprite;
}
