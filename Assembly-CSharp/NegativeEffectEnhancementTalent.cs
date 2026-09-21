using System;
using System.Collections.Generic;

// Token: 0x020003EC RID: 1004
[Serializable]
public class NegativeEffectEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001B55 RID: 6997 RVA: 0x000C2F70 File Offset: 0x000C1370
	public NegativeEffectEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B56 RID: 6998 RVA: 0x000C2FAE File Offset: 0x000C13AE
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.NegativeEffectResistanceBoost;
	}

	// Token: 0x06001B57 RID: 6999 RVA: 0x000C2FB2 File Offset: 0x000C13B2
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001B58 RID: 7000 RVA: 0x000C2FB5 File Offset: 0x000C13B5
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001B59 RID: 7001 RVA: 0x000C2FBD File Offset: 0x000C13BD
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001B5A RID: 7002 RVA: 0x000C2FC5 File Offset: 0x000C13C5
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001B5B RID: 7003 RVA: 0x000C2FCD File Offset: 0x000C13CD
	public int GetMaxLevel()
	{
		return NegativeEffectEnhancementTalent.MaxLevel;
	}

	// Token: 0x06001B5C RID: 7004 RVA: 0x000C2FD4 File Offset: 0x000C13D4
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001B5D RID: 7005 RVA: 0x000C2FE4 File Offset: 0x000C13E4
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001B5E RID: 7006 RVA: 0x000C2FF4 File Offset: 0x000C13F4
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B5F RID: 7007 RVA: 0x000C3000 File Offset: 0x000C1400
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new NegativeEffectSpeedupData
			{
				IsStarEf = new bool?(false),
				DecreaseRate = NegativeEffectEnhancementTalent.Rate * (double)this.CurrentLevel
			}
		};
	}

	// Token: 0x06001B60 RID: 7008 RVA: 0x000C3040 File Offset: 0x000C1440
	// Note: this type is marked as 'beforefieldinit'.
	static NegativeEffectEnhancementTalent()
	{
	}

	// Token: 0x04001A2D RID: 6701
	public static double Rate = 0.1;

	// Token: 0x04001A2E RID: 6702
	public string Id;

	// Token: 0x04001A2F RID: 6703
	public string AdditionalKey;

	// Token: 0x04001A30 RID: 6704
	public int CurrentLevel;

	// Token: 0x04001A31 RID: 6705
	public static int MaxLevel = 3;
}
