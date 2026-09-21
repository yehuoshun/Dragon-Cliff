using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000B07 RID: 2823
public abstract class MiniBossUnitConfigurationBase : MonsterUnitConfigurationBase
{
	// Token: 0x06004BB1 RID: 19377 RVA: 0x001E5146 File Offset: 0x001E3546
	protected MiniBossUnitConfigurationBase()
	{
	}

	// Token: 0x06004BB2 RID: 19378 RVA: 0x001E5150 File Offset: 0x001E3550
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
			growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.02, false);
			if (measurement.DifficultyValue <= 8.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 2.0, false);
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 10.0, false);
			}
			else if (measurement.DifficultyValue <= 15.0)
			{
				growthProfile.SetValue(type, num * 1.3, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 3.5, false);
				base.SetProfileResistanceToValue(100.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 20.0, false);
			}
			else if (measurement.DifficultyValue <= 21.0)
			{
				growthProfile.SetValue(type, num * 1.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 4.0, false);
				base.SetProfileResistanceToValue(150.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 30.0, false);
			}
			else if (measurement.DifficultyValue <= 28.0)
			{
				growthProfile.SetValue(type, num * 1.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 5.0, false);
				base.SetProfileResistanceToValue(250.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 50.0, false);
			}
			else if (measurement.DifficultyValue <= 35.0)
			{
				growthProfile.SetValue(type, num * 2.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 5.5, false);
				base.SetProfileResistanceToValue(350.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 60.0, false);
			}
			else if (measurement.DifficultyValue <= 42.0)
			{
				growthProfile.SetValue(type, num * 2.3, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 6.0, false);
				base.SetProfileResistanceToValue(350.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 60.0, false);
			}
			else if (measurement.DifficultyValue <= 48.0)
			{
				growthProfile.SetValue(type, num * 2.4, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 6.5, false);
				base.SetProfileResistanceToValue(400.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 60.0, false);
			}
			else if (measurement.DifficultyValue <= 55.0)
			{
				growthProfile.SetValue(type, num * 2.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 7.0, false);
				base.SetProfileResistanceToValue(450.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 60.0, false);
			}
			else if (measurement.DifficultyValue <= 62.0)
			{
				growthProfile.SetValue(type, num * 2.7, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 7.5, false);
				base.SetProfileResistanceToValue(500.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 60.0, false);
			}
			else if (measurement.DifficultyValue <= 70.0)
			{
				growthProfile.SetValue(type, num * 2.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 8.0, false);
				base.SetProfileResistanceToValue(550.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 70.0, false);
			}
			else if (measurement.DifficultyValue <= 85.0)
			{
				growthProfile.SetValue(type, num * 3.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 8.0, false);
				base.SetProfileResistanceToValue(600.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 70.0, false);
			}
			else if (measurement.DifficultyValue > 85.0 && measurement.DifficultyValue <= 100.0)
			{
				growthProfile.SetValue(type, num * 3.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 9.0, false);
				base.SetProfileResistanceToValue(600.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 80.0, false);
			}
			else if (measurement.DifficultyValue > 100.0 && measurement.DifficultyValue <= 110.0)
			{
				growthProfile.SetValue(type, num * 3.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 9.5, false);
				base.SetProfileResistanceToValue(650.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 90.0, false);
			}
			else if (measurement.DifficultyValue > 110.0 && measurement.DifficultyValue <= 120.0)
			{
				growthProfile.SetValue(type, num * 3.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 10.0, false);
				base.SetProfileResistanceToValue(700.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 100.0, false);
			}
			else if (measurement.DifficultyValue > 120.0 && measurement.DifficultyValue <= 150.0)
			{
				growthProfile.SetValue(type, num * 3.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 12.5, false);
				base.SetProfileResistanceToValue(800.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 100.0, false);
			}
			else if (measurement.DifficultyValue > 150.0 && measurement.DifficultyValue <= 180.0)
			{
				growthProfile.SetValue(type, num * 3.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 12.5, false);
				base.SetProfileResistanceToValue(1200.0, growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 100.0, false);
			}
			else if (measurement.DifficultyValue > 180.0)
			{
				growthProfile.SetValue(type, num * 3.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 4.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * (13.5 + (double)((int)((measurement.DifficultyValue - 180.0) / 10.0))), false);
				base.SetProfileResistanceToValue((double)(1500 + (int)((measurement.DifficultyValue - 180.0) * 10.0)), growthProfile);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 100.0, false);
			}
		}
		else if (measurement.StarRating == -1)
		{
			if (measurement.DifficultyValue <= 25.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.05, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.02, false);
				growthProfile.SetValue(type, num * 1.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 25.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 9000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 50.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 120.0, false);
				base.SetProfileResistanceToValue(9000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 50.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.1, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.03, false);
				growthProfile.SetValue(type, num * 1.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 30.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 12000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.5, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 50.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 140.0, false);
				base.SetProfileResistanceToValue(12000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 100.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.1, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.03, false);
				growthProfile.SetValue(type, num * 1.1, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 35.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 15000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 70.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 160.0, false);
				base.SetProfileResistanceToValue(15000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 150.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.2, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.04, false);
				growthProfile.SetValue(type, num * 1.1, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 40.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 18000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 80.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 180.0, false);
				base.SetProfileResistanceToValue(18000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 200.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.05, false);
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 45.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 21000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 90.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 200.0, false);
				base.SetProfileResistanceToValue(21000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 250.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.06, false);
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 50.0, false);
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
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.07, false);
				growthProfile.SetValue(type, num * 1.3, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 55.0, false);
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
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.08, false);
				growthProfile.SetValue(type, num * 1.3, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 60.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 30000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 120.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 280.0, false);
				base.SetProfileResistanceToValue(30000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 400.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.08, false);
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 65.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 33000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 140.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 310.0, false);
				base.SetProfileResistanceToValue(33000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 500.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.09, false);
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 70.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 36000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 130.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 350.0, false);
				base.SetProfileResistanceToValue(36000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 600.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.11, false);
				growthProfile.SetValue(type, num * 1.1, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 85.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 40000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.2, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 150.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 420.0, false);
				base.SetProfileResistanceToValue(40000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 700.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.12, false);
				growthProfile.SetValue(type, num * 1.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 100.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 42000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 3.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 200.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 450.0, false);
				base.SetProfileResistanceToValue(42000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 750.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.14, false);
				growthProfile.SetValue(type, num * 0.9, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.1, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 115.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 45000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 4.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 270.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 520.0, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.1, false);
				base.SetProfileResistanceToValue(45000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 800.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.16, false);
				growthProfile.SetValue(type, num * 0.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 125.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 48000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 4.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 280.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 580.0, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.1, false);
				base.SetProfileResistanceToValue(47000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 850.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.17, false);
				growthProfile.SetValue(type, num * 0.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 135.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 51000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 4.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 310.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 650.0, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.15, false);
				base.SetProfileResistanceToValue(51000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 900.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.18, false);
				growthProfile.SetValue(type, num * 0.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 145.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 55000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 5.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 350.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 700.0, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.15, false);
				base.SetProfileResistanceToValue(55000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 950.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.2, false);
				growthProfile.SetValue(type, num * 0.4, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 180.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 62000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 5.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 450.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 850.0, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.15, false);
				base.SetProfileResistanceToValue(70000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 1000.0)
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.2, false);
				growthProfile.SetValue(type, num * 0.4, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.2, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 200.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 70000.0, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 5.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 550.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 1000.0, false);
				growthProfile.SetValue(AttributeType.TurnStartHeal, 0.15, false);
				base.SetProfileResistanceToValue(82000.0, growthProfile);
			}
			else
			{
				growthProfile.SetValue(AttributeType.DodgeRateAdjustment, 0.25, false);
				growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.21, false);
				growthProfile.SetValue(type, num * 0.4, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 3.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * (double)(200 + (int)((measurement.DifficultyValue - 1000.0) * 4.0)), false);
				if (measurement.DifficultyValue >= 8000.0)
				{
					growthProfile.SetValue(AttributeType.Vitality, num2 * (double)(850 + (int)(measurement.DifficultyValue - 1000.0) * 1000), false);
				}
				if (measurement.DifficultyValue >= 12000.0)
				{
					growthProfile.SetValue(AttributeType.Vitality, num2 * (double)(850 + (int)(measurement.DifficultyValue - 1000.0) * 3000), false);
				}
				int num4 = 70000 + (int)((measurement.DifficultyValue - 1000.0) * 80.0);
				if (measurement.DifficultyValue <= 3000.0 && num4 > 130000)
				{
					num4 = 130000;
				}
				growthProfile.SetValue(AttributeType.Resilience, (double)num4, false);
				growthProfile.SetValue(AttributeType.CritRate, 0.6, false);
				growthProfile.SetValue(AttributeType.CritDamage, 5.0, false);
				growthProfile.SetValue(AttributeType.StunOnHit, 0.3, false);
				int num5 = 550 + (int)(measurement.DifficultyValue - 1000.0);
				if (num5 > 6500)
				{
					num5 = 6500;
				}
				growthProfile.SetValue(AttributeType.EffectHitRating, (double)num5, false);
				int num6 = 1000 + (int)(measurement.DifficultyValue - 1000.0) * 5;
				if (num6 > 20000)
				{
					num6 = 20000;
				}
				if (measurement.DifficultyValue > 4000.0)
				{
					growthProfile.SetValue(type, num * (4.0 + 1.5 * (measurement.DifficultyValue - 5000.0) / 1000.0), false);
				}
				growthProfile.SetValue(AttributeType.EffectResistanceRating, (double)num6, false);
				int num7 = 82000 + (int)((measurement.DifficultyValue - 1000.0) * 450.0);
				if (measurement.DifficultyValue <= 3000.0 && num7 > 260000)
				{
					num7 = 260000;
				}
				base.SetProfileResistanceToValue((double)num7, growthProfile);
			}
		}
		else
		{
			growthProfile.SetValue(AttributeType.HitRateAdjustment, 0.03, false);
			if (measurement.DifficultyValue <= 20.0)
			{
				growthProfile.SetValue(AttributeType.Vitality, num2 * 10.0, false);
				growthProfile.SetValue(type, num * 1.2, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 2000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 10.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 80.0, false);
				base.SetProfileResistanceToValue(2000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 35.0)
			{
				growthProfile.SetValue(type, num * 1.9, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.3, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 11.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 2200.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 10.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 100.0, false);
				base.SetProfileResistanceToValue(2200.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 40.0)
			{
				growthProfile.SetValue(type, num * 2.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.4, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 13.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 2500.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 20.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 120.0, false);
				base.SetProfileResistanceToValue(2500.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 60.0)
			{
				growthProfile.SetValue(type, num * 2.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.5, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 15.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 2800.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 20.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 130.0, false);
				base.SetProfileResistanceToValue(2800.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 80.0)
			{
				growthProfile.SetValue(type, num * 2.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.6, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 15.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 3500.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 30.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 160.0, false);
				base.SetProfileResistanceToValue(3500.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 100.0)
			{
				growthProfile.SetValue(type, num * 2.5, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.6, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 20.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 4000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 40.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 180.0, false);
				base.SetProfileResistanceToValue(4000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 120.0)
			{
				growthProfile.SetValue(type, num * 2.6, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.7, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 22.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 4000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 50.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 220.0, false);
				base.SetProfileResistanceToValue(4000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 150.0)
			{
				growthProfile.SetValue(type, num * 2.7, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.8, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 25.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 5000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 60.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 250.0, false);
				base.SetProfileResistanceToValue(5000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 170.0)
			{
				growthProfile.SetValue(type, num * 2.7, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.8, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 25.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 7000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 70.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 280.0, false);
				base.SetProfileResistanceToValue(7000.0, growthProfile);
			}
			else if (measurement.DifficultyValue <= 170.0)
			{
				growthProfile.SetValue(type, num * 2.8, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 1.8, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * 25.0, false);
				growthProfile.SetValue(AttributeType.Resilience, 9000.0, false);
				growthProfile.SetValue(AttributeType.EffectHitRating, 90.0, false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, 310.0, false);
				base.SetProfileResistanceToValue(9000.0, growthProfile);
			}
			else
			{
				growthProfile.SetValue(type, num * 3.0, false);
				growthProfile.SetValue(AttributeType.Agility, num3 * 2.0, false);
				growthProfile.SetValue(AttributeType.Vitality, num2 * (27.0 + (double)((int)((measurement.DifficultyValue - 170.0) / 10.0))), false);
				growthProfile.SetValue(AttributeType.Resilience, (double)(10000 + (int)((measurement.DifficultyValue - 170.0) * 10.0)), false);
				growthProfile.SetValue(AttributeType.EffectHitRating, (double)(100 + (int)((measurement.DifficultyValue - 170.0) / 10.0)), false);
				growthProfile.SetValue(AttributeType.EffectResistanceRating, (double)(350 + (int)((measurement.DifficultyValue - 170.0) / 10.0)), false);
				base.SetProfileResistanceToValue((double)(10000 + (int)((measurement.DifficultyValue - 170.0) * 10.0)), growthProfile);
			}
		}
		return this.FurtherProfileModification(growthProfile);
	}

	// Token: 0x06004BB3 RID: 19379 RVA: 0x001E7812 File Offset: 0x001E5C12
	protected virtual UnitGrowthProfile FurtherProfileModification(UnitGrowthProfile originalGrowthProfile)
	{
		return originalGrowthProfile;
	}

	// Token: 0x06004BB4 RID: 19380 RVA: 0x001E7818 File Offset: 0x001E5C18
	public override List<ISpecialEffectDataLoad> GetSpecialEffectDataLoads(DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		List<ISpecialEffectDataLoad> specialEffectDataLoads = this.CorrespondingClassStyle.GetStyleConfig().GetSpecialEffectDataLoads(relevantDifficultyLevelMeasurement);
		if (relevantDifficultyLevelMeasurement.DifficultyValue >= 8.0 || relevantDifficultyLevelMeasurement.StarRating != 1)
		{
			specialEffectDataLoads.AddRange((from e in UnitExtensions.GetAllDamageElements()
			select new ElementEffectData
			{
				ElementType = e
			}).Cast<ISpecialEffectDataLoad>());
		}
		List<ISpecialEffectDataLoad> list = this.FurtherSpecialEffectsFilter(specialEffectDataLoads, relevantDifficultyLevelMeasurement);
		if (relevantDifficultyLevelMeasurement.StarRating == 2)
		{
			List<SpecialEffectPresence> minibossSpecialEffectsPresences = base.GetMinibossSpecialEffectsPresences();
			if (minibossSpecialEffectsPresences.Any<SpecialEffectPresence>())
			{
				SpecialEffectPresence specialEffectPresence = minibossSpecialEffectsPresences.WeightedRandomSelect<SpecialEffectPresence>();
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
		if (relevantDifficultyLevelMeasurement.StarRating == -1)
		{
			List<SpecialEffectPresence> minibossSpecialEffectsPresences2 = base.GetMinibossSpecialEffectsPresences();
			if (minibossSpecialEffectsPresences2.Any<SpecialEffectPresence>())
			{
				SpecialEffectPresence specialEffectPresence2 = minibossSpecialEffectsPresences2.WeightedRandomSelect<SpecialEffectPresence>();
				using (List<ISpecialEffectDataLoad>.Enumerator enumerator2 = specialEffectPresence2.SpecialEffectDataLoads.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						ISpecialEffectDataLoad effect = enumerator2.Current;
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
				DecreaseRate = 0.4
			});
		}
		else
		{
			list.Add(new NegativeEffectSpeedupData
			{
				DecreaseRate = 0.6
			});
		}
		return list;
	}

	// Token: 0x06004BB5 RID: 19381 RVA: 0x001E7A38 File Offset: 0x001E5E38
	public virtual List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		return original;
	}

	// Token: 0x06004BB6 RID: 19382 RVA: 0x001E7A3B File Offset: 0x001E5E3B
	[CompilerGenerated]
	private static bool <GetMonsterGrowthProfile>m__0(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Intelligience || v.AttributeType == AttributeType.Strength;
	}

	// Token: 0x06004BB7 RID: 19383 RVA: 0x001E7A55 File Offset: 0x001E5E55
	[CompilerGenerated]
	private static double <GetMonsterGrowthProfile>m__1(UnitGrowthValue a)
	{
		return a.Potential;
	}

	// Token: 0x06004BB8 RID: 19384 RVA: 0x001E7A5D File Offset: 0x001E5E5D
	[CompilerGenerated]
	private static bool <GetMonsterGrowthProfile>m__2(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Vitality;
	}

	// Token: 0x06004BB9 RID: 19385 RVA: 0x001E7A68 File Offset: 0x001E5E68
	[CompilerGenerated]
	private static double <GetMonsterGrowthProfile>m__3(UnitGrowthValue a)
	{
		return a.Potential;
	}

	// Token: 0x06004BBA RID: 19386 RVA: 0x001E7A70 File Offset: 0x001E5E70
	[CompilerGenerated]
	private static bool <GetMonsterGrowthProfile>m__4(UnitGrowthValue v)
	{
		return v.AttributeType == AttributeType.Agility;
	}

	// Token: 0x06004BBB RID: 19387 RVA: 0x001E7A7B File Offset: 0x001E5E7B
	[CompilerGenerated]
	private static double <GetMonsterGrowthProfile>m__5(UnitGrowthValue a)
	{
		return a.Potential;
	}

	// Token: 0x06004BBC RID: 19388 RVA: 0x001E7A84 File Offset: 0x001E5E84
	[CompilerGenerated]
	private static ElementEffectData <GetSpecialEffectDataLoads>m__6(OutputType e)
	{
		return new ElementEffectData
		{
			ElementType = e
		};
	}

	// Token: 0x04003ACC RID: 15052
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache0;

	// Token: 0x04003ACD RID: 15053
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache1;

	// Token: 0x04003ACE RID: 15054
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache2;

	// Token: 0x04003ACF RID: 15055
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache3;

	// Token: 0x04003AD0 RID: 15056
	[CompilerGenerated]
	private static Func<UnitGrowthValue, bool> <>f__am$cache4;

	// Token: 0x04003AD1 RID: 15057
	[CompilerGenerated]
	private static Func<UnitGrowthValue, double> <>f__am$cache5;

	// Token: 0x04003AD2 RID: 15058
	[CompilerGenerated]
	private static Func<OutputType, ElementEffectData> <>f__am$cache6;

	// Token: 0x0200107B RID: 4219
	[CompilerGenerated]
	private sealed class <GetSpecialEffectDataLoads>c__AnonStorey0
	{
		// Token: 0x06006974 RID: 26996 RVA: 0x001E7A9F File Offset: 0x001E5E9F
		public <GetSpecialEffectDataLoads>c__AnonStorey0()
		{
		}

		// Token: 0x06006975 RID: 26997 RVA: 0x001E7AA7 File Offset: 0x001E5EA7
		internal bool <>m__0(ISpecialEffectDataLoad r)
		{
			return r.GetSpecialEffectType() != this.effect.GetSpecialEffectType();
		}

		// Token: 0x040063FC RID: 25596
		internal ISpecialEffectDataLoad effect;
	}

	// Token: 0x0200107C RID: 4220
	[CompilerGenerated]
	private sealed class <GetSpecialEffectDataLoads>c__AnonStorey1
	{
		// Token: 0x06006976 RID: 26998 RVA: 0x001E7ABF File Offset: 0x001E5EBF
		public <GetSpecialEffectDataLoads>c__AnonStorey1()
		{
		}

		// Token: 0x06006977 RID: 26999 RVA: 0x001E7AC7 File Offset: 0x001E5EC7
		internal bool <>m__0(ISpecialEffectDataLoad r)
		{
			return r.GetSpecialEffectType() != this.effect.GetSpecialEffectType();
		}

		// Token: 0x040063FD RID: 25597
		internal ISpecialEffectDataLoad effect;
	}
}
