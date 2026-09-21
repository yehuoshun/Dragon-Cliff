using System;
using System.Collections.Generic;

// Token: 0x020003C8 RID: 968
[Serializable]
public class DivineHeartTalent : IAdventurerTalent
{
	// Token: 0x060019FE RID: 6654 RVA: 0x000C1330 File Offset: 0x000BF730
	public DivineHeartTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x060019FF RID: 6655 RVA: 0x000C136E File Offset: 0x000BF76E
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.DivineHeart;
	}

	// Token: 0x06001A00 RID: 6656 RVA: 0x000C1372 File Offset: 0x000BF772
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001A01 RID: 6657 RVA: 0x000C1375 File Offset: 0x000BF775
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001A02 RID: 6658 RVA: 0x000C137D File Offset: 0x000BF77D
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001A03 RID: 6659 RVA: 0x000C1385 File Offset: 0x000BF785
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001A04 RID: 6660 RVA: 0x000C138D File Offset: 0x000BF78D
	public int GetMaxLevel()
	{
		return DivineHeartTalent.MaxLevel;
	}

	// Token: 0x06001A05 RID: 6661 RVA: 0x000C1394 File Offset: 0x000BF794
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001A06 RID: 6662 RVA: 0x000C13A4 File Offset: 0x000BF7A4
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001A07 RID: 6663 RVA: 0x000C13B4 File Offset: 0x000BF7B4
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001A08 RID: 6664 RVA: 0x000C13C0 File Offset: 0x000BF7C0
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new DivineHeartData
			{
				IsStar = false,
				Chance = DivineHeartTalent.StartRate + (double)this.CurrentLevel * DivineHeartTalent.RatePerLevel,
				NumberOfFreeCast = 1
			}
		};
	}

	// Token: 0x06001A09 RID: 6665 RVA: 0x000C1408 File Offset: 0x000BF808
	// Note: this type is marked as 'beforefieldinit'.
	static DivineHeartTalent()
	{
	}

	// Token: 0x0400199F RID: 6559
	public static double StartRate = 0.1;

	// Token: 0x040019A0 RID: 6560
	public static double RatePerLevel = 0.1;

	// Token: 0x040019A1 RID: 6561
	public string Id;

	// Token: 0x040019A2 RID: 6562
	public string AdditionalKey;

	// Token: 0x040019A3 RID: 6563
	public int CurrentLevel;

	// Token: 0x040019A4 RID: 6564
	public static int MaxLevel = 3;
}
