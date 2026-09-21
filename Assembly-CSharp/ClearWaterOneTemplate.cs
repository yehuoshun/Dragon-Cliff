using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x0200053B RID: 1339
public class ClearWaterOneTemplate : AccessoryTemplateBase
{
	// Token: 0x0600270D RID: 9997 RVA: 0x0011789E File Offset: 0x00115C9E
	public ClearWaterOneTemplate()
	{
	}

	// Token: 0x17000309 RID: 777
	// (get) Token: 0x0600270E RID: 9998 RVA: 0x001178B8 File Offset: 0x00115CB8
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700030A RID: 778
	// (get) Token: 0x0600270F RID: 9999 RVA: 0x001178C0 File Offset: 0x00115CC0
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002710 RID: 10000 RVA: 0x001178C8 File Offset: 0x00115CC8
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 100;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		return (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
	}

	// Token: 0x06002711 RID: 10001 RVA: 0x00117914 File Offset: 0x00115D14
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		int numberOfCleanUps = 2;
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

	// Token: 0x04002177 RID: 8567
	private ResourceType _itemType = ResourceType.ClearWaterOne;

	// Token: 0x04002178 RID: 8568
	private int _itemTierNumber = 4;

	// Token: 0x02000DC1 RID: 3521
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058DF RID: 22751 RVA: 0x0011799B File Offset: 0x00115D9B
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058E0 RID: 22752 RVA: 0x001179A3 File Offset: 0x00115DA3
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048D7 RID: 18647
		internal int value;
	}
}
