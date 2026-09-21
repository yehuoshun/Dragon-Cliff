using System;
using System.Collections.Generic;

// Token: 0x02000406 RID: 1030
[Serializable]
public class ShadowSacrificeExplosionEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001C37 RID: 7223 RVA: 0x000C3F6A File Offset: 0x000C236A
	public ShadowSacrificeExplosionEnhancementTalent()
	{
	}

	// Token: 0x06001C38 RID: 7224 RVA: 0x000C3F72 File Offset: 0x000C2372
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ShadowSacrificeExplosionEnhancement;
	}

	// Token: 0x06001C39 RID: 7225 RVA: 0x000C3F76 File Offset: 0x000C2376
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001C3A RID: 7226 RVA: 0x000C3F79 File Offset: 0x000C2379
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001C3B RID: 7227 RVA: 0x000C3F81 File Offset: 0x000C2381
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001C3C RID: 7228 RVA: 0x000C3F89 File Offset: 0x000C2389
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001C3D RID: 7229 RVA: 0x000C3F91 File Offset: 0x000C2391
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001C3E RID: 7230 RVA: 0x000C3F94 File Offset: 0x000C2394
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001C3F RID: 7231 RVA: 0x000C3FA4 File Offset: 0x000C23A4
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001C40 RID: 7232 RVA: 0x000C3FB4 File Offset: 0x000C23B4
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001C41 RID: 7233 RVA: 0x000C3FBD File Offset: 0x000C23BD
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001C42 RID: 7234 RVA: 0x000C3FC4 File Offset: 0x000C23C4
	// Note: this type is marked as 'beforefieldinit'.
	static ShadowSacrificeExplosionEnhancementTalent()
	{
	}

	// Token: 0x04001A8A RID: 6794
	public string Id;

	// Token: 0x04001A8B RID: 6795
	public string AdditionalKey;

	// Token: 0x04001A8C RID: 6796
	public int CurrentLevel;

	// Token: 0x04001A8D RID: 6797
	public static double ExtraRate = 0.15;
}
