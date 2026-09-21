using System;
using System.Collections.Generic;

// Token: 0x020003E7 RID: 999
[Serializable]
public class IceEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001B1B RID: 6939 RVA: 0x000C2A18 File Offset: 0x000C0E18
	public IceEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B1C RID: 6940 RVA: 0x000C2A56 File Offset: 0x000C0E56
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.IceEnhancement;
	}

	// Token: 0x06001B1D RID: 6941 RVA: 0x000C2A5A File Offset: 0x000C0E5A
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001B1E RID: 6942 RVA: 0x000C2A5D File Offset: 0x000C0E5D
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001B1F RID: 6943 RVA: 0x000C2A65 File Offset: 0x000C0E65
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001B20 RID: 6944 RVA: 0x000C2A6D File Offset: 0x000C0E6D
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001B21 RID: 6945 RVA: 0x000C2A75 File Offset: 0x000C0E75
	public int GetMaxLevel()
	{
		return IceEnhancementTalent.MaxLevel;
	}

	// Token: 0x06001B22 RID: 6946 RVA: 0x000C2A7C File Offset: 0x000C0E7C
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001B23 RID: 6947 RVA: 0x000C2A8C File Offset: 0x000C0E8C
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001B24 RID: 6948 RVA: 0x000C2A9C File Offset: 0x000C0E9C
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B25 RID: 6949 RVA: 0x000C2AA8 File Offset: 0x000C0EA8
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new IceEffectEnhancementData
			{
				IsStar = false,
				AdditionalRate = IceEnhancementTalent.Rate * (double)this.CurrentLevel
			}
		};
	}

	// Token: 0x06001B26 RID: 6950 RVA: 0x000C2AE3 File Offset: 0x000C0EE3
	// Note: this type is marked as 'beforefieldinit'.
	static IceEnhancementTalent()
	{
	}

	// Token: 0x04001A11 RID: 6673
	public static double Rate = 1.5;

	// Token: 0x04001A12 RID: 6674
	public string Id;

	// Token: 0x04001A13 RID: 6675
	public string AdditionalKey;

	// Token: 0x04001A14 RID: 6676
	public int CurrentLevel;

	// Token: 0x04001A15 RID: 6677
	public static int MaxLevel = 3;
}
