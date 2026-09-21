using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002AF RID: 687
public class ShipMenuController : MonoBehaviour
{
	// Token: 0x06001263 RID: 4707 RVA: 0x0009E0C1 File Offset: 0x0009C4C1
	public ShipMenuController()
	{
	}

	// Token: 0x06001264 RID: 4708 RVA: 0x0009E0CC File Offset: 0x0009C4CC
	private void Start()
	{
		TMP_Dropdown dropdown = this.TravellerDropdown.GetComponent<TMP_Dropdown>();
		dropdown.onValueChanged.AddListener(delegate(int A_1)
		{
			this.TravellerDropdown.Init(this.TravellerDropdown.DropdownValues.Single((JourneyContributeTypeDropdownValue d) => d.Value == dropdown.value).Type);
			this.OrderTravellerPage();
		});
		this.AutoExploreButton.SetActive(!this.GetAdditionalData(UIAdditionalDataKey.AutoExplore, false));
	}

	// Token: 0x06001265 RID: 4709 RVA: 0x0009E12D File Offset: 0x0009C52D
	private void Update()
	{
		if (this._isOnTrip)
		{
			this.UpdateHealth();
		}
	}

	// Token: 0x06001266 RID: 4710 RVA: 0x0009E140 File Offset: 0x0009C540
	private void OnEnable()
	{
		this.UpdateShipTabs();
	}

	// Token: 0x06001267 RID: 4711 RVA: 0x0009E148 File Offset: 0x0009C548
	private void OnDisable()
	{
		this.DestroyBoatComfirmPanel.SetActive(false);
		this.RewardPanel.gameObject.SetActive(false);
		this.CancelTripConfirmPanel.gameObject.SetActive(false);
	}

	// Token: 0x06001268 RID: 4712 RVA: 0x0009E178 File Offset: 0x0009C578
	private void UpdateShipTabs()
	{
		this._shipTabs = new List<ShipMenuTabController>();
		IEnumerator enumerator = this.ShipTabContrainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		List<Vehicle> currentVehicles = GameWorld.instance.PlayerProfile.CurrentVehicles;
		foreach (Vehicle vehicle in currentVehicles)
		{
			ShipMenuTabController shipMenuTabController = UnityEngine.Object.Instantiate<ShipMenuTabController>(this.ShipTabPre);
			shipMenuTabController.Init(vehicle);
			shipMenuTabController.transform.SetParent(this.ShipTabContrainer, false);
			this._shipTabs.Add(shipMenuTabController);
		}
		if (currentVehicles.Count > 0)
		{
			this.UpdateCurrentShipPage(currentVehicles[0]);
		}
	}

	// Token: 0x06001269 RID: 4713 RVA: 0x0009E28C File Offset: 0x0009C68C
	public void UpdateCurrentShipPage(Vehicle vehicle)
	{
		this._selectedVehicle = vehicle;
		if (vehicle == null)
		{
			return;
		}
		List<TripRecord> currentJourneys = GameWorld.instance.PlayerProfile.CurrentJourneys;
		TripRecord tripRecord = currentJourneys.FirstOrDefault((TripRecord j) => j.Vehicle.Id == vehicle.Id);
		foreach (ShipMenuTabController shipMenuTabController in this._shipTabs)
		{
			shipMenuTabController.SetButtonStatus(vehicle);
		}
		this.SelectedTravellersPanel.Init(vehicle);
		this.ShipInfoPanel.Init(vehicle);
		this.DestroyBoatButton.SetActive(true);
		if (tripRecord != null && !tripRecord.Claimed)
		{
			this._isOnTrip = true;
			this.SelectDestinationPanel.SetActive(false);
			this.DisplayTripDetailsPanel.Init(tripRecord);
			this.DisplayTripDetailsPanel.gameObject.SetActive(true);
			this.LogPanel.Init(tripRecord.Encounters);
			this.DestroyBoatButton.SetActive(false);
		}
		else
		{
			this._isOnTrip = false;
			this.SelectDestinationPanel.SetActive(true);
			this.DisplayTripDetailsPanel.gameObject.SetActive(false);
			this.LogPanel.Clear();
		}
		this.OrderTravellerPage();
		this.ResetGoButtonStaus();
	}

