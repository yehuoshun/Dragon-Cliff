using System;

// Token: 0x020003A4 RID: 932
public class ResourceCategoryHoverController : GenericHoverController
{
	// Token: 0x060018E1 RID: 6369 RVA: 0x000BF8E3 File Offset: 0x000BDCE3
	public ResourceCategoryHoverController()
	{
	}

	// Token: 0x060018E2 RID: 6370 RVA: 0x000BF8EB File Offset: 0x000BDCEB
	public void Update()
	{
		if (this._pointerIn)
		{
			this.ResourceTypeInfo();
		}
	}

	// Token: 0x060018E3 RID: 6371 RVA: 0x000BF8FE File Offset: 0x000BDCFE
	public void SetResourceType(ResourceCategory type)
	{
		this._type = type;
	}

	// Token: 0x060018E4 RID: 6372 RVA: 0x000BF908 File Offset: 0x000BDD08
	public void ResourceTypeInfo()
	{
		string title = this._type.GetDescription().Title;
		string details = this._type.GetDescription().Details1;
		this.OpenTooltip(new TooltipItem
		{
			Image = FilePath.GetResourceCategoryIcon(this._type),
			Title = title,
			Description = details,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x040018B5 RID: 6325
	private ResourceCategory _type;
}
