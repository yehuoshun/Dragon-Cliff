using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000565 RID: 1381
public class PhenixOneTemplate : AccessoryTemplateBase
{
	// Token: 0x060027D3 RID: 10195 RVA: 0x0011971A File Offset: 0x00117B1A
	public PhenixOneTemplate()
	{
	}

	// Token: 0x1700035D RID: 861
	// (get) Token: 0x060027D4 RID: 10196 RVA: 0x00119734 File Offset: 0x00117B34
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700035E RID: 862
	// (get) Token: 0x060027D5 RID: 10197 RVA: 0x0011973C File Offset: 0x00117B3C
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027D6 RID: 10198 RVA: 0x00119744 File Offset: 0x00117B44
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 100;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		return (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
	}

	// Token: 0x060027D7 RID: 10199 RVA: 0x00119790 File Offset: 0x00117B90
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		double reburnLifeRecoveryRate = 0.1;
		double num = 0.2;
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

	// Token: 0x040021C0 RID: 8640
	private ResourceType _itemType = ResourceType.PhenixOne;

	// Token: 0x040021C1 RID: 8641
	private int _itemTierNumber = 4;

	// Token: 0x02000DC7 RID: 3527
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058EB RID: 22763 RVA: 0x0011981F File Offset: 0x00117C1F
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058EC RID: 22764 RVA: 0x00119827 File Offset: 0x00117C27
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048DD RID: 18653
		internal int value;
	}
}
