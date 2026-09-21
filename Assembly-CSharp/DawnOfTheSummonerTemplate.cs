using System;
using System.Collections.Generic;

// Token: 0x020005BD RID: 1469
public class DawnOfTheSummonerTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002923 RID: 10531 RVA: 0x0011B61F File Offset: 0x00119A1F
	public DawnOfTheSummonerTemplate()
	{
	}

	// Token: 0x1700040E RID: 1038
	// (get) Token: 0x06002924 RID: 10532 RVA: 0x0011B63A File Offset: 0x00119A3A
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700040F RID: 1039
	// (get) Token: 0x06002925 RID: 10533 RVA: 0x0011B642 File Offset: 0x00119A42
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002926 RID: 10534 RVA: 0x0011B64C File Offset: 0x00119A4C
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
						BoostValue = (double)(270 + (grade - QualityGrade.Normal) * 20),
						BoostAttribute = AttributeType.Intelligience
					}
				}
			}
		};
	}

	// Token: 0x04002220 RID: 8736
	private ResourceType _itemType = ResourceType.DawnOfTheSummoner;

	// Token: 0x04002221 RID: 8737
	private int _itemTierNumber = 23;
}
