using System;
using System.Collections.Generic;

// Token: 0x020005C5 RID: 1477
public class HopeOfIceTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002940 RID: 10560 RVA: 0x0011B878 File Offset: 0x00119C78
	public HopeOfIceTemplate()
	{
	}

	// Token: 0x1700041E RID: 1054
	// (get) Token: 0x06002941 RID: 10561 RVA: 0x0011B893 File Offset: 0x00119C93
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700041F RID: 1055
	// (get) Token: 0x06002942 RID: 10562 RVA: 0x0011B89B File Offset: 0x00119C9B
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002943 RID: 10563 RVA: 0x0011B8A4 File Offset: 0x00119CA4
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new PossessionData
			{
				TriggerEventType = AdventureEventType.UnitRegularTurnStarts,
				LastingTurns = 2,
				PossessionEffectSourceIdentityCode = base.GetType().FullName,
				Chance = 0.5,
				Boosts = new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostValue = (double)(500 + (grade - QualityGrade.Normal) * 50),
						BoostAttribute = AttributeType.IceResistance
					}
				}
			}
		};
	}

	// Token: 0x04002228 RID: 8744
	private ResourceType _itemType = ResourceType.HopeOfIce;

	// Token: 0x04002229 RID: 8745
	private int _itemTierNumber = 19;
}
