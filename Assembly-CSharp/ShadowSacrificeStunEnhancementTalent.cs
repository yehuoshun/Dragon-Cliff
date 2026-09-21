using System;
using System.Collections.Generic;

// Token: 0x02000408 RID: 1032
[Serializable]
public class ShadowSacrificeStunEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001C4F RID: 7247 RVA: 0x000C403E File Offset: 0x000C243E
	public ShadowSacrificeStunEnhancementTalent()
	{
	}

	// Token: 0x06001C50 RID: 7248 RVA: 0x000C4046 File Offset: 0x000C2446
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ShadowSacrificeStunEnhancement;
	}

	// Token: 0x06001C51 RID: 7249 RVA: 0x000C404A File Offset: 0x000C244A
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001C52 RID: 7250 RVA: 0x000C404D File Offset: 0x000C244D
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001C53 RID: 7251 RVA: 0x000C4055 File Offset: 0x000C2455
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001C54 RID: 7252 RVA: 0x000C405D File Offset: 0x000C245D
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001C55 RID: 7253 RVA: 0x000C4065 File Offset: 0x000C2465
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001C56 RID: 7254 RVA: 0x000C4068 File Offset: 0x000C2468
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001C57 RID: 7255 RVA: 0x000C4078 File Offset: 0x000C2478
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001C58 RID: 7256 RVA: 0x000C4088 File Offset: 0x000C2488
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001C59 RID: 7257 RVA: 0x000C4091 File Offset: 0x000C2491
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001C5A RID: 7258 RVA: 0x000C4098 File Offset: 0x000C2498
	// Note: this type is marked as 'beforefieldinit'.
	static ShadowSacrificeStunEnhancementTalent()
	{
	}

	// Token: 0x04001A92 RID: 6802
	public string Id;

	// Token: 0x04001A93 RID: 6803
	public string AdditionalKey;

	// Token: 0x04001A94 RID: 6804
	public int CurrentLevel;

	// Token: 0x04001A95 RID: 6805
	public static int StunSeconds = 1;
}
