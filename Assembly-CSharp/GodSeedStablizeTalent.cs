using System;
using System.Collections.Generic;

// Token: 0x020003DF RID: 991
[Serializable]
public class GodSeedStablizeTalent : IAdventurerTalent
{
	// Token: 0x06001AD4 RID: 6868 RVA: 0x000C2674 File Offset: 0x000C0A74
	public GodSeedStablizeTalent()
	{
	}

	// Token: 0x06001AD5 RID: 6869 RVA: 0x000C267C File Offset: 0x000C0A7C
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.GodSeedStablize;
	}

	// Token: 0x06001AD6 RID: 6870 RVA: 0x000C2680 File Offset: 0x000C0A80
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001AD7 RID: 6871 RVA: 0x000C2683 File Offset: 0x000C0A83
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001AD8 RID: 6872 RVA: 0x000C268B File Offset: 0x000C0A8B
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001AD9 RID: 6873 RVA: 0x000C2693 File Offset: 0x000C0A93
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001ADA RID: 6874 RVA: 0x000C269B File Offset: 0x000C0A9B
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001ADB RID: 6875 RVA: 0x000C269E File Offset: 0x000C0A9E
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001ADC RID: 6876 RVA: 0x000C26AE File Offset: 0x000C0AAE
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001ADD RID: 6877 RVA: 0x000C26BE File Offset: 0x000C0ABE
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001ADE RID: 6878 RVA: 0x000C26C7 File Offset: 0x000C0AC7
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x040019FB RID: 6651
	public string Id;

	// Token: 0x040019FC RID: 6652
	public string AdditionalKey;

	// Token: 0x040019FD RID: 6653
	public int CurrentLevel;
}
