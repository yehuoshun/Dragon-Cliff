using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000567 RID: 1383
public class PhenixTwoTemplate : AccessoryTemplateBase
{
	// Token: 0x060027DD RID: 10205 RVA: 0x0011995A File Offset: 0x00117D5A
	public PhenixTwoTemplate()
	{
	}

	// Token: 0x17000361 RID: 865
	// (get) Token: 0x060027DE RID: 10206 RVA: 0x00119975 File Offset: 0x00117D75
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000362 RID: 866
	// (get) Token: 0x060027DF RID: 10207 RVA: 0x0011997D File Offset: 0x00117D7D
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027E0 RID: 10208 RVA: 0x00119988 File Offset: 0x00117D88
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 130;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		return (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
	}

	// Token: 0x060027E1 RID: 10209 RVA: 0x001199D8 File Offset: 0x00117DD8
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		double reburnLifeRecoveryRate = 0.1;
		double num = 0.25;
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

	// Token: 0x040021C4 RID: 8644
	private ResourceType _itemType = ResourceType.PhenixTwo;

	// Token: 0x040021C5 RID: 8645
	private int _itemTierNumber = 9;

	// Token: 0x02000DC9 RID: 3529
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058EF RID: 22767 RVA: 0x00119A67 File Offset: 0x00117E67
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058F0 RID: 22768 RVA: 0x00119A6F File Offset: 0x00117E6F
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048DF RID: 18655
		internal int value;
	}
}
