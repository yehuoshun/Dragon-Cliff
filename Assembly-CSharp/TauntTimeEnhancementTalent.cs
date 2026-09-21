using System;
using System.Collections.Generic;

// Token: 0x02000422 RID: 1058
[Serializable]
public class TauntTimeEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001D28 RID: 7464 RVA: 0x000C76E3 File Offset: 0x000C5AE3
	public TauntTimeEnhancementTalent()
	{
	}

	// Token: 0x06001D29 RID: 7465 RVA: 0x000C76EB File Offset: 0x000C5AEB
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.TauntTimeEnhancement;
	}

	// Token: 0x06001D2A RID: 7466 RVA: 0x000C76EF File Offset: 0x000C5AEF
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001D2B RID: 7467 RVA: 0x000C76F2 File Offset: 0x000C5AF2
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001D2C RID: 7468 RVA: 0x000C76FA File Offset: 0x000C5AFA
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001D2D RID: 7469 RVA: 0x000C7702 File Offset: 0x000C5B02
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001D2E RID: 7470 RVA: 0x000C770A File Offset: 0x000C5B0A
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001D2F RID: 7471 RVA: 0x000C770D File Offset: 0x000C5B0D
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001D30 RID: 7472 RVA: 0x000C771D File Offset: 0x000C5B1D
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001D31 RID: 7473 RVA: 0x000C772D File Offset: 0x000C5B2D
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001D32 RID: 7474 RVA: 0x000C7736 File Offset: 0x000C5B36
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001D33 RID: 7475 RVA: 0x000C773D File Offset: 0x000C5B3D
	// Note: this type is marked as 'beforefieldinit'.
	static TauntTimeEnhancementTalent()
	{
	}

	// Token: 0x04001AEE RID: 6894
	public string Id;

	// Token: 0x04001AEF RID: 6895
	public string AdditionalKey;

	// Token: 0x04001AF0 RID: 6896
	public int CurrentLevel;

	// Token: 0x04001AF1 RID: 6897
	public static int TauntTime = 6;
}
