using System;
using TMPro;
using UnityEngine;

// Token: 0x02000200 RID: 512
public class ComfirmDeleteRecordController : MonoBehaviour
{
	// Token: 0x06000D8A RID: 3466 RVA: 0x0008ED24 File Offset: 0x0008D124
	public ComfirmDeleteRecordController()
	{
	}

	// Token: 0x06000D8B RID: 3467 RVA: 0x0008ED2C File Offset: 0x0008D12C
	public void Init(PlayerProfileLoadDetails loadDetails)
	{
		this._loadDetails = loadDetails;
		this.DaysText.text = UIComponentType.DayPanelDays.GetName().ReplaceToBuilder(UIComponentKey.NumberOfDay, loadDetails.Profile.GameDays.ToString()).ToString();
		this.ReputationTitleText.text = loadDetails.Profile.GetTitle().GetDescription().Title;
	}

	// Token: 0x06000D8C RID: 3468 RVA: 0x0008ED96 File Offset: 0x0008D196
	public void ComfirmDelete()
	{
		base.GetComponentInParent<StartGamePanelController>().ComfirmDeleteRecord(this._loadDetails);
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x0008EDA9 File Offset: 0x0008D1A9
	public void CancelDelete()
	{
		base.GetComponentInParent<StartGamePanelController>().CancelDelete();
	}

	// Token: 0x04000F8D RID: 3981
	public TextMeshProUGUI DaysText;

	// Token: 0x04000F8E RID: 3982
	public TextMeshProUGUI ReputationTitleText;

	// Token: 0x04000F8F RID: 3983
	private PlayerProfileLoadDetails _loadDetails;
}
