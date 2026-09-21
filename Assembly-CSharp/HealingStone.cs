using System;
using System.Collections.Generic;

// Token: 0x02000B01 RID: 2817
public class HealingStone : MinionUnitConfigurationBase
{
	// Token: 0x06004B9B RID: 19355 RVA: 0x001F13C2 File Offset: 0x001EF7C2
	public HealingStone()
	{
	}

	// Token: 0x17001007 RID: 4103
	// (get) Token: 0x06004B9C RID: 19356 RVA: 0x001F13CA File Offset: 0x001EF7CA
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.HealingStone;
		}
	}

	// Token: 0x17001008 RID: 4104
	// (get) Token: 0x06004B9D RID: 19357 RVA: 0x001F13D1 File Offset: 0x001EF7D1
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Statue;
		}
	}

	// Token: 0x06004B9E RID: 19358 RVA: 0x001F13D8 File Offset: 0x001EF7D8
	public override List<ISpecialEffectDataLoad> FurtherSpecialEffectsFilter(List<ISpecialEffectDataLoad> original, DifficultyLevelMeasurement relevantDifficultyLevelMeasurement)
	{
		original.AddRange(new List<ISpecialEffectDataLoad>
		{
			new LifeGenData
			{
				IsStarEf = new bool?(false),
				HealRate = 0.05
			},
			new SacrificeEffectData
			{
				IsStarEf = new bool?(false),
				HealRate = 1.0,
				MinimumSelfRate = 0.2,
				SacrificeRate = 0.2
			}
		});
		return original;
	}
}
