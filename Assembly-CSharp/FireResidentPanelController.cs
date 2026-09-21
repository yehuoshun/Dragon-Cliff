using System;
using TMPro;
using UnityEngine;

// Token: 0x02000245 RID: 581
public class FireResidentPanelController : MonoBehaviour
{
	// Token: 0x06000F0E RID: 3854 RVA: 0x0009334B File Offset: 0x0009174B
	public FireResidentPanelController()
	{
	}

	// Token: 0x06000F0F RID: 3855 RVA: 0x00093353 File Offset: 0x00091753
	public void Init(Resident resident)
	{
		this._resident = resident;
		this.ResidentNameText.text = resident.Type.GetDescription().Title;
		this.ResidentNameText.color = ColorPicker.GetGradeColor(resident.Grade, false);
	}

	// Token: 0x06000F10 RID: 3856 RVA: 0x0009338E File Offset: 0x0009178E
	public void ComfirmKickResident()
	{
		base.GetComponentInParent<ResidentMenuController>().ComfirmKickout(this._resident);
	}

	// Token: 0x0400107B RID: 4219
	public TextMeshProUGUI ResidentNameText;

	// Token: 0x0400107C RID: 4220
	private Resident _resident;
}
