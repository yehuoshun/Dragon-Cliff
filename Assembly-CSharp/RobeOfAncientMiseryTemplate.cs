using System;
using System.Collections.Generic;

// Token: 0x020005D2 RID: 1490
public class RobeOfAncientMiseryTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600296E RID: 10606 RVA: 0x0011BC45 File Offset: 0x0011A045
	public RobeOfAncientMiseryTemplate()
	{
	}

	// Token: 0x17000438 RID: 1080
	// (get) Token: 0x0600296F RID: 10607 RVA: 0x0011BC60 File Offset: 0x0011A060
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000439 RID: 1081
	// (get) Token: 0x06002970 RID: 10608 RVA: 0x0011BC68 File Offset: 0x0011A068
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002971 RID: 10609 RVA: 0x0011BC70 File Offset: 0x0011A070
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
						BoostValue = 0.22 + (double)(grade - QualityGrade.Normal) * 0.02,
						BoostAttribute = AttributeType.CritRate
					}
				}
			}
		};
	}

	// Token: 0x04002234 RID: 8756
	private ResourceType _itemType = ResourceType.RobeOfAncientMisery;

	// Token: 0x04002235 RID: 8757
	private int _itemTierNumber = 14;
}
