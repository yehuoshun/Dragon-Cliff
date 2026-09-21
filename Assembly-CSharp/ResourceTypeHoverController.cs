using System;

// Token: 0x020003A5 RID: 933
public class ResourceTypeHoverController : GenericHoverController
{
	// Token: 0x060018E5 RID: 6373 RVA: 0x000BF980 File Offset: 0x000BDD80
	public ResourceTypeHoverController()
	{
	}

	// Token: 0x060018E6 RID: 6374 RVA: 0x000BF988 File Offset: 0x000BDD88
	public void Update()
	{
		if (this._pointerIn)
		{
			this.ResourceTypeInfo();
		}
	}

	// Token: 0x060018E7 RID: 6375 RVA: 0x000BF99B File Offset: 0x000BDD9B
	public void SetResourceType(ResourceType type)
	{
		this._type = type;
	}

	// Token: 0x060018E8 RID: 6376 RVA: 0x000BF9A4 File Offset: 0x000BDDA4
	public void ResourceTypeInfo()
	{
		string title = this._type.GetDescription().Title;
		string details = this._type.GetDescription().Details1;
		this.OpenTooltip(new TooltipItem
		{
			Title = title,
			Description = details,
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x040018B6 RID: 6326
	private ResourceType _type;
}
