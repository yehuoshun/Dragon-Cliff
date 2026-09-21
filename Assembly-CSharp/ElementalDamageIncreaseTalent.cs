using System;
using System.Collections.Generic;

// Token: 0x020003CD RID: 973
[Serializable]
public class ElementalDamageIncreaseTalent : IAdventurerTalent
{
	// Token: 0x06001A3B RID: 6715 RVA: 0x000C1ADD File Offset: 0x000BFEDD
	public ElementalDamageIncreaseTalent()
	{
	}

	// Token: 0x06001A3C RID: 6716 RVA: 0x000C1AE8 File Offset: 0x000BFEE8
	public double GetRate()
	{
		if (this.SkillType == SkillType.Assassination)
		{
			return 0.1;
		}
		if (this.SkillType == SkillType.BladeRain)
		{
			return 0.06;
		}
		if (this.SkillType == SkillType.Lightning)
		{
			return 0.06;
		}
		if (this.SkillType == SkillType.Meteorolite)
		{
			return 0.03;
		}
		if (this.SkillType == SkillType.SeedsOfSin)
		{
			return 0.1;
		}
		if (this.SkillType == SkillType.StealSoul)
		{
			return 0.1;
		}
		if (this.SkillType == SkillType.SwallowFire)
		{
			return 0.06;
		}
		if (this.SkillType == SkillType.DeadlyBlade)
		{
			return 0.1;
		}
		if (this.SkillType == SkillType.Swordmanship)
		{
			return 0.1;
		}
		if (this.SkillType == SkillType.FireBlast)
		{
			return 0.06;
		}
		if (this.SkillType == SkillType.PoisonBlade)
		{
			return 0.1;
		}
		return 0.0;
	}

	// Token: 0x06001A3D RID: 6717 RVA: 0x000C1C1C File Offset: 0x000C001C
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.ElementalDamageIncrease;
	}

	// Token: 0x06001A3E RID: 6718 RVA: 0x000C1C1F File Offset: 0x000C001F
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001A3F RID: 6719 RVA: 0x000C1C22 File Offset: 0x000C0022
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001A40 RID: 6720 RVA: 0x000C1C2A File Offset: 0x000C002A
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001A41 RID: 6721 RVA: 0x000C1C32 File Offset: 0x000C0032
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001A42 RID: 6722 RVA: 0x000C1C3A File Offset: 0x000C003A
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001A43 RID: 6723 RVA: 0x000C1C3D File Offset: 0x000C003D
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001A44 RID: 6724 RVA: 0x000C1C4D File Offset: 0x000C004D
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001A45 RID: 6725 RVA: 0x000C1C5D File Offset: 0x000C005D
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001A46 RID: 6726 RVA: 0x000C1C66 File Offset: 0x000C0066
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x040019BE RID: 6590
	public string Id;

	// Token: 0x040019BF RID: 6591
	public string AdditionalKey;

	// Token: 0x040019C0 RID: 6592
	public int CurrentLevel;

	// Token: 0x040019C1 RID: 6593
	public SkillType SkillType;

	// Token: 0x040019C2 RID: 6594
	public int SlotNumber;
}
