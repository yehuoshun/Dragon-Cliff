using System;
using System.Collections.Generic;

// Token: 0x0200064A RID: 1610
public class DragonKingsWhisperTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B71 RID: 11121 RVA: 0x0012095D File Offset: 0x0011ED5D
	public DragonKingsWhisperTemplate()
	{
	}

	// Token: 0x17000529 RID: 1321
	// (get) Token: 0x06002B72 RID: 11122 RVA: 0x00120978 File Offset: 0x0011ED78
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700052A RID: 1322
	// (get) Token: 0x06002B73 RID: 11123 RVA: 0x00120980 File Offset: 0x0011ED80
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002B74 RID: 11124 RVA: 0x00120988 File Offset: 0x0011ED88
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
						BoostAttribute = AttributeType.Intelligience,
						BoostValue = (double)(300 + (grade - QualityGrade.Normal) * 20)
					}
				},
				PossessionEffectSourceIdentityCode = base.GetType().FullName,
				TriggerEventType = AdventureEventType.UnitReadyInBattle,
				LastingTurns = 3
			}
		};
	}

	// Token: 0x040022A2 RID: 8866
	private ResourceType _itemType = ResourceType.DragonKingsWhisper;

	// Token: 0x040022A3 RID: 8867
	private int _itemTierNumber = 23;
}
