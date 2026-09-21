using System;
using System.Collections.Generic;

// Token: 0x020005FE RID: 1534
public class PrincesFallenSoulTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A31 RID: 10801 RVA: 0x0011EDDF File Offset: 0x0011D1DF
	public PrincesFallenSoulTemplate()
	{
	}

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x06002A32 RID: 10802 RVA: 0x0011EDFA File Offset: 0x0011D1FA
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x06002A33 RID: 10803 RVA: 0x0011EE02 File Offset: 0x0011D202
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002A34 RID: 10804 RVA: 0x0011EE0C File Offset: 0x0011D20C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		if (itemTierNumber <= 35)
		{
			return new List<AttributeType>();
		}
		return new List<AttributeType>
		{
			AttributeType.EffectMastery
		};
	}

	// Token: 0x06002A35 RID: 10805 RVA: 0x0011EE3C File Offset: 0x0011D23C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeDestroyData
			{
				Chance = 0.18 + (double)(grade - QualityGrade.Normal) * 0.02,
				ReplaceAttribute = AttributeType.PhysicalResistance,
				ReplacementValue = 0.0
			}
		};
	}

	// Token: 0x04002265 RID: 8805
	private ResourceType _itemType = ResourceType.PrincesFallenSoul;

	// Token: 0x04002266 RID: 8806
	private int _itemTierNumber = 23;
}
