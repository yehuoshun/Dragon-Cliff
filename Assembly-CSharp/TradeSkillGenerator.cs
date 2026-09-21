using System;
using System.Collections.Generic;

// Token: 0x020009B1 RID: 2481
public class TradeSkillGenerator : JourneyContributionGenerator
{
	// Token: 0x0600440A RID: 17418 RVA: 0x001B9922 File Offset: 0x001B7D22
	public TradeSkillGenerator()
	{
	}

	// Token: 0x17000D92 RID: 3474
	// (get) Token: 0x0600440B RID: 17419 RVA: 0x001B992A File Offset: 0x001B7D2A
	public override JourneyContributeType Type
	{
		get
		{
			return JourneyContributeType.TradeSkill;
		}
	}

	// Token: 0x0600440C RID: 17420 RVA: 0x001B9930 File Offset: 0x001B7D30
	public override List<JourneyContributionModifier> Generate(DifficultyLevelMeasurement measurement, double ratio)
	{
		return new List<JourneyContributionModifier>
		{
			new JourneyContributionModifier
			{
				Value = base.GenerateGenericValue(measurement) * ratio,
				Key = string.Empty,
				Type = JourneyContributeType.TradeSkill
			}
		};
	}
}
