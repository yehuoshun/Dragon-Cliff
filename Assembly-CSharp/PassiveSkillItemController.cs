using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020001D1 RID: 465
public class PassiveSkillItemController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, ISkillItemController, IEventSystemHandler
{
	// Token: 0x06000C98 RID: 3224 RVA: 0x0008AB93 File Offset: 0x00088F93
	public PassiveSkillItemController()
	{
	}

	// Token: 0x06000C99 RID: 3225 RVA: 0x0008AB9B File Offset: 0x00088F9B
	public void Init(Skill skill, bool selected)
	{
		if (skill == null)
		{
			return;
		}
		this._skill = skill;
		this.SkillImage.sprite = FilePath.GetSkillIconImage(skill.SkillType);
		this.SelectedFrame.SetActive(selected);
	}

	// Token: 0x06000C9A RID: 3226 RVA: 0x0008ABCD File Offset: 0x00088FCD
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.OpenTooltip(this.GetSkillItemTooltip(this._skill, false, null), null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000C9B RID: 3227 RVA: 0x0008ABEF File Offset: 0x00088FEF
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x06000C9C RID: 3228 RVA: 0x0008ABF7 File Offset: 0x00088FF7
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<HeroMenuController>().ChangeSecondSkill(this._skill);
		this.CloseTooltip();
	}

	// Token: 0x04000EC1 RID: 3777
	public Image SkillImage;

	// Token: 0x04000EC2 RID: 3778
	public GameObject SelectedFrame;

	// Token: 0x04000EC3 RID: 3779
	private Skill _skill;
}
