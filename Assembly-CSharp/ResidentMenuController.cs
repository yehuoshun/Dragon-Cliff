using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200024E RID: 590
public class ResidentMenuController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000F3C RID: 3900 RVA: 0x00093961 File Offset: 0x00091D61
	public ResidentMenuController()
	{
	}

	// Token: 0x06000F3D RID: 3901 RVA: 0x00093969 File Offset: 0x00091D69
	private void Start()
	{
		this.SortingDropdown.Dropdown.onValueChanged.AddListener(delegate(int A_1)
		{
			ResidentEffectType type = this.SortingDropdown.DropdownValues.Single((ResidentEffectDropdownValue d) => d.Value == this.SortingDropdown.Dropdown.value).Type;
			this.OrderResidents(type);
		});
		this.OnCandidate();
	}

	// Token: 0x06000F3E RID: 3902 RVA: 0x00093992 File Offset: 0x00091D92
	private void OnEnable()
	{
		this.Init();
		TownManager.Instance.Slots.GetComponentInChildren<CityTownController>().HideNewResidentIcon();
		if (this.SavedCandidatePanel.gameObject.activeSelf)
		{
			this.SavedCandidateDot.SetActive(false);
		}
	}

	// Token: 0x06000F3F RID: 3903 RVA: 0x000939CF File Offset: 0x00091DCF
	private void OnDisable()
	{
		this.FireComfirmPanel.gameObject.SetActive(false);
		this._selectedCandidate = null;
		this.CloseOperationPanels();
	}

	// Token: 0x06000F40 RID: 3904 RVA: 0x000939F0 File Offset: 0x00091DF0
	public void Init()
	{
		PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
		this.ResidentPanel.Init(playerProfile.Residents, true);
		this.CandidatePanel.Init((from c in playerProfile.Candidates
		select c.Candidate).ToList<Resident>(), false);
		this.UnlockNewSlotButton.interactable = GameWorld.instance.PlayerProfile.CanUnlockResidentSlot();
		int maxNumberOfResidents = playerProfile.GetMaxNumberOfResidents();
		this.ResidentAmountText.text = string.Concat(new object[]
		{
			"(",
			playerProfile.Residents.Count,
			"/",
			maxNumberOfResidents,
			")"
		});
		this.ResidentAmountText.color = ColorPicker.GetPosNegColor(maxNumberOfResidents - playerProfile.Residents.Count);
		this.ResidentPanel.OrderItems(this.SortingDropdown.GetSlectedOrderType());
	}

	// Token: 0x06000F41 RID: 3905 RVA: 0x00093AF4 File Offset: 0x00091EF4
	public void AddNewResidents(List<ResidentCandidate> residents)
	{
		foreach (ResidentCandidate residentCandidate in residents)
		{
			this.ResidentPanel.AddNew(residentCandidate.Candidate, true);
		}
	}

	// Token: 0x06000F42 RID: 3906 RVA: 0x00093B58 File Offset: 0x00091F58
	public void RemoveResident(Resident resident)
	{
		this.ResidentPanel.Remove(resident.Id, true);
	}

	// Token: 0x06000F43 RID: 3907 RVA: 0x00093B6C File Offset: 0x00091F6C
	public void AddNewCandidates(List<ResidentCandidate> candidates)
	{
		foreach (ResidentCandidate residentCandidate in candidates)
		{
			this.CandidatePanel.AddNew(residentCandidate.Candidate, false);
		}
	}

	// Token: 0x06000F44 RID: 3908 RVA: 0x00093BD0 File Offset: 0x00091FD0
	public void RemoveCandidate(ResidentCandidate candidate)
	{
		this.ResidentPanel.Remove(candidate.Candidate.Id, false);
	}

	// Token: 0x06000F45 RID: 3909 RVA: 0x00093BEC File Offset: 0x00091FEC
	private IEnumerator TryOrderItem()
	{
		yield return new WaitForEndOfFrame();
		this.ResidentPanel.OrderItems(this.SortingDropdown.GetSlectedOrderType());
		yield break;
	}

	// Token: 0x06000F46 RID: 3910 RVA: 0x00093C08 File Offset: 0x00092008
	public void OnCandidate()
	{
		this.CandidateTab.interactable = false;
		this.SavedCandidateTab.interactable = true;
		this.CandidatePanel.gameObject.SetActive(true);
		this.SavedCandidatePanel.gameObject.SetActive(false);
		this.CandidateTitle.SetActive(true);
		this.SavedCandidateTitle.SetActive(false);
		this.StoredCandidateTogglePanel.SetActive(false);
		this.CloseOperationPanels();
	}

	// Token: 0x06000F47 RID: 3911 RVA: 0x00093C7C File Offset: 0x0009207C
	public void OnSavedCandidate()
	{
		this.CandidateTab.interactable = true;
		this.SavedCandidateTab.interactable = false;
		this.CandidatePanel.gameObject.SetActive(false);
		this.SavedCandidatePanel.gameObject.SetActive(true);
		this.SavedCandidateDot.SetActive(false);
		this.CandidateTitle.SetActive(false);
		this.SavedCandidateTitle.SetActive(true);
		this.StoredCandidateTogglePanel.SetActive(true);
		this.CloseOperationPanels();
	}

	// Token: 0x06000F48 RID: 3912 RVA: 0x00093CFC File Offset: 0x000920FC
	public void UpdateCandidateList()
	{
		PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
		this.CandidatePanel.Init((from c in playerProfile.Candidates
		select c.Candidate).ToList<Resident>(), false);
	}

	// Token: 0x06000F49 RID: 3913 RVA: 0x00093D4D File Offset: 0x0009214D
	private void OrderResidents(ResidentEffectType type)
	{
		this.SortingDropdown.Init(type);
		this.ResidentPanel.OrderItems(type);
	}

	// Token: 0x06000F4A RID: 3914 RVA: 0x00093D67 File Offset: 0x00092167
	public void UnlockNewSlot()
	{
		GameWorld.instance.PlayerProfile.UnlockResidentSlot();
		this.Init();
		this.OnMouseOverUnlockButton();
	}

	// Token: 0x06000F4B RID: 3915 RVA: 0x00093D84 File Offset: 0x00092184
	public void OnMouseOverUnlockButton()
	{
		string description = string.Empty;
		if (GameWorld.instance.PlayerProfile.NumberOfResidentSlots < PlayerProfile.MaxResidentSlot)
		{
			description = UIComponentType.ResidentMenuConsumeTitle.GetName() + ": " + GameWorld.instance.PlayerProfile.GetResidentSlotUnlockCost().ToGameCurrency();
		}
		else
		{
			description = UIComponentType.ResidentMenuReachedMaxSlot.GetName();
		}
		this.OpenTooltip(new TooltipItem
		{
			Title = UIComponentType.ResidentMenuUnlockNewSlot.GetName(),
			Description = description,
			Position = this.UnlockNewSlotButton.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000F4C RID: 3916 RVA: 0x00093E2F File Offset: 0x0009222F
	public void OnMouseExitUnlockButton()
	{
		this.CloseTooltip();
	}

	// Token: 0x06000F4D RID: 3917 RVA: 0x00093E37 File Offset: 0x00092237
	public void ShowStoredCandidateOperationPanel(Resident selectedCandidate, Vector3 position)
	{
		if (selectedCandidate == null)
		{
			return;
		}
		this._selectedCandidate = selectedCandidate;
		this.StoredCandidateOperationPanel.transform.position = position;
		this.CloseOperationPanels();
		this.StoredCandidateOperationPanel.SetActive(true);
	}

	// Token: 0x06000F4E RID: 3918 RVA: 0x00093E6A File Offset: 0x0009226A
	public void ShowCandidateOperationPanel(Resident selectedCandidate, Vector3 position)
	{
		if (selectedCandidate == null)
		{
			return;
		}
		this._selectedCandidate = selectedCandidate;
		this.CandidateOperationPanel.transform.position = position;
		this.CloseOperationPanels();
		this.CandidateOperationPanel.SetActive(true);
	}

	// Token: 0x06000F4F RID: 3919 RVA: 0x00093E9D File Offset: 0x0009229D
	public void PreApprove()
	{
		this.ApproveComfirmPanel.SetActive(true);
		this.CandidateOperationPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000F50 RID: 3920 RVA: 0x00093EBC File Offset: 0x000922BC
	public void Approve()
	{
		if (this._selectedCandidate == null)
		{
			return;
		}
		PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
		if (playerProfile.Residents.Count < playerProfile.GetMaxNumberOfResidents())
		{
			ResidentCandidate candidate = GameWorld.instance.PlayerProfile.Candidates.FirstOrDefault((ResidentCandidate c) => c.Candidate.Id == this._selectedCandidate.Id);
			GameWorld.instance.PlayerProfile.AddNewResidents(candidate);
			this.Init();
		}
		else
		{
			this.DisplayWarningText(UIComponentType.ResidentMenuNoVacancyWarning.GetName());
		}
		this._selectedCandidate = null;
		this.CloseOperationPanels();
		this.ApproveComfirmPanel.SetActive(false);
	}

	// Token: 0x06000F51 RID: 3921 RVA: 0x00093F5B File Offset: 0x0009235B
	public void DeleteStoredCandidate()
	{
		if (this._selectedCandidate == null)
		{
			return;
		}
		GameWorld.instance.PlayerProfile.RemoveStoredCandidate(this._selectedCandidate.Id);
		this.SavedCandidatePanel.Init();
		this.CloseOperationPanels();
	}

	// Token: 0x06000F52 RID: 3922 RVA: 0x00093F94 File Offset: 0x00092394
	public void ApproveStoredCandidate()
	{
		if (this._selectedCandidate == null)
		{
			return;
		}
		PlayerProfile playerProfile = GameWorld.instance.PlayerProfile;
		if (playerProfile.Residents.Count < playerProfile.GetMaxNumberOfResidents())
		{
			ResidentCandidate candidate = GameWorld.instance.PlayerProfile.StoredCandidates.FirstOrDefault((ResidentCandidate c) => c.Candidate.Id == this._selectedCandidate.Id);
			GameWorld.instance.PlayerProfile.AddNewResidentFromStoredCandidate(candidate);
			this.Init();
			this.SavedCandidatePanel.Init();
		}
		else
		{
			this.DisplayWarningText(UIComponentType.ResidentMenuNoVacancyWarning.GetName());
		}
		this._selectedCandidate = null;
		this.CloseOperationPanels();
		this.ApproveComfirmPanel.SetActive(false);
	}

	// Token: 0x06000F53 RID: 3923 RVA: 0x0009403E File Offset: 0x0009243E
	public void ShowResidentOperationPanel(Resident selectedResident, Vector3 position)
	{
		if (selectedResident == null)
		{
			return;
		}
		this._selectedCandidate = selectedResident;
		this.ResidentOperationPanel.transform.position = position;
		this.CloseOperationPanels();
		this.ResidentOperationPanel.SetActive(true);
	}

	// Token: 0x06000F54 RID: 3924 RVA: 0x00094071 File Offset: 0x00092471
	public void Kickout()
	{
		this.Kickout(this._selectedCandidate);
		this.ResidentOperationPanel.SetActive(false);
	}

	// Token: 0x06000F55 RID: 3925 RVA: 0x0009408B File Offset: 0x0009248B
	public void Kickout(Resident resident)
	{
		if (resident == null)
		{
			return;
		}
		this.FireComfirmPanel.Init(resident);
		this.FireComfirmPanel.gameObject.SetActive(true);
	}

	// Token: 0x06000F56 RID: 3926 RVA: 0x000940B4 File Offset: 0x000924B4
	public void ComfirmKickout(Resident resident)
	{
		List<ITraveller> currentTravellers = GameWorld.instance.PlayerProfile.GetCurrentTravellers();
		if (currentTravellers.Any((ITraveller t) => t is Resident && ((Resident)t).Id == resident.Id))
		{
			this.DisplayWarningText(UIComponentType.ResidentMenuFireResidentOnTripWarning.GetName());
		}
		else
		{
			GameWorld.instance.PlayerProfile.RemoveFiredTraveller(resident);
			GameWorld.instance.PlayerProfile.RemoveResident(resident.Id);
			this.Init();
		}
		this.CloseOperationPanels();
		this.FireComfirmPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000F57 RID: 3927 RVA: 0x00094156 File Offset: 0x00092556
	public void CloseFireComfirmPanel()
	{
		this.FireComfirmPanel.gameObject.SetActive(false);
	}

	// Token: 0x06000F58 RID: 3928 RVA: 0x00094169 File Offset: 0x00092569
	public void CloseApproveComfirmPanel()
	{
		this.ApproveComfirmPanel.SetActive(false);
	}

	// Token: 0x06000F59 RID: 3929 RVA: 0x00094177 File Offset: 0x00092577
	public void OnPointerClick(PointerEventData eventData)
	{
		this.CloseOperationPanels();
	}

	// Token: 0x06000F5A RID: 3930 RVA: 0x0009417F File Offset: 0x0009257F
	private void CloseOperationPanels()
	{
		this.StoredCandidateOperationPanel.SetActive(false);
		this.CandidateOperationPanel.SetActive(false);
		this.ResidentOperationPanel.SetActive(false);
	}

	// Token: 0x06000F5B RID: 3931 RVA: 0x000941A8 File Offset: 0x000925A8
	[CompilerGenerated]
	private void <Start>m__0(int A_1)
	{
		ResidentEffectType type = this.SortingDropdown.DropdownValues.Single((ResidentEffectDropdownValue d) => d.Value == this.SortingDropdown.Dropdown.value).Type;
		this.OrderResidents(type);
	}

	// Token: 0x06000F5C RID: 3932 RVA: 0x000941DE File Offset: 0x000925DE
	[CompilerGenerated]
	private static Resident <Init>m__1(ResidentCandidate c)
	{
		return c.Candidate;
	}

	// Token: 0x06000F5D RID: 3933 RVA: 0x000941E6 File Offset: 0x000925E6
	[CompilerGenerated]
	private static Resident <UpdateCandidateList>m__2(ResidentCandidate c)
	{
		return c.Candidate;
	}

	// Token: 0x06000F5E RID: 3934 RVA: 0x000941EE File Offset: 0x000925EE
	[CompilerGenerated]
	private bool <Approve>m__3(ResidentCandidate c)
	{
		return c.Candidate.Id == this._selectedCandidate.Id;
	}

	// Token: 0x06000F5F RID: 3935 RVA: 0x0009420B File Offset: 0x0009260B
	[CompilerGenerated]
	private bool <ApproveStoredCandidate>m__4(ResidentCandidate c)
	{
		return c.Candidate.Id == this._selectedCandidate.Id;
	}

	// Token: 0x06000F60 RID: 3936 RVA: 0x00094228 File Offset: 0x00092628
	[CompilerGenerated]
	private bool <Start>m__5(ResidentEffectDropdownValue d)
	{
		return d.Value == this.SortingDropdown.Dropdown.value;
	}

	// Token: 0x0400109C RID: 4252
	public ResidentPanelController ResidentPanel;

	// Token: 0x0400109D RID: 4253
	public ResidentPanelController CandidatePanel;

	// Token: 0x0400109E RID: 4254
	public StoredCandidatesPanelController SavedCandidatePanel;

	// Token: 0x0400109F RID: 4255
	public GameObject CandidateOperationPanel;

	// Token: 0x040010A0 RID: 4256
	public GameObject ResidentOperationPanel;

	// Token: 0x040010A1 RID: 4257
	public GameObject StoredCandidateOperationPanel;

	// Token: 0x040010A2 RID: 4258
	public Button UnlockNewSlotButton;

	// Token: 0x040010A3 RID: 4259
	public Button CandidateTab;

	// Token: 0x040010A4 RID: 4260
	public Button SavedCandidateTab;

	// Token: 0x040010A5 RID: 4261
	public GameObject CandidateTitle;

	// Token: 0x040010A6 RID: 4262
	public GameObject SavedCandidateTitle;

	// Token: 0x040010A7 RID: 4263
	public GameObject SavedCandidateDot;

	// Token: 0x040010A8 RID: 4264
	public GameObject StoredCandidateTogglePanel;

	// Token: 0x040010A9 RID: 4265
	public TextMeshProUGUI ResidentAmountText;

	// Token: 0x040010AA RID: 4266
	public FireResidentPanelController FireComfirmPanel;

	// Token: 0x040010AB RID: 4267
	public GameObject ApproveComfirmPanel;

	// Token: 0x040010AC RID: 4268
	public ResidentDropdownController SortingDropdown;

	// Token: 0x040010AD RID: 4269
	private Resident _selectedCandidate;

	// Token: 0x040010AE RID: 4270
	[CompilerGenerated]
	private static Func<ResidentCandidate, Resident> <>f__am$cache0;

	// Token: 0x040010AF RID: 4271
	[CompilerGenerated]
	private static Func<ResidentCandidate, Resident> <>f__am$cache1;

	// Token: 0x02000C51 RID: 3153
	[CompilerGenerated]
	private sealed class <TryOrderItem>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005299 RID: 21145 RVA: 0x00094242 File Offset: 0x00092642
		[DebuggerHidden]
		public <TryOrderItem>c__Iterator0()
		{
		}

		// Token: 0x0600529A RID: 21146 RVA: 0x0009424C File Offset: 0x0009264C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForEndOfFrame();
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.ResidentPanel.OrderItems(this.SortingDropdown.GetSlectedOrderType());
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x17001198 RID: 4504
		// (get) Token: 0x0600529B RID: 21147 RVA: 0x000942C3 File Offset: 0x000926C3
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001199 RID: 4505
		// (get) Token: 0x0600529C RID: 21148 RVA: 0x000942CB File Offset: 0x000926CB
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600529D RID: 21149 RVA: 0x000942D3 File Offset: 0x000926D3
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x0600529E RID: 21150 RVA: 0x000942E3 File Offset: 0x000926E3
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04004074 RID: 16500
		internal ResidentMenuController $this;

		// Token: 0x04004075 RID: 16501
		internal object $current;

		// Token: 0x04004076 RID: 16502
		internal bool $disposing;

		// Token: 0x04004077 RID: 16503
		internal int $PC;
	}

	// Token: 0x02000C52 RID: 3154
	[CompilerGenerated]
	private sealed class <ComfirmKickout>c__AnonStorey1
	{
		// Token: 0x0600529F RID: 21151 RVA: 0x000942EA File Offset: 0x000926EA
		public <ComfirmKickout>c__AnonStorey1()
		{
		}

		// Token: 0x060052A0 RID: 21152 RVA: 0x000942F2 File Offset: 0x000926F2
		internal bool <>m__0(ITraveller t)
		{
			return t is Resident && ((Resident)t).Id == this.resident.Id;
		}

		// Token: 0x04004078 RID: 16504
		internal Resident resident;
	}
}
