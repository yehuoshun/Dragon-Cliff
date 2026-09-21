using System;
using System.Collections.Generic;

// Token: 0x020003E1 RID: 993
[Serializable]
public class GrandStrategyDispelEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001AEB RID: 6891 RVA: 0x000C2738 File Offset: 0x000C0B38
	public GrandStrategyDispelEnhancementTalent()
	{
	}

	// Token: 0x06001AEC RID: 6892 RVA: 0x000C2740 File Offset: 0x000C0B40
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.GrandStrategyDispelEnhancement;
	}

	// Token: 0x06001AED RID: 6893 RVA: 0x000C2744 File Offset: 0x000C0B44
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001AEE RID: 6894 RVA: 0x000C2747 File Offset: 0x000C0B47
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001AEF RID: 6895 RVA: 0x000C274F File Offset: 0x000C0B4F
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001AF0 RID: 6896 RVA: 0x000C2757 File Offset: 0x000C0B57
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001AF1 RID: 6897 RVA: 0x000C275F File Offset: 0x000C0B5F
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001AF2 RID: 6898 RVA: 0x000C2762 File Offset: 0x000C0B62
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001AF3 RID: 6899 RVA: 0x000C2772 File Offset: 0x000C0B72
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001AF4 RID: 6900 RVA: 0x000C2782 File Offset: 0x000C0B82
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001AF5 RID: 6901 RVA: 0x000C278B File Offset: 0x000C0B8B
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001AF6 RID: 6902 RVA: 0x000C2792 File Offset: 0x000C0B92
	// Note: this type is marked as 'beforefieldinit'.
	static GrandStrategyDispelEnhancementTalent()
	{
	}

	// Token: 0x04001A02 RID: 6658
	public string Id;

	// Token: 0x04001A03 RID: 6659
	public string AdditionalKey;

	// Token: 0x04001A04 RID: 6660
	public int CurrentLevel;

	// Token: 0x04001A05 RID: 6661
	public static double Chance = 0.5;

	// Token: 0x04001A06 RID: 6662
	public static int Dispels = 1;
}
