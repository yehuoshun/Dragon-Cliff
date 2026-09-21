using System;
using TMPro;

// Token: 0x020001CC RID: 460
public class ItemWithLevelItemController : ItemController
{
	// Token: 0x06000C80 RID: 3200 RVA: 0x0008AB14 File Offset: 0x00088F14
	public ItemWithLevelItemController()
	{
	}

	// Token: 0x06000C81 RID: 3201 RVA: 0x0008AB1C File Offset: 0x00088F1C
	public override void Init(PageElement item)
	{
		base.Init(item);
		this.LevelText.text = this.NormalItem.Item.Level.ToLevelText();
	}

	// Token: 0x04000EB7 RID: 3767
	public TextMeshProUGUI LevelText;
}
