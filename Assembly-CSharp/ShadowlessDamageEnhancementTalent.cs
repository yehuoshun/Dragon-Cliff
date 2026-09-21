using System;
using System.Collections.Generic;

// Token: 0x02000409 RID: 1033
[Serializable]
public class ShadowlessDamageEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001C5B RID: 7259 RVA: 0x000C40A0 File Offset: 0x000C24A0
	public ShadowlessDamageEnhancementTalent()
	{
	}

	// Token: 0x06001C5C RID: 7260 RVA: 0x000C40A8 File Offset: 0x000C24A8
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ShadowlessDamageEnhancement;
	}

	// Token: 0x06001C5D RID: 7261 RVA: 0x000C40AC File Offset: 0x000C24AC
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001C5E RID: 7262 RVA: 0x000C40AF File Offset: 0x000C24AF
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001C5F RID: 7263 RVA: 0x000C40B7 File Offset: 0x000C24B7
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001C60 RID: 7264 RVA: 0x000C40BF File Offset: 0x000C24BF
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001C61 RID: 7265 RVA: 0x000C40C7 File Offset: 0x000C24C7
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001C62 RID: 7266 RVA: 0x000C40CA File Offset: 0x000C24CA
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001C63 RID: 7267 RVA: 0x000C40DA File Offset: 0x000C24DA
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001C64 RID: 7268 RVA: 0x000C40EA File Offset: 0x000C24EA
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001C65 RID: 7269 RVA: 0x000C40F3 File Offset: 0x000C24F3
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001C66 RID: 7270 RVA: 0x000C40FA File Offset: 0x000C24FA
	// Note: this type is marked as 'beforefieldinit'.
	static ShadowlessDamageEnhancementTalent()
	{
	}

	// Token: 0x04001A96 RID: 6806
	public string Id;

	// Token: 0x04001A97 RID: 6807
	public string AdditionalKey;

	// Token: 0x04001A98 RID: 6808
	public int CurrentLevel;

	// Token: 0x04001A99 RID: 6809
	public static double ExtraRate = 1.0;
}
