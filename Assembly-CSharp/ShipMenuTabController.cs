using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002B6 RID: 694
public class ShipMenuTabController : MonoBehaviour
{
	// Token: 0x060012A2 RID: 4770 RVA: 0x0009F844 File Offset: 0x0009DC44
	public ShipMenuTabController()
	{
	}

	// Token: 0x060012A3 RID: 4771 RVA: 0x0009F84C File Offset: 0x0009DC4C
	public void Init(Vehicle vehicle)
	{
		this.Vehicle = vehicle;
		this.ShipImage.sprite = FilePath.GetVehicleSprite(vehicle.Type);
	}

	// Token: 0x060012A4 RID: 4772 RVA: 0x0009F86C File Offset: 0x0009DC6C
	public void SetButtonStatus(Vehicle vehicle)
	{
		this.Button.interactable = (this.Vehicle.Id != vehicle.Id);
		List<TripRecord> currentJourneys = GameWorld.instance.PlayerProfile.CurrentJourneys;
		TripRecord tripRecord = currentJourneys.FirstOrDefault((TripRecord j) => j.Vehicle.Id == this.Vehicle.Id);
		this.ButtonBackground.sprite = ((tripRecord == null || tripRecord.Completed) ? this.NormalButtonSprite : this.OnJourneyButtonSprite);
	}

	// Token: 0x060012A5 RID: 4773 RVA: 0x0009F8EA File Offset: 0x0009DCEA
	public void SwitchPage()
	{
		if (this.Vehicle != null)
		{
			base.GetComponentInParent<ShipMenuController>().UpdateCurrentShipPage(this.Vehicle);
		}
	}

	// Token: 0x060012A6 RID: 4774 RVA: 0x0009F908 File Offset: 0x0009DD08
	[CompilerGenerated]
	private bool <SetButtonStatus>m__0(TripRecord j)
	{
		return j.Vehicle.Id == this.Vehicle.Id;
	}

	// Token: 0x0400135A RID: 4954
	public Image ShipImage;

	// Token: 0x0400135B RID: 4955
	public Button Button;

	// Token: 0x0400135C RID: 4956
	public Image ButtonBackground;

	// Token: 0x0400135D RID: 4957
	public Sprite NormalButtonSprite;

	// Token: 0x0400135E RID: 4958
	public Sprite OnJourneyButtonSprite;

	// Token: 0x0400135F RID: 4959
	public Vehicle Vehicle;
}
