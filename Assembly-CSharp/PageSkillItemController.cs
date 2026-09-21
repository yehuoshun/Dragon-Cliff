using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002F4 RID: 756
public class PageSkillItemController : PageElementController, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06001405 RID: 5125 RVA: 0x000A5481 File Offset: 0x000A3881
	public PageSkillItemController()
	{
	}

	// Token: 0x06001406 RID: 5126 RVA: 0x000A548C File Offset: 0x000A388C
	public override void Init(PageElement item)
	{
		base.PageElement = item;
		this._skillItem = (PageSkillItem)item;
		this.SkillImage.sprite = FilePath.GetSkillIconImage(this._skillItem.Skill.SkillType);
		this.SkillName.text = this._skillItem.Skill.SkillType.GetDescription().Title;
	}

	// Token: 0x06001407 RID: 5127 RVA: 0x000A54F4 File Offset: 0x000A38F4
	public void OnPointerEnter(PointerEventData eventData)
	{
		Description description = this._skillItem.Skill.GetDescription();
		string description2 = ColorPicker.ReplaceSkillTag(description.Details1);
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = description2,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06001408 RID: 5128 RVA: 0x000A555B File Offset: 0x000A395B
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x06001409 RID: 5129 RVA: 0x000A5563 File Offset: 0x000A3963
	public void OnPointerClick(PointerEventData eventData)
	{
	}

	// Token: 0x0400145B RID: 5211
	public Image SkillImage;

	// Token: 0x0400145C RID: 5212
	public TextMeshProUGUI SkillName;

	// Token: 0x0400145D RID: 5213
	private PageSkillItem _skillItem;
}
