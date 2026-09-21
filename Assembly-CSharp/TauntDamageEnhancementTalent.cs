using System;
using System.Collections.Generic;

// Token: 0x0200041F RID: 1055
[Serializable]
public class TauntDamageEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001D01 RID: 7425 RVA: 0x000C7477 File Offset: 0x000C5877
	public TauntDamageEnhancementTalent()
	{
	}

	// Token: 0x06001D02 RID: 7426 RVA: 0x000C747F File Offset: 0x000C587F
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.TauntDamageEnhancement;
	}

	// Token: 0x06001D03 RID: 7427 RVA: 0x000C7483 File Offset: 0x000C5883
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001D04 RID: 7428 RVA: 0x000C7486 File Offset: 0x000C5886
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001D05 RID: 7429 RVA: 0x000C748E File Offset: 0x000C588E
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001D06 RID: 7430 RVA: 0x000C7496 File Offset: 0x000C5896
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001D07 RID: 7431 RVA: 0x000C749E File Offset: 0x000C589E
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001D08 RID: 7432 RVA: 0x000C74A1 File Offset: 0x000C58A1
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001D09 RID: 7433 RVA: 0x000C74B1 File Offset: 0x000C58B1
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001D0A RID: 7434 RVA: 0x000C74C1 File Offset: 0x000C58C1
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001D0B RID: 7435 RVA: 0x000C74CA File Offset: 0x000C58CA
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001D0C RID: 7436 RVA: 0x000C74D1 File Offset: 0x000C58D1
	// Note: this type is marked as 'beforefieldinit'.
	static TauntDamageEnhancementTalent()
	{
	}

	// Token: 0x04001ADD RID: 6877
	public string Id;

	// Token: 0x04001ADE RID: 6878
	public string AdditionalKey;

	// Token: 0x04001ADF RID: 6879
	public int CurrentLevel;

	// Token: 0x04001AE0 RID: 6880
	public static double DamageIncreaseRate = 0.15;
}
