using System;
using System.Collections.Generic;

// Token: 0x02000407 RID: 1031
[Serializable]
public class ShadowSacrificeHealOnExpTalent : IAdventurerTalent
{
	// Token: 0x06001C43 RID: 7235 RVA: 0x000C3FD4 File Offset: 0x000C23D4
	public ShadowSacrificeHealOnExpTalent()
	{
	}

	// Token: 0x06001C44 RID: 7236 RVA: 0x000C3FDC File Offset: 0x000C23DC
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ShadowSacrificeHealOnExplo;
	}

	// Token: 0x06001C45 RID: 7237 RVA: 0x000C3FE0 File Offset: 0x000C23E0
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001C46 RID: 7238 RVA: 0x000C3FE3 File Offset: 0x000C23E3
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001C47 RID: 7239 RVA: 0x000C3FEB File Offset: 0x000C23EB
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001C48 RID: 7240 RVA: 0x000C3FF3 File Offset: 0x000C23F3
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001C49 RID: 7241 RVA: 0x000C3FFB File Offset: 0x000C23FB
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001C4A RID: 7242 RVA: 0x000C3FFE File Offset: 0x000C23FE
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001C4B RID: 7243 RVA: 0x000C400E File Offset: 0x000C240E
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001C4C RID: 7244 RVA: 0x000C401E File Offset: 0x000C241E
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001C4D RID: 7245 RVA: 0x000C4027 File Offset: 0x000C2427
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001C4E RID: 7246 RVA: 0x000C402E File Offset: 0x000C242E
	// Note: this type is marked as 'beforefieldinit'.
	static ShadowSacrificeHealOnExpTalent()
	{
	}

	// Token: 0x04001A8E RID: 6798
	public string Id;

	// Token: 0x04001A8F RID: 6799
	public string AdditionalKey;

	// Token: 0x04001A90 RID: 6800
	public int CurrentLevel;

	// Token: 0x04001A91 RID: 6801
	public static double HealRate = 0.06;
}
