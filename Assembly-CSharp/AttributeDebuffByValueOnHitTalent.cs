using System;
using System.Collections.Generic;

// Token: 0x020003B7 RID: 951
[Serializable]
public class AttributeDebuffByValueOnHitTalent : IAdventurerTalent
{
	// Token: 0x06001964 RID: 6500 RVA: 0x000C0884 File Offset: 0x000BEC84
	public AttributeDebuffByValueOnHitTalent()
	{
	}

	// Token: 0x06001965 RID: 6501 RVA: 0x000C088C File Offset: 0x000BEC8C
	public List<BoostSetting> GetDebuffs()
	{
		if (this.SkillType == SkillType.Lightning)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.15,
					BoostAttribute = AttributeType.ReceivedHealEffectivenessChangeRate
				}
			};
		}
		if (this.SkillType == SkillType.Scorn)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.15,
					BoostAttribute = AttributeType.CritRate
				}
			};
		}
		if (this.SkillType == SkillType.StealSoul)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.3,
					BoostAttribute = AttributeType.CritRate
				}
			};
		}
		if (this.SkillType == SkillType.PoisonBlade)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.25,
					BoostAttribute = AttributeType.ReceivedHealEffectivenessChangeRate
				}
			};
		}
		return new List<BoostSetting>();
	}

	// Token: 0x06001966 RID: 6502 RVA: 0x000C0992 File Offset: 0x000BED92
	public int GetMaxStack()
	{
		return 3;
	}

	// Token: 0x06001967 RID: 6503 RVA: 0x000C0995 File Offset: 0x000BED95
	public int GetLastingSeconds()
	{
		return 5;
	}

	// Token: 0x06001968 RID: 6504 RVA: 0x000C0998 File Offset: 0x000BED98
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.AttributeDebuffByValueOnHit;
	}

	// Token: 0x06001969 RID: 6505 RVA: 0x000C099C File Offset: 0x000BED9C
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x0600196A RID: 6506 RVA: 0x000C099F File Offset: 0x000BED9F
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x0600196B RID: 6507 RVA: 0x000C09A7 File Offset: 0x000BEDA7
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x0600196C RID: 6508 RVA: 0x000C09AF File Offset: 0x000BEDAF
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x0600196D RID: 6509 RVA: 0x000C09B7 File Offset: 0x000BEDB7
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x0600196E RID: 6510 RVA: 0x000C09BA File Offset: 0x000BEDBA
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x0600196F RID: 6511 RVA: 0x000C09CA File Offset: 0x000BEDCA
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001970 RID: 6512 RVA: 0x000C09DA File Offset: 0x000BEDDA
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001971 RID: 6513 RVA: 0x000C09E3 File Offset: 0x000BEDE3
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x04001964 RID: 6500
	public string Id;

	// Token: 0x04001965 RID: 6501
	public string AdditionalKey;

	// Token: 0x04001966 RID: 6502
	public int CurrentLevel;

	// Token: 0x04001967 RID: 6503
	public SkillType SkillType;

	// Token: 0x04001968 RID: 6504
	public int SlotNumber;
}
