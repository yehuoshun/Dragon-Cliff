using System;
using System.Collections.Generic;

// Token: 0x020003EA RID: 1002
[Serializable]
public class LightningShieldTalent : IAdventurerTalent
{
	// Token: 0x06001B44 RID: 6980 RVA: 0x000C2DFC File Offset: 0x000C11FC
	public LightningShieldTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B45 RID: 6981 RVA: 0x000C2E3A File Offset: 0x000C123A
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.LightningShield;
	}

	// Token: 0x06001B46 RID: 6982 RVA: 0x000C2E3E File Offset: 0x000C123E
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001B47 RID: 6983 RVA: 0x000C2E41 File Offset: 0x000C1241
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001B48 RID: 6984 RVA: 0x000C2E49 File Offset: 0x000C1249
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001B49 RID: 6985 RVA: 0x000C2E51 File Offset: 0x000C1251
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001B4A RID: 6986 RVA: 0x000C2E59 File Offset: 0x000C1259
	public int GetMaxLevel()
	{
		return LightningShieldTalent.MaxLevel;
	}

	// Token: 0x06001B4B RID: 6987 RVA: 0x000C2E60 File Offset: 0x000C1260
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001B4C RID: 6988 RVA: 0x000C2E70 File Offset: 0x000C1270
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001B4D RID: 6989 RVA: 0x000C2E80 File Offset: 0x000C1280
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B4E RID: 6990 RVA: 0x000C2E8C File Offset: 0x000C128C
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new LightningShieldData
			{
				IsStar = false,
				NegativeResistance = LightningShieldTalent.NegativeResistancerate * (double)this.CurrentLevel,
				ResilienceReductionRate = LightningShieldTalent.ResilienceRate * (double)this.CurrentLevel
			}
		};
	}

	// Token: 0x06001B4F RID: 6991 RVA: 0x000C2EDA File Offset: 0x000C12DA
	// Note: this type is marked as 'beforefieldinit'.
	static LightningShieldTalent()
	{
	}

	// Token: 0x04001A26 RID: 6694
	public static double ResilienceRate = 0.15;

	// Token: 0x04001A27 RID: 6695
	public static double NegativeResistancerate = 0.05;

	// Token: 0x04001A28 RID: 6696
	public string Id;

	// Token: 0x04001A29 RID: 6697
	public string AdditionalKey;

	// Token: 0x04001A2A RID: 6698
	public int CurrentLevel;

	// Token: 0x04001A2B RID: 6699
	public static int MaxLevel = 3;
}
