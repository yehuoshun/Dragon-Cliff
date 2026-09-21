using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200054B RID: 1355
public class DragonSealSevenTemplate : AccessoryTemplateBase
{
	// Token: 0x06002755 RID: 10069 RVA: 0x00118619 File Offset: 0x00116A19
	public DragonSealSevenTemplate()
	{
	}

	// Token: 0x17000329 RID: 809
	// (get) Token: 0x06002756 RID: 10070 RVA: 0x00118634 File Offset: 0x00116A34
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700032A RID: 810
	// (get) Token: 0x06002757 RID: 10071 RVA: 0x0011863C File Offset: 0x00116A3C
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002758 RID: 10072 RVA: 0x00118644 File Offset: 0x00116A44
	public override List<ISpecialEffectDataLoad> GenerateStarEffects(QualityGrade grade, int itemTierNumber)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new OutputResistanceBoostData
			{
				IsStar = true,
				BoostRate = (double)UnityEngine.Random.Range(1.9f, 2.3f)
			}
		};
	}

	// Token: 0x06002759 RID: 10073 RVA: 0x00118684 File Offset: 0x00116A84
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		double mean = 0.56;
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.DealFireDamageEffectivenessChangeRate, mean),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.DealPhysicalDamageEffectivenessChangeRate, mean),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.DealPoisonDamageEffectivenessChangeRate, mean),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.DealShadowDamageEffectivenessChangeRate, mean),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.DealDivineDamageEffectivenessChangeRate, mean),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.DealLightningDamageEffectivenessChangeRate, mean),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.DealIceDamageEffectivenessChangeRate, mean)
		};
	}

	// Token: 0x04002199 RID: 8601
	private ResourceType _itemType = ResourceType.DragonSealSeven;

	// Token: 0x0400219A RID: 8602
	private int _itemTierNumber = 53;
}