	// Token: 0x0600126A RID: 4714 RVA: 0x0009E404 File Offset: 0x0009C804
	private void OrderTravellerPage()
	{
		IEnumerable<PageTraveller> enumerable = from t in GameWorld.instance.PlayerProfile.GetAllAvaliableTravellers()
		select new PageTraveller
		{
			Id = t.GetId(),
			Traveller = t,
			Picked = false
		};
		enumerable = this.OrderJourneyContribute(enumerable, this.TravellerDropdown.GetSlectedJourneyContributeType());
		this.TravellerPage.UpdateItems(enumerable.Cast<PageElement>().ToList<PageElement>());
	}

	// Token: 0x0600126B RID: 4715 RVA: 0x0009E46C File Offset: 0x0009C86C
	private IEnumerable<PageTraveller> OrderJourneyContribute(IEnumerable<PageTraveller> travellers, JourneyContributeType type)
	{
		return travellers.OrderByDescending(delegate(PageTraveller p)
		{
			JourneyContributionModifier journeyContributionModifier = p.Traveller.GetContributions().FirstOrDefault((JourneyContributionModifier c) => c.Type == type);
			if (journeyContributionModifier != null)
			{
				return journeyContributionModifier.Value;
			}
			return 0.0;
		});
	}

	// Token: 0x0600126C RID: 4716 RVA: 0x0009E498 File Offset: 0x0009C898
	public void PreRepair()
	{
		int repairCost = this._selectedVehicle.GetRepairCost();
		this.RepairComfirmPanel.Init(repairCost);
		this.RepairComfirmPanel.gameObject.SetActive(true);
	}

	// Token: 0x0600126D RID: 4717 RVA: 0x0009E4D0 File Offset: 0x0009C8D0
	public void Repair()
	{
		int repairCost = this._selectedVehicle.GetRepairCost();
		if (GameWorld.instance.PlayerProfile.GetMoney() >= (double)repairCost)
		{
			this._selectedVehicle.Repair();
			this.UpdateCurrentShipPage(this._selectedVehicle);
		}
		else
		{
			this.DisplayWarningText(UIComponentType.NotEnoughMoney.GetName());
		}
		this.RepairComfirmPanel.gameObject.SetActive(false);
	}

	// Token: 0x0600126E RID: 4718 RVA: 0x0009E53C File Offset: 0x0009C93C
	public void PreDestroyBoat()
	{
		this.DestroyBoatComfirmPanel.SetActive(true);
	}

	// Token: 0x0600126F RID: 4719 RVA: 0x0009E54C File Offset: 0x0009C94C
	public void DestroyBoat()
	{
		if (this._selectedVehicle != null)
		{
			GameWorld.instance.PlayerProfile.RemoveVehcle(this._selectedVehicle);
			this.DestroyBoatComfirmPanel.SetActive(false);
			if (GameWorld.instance.PlayerProfile.CurrentVehicles.Count > 0)
			{
				this.UpdateShipTabs();
			}
			else
			{
				TownManager.Instance.Ui.OpenBuildShipMenu();
				TownManager.Instance.Ui.CloseShipMenu();
			}
			TownManager.Instance.VehiclePoints.UpdateShipsOnPoints();
		}
	}

	// Token: 0x06001270 RID: 4720 RVA: 0x0009E5D7 File Offset: 0x0009C9D7
	public void CancelRemove()
	{
		this.DestroyBoatComfirmPanel.SetActive(false);
	}

	// Token: 0x06001271 RID: 4721 RVA: 0x0009E5E5 File Offset: 0x0009C9E5
	public void CompleteTrip(TripRecord record)
	{
		if (this._selectedVehicle != null && this._selectedVehicle.Id == record.Vehicle.Id)
		{
			this.DisplayTripDetailsPanel.UpdateStatus(record);
		}
	}

	// Token: 0x06001272 RID: 4722 RVA: 0x0009E620 File Offset: 0x0009CA20
	public void AddLog(ITripeEncounter encounter)
	{
		if (this._selectedVehicle != null)
		{
			TripRecord tripRecord = GameWorld.instance.PlayerProfile.CurrentJourneys.FirstOrDefault((TripRecord j) => j.Vehicle.Id == this._selectedVehicle.Id);
			if (tripRecord != null && tripRecord.Encounters.Contains(encounter))
			{
				this.UpdateCurrentShipPage(this._selectedVehicle);
			}
		}
	}

