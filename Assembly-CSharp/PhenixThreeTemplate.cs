using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000566 RID: 1382
public class PhenixThreeTemplate : AccessoryTemplateBase
{
	// Token: 0x060027D8 RID: 10200 RVA: 0x00119836 File Offset: 0x00117C36
	public PhenixThreeTemplate()
	{
	}

	// Token: 0x1700035F RID: 863
	// (get) Token: 0x060027D9 RID: 10201 RVA: 0x00119851 File Offset: 0x00117C51
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x060027DA RID: 10202 RVA: 0x00119859 File Offset: 0x00117C59
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027DB RID: 10203 RVA: 0x00119864 File Offset: 0x00117C64
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 165;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		return (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
	}

	// Token: 0x060027DC RID: 10204 RVA: 0x001198B4 File Offset: 0x00117CB4
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		double reburnLifeRecoveryRate = 0.1;
		double num = 0.3;
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

	// Token: 0x040021C2 RID: 8642
	private ResourceType _itemType = ResourceType.PhenixThree;

	// Token: 0x040021C3 RID: 8643
	private int _itemTierNumber = 16;

	// Token: 0x02000DC8 RID: 3528
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058ED RID: 22765 RVA: 0x00119943 File Offset: 0x00117D43
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058EE RID: 22766 RVA: 0x0011994B File Offset: 0x00117D4B
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048DE RID: 18654
		internal int value;
	}
}
