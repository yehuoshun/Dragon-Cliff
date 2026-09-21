using System;
using System.Collections.Generic;

// Token: 0x02000602 RID: 1538
public class GoldenAxeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A42 RID: 10818 RVA: 0x0011EF67 File Offset: 0x0011D367
	public GoldenAxeTemplate()
	{
	}

	// Token: 0x17000495 RID: 1173
	// (get) Token: 0x06002A43 RID: 10819 RVA: 0x0011EF82 File Offset: 0x0011D382
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000496 RID: 1174
	// (get) Token: 0x06002A44 RID: 10820 RVA: 0x0011EF8A File Offset: 0x0011D38A
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002A45 RID: 10821 RVA: 0x0011EF94 File Offset: 0x0011D394
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new TauntRecoveryData
			{
				RecoveryRate = 0.03 + (double)(grade - QualityGrade.Normal) * 0.005
			}
		};
	}

	// Token: 0x0400226B RID: 8811
	private ResourceType _itemType = ResourceType.GoldenAxe;

	// Token: 0x0400226C RID: 8812
	private int _itemTierNumber = 22;
}
