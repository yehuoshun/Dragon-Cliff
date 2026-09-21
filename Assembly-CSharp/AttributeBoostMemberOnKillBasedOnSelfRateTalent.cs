using System;
using System.Collections.Generic;

// Token: 0x020003B3 RID: 947
[Serializable]
public class AttributeBoostMemberOnKillBasedOnSelfRateTalent : IAdventurerTalent
{
	// Token: 0x0600192F RID: 6447 RVA: 0x000C01CD File Offset: 0x000BE5CD
	public AttributeBoostMemberOnKillBasedOnSelfRateTalent()
	{
	}

	// Token: 0x06001930 RID: 6448 RVA: 0x000C01D5 File Offset: 0x000BE5D5
	public AttributeType GetBoostType()
	{
		if (this.SkillType == SkillType.Shadowless)
		{
			return AttributeType.Agility;
		}
		return AttributeType.Agility;
	}

	// Token: 0x06001931 RID: 6449 RVA: 0x000C01EA File Offset: 0x000BE5EA
	public double GetBoostRate()
	{
		if (this.SkillType == SkillType.Shadowless)
		{
			return 0.05;
		}
		return 0.0;
	}

	// Token: 0x06001932 RID: 6450 RVA: 0x000C020F File Offset: 0x000BE60F
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.AttributeBoostAllMemberOnKillBasedOnSelfRate;
	}

	// Token: 0x06001933 RID: 6451 RVA: 0x000C0213 File Offset: 0x000BE613
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x06001934 RID: 6452 RVA: 0x000C0216 File Offset: 0x000BE616
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x06001935 RID: 6453 RVA: 0x000C021E File Offset: 0x000BE61E
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001936 RID: 6454 RVA: 0x000C0226 File Offset: 0x000BE626
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001937 RID: 6455 RVA: 0x000C022E File Offset: 0x000BE62E
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001938 RID: 6456 RVA: 0x000C0231 File Offset: 0x000BE631
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001939 RID: 6457 RVA: 0x000C0241 File Offset: 0x000BE641
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x0600193A RID: 6458 RVA: 0x000C0251 File Offset: 0x000BE651
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x0600193B RID: 6459 RVA: 0x000C025A File Offset: 0x000BE65A
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x04001952 RID: 6482
	public string Id;

	// Token: 0x04001953 RID: 6483
	public string AdditionalKey;

	// Token: 0x04001954 RID: 6484
	public int CurrentLevel;

	// Token: 0x04001955 RID: 6485
	public SkillType SkillType;
}
