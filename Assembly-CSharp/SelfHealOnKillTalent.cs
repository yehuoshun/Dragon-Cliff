using System;
using System.Collections.Generic;

// Token: 0x02000403 RID: 1027
[Serializable]
public class SelfHealOnKillTalent : IAdventurerTalent
{
	// Token: 0x06001C13 RID: 7187 RVA: 0x000C3D21 File Offset: 0x000C2121
	public SelfHealOnKillTalent()
	{
	}

	// Token: 0x06001C14 RID: 7188 RVA: 0x000C3D29 File Offset: 0x000C2129
	public double GetHealrate()
	{
		if (this.SkillType == SkillType.Arcane)
		{
			return 0.2;
		}
		return 0.0;
	}

	// Token: 0x06001C15 RID: 7189 RVA: 0x000C3D4E File Offset: 0x000C214E
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SelfHealOnKill;
	}

	// Token: 0x06001C16 RID: 7190 RVA: 0x000C3D52 File Offset: 0x000C2152
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001C17 RID: 7191 RVA: 0x000C3D55 File Offset: 0x000C2155
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001C18 RID: 7192 RVA: 0x000C3D5D File Offset: 0x000C215D
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001C19 RID: 7193 RVA: 0x000C3D65 File Offset: 0x000C2165
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001C1A RID: 7194 RVA: 0x000C3D6D File Offset: 0x000C216D
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001C1B RID: 7195 RVA: 0x000C3D70 File Offset: 0x000C2170
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001C1C RID: 7196 RVA: 0x000C3D80 File Offset: 0x000C2180
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001C1D RID: 7197 RVA: 0x000C3D90 File Offset: 0x000C2190
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001C1E RID: 7198 RVA: 0x000C3D99 File Offset: 0x000C2199
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x04001A7A RID: 6778
	public string Id;

	// Token: 0x04001A7B RID: 6779
	public string AdditionalKey;

	// Token: 0x04001A7C RID: 6780
	public int CurrentLevel;

	// Token: 0x04001A7D RID: 6781
	public SkillType SkillType;

	// Token: 0x04001A7E RID: 6782
	public int SlotNumber;
}
