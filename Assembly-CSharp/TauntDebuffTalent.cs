using System;
using System.Collections.Generic;

// Token: 0x02000420 RID: 1056
[Serializable]
public class TauntDebuffTalent : IAdventurerTalent
{
	// Token: 0x06001D0D RID: 7437 RVA: 0x000C74E1 File Offset: 0x000C58E1
	public TauntDebuffTalent()
	{
	}

	// Token: 0x06001D0E RID: 7438 RVA: 0x000C74E9 File Offset: 0x000C58E9
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.TauntDebuff;
	}

	// Token: 0x06001D0F RID: 7439 RVA: 0x000C74ED File Offset: 0x000C58ED
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001D10 RID: 7440 RVA: 0x000C74F0 File Offset: 0x000C58F0
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001D11 RID: 7441 RVA: 0x000C74F8 File Offset: 0x000C58F8
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001D12 RID: 7442 RVA: 0x000C7500 File Offset: 0x000C5900
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001D13 RID: 7443 RVA: 0x000C7508 File Offset: 0x000C5908
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001D14 RID: 7444 RVA: 0x000C750B File Offset: 0x000C590B
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001D15 RID: 7445 RVA: 0x000C751B File Offset: 0x000C591B
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001D16 RID: 7446 RVA: 0x000C752B File Offset: 0x000C592B
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001D17 RID: 7447 RVA: 0x000C7534 File Offset: 0x000C5934
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001D18 RID: 7448 RVA: 0x000C753B File Offset: 0x000C593B
	// Note: this type is marked as 'beforefieldinit'.
	static TauntDebuffTalent()
	{
	}

	// Token: 0x04001AE1 RID: 6881
	public string Id;

	// Token: 0x04001AE2 RID: 6882
	public string AdditionalKey;

	// Token: 0x04001AE3 RID: 6883
	public int CurrentLevel;

	// Token: 0x04001AE4 RID: 6884
	public static AttributeType Type = AttributeType.Allresistances;

	// Token: 0x04001AE5 RID: 6885
	public static double ReductionRate = 0.15;
}
