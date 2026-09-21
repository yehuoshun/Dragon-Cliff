using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200020F RID: 527
public class BuildingCardController : PageBuildingController, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000DED RID: 3565 RVA: 0x000903BB File Offset: 0x0008E7BB
	public BuildingCardController()
	{
	}

	// Token: 0x17000070 RID: 112
	// (get) Token: 0x06000DEE RID: 3566 RVA: 0x000903C3 File Offset: 0x0008E7C3
	// (set) Token: 0x06000DEF RID: 3567 RVA: 0x000903CB File Offset: 0x0008E7CB
	public BuildingItem BuildingItem
	{
		[CompilerGenerated]
		get
		{
			return this.<BuildingItem>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<BuildingItem>k__BackingField = value;
		}
	}

	// Token: 0x06000DF0 RID: 3568 RVA: 0x000903D4 File Offset: 0x0008E7D4
	public override void Init(PageElement element)
	{
		base.Init(element);
		this.BuildingItem = (BuildingItem)element;
		this.BuildingImage.sprite = FilePath.GetBuildingImage(this.BuildingItem.BuildingType);
		this.BuildingName.text = this.BuildingItem.BuildingType.GetDescription().Title;
		this.BuidlingPrice.text = this.BuildingItem.Price.ToGameCurrency();
	}

	// Token: 0x06000DF1 RID: 3569 RVA: 0x0009044A File Offset: 0x0008E84A
	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	// Token: 0x06000DF2 RID: 3570 RVA: 0x0009044C File Offset: 0x0008E84C
	public void OnPointerExit(PointerEventData eventData)
	{
	}

	// Token: 0x06000DF3 RID: 3571 RVA: 0x0009044E File Offset: 0x0008E84E
	public void OnPointerClick(PointerEventData eventData)
	{
		base.GetComponentInParent<BuildingMenuController>().SelectBuilding(this.BuildingItem);
	}

	// Token: 0x04000FD9 RID: 4057
	public Image BuildingImage;

	// Token: 0x04000FDA RID: 4058
	public Text BuildingName;

	// Token: 0x04000FDB RID: 4059
	public Text BuidlingPrice;

	// Token: 0x04000FDC RID: 4060
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BuildingItem <BuildingItem>k__BackingField;
}
