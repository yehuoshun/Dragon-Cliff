using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200053D RID: 1341
public class ClearWaterSixTemplate : AccessoryTemplateBase
{
	// Token: 0x06002718 RID: 10008 RVA: 0x00117B36 File Offset: 0x00115F36
	public ClearWaterSixTemplate()
	{
	}

	// Token: 0x1700030D RID: 781
	// (get) Token: 0x06002719 RID: 10009 RVA: 0x00117B51 File Offset: 0x00115F51
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700030E RID: 782
	// (get) Token: 0x0600271A RID: 10010 RVA: 0x00117B59 File Offset: 0x00115F59
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600271B RID: 10011 RVA: 0x00117B64 File Offset: 0x00115F64
	public override List<ISpecialEffectDataLoad> GenerateStarEffects(QualityGrade grade, int itemTierNumber)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ClearWaterDispelShieldData
			{
				IsStar = true,
				HealRate = (double)UnityEngine.Random.Range(0.1f, 0.2f),
				ShieldSeconds = UnityEngine.Random.Range(2, 4)
			}
		};
	}

	// Token: 0x0600271C RID: 10012 RVA: 0x00117BB0 File Offset: 0x00115FB0
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 500;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		List<ItemPropertyPotential> list = (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
		list.Add(ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Resilience, 400.0));
		return list;
	}

	// Token: 0x0600271D RID: 10013 RVA: 0x00117C1C File Offset: 0x0011601C
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int numberOfCleanUps = 5;
		double num = 0.5;
		if (grade == QualityGrade.Rare)
		{
			num += 0.1;
		}
		if (grade == QualityGrade.Epic)
		{
			num += 0.2;
		}
		if (grade == QualityGrade.Legendary)
		{
			num += 0.3;
		}
		if (grade == QualityGrade.Ancient)
		{
			num += 0.4;
		}
		return new List<ISpecialEffectDataLoad>
		{
			new ClearWaterData
			{
				Chance = num,
				NumberOfCleanUps = numberOfCleanUps
			}
		};
	}

	// Token: 0x0400217B RID: 8571
	private ResourceType _itemType = ResourceType.ClearWaterSix;

	// Token: 0x0400217C RID: 8572
	private int _itemTierNumber = 45;

	// Token: 0x02000DC3 RID: 3523
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058E3 RID: 22755 RVA: 0x00117CA3 File Offset: 0x001160A3
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058E4 RID: 22756 RVA: 0x00117CAB File Offset: 0x001160AB
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048D9 RID: 18649
		internal int value;
	}
}
