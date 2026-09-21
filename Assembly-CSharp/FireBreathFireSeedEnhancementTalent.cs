using System;
using System.Collections.Generic;

// Token: 0x020003D3 RID: 979
[Serializable]
public class FireBreathFireSeedEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001A79 RID: 6777 RVA: 0x000C2084 File Offset: 0x000C0484
	public FireBreathFireSeedEnhancementTalent()
	{
	}

	// Token: 0x06001A7A RID: 6778 RVA: 0x000C208C File Offset: 0x000C048C
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.FireBreathFireSeedEnhancement;
	}

	// Token: 0x06001A7B RID: 6779 RVA: 0x000C208F File Offset: 0x000C048F
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001A7C RID: 6780 RVA: 0x000C2092 File Offset: 0x000C0492
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001A7D RID: 6781 RVA: 0x000C209A File Offset: 0x000C049A
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001A7E RID: 6782 RVA: 0x000C20A2 File Offset: 0x000C04A2
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001A7F RID: 6783 RVA: 0x000C20AA File Offset: 0x000C04AA
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001A80 RID: 6784 RVA: 0x000C20AD File Offset: 0x000C04AD
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001A81 RID: 6785 RVA: 0x000C20BD File Offset: 0x000C04BD
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001A82 RID: 6786 RVA: 0x000C20CD File Offset: 0x000C04CD
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001A83 RID: 6787 RVA: 0x000C20D6 File Offset: 0x000C04D6
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001A84 RID: 6788 RVA: 0x000C20DD File Offset: 0x000C04DD
	// Note: this type is marked as 'beforefieldinit'.
	static FireBreathFireSeedEnhancementTalent()
	{
	}

	// Token: 0x040019D9 RID: 6617
	public string Id;

	// Token: 0x040019DA RID: 6618
	public string AdditionalKey;

	// Token: 0x040019DB RID: 6619
	public int CurrentLevel;

	// Token: 0x040019DC RID: 6620
	public static double Rate = 0.2;
}
