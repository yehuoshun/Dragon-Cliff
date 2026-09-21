using System;
using System.Collections.Generic;

// Token: 0x02000AB6 RID: 2742
public class ThugLeader2 : MiniBossUnitConfigurationBase
{
	// Token: 0x06004A0E RID: 18958 RVA: 0x001E82FD File Offset: 0x001E66FD
	public ThugLeader2()
	{
	}

	// Token: 0x17000F7D RID: 3965
	// (get) Token: 0x06004A0F RID: 18959 RVA: 0x001E8305 File Offset: 0x001E6705
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ThugLeader2;
		}
	}

	// Token: 0x17000F7E RID: 3966
	// (get) Token: 0x06004A10 RID: 18960 RVA: 0x001E830C File Offset: 0x001E670C
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004A11 RID: 18961 RVA: 0x001E8310 File Offset: 0x001E6710
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Shock
		};
	}

	// Token: 0x06004A12 RID: 18962 RVA: 0x001E8330 File Offset: 0x001E6730
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
