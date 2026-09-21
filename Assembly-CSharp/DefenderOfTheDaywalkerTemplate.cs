using System;
using System.Collections.Generic;

// Token: 0x0200059D RID: 1437
public class DefenderOfTheDaywalkerTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028B7 RID: 10423 RVA: 0x0011B087 File Offset: 0x00119487
	public DefenderOfTheDaywalkerTemplate()
	{
	}

	// Token: 0x170003CE RID: 974
	// (get) Token: 0x060028B8 RID: 10424 RVA: 0x0011B0A2 File Offset: 0x001194A2
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003CF RID: 975
	// (get) Token: 0x060028B9 RID: 10425 RVA: 0x0011B0AA File Offset: 0x001194AA
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060028BA RID: 10426 RVA: 0x0011B0B4 File Offset: 0x001194B4
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new TauntRecoveryData
			{
				RecoveryRate = 0.03 + (double)(grade - QualityGrade.Normal) * 0.01
			}
		};
	}

	// Token: 0x0400220A RID: 8714
	private ResourceType _itemType = ResourceType.DefenderOfTheDaywalker;

	// Token: 0x0400220B RID: 8715
	private int _itemTierNumber = 23;
}
