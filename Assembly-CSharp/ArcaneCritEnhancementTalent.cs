using System;
using System.Collections.Generic;

// Token: 0x020003AF RID: 943
[Serializable]
public class ArcaneCritEnhancementTalent : IAdventurerTalent
{
	// Token: 0x0600190F RID: 6415 RVA: 0x000BFF34 File Offset: 0x000BE334
	public ArcaneCritEnhancementTalent()
	{
	}

	// Token: 0x06001910 RID: 6416 RVA: 0x000BFF3C File Offset: 0x000BE33C
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ArcaneCritEnhancement;
	}

	// Token: 0x06001911 RID: 6417 RVA: 0x000BFF40 File Offset: 0x000BE340
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001912 RID: 6418 RVA: 0x000BFF43 File Offset: 0x000BE343
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001913 RID: 6419 RVA: 0x000BFF4B File Offset: 0x000BE34B
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001914 RID: 6420 RVA: 0x000BFF53 File Offset: 0x000BE353
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001915 RID: 6421 RVA: 0x000BFF5B File Offset: 0x000BE35B
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001916 RID: 6422 RVA: 0x000BFF5E File Offset: 0x000BE35E
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001917 RID: 6423 RVA: 0x000BFF6E File Offset: 0x000BE36E
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001918 RID: 6424 RVA: 0x000BFF7E File Offset: 0x000BE37E
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001919 RID: 6425 RVA: 0x000BFF87 File Offset: 0x000BE387
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x0600191A RID: 6426 RVA: 0x000BFF8E File Offset: 0x000BE38E
	// Note: this type is marked as 'beforefieldinit'.
	static ArcaneCritEnhancementTalent()
	{
	}

	// Token: 0x04001949 RID: 6473
	public string Id;

	// Token: 0x0400194A RID: 6474
	public string AdditionalKey;

	// Token: 0x0400194B RID: 6475
	public int CurrentLevel;

	// Token: 0x0400194C RID: 6476
	public static double Rate = 0.6;
}
