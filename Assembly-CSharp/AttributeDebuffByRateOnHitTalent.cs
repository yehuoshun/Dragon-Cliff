using System;
using System.Collections.Generic;

// Token: 0x020003B6 RID: 950
[Serializable]
public class AttributeDebuffByRateOnHitTalent : IAdventurerTalent
{
	// Token: 0x06001956 RID: 6486 RVA: 0x000C04EE File Offset: 0x000BE8EE
	public AttributeDebuffByRateOnHitTalent()
	{
	}

	// Token: 0x06001957 RID: 6487 RVA: 0x000C04F8 File Offset: 0x000BE8F8
	public List<BoostSetting> GetDebuffs()
	{
		if (this.SkillType == SkillType.Lightning)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.06,
					BoostAttribute = AttributeType.Agility
				}
			};
		}
		if (this.SkillType == SkillType.BurningHeart)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.07,
					BoostAttribute = AttributeType.Agility
				}
			};
		}
		if (this.SkillType == SkillType.CurseOfCube)
		{
			if (this.SlotNumber == 1)
			{
				return new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = 0.07,
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
						BoostValue = 0.06,
						BoostAttribute = AttributeType.Agility
					}
				};
			}
		}
		if (this.SkillType == SkillType.DeadlyBlade)
		{
			if (this.SlotNumber == 1)
			{
				return new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = 0.05,
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
		if (this.SkillType == SkillType.Swordmanship)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.08,
					BoostAttribute = AttributeType.Resilience
				}
			};
		}
		if (this.SkillType == SkillType.Shadowless)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.08,
					BoostAttribute = AttributeType.Agility
				}
			};
		}
		if (this.SkillType == SkillType.Arcane)
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
		if (this.SkillType == SkillType.Roar)
		{
			if (this.SlotNumber == 1)
			{
				return new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = 0.08,
						BoostAttribute = AttributeType.Resilience
					}
				};
			}
			if (this.SlotNumber == 2)
			{
				return new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = 0.07,
						BoostAttribute = AttributeType.Agility
					}
				};
			}
		}
		if (this.SkillType == SkillType.DivineHammer)
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
		if (this.SkillType == SkillType.BladeRain)
		{
			return new List<BoostSetting>
			{
				new BoostSetting
				{
					BoostValue = 0.06,
					BoostAttribute = AttributeType.Intelligience
				}
			};
		}
		return new List<BoostSetting>();
	}

	// Token: 0x06001958 RID: 6488 RVA: 0x000C082D File Offset: 0x000BEC2D
	public int GetMaxStack()
	{
		return 3;
	}

	// Token: 0x06001959 RID: 6489 RVA: 0x000C0830 File Offset: 0x000BEC30
	public int GetLastingSeconds()
	{
		return 5;
	}

	// Token: 0x0600195A RID: 6490 RVA: 0x000C0833 File Offset: 0x000BEC33
	public AdventurerTalentType GetCorrespondingType()
	{
		return AdventurerTalentType.AttributeDebuffByRateOnHit;
	}

	// Token: 0x0600195B RID: 6491 RVA: 0x000C0836 File Offset: 0x000BEC36
	public AdventurerTalentTier GetTier()
	{
		return AdventurerTalentTier.Second;
	}

	// Token: 0x0600195C RID: 6492 RVA: 0x000C0839 File Offset: 0x000BEC39
	public string GetAdditionalKey()
	{
		return this.AdditionalKey;
	}

	// Token: 0x0600195D RID: 6493 RVA: 0x000C0841 File Offset: 0x000BEC41
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x0600195E RID: 6494 RVA: 0x000C0849 File Offset: 0x000BEC49
	public int GetCurrentLevel()
	{
		return this.CurrentLevel;
	}

	// Token: 0x0600195F RID: 6495 RVA: 0x000C0851 File Offset: 0x000BEC51
	public int GetMaxLevel()
	{
		return 1;
	}

	// Token: 0x06001960 RID: 6496 RVA: 0x000C0854 File Offset: 0x000BEC54
	public void UpgradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel++;
	}

	// Token: 0x06001961 RID: 6497 RVA: 0x000C0864 File Offset: 0x000BEC64
	public void DowngradeLogic(AdventurerProfile profile)
	{
		this.CurrentLevel--;
	}

	// Token: 0x06001962 RID: 6498 RVA: 0x000C0874 File Offset: 0x000BEC74
	public void ResetLogic(AdventurerProfile profile)
	{
		this.CurrentLevel = 0;
	}

	// Token: 0x06001963 RID: 6499 RVA: 0x000C087D File Offset: 0x000BEC7D
	public List<ISpecialEffectDataLoad> GetSpecialEffects(AdventurerProfile profile)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x0400195F RID: 6495
	public string Id;

	// Token: 0x04001960 RID: 6496
	public string AdditionalKey;

	// Token: 0x04001961 RID: 6497
	public int CurrentLevel;

	// Token: 0x04001962 RID: 6498
	public SkillType SkillType;

	// Token: 0x04001963 RID: 6499
	public int SlotNumber;
}
