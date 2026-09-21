using System;
using System.Collections.Generic;

// Token: 0x02000609 RID: 1545
public class BetrayersBladeTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A6D RID: 10861 RVA: 0x0011F38B File Offset: 0x0011D78B
	public BetrayersBladeTemplate()
	{
	}

	// Token: 0x170004A7 RID: 1191
	// (get) Token: 0x06002A6E RID: 10862 RVA: 0x0011F3A6 File Offset: 0x0011D7A6
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170004A8 RID: 1192
	// (get) Token: 0x06002A6F RID: 10863 RVA: 0x0011F3AE File Offset: 0x0011D7AE
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002A70 RID: 10864 RVA: 0x0011F3B8 File Offset: 0x0011D7B8
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealPoisonDamageEffectivenessChangeRate
		};
	}

	// Token: 0x06002A71 RID: 10865 RVA: 0x0011F3D8 File Offset: 0x0011D7D8
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeDestroyData
			{
				Chance = 0.4 + (double)(grade - QualityGrade.Normal) * 0.05,
				ReplaceAttribute = AttributeType.CritRate,
				ReplacementValue = 0.0
			}
		};
	}

	// Token: 0x0400227D RID: 8829
	private ResourceType _itemType = ResourceType.BetrayersBlade;

	// Token: 0x0400227E RID: 8830
	private int _itemTierNumber = 29;
}
