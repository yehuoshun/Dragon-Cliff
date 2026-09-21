using System;
using System.Collections.Generic;

// Token: 0x020009AA RID: 2474
public class CollectionSkillGenerator : JourneyContributionGenerator
{
	// Token: 0x060043FA RID: 17402 RVA: 0x001B982B File Offset: 0x001B7C2B
	public CollectionSkillGenerator()
	{
	}

	// Token: 0x17000D8E RID: 3470
	// (get) Token: 0x060043FB RID: 17403 RVA: 0x001B9833 File Offset: 0x001B7C33
	public override JourneyContributeType Type
	{
		get
		{
			return JourneyContributeType.CollectionSkill;
		}
	}

	// Token: 0x060043FC RID: 17404 RVA: 0x001B9838 File Offset: 0x001B7C38
	public override List<JourneyContributionModifier> Generate(DifficultyLevelMeasurement measurement, double ratio)
	{
		return new List<JourneyContributionModifier>
		{
			new JourneyContributionModifier
			{
				Value = base.GenerateGenericValue(measurement) * ratio,
				Key = string.Empty,
				Type = JourneyContributeType.CollectionSkill
			}
		};
	}
}
