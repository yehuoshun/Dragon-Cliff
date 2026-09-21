using System;
using System.Runtime.CompilerServices;

// Token: 0x0200025C RID: 604
public class SkillPaginationController : PaginationController<PageSkillController>
{
	// Token: 0x06000FBF RID: 4031 RVA: 0x00095DDD File Offset: 0x000941DD
	public SkillPaginationController()
	{
	}

	// Token: 0x06000FC0 RID: 4032 RVA: 0x00095DE8 File Offset: 0x000941E8
	public void DiselectAllSkill()
	{
		foreach (PageSkillController pageSkillController in base.ItemHolders)
		{
			if (pageSkillController.PageSkill != null)
			{
				pageSkillController.Deselect();
			}
		}
	}

	// Token: 0x06000FC1 RID: 4033 RVA: 0x00095E50 File Offset: 0x00094250
	public override void UpdateSelectedFrame()
	{
		base.UpdateSelectedFrame();
		if (this.SelectedElement == null)
		{
			return;
		}
		int num = base.ItemHolders.FindIndex((PageSkillController i) => i.PageElement != null && i.PageElement.Id == this.SelectedElement.Id);
		if (num != -1)
		{
			this.DiselectAllSkill();
			base.ItemHolders[num].UpdateButtonState();
		}
		else
		{
			this.DiselectAllSkill();
		}
	}

	// Token: 0x06000FC2 RID: 4034 RVA: 0x00095EB0 File Offset: 0x000942B0
	[CompilerGenerated]
	private bool <UpdateSelectedFrame>m__0(PageSkillController i)
	{
		return i.PageElement != null && i.PageElement.Id == this.SelectedElement.Id;
	}
}
