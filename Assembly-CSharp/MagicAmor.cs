using System;
using System.Collections.Generic;

// Token: 0x02000A85 RID: 2693
public class MagicAmor : BuriedTempleBossConfigurationBase
{
	// Token: 0x0600493C RID: 18748 RVA: 0x001E41CC File Offset: 0x001E25CC
	public MagicAmor()
	{
	}

	// Token: 0x17000F1F RID: 3871
	// (get) Token: 0x0600493D RID: 18749 RVA: 0x001E41D4 File Offset: 0x001E25D4
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.MagicAmor;
		}
	}

	// Token: 0x17000F20 RID: 3872
	// (get) Token: 0x0600493E RID: 18750 RVA: 0x001E41DB File Offset: 0x001E25DB
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}

	// Token: 0x0600493F RID: 18751 RVA: 0x001E41E0 File Offset: 0x001E25E0
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.FireBlast,
			SkillType.LightFire
		};
	}

	// Token: 0x06004940 RID: 18752 RVA: 0x001E420C File Offset: 0x001E260C
	protected override List<ISpecialEffectDataLoad> BossLevelSpecialEffectsFilter(DifficultyLevelMeasurement difficultyLevelMeasurement)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new BoneOfRaptureData
			{
				IsStarEf = new bool?(false),
				Chance = 0.3,
				Timer = 0f,
				SpeedUpRate = 0.2
			}
		};
	}
}
