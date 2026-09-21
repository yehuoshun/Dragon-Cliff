using System;
using System.Collections.Generic;

// Token: 0x02000678 RID: 1656
public class SwordOfRegretTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002C1C RID: 11292 RVA: 0x0012163D File Offset: 0x0011FA3D
	public SwordOfRegretTemplate()
	{
	}

	// Token: 0x17000585 RID: 1413
	// (get) Token: 0x06002C1D RID: 11293 RVA: 0x00121658 File Offset: 0x0011FA58
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000586 RID: 1414
	// (get) Token: 0x06002C1E RID: 11294 RVA: 0x00121660 File Offset: 0x0011FA60
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002C1F RID: 11295 RVA: 0x00121668 File Offset: 0x0011FA68
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new GrowthData
			{
				GrowthAttributeType = AttributeType.PhysicalResistance,
				GrowthRate = 5.0,
				CurrentGrowthValue = 0.0,
				ConditionValue = 400.0,
				Condition = GrowthConditionType.ReceiveDamage,
				MaxGrowthValue = (double)(500 + (grade - QualityGrade.Normal) * 100),
				Id = Guid.NewGuid().ToString()
			}
		};
	}

	// Token: 0x040022C5 RID: 8901
	private ResourceType _itemType = ResourceType.SwordOfRegret;

	// Token: 0x040022C6 RID: 8902
	private int _itemTierNumber = 24;
}