	// Token: 0x06001273 RID: 4723 RVA: 0x0009E67C File Offset: 0x0009CA7C
	public void AddStartLog()
	{
		this.LogPanel.AddStartText();
	}

	// Token: 0x06001274 RID: 4724 RVA: 0x0009E68C File Offset: 0x0009CA8C
	public void UpdateHealth()
	{
		if (this._selectedVehicle != null)
		{
			TripRecord tripRecord = GameWorld.instance.PlayerProfile.CurrentJourneys.FirstOrDefault((TripRecord j) => j.Vehicle.Id == this._selectedVehicle.Id);
			if (tripRecord != null)
			{
				this.ShipInfoPanel.UpdateHealth(tripRecord.CurrentHealth);
			}
		}
	}

	// Token: 0x06001275 RID: 4725 RVA: 0x0009E6DC File Offset: 0x0009CADC
	public void PickTraveller(ITraveller traveller)
	{
		if (this._selectedVehicle != null && !this._isOnTrip)
		{
			if (traveller is AdventurerProfile)
			{
				AdventurerProfile adventurerProfile = traveller as AdventurerProfile;
				if (adventurerProfile.IsInBattle())
				{
					this.DisplayWarningText(UIComponentType.ShipMenuHeroInBattleWarning.GetName());
					return;
				}
			}
			if ((double)this._selectedVehicle.Travellers.Count < this._selectedVehicle.Stats.GetValue(VehicleAttributeType.Capacity) && !this._selectedVehicle.Travellers.Contains(traveller))
			{
				this._selectedVehicle.AddTraveller(traveller);
				this.UpdateCurrentShipPage(this._selectedVehicle);
			}
			else
			{
				this.DisplayWarningText(UIComponentType.ShipMenuShipIsFull.GetName());
			}
		}
	}

	// Token: 0x06001276 RID: 4726 RVA: 0x0009E798 File Offset: 0x0009CB98
	public void UnpickTraveller(ITraveller traveller)
	{
		if (this._selectedVehicle != null && this._selectedVehicle.Travellers.Contains(traveller))
		{
			if (!this._isOnTrip)
			{
				this._selectedVehicle.RemoveTraveller(traveller);
				this.UpdateCurrentShipPage(this._selectedVehicle);
			}
			else
			{
				this.DisplayWarningText(UIComponentType.ShipMenuTravellerIsOnTripWarning.GetName());
			}
		}
	}

	// Token: 0x06001277 RID: 4727 RVA: 0x0009E7FE File Offset: 0x0009CBFE
	public void PreCancelTrip()
	{
		this.CancelTripConfirmPanel.SetActive(true);
	}

	// Token: 0x06001278 RID: 4728 RVA: 0x0009E80C File Offset: 0x0009CC0C
	public void HidePreCancelTripPanel()
	{
		this.CancelTripConfirmPanel.SetActive(false);
	}

	// Token: 0x06001279 RID: 4729 RVA: 0x0009E81C File Offset: 0x0009CC1C
	public void CancelTrip()
	{
		if (this._selectedVehicle != null && this._isOnTrip)
		{
			List<TripRecord> currentJourneys = GameWorld.instance.PlayerProfile.CurrentJourneys;
			TripRecord tripRecord = currentJourneys.FirstOrDefault((TripRecord j) => j.Vehicle.Id == this._selectedVehicle.Id);
			if (tripRecord != null)
			{
				tripRecord.Callback();
				this.ClaimReward(false);
			}
		}
		this.CancelTripConfirmPanel.SetActive(false);
	}

