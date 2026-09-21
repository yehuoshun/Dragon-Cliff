using System;
using System.Collections.Generic;

// Token: 0x020003EE RID: 1006
[Serializable]
public class PhysicalEnhancementTalent : IAdventurerTalent
{
	// Token: 0x06001B6D RID: 7021 RVA: 0x000C30B8 File Offset: 0x000C14B8
	public PhysicalEnhancementTalent()
	{
		this.Id = Guid.NewGuid().ToString();
		this.AdditionalKey = string.Empty;
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B6E RID: 7022 RVA: 0x000C30F6 File Offset: 0x000C14F6
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.PhysicalEnhancement;
	}

	// Token: 0x06001B6F RID: 7023 RVA: 0x000C30FA File Offset: 0x000C14FA
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Third;
	}

	// Token: 0x06001B70 RID: 7024 RVA: 0x000C30FD File Offset: 0x000C14FD
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001B71 RID: 7025 RVA: 0x000C3105 File Offset: 0x000C1505
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001B72 RID: 7026 RVA: 0x000C310D File Offset: 0x000C150D
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001B73 RID: 7027 RVA: 0x000C3115 File Offset: 0x000C1515
	public int GetMaxLevel()
	{
		return PhysicalEnhancementTalent.MaxLevel;
	}

	// Token: 0x06001B74 RID: 7028 RVA: 0x000C311C File Offset: 0x000C151C
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001B75 RID: 7029 RVA: 0x000C312C File Offset: 0x000C152C
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001B76 RID: 7030 RVA: 0x000C313C File Offset: 0x000C153C
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001B77 RID: 7031 RVA: 0x000C3148 File Offset: 0x000C1548
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new PhysicalEffectEnhancementData
			{
				IsStar = false,
				DodgeRate = PhysicalEnhancementTalent.StartRate + (double)this.CurrentLevel * PhysicalEnhancementTalent.RatePerLevel
			}
		};
	}

	// Token: 0x06001B78 RID: 7032 RVA: 0x000C3189 File Offset: 0x000C1589
	// Note: this type is marked as 'beforefieldinit'.
	static PhysicalEnhancementTalent()
	{
	}

	// Token: 0x04001A36 RID: 6710
	public static double StartRate = 0.01;

	// Token: 0x04001A37 RID: 6711
	public static double RatePerLevel = 0.01;

	// Token: 0x04001A38 RID: 6712
	public string Id;

	// Token: 0x04001A39 RID: 6713
	public string AdditionalKey;

	// Token: 0x04001A3A RID: 6714
	public int CurrentLevel;

	// Token: 0x04001A3B RID: 6715
	public static int MaxLevel = 3;
}
