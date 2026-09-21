using System;
using System.Collections.Generic;

// Token: 0x02000591 RID: 1425
public class SalvationTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600288E RID: 10382 RVA: 0x0011AE57 File Offset: 0x00119257
	public SalvationTemplate()
	{
	}

	// Token: 0x170003B6 RID: 950
	// (get) Token: 0x0600288F RID: 10383 RVA: 0x0011AE5F File Offset: 0x0011925F
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Salvation;
		}
	}

	// Token: 0x170003B7 RID: 951
	// (get) Token: 0x06002890 RID: 10384 RVA: 0x0011AE66 File Offset: 0x00119266
	public override int ItemTierNumber
	{
		get
		{
			return 30;
		}
	}

	// Token: 0x06002891 RID: 10385 RVA: 0x0011AE6C File Offset: 0x0011926C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FadeoutData
			{
				TriggerEventType = AdventureEventType.UnitRegularTurnStarts,
				LastingTurns = 1,
				Chance = 0.2 + (double)(grade - QualityGrade.Normal) * 0.05
			}
		};
	}
}
