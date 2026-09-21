using System;
using System.Collections.Generic;

// Token: 0x0200064E RID: 1614
public class FlameguardTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B81 RID: 11137 RVA: 0x00120A93 File Offset: 0x0011EE93
	public FlameguardTemplate()
	{
	}

	// Token: 0x17000531 RID: 1329
	// (get) Token: 0x06002B82 RID: 11138 RVA: 0x00120AAE File Offset: 0x0011EEAE
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000532 RID: 1330
	// (get) Token: 0x06002B83 RID: 11139 RVA: 0x00120AB6 File Offset: 0x0011EEB6
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002B84 RID: 11140 RVA: 0x00120AC0 File Offset: 0x0011EEC0
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new PossessionData
			{
				Chance = 0.7,
				Boosts = new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = 0.3 + (double)(grade - QualityGrade.Normal) * 0.05,
						BoostAttribute = AttributeType.DealFireDamageEffectivenessChangeRate
					},
					new BoostSetting
					{
						BoostAttribute = AttributeType.DealLightningDamageEffectivenessChangeRate,
						BoostValue = 0.3 + (double)(grade - QualityGrade.Normal) * 0.05
					}
				},
				PossessionEffectSourceIdentityCode = base.GetType().FullName,
				TriggerEventType = AdventureEventType.UnitRegularTurnStarts,
				LastingTurns = 2
			}
		};
	}

	// Token: 0x040022A6 RID: 8870
	private ResourceType _itemType = ResourceType.FlameGuard;

	// Token: 0x040022A7 RID: 8871
	private int _itemTierNumber = 18;
}
