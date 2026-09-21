using System;
using System.Collections.Generic;

// Token: 0x020003B4 RID: 948
[Serializable]
public class AttributeBoostOnHealByRateTalent : IAdventurerTalent
{
	// Token: 0x0600193C RID: 6460 RVA: 0x000C0261 File Offset: 0x000BE661
	public AttributeBoostOnHealByRateTalent()
	{
	}

	// Token: 0x0600193D RID: 6461 RVA: 0x000C026C File Offset: 0x000BE66C
	public List<BoostSetting> GetBoosts()
	{
		if (this.SkillType == SkillType.DivineHammer)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.05,
					BoostAttribute = AttributeType.Agility
				}
			};
		}
		if (this.SkillType == SkillType.Pray)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.1,
					BoostAttribute = AttributeType.Allresistances
				}
			};
		}
		return new List<BoostSetting>();
	}

	// Token: 0x0600193E RID: 6462 RVA: 0x000C02F5 File Offset: 0x000BE6F5
	public int GetMaxStack()
	{
		return 3;
	}

	// Token: 0x0600193F RID: 6463 RVA: 0x000C02F8 File Offset: 0x000BE6F8
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.AttributeBoostOnHealByRate;
	}

	// Token: 0x06001940 RID: 6464 RVA: 0x000C02FC File Offset: 0x000BE6FC
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001941 RID: 6465 RVA: 0x000C02FF File Offset: 0x000BE6FF
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001942 RID: 6466 RVA: 0x000C0307 File Offset: 0x000BE707
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001943 RID: 6467 RVA: 0x000C030F File Offset: 0x000BE70F
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001944 RID: 6468 RVA: 0x000C0317 File Offset: 0x000BE717
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001945 RID: 6469 RVA: 0x000C031A File Offset: 0x000BE71A
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001946 RID: 6470 RVA: 0x000C032A File Offset: 0x000BE72A
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001947 RID: 6471 RVA: 0x000C033A File Offset: 0x000BE73A
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001948 RID: 6472 RVA: 0x000C0343 File Offset: 0x000BE743
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x04001956 RID: 6486
	public string Id;

	// Token: 0x04001957 RID: 6487
	public string AdditionalKey;

	// Token: 0x04001958 RID: 6488
	public int CurrentLevel;

	// Token: 0x04001959 RID: 6489
	public SkillType SkillType;
}
