using System;
using System.Collections.Generic;

// Token: 0x020003B2 RID: 946
[Serializable]
public class AssassinDispelEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001923 RID: 6435 RVA: 0x000C016B File Offset: 0x000BE56B
	public AssassinDispelEnhancementTalent()
	{
	}

	// Token: 0x06001924 RID: 6436 RVA: 0x000C0173 File Offset: 0x000BE573
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.AssassinDispelEnhancement;
	}

	// Token: 0x06001925 RID: 6437 RVA: 0x000C0177 File Offset: 0x000BE577
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001926 RID: 6438 RVA: 0x000C017A File Offset: 0x000BE57A
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001927 RID: 6439 RVA: 0x000C0182 File Offset: 0x000BE582
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001928 RID: 6440 RVA: 0x000C018A File Offset: 0x000BE58A
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001929 RID: 6441 RVA: 0x000C0192 File Offset: 0x000BE592
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x0600192A RID: 6442 RVA: 0x000C0195 File Offset: 0x000BE595
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x0600192B RID: 6443 RVA: 0x000C01A5 File Offset: 0x000BE5A5
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x0600192C RID: 6444 RVA: 0x000C01B5 File Offset: 0x000BE5B5
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x0600192D RID: 6445 RVA: 0x000C01BE File Offset: 0x000BE5BE
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x0600192E RID: 6446 RVA: 0x000C01C5 File Offset: 0x000BE5C5
	// Note: this type is marked as 'beforefieldinit'.
	static AssassinDispelEnhancementTalent()
	{
	}

	// Token: 0x0400194E RID: 6478
	public string Id;

	// Token: 0x0400194F RID: 6479
	public string AdditionalKey;

	// Token: 0x04001950 RID: 6480
	public int CurrentLevel;

	// Token: 0x04001951 RID: 6481
	public static int NumberOfDispel = 2;
}
