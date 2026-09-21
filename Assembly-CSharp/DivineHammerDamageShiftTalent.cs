using System;
using System.Collections.Generic;

// Token: 0x020003C7 RID: 967
[Serializable]
public class DivineHammerDamageShiftTalent : IAdventurerTalent
{
	// Token: 0x060019F2 RID: 6642 RVA: 0x000C12C5 File Offset: 0x000BF6C5
	public DivineHammerDamageShiftTalent()
	{
	}

	// Token: 0x060019F3 RID: 6643 RVA: 0x000C12CD File Offset: 0x000BF6CD
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.DivineHammerDamage;
	}

	// Token: 0x060019F4 RID: 6644 RVA: 0x000C12D1 File Offset: 0x000BF6D1
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x060019F5 RID: 6645 RVA: 0x000C12D4 File Offset: 0x000BF6D4
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x060019F6 RID: 6646 RVA: 0x000C12DC File Offset: 0x000BF6DC
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x060019F7 RID: 6647 RVA: 0x000C12E4 File Offset: 0x000BF6E4
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x060019F8 RID: 6648 RVA: 0x000C12EC File Offset: 0x000BF6EC
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x060019F9 RID: 6649 RVA: 0x000C12EF File Offset: 0x000BF6EF
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x060019FA RID: 6650 RVA: 0x000C12FF File Offset: 0x000BF6FF
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x060019FB RID: 6651 RVA: 0x000C130F File Offset: 0x000BF70F
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x060019FC RID: 6652 RVA: 0x000C1318 File Offset: 0x000BF718
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x060019FD RID: 6653 RVA: 0x000C131F File Offset: 0x000BF71F
	// Note: this type is marked as 'beforefieldinit'.
	static DivineHammerDamageShiftTalent()
	{
	}

	// Token: 0x0400199B RID: 6555
	public string Id;

	// Token: 0x0400199C RID: 6556
	public string AdditionalKey;

	// Token: 0x0400199D RID: 6557
	public int CurrentLevel;

	// Token: 0x0400199E RID: 6558
	public static double ExtraDamageRate = 2.0;
}
