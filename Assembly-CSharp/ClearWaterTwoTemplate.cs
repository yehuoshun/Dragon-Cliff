using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200053F RID: 1343
public class ClearWaterTwoTemplate : AccessoryTemplateBase
{
	// Token: 0x06002723 RID: 10019 RVA: 0x00117DD6 File Offset: 0x001161D6
	public ClearWaterTwoTemplate()
	{
	}

	// Token: 0x17000311 RID: 785
	// (get) Token: 0x06002724 RID: 10020 RVA: 0x00117DF0 File Offset: 0x001161F0
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000312 RID: 786
	// (get) Token: 0x06002725 RID: 10021 RVA: 0x00117DF8 File Offset: 0x001161F8
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002726 RID: 10022 RVA: 0x00117E00 File Offset: 0x00116200
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 130;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		return (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
	}

	// Token: 0x06002727 RID: 10023 RVA: 0x00117E50 File Offset: 0x00116250
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int numberOfCleanUps = 3;
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

	// Token: 0x0400217F RID: 8575
	private ResourceType _itemType = ResourceType.ClearWaterTwo;

	// Token: 0x04002180 RID: 8576
	private int _itemTierNumber = 8;

	// Token: 0x02000DC5 RID: 3525
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058E7 RID: 22759 RVA: 0x00117ED7 File Offset: 0x001162D7
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058E8 RID: 22760 RVA: 0x00117EDF File Offset: 0x001162DF
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048DB RID: 18651
		internal int value;
	}
}
