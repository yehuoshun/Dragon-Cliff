using System;
using System.Collections.Generic;

// Token: 0x0200063B RID: 1595
public class MirageTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B3B RID: 11067 RVA: 0x001205D9 File Offset: 0x0011E9D9
	public MirageTemplate()
	{
	}

	// Token: 0x1700050B RID: 1291
	// (get) Token: 0x06002B3C RID: 11068 RVA: 0x001205F4 File Offset: 0x0011E9F4
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700050C RID: 1292
	// (get) Token: 0x06002B3D RID: 11069 RVA: 0x001205FC File Offset: 0x0011E9FC
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002B3E RID: 11070 RVA: 0x00120604 File Offset: 0x0011EA04
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new AttributeDestroyData
			{
				Chance = 0.2 + (double)(grade - QualityGrade.Normal) * 0.02,
				ReplaceAttribute = AttributeType.FireResistanceResistance,
				ReplacementValue = 0.0
			}
		};
	}

	// Token: 0x04002296 RID: 8854
	private ResourceType _itemType = ResourceType.Mirage;

	// Token: 0x04002297 RID: 8855
	private int _itemTierNumber = 19;
}
