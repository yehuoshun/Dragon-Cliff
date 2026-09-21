using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020001C2 RID: 450
public class HeroMenuSkillIconController : PageElementController, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, ISkillItemController, IEventSystemHandler
{
	// Token: 0x06000C05 RID: 3077 RVA: 0x00088115 File Offset: 0x00086515
	public HeroMenuSkillIconController()
	{
	}

	// Token: 0x17000052 RID: 82
	// (get) Token: 0x06000C06 RID: 3078 RVA: 0x0008811D File Offset: 0x0008651D
	// (set) Token: 0x06000C07 RID: 3079 RVA: 0x00088125 File Offset: 0x00086525
	public PageSkillItem SkillItem
	{
		[CompilerGenerated]
		get
		{
			return this.<SkillItem>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<SkillItem>k__BackingField = value;
		}
	}

	// Token: 0x06000C08 RID: 3080 RVA: 0x0008812E File Offset: 0x0008652E
	public override void Init(PageElement item)
	{
		base.PageElement = item;
		this.SkillItem = (item as PageSkillItem);
		if (this.SkillItem != null)
		{
			this.SkillImage.sprite = FilePath.GetSkillIconImage(this.SkillItem.Skill.SkillType);
		}
	}

	// Token: 0x06000C09 RID: 3081 RVA: 0x0008816E File Offset: 0x0008656E
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.OpenTooltip(this.GetSkillItemTooltip(this.SkillItem.Skill, false, null), null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000C0A RID: 3082 RVA: 0x00088195 File Offset: 0x00086595
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x06000C0B RID: 3083 RVA: 0x0008819D File Offset: 0x0008659D
	public void OnPointerClick(PointerEventData eventData)
	{
	}

	// Token: 0x04000E63 RID: 3683
	public Image SkillImage;

	// Token: 0x04000E64 RID: 3684
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PageSkillItem <SkillItem>k__BackingField;
}
