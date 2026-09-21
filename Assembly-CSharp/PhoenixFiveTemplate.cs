using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000568 RID: 1384
public class PhoenixFiveTemplate : AccessoryTemplateBase
{
	// Token: 0x060027E2 RID: 10210 RVA: 0x00119A7E File Offset: 0x00117E7E
	public PhoenixFiveTemplate()
	{
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x060027E3 RID: 10211 RVA: 0x00119A99 File Offset: 0x00117E99
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x060027E4 RID: 10212 RVA: 0x00119AA1 File Offset: 0x00117EA1
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027E5 RID: 10213 RVA: 0x00119AAC File Offset: 0x00117EAC
	public override List<ISpecialEffectDataLoad> GenerateStarEffects(QualityGrade grade, int itemTierNumber)
	{
		List<OutputType> allDamageElements = UnitExtensions.GetAllDamageElements();
		OutputType damageType = allDamageElements[UnityEngine.Random.Range(0, allDamageElements.Count)];
		return new List<ISpecialEffectDataLoad>
		{
			new ReviveDamageData
			{
				DamageType = damageType,
				IsStar = true,
				DamageRate = (double)UnityEngine.Random.Range(3.5f, 4.5f)
			}
		};
	}

	// Token: 0x060027E6 RID: 10214 RVA: 0x00119B0C File Offset: 0x00117F0C
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 400;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		List<ItemPropertyPotential> list = (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
		list.Add(ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Vitality, 300.0));
		return list;
	}

	// Token: 0x060027E7 RID: 10215 RVA: 0x00119B74 File Offset: 0x00117F74
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		double reburnLifeRecoveryRate = 0.1;
		double num = 0.35;
		if (grade == QualityGrade.Rare)
		{
			num += 0.01;
		}
		if (grade == QualityGrade.Epic)
		{
			num += 0.02;
		}
		if (grade == QualityGrade.Legendary)
		{
			num += 0.03;
		}
		if (grade == QualityGrade.Ancient)
		{
			num += 0.04;
		}
		return new List<ISpecialEffectDataLoad>
		{
			new PhenixData
			{
				ReburnLifeRecoveryRate = reburnLifeRecoveryRate,
				ReburnChance = num
			}
		};
	}

	// Token: 0x040021C6 RID: 8646
	private ResourceType _itemType = ResourceType.PhenixFive;

	// Token: 0x040021C7 RID: 8647
	private int _itemTierNumber = 37;

	// Token: 0x02000DCA RID: 3530
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058F1 RID: 22769 RVA: 0x00119C03 File Offset: 0x00118003
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058F2 RID: 22770 RVA: 0x00119C0B File Offset: 0x0011800B
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048E0 RID: 18656
		internal int value;
	}
}
