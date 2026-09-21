using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001CA RID: 458
public class InventoryToggleController : MonoBehaviour
{
	// Token: 0x06000C78 RID: 3192 RVA: 0x0008A8BC File Offset: 0x00088CBC
	public InventoryToggleController()
	{
	}

	// Token: 0x06000C79 RID: 3193 RVA: 0x0008A8C4 File Offset: 0x00088CC4
	public void Init(InventoryToggleType selectedType, InventoryTabButton tab)
	{
		if (this.TabType == tab && selectedType == this.ToggleType)
		{
			return;
		}
		if (this.TabType == tab)
		{
			this.Toggle.isOn = false;
		}
	}

	// Token: 0x06000C7A RID: 3194 RVA: 0x0008A8F7 File Offset: 0x00088CF7
	public void SelectToggle()
	{
		if (this.Toggle.isOn)
		{
			base.GetComponentInParent<InventoryMenuManager>().SelectToggle(this.ToggleType);
		}
	}

	// Token: 0x04000EB4 RID: 3764
	public Toggle Toggle;

	// Token: 0x04000EB5 RID: 3765
	public InventoryToggleType ToggleType;

	// Token: 0x04000EB6 RID: 3766
	public InventoryTabButton TabType;
}
