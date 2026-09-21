using System;
using System.Collections.Generic;

// Token: 0x0200040A RID: 1034
[Serializable]
public class ShieldOnKillTalent : IAdventurerTalent
{
	// Token: 0x06001C67 RID: 7271 RVA: 0x000C410A File Offset: 0x000C250A
	public ShieldOnKillTalent()
	{
	}

	// Token: 0x06001C68 RID: 7272 RVA: 0x000C4112 File Offset: 0x000C2512
	public int GetNumberOfShields()
	{
		if (this.SkillType == SkillType.Assassination)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06001C69 RID: 7273 RVA: 0x000C4127 File Offset: 0x000C2527
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ShieldOnKill;
	}

	// Token: 0x06001C6A RID: 7274 RVA: 0x000C412B File Offset: 0x000C252B
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001C6B RID: 7275 RVA: 0x000C412E File Offset: 0x000C252E
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001C6C RID: 7276 RVA: 0x000C4136 File Offset: 0x000C2536
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001C6D RID: 7277 RVA: 0x000C413E File Offset: 0x000C253E
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001C6E RID: 7278 RVA: 0x000C4146 File Offset: 0x000C2546
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001C6F RID: 7279 RVA: 0x000C4149 File Offset: 0x000C2549
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001C70 RID: 7280 RVA: 0x000C4159 File Offset: 0x000C2559
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001C71 RID: 7281 RVA: 0x000C4169 File Offset: 0x000C2569
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001C72 RID: 7282 RVA: 0x000C4172 File Offset: 0x000C2572
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x04001A9A RID: 6810
	public string Id;

	// Token: 0x04001A9B RID: 6811
	public string AdditionalKey;

	// Token: 0x04001A9C RID: 6812
	public int CurrentLevel;

	// Token: 0x04001A9D RID: 6813
	public SkillType SkillType;

	// Token: 0x04001A9E RID: 6814
	public int SlotNumber;
}
