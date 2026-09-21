using System;
using System.Collections.Generic;

// Token: 0x020003C5 RID: 965
[Serializable]
public class DispelPositiveEffectOnHitTalent : IAdventurerTalent
{
	// Token: 0x060019D9 RID: 6617 RVA: 0x000C10B3 File Offset: 0x000BF4B3
	public DispelPositiveEffectOnHitTalent()
	{
	}

	// Token: 0x060019DA RID: 6618 RVA: 0x000C10BC File Offset: 0x000BF4BC
	public double GetChance()
	{
		if (this.SkillType == SkillType.Freeze)
		{
			return 0.6;
		}
		if (this.SkillType == SkillType.Meteorolite)
		{
			return 0.1;
		}
		if (this.SkillType == SkillType.Scorn)
		{
			return 1.0;
		}
		if (this.SkillType == SkillType.SeedsOfSin)
		{
			return 1.0;
		}
		return 0.0;
	}

	// Token: 0x060019DB RID: 6619 RVA: 0x000C113C File Offset: 0x000BF53C
	public int GetNumberOfDispels()
	{
		if (this.SkillType == SkillType.Freeze)
		{
			return 2;
		}
		if (this.SkillType == SkillType.Meteorolite)
		{
			return 1;
		}
		if (this.SkillType == SkillType.Scorn)
		{
			return 1;
		}
		if (this.SkillType == SkillType.SeedsOfSin)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060019DC RID: 6620 RVA: 0x000C1192 File Offset: 0x000BF592
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.DispelPositiveEffectsOnHit;
	}

	// Token: 0x060019DD RID: 6621 RVA: 0x000C1195 File Offset: 0x000BF595
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x060019DE RID: 6622 RVA: 0x000C1198 File Offset: 0x000BF598
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x060019DF RID: 6623 RVA: 0x000C11A0 File Offset: 0x000BF5A0
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x060019E0 RID: 6624 RVA: 0x000C11A8 File Offset: 0x000BF5A8
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x060019E1 RID: 6625 RVA: 0x000C11B0 File Offset: 0x000BF5B0
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x060019E2 RID: 6626 RVA: 0x000C11B3 File Offset: 0x000BF5B3
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x060019E3 RID: 6627 RVA: 0x000C11C3 File Offset: 0x000BF5C3
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x060019E4 RID: 6628 RVA: 0x000C11D3 File Offset: 0x000BF5D3
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x060019E5 RID: 6629 RVA: 0x000C11DC File Offset: 0x000BF5DC
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x04001991 RID: 6545
	public string Id;

	// Token: 0x04001992 RID: 6546
	public string AdditionalKey;

	// Token: 0x04001993 RID: 6547
	public int CurrentLevel;

	// Token: 0x04001994 RID: 6548
	public SkillType SkillType;

	// Token: 0x04001995 RID: 6549
	public int SlotNumber;
}
