using System;
using System.Collections.Generic;

// Token: 0x02000ACE RID: 2766
public class Icebeast : MinionUnitConfigurationBase
{
	// Token: 0x06004A8C RID: 19084 RVA: 0x001E9F0D File Offset: 0x001E830D
	public Icebeast()
	{
	}

	// Token: 0x17000FA9 RID: 4009
	// (get) Token: 0x06004A8D RID: 19085 RVA: 0x001E9F15 File Offset: 0x001E8315
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.IceBeast;
		}
	}

	// Token: 0x17000FAA RID: 4010
	// (get) Token: 0x06004A8E RID: 19086 RVA: 0x001E9F1C File Offset: 0x001E831C
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004A8F RID: 19087 RVA: 0x001E9F20 File Offset: 0x001E8320
	public override List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		original.AddRange(new List<ISpecialEffectDataLoad>
		{
			new StarfallData
			{
				IsStarEf = new bool?(false),
				Chance = 0.5,
				DamageType = OutputType.Ice,
				DamagePercentage = 0.8
			}
		});
		return original;
	}

	// Token: 0x06004A90 RID: 19088 RVA: 0x001E9F79 File Offset: 0x001E8379
	protected override UnitGrowthProfile FurtherProfileModification(UnitGrowthProfile originalGrowthProfile, DifficultyLevelMeasurement measurement)
	{
		originalGrowthProfile.SetValue(AttributeType.StunOnHit, 0.8, false);
		return originalGrowthProfile;
	}
}
