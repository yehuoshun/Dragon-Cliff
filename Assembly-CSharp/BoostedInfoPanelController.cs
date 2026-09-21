using System;
using UnityEngine;

// Token: 0x02000162 RID: 354
public class BoostedInfoPanelController : MonoBehaviour
{
	// Token: 0x0600096F RID: 2415 RVA: 0x0007AFF5 File Offset: 0x000793F5
	public BoostedInfoPanelController()
	{
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x0007AFFD File Offset: 0x000793FD
	private void Start()
	{
		this.UpdateStats();
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x0007B005 File Offset: 0x00079405
	private void Update()
	{
		this.UpdateStats();
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x0007B010 File Offset: 0x00079410
	public void UpdateStats()
	{
		PlayerTownStatsSummary townStats = GameWorld.instance.PlayerProfile.GetTownStats();
		this.ProductoinItem.Init(townStats.TotalProductionIncreaseRate, townStats.TotalProductionIncreaseRateExceeded, PlayerProfile.MaxProductionRate);
		this.DropItem.Init(townStats.TotalItemDropBoostRate, townStats.TotalItemDropBoostRateExceeded, PlayerProfile.MaxItemQualityBoostRate);
		this.ChestItem.Init(townStats.TotalChestBoostRate, townStats.TotalChestBoostRateExceeded, PlayerProfile.MaxChestBoost);
		this.PracticePointItem.Init(townStats.TotalPracticePointsBoost, townStats.TotalPracticePointsBoostExceeded, PlayerProfile.MaxPracticePointsBoost);
		this.WeaponPriceItem.Init(townStats.WeaponPriceBoost, townStats.WeaponPriceBoostExceeded, PlayerProfile.MaxReisdentPriceBoost);
		this.ArmorPriceItem.Init(townStats.ArmorPriceBoost, townStats.ArmorPriceBoostExceeded, PlayerProfile.MaxReisdentPriceBoost);
	}

	// Token: 0x04000C1D RID: 3101
	public BoostedItemController ProductoinItem;

	// Token: 0x04000C1E RID: 3102
	public BoostedItemController DropItem;

	// Token: 0x04000C1F RID: 3103
	public BoostedItemController ChestItem;

	// Token: 0x04000C20 RID: 3104
	public BoostedItemController PracticePointItem;

	// Token: 0x04000C21 RID: 3105
	public BoostedItemController WeaponPriceItem;

	// Token: 0x04000C22 RID: 3106
	public BoostedItemController ArmorPriceItem;
}
