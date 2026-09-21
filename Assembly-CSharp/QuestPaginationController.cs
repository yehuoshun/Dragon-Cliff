using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000230 RID: 560
public class QuestPaginationController : PaginationController<QuestItemController>
{
	// Token: 0x06000EA6 RID: 3750 RVA: 0x00091830 File Offset: 0x0008FC30
	public QuestPaginationController()
	{
	}

	// Token: 0x06000EA7 RID: 3751 RVA: 0x00091838 File Offset: 0x0008FC38
	public override void UpdateItems(List<PageElement> elements)
	{
		List<PageElement> elements2 = (from q in elements.Cast<PageQuest>().ToList<PageQuest>()
		orderby (!q.Quest.QuestIdentifier.IsMainQuest()) ? 1 : 0
		select q).Cast<PageElement>().ToList<PageElement>();
		base.UpdateItems(elements2);
	}

	// Token: 0x06000EA8 RID: 3752 RVA: 0x00091884 File Offset: 0x0008FC84
	[CompilerGenerated]
	private static int <UpdateItems>m__0(PageQuest q)
	{
		return (!q.Quest.QuestIdentifier.IsMainQuest()) ? 1 : 0;
	}

	// Token: 0x0400101F RID: 4127
	[CompilerGenerated]
	private static Func<PageQuest, int> <>f__am$cache0;
}
