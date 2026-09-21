using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200054F RID: 1359
public class FameFiveTemplate : AccessoryTemplateBase
{
	// Token: 0x06002767 RID: 10087 RVA: 0x00118999 File Offset: 0x00116D99
	public FameFiveTemplate()
	{
	}

	// Token: 0x17000331 RID: 817
	// (get) Token: 0x06002768 RID: 10088 RVA: 0x001189A1 File Offset: 0x00116DA1
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FameFive;
		}
	}

	// Token: 0x06002769 RID: 10089 RVA: 0x001189A8 File Offset: 0x00116DA8
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Strength, 600.0),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Intelligience, 600.0)
		};
	}

	// Token: 0x0600276A RID: 10090 RVA: 0x001189E8 File Offset: 0x00116DE8
	public override List<ISpecialEffectDataLoad> GenerateStarEffects(QualityGrade grade, int itemTierNumber)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new DispelOnHitData
			{
				Chance = 1.0,
				IsStar = true,
				NumberOfDispels = UnityEngine.Random.Range(1, 3)
			}
		};
	}

	// Token: 0x17000332 RID: 818
	// (get) Token: 0x0600276B RID: 10091 RVA: 0x00118A2C File Offset: 0x00116E2C
	public override int ItemTierNumber
	{
		get
		{
			return 37;
		}
	}
}
