using System;
using System.Collections.Generic;

// Token: 0x020003D5 RID: 981
[Serializable]
public class FirebreathDamageAbsorbTalent : IAdventurerTalent
{
	// Token: 0x06001A91 RID: 6801 RVA: 0x000C21D1 File Offset: 0x000C05D1
	public FirebreathDamageAbsorbTalent()
	{
	}

	// Token: 0x06001A92 RID: 6802 RVA: 0x000C21D9 File Offset: 0x000C05D9
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.FireBreathAbsorbShield;
	}

	// Token: 0x06001A93 RID: 6803 RVA: 0x000C21DD File Offset: 0x000C05DD
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001A94 RID: 6804 RVA: 0x000C21E0 File Offset: 0x000C05E0
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001A95 RID: 6805 RVA: 0x000C21E8 File Offset: 0x000C05E8
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001A96 RID: 6806 RVA: 0x000C21F0 File Offset: 0x000C05F0
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001A97 RID: 6807 RVA: 0x000C21F8 File Offset: 0x000C05F8
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001A98 RID: 6808 RVA: 0x000C21FB File Offset: 0x000C05FB
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001A99 RID: 6809 RVA: 0x000C220B File Offset: 0x000C060B
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001A9A RID: 6810 RVA: 0x000C221B File Offset: 0x000C061B
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001A9B RID: 6811 RVA: 0x000C2224 File Offset: 0x000C0624
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001A9C RID: 6812 RVA: 0x000C222B File Offset: 0x000C062B
	// Note: this type is marked as 'beforefieldinit'.
	static FirebreathDamageAbsorbTalent()
	{
	}

	// Token: 0x040019E2 RID: 6626
	public string Id;

	// Token: 0x040019E3 RID: 6627
	public string AdditionalKey;

	// Token: 0x040019E4 RID: 6628
	public int CurrentLevel;

	// Token: 0x040019E5 RID: 6629
	public static double Rate = 0.008;
}
