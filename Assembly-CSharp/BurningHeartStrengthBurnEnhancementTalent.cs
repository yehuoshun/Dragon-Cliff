using System;
using System.Collections.Generic;

// Token: 0x020003BF RID: 959
[Serializable]
public class BurningHeartStrengthBurnEnhancementTalent : IAdventurerTalent
{
	// Token: 0x060019AF RID: 6575 RVA: 0x000C0D7D File Offset: 0x000BF17D
	public BurningHeartStrengthBurnEnhancementTalent()
	{
	}

	// Token: 0x060019B0 RID: 6576 RVA: 0x000C0D85 File Offset: 0x000BF185
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.BurningHeartStrengthBurnEnhancement;
	}

	// Token: 0x060019B1 RID: 6577 RVA: 0x000C0D89 File Offset: 0x000BF189
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x060019B2 RID: 6578 RVA: 0x000C0D8C File Offset: 0x000BF18C
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x060019B3 RID: 6579 RVA: 0x000C0D94 File Offset: 0x000BF194
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x060019B4 RID: 6580 RVA: 0x000C0D9C File Offset: 0x000BF19C
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x060019B5 RID: 6581 RVA: 0x000C0DA4 File Offset: 0x000BF1A4
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x060019B6 RID: 6582 RVA: 0x000C0DA7 File Offset: 0x000BF1A7
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x060019B7 RID: 6583 RVA: 0x000C0DB7 File Offset: 0x000BF1B7
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x060019B8 RID: 6584 RVA: 0x000C0DC7 File Offset: 0x000BF1C7
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x060019B9 RID: 6585 RVA: 0x000C0DD0 File Offset: 0x000BF1D0
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x04001981 RID: 6529
	public string Id;

	// Token: 0x04001982 RID: 6530
	public string AdditionalKey;

	// Token: 0x04001983 RID: 6531
	public int CurrentLevel;
}
