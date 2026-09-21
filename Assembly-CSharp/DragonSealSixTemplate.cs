using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200054C RID: 1356
public class DragonSealSixTemplate : AccessoryTemplateBase
{
	// Token: 0x0600275A RID: 10074 RVA: 0x00118719 File Offset: 0x00116B19
	public DragonSealSixTemplate()
	{
	}

	// Token: 0x1700032B RID: 811
	// (get) Token: 0x0600275B RID: 10075 RVA: 0x00118734 File Offset: 0x00116B34
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700032C RID: 812
	// (get) Token: 0x0600275C RID: 10076 RVA: 0x0011873C File Offset: 0x00116B3C
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600275D RID: 10077 RVA: 0x00118744 File Offset: 0x00116B44
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

	// Token: 0x0600275E RID: 10078 RVA: 0x00118784 File Offset: 0x00116B84
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		double mean = 0.48;
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

	// Token: 0x0400219B RID: 8603
	private ResourceType _itemType = ResourceType.DragonSealSix;

	// Token: 0x0400219C RID: 8604
	private int _itemTierNumber = 45;
}
