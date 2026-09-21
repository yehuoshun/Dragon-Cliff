using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000B08 RID: 2824
public abstract class MinionUnitConfigurationBase : MonsterUnitConfigurationBase
{
	// Token: 0x06004BBD RID: 19389 RVA: 0x001DCAE6 File Offset: 0x001DAEE6
	protected MinionUnitConfigurationBase()
	{
	}

	// Token: 0x06004BBE RID: 19390 RVA: 0x001DCAF0 File Offset: 0x001DAEF0
	public sealed override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		List<ISpecialEffectDataLoad> specialEffectDataLoads = this.CorrespondingClassStyle.GetStyleConfig().GetSpecialEffectDataLoads(relevantDifficultyLevelMeasurement);
		if (relevantDifficultyLevelMeasurement.StarRating != 1 || relevantDifficultyLevelMeasurement.DifficultyValue >= 18.0)
		{
			specialEffectDataLoads.AddRange((from e in UnitExtensions.GetAllDamageElements()
			select new ElementEffectData
			{
				ElementType = e
			}).Cast<ISpecialEffectDataLoad>());
		}
		if (relevantDifficultyLevelMeasurement.StarRating != 1 && relevantDifficultyLevelMeasurement.DifficultyValue <= 900.0)
		{
			specialEffectDataLoads.Add(new NegativeEffectSpeedupData
			{
				IsStarEf = new bool?(false),
				DecreaseRate = 0.5
			});
		}
		if (relevantDifficultyLevelMeasurement.StarRating == -1 && relevantDifficultyLevelMeasurement.DifficultyValue > 900.0)
		{
			specialEffectDataLoads.Add(new TurnResistanceData
			{
				Rate = 0.9,
				IsStar = false
			});
			specialEffectDataLoads.Add(new NegativeEffectSpeedupData
			{
				IsStarEf = new bool?(false),
				DecreaseRate = 0.7
			});
		}
		return this.FurtherSpecialEffectsFilter(specialEffectDataLoads, relevantDifficultyLevelMeasurement);
	}

	// Token: 0x06004BBF RID: 19391 RVA: 0x001DCC1C File Offset: 0x001DB01C
	public sealed override UnitGrowthProfile GetMonsterGrowthProfile(DifficultyLevelMeasurement measurement)
	{
		UnitGrowthProfile growthProfile = this.CorrespondingClassStyle.GetStyleConfig().GetGrowthProfile(measurement);
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
			growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.01, false);
			if (measurement.DifficultyValue <= 28.0 && measurement.DifficultyValue >= 21.0)
			{
				base.SetProfileResistanceToValue(100.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 35.0 && measurement.DifficultyValue > 28.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 2.0, false);
				base.SetProfileResistanceToValue(200.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 42.0 && measurement.DifficultyValue > 35.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 2.5, false);
				base.SetProfileResistanceToValue(300.0, growthProfile);
			}
			else if (measurement.DifficultyValue > 42.0 && measurement.DifficultyValue <= 46.0)
			{
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 3.5, false);
				base.SetProfileResistanceToValue(200.0, growthProfile);
			}
			else if (measurement.DifficultyValue > 46.0 && measurement.DifficultyValue <= 58.0)
			{
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 4.0, false);
				base.SetProfileResistanceToValue(200.0, growthProfile);
			}
			else if (measurement.DifficultyValue > 58.0 && measurement.DifficultyValue <= 100.0)
			{
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 4.5, false);
				base.SetProfileResistanceToValue(200.0, growthProfile);
			}
			else if (measurement.DifficultyValue > 100.0 && measurement.DifficultyValue <= 110.0)
			{
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 11.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 500.0, false);
				base.SetProfileResistanceToValue(500.0, growthProfile);
			}
			else if (measurement.DifficultyValue > 110.0 && measurement.DifficultyValue <= 140.0)
			{
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 12.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 500.0, false);
				base.SetProfileResistanceToValue(500.0, growthProfile);
			}
			else if (measurement.DifficultyValue > 140.0 && measurement.DifficultyValue <= 160.0)
			{
				growthProfile.SetValue(type, num * 1.1, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 13.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 1200.0, false);
				base.SetProfileResistanceToValue(1200.0, growthProfile);
			}
			else if (measurement.DifficultyValue > 160.0 && measurement.DifficultyValue <= 180.0)
			{
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 14.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 1600.0, false);
				base.SetProfileResistanceToValue(1600.0, growthProfile);
			}
			else if (measurement.DifficultyValue > 180.0)
			{
				growthProfile.SetValue(type, num * 1.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * (double)(15 + (int)((measurement.DifficultyValue - 180.0) / 10.0)), false);
				growthProfile.SetValue(AttributeType.Resilience, (double)(2200 + (int)((measurement.DifficultyValue - 180.0) * 10.0)), false);
				base.SetProfileResistanceToValue((double)(2200 + (int)((measurement.DifficultyValue - 180.0) * 10.0)), growthProfile);
			}
		}
		else if (measurement.StarRating == 2)
		{
			growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.015, false);
			if (measurement.DifficultyValue <= 28.0)
			{
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 0.9, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 13.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 1600.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 10.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 50.0, false);
				base.SetProfileResistanceToValue(1800.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 35.0)
			{
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 13.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 2000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 10.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 70.0, false);
				base.SetProfileResistanceToValue(2000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 42.0)
			{
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 15.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 2200.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 10.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 90.0, false);
				base.SetProfileResistanceToValue(2200.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 46.0)
			{
				growthProfile.SetValue(type, num * 1.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 15.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 2400.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 30.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 100.0, false);
				base.SetProfileResistanceToValue(2400.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 58.0)
			{
				growthProfile.SetValue(type, num * 1.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 16.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 3000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 30.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 120.0, false);
				base.SetProfileResistanceToValue(3000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 100.0)
			{
				growthProfile.SetValue(type, num * 1.6, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.3, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 17.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 3200.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 50.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 150.0, false);
				base.SetProfileResistanceToValue(3200.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 110.0)
			{
				growthProfile.SetValue(type, num * 1.6, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.3, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 18.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 3500.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 50.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 170.0, false);
				base.SetProfileResistanceToValue(3500.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 120.0)
			{
				growthProfile.SetValue(type, num * 1.6, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.3, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 19.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 4000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 50.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 180.0, false);
				base.SetProfileResistanceToValue(4000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 130.0)
			{
				growthProfile.SetValue(type, num * 1.7, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.3, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 19.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 4500.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 70.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 200.0, false);
				base.SetProfileResistanceToValue(4500.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 140.0)
			{
				growthProfile.SetValue(type, num * 1.7, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.3, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 20.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 70.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 230.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 5000.0, false);
				base.SetProfileResistanceToValue(5000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 150.0)
			{
				growthProfile.SetValue(type, num * 1.9, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.3, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 21.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 70.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 250.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 5500.0, false);
				base.SetProfileResistanceToValue(5500.0, growthProfile);
			}
			else
			{
				growthProfile.SetValue(type, num * 2.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.4, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * (double)(25 + (int)((measurement.DifficultyValue - 150.0) / 10.0)), false);
				growthProfile.SetValue(AttributeType.Resilience, (double)(6000 + (int)((measurement.DifficultyValue - 150.0) * 10.0)), false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 70.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 300.0, false);
				base.SetProfileResistanceToValue((double)(6000 + (int)((measurement.DifficultyValue - 150.0) * 10.0)), growthProfile);
			}
		}
		else if (measurement.StarRating == -1)
		{
			if (measurement.DifficultyValue <= 25.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.02, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.002, false);
				growthProfile.SetValue(type, num * 1.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 20.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 7000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 50.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 100.0, false);
				base.SetProfileResistanceToValue(7000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 50.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.05, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.04, false);
				growthProfile.SetValue(type, num * 1.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 22.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 10000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 50.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 120.0, false);
				base.SetProfileResistanceToValue(10000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 100.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.05, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.05, false);
				growthProfile.SetValue(type, num * 1.1, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 25.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 12000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 70.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 140.0, false);
				base.SetProfileResistanceToValue(12000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 150.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.1, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.06, false);
				growthProfile.SetValue(type, num * 1.1, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 27.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 15000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 70.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 160.0, false);
				base.SetProfileResistanceToValue(15000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 200.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.1, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.08, false);
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 30.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 18000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 80.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 180.0, false);
				base.SetProfileResistanceToValue(18000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 250.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.15, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.09, false);
				growthProfile.SetValue(type, num * 1.3, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 32.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 21000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 2.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 90.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 210.0, false);
				base.SetProfileResistanceToValue(21000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 300.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.15, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.1, false);
				growthProfile.SetValue(type, num * 1.3, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 35.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 24000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 100.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 230.0, false);
				base.SetProfileResistanceToValue(24000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 350.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.2, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.11, false);
				growthProfile.SetValue(type, num * 1.3, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 42.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 26000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 100.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 250.0, false);
				base.SetProfileResistanceToValue(26000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 400.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.2, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.12, false);
				growthProfile.SetValue(type, num * 1.3, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 55.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 29000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 120.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 280.0, false);
				base.SetProfileResistanceToValue(29000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 500.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.2, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.12, false);
				growthProfile.SetValue(type, num * 1.1, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 65.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 32000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 120.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 310.0, false);
				base.SetProfileResistanceToValue(32000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 600.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.12, false);
				growthProfile.SetValue(type, num * 1.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 85.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 35000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.2, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 150.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 360.0, false);
				base.SetProfileResistanceToValue(35000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 700.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.13, false);
				growthProfile.SetValue(type, num * 1.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 100.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 38000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 170.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 410.0, false);
				base.SetProfileResistanceToValue(40000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 750.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.13, false);
				growthProfile.SetValue(type, num * 0.9, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 110.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 40000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.4, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 220.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 450.0, false);
				base.SetProfileResistanceToValue(42000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 800.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.13, false);
				growthProfile.SetValue(type, num * 0.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 120.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 42000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 230.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 480.0, false);
				base.SetProfileResistanceToValue(45000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 850.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.14, false);
				growthProfile.SetValue(type, num * 0.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 130.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 46000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 240.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 510.0, false);
				base.SetProfileResistanceToValue(50000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 900.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.14, false);
				growthProfile.SetValue(type, num * 0.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 140.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 48000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 250.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 560.0, false);
				base.SetProfileResistanceToValue(52000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 950.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.15, false);
				growthProfile.SetValue(type, num * 0.4, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.8, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 160.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 55000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.75, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 270.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 750.0, false);
				base.SetProfileResistanceToValue(70000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 1000.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.15, false);
				growthProfile.SetValue(type, num * 0.4, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 180.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 62000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.7, false);
				growthProfile.SetValue(AttributeType.CritDamage, 4.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 280.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 820.0, false);
				base.SetProfileResistanceToValue(80000.0, growthProfile);
			}
			else
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.15, false);
				growthProfile.SetValue(type, num * 0.4, false);
				if (measurement.DifficultyValue <= 3000.0)
				{
					growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				}
				else
				{
					growthProfile.SetValue(AttributeType.Agility, num3 * 4.2, false);
				}
				growthProfile.SetValue(AttributeType.Vitality, num2 * (double)(180 + (int)(measurement.DifficultyValue - 1000.0) * 4), false);
				if (measurement.DifficultyValue >= 8000.0)
				{
					growthProfile.SetValue(AttributeType.Vitality, num2 * (double)(800 + (int)(measurement.DifficultyValue - 1000.0) * 1000), false);
				}
				if (measurement.DifficultyValue >= 12000.0)
				{
					growthProfile.SetValue(AttributeType.Vitality, num2 * (double)(850 + (int)(measurement.DifficultyValue - 1000.0) * 3000), false);
				}
				int num4 = 62000 + (int)((measurement.DifficultyValue - 1000.0) * 75.0);
				if (measurement.DifficultyValue <= 3000.0 && num4 > 100000)
				{
					num4 = 100000;
				}
				if (measurement.DifficultyValue <= 5500.0 && num4 > 300000)
				{
					num4 = 300000;
				}
				if (measurement.DifficultyValue > 4000.0)
				{
					growthProfile.SetValue(type, num * (3.7 + 1.5 * (measurement.DifficultyValue - 5000.0) / 1000.0), false);
				}
				growthProfile.SetValue(AttributeType.Resilience, (double)num4, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.7, false);
				growthProfile.SetValue(AttributeType.CritDamage, 4.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.6, false);
				int num5 = 280 + (int)(measurement.DifficultyValue - 1000.0);
				if (num5 > 5000)
				{
					num5 = 5000;
				}
				growthProfile.SetValue(AttributeType.EffectHitRating, (double)num5, false);
				int num6 = 820 + (int)(measurement.DifficultyValue - 1000.0) * 5;
				if (num6 > 15000)
				{
					num6 = 15000;
				}
				growthProfile.SetValue(AttributeType.EffectResistanceRating, (double)num6, false);
				int num7 = 80000 + (int)((measurement.DifficultyValue - 1000.0) * 450.0);
				if (measurement.DifficultyValue <= 3000.0 && num7 > 250000)
				{
					num7 = 250000;
				}
				if (measurement.DifficultyValue <= 5500.0 && num7 > 450000)
				{
					num7 = 450000;
				}
				base.SetProfileResistanceToValue((double)num7, growthProfile);
			}
		}
		return this.FurtherProfileModification(growthProfile, measurement);
	}

	// Token: 0x06004BC0 RID: 19392 RVA: 0x001DEF74 File Offset: 0x001DD374
	protected virtual UnitGrowthProfile FurtherProfileModification(UnitGrowthProfile originalGrowthProfile, DifficultyLevelMeasurement measurement)
	{
		return originalGrowthProfile;
	}

	// Token: 0x06004BC1 RID: 19393 RVA: 0x001DEF77 File Offset: 0x001DD377
	public virtual List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		return original;
	}

	// Token: 0x06004BC2 RID: 19394 RVA: 0x001DEF7C File Offset: 0x001DD37C
	[CompilerGenerated]
	private static ElementEffectData <GetSpecialEffectDataLoads>m__0(OutputType e)
	{
		return new ElementEffectData
		{
			ElementType = e
		};
	}

	// Token: 0x06004BC3 RID: 19395 RVA: 0x001DEF97 File Offset: 0x001DD397
	[CompilerGenerated]
	private static bool <GetMonsterGrowthProfile>m__1(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Intelligience || v.AttributeType == AttributeType.Strength;
	}

	// Token: 0x06004BC4 RID: 19396 RVA: 0x001DEFB1 File Offset: 0x001DD3B1
	[CompilerGenerated]
	private static double <GetMonsterGrowthProfile>m__2(UnitGrowthValue a)
	{
		return a.Potential;
	}

	// Token: 0x06004BC5 RID: 19397 RVA: 0x001DEFB9 File Offset: 0x001DD3B9
	[CompilerGenerated]
	private static bool <GetMonsterGrowthProfile>m__3(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004BC6 RID: 19398 RVA: 0x001DEFC4 File Offset: 0x001DD3C4
	[CompilerGenerated]
	private static double <GetMonsterGrowthProfile>m__4(UnitGrowthValue a)
	{
		return a.Potential;
	}

	// Token: 0x06004BC7 RID: 19399 RVA: 0x001DEFCC File Offset: 0x001DD3CC
	[CompilerGenerated]
	private static bool <GetMonsterGrowthProfile>m__5(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Agility;
	}

	// Token: 0x06004BC8 RID: 19400 RVA: 0x001DEFD7 File Offset: 0x001DD3D7
	[CompilerGenerated]
	private static double <GetMonsterGrowthProfile>m__6(UnitGrowthValue a)
	{
		return a.Potential;
	}

	// Token: 0x04003AD3 RID: 15059
	[CompilerGenerated]
	private static Func<OutputType, ElementEffectData> <>f__am$cache0;

	// Token: 0x04003AD4 RID: 15060
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache1;

	// Token: 0x04003AD5 RID: 15061
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache2;

	// Token: 0x04003AD6 RID: 15062
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache3;

	// Token: 0x04003AD7 RID: 15063
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache4;

	// Token: 0x04003AD8 RID: 15064
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache5;

	// Token: 0x04003AD9 RID: 15065
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache6;
}
