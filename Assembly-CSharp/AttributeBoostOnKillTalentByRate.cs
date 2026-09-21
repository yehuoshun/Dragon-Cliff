using System;
using System.Collections.Generic;

// Token: 0x020003B5 RID: 949
[Serializable]
public class AttributeBoostOnKillTalentByRate : IAdventurerTalent
{
	// Token: 0x06001949 RID: 6473 RVA: 0x000C034A File Offset: 0x000BE74A
	public AttributeBoostOnKillTalentByRate()
	{
	}

	// Token: 0x0600194A RID: 6474 RVA: 0x000C0354 File Offset: 0x000BE754
	public List<BoostSetting> GetBoosts()
	{
		if (this.SkillType == SkillType.BladeRain)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.1,
					BoostAttribute = AttributeType.Strength
				}
			};
		}
		if (this.SkillType == SkillType.FireBlast)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.1,
					BoostAttribute = AttributeType.Agility
				}
			};
		}
		if (this.SkillType == SkillType.Meteorolite)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.06,
					BoostAttribute = AttributeType.DamageReduction
				}
			};
		}
		if (this.SkillType == SkillType.SwallowFire)
		{
			if (this.SlotNumber == 1)
			{
				return new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = 0.06,
						BoostAttribute = AttributeType.Allresistances
					}
				};
			}
			if (this.SlotNumber == 2)
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
		}
		return new List<BoostSetting>();
	}

	// Token: 0x0600194B RID: 6475 RVA: 0x000C049A File Offset: 0x000BE89A
	public int GetMaxStack()
	{
		return 1;
	}

	// Token: 0x0600194C RID: 6476 RVA: 0x000C049D File Offset: 0x000BE89D
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.AttributeBoostOnKillByRate;
	}

	// Token: 0x0600194D RID: 6477 RVA: 0x000C04A0 File Offset: 0x000BE8A0
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x0600194E RID: 6478 RVA: 0x000C04A3 File Offset: 0x000BE8A3
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x0600194F RID: 6479 RVA: 0x000C04AB File Offset: 0x000BE8AB
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x06001950 RID: 6480 RVA: 0x000C04B3 File Offset: 0x000BE8B3
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x06001951 RID: 6481 RVA: 0x000C04BB File Offset: 0x000BE8BB
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001952 RID: 6482 RVA: 0x000C04BE File Offset: 0x000BE8BE
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001953 RID: 6483 RVA: 0x000C04CE File Offset: 0x000BE8CE
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001954 RID: 6484 RVA: 0x000C04DE File Offset: 0x000BE8DE
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001955 RID: 6485 RVA: 0x000C04E7 File Offset: 0x000BE8E7
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x0400195A RID: 6490
	public string Id;

	// Token: 0x0400195B RID: 6491
	public string AdditionalKey;

	// Token: 0x0400195C RID: 6492
	public int CurrentLevel;

	// Token: 0x0400195D RID: 6493
	public SkillType SkillType;

	// Token: 0x0400195E RID: 6494
	public int SlotNumber;
}
