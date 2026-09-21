using System;
using System.Collections.Generic;

// Token: 0x020005D0 RID: 1488
public class PunishmentTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002965 RID: 10597 RVA: 0x0011BACE File Offset: 0x00119ECE
	public PunishmentTemplate()
	{
	}

	// Token: 0x17000434 RID: 1076
	// (get) Token: 0x06002966 RID: 10598 RVA: 0x0011BAE9 File Offset: 0x00119EE9
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000435 RID: 1077
	// (get) Token: 0x06002967 RID: 10599 RVA: 0x0011BAF1 File Offset: 0x00119EF1
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002968 RID: 10600 RVA: 0x0011BAFC File Offset: 0x00119EFC
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new FadeoutData
			{
				TriggerEventType = AdventureEventType.UnitEntersTurn,
				LastingTurns = 1,
				Chance = 0.27 + (double)(grade - QualityGrade.Normal) * 0.02
			}
		};
	}

	// Token: 0x06002969 RID: 10601 RVA: 0x0011BB4C File Offset: 0x00119F4C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.EffectResistanceRating
		};
	}

	// Token: 0x04002230 RID: 8752
	private ResourceType _itemType = ResourceType.Punishment;

	// Token: 0x04002231 RID: 8753
	private int _itemTierNumber = 20;
}
