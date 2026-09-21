using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002B1 RID: 689
public class ShipMenuOnTipPanelController : MonoBehaviour
{
	// Token: 0x0600128F RID: 4751 RVA: 0x0009F2E4 File Offset: 0x0009D6E4
	public ShipMenuOnTipPanelController()
	{
	}

	// Token: 0x06001290 RID: 4752 RVA: 0x0009F2EC File Offset: 0x0009D6EC
	private void Update()
	{
		if (this._record != null && !this._record.Claimed)
		{
			this.CurrentMiles.text = this._record.CurrentOnMiles.DoubleToString() + " " + UIComponentType.ShipMenuMile.GetName();
		}
	}

	// Token: 0x06001291 RID: 4753 RVA: 0x0009F344 File Offset: 0x0009D744
	public void Init(TripRecord record)
	{
		this._record = record;
		this.DestinationText.text = record.CurrentDestination.GetDescription().Title;
		this.UpdateStatus(record);
		this.CurrentMiles.text = this._record.CurrentOnMiles.DoubleToString() + " " + UIComponentType.ShipMenuMile.GetName();
	}

	// Token: 0x06001292 RID: 4754 RVA: 0x0009F3AC File Offset: 0x0009D7AC
	public void UpdateStatus(TripRecord record)
	{
		this._record = record;
		this.CancelTripButton.gameObject.SetActive(!record.Completed);
		this.ClaimRewardButton.gameObject.SetActive(record.Completed && !record.Claimed);
		this.TripFinishedText.SetActive(record.Completed);
	}

	// Token: 0x04001347 RID: 4935
	public TextMeshProUGUI DestinationText;

	// Token: 0x04001348 RID: 4936
	public TextMeshProUGUI CurrentMiles;

	// Token: 0x04001349 RID: 4937
	public GameObject TripFinishedText;

	// Token: 0x0400134A RID: 4938
	public Button CancelTripButton;

	// Token: 0x0400134B RID: 4939
	public Button ClaimRewardButton;

	// Token: 0x0400134C RID: 4940
	private TripRecord _record;
}
