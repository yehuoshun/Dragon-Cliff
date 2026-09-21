using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000564 RID: 1380
public class PhenixFourTemplate : AccessoryTemplateBase
{
	// Token: 0x060027CE RID: 10190 RVA: 0x001195F8 File Offset: 0x001179F8
	public PhenixFourTemplate()
	{
	}

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x060027CF RID: 10191 RVA: 0x00119613 File Offset: 0x00117A13
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700035C RID: 860
	// (get) Token: 0x060027D0 RID: 10192 RVA: 0x0011961B File Offset: 0x00117A1B
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027D1 RID: 10193 RVA: 0x00119624 File Offset: 0x00117A24
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 200;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		return (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
	}

	// Token: 0x060027D2 RID: 10194 RVA: 0x00119674 File Offset: 0x00117A74
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

	// Token: 0x040021BE RID: 8638
	private ResourceType _itemType = ResourceType.PhenixFour;

	// Token: 0x040021BF RID: 8639
	private int _itemTierNumber = 21;

	// Token: 0x02000DC6 RID: 3526
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058E9 RID: 22761 RVA: 0x00119703 File Offset: 0x00117B03
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058EA RID: 22762 RVA: 0x0011970B File Offset: 0x00117B0B
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048DC RID: 18652
		internal int value;
	}
}
