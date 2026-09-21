using System;
using System.Collections.Generic;

// Token: 0x020003B8 RID: 952
[Serializable]
public class BlackBloodTalent : IAdventurerTalent
{
	// Token: 0x06001972 RID: 6514 RVA: 0x000C09EC File Offset: 0x000BEDEC
	public BlackBloodTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001973 RID: 6515 RVA: 0x000C0A2A File Offset: 0x000BEE2A
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.BlackBlood;
	}

	// Token: 0x06001974 RID: 6516 RVA: 0x000C0A2E File Offset: 0x000BEE2E
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001975 RID: 6517 RVA: 0x000C0A31 File Offset: 0x000BEE31
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001976 RID: 6518 RVA: 0x000C0A39 File Offset: 0x000BEE39
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001977 RID: 6519 RVA: 0x000C0A41 File Offset: 0x000BEE41
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001978 RID: 6520 RVA: 0x000C0A49 File Offset: 0x000BEE49
	public int GetMaxLevel()
	{
		return BlackBloodTalent.MaxLevel;
	}

	// Token: 0x06001979 RID: 6521 RVA: 0x000C0A50 File Offset: 0x000BEE50
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x0600197A RID: 6522 RVA: 0x000C0A60 File Offset: 0x000BEE60
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x0600197B RID: 6523 RVA: 0x000C0A70 File Offset: 0x000BEE70
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x0600197C RID: 6524 RVA: 0x000C0A7C File Offset: 0x000BEE7C
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new BlackBloodData
			{
				IsStar = false,
				Seconds = BlackBloodTalent.Seconds,
				DodgeDecayRate = BlackBloodTalent.DodgeDecayRate * (double)this.CurrentLevel,
				ResistanceDecayRate = BlackBloodTalent.ResistanceDecayRate * (double)this.CurrentLevel
			}
		};
	}

	// Token: 0x0600197D RID: 6525 RVA: 0x000C0AD5 File Offset: 0x000BEED5
	// Note: this type is marked as 'beforefieldinit'.
	static BlackBloodTalent()
	{
	}

	// Token: 0x04001969 RID: 6505
	public static double ResistanceDecayRate = 0.08;

	// Token: 0x0400196A RID: 6506
	public static double DodgeDecayRate = 0.01;

	// Token: 0x0400196B RID: 6507
	public static int Seconds = 5;

	// Token: 0x0400196C RID: 6508
	public string Id;

	// Token: 0x0400196D RID: 6509
	public string AdditionalKey;

	// Token: 0x0400196E RID: 6510
	public int CurrentLevel;

	// Token: 0x0400196F RID: 6511
	public static int MaxLevel = 3;
}
