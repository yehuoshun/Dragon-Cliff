using System;
using System.Collections.Generic;

// Token: 0x020003FE RID: 1022
[Serializable]
public class ScornChanceEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001BF0 RID: 7152 RVA: 0x000C3B3B File Offset: 0x000C1F3B
	public ScornChanceEnhancementTalent()
	{
	}

	// Token: 0x06001BF1 RID: 7153 RVA: 0x000C3B43 File Offset: 0x000C1F43
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ScornChanceEnhancement;
	}

	// Token: 0x06001BF2 RID: 7154 RVA: 0x000C3B47 File Offset: 0x000C1F47
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001BF3 RID: 7155 RVA: 0x000C3B4A File Offset: 0x000C1F4A
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001BF4 RID: 7156 RVA: 0x000C3B52 File Offset: 0x000C1F52
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001BF5 RID: 7157 RVA: 0x000C3B5A File Offset: 0x000C1F5A
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001BF6 RID: 7158 RVA: 0x000C3B62 File Offset: 0x000C1F62
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001BF7 RID: 7159 RVA: 0x000C3B65 File Offset: 0x000C1F65
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001BF8 RID: 7160 RVA: 0x000C3B75 File Offset: 0x000C1F75
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001BF9 RID: 7161 RVA: 0x000C3B85 File Offset: 0x000C1F85
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001BFA RID: 7162 RVA: 0x000C3B8E File Offset: 0x000C1F8E
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001BFB RID: 7163 RVA: 0x000C3B95 File Offset: 0x000C1F95
	// Note: this type is marked as 'beforefieldinit'.
	static ScornChanceEnhancementTalent()
	{
	}

	// Token: 0x04001A6D RID: 6765
	public string Id;

	// Token: 0x04001A6E RID: 6766
	public string AdditionalKey;

	// Token: 0x04001A6F RID: 6767
	public int CurrentLevel;

	// Token: 0x04001A70 RID: 6768
	public static double Rate = 0.2;
}
