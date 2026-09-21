using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200053C RID: 1340
public class ClearWaterSevenTemplate : AccessoryTemplateBase
{
	// Token: 0x06002712 RID: 10002 RVA: 0x001179B2 File Offset: 0x00115DB2
	public ClearWaterSevenTemplate()
	{
	}

	// Token: 0x1700030B RID: 779
	// (get) Token: 0x06002713 RID: 10003 RVA: 0x001179CD File Offset: 0x00115DCD
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700030C RID: 780
	// (get) Token: 0x06002714 RID: 10004 RVA: 0x001179D5 File Offset: 0x00115DD5
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002715 RID: 10005 RVA: 0x001179E0 File Offset: 0x00115DE0
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

	// Token: 0x06002716 RID: 10006 RVA: 0x00117A2C File Offset: 0x00115E2C
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 600;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		List<ItemPropertyPotential> list = (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
		list.Add(ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Resilience, 500.0));
		return list;
	}

	// Token: 0x06002717 RID: 10007 RVA: 0x00117A98 File Offset: 0x00115E98
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

	// Token: 0x04002179 RID: 8569
	private ResourceType _itemType = ResourceType.ClearWaterSeven;

	// Token: 0x0400217A RID: 8570
	private int _itemTierNumber = 52;

	// Token: 0x02000DC2 RID: 3522
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058E1 RID: 22753 RVA: 0x00117B1F File Offset: 0x00115F1F
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058E2 RID: 22754 RVA: 0x00117B27 File Offset: 0x00115F27
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048D8 RID: 18648
		internal int value;
	}
}
