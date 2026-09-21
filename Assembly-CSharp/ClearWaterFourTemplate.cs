using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200053A RID: 1338
public class ClearWaterFourTemplate : AccessoryTemplateBase
{
	// Token: 0x06002708 RID: 9992 RVA: 0x00117782 File Offset: 0x00115B82
	public ClearWaterFourTemplate()
	{
	}

	// Token: 0x17000307 RID: 775
	// (get) Token: 0x06002709 RID: 9993 RVA: 0x0011779D File Offset: 0x00115B9D
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000308 RID: 776
	// (get) Token: 0x0600270A RID: 9994 RVA: 0x001177A5 File Offset: 0x00115BA5
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600270B RID: 9995 RVA: 0x001177B0 File Offset: 0x00115BB0
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 200;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		return (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
	}

	// Token: 0x0600270C RID: 9996 RVA: 0x00117800 File Offset: 0x00115C00
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

	// Token: 0x04002175 RID: 8565
	private ResourceType _itemType = ResourceType.ClearWaterFour;

	// Token: 0x04002176 RID: 8566
	private int _itemTierNumber = 27;

	// Token: 0x02000DC0 RID: 3520
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058DD RID: 22749 RVA: 0x00117887 File Offset: 0x00115C87
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058DE RID: 22750 RVA: 0x0011788F File Offset: 0x00115C8F
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048D6 RID: 18646
		internal int value;
	}
}
