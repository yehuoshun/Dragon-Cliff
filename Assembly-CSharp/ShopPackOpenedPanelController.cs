using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class ShopPackOpenedPanelController : MonoBehaviour
{
	// Token: 0x06001347 RID: 4935 RVA: 0x000A21AA File Offset: 0x000A05AA
	public ShopPackOpenedPanelController()
	{
	}

	// Token: 0x06001348 RID: 4936 RVA: 0x000A21B2 File Offset: 0x000A05B2
	public void Init(List<ResourceUpdate> resources)
	{
		this.ItemPage.UpdateItems(resources.Select(delegate(ResourceUpdate r)
		{
			Item item = r.RelatedItems[0];
			return new NormalItem
			{
				Id = item.Id,
				ResourceType = item.Type,
				Item = item,
				Amount = 1.0
			};
		}).Cast<PageElement>().ToList<PageElement>());
	}

	// Token: 0x06001349 RID: 4937 RVA: 0x000A21EC File Offset: 0x000A05EC
	public void ClosePanel()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x0600134A RID: 4938 RVA: 0x000A21FC File Offset: 0x000A05FC
	[CompilerGenerated]
	private static NormalItem <Init>m__0(ResourceUpdate r)
	{
		Item item = r.RelatedItems[0];
		return new NormalItem
		{
			Id = item.Id,
			ResourceType = item.Type,
			Item = item,
			Amount = 1.0
		};
	}

	// Token: 0x040013D1 RID: 5073
	public ItemPaginationController ItemPage;

	// Token: 0x040013D2 RID: 5074
	[CompilerGenerated]
	private static Func<ResourceUpdate, NormalItem> <>f__am$cache0;
}
