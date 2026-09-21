using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000292 RID: 658
public class SlotPanelsController : MonoBehaviour
{
	// Token: 0x06001195 RID: 4501 RVA: 0x0009BBCF File Offset: 0x00099FCF
	public SlotPanelsController()
	{
	}

	// Token: 0x06001196 RID: 4502 RVA: 0x0009BBD7 File Offset: 0x00099FD7
	private void Awake()
	{
		SlotPanelsController.Instance = this;
		this._raycastImage = base.GetComponent<Image>();
	}

	// Token: 0x06001197 RID: 4503 RVA: 0x0009BBEB File Offset: 0x00099FEB
	public void SelectBuilding(BuildingType selectedBuilding)
	{
		this._buildingType = selectedBuilding;
		this.DisplayAvailableSlots();
	}

	// Token: 0x06001198 RID: 4504 RVA: 0x0009BBFA File Offset: 0x00099FFA
	public void SelectSlot(TownSlot selectedSlot)
	{
		GameWorld.instance.PlayerProfile.Build(this._buildingType, selectedSlot);
		this.StopDisplayingSlots();
	}

	// Token: 0x06001199 RID: 4505 RVA: 0x0009BC18 File Offset: 0x0009A018
	public void DisplayAvailableSlots()
	{
		List<TownSlot> list = (from b in GameWorld.instance.PlayerProfile.Buildings
		where b.Value == null
		select b.Key).ToList<TownSlot>();
		foreach (SlotFlashingPanel slotFlashingPanel in this.Panels)
		{
			if (list.Contains(slotFlashingPanel.Slot))
			{
				slotFlashingPanel.gameObject.SetActive(true);
				slotFlashingPanel.Flash();
				TownManager.Instance.Ui.ShowMainUi(false);
				this._raycastImage.raycastTarget = true;
			}
		}
		this.CancelButton.SetActive(true);
	}

	// Token: 0x0600119A RID: 4506 RVA: 0x0009BD14 File Offset: 0x0009A114
	public void StopDisplayingSlots()
	{
		this.Panels.ForEach(delegate(SlotFlashingPanel p)
		{
			this._buildingType = BuildingType.None;
			p.StopFlashing();
			p.gameObject.SetActive(false);
			TownManager.Instance.Ui.ShowMainUi(true);
			this._raycastImage.raycastTarget = false;
		});
		this.CancelButton.SetActive(false);
	}

	// Token: 0x0600119B RID: 4507 RVA: 0x0009BD39 File Offset: 0x0009A139
	[CompilerGenerated]
	private static bool <DisplayAvailableSlots>m__0(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Value == null;
	}

	// Token: 0x0600119C RID: 4508 RVA: 0x0009BD45 File Offset: 0x0009A145
	[CompilerGenerated]
	private static TownSlot <DisplayAvailableSlots>m__1(KeyValuePair<TownSlot, IBuildingProfile> b)
	{
		return b.Key;
	}

	// Token: 0x0600119D RID: 4509 RVA: 0x0009BD4E File Offset: 0x0009A14E
	[CompilerGenerated]
	private void <StopDisplayingSlots>m__2(SlotFlashingPanel p)
	{
		this._buildingType = BuildingType.None;
		p.StopFlashing();
		p.gameObject.SetActive(false);
		TownManager.Instance.Ui.ShowMainUi(true);
		this._raycastImage.raycastTarget = false;
	}

	// Token: 0x0400126A RID: 4714
	public static SlotPanelsController Instance;

	// Token: 0x0400126B RID: 4715
	public List<SlotFlashingPanel> Panels;

	// Token: 0x0400126C RID: 4716
	public GameObject CancelButton;

	// Token: 0x0400126D RID: 4717
	private BuildingType _buildingType;

	// Token: 0x0400126E RID: 4718
	private Image _raycastImage;

	// Token: 0x0400126F RID: 4719
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, bool> <>f__am$cache0;

	// Token: 0x04001270 RID: 4720
	[CompilerGenerated]
	private static Func<KeyValuePair<TownSlot, IBuildingProfile>, TownSlot> <>f__am$cache1;
}
