using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000569 RID: 1385
public class PhoenixSevenTemplate : AccessoryTemplateBase
{
	// Token: 0x060027E8 RID: 10216 RVA: 0x00119C1A File Offset: 0x0011801A
	public PhoenixSevenTemplate()
	{
	}

	// Token: 0x17000365 RID: 869
	// (get) Token: 0x060027E9 RID: 10217 RVA: 0x00119C35 File Offset: 0x00118035
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000366 RID: 870
	// (get) Token: 0x060027EA RID: 10218 RVA: 0x00119C3D File Offset: 0x0011803D
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027EB RID: 10219 RVA: 0x00119C48 File Offset: 0x00118048
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

	// Token: 0x060027EC RID: 10220 RVA: 0x00119CA8 File Offset: 0x001180A8
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 600;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		List<ItemPropertyPotential> list = (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
		list.Add(ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Vitality, 500.0));
		return list;
	}

	// Token: 0x060027ED RID: 10221 RVA: 0x00119D10 File Offset: 0x00118110
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

	// Token: 0x040021C8 RID: 8648
	private ResourceType _itemType = ResourceType.PhenixSeven;

	// Token: 0x040021C9 RID: 8649
	private int _itemTierNumber = 52;

	// Token: 0x02000DCB RID: 3531
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058F3 RID: 22771 RVA: 0x00119D9F File Offset: 0x0011819F
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058F4 RID: 22772 RVA: 0x00119DA7 File Offset: 0x001181A7
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048E1 RID: 18657
		internal int value;
	}
}
