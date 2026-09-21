using System;
using System.Collections.Generic;

// Token: 0x020003BD RID: 957
[Serializable]
public class BrightCircleDispelEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001997 RID: 6551 RVA: 0x000C0CAB File Offset: 0x000BF0AB
	public BrightCircleDispelEnhancementTalent()
	{
	}

	// Token: 0x06001998 RID: 6552 RVA: 0x000C0CB3 File Offset: 0x000BF0B3
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.BrightCircleDispelEnhancement;
	}

	// Token: 0x06001999 RID: 6553 RVA: 0x000C0CB7 File Offset: 0x000BF0B7
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x0600199A RID: 6554 RVA: 0x000C0CBA File Offset: 0x000BF0BA
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x0600199B RID: 6555 RVA: 0x000C0CC2 File Offset: 0x000BF0C2
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x0600199C RID: 6556 RVA: 0x000C0CCA File Offset: 0x000BF0CA
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x0600199D RID: 6557 RVA: 0x000C0CD2 File Offset: 0x000BF0D2
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x0600199E RID: 6558 RVA: 0x000C0CD5 File Offset: 0x000BF0D5
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x0600199F RID: 6559 RVA: 0x000C0CE5 File Offset: 0x000BF0E5
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x060019A0 RID: 6560 RVA: 0x000C0CF5 File Offset: 0x000BF0F5
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x060019A1 RID: 6561 RVA: 0x000C0CFE File Offset: 0x000BF0FE
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x060019A2 RID: 6562 RVA: 0x000C0D05 File Offset: 0x000BF105
	// Note: this type is marked as 'beforefieldinit'.
	static BrightCircleDispelEnhancementTalent()
	{
	}

	// Token: 0x04001978 RID: 6520
	public string Id;

	// Token: 0x04001979 RID: 6521
	public string AdditionalKey;

	// Token: 0x0400197A RID: 6522
	public int CurrentLevel;

	// Token: 0x0400197B RID: 6523
	public static int NumberOfDispels = 1;
}
