using System;
using System.Collections.Generic;

// Token: 0x020003D4 RID: 980
[Serializable]
public class FireShieldTalent : IAdventurerTalent
{
	// Token: 0x06001A85 RID: 6789 RVA: 0x000C20F0 File Offset: 0x000C04F0
	public FireShieldTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001A86 RID: 6790 RVA: 0x000C212E File Offset: 0x000C052E
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.FireShield;
	}

	// Token: 0x06001A87 RID: 6791 RVA: 0x000C2132 File Offset: 0x000C0532
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001A88 RID: 6792 RVA: 0x000C2135 File Offset: 0x000C0535
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001A89 RID: 6793 RVA: 0x000C213D File Offset: 0x000C053D
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001A8A RID: 6794 RVA: 0x000C2145 File Offset: 0x000C0545
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001A8B RID: 6795 RVA: 0x000C214D File Offset: 0x000C054D
	public int GetMaxLevel()
	{
		return FireShieldTalent.MaxLevel;
	}

	// Token: 0x06001A8C RID: 6796 RVA: 0x000C2154 File Offset: 0x000C0554
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001A8D RID: 6797 RVA: 0x000C2164 File Offset: 0x000C0564
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001A8E RID: 6798 RVA: 0x000C2174 File Offset: 0x000C0574
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001A8F RID: 6799 RVA: 0x000C2180 File Offset: 0x000C0580
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FireShieldData
			{
				IsStar = false,
				FireSeedRate = FireShieldTalent.Rate * (double)this.CurrentLevel
			}
		};
	}

	// Token: 0x06001A90 RID: 6800 RVA: 0x000C21BB File Offset: 0x000C05BB
	// Note: this type is marked as 'beforefieldinit'.
	static FireShieldTalent()
	{
	}

	// Token: 0x040019DD RID: 6621
	public static double Rate = 0.8;

	// Token: 0x040019DE RID: 6622
	public string Id;

	// Token: 0x040019DF RID: 6623
	public string AdditionalKey;

	// Token: 0x040019E0 RID: 6624
	public int CurrentLevel;

	// Token: 0x040019E1 RID: 6625
	public static int MaxLevel = 3;
}
