using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200028E RID: 654
public class ShopSettingPanelController : MonoBehaviour
{
	// Token: 0x0600117C RID: 4476 RVA: 0x0009B735 File Offset: 0x00099B35
	public ShopSettingPanelController()
	{
	}

	// Token: 0x0600117D RID: 4477 RVA: 0x0009B73D File Offset: 0x00099B3D
	public void Init(List<PageElement> items)
	{
		this.RequirementPage.UpdateItems(items);
	}

	// Token: 0x0600117E RID: 4478 RVA: 0x0009B74B File Offset: 0x00099B4B
	public void AddNewItems(List<PageElement> items)
	{
		this.RequirementPage.AddNewItems(items);
	}

	// Token: 0x0600117F RID: 4479 RVA: 0x0009B759 File Offset: 0x00099B59
	public void ResetRequirementPage()
	{
		this.RequirementPage.ResetPage();
	}

	// Token: 0x04001257 RID: 4695
	public ItemPaginationController RequirementPage;
}
