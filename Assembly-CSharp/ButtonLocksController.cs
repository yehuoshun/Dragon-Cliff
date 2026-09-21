using System;
using UnityEngine;

// Token: 0x02000265 RID: 613
public class ButtonLocksController : MonoBehaviour
{
	// Token: 0x06000FE1 RID: 4065 RVA: 0x000964F8 File Offset: 0x000948F8
	public ButtonLocksController()
	{
	}

	// Token: 0x06000FE2 RID: 4066 RVA: 0x00096500 File Offset: 0x00094900
	private void Update()
	{
		if (!this._furnaceBreakUnlocked)
		{
			bool flag = ResourceType.GrindingTable.HasObtained();
			this.FurnaceBreakLock.SetActive(!flag);
			this._furnaceBreakUnlocked = flag;
		}
		if (!this._furnaceScrollUnlocked)
		{
			bool flag2 = ResourceType.BluePrintOfScrolls.HasObtained();
			this.FurnaceTransferLock.SetActive(!flag2);
			this.HeroScrollLock.SetActive(!flag2);
			this.FurnanceScrollLock.SetActive(!flag2);
			this.SchoolLock.SetActive(!flag2);
			this.InventoryScrollTab.SetActive(flag2);
			this._furnaceScrollUnlocked = flag2;
		}
		if (!this._deviceUnlocked)
		{
			bool flag3 = GameWorld.instance.PlayerProfile.GetStarRating() >= 2 || GameWorld.instance.PlayerProfile.GetTitle() >= TownTitleType.SalvationOfHeaven;
			this.FurnanceDeviceLock.SetActive(!flag3);
			this.InventoryDeviceTab.SetActive(flag3);
			this.DeviceLock.SetActive(!flag3);
			this._deviceUnlocked = flag3;
		}
		if (!this._autoTacticUnlocked)
		{
			bool flag4 = GameWorld.instance.PlayerProfile.GetStarRating() >= 2 || GameWorld.instance.PlayerProfile.GetTitle() >= TownTitleType.RomaticRumors;
			this.AutoTacticPanel.SetActive(flag4);
			this.AutoTacticLock.SetActive(!flag4);
			this._autoTacticUnlocked = flag4;
		}
		if (!this._explorationUnlocked)
		{
			bool flag5 = GameWorld.instance.PlayerProfile.ExplorationEnabled();
			this.ExplorationLock.SetActive(!flag5);
			this.AutoHireResidentLock.SetActive(!flag5);
			this.BoatManObj.SetActive(flag5);
			this._explorationUnlocked = flag5;
		}
		if (!this._endlessEntryUnlocked)
		{
			bool flag6 = GameWorld.instance.PlayerProfile.EndlessDungeonIsEnabled();
			this.EndlessEntry.SetActive(flag6);
			this.AmuletLock.SetActive(!flag6);
			this.InventoryAmuletTab.SetActive(flag6);
			this.AshOfHopeText.SetActive(flag6);
			this._endlessEntryUnlocked = flag6;
		}
		if (!this._autoAdventureUnlocked)
		{
			bool flag7 = GameWorld.instance.PlayerProfile.GetStarRating() >= 2 || GameWorld.instance.PlayerProfile.GetProgress(null).Reputation >= 500.0;
			this.AutoAdventureToggle.SetActive(flag7);
			this._autoAdventureUnlocked = flag7;
		}
	}

	// Token: 0x04001110 RID: 4368
	public GameObject FurnaceBreakLock;

	// Token: 0x04001111 RID: 4369
	public GameObject FurnaceTransferLock;

	// Token: 0x04001112 RID: 4370
	public GameObject HeroScrollLock;

	// Token: 0x04001113 RID: 4371
	public GameObject FurnanceScrollLock;

	// Token: 0x04001114 RID: 4372
	public GameObject FurnanceDeviceLock;

	// Token: 0x04001115 RID: 4373
	public GameObject SchoolLock;

	// Token: 0x04001116 RID: 4374
	public GameObject ExplorationLock;

	// Token: 0x04001117 RID: 4375
	public GameObject AutoHireResidentLock;

	// Token: 0x04001118 RID: 4376
	public GameObject BoatManObj;

	// Token: 0x04001119 RID: 4377
	public GameObject InventoryScrollTab;

	// Token: 0x0400111A RID: 4378
	public GameObject InventoryAmuletTab;

	// Token: 0x0400111B RID: 4379
	public GameObject InventoryDeviceTab;

	// Token: 0x0400111C RID: 4380
	public GameObject EndlessEntry;

	// Token: 0x0400111D RID: 4381
	public GameObject AshOfHopeText;

	// Token: 0x0400111E RID: 4382
	public GameObject AutoAdventureToggle;

	// Token: 0x0400111F RID: 4383
	public GameObject AutoTacticPanel;

	// Token: 0x04001120 RID: 4384
	public GameObject AutoTacticLock;

	// Token: 0x04001121 RID: 4385
	public GameObject AmuletLock;

	// Token: 0x04001122 RID: 4386
	public GameObject DeviceLock;

	// Token: 0x04001123 RID: 4387
	private bool _furnaceScrollUnlocked;

	// Token: 0x04001124 RID: 4388
	private bool _furnaceBreakUnlocked;

	// Token: 0x04001125 RID: 4389
	private bool _explorationUnlocked;

	// Token: 0x04001126 RID: 4390
	private bool _endlessEntryUnlocked;

	// Token: 0x04001127 RID: 4391
	private bool _autoAdventureUnlocked;

	// Token: 0x04001128 RID: 4392
	private bool _autoTacticUnlocked;

	// Token: 0x04001129 RID: 4393
	private bool _deviceUnlocked;
}