	// Token: 0x0600127A RID: 4730 RVA: 0x0009E884 File Offset: 0x0009CC84
	public void ClaimReward(bool isSucceed = true)
	{
		if (this._selectedVehicle != null && this._isOnTrip)
		{
			List<TripRecord> currentJourneys = GameWorld.instance.PlayerProfile.CurrentJourneys;
			TripRecord tripRecord = currentJourneys.FirstOrDefault((TripRecord j) => j.Vehicle.Id == this._selectedVehicle.Id);
			if (tripRecord != null && tripRecord.Completed && !tripRecord.Claimed)
			{
				tripRecord.ClaimLoots();
				this.RewardPanel.Init(tripRecord.GetLoots(), isSucceed);
				this.RewardPanel.gameObject.SetActive(true);
				this.UpdateCurrentShipPage(this._selectedVehicle);
			}
		}
	}

	// Token: 0x0600127B RID: 4731 RVA: 0x0009E91B File Offset: 0x0009CD1B
	public void TurnOnAutoExplore()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.AutoExplore, true);
		this.AutoExploreButton.SetActive(false);
		this.CloseTooltip();
	}

	// Token: 0x0600127C RID: 4732 RVA: 0x0009E949 File Offset: 0x0009CD49
	public void TurnOffAutoExplope()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.AutoExplore, false);
		this.AutoExploreButton.SetActive(true);
		this.CloseTooltip();
	}

	// Token: 0x0600127D RID: 4733 RVA: 0x0009E978 File Offset: 0x0009CD78
	public void TryAutoExplore(TripRecord record)
	{
		if (this.GetAdditionalData(UIAdditionalDataKey.AutoExplore, false) && !record.Claimed && record.Completed)
		{
			record.ClaimLoots();
			if (base.gameObject.activeSelf && this._selectedVehicle != null && this._selectedVehicle.Id == record.Vehicle.Id)
			{
				this.UpdateCurrentShipPage(this._selectedVehicle);
				this.CompleteTrip(record);
			}
			this.StartJourney(record.Vehicle, record.CurrentDestination);
		}
	}

	// Token: 0x0600127E RID: 4734 RVA: 0x0009EA14 File Offset: 0x0009CE14
	public void SelectToggle(DestinationType type)
	{
		foreach (ShipDestinationToggleController shipDestinationToggleController in this.DestinationToggles)
		{
			if (shipDestinationToggleController.Destination != type)
			{
				shipDestinationToggleController.ToggleTrigger.isOn = false;
			}
		}
		this._selectedDestination = type;
		this.ResetGoButtonStaus();
	}

	// Token: 0x0600127F RID: 4735 RVA: 0x0009EA90 File Offset: 0x0009CE90
	public void DeselectToggle(DestinationType type)
	{
		this._selectedDestination = (DestinationType)0;
		this.ResetGoButtonStaus();
	}

	// Token: 0x06001280 RID: 4736 RVA: 0x0009EA9F File Offset: 0x0009CE9F
	private void ResetGoButtonStaus()
	{
		this.GoTripButton.interactable = (this._selectedDestination != (DestinationType)0 && this._selectedVehicle != null);
	}

	// Token: 0x06001281 RID: 4737 RVA: 0x0009EAC6 File Offset: 0x0009CEC6
	public void DiselectToggle(DestinationType type)
	{
	}

	// Token: 0x06001282 RID: 4738 RVA: 0x0009EAC8 File Offset: 0x0009CEC8
	public void StartJourney()
	{
		this.StartJourney(this._selectedVehicle, this._selectedDestination);
	}

	// Token: 0x06001283 RID: 4739 RVA: 0x0009EADC File Offset: 0x0009CEDC
	private void StartJourney(Vehicle vehicle, DestinationType destination)
	{
		if (GameWorld.instance.PlayerProfile.IsInventoryFull())
		{
			this.DisplayWarningText(UIComponentType.InventoryFullNotify.GetName());
			return;
		}
		if (vehicle != null)
		{
			if ((from traveller in vehicle.Travellers.OfType<AdventurerProfile>()
			select traveller).Any((AdventurerProfile adv) => adv.IsInBattle()))
			{
				this.DisplayWarningText(UIComponentType.AdventurerInBattleWarning.GetName());
				return;
			}
			GameWorld.instance.PlayerProfile.StartTrip(vehicle, destination);
			if (base.gameObject.activeSelf && this._selectedVehicle != null && this._selectedVehicle.Id == vehicle.Id)
			{
				this.UpdateCurrentShipPage(vehicle);
			}
			List<AdventurerProfile> list = new List<AdventurerProfile>();
			foreach (ITraveller traveller2 in vehicle.Travellers)
			{
				if (traveller2 is AdventurerProfile)
				{
					list.Add(traveller2 as AdventurerProfile);
				}
			}
			foreach (BattleTeam battleTeam in GameWorld.instance.PlayerProfile.GetBattleTeams())
			{
				List<AdventurerProfile> list2 = new List<AdventurerProfile>();
				foreach (AdventurerProfile item in battleTeam.Adventurers)
				{
					if (list.Contains(item))
					{
						list2.Add(item);
					}
				}
				foreach (AdventurerProfile item2 in list2)
				{
					battleTeam.Adventurers.Remove(item2);
				}
			}
		}
	}

	// Token: 0x06001284 RID: 4740 RVA: 0x0009ED30 File Offset: 0x0009D130
	[CompilerGenerated]
	private static PageTraveller <OrderTravellerPage>m__0(ITraveller t)
	{
		return new PageTraveller
		{
			Id = t.GetId(),
			Traveller = t,
			Picked = false
		};
	}

	// Token: 0x06001285 RID: 4741 RVA: 0x0009ED5E File Offset: 0x0009D15E
	[CompilerGenerated]
	private bool <AddLog>m__1(TripRecord j)
	{
		return j.Vehicle.Id == this._selectedVehicle.Id;
	}

	// Token: 0x06001286 RID: 4742 RVA: 0x0009ED7B File Offset: 0x0009D17B
	[CompilerGenerated]
	private bool <UpdateHealth>m__2(TripRecord j)
	{
		return j.Vehicle.Id == this._selectedVehicle.Id;
	}

	// Token: 0x06001287 RID: 4743 RVA: 0x0009ED98 File Offset: 0x0009D198
	[CompilerGenerated]
	private bool <CancelTrip>m__3(TripRecord j)
	{
		return j.Vehicle.Id == this._selectedVehicle.Id;
	}

	// Token: 0x06001288 RID: 4744 RVA: 0x0009EDB5 File Offset: 0x0009D1B5
	[CompilerGenerated]
	private bool <ClaimReward>m__4(TripRecord j)
	{
		return j.Vehicle.Id == this._selectedVehicle.Id;
	}

	// Token: 0x06001289 RID: 4745 RVA: 0x0009EDD2 File Offset: 0x0009D1D2
	[CompilerGenerated]
	private static AdventurerProfile <StartJourney>m__5(AdventurerProfile traveller)
	{
		return traveller;
	}

	// Token: 0x0600128A RID: 4746 RVA: 0x0009EDD5 File Offset: 0x0009D1D5
	[CompilerGenerated]
	private static bool <StartJourney>m__6(AdventurerProfile adv)
	{
		return adv.IsInBattle();
	}

	// Token: 0x04001321 RID: 4897
	public ShipMenuInfoController ShipInfoPanel;

	// Token: 0x04001322 RID: 4898
	public ShipLogPanelController LogPanel;

	// Token: 0x04001323 RID: 4899
	public TravellerPaginationController TravellerPage;

	// Token: 0x04001324 RID: 4900
	public SelectedTravellerPanelController SelectedTravellersPanel;

	// Token: 0x04001325 RID: 4901
	public List<ShipDestinationToggleController> DestinationToggles;

	// Token: 0x04001326 RID: 4902
	public ShipMenuTabController ShipTabPre;

	// Token: 0x04001327 RID: 4903
	public Transform ShipTabContrainer;

	// Token: 0x04001328 RID: 4904
	public Button GoTripButton;

	// Token: 0x04001329 RID: 4905
	public GameObject SelectDestinationPanel;

	// Token: 0x0400132A RID: 4906
	public ShipMenuOnTipPanelController DisplayTripDetailsPanel;

	// Token: 0x0400132B RID: 4907
	public ShipMenuRewardsPanelController RewardPanel;

	// Token: 0x0400132C RID: 4908
	public ShipMenuRepairComfirmPanelController RepairComfirmPanel;

	// Token: 0x0400132D RID: 4909
	public TravellerDropdownController TravellerDropdown;

	// Token: 0x0400132E RID: 4910
	public GameObject DestroyBoatComfirmPanel;

	// Token: 0x0400132F RID: 4911
	public GameObject DestroyBoatButton;

	// Token: 0x04001330 RID: 4912
	public GameObject CancelTripConfirmPanel;

	// Token: 0x04001331 RID: 4913
	public GameObject AutoExploreButton;

	// Token: 0x04001332 RID: 4914
	private List<ShipMenuTabController> _shipTabs;

	// Token: 0x04001333 RID: 4915
	private DestinationType _selectedDestination;

	// Token: 0x04001334 RID: 4916
	private Vehicle _selectedVehicle;

	// Token: 0x04001335 RID: 4917
	private bool _isOnTrip;

	// Token: 0x04001336 RID: 4918
	[CompilerGenerated]
	private static Func<ITraveller, PageTraveller> <>f__am$cache0;

	// Token: 0x04001337 RID: 4919
	[CompilerGenerated]
	private static Func<AdventurerProfile, AdventurerProfile> <>f__am$cache1;

	// Token: 0x04001338 RID: 4920
	[CompilerGenerated]
	private static Func<AdventurerProfile, bool> <>f__am$cache2;

	// Token: 0x02000C66 RID: 3174
	[CompilerGenerated]
	private sealed class <Start>c__AnonStorey0
	{
		// Token: 0x060052D5 RID: 21205 RVA: 0x0009EDDD File Offset: 0x0009D1DD
		public <Start>c__AnonStorey0()
		{
		}

		// Token: 0x060052D6 RID: 21206 RVA: 0x0009EDE8 File Offset: 0x0009D1E8
		internal void <>m__0(int A_1)
		{
			this.$this.TravellerDropdown.Init(this.$this.TravellerDropdown.DropdownValues.Single((JourneyContributeTypeDropdownValue d) => d.Value == this.dropdown.value).Type);
			this.$this.OrderTravellerPage();
		}

		// Token: 0x060052D7 RID: 21207 RVA: 0x0009EE36 File Offset: 0x0009D236
		internal bool <>m__1(JourneyContributeTypeDropdownValue d)
		{
			return d.Value == this.dropdown.value;
		}

		// Token: 0x04004093 RID: 16531
		internal TMP_Dropdown dropdown;

		// Token: 0x04004094 RID: 16532
		internal ShipMenuController $this;
	}

	// Token: 0x02000C67 RID: 3175
	[CompilerGenerated]
	private sealed class <UpdateCurrentShipPage>c__AnonStorey1
	{
		// Token: 0x060052D8 RID: 21208 RVA: 0x0009EE4B File Offset: 0x0009D24B
		public <UpdateCurrentShipPage>c__AnonStorey1()
		{
		}

		// Token: 0x060052D9 RID: 21209 RVA: 0x0009EE53 File Offset: 0x0009D253
		internal bool <>m__0(TripRecord j)
		{
			return j.Vehicle.Id == this.vehicle.Id;
		}

		// Token: 0x04004095 RID: 16533
		internal Vehicle vehicle;
	}

	// Token: 0x02000C68 RID: 3176
	[CompilerGenerated]
	private sealed class <OrderJourneyContribute>c__AnonStorey2
	{
		// Token: 0x060052DA RID: 21210 RVA: 0x0009EE70 File Offset: 0x0009D270
		public <OrderJourneyContribute>c__AnonStorey2()
		{
		}

		// Token: 0x060052DB RID: 21211 RVA: 0x0009EE78 File Offset: 0x0009D278
		internal double <>m__0(PageTraveller p)
		{
			JourneyContributionModifier journeyContributionModifier = p.Traveller.GetContributions().FirstOrDefault((JourneyContributionModifier c) => c.Type == this.type);
			if (journeyContributionModifier != null)
			{
				return journeyContributionModifier.Value;
			}
			return 0.0;
		}

		// Token: 0x060052DC RID: 21212 RVA: 0x0009EEB8 File Offset: 0x0009D2B8
		internal bool <>m__1(JourneyContributionModifier c)
		{
			return c.Type == this.type;
		}

		// Token: 0x04004096 RID: 16534
		internal JourneyContributeType type;
	}
}
