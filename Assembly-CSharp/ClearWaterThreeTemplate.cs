using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200053E RID: 1342
public class ClearWaterThreeTemplate : AccessoryTemplateBase
{
	// Token: 0x0600271E RID: 10014 RVA: 0x00117CBA File Offset: 0x001160BA
	public ClearWaterThreeTemplate()
	{
	}

	// Token: 0x1700030F RID: 783
	// (get) Token: 0x0600271F RID: 10015 RVA: 0x00117CD5 File Offset: 0x001160D5
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000310 RID: 784
	// (get) Token: 0x06002720 RID: 10016 RVA: 0x00117CDD File Offset: 0x001160DD
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002721 RID: 10017 RVA: 0x00117CE8 File Offset: 0x001160E8
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 165;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		return (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
	}

	// Token: 0x06002722 RID: 10018 RVA: 0x00117D38 File Offset: 0x00116138
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int numberOfCleanUps = 4;
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

	// Token: 0x0400217D RID: 8573
	private ResourceType _itemType = ResourceType.ClearWaterThree;

	// Token: 0x0400217E RID: 8574
	private int _itemTierNumber = 15;

	// Token: 0x02000DC4 RID: 3524
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058E5 RID: 22757 RVA: 0x00117DBF File Offset: 0x001161BF
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058E6 RID: 22758 RVA: 0x00117DC7 File Offset: 0x001161C7
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048DA RID: 18650
		internal int value;
	}
}
