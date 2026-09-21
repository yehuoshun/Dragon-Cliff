using System;
using System.Collections.Generic;

// Token: 0x020005BF RID: 1471
public class EndlessFortunesTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600292A RID: 10538 RVA: 0x0011B6E8 File Offset: 0x00119AE8
	public EndlessFortunesTemplate()
	{
	}

	// Token: 0x17000412 RID: 1042
	// (get) Token: 0x0600292B RID: 10539 RVA: 0x0011B6F0 File Offset: 0x00119AF0
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.EndlessFortunes;
		}
	}

	// Token: 0x17000413 RID: 1043
	// (get) Token: 0x0600292C RID: 10540 RVA: 0x0011B6F7 File Offset: 0x00119AF7
	public override int ItemTierNumber
	{
		get
		{
			return 30;
		}
	}

	// Token: 0x0600292D RID: 10541 RVA: 0x0011B6FC File Offset: 0x00119AFC
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ClearWaterData
			{
				Chance = 1.0,
				NumberOfCleanUps = ((grade < QualityGrade.Legendary) ? 1 : 2)
			}
		};
	}
}
