using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000539 RID: 1337
public class ClearWaterFiveTemplate : AccessoryTemplateBase
{
	// Token: 0x06002702 RID: 9986 RVA: 0x001175FF File Offset: 0x001159FF
	public ClearWaterFiveTemplate()
	{
	}

	// Token: 0x17000305 RID: 773
	// (get) Token: 0x06002703 RID: 9987 RVA: 0x0011761A File Offset: 0x00115A1A
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000306 RID: 774
	// (get) Token: 0x06002704 RID: 9988 RVA: 0x00117622 File Offset: 0x00115A22
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002705 RID: 9989 RVA: 0x0011762C File Offset: 0x00115A2C
	public override List<ISpecialEffectDataLoad> GenerateStarEffects(QualityGrade grade, int itemTierNumber)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new ClearWaterDispelShieldData
			{
				IsStar = true,
				HealRate = (double)UnityEngine.Random.Range(0.1f, 0.2f),
				ShieldSeconds = UnityEngine.Random.Range(2, 4)
			}
		};
	}

	// Token: 0x06002706 RID: 9990 RVA: 0x00117678 File Offset: 0x00115A78
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		int value = 400;
		List<AttributeType> allResistances = UnitExtensions.GetAllResistances();
		allResistances.Shuffle<AttributeType>();
		List<AttributeType> source = allResistances.Take(3).ToList<AttributeType>();
		List<ItemPropertyPotential> list = (from r in source
		select ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)value)).ToList<ItemPropertyPotential>();
		list.Add(ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Resilience, 300.0));
		return list;
	}

	// Token: 0x06002707 RID: 9991 RVA: 0x001176E4 File Offset: 0x00115AE4
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

	// Token: 0x04002173 RID: 8563
	private ResourceType _itemType = ResourceType.ClearWaterFive;

	// Token: 0x04002174 RID: 8564
	private int _itemTierNumber = 37;

	// Token: 0x02000DBF RID: 3519
	[CompilerGenerated]
	private sealed class <PropertyPotentials>c__AnonStorey0
	{
		// Token: 0x060058DB RID: 22747 RVA: 0x0011776B File Offset: 0x00115B6B
		public <PropertyPotentials>c__AnonStorey0()
		{
		}

		// Token: 0x060058DC RID: 22748 RVA: 0x00117773 File Offset: 0x00115B73
		internal ItemPropertyPotential <>m__0(AttributeType r)
		{
			return ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(r, (double)this.value);
		}

		// Token: 0x040048D5 RID: 18645
		internal int value;
	}
}
