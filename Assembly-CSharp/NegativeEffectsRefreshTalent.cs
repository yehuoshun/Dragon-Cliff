using System;
using System.Collections.Generic;

// Token: 0x020003ED RID: 1005
[Serializable]
public class NegativeEffectsRefreshTalent : IAdventurerTalent
{
	// Token: 0x06001B61 RID: 7009 RVA: 0x000C3056 File Offset: 0x000C1456
	public NegativeEffectsRefreshTalent()
	{
	}

	// Token: 0x06001B62 RID: 7010 RVA: 0x000C305E File Offset: 0x000C145E
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.NegativeEffectsRefresh;
	}

	// Token: 0x06001B63 RID: 7011 RVA: 0x000C3061 File Offset: 0x000C1461
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001B64 RID: 7012 RVA: 0x000C3064 File Offset: 0x000C1464
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001B65 RID: 7013 RVA: 0x000C306C File Offset: 0x000C146C
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001B66 RID: 7014 RVA: 0x000C3074 File Offset: 0x000C1474
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001B67 RID: 7015 RVA: 0x000C307C File Offset: 0x000C147C
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001B68 RID: 7016 RVA: 0x000C307F File Offset: 0x000C147F
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001B69 RID: 7017 RVA: 0x000C308F File Offset: 0x000C148F
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001B6A RID: 7018 RVA: 0x000C309F File Offset: 0x000C149F
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B6B RID: 7019 RVA: 0x000C30A8 File Offset: 0x000C14A8
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001B6C RID: 7020 RVA: 0x000C30AF File Offset: 0x000C14AF
	// Note: this type is marked as 'beforefieldinit'.
	static NegativeEffectsRefreshTalent()
	{
	}

	// Token: 0x04001A32 RID: 6706
	public string Id;

	// Token: 0x04001A33 RID: 6707
	public string AdditionalKey;

	// Token: 0x04001A34 RID: 6708
	public int CurrentLevel;

	// Token: 0x04001A35 RID: 6709
	public static int Counts = 1;
}
