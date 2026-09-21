using System;
using System.Collections.Generic;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class RestrictionOfTimeTalent : IAdventurerTalent
{
	// Token: 0x06001BCC RID: 7116 RVA: 0x000C3898 File Offset: 0x000C1C98
	public RestrictionOfTimeTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001BCD RID: 7117 RVA: 0x000C38D6 File Offset: 0x000C1CD6
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.RestrictionOfTime;
	}

	// Token: 0x06001BCE RID: 7118 RVA: 0x000C38DA File Offset: 0x000C1CDA
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001BCF RID: 7119 RVA: 0x000C38DD File Offset: 0x000C1CDD
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001BD0 RID: 7120 RVA: 0x000C38E5 File Offset: 0x000C1CE5
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001BD1 RID: 7121 RVA: 0x000C38ED File Offset: 0x000C1CED
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001BD2 RID: 7122 RVA: 0x000C38F5 File Offset: 0x000C1CF5
	public int GetMaxLevel()
	{
		return RestrictionOfTimeTalent.MaxLevel;
	}

	// Token: 0x06001BD3 RID: 7123 RVA: 0x000C38FC File Offset: 0x000C1CFC
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001BD4 RID: 7124 RVA: 0x000C390C File Offset: 0x000C1D0C
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001BD5 RID: 7125 RVA: 0x000C391C File Offset: 0x000C1D1C
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001BD6 RID: 7126 RVA: 0x000C3928 File Offset: 0x000C1D28
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new RestrictionOfTimeData
			{
				IsStar = false,
				HealRate = RestrictionOfTimeTalent.HealRate * (double)this.CurrentLevel,
				HealSeconds = RestrictionOfTimeTalent.HealSeconds,
				DodgeRateBoost = RestrictionOfTimeTalent.DodgeRateBoost * (double)this.CurrentLevel
			}
		};
	}

	// Token: 0x06001BD7 RID: 7127 RVA: 0x000C3981 File Offset: 0x000C1D81
	// Note: this type is marked as 'beforefieldinit'.
	static RestrictionOfTimeTalent()
	{
	}

	// Token: 0x04001A5C RID: 6748
	public static double DodgeRateBoost = 0.08;

	// Token: 0x04001A5D RID: 6749
	public static double HealRate = 0.1;

	// Token: 0x04001A5E RID: 6750
	public static int HealSeconds = 3;

	// Token: 0x04001A5F RID: 6751
	public string Id;

	// Token: 0x04001A60 RID: 6752
	public string AdditionalKey;

	// Token: 0x04001A61 RID: 6753
	public int CurrentLevel;

	// Token: 0x04001A62 RID: 6754
	public static int MaxLevel = 3;
}
