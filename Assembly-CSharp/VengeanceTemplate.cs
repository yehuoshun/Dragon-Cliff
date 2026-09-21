using System;
using System.Collections.Generic;

// Token: 0x02000664 RID: 1636
public class VengeanceTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002BD1 RID: 11217 RVA: 0x00121033 File Offset: 0x0011F433
	public VengeanceTemplate()
	{
	}

	// Token: 0x1700055D RID: 1373
	// (get) Token: 0x06002BD2 RID: 11218 RVA: 0x0012104E File Offset: 0x0011F44E
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700055E RID: 1374
	// (get) Token: 0x06002BD3 RID: 11219 RVA: 0x00121056 File Offset: 0x0011F456
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002BD4 RID: 11220 RVA: 0x00121060 File Offset: 0x0011F460
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				ConditionValue = (double)(150 + (grade - QualityGrade.Normal) * 20),
				GrowthAttributeType = AttributeType.Agility,
				GrowthRate = 2.0,
				CurrentGrowthValue = 0.0,
				Condition = GrowthConditionType.ReceiveDamage,
				MaxGrowthValue = (double)(150 + (grade - QualityGrade.Normal) * 20),
				Id = Guid.NewGuid().ToString()
			}
		};
	}

	// Token: 0x040022B0 RID: 8880
	private ResourceType _itemType = ResourceType.Vengeance;

	// Token: 0x040022B1 RID: 8881
	private int _itemTierNumber = 11;
}
