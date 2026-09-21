using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E5 RID: 485
public class FilterHasGemToggleController : MonoBehaviour
{
	// Token: 0x06000CE6 RID: 3302 RVA: 0x0008C8AC File Offset: 0x0008ACAC
	public FilterHasGemToggleController()
	{
	}

	// Token: 0x06000CE7 RID: 3303 RVA: 0x0008C8B4 File Offset: 0x0008ACB4
	public void Init(HasGemStatus hasGemStatus)
	{
		if (this.HasGemStatus != hasGemStatus)
		{
			this.Toggle.isOn = false;
		}
	}

	// Token: 0x06000CE8 RID: 3304 RVA: 0x0008C8CE File Offset: 0x0008ACCE
	public void OnToggleChange()
	{
		if (this.Toggle.isOn)
		{
			base.GetComponentInParent<InventoryFilterPanelController>().OnHasGemToggle(this.HasGemStatus);
		}
	}

	// Token: 0x04000EFD RID: 3837
	public Toggle Toggle;

	// Token: 0x04000EFE RID: 3838
	public HasGemStatus HasGemStatus;
}
