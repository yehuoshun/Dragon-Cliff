using System;
using System.Collections.Generic;

// Token: 0x020009B0 RID: 2480
public class ResearchSkillGenerator : JourneyContributionGenerator
{
	// Token: 0x06004407 RID: 17415 RVA: 0x001B98D2 File Offset: 0x001B7CD2
	public ResearchSkillGenerator()
	{
	}

	// Token: 0x17000D91 RID: 3473
	// (get) Token: 0x06004408 RID: 17416 RVA: 0x001B98DA File Offset: 0x001B7CDA
	public override JourneyContributeType Type
	{
		get
		{
			return JourneyContributeType.ResearchSkill;
		}
	}

	// Token: 0x06004409 RID: 17417 RVA: 0x001B98E0 File Offset: 0x001B7CE0
	public override List<JourneyContributionModifier> Generate(DifficultyLevelMeasurement measurement, double ratio)
	{
		return new List<JourneyContributionModifier>
		{
			new JourneyContributionModifier
			{
				Value = base.GenerateGenericValue(measurement) * ratio,
				Key = string.Empty,
				Type = JourneyContributeType.ResearchSkill
			}
		};
	}
}
