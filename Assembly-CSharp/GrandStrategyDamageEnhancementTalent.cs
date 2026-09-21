using System;
using System.Collections.Generic;

// Token: 0x020003E0 RID: 992
[Serializable]
public class GrandStrategyDamageEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001ADF RID: 6879 RVA: 0x000C26CE File Offset: 0x000C0ACE
	public GrandStrategyDamageEnhancementTalent()
	{
	}

	// Token: 0x06001AE0 RID: 6880 RVA: 0x000C26D6 File Offset: 0x000C0AD6
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.GrandStrategyDamageEnhancement;
	}

	// Token: 0x06001AE1 RID: 6881 RVA: 0x000C26DA File Offset: 0x000C0ADA
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001AE2 RID: 6882 RVA: 0x000C26DD File Offset: 0x000C0ADD
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001AE3 RID: 6883 RVA: 0x000C26E5 File Offset: 0x000C0AE5
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001AE4 RID: 6884 RVA: 0x000C26ED File Offset: 0x000C0AED
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001AE5 RID: 6885 RVA: 0x000C26F5 File Offset: 0x000C0AF5
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001AE6 RID: 6886 RVA: 0x000C26F8 File Offset: 0x000C0AF8
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001AE7 RID: 6887 RVA: 0x000C2708 File Offset: 0x000C0B08
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001AE8 RID: 6888 RVA: 0x000C2718 File Offset: 0x000C0B18
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001AE9 RID: 6889 RVA: 0x000C2721 File Offset: 0x000C0B21
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001AEA RID: 6890 RVA: 0x000C2728 File Offset: 0x000C0B28
	// Note: this type is marked as 'beforefieldinit'.
	static GrandStrategyDamageEnhancementTalent()
	{
	}

	// Token: 0x040019FE RID: 6654
	public string Id;

	// Token: 0x040019FF RID: 6655
	public string AdditionalKey;

	// Token: 0x04001A00 RID: 6656
	public int CurrentLevel;

	// Token: 0x04001A01 RID: 6657
	public static double ExtraDamageRate = 0.5;
}
