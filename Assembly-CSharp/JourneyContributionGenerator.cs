using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020009AE RID: 2478
public abstract class JourneyContributionGenerator
{
	// Token: 0x06004402 RID: 17410 RVA: 0x001B9779 File Offset: 0x001B7B79
	protected JourneyContributionGenerator()
	{
	}

	// Token: 0x17000D90 RID: 3472
	// (get) Token: 0x06004403 RID: 17411
	public abstract JourneyContributeType Type { get; }

	// Token: 0x06004404 RID: 17412
	public abstract List<JourneyContributionModifier> Generate(DifficultyLevelMeasurement measurement, double ratio);

	// Token: 0x06004405 RID: 17413 RVA: 0x001B9784 File Offset: 0x001B7B84
	protected double GenerateGenericValue(DifficultyLevelMeasurement measurement)
	{
		if (measurement.DifficultyValue > 100.0 && measurement.StarRating == 1)
		{
			return Math.Ceiling((measurement.DifficultyValue - 100.0) / 10.0) * 10.0 * (double)UnityEngine.Random.Range(0.8f, 1f);
		}
		if (measurement.StarRating > 1)
		{
			return Math.Ceiling(10.0) * 10.0 * (double)UnityEngine.Random.Range(0.8f, 1f);
		}
		return 0.0;
	}
}
