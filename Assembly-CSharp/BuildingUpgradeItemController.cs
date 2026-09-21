using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000213 RID: 531
public class BuildingUpgradeItemController : PageItemController
{
	// Token: 0x06000DFD RID: 3581 RVA: 0x00090500 File Offset: 0x0008E900
	public BuildingUpgradeItemController()
	{
	}

	// Token: 0x06000DFE RID: 3582 RVA: 0x00090508 File Offset: 0x0008E908
	public override void Init(PageElement item)
	{
		this.UpdateIconStatus();
	}

	// Token: 0x06000DFF RID: 3583 RVA: 0x00090510 File Offset: 0x0008E910
	private void UpdateIconStatus()
	{
	}

	// Token: 0x06000E00 RID: 3584 RVA: 0x00090512 File Offset: 0x0008E912
	public void Upgrade()
	{
		this.UpdateIconStatus();
	}

	// Token: 0x06000E01 RID: 3585 RVA: 0x0009051A File Offset: 0x0008E91A
	public override void OnPointerEnter(PointerEventData eventData)
	{
	}

	// Token: 0x06000E02 RID: 3586 RVA: 0x0009051C File Offset: 0x0008E91C
	public override void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x04000FE0 RID: 4064
	public Image FadeFrame;

	// Token: 0x04000FE1 RID: 4065
	public Text LevelText;
}
