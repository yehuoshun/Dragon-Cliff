using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000A77 RID: 2679
public abstract class BossUnitConfigurationBase : MonsterUnitConfigurationBase
{
	// Token: 0x060048E6 RID: 18662 RVA: 0x001E0532 File Offset: 0x001DE932
	protected BossUnitConfigurationBase()
	{
	}

	// Token: 0x060048E7 RID: 18663 RVA: 0x001E053C File Offset: 0x001DE93C
	protected static double GetEpicInvitationDropRate()
	{
		double num = 0.02;
		double num2 = GameWorld.instance.PlayerProfile.GetResidentEffects<RecruitmentResidentEffect>().Sum((RecruitmentResidentEffect r) => r.Chance);
		if (num2 > 5.0)
		{
			num2 = 5.0;
		}
		return num * (1.0 + num2);
	}

	// Token: 0x060048E8 RID: 18664 RVA: 0x001E05AC File Offset: 0x001DE9AC
	protected static double GetRareInvitationDropRate()
	{
		double num = 0.05;
		double num2 = GameWorld.instance.PlayerProfile.GetResidentEffects<RecruitmentResidentEffect>().Sum((RecruitmentResidentEffect r) => r.Chance);
		if (num2 > 5.0)
		{
			num2 = 5.0;
		}
		return num * (1.0 + num2);
	}

	// Token: 0x060048E9 RID: 18665 RVA: 0x001E061C File Offset: 0x001DEA1C
	protected static double GetCommonInvitationDropRate()
	{
		double num = 0.15;
		double num2 = GameWorld.instance.PlayerProfile.GetResidentEffects<RecruitmentResidentEffect>().Sum((RecruitmentResidentEffect r) => r.Chance);
		if (num2 > 5.0)
		{
			num2 = 5.0;
		}
		return num * (1.0 + num2);
	}

	// Token: 0x060048EA RID: 18666 RVA: 0x001E068C File Offset: 0x001DEA8C
	protected List<ResourceUpdate> GenerateScrollMats(ResourceType type, DifficultyLevelMeasurement measurement)
	{
		double num = 0.0;
		if (GameWorld.instance.PlayerProfile.AchievedDifficultyValue > 140.0)
		{
			if (measurement.StarRating == 1)
			{
				if (measurement.DifficultyValue <= 100.0)
				{
					num = 0.01;
				}
				else if (measurement.DifficultyValue <= 200.0)
				{
					num = 0.05;
				}
				else
				{
					num = 0.1;
				}
			}
			if (measurement.StarRating > 1)
			{
				if (measurement.DifficultyValue <= 80.0)
				{
					num = 0.12;
				}
				else if (measurement.DifficultyValue <= 180.0)
				{
					num = 0.18;
				}
				else
				{
					num = 0.3;
				}
			}
		}
		if ((double)UnityEngine.Random.value <= num)
		{
			return new List<ResourceUpdate>
			{
				new ResourceUpdate
				{
					ResourceType = type,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>()
				}
			};
		}
		return new List<ResourceUpdate>();
	}

