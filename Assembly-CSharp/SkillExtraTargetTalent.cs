using System;
using System.Collections.Generic;

// Token: 0x0200040B RID: 1035
[Serializable]
public class SkillExtraTargetTalent : IAdventurerTalent
{
	// Token: 0x06001C73 RID: 7283 RVA: 0x000C4179 File Offset: 0x000C2579
	public SkillExtraTargetTalent()
	{
	}

	// Token: 0x06001C74 RID: 7284 RVA: 0x000C4181 File Offset: 0x000C2581
	public int GetExtra()
	{
		if (this.SkillType == SkillType.Freeze || this.SkillType == SkillType.Pray)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06001C75 RID: 7285 RVA: 0x000C41A6 File Offset: 0x000C25A6
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SkillExtraTarget;
	}

	// Token: 0x06001C76 RID: 7286 RVA: 0x000C41AA File Offset: 0x000C25AA
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001C77 RID: 7287 RVA: 0x000C41AD File Offset: 0x000C25AD
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001C78 RID: 7288 RVA: 0x000C41B5 File Offset: 0x000C25B5
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001C79 RID: 7289 RVA: 0x000C41BD File Offset: 0x000C25BD
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001C7A RID: 7290 RVA: 0x000C41C5 File Offset: 0x000C25C5
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001C7B RID: 7291 RVA: 0x000C41C8 File Offset: 0x000C25C8
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001C7C RID: 7292 RVA: 0x000C41D8 File Offset: 0x000C25D8
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001C7D RID: 7293 RVA: 0x000C41E8 File Offset: 0x000C25E8
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001C7E RID: 7294 RVA: 0x000C41F1 File Offset: 0x000C25F1
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x04001A9F RID: 6815
	public string Id;

	// Token: 0x04001AA0 RID: 6816
	public string AdditionalKey;

	// Token: 0x04001AA1 RID: 6817
	public int CurrentLevel;

	// Token: 0x04001AA2 RID: 6818
	public SkillType SkillType;

	// Token: 0x04001AA3 RID: 6819
	public int SlotNumber;
}
