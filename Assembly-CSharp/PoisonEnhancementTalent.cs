using System;
using System.Collections.Generic;

// Token: 0x020003EF RID: 1007
[Serializable]
public class PoisonEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001B79 RID: 7033 RVA: 0x000C31B0 File Offset: 0x000C15B0
	public PoisonEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B7A RID: 7034 RVA: 0x000C31EE File Offset: 0x000C15EE
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.PoisonEnhancement;
	}

	// Token: 0x06001B7B RID: 7035 RVA: 0x000C31F2 File Offset: 0x000C15F2
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001B7C RID: 7036 RVA: 0x000C31F5 File Offset: 0x000C15F5
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001B7D RID: 7037 RVA: 0x000C31FD File Offset: 0x000C15FD
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001B7E RID: 7038 RVA: 0x000C3205 File Offset: 0x000C1605
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001B7F RID: 7039 RVA: 0x000C320D File Offset: 0x000C160D
	public int GetMaxLevel()
	{
		return PoisonEnhancementTalent.MaxLevel;
	}

	// Token: 0x06001B80 RID: 7040 RVA: 0x000C3214 File Offset: 0x000C1614
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001B81 RID: 7041 RVA: 0x000C3224 File Offset: 0x000C1624
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001B82 RID: 7042 RVA: 0x000C3234 File Offset: 0x000C1634
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B83 RID: 7043 RVA: 0x000C3240 File Offset: 0x000C1640
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new PoisonEffectEnhancementData
			{
				IsStar = false,
				ExtraRate = PoisonEnhancementTalent.DamageStart + (double)this.CurrentLevel * PoisonEnhancementTalent.DamagePerLevel
			}
		};
	}

	// Token: 0x06001B84 RID: 7044 RVA: 0x000C3281 File Offset: 0x000C1681
	// Note: this type is marked as 'beforefieldinit'.
	static PoisonEnhancementTalent()
	{
	}

	// Token: 0x04001A3C RID: 6716
	public static double DamageStart = 0.2;

	// Token: 0x04001A3D RID: 6717
	public static double DamagePerLevel = 0.5;

	// Token: 0x04001A3E RID: 6718
	public string Id;

	// Token: 0x04001A3F RID: 6719
	public string AdditionalKey;

	// Token: 0x04001A40 RID: 6720
	public int CurrentLevel;

	// Token: 0x04001A41 RID: 6721
	public static int MaxLevel = 3;
}
