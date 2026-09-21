using System;
using System.Collections.Generic;

// Token: 0x02000402 RID: 1026
[Serializable]
public class SeedsOfSinPetPushTalent : IAdventurerTalent
{
	// Token: 0x06001C07 RID: 7175 RVA: 0x000C3CB7 File Offset: 0x000C20B7
	public SeedsOfSinPetPushTalent()
	{
	}

	// Token: 0x06001C08 RID: 7176 RVA: 0x000C3CBF File Offset: 0x000C20BF
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.SeedsOfSinPetPush;
	}

	// Token: 0x06001C09 RID: 7177 RVA: 0x000C3CC3 File Offset: 0x000C20C3
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001C0A RID: 7178 RVA: 0x000C3CC6 File Offset: 0x000C20C6
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001C0B RID: 7179 RVA: 0x000C3CCE File Offset: 0x000C20CE
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001C0C RID: 7180 RVA: 0x000C3CD6 File Offset: 0x000C20D6
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001C0D RID: 7181 RVA: 0x000C3CDE File Offset: 0x000C20DE
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001C0E RID: 7182 RVA: 0x000C3CE1 File Offset: 0x000C20E1
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001C0F RID: 7183 RVA: 0x000C3CF1 File Offset: 0x000C20F1
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001C10 RID: 7184 RVA: 0x000C3D01 File Offset: 0x000C2101
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001C11 RID: 7185 RVA: 0x000C3D0A File Offset: 0x000C210A
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001C12 RID: 7186 RVA: 0x000C3D11 File Offset: 0x000C2111
	// Note: this type is marked as 'beforefieldinit'.
	static SeedsOfSinPetPushTalent()
	{
	}

	// Token: 0x04001A76 RID: 6774
	public string Id;

	// Token: 0x04001A77 RID: 6775
	public string AdditionalKey;

	// Token: 0x04001A78 RID: 6776
	public int CurrentLevel;

	// Token: 0x04001A79 RID: 6777
	public static double PushRate = 0.3;
}
