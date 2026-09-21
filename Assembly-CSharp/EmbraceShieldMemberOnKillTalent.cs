using System;
using System.Collections.Generic;

// Token: 0x020003CE RID: 974
[Serializable]
public class EmbraceShieldMemberOnKillTalent : IAdventurerTalent
{
	// Token: 0x06001A47 RID: 6727 RVA: 0x000C1C6D File Offset: 0x000C006D
	public EmbraceShieldMemberOnKillTalent()
	{
	}

	// Token: 0x06001A48 RID: 6728 RVA: 0x000C1C75 File Offset: 0x000C0075
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.EmbraceShieldMemberOnKill;
	}

	// Token: 0x06001A49 RID: 6729 RVA: 0x000C1C79 File Offset: 0x000C0079
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001A4A RID: 6730 RVA: 0x000C1C7C File Offset: 0x000C007C
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001A4B RID: 6731 RVA: 0x000C1C84 File Offset: 0x000C0084
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001A4C RID: 6732 RVA: 0x000C1C8C File Offset: 0x000C008C
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001A4D RID: 6733 RVA: 0x000C1C94 File Offset: 0x000C0094
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001A4E RID: 6734 RVA: 0x000C1C97 File Offset: 0x000C0097
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001A4F RID: 6735 RVA: 0x000C1CA7 File Offset: 0x000C00A7
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001A50 RID: 6736 RVA: 0x000C1CB7 File Offset: 0x000C00B7
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001A51 RID: 6737 RVA: 0x000C1CC0 File Offset: 0x000C00C0
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x06001A52 RID: 6738 RVA: 0x000C1CC7 File Offset: 0x000C00C7
	// Note: this type is marked as 'beforefieldinit'.
	static EmbraceShieldMemberOnKillTalent()
	{
	}

	// Token: 0x040019C3 RID: 6595
	public string Id;

	// Token: 0x040019C4 RID: 6596
	public string AdditionalKey;

	// Token: 0x040019C5 RID: 6597
	public int CurrentLevel;

	// Token: 0x040019C6 RID: 6598
	public static int NumberOfShields = 1;
}
