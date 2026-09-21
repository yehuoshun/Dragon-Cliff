using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E9 RID: 489
public class FilterSocketToggleController : MonoBehaviour
{
	// Token: 0x06000CF6 RID: 3318 RVA: 0x0008CC3F File Offset: 0x0008B03F
	public FilterSocketToggleController()
	{
	}

	// Token: 0x06000CF7 RID: 3319 RVA: 0x0008CC47 File Offset: 0x0008B047
	public void Init(SocketType socketType)
	{
		if (this.SocketType != socketType)
		{
			this.Toggle.isOn = false;
		}
	}

	// Token: 0x06000CF8 RID: 3320 RVA: 0x0008CC64 File Offset: 0x0008B064
	public void SwitchOn()
	{
		this.Toggle.isOn = true;
		InventoryFilterPanelController componentInParent = base.GetComponentInParent<InventoryFilterPanelController>();
		if (componentInParent != null)
		{
			componentInParent.OnSocketToggle(this.SocketType);
		}
	}

	// Token: 0x06000CF9 RID: 3321 RVA: 0x0008CC9C File Offset: 0x0008B09C
	public void OnToggleChange()
	{
		if (this.Toggle.isOn)
		{
			base.GetComponentInParent<InventoryFilterPanelController>().OnSocketToggle(this.SocketType);
		}
	}

	// Token: 0x04000F09 RID: 3849
	public Toggle Toggle;

	// Token: 0x04000F0A RID: 3850
	public SocketType SocketType;
}
