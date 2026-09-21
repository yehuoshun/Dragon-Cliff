using System;
using System.Collections.Generic;

// Token: 0x02000640 RID: 1600
public class SpellbinderTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B4B RID: 11083 RVA: 0x001206BE File Offset: 0x0011EABE
	public SpellbinderTemplate()
	{
	}

	// Token: 0x17000515 RID: 1301
	// (get) Token: 0x06002B4C RID: 11084 RVA: 0x001206D9 File Offset: 0x0011EAD9
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000516 RID: 1302
	// (get) Token: 0x06002B4D RID: 11085 RVA: 0x001206E1 File Offset: 0x0011EAE1
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002B4E RID: 11086 RVA: 0x001206EC File Offset: 0x0011EAEC
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				Condition = GrowthConditionType.Heal,
				ConditionValue = 80.0,
				CurrentGrowthValue = 0.0,
				GrowthAttributeType = AttributeType.Intelligience,
				GrowthRate = 3.0,
				MaxGrowthValue = (double)(85 + (grade - QualityGrade.Normal) * 15),
				Id = Guid.NewGuid().ToString()
			}
		};
	}

	// Token: 0x0400229A RID: 8858
	private ResourceType _itemType = ResourceType.Spellbinder;

	// Token: 0x0400229B RID: 8859
	private int _itemTierNumber = 11;
}
