using System;
using System.Collections.Generic;

// Token: 0x02000AB7 RID: 2743
public class ThugLeader3 : MiniBossUnitConfigurationBase
{
	// Token: 0x06004A13 RID: 18963 RVA: 0x001E83A5 File Offset: 0x001E67A5
	public ThugLeader3()
	{
	}

	// Token: 0x17000F7F RID: 3967
	// (get) Token: 0x06004A14 RID: 18964 RVA: 0x001E83AD File Offset: 0x001E67AD
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ThugLeader3;
		}
	}

	// Token: 0x17000F80 RID: 3968
	// (get) Token: 0x06004A15 RID: 18965 RVA: 0x001E83B4 File Offset: 0x001E67B4
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004A16 RID: 18966 RVA: 0x001E83B8 File Offset: 0x001E67B8
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.ShieldBurn
		};
	}

	// Token: 0x06004A17 RID: 18967 RVA: 0x001E83D8 File Offset: 0x001E67D8
	public override List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		original.AddRange(new List<ISpecialEffectDataLoad>
		{
			new ThugPowerData
			{
				IsStar = false
			},
			new TimeLockResistanceData
			{
				IsStar = false,
				Chance = 1.0
			},
			new TurnResistanceData
			{
				IsStar = false,
				Rate = 1.0
			}
		});
		return original;
	}
}
