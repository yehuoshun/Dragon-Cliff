using System;
using System.Collections.Generic;

// Token: 0x0200057F RID: 1407
public class DiligenceTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002850 RID: 10320 RVA: 0x0011AA3B File Offset: 0x00118E3B
	public DiligenceTemplate()
	{
	}

	// Token: 0x17000392 RID: 914
	// (get) Token: 0x06002851 RID: 10321 RVA: 0x0011AA43 File Offset: 0x00118E43
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Diligence;
		}
	}

	// Token: 0x17000393 RID: 915
	// (get) Token: 0x06002852 RID: 10322 RVA: 0x0011AA4A File Offset: 0x00118E4A
	public override int ItemTierNumber
	{
		get
		{
			return 28;
		}
	}

	// Token: 0x06002853 RID: 10323 RVA: 0x0011AA50 File Offset: 0x00118E50
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new PossessionData
			{
				TriggerEventType = AdventureEventType.UnitRegularTurnStarts,
				LastingTurns = 2,
				PossessionEffectSourceIdentityCode = base.GetType().FullName,
				Chance = 0.3,
				Boosts = new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = 0.7 + (double)(grade - QualityGrade.Normal) * 0.1,
						BoostAttribute = AttributeType.CritRate
					}
				}
			}
		};
	}
}
