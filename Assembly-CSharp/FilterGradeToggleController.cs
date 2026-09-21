using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E4 RID: 484
public class FilterGradeToggleController : MonoBehaviour
{
	// Token: 0x06000CE4 RID: 3300 RVA: 0x0008C886 File Offset: 0x0008AC86
	public FilterGradeToggleController()
	{
	}

	// Token: 0x06000CE5 RID: 3301 RVA: 0x0008C88E File Offset: 0x0008AC8E
	public void OnToggleChange()
	{
		base.GetComponentInParent<InventoryFilterPanelController>().OnGradeToggle(this.GradeType, this.Toggle.isOn);
	}

	// Token: 0x04000EFB RID: 3835
	public Toggle Toggle;

	// Token: 0x04000EFC RID: 3836
	public FilterGrade GradeType;
}
