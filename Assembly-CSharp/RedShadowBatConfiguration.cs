using System;
using System.Collections.Generic;

// Token: 0x02000A8F RID: 2703
public class RedShadowBatConfiguration : MistForestBossConfigurationBase
{
	// Token: 0x0600496E RID: 18798 RVA: 0x001E4C09 File Offset: 0x001E3009
	public RedShadowBatConfiguration()
	{
	}

	// Token: 0x17000F33 RID: 3891
	// (get) Token: 0x0600496F RID: 18799 RVA: 0x001E4C11 File Offset: 0x001E3011
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedShadowBat;
		}
	}

	// Token: 0x17000F34 RID: 3892
	// (get) Token: 0x06004970 RID: 18800 RVA: 0x001E4C18 File Offset: 0x001E3018
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Healer;
		}
	}

	// Token: 0x06004971 RID: 18801 RVA: 0x001E4C1C File Offset: 0x001E301C
	protected override UnitGrowthProfile FurtherProfileModification(UnitGrowthProfile originalGrowthProfile, DifficultyLevelMeasurement measurement)
	{
		if (measurement.StarRating == 2)
		{
			originalGrowthProfile.SetValue(AttributeType.StunOnHit, 0.7, false);
		}
		return originalGrowthProfile;
	}

	// Token: 0x06004972 RID: 18802 RVA: 0x001E4C44 File Offset: 0x001E3044
	protected override List<SkillType> MonsterSkills(DifficultyLevelMeasurement measurement)
	{
		return new List<SkillType>
		{
			SkillType.DivineLight,
			SkillType.Harmony
		};
	}
}
