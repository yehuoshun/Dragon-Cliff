using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000289 RID: 649
public class ResourceMenuController : MonoBehaviour
{
	// Token: 0x06001147 RID: 4423 RVA: 0x0009A463 File Offset: 0x00098863
	public ResourceMenuController()
	{
	}

	// Token: 0x06001148 RID: 4424 RVA: 0x0009A474 File Offset: 0x00098874
	private void OnEnable()
	{
		List<ResourceMenuItem> resources = (from r in GameWorld.instance.PlayerProfile.ResourcesAt
		where r.Key.GetResourceCategory().IsRawMaterial() || r.Key.GetResourceCategory() == ResourceCategory.GameItem || r.Key.GetResourceCategory() == ResourceCategory.CoreResource || r.Key.GetResourceCategory() == ResourceCategory.Consumable
		select new ResourceMenuItem
		{
			Type = r.Key,
			Amount = r.Value.GetValue()
		}).ToList<ResourceMenuItem>();
		this.Init(resources);
	}

	// Token: 0x06001149 RID: 4425 RVA: 0x0009A4E4 File Offset: 0x000988E4
	public void Init(List<ResourceMenuItem> resources)
	{
		foreach (ResourceMenuItem resource in resources)
		{
			this.AddResource(resource);
		}
	}

	// Token: 0x0600114A RID: 4426 RVA: 0x0009A53C File Offset: 0x0009893C
	public void AddResource(ResourceMenuItem resource)
	{
		PageItem item = new PageItem
		{
			Id = resource.Type.ToString(),
			ResourceType = resource.Type,
			Amount = resource.Amount
		};
		if (!this.ItemExist(resource.Type))
		{
			this.AddItem(item);
		}
		else
		{
			this.UpdateItemAmount(item);
		}
	}

	// Token: 0x0600114B RID: 4427 RVA: 0x0009A5A8 File Offset: 0x000989A8
	public void AddItems(List<PageItem> items)
	{
		foreach (PageItem item in items)
		{
			this.AddItem(item);
		}
	}

	// Token: 0x0600114C RID: 4428 RVA: 0x0009A600 File Offset: 0x00098A00
	public void AddItem(PageItem item)
	{
		ResourceCategory resourceCategory = item.ResourceType.GetResourceCategory();
		if (resourceCategory == ResourceCategory.Hides || resourceCategory == ResourceCategory.Ore || resourceCategory == ResourceCategory.CoreResource)
		{
			if (this.LeftPage.PageElements.Count < this.MaxItemPerPage)
			{
				this.LeftPage.AddNewItem(item);
			}
			else
			{
				this.MiddlePage.AddNewItem(item);
			}
		}
		else if (resourceCategory == ResourceCategory.GameItem)
		{
			if (this.RightPage.PageElements.Count < this.MaxItemPerPage)
			{
				this.RightPage.AddNewItem(item);
			}
			else
			{
				this.LastPage.AddNewItem(item);
			}
		}
		else if (resourceCategory == ResourceCategory.Consumable && item.Amount >= 0.0)
		{
			this.LastPage.AddNewItem(item);
		}
	}

	// Token: 0x0600114D RID: 4429 RVA: 0x0009A6DC File Offset: 0x00098ADC
	public bool ItemExist(ResourceType type)
	{
		ResourceCategory resourceCategory = type.GetResourceCategory();
		if (resourceCategory == ResourceCategory.Hides || resourceCategory == ResourceCategory.Ore || resourceCategory == ResourceCategory.CoreResource)
		{
			return this.LeftPage.GetPageItem(type.ToString()) != null || this.MiddlePage.GetPageItem(type.ToString()) != null;
		}
		if (resourceCategory == ResourceCategory.GameItem)
		{
			return this.RightPage.GetPageItem(type.ToString()) != null || this.LastPage.GetPageItem(type.ToString()) != null;
		}
		return resourceCategory == ResourceCategory.Consumable && this.LastPage.GetPageItem(type.ToString()) != null;
	}

	// Token: 0x0600114E RID: 4430 RVA: 0x0009A7B8 File Offset: 0x00098BB8
	public void UpdateItemAmount(PageItem item)
	{
		ResourceCategory resourceCategory = item.ResourceType.GetResourceCategory();
		if (item.Amount < 0.0)
		{
			List<string> ids = new List<string>
			{
				item.Id
			};
			if (resourceCategory == ResourceCategory.Hides || resourceCategory == ResourceCategory.Ore || resourceCategory == ResourceCategory.CoreResource)
			{
				this.LeftPage.TryRemoveItem(ids);
				this.MiddlePage.TryRemoveItem(ids);
			}
			else if (resourceCategory == ResourceCategory.GameItem)
			{
				this.RightPage.TryRemoveItem(ids);
				this.LastPage.TryRemoveItem(ids);
			}
			else if (resourceCategory == ResourceCategory.Consumable)
			{
				this.LastPage.TryRemoveItem(ids);
			}
		}
		else if (resourceCategory == ResourceCategory.Hides || resourceCategory == ResourceCategory.Ore || resourceCategory == ResourceCategory.CoreResource)
		{
			this.LeftPage.UpdateItemAmount(item);
			this.MiddlePage.UpdateItemAmount(item);
		}
		else if (resourceCategory == ResourceCategory.GameItem)
		{
			this.RightPage.UpdateItemAmount(item);
			this.LastPage.UpdateItemAmount(item);
		}
		else if (resourceCategory == ResourceCategory.Consumable)
		{
			this.LastPage.UpdateItemAmount(item);
		}
	}

	// Token: 0x0600114F RID: 4431 RVA: 0x0009A8DC File Offset: 0x00098CDC
	[CompilerGenerated]
	private static bool <OnEnable>m__0(KeyValuePair<ResourceType, ResourceProfileAntiCheat> r)
	{
		return r.Key.GetResourceCategory().IsRawMaterial() || r.Key.GetResourceCategory() == ResourceCategory.GameItem || r.Key.GetResourceCategory() == ResourceCategory.CoreResource || r.Key.GetResourceCategory() == ResourceCategory.Consumable;
	}

	// Token: 0x06001150 RID: 4432 RVA: 0x0009A938 File Offset: 0x00098D38
	[CompilerGenerated]
	private static ResourceMenuItem <OnEnable>m__1(KeyValuePair<ResourceType, ResourceProfileAntiCheat> r)
	{
		return new ResourceMenuItem
		{
			Type = r.Key,
			Amount = r.Value.GetValue()
		};
	}

	// Token: 0x04001220 RID: 4640
	public ItemPaginationController LeftPage;

	// Token: 0x04001221 RID: 4641
	public ItemPaginationController MiddlePage;

	// Token: 0x04001222 RID: 4642
	public ItemPaginationController RightPage;

	// Token: 0x04001223 RID: 4643
	public ItemPaginationController LastPage;

	// Token: 0x04001224 RID: 4644
	public int MaxItemPerPage = 14;

	// Token: 0x04001225 RID: 4645
	[CompilerGenerated]
	private static Func<KeyValuePair<ResourceType, ResourceProfileAntiCheat>, bool> <>f__am$cache0;

	// Token: 0x04001226 RID: 4646
	[CompilerGenerated]
	private static Func<KeyValuePair<ResourceType, ResourceProfileAntiCheat>, ResourceMenuItem> <>f__am$cache1;
}
