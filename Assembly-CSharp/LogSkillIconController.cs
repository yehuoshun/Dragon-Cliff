using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020001F7 RID: 503
public class LogSkillIconController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISkillItemController, IEventSystemHandler
{
	// Token: 0x06000D51 RID: 3409 RVA: 0x0008E0F4 File Offset: 0x0008C4F4
	public LogSkillIconController()
	{
	}

	// Token: 0x06000D52 RID: 3410 RVA: 0x0008E0FC File Offset: 0x0008C4FC
	public void Init(Skill skill)
	{
		if (skill == null)
		{
			this.SkillIcon.color = Color.black;
		}
		else
		{
			this.SkillIcon.color = Color.white;
			this.SkillIcon.sprite = FilePath.GetSkillIconImage(skill.SkillType);
			this._skill = skill;
		}
	}

	// Token: 0x06000D53 RID: 3411 RVA: 0x0008E154 File Offset: 0x0008C554
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._skill == null)
		{
			return;
		}
		TooltipItem skillItemTooltip = this.GetSkillItemTooltip(this._skill, false, null);
		this.OpenTooltip(skillItemTooltip, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000D54 RID: 3412 RVA: 0x0008E18F File Offset: 0x0008C58F
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000F5D RID: 3933
	public Image SkillIcon;

	// Token: 0x04000F5E RID: 3934
	private Skill _skill;
}
