using System;
using System.Collections.Generic;

// Token: 0x020005AE RID: 1454
public class PlateOfTheUniverseTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028F1 RID: 10481 RVA: 0x0011B3AE File Offset: 0x001197AE
	public PlateOfTheUniverseTemplate()
	{
	}

	// Token: 0x170003F0 RID: 1008
	// (get) Token: 0x060028F2 RID: 10482 RVA: 0x0011B3C9 File Offset: 0x001197C9
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003F1 RID: 1009
	// (get) Token: 0x060028F3 RID: 10483 RVA: 0x0011B3D1 File Offset: 0x001197D1
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060028F4 RID: 10484 RVA: 0x0011B3DC File Offset: 0x001197DC
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ChargeData
			{
				ChargingDamageTypes = new List<OutputType>
				{
					OutputType.Physical
				},
				BoostAttributeType = AttributeType.Strength,
				ChargeCap = (double)(240 + (grade - QualityGrade.Normal) * 15)
			}
		};
	}

	// Token: 0x04002218 RID: 8728
	private ResourceType _itemType = ResourceType.PlateOfTheUniverse;

	// Token: 0x04002219 RID: 8729
	private int _itemTierNumber = 15;
}
