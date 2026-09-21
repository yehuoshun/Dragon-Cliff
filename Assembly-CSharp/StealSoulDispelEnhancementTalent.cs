using System;
using System.Collections.Generic;

// Token: 0x02000412 RID: 1042
[Serializable]
public class StealSoulDispelEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001C98 RID: 7320 RVA: 0x000C4458 File Offset: 0x000C2858
	public StealSoulDispelEnhancementTalent()
	{
	}

	// Token: 0x06001C99 RID: 7321 RVA: 0x000C4460 File Offset: 0x000C2860
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.StealSoulDispelEnhancement;
	}

	// Token: 0x06001C9A RID: 7322 RVA: 0x000C4464 File Offset: 0x000C2864
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001C9B RID: 7323 RVA: 0x000C4467 File Offset: 0x000C2867
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001C9C RID: 7324 RVA: 0x000C446F File Offset: 0x000C286F
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001C9D RID: 7325 RVA: 0x000C4477 File Offset: 0x000C2877
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001C9E RID: 7326 RVA: 0x000C447F File Offset: 0x000C287F
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001C9F RID: 7327 RVA: 0x000C4482 File Offset: 0x000C2882
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001CA0 RID: 7328 RVA: 0x000C4492 File Offset: 0x000C2892
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001CA1 RID: 7329 RVA: 0x000C44A2 File Offset: 0x000C28A2
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001CA2 RID: 7330 RVA: 0x000C44AB File Offset: 0x000C28AB
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001CA3 RID: 7331 RVA: 0x000C44B2 File Offset: 0x000C28B2
	// Note: this type is marked as 'beforefieldinit'.
	static StealSoulDispelEnhancementTalent()
	{
	}

	// Token: 0x04001AAD RID: 6829
	public string Id;

	// Token: 0x04001AAE RID: 6830
	public string AdditionalKey;

	// Token: 0x04001AAF RID: 6831
	public int CurrentLevel;

	// Token: 0x04001AB0 RID: 6832
	public static int NumberOfDispels = 2;
}
