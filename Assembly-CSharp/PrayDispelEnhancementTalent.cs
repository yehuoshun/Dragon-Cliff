using System;
using System.Collections.Generic;

// Token: 0x020003F1 RID: 1009
[Serializable]
public class PrayDispelEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001B89 RID: 7049 RVA: 0x000C32EF File Offset: 0x000C16EF
	public PrayDispelEnhancementTalent()
	{
	}

	// Token: 0x06001B8A RID: 7050 RVA: 0x000C32F7 File Offset: 0x000C16F7
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.PrayDispelEnhancement;
	}

	// Token: 0x06001B8B RID: 7051 RVA: 0x000C32FB File Offset: 0x000C16FB
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001B8C RID: 7052 RVA: 0x000C32FE File Offset: 0x000C16FE
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001B8D RID: 7053 RVA: 0x000C3306 File Offset: 0x000C1706
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001B8E RID: 7054 RVA: 0x000C330E File Offset: 0x000C170E
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001B8F RID: 7055 RVA: 0x000C3316 File Offset: 0x000C1716
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001B90 RID: 7056 RVA: 0x000C3319 File Offset: 0x000C1719
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001B91 RID: 7057 RVA: 0x000C3329 File Offset: 0x000C1729
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001B92 RID: 7058 RVA: 0x000C3339 File Offset: 0x000C1739
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B93 RID: 7059 RVA: 0x000C3342 File Offset: 0x000C1742
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001B94 RID: 7060 RVA: 0x000C3349 File Offset: 0x000C1749
	// Note: this type is marked as 'beforefieldinit'.
	static PrayDispelEnhancementTalent()
	{
	}

	// Token: 0x04001A43 RID: 6723
	public string Id;

	// Token: 0x04001A44 RID: 6724
	public string AdditionalKey;

	// Token: 0x04001A45 RID: 6725
	public int CurrentLevel;

	// Token: 0x04001A46 RID: 6726
	public static double Chance = 1.0;

	// Token: 0x04001A47 RID: 6727
	public static int DispelCounts = 2;
}
