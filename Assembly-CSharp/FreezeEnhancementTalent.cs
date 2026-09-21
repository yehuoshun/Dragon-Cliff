using System;
using System.Collections.Generic;

// Token: 0x020003D9 RID: 985
[Serializable]
public class FreezeEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001AA9 RID: 6825 RVA: 0x000C2337 File Offset: 0x000C0737
	public FreezeEnhancementTalent()
	{
	}

	// Token: 0x06001AAA RID: 6826 RVA: 0x000C233F File Offset: 0x000C073F
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.FreezeEnhancement;
	}

	// Token: 0x06001AAB RID: 6827 RVA: 0x000C2343 File Offset: 0x000C0743
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001AAC RID: 6828 RVA: 0x000C2346 File Offset: 0x000C0746
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001AAD RID: 6829 RVA: 0x000C234E File Offset: 0x000C074E
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001AAE RID: 6830 RVA: 0x000C2356 File Offset: 0x000C0756
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001AAF RID: 6831 RVA: 0x000C235E File Offset: 0x000C075E
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001AB0 RID: 6832 RVA: 0x000C2361 File Offset: 0x000C0761
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001AB1 RID: 6833 RVA: 0x000C2371 File Offset: 0x000C0771
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001AB2 RID: 6834 RVA: 0x000C2381 File Offset: 0x000C0781
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001AB3 RID: 6835 RVA: 0x000C238A File Offset: 0x000C078A
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001AB4 RID: 6836 RVA: 0x000C2391 File Offset: 0x000C0791
	// Note: this type is marked as 'beforefieldinit'.
	static FreezeEnhancementTalent()
	{
	}

	// Token: 0x040019EA RID: 6634
	public string Id;

	// Token: 0x040019EB RID: 6635
	public string AdditionalKey;

	// Token: 0x040019EC RID: 6636
	public int CurrentLevel;

	// Token: 0x040019ED RID: 6637
	public static int LastingSecondsToReplace = 5;
}
