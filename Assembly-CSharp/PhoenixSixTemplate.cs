using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200056A RID: 1386
public class PhoenixSixTemplate : AccessoryTemplateBase
{
	// Token: 0x060027EE RID: 10222 RVA: 0x00119DB6 File Offset: 0x001181B6
	public PhoenixSixTemplate()
	{
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x060027EF RID: 10223 RVA: 0x00119DD1 File Offset: 0x001181D1
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000368 RID: 872
	// (get) Token: 0x060027F0 RID: 10224 RVA: 0x00119DD9 File Offset: 0x001181D9
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027F1 RID: 10225 RVA: 0x00119DE4 File Offset: 0x001181E4
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

	// Token: 0x060027F2 RID: 10226 RVA: 0x00119E44 File Offset: 0x00118244
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 500;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		List<ItemPropertyPotential> list = (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
		list.Add(ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Vitality, 400.0));
		return list;
	}

	// Token: 0x060027F3 RID: 10227 RVA: 0x00119EAC File Offset: 0x001182AC
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

	// Token: 0x040021CA RID: 8650
	private ResourceType _itemType = ResourceType.PhenixSix;

	// Token: 0x040021CB RID: 8651
	private int _itemTierNumber = 45;

	// Token: 0x02000DCC RID: 3532
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058F5 RID: 22773 RVA: 0x00119F3B File Offset: 0x0011833B
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058F6 RID: 22774 RVA: 0x00119F43 File Offset: 0x00118343
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048E2 RID: 18658
		internal int value;
	}
}
