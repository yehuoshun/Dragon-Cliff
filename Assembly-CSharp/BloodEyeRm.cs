using System;
using System.Collections.Generic;

// Token: 0x02000ADE RID: 2782
public class BloodEyeRm : RemnantsBossBase
{
	// Token: 0x06004AFB RID: 19195 RVA: 0x001EB2C4 File Offset: 0x001E96C4
	public BloodEyeRm()
	{
	}

	// Token: 0x17000FC7 RID: 4039
	// (get) Token: 0x06004AFC RID: 19196 RVA: 0x001EB2CC File Offset: 0x001E96CC
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BloodEye_Remnants;
		}
	}

	// Token: 0x17000FC8 RID: 4040
	// (get) Token: 0x06004AFD RID: 19197 RVA: 0x001EB2D3 File Offset: 0x001E96D3
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x06004AFE RID: 19198 RVA: 0x001EB2D6 File Offset: 0x001E96D6
	public override OutputType GetOutputType(DifficultyLevelMeasurement difficultyLevelMeasurement, AdventureType adventureType)
	{
		return OutputType.Shadow;
	}

	// Token: 0x06004AFF RID: 19199 RVA: 0x001EB2DC File Offset: 0x001E96DC
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.Confusion,
			SkillType.ReturningSoul
		};
	}

	// Token: 0x06004B00 RID: 19200 RVA: 0x001EB308 File Offset: 0x001E9708
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		if (difficultyLevelMeasurement.StarRating == 2)
		{
			return new List<ISpecialEffectDataLoad>
			{
				new MonksEyesData
				{
					IsStarEf = new bool?(false),
					MaxLoss = 0.2
				}
			};
		}
		return new List<ISpecialEffectDataLoad>
		{
			new MonksEyesData
			{
				IsStarEf = new bool?(false),
				MaxLoss = 0.2
			}
		};
	}
}
