using System;
using System.Collections.Generic;

// Token: 0x02000AB5 RID: 2741
public class ThugLeader1 : MiniBossUnitConfigurationBase
{
	// Token: 0x06004A09 RID: 18953 RVA: 0x001E8253 File Offset: 0x001E6653
	public ThugLeader1()
	{
	}

	// Token: 0x17000F7B RID: 3963
	// (get) Token: 0x06004A0A RID: 18954 RVA: 0x001E825B File Offset: 0x001E665B
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ThugLeader1;
		}
	}

	// Token: 0x17000F7C RID: 3964
	// (get) Token: 0x06004A0B RID: 18955 RVA: 0x001E8262 File Offset: 0x001E6662
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004A0C RID: 18956 RVA: 0x001E8268 File Offset: 0x001E6668
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.WillOfFight
		};
	}

	// Token: 0x06004A0D RID: 18957 RVA: 0x001E8288 File Offset: 0x001E6688
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
