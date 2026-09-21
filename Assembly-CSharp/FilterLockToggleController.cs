using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E7 RID: 487
public class FilterLockToggleController : MonoBehaviour
{
	// Token: 0x06000CEF RID: 3311 RVA: 0x0008CA73 File Offset: 0x0008AE73
	public FilterLockToggleController()
	{
	}

	// Token: 0x06000CF0 RID: 3312 RVA: 0x0008CA7B File Offset: 0x0008AE7B
	public void Init(LockStatus lockStatus)
	{
		if (this.LockStatus != lockStatus)
		{
			this.Toggle.isOn = false;
		}
	}

	// Token: 0x06000CF1 RID: 3313 RVA: 0x0008CA95 File Offset: 0x0008AE95
	public void OnToggleChange()
	{
		if (this.Toggle.isOn)
		{
			base.GetComponentInParent<InventoryFilterPanelController>().OnLockToggle(this.LockStatus);
		}
	}

	// Token: 0x04000F04 RID: 3844
	public Toggle Toggle;

	// Token: 0x04000F05 RID: 3845
	public LockStatus LockStatus;
}
