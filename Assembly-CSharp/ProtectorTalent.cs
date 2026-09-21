using System;
using System.Collections.Generic;

// Token: 0x020003F4 RID: 1012
[Serializable]
public class ProtectorTalent : IAdventurerTalent
{
	// Token: 0x06001B9D RID: 7069 RVA: 0x000C34CC File Offset: 0x000C18CC
	public ProtectorTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B9E RID: 7070 RVA: 0x000C350A File Offset: 0x000C190A
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ProtectorTalent;
	}

	// Token: 0x06001B9F RID: 7071 RVA: 0x000C350E File Offset: 0x000C190E
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001BA0 RID: 7072 RVA: 0x000C3511 File Offset: 0x000C1911
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001BA1 RID: 7073 RVA: 0x000C3519 File Offset: 0x000C1919
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001BA2 RID: 7074 RVA: 0x000C3521 File Offset: 0x000C1921
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001BA3 RID: 7075 RVA: 0x000C3529 File Offset: 0x000C1929
	public int GetMaxLevel()
	{
		return ProtectorTalent.MaxLevel;
	}

	// Token: 0x06001BA4 RID: 7076 RVA: 0x000C3530 File Offset: 0x000C1930
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001BA5 RID: 7077 RVA: 0x000C3540 File Offset: 0x000C1940
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001BA6 RID: 7078 RVA: 0x000C3550 File Offset: 0x000C1950
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001BA7 RID: 7079 RVA: 0x000C355C File Offset: 0x000C195C
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ProtectorData
			{
				IsStar = false,
				DamageReductionRate = ProtectorTalent.DamageShareRate,
				DamageReceivedRate = ProtectorTalent.DamageRateStart - (double)this.CurrentLevel * ProtectorTalent.DamageRateReductionPerLevel
			}
		};
	}

	// Token: 0x06001BA8 RID: 7080 RVA: 0x000C35A8 File Offset: 0x000C19A8
	// Note: this type is marked as 'beforefieldinit'.
	static ProtectorTalent()
	{
	}

	// Token: 0x04001A48 RID: 6728
	public static double DamageRateStart = 1.0;

	// Token: 0x04001A49 RID: 6729
	public static double DamageRateReductionPerLevel = 0.15;

	// Token: 0x04001A4A RID: 6730
	public static double DamageShareRate = 0.4;

	// Token: 0x04001A4B RID: 6731
	public string Id;

	// Token: 0x04001A4C RID: 6732
	public string AdditionalKey;

	// Token: 0x04001A4D RID: 6733
	public int CurrentLevel;

	// Token: 0x04001A4E RID: 6734
	public static int MaxLevel = 3;
}
