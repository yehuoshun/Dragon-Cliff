using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200021D RID: 541
public class ItemPaginationController : PaginationController<PageItemController>
{
	// Token: 0x06000E30 RID: 3632 RVA: 0x0009105C File Offset: 0x0008F45C
	public ItemPaginationController()
	{
	}

	// Token: 0x06000E31 RID: 3633 RVA: 0x00091064 File Offset: 0x0008F464
	public void UpdateItemAmount(PageItem item)
	{
		PageItem pageItem = this.GetPageItem(item.Id);
		if (pageItem != null)
		{
			pageItem.Amount = item.Amount;
		}
		this.DisplayCurrentPage();
	}

	// Token: 0x06000E32 RID: 3634 RVA: 0x00091098 File Offset: 0x0008F498
	public bool ContainsSameTypeItem(ResourceType type)
	{
		List<NormalItem> source = base.PageElements.OfType<NormalItem>().ToList<NormalItem>();
		return source.Any((NormalItem i) => i.ResourceType == type);
	}

	// Token: 0x06000E33 RID: 3635 RVA: 0x000910D8 File Offset: 0x0008F4D8
	public bool ContainsSameTypeAndLevel(NormalItem item)
	{
		List<NormalItem> source = base.PageElements.OfType<NormalItem>().ToList<NormalItem>();
		return source.Any((NormalItem i) => i.ResourceType == item.Item.Type && i.Item.Level == item.Item.Level);
	}

	// Token: 0x06000E34 RID: 3636 RVA: 0x00091118 File Offset: 0x0008F518
	public PageItem GetPageItem(string id)
	{
		PageElement pageElement = base.GetPageElement(id);
		if (pageElement != null)
		{
			return (PageItem)pageElement;
		}
		return null;
	}

	// Token: 0x02000C47 RID: 3143
	[CompilerGenerated]
	private sealed class <ContainsSameTypeItem>c__AnonStorey0
	{
		// Token: 0x0600527D RID: 21117 RVA: 0x0009113B File Offset: 0x0008F53B
		public <ContainsSameTypeItem>c__AnonStorey0()
		{
		}

		// Token: 0x0600527E RID: 21118 RVA: 0x00091143 File Offset: 0x0008F543
		internal bool <>m__0(NormalItem i)
		{
			return i.ResourceType == this.type;
		}

		// Token: 0x04004064 RID: 16484
		internal ResourceType type;
	}

	// Token: 0x02000C48 RID: 3144
	[CompilerGenerated]
	private sealed class <ContainsSameTypeAndLevel>c__AnonStorey1
	{
		// Token: 0x0600527F RID: 21119 RVA: 0x00091153 File Offset: 0x0008F553
		public <ContainsSameTypeAndLevel>c__AnonStorey1()
		{
		}

		// Token: 0x06005280 RID: 21120 RVA: 0x0009115B File Offset: 0x0008F55B
		internal bool <>m__0(NormalItem i)
		{
			return i.ResourceType == this.item.Item.Type && i.Item.Level == this.item.Item.Level;
		}

		// Token: 0x04004065 RID: 16485
		internal NormalItem item;
	}
}
