using System;
using System.Collections.Generic;

// Token: 0x020003BE RID: 958
[Serializable]
public class BurningHeartDispelEnhancementTalent : IAdventurerTalent
{
	// Token: 0x060019A3 RID: 6563 RVA: 0x000C0D0D File Offset: 0x000BF10D
	public BurningHeartDispelEnhancementTalent()
	{
	}

	// Token: 0x060019A4 RID: 6564 RVA: 0x000C0D15 File Offset: 0x000BF115
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.BurningHeartDispelEnhancement;
	}

	// Token: 0x060019A5 RID: 6565 RVA: 0x000C0D19 File Offset: 0x000BF119
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x060019A6 RID: 6566 RVA: 0x000C0D1C File Offset: 0x000BF11C
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x060019A7 RID: 6567 RVA: 0x000C0D24 File Offset: 0x000BF124
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x060019A8 RID: 6568 RVA: 0x000C0D2C File Offset: 0x000BF12C
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x060019A9 RID: 6569 RVA: 0x000C0D34 File Offset: 0x000BF134
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x060019AA RID: 6570 RVA: 0x000C0D37 File Offset: 0x000BF137
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x060019AB RID: 6571 RVA: 0x000C0D47 File Offset: 0x000BF147
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x060019AC RID: 6572 RVA: 0x000C0D57 File Offset: 0x000BF157
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x060019AD RID: 6573 RVA: 0x000C0D60 File Offset: 0x000BF160
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x060019AE RID: 6574 RVA: 0x000C0D67 File Offset: 0x000BF167
	// Note: this type is marked as 'beforefieldinit'.
	static BurningHeartDispelEnhancementTalent()
	{
	}

	// Token: 0x0400197C RID: 6524
	public string Id;

	// Token: 0x0400197D RID: 6525
	public string AdditionalKey;

	// Token: 0x0400197E RID: 6526
	public int CurrentLevel;

	// Token: 0x0400197F RID: 6527
	public static int NumberOfDispels = 1;

	// Token: 0x04001980 RID: 6528
	public static double Chance = 0.6;
}
