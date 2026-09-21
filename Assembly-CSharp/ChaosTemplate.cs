using System;
using System.Collections.Generic;

// Token: 0x0200060B RID: 1547
public class ChaosTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A77 RID: 10871 RVA: 0x0011F4AF File Offset: 0x0011D8AF
	public ChaosTemplate()
	{
	}

	// Token: 0x170004AB RID: 1195
	// (get) Token: 0x06002A78 RID: 10872 RVA: 0x0011F4CA File Offset: 0x0011D8CA
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170004AC RID: 1196
	// (get) Token: 0x06002A79 RID: 10873 RVA: 0x0011F4D2 File Offset: 0x0011D8D2
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002A7A RID: 10874 RVA: 0x0011F4DC File Offset: 0x0011D8DC
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new PossessionData
			{
				Boosts = new List<BoostSetting>
				{
					new BoostSetting
					{
						BoostAttribute = AttributeType.Strength,
						BoostValue = (double)(90 + (grade - QualityGrade.Normal) * 20)
					}
				},
				Chance = 0.3,
				TriggerEventType = AdventureEventType.UnitRegularTurnStarts,
				PossessionEffectSourceIdentityCode = base.GetType().FullName,
				LastingTurns = 2
			}
		};
	}

	// Token: 0x0400227F RID: 8831
	private ResourceType _itemType = ResourceType.Chaos;

	// Token: 0x04002280 RID: 8832
	private int _itemTierNumber = 10;
}
