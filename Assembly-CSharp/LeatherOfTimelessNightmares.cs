using System;
using System.Collections.Generic;

// Token: 0x0200058A RID: 1418
public class LeatherOfTimelessNightmares : RecipeProducedGearTemplateBase
{
	// Token: 0x06002876 RID: 10358 RVA: 0x0011ACC5 File Offset: 0x001190C5
	public LeatherOfTimelessNightmares()
	{
	}

	// Token: 0x170003A8 RID: 936
	// (get) Token: 0x06002877 RID: 10359 RVA: 0x0011ACE0 File Offset: 0x001190E0
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003A9 RID: 937
	// (get) Token: 0x06002878 RID: 10360 RVA: 0x0011ACE8 File Offset: 0x001190E8
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002879 RID: 10361 RVA: 0x0011ACF0 File Offset: 0x001190F0
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
						BoostValue = (double)(140 + (grade - QualityGrade.Normal) * 15),
						BoostAttribute = AttributeType.Strength
					}
				}
			}
		};
	}

	// Token: 0x040021F7 RID: 8695
	private ResourceType _itemType = ResourceType.LeatherOfTimelessNightmares;

	// Token: 0x040021F8 RID: 8696
	private int _itemTierNumber = 14;
}
