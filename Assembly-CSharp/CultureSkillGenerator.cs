using System;
using System.Collections.Generic;

// Token: 0x020009AB RID: 2475
public class CultureSkillGenerator : JourneyContributionGenerator
{
	// Token: 0x060043FD RID: 17405 RVA: 0x001B987A File Offset: 0x001B7C7A
	public CultureSkillGenerator()
	{
	}

	// Token: 0x17000D8F RID: 3471
	// (get) Token: 0x060043FE RID: 17406 RVA: 0x001B9882 File Offset: 0x001B7C82
	public override JourneyContributeType Type
	{
		get
		{
			return JourneyContributeType.CultureSkill;
		}
	}

	// Token: 0x060043FF RID: 17407 RVA: 0x001B9888 File Offset: 0x001B7C88
	public override List<JourneyContributionModifier> Generate(DifficultyLevelMeasurement measurement, double ratio)
	{
		return new List<JourneyContributionModifier>
		{
			new JourneyContributionModifier
			{
				Value = base.GenerateGenericValue(measurement) * ratio,
				Key = string.Empty,
				Type = JourneyContributeType.CultureSkill
			}
		};
	}
}