	// Token: 0x060048EB RID: 18667 RVA: 0x001E07D8 File Offset: 0x001DEBD8
	public sealed override UnitGrowthProfile GetMonsterGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		UnitGrowthProfile growthProfile = this.CorrespondingClassStyle.GetStyleConfig().GetGrowthProfile(measurement);
		growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.02, false);
		AttributeType type = (this.CorrespondingClassStyle.GetClassCategory() != ClassCategory.CasterAssassin) ? AttributeType.Strength : AttributeType.Intelligience;
		double num = (from v in growthProfile.UnitGrowthValues
		where v.AttributeType == AttributeType.Intelligience || v.AttributeType == AttributeType.Strength
		select v).Sum((UnitGrowthValue a) => a.Potential);
		double num2 = (from v in growthProfile.UnitGrowthValues
		where v.AttributeType == AttributeType.Vitality
		select v).Sum((UnitGrowthValue a) => a.Potential);
		double num3 = (from v in growthProfile.UnitGrowthValues
		where v.AttributeType == AttributeType.Agility
		select v).Sum((UnitGrowthValue a) => a.Potential);
		if (measurement.StarRating == 1)
		{
			growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.06, false);
			if (measurement.DifficultyValue <= 8.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 1.5, false);
				growthProfile.SetValue(type, num * 1.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
			}
			else if (measurement.DifficultyValue <= 15.0)
			{
				growthProfile.SetValue(type, num * 2.3, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 3.5, false);
				base.SetProfileResistanceToValue(200.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 21.0)
			{
				growthProfile.SetValue(type, num * 2.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 4.5, false);
				base.SetProfileResistanceToValue(250.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 28.0)
			{
				growthProfile.SetValue(type, num * 3.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 5.0, false);
				base.SetProfileResistanceToValue(350.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 35.0)
			{
				growthProfile.SetValue(type, num * 4.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 6.0, false);
				base.SetProfileResistanceToValue(450.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 42.0)
			{
				growthProfile.SetValue(type, num * 5.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 7.0, false);
				base.SetProfileResistanceToValue(500.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 48.0)
			{
				growthProfile.SetValue(type, num * 5.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 7.5, false);
				base.SetProfileResistanceToValue(600.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 55.0)
			{
				growthProfile.SetValue(type, num * 5.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 8.0, false);
				base.SetProfileResistanceToValue(650.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 62.0)
			{
				growthProfile.SetValue(type, num * 5.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 9.0, false);
				base.SetProfileResistanceToValue(700.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 70.0)
			{
				growthProfile.SetValue(type, num * 5.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 9.0, false);
				base.SetProfileResistanceToValue(750.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 85.0)
			{
				growthProfile.SetValue(type, num * 5.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 9.0, false);
				base.SetProfileResistanceToValue(800.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 110.0)
			{
				growthProfile.SetValue(type, num * 5.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 10.0, false);
				base.SetProfileResistanceToValue(850.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 110.0)
			{
				growthProfile.SetValue(type, num * 5.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 11.0, false);
				base.SetProfileResistanceToValue(900.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 130.0)
			{
				growthProfile.SetValue(type, num * 5.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 11.0, false);
				base.SetProfileResistanceToValue(1100.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 150.0)
			{
				growthProfile.SetValue(type, num * 5.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 12.0, false);
				base.SetProfileResistanceToValue(1300.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 170.0)
			{
				growthProfile.SetValue(type, num * 5.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 12.0, false);
				base.SetProfileResistanceToValue(1500.0, growthProfile);
			}
			else
			{
				growthProfile.SetValue(type, num * 5.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * (14.0 + (double)((int)((measurement.DifficultyValue - 170.0) / 10.0))), false);
				base.SetProfileResistanceToValue((double)(2000 + (int)((measurement.DifficultyValue - 170.0) * 10.0)), growthProfile);
			}
		}
		else if (measurement.StarRating == -1)
		{
			if (measurement.DifficultyValue <= 25.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.1, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.02, false);
				growthProfile.SetValue(type, num * 1.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 35.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 9000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 50.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 120.0, false);
				base.SetProfileResistanceToValue(9000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 50.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.1, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.04, false);
				growthProfile.SetValue(type, num * 1.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 40.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 12000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 50.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 140.0, false);
				base.SetProfileResistanceToValue(12000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 100.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.1, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.05, false);
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 45.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 15000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 70.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 160.0, false);
				base.SetProfileResistanceToValue(15000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 150.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.2, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.07, false);
				growthProfile.SetValue(type, num * 1.3, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 50.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 18000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 80.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 180.0, false);
				base.SetProfileResistanceToValue(18000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 200.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.1, false);
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 55.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 21000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 90.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 200.0, false);
				base.SetProfileResistanceToValue(21000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 250.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.13, false);
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 60.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 24000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 2.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 100.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 230.0, false);
				base.SetProfileResistanceToValue(24000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 300.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.16, false);
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.3, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 65.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 27000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 120.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 260.0, false);
				base.SetProfileResistanceToValue(27000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 350.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.17, false);
				growthProfile.SetValue(type, num * 1.1, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.3, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 70.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 30000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 120.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 280.0, false);
				base.SetProfileResistanceToValue(30000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 400.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.3, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.18, false);
				growthProfile.SetValue(type, num * 1.1, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.3, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 75.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 33000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 140.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 300.0, false);
				base.SetProfileResistanceToValue(33000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 500.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.3, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.19, false);
				growthProfile.SetValue(type, num * 1.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.3, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 80.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 36000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 130.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 340.0, false);
				base.SetProfileResistanceToValue(36000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 600.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.3, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.21, false);
				growthProfile.SetValue(type, num * 0.9, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 100.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 40000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.2, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 200.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 420.0, false);
				base.SetProfileResistanceToValue(40000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 700.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.3, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.22, false);
				growthProfile.SetValue(type, num * 0.9, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 120.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 42000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 4.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 300.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 550.0, false);
				base.SetProfileResistanceToValue(42000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 750.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.3, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.22, false);
				growthProfile.SetValue(type, num * 0.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 135.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 46000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 4.5, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 330.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 650.0, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.15, false);
				base.SetProfileResistanceToValue(50000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 800.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.3, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.22, false);
				growthProfile.SetValue(type, num * 0.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 155.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 51000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 5.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 350.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 700.0, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.15, false);
				base.SetProfileResistanceToValue(58000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 850.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.3, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.22, false);
				growthProfile.SetValue(type, num * 0.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 165.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 54000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 5.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 370.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 750.0, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.15, false);
				base.SetProfileResistanceToValue(65000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 900.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.3, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.22, false);
				growthProfile.SetValue(type, num * 0.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 175.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 58000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 5.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 390.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 900.0, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.15, false);
				base.SetProfileResistanceToValue(72000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 950.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.3, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.22, false);
				growthProfile.SetValue(type, num * 0.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 200.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 62000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 5.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 410.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 1100.0, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.15, false);
				base.SetProfileResistanceToValue(80000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 1000.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.3, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.22, false);
				growthProfile.SetValue(type, num * 0.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 215.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 64000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 5.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.7, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 430.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 1300.0, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.15, false);
				base.SetProfileResistanceToValue(90000.0, growthProfile);
			}
			else
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.3, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.22, false);
				growthProfile.SetValue(type, num * 0.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * (double)(215 + (int)((measurement.DifficultyValue - 1000.0) * 4.0)), false);
				if (measurement.DifficultyValue >= 8000.0)
				{
					growthProfile.SetValue(AttributeType.Vitality, num2 * (double)(850 + (int)(measurement.DifficultyValue - 1000.0) * 1000), false);
				}
				if (measurement.DifficultyValue >= 12000.0)
				{
					growthProfile.SetValue(AttributeType.Vitality, num2 * (double)(850 + (int)(measurement.DifficultyValue - 1000.0) * 4000), false);
				}
				int num4 = 64000 + (int)((measurement.DifficultyValue - 1000.0) * 15.0);
				if (measurement.DifficultyValue <= 3000.0 && num4 > 130000)
				{
					num4 = 130000;
				}
				if (measurement.DifficultyValue > 5000.0)
				{
					growthProfile.SetValue(type, num * (4.0 + 1.5 * (measurement.DifficultyValue - 5000.0) / 1000.0), false);
				}
				growthProfile.SetValue(AttributeType.Resilience, (double)num4, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.7, false);
				int num5 = 430 + (int)(measurement.DifficultyValue - 1000.0);
				if (num5 > 10000)
				{
					num5 = 10000;
				}
				growthProfile.SetValue(AttributeType.EffectHitRating, (double)num5, false);
				int num6 = 1300 + (int)(measurement.DifficultyValue - 1000.0) * 5;
				if (num6 > 30000)
				{
					num6 = 30000;
				}
				growthProfile.SetValue(AttributeType.EffectResistanceRating, (double)num6, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.15, false);
				int num7 = 90000 + (int)((measurement.DifficultyValue - 1000.0) * 550.0);
				if (measurement.DifficultyValue <= 3000.0 && num7 > 260000)
				{
					num7 = 260000;
				}
				base.SetProfileResistanceToValue((double)num7, growthProfile);
			}
		}
		else
		{
			growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.04, false);
			if (measurement.DifficultyValue <= 15.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 13.0, false);
				growthProfile.SetValue(type, num * 2.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Resilience, 3000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 10.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 100.0, false);
				base.SetProfileResistanceToValue(3000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 30.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 14.0, false);
				growthProfile.SetValue(type, num * 2.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Resilience, 4000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 30.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 120.0, false);
				base.SetProfileResistanceToValue(4000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 50.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 15.0, false);
				growthProfile.SetValue(type, num * 2.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Resilience, 5000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 50.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 140.0, false);
				base.SetProfileResistanceToValue(5000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 70.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 15.0, false);
				growthProfile.SetValue(type, num * 2.7, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Resilience, 6000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 70.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 180.0, false);
				base.SetProfileResistanceToValue(6000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 90.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 16.0, false);
				growthProfile.SetValue(type, num * 2.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Resilience, 7000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 100.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 200.0, false);
				base.SetProfileResistanceToValue(7000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 120.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 17.0, false);
				growthProfile.SetValue(type, num * 2.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Resilience, 8000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 110.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 250.0, false);
				base.SetProfileResistanceToValue(8000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 150.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 20.0, false);
				growthProfile.SetValue(type, num * 3.1, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Resilience, 9000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 120.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 300.0, false);
				base.SetProfileResistanceToValue(9000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 170.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 23.0, false);
				growthProfile.SetValue(type, num * 3.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Resilience, 10000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 130.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 320.0, false);
				base.SetProfileResistanceToValue(10000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 190.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 26.0, false);
				growthProfile.SetValue(type, num * 3.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Resilience, 10000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 140.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 340.0, false);
				base.SetProfileResistanceToValue(10000.0, growthProfile);
			}
			else
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 28.0, false);
				growthProfile.SetValue(type, num * 4.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Resilience, (double)(12000 + (int)((measurement.DifficultyValue - 190.0) * 10.0)), false);
				growthProfile.SetValue(AttributeType.EffectHitRating, (double)(150 + (int)((measurement.DifficultyValue - 190.0) / 10.0)), false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, (double)(350 + (int)((measurement.DifficultyValue - 190.0) * 10.0)), false);
				base.SetProfileResistanceToValue((double)(12000 + (int)((measurement.DifficultyValue - 190.0) * 10.0)), growthProfile);
			}
		}
		return this.FurtherProfileModification(growthProfile, measurement);
	}

	// Token: 0x060048EC RID: 18668 RVA: 0x001E2C18 File Offset: 0x001E1018
	public override List<ResourceUpdate> GenerateGuarranteedDrops(Adventure fromAdventure)
	{
		List<ResourceUpdate> list = base.GenerateGuarranteedDrops(fromAdventure);
		if (fromAdventure.CorrespondingDifficultyMeasurement.StarRating == 1 && (double)UnityEngine.Random.value <= 0.0025 && fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue > 100.0)
		{
			list.Add(new ResourceUpdate
			{
				ResourceType = ResourceType.FragmentOfDemon,
				ChangeAmount = 1.0,
				RelatedItems = new List<Item>()
			});
		}
		if (fromAdventure.CorrespondingDifficultyMeasurement.StarRating == 2)
		{
			if (fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue <= 50.0)
			{
				if ((double)UnityEngine.Random.value <= 0.02)
				{
					list.Add(new ResourceUpdate
					{
						ResourceType = ResourceType.FragmentOfDemon,
						ChangeAmount = 1.0,
						RelatedItems = new List<Item>()
					});
				}
			}
			else if (fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue <= 100.0)
			{
				if ((double)UnityEngine.Random.value <= 0.05)
				{
					list.Add(new ResourceUpdate
					{
						ResourceType = ResourceType.FragmentOfDemon,
						ChangeAmount = 1.0,
						RelatedItems = new List<Item>()
					});
				}
			}
			else if (fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue <= 150.0 && (double)UnityEngine.Random.value <= 0.08)
			{
				list.Add(new ResourceUpdate
				{
					ResourceType = ResourceType.FragmentOfDemon,
					ChangeAmount = 1.0,
					RelatedItems = new List<Item>()
				});
			}
		}
		if ((fromAdventure.CorrespondingDifficultyMeasurement.StarRating == 2 || fromAdventure.CorrespondingDifficultyMeasurement.StarRating == -1 || fromAdventure.CorrespondingDifficultyMeasurement.DifficultyValue >= 100.0) && (double)UnityEngine.Random.value <= 0.12)
		{
			list.AddRange(fromAdventure.CorrespondingDifficultyMeasurement.GenerateRandomDevice());
		}
		return list;
	}

	// Token: 0x060048ED RID: 18669 RVA: 0x001E2E36 File Offset: 0x001E1236
	protected virtual UnitGrowthProfile FurtherProfileModification(UnitGrowthProfile originalGrowthProfile, DifficultyLevelMeasurement measurement)
	{
		return originalGrowthProfile;
	}

	// Token: 0x060048EE RID: 18670 RVA: 0x001E2E3C File Offset: 0x001E123C
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		List<ISpecialEffectDataLoad> list = new List<ISpecialEffectDataLoad>();
		if (relevantDifficultyLevelMeasurement.DifficultyValue >= 8.0 || relevantDifficultyLevelMeasurement.StarRating != 1)
		{
			list.AddRange((from e in UnitExtensions.GetAllDamageElements()
			select new ElementEffectData
			{
				ElementType = e
			}).Cast<ISpecialEffectDataLoad>());
		}
		list.AddRange(this.BossLevelSpecialEffectsFilter(relevantDifficultyLevelMeasurement));
		if (relevantDifficultyLevelMeasurement.StarRating == 2)
		{
			List<SpecialEffectPresence> list2 = base.GetbossSpecialEffectsPresences();
			if (list2.Any<SpecialEffectPresence>())
			{
				SpecialEffectPresence specialEffectPresence = list2.WeightedRandomSelect<SpecialEffectPresence>();
				using (List<ISpecialEffectDataLoad>.Enumerator enumerator = specialEffectPresence.SpecialEffectDataLoads.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ISpecialEffectDataLoad effect = enumerator.Current;
						if (list.All((ISpecialEffectDataLoad r) => r.GetSpecialEffectType() != effect.GetSpecialEffectType()))
						{
							list.Add(effect);
						}
					}
				}
			}
		}
		if (relevantDifficultyLevelMeasurement.DifficultyValue <= 140.0 && relevantDifficultyLevelMeasurement.StarRating == 1)
		{
			list.Add(new NegativeEffectSpeedupData
			{
				DecreaseRate = 0.7
			});
		}
		else
		{
			list.Add(new NegativeEffectSpeedupData
			{
				DecreaseRate = 0.75
			});
			if (relevantDifficultyLevelMeasurement.DifficultyValue > 900.0)
			{
				list.Add(new TurnResistanceData
				{
					IsStar = false,
					Rate = 0.9
				});
			}
		}
		return list;
	}

	// Token: 0x060048EF RID: 18671 RVA: 0x001E2FEC File Offset: 0x001E13EC
	protected virtual List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x060048F0 RID: 18672 RVA: 0x001E2FF3 File Offset: 0x001E13F3
	[CompilerGenerated]
	private static double <GetEpicInvitationDropRate>m__0(RecruitmentResidentEffect r)
	{
		return r.Chance;
	}

	// Token: 0x060048F1 RID: 18673 RVA: 0x001E2FFB File Offset: 0x001E13FB
	[CompilerGenerated]
	private static double <GetRareInvitationDropRate>m__1(RecruitmentResidentEffect r)
	{
		return r.Chance;
	}

	// Token: 0x060048F2 RID: 18674 RVA: 0x001E3003 File Offset: 0x001E1403
	[CompilerGenerated]
	private static double <GetCommonInvitationDropRate>m__2(RecruitmentResidentEffect r)
	{
		return r.Chance;
	}

	// Token: 0x060048F3 RID: 18675 RVA: 0x001E300B File Offset: 0x001E140B
	[CompilerGenerated]
	private static bool <GetMonsterGrowthProfile>m__3(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Intelligience || v.AttributeType == AttributeType.Strength;
	}

	// Token: 0x060048F4 RID: 18676 RVA: 0x001E3025 File Offset: 0x001E1425
	[CompilerGenerated]
	private static double <GetMonsterGrowthProfile>m__4(UnitGrowthValue a)
	{
		return a.Potential;
	}

	// Token: 0x060048F5 RID: 18677 RVA: 0x001E302D File Offset: 0x001E142D
	[CompilerGenerated]
	private static bool <GetMonsterGrowthProfile>m__5(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x060048F6 RID: 18678 RVA: 0x001E3038 File Offset: 0x001E1438
	[CompilerGenerated]
	private static double <GetMonsterGrowthProfile>m__6(UnitGrowthValue a)
	{
		return a.Potential;
	}

	// Token: 0x060048F7 RID: 18679 RVA: 0x001E3040 File Offset: 0x001E1440
	[CompilerGenerated]
	private static bool <GetMonsterGrowthProfile>m__7(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Agility;
	}

	// Token: 0x060048F8 RID: 18680 RVA: 0x001E304B File Offset: 0x001E144B
	[CompilerGenerated]
	private static double <GetMonsterGrowthProfile>m__8(UnitGrowthValue a)
	{
		return a.Potential;
	}

	// Token: 0x060048F9 RID: 18681 RVA: 0x001E3054 File Offset: 0x001E1454
	[CompilerGenerated]
	private static ElementEffectData <GetSpecialEffectDataLoads>m__9(OutputType e)
	{
		return new ElementEffectData
		{
			ElementType = e
		};
	}

	// Token: 0x04003A86 RID: 14982
	[CompilerGenerated]
	private static Func<RecruitmentResidentEffect, double> <>f__am$cache0;

	// Token: 0x04003A87 RID: 14983
	[CompilerGenerated]
	private static Func<RecruitmentResidentEffect, double> <>f__am$cache1;

	// Token: 0x04003A88 RID: 14984
	[CompilerGenerated]
	private static Func<RecruitmentResidentEffect, double> <>f__am$cache2;

	// Token: 0x04003A89 RID: 14985
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache3;

	// Token: 0x04003A8A RID: 14986
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache4;

	// Token: 0x04003A8B RID: 14987
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache5;

	// Token: 0x04003A8C RID: 14988
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache6;

	// Token: 0x04003A8D RID: 14989
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache7;

	// Token: 0x04003A8E RID: 14990
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache8;

	// Token: 0x04003A8F RID: 14991
	[CompilerGenerated]
	private static Func<OutputType, ElementEffectData> <>f__am$cache9;

	// Token: 0x02001078 RID: 4216
	[CompilerGenerated]
	private sealed class <GetSpecialEffectDataLoads>c__AnonStorey0
	{
		// Token: 0x0600696E RID: 26990 RVA: 0x001E306F File Offset: 0x001E146F
		public <GetSpecialEffectDataLoads>c__AnonStorey0()
		{
		}

		// Token: 0x0600696F RID: 26991 RVA: 0x001E3077 File Offset: 0x001E1477
		internal bool <>m__0(ISpecialEffectDataLoad r)
		{
			return r.GetSpecialEffectType() != this.effect.GetSpecialEffectType();
		}

		// Token: 0x040063F9 RID: 25593
		internal ISpecialEffectDataLoad effect;
	}
}
