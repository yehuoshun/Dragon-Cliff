using System;
using System.Collections.Generic;

// Token: 0x02000AD9 RID: 2777
public class Savagery : MinionUnitConfigurationBase
{
	// Token: 0x06004ADE RID: 19166 RVA: 0x001EA8E6 File Offset: 0x001E8CE6
	public Savagery()
	{
	}

	// Token: 0x17000FBD RID: 4029
	// (get) Token: 0x06004ADF RID: 19167 RVA: 0x001EA8EE File Offset: 0x001E8CEE
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Savagery;
		}
	}

	// Token: 0x17000FBE RID: 4030
	// (get) Token: 0x06004AE0 RID: 19168 RVA: 0x001EA8F5 File Offset: 0x001E8CF5
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}

	// Token: 0x06004AE1 RID: 19169 RVA: 0x001EA8F8 File Offset: 0x001E8CF8
	public override List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		if (relevantDifficultyLevelMeasurement.StarRating == 2)
		{
			original.Add(new MonksEyesData
			{
				IsStarEf = new bool?(false),
				MaxLoss = 0.1
			});
		}
		return original;
	}
}
