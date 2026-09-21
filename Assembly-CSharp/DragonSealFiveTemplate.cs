using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000548 RID: 1352
public class DragonSealFiveTemplate : AccessoryTemplateBase
{
	// Token: 0x06002748 RID: 10056 RVA: 0x0011838F File Offset: 0x0011678F
	public DragonSealFiveTemplate()
	{
	}

	// Token: 0x17000323 RID: 803
	// (get) Token: 0x06002749 RID: 10057 RVA: 0x001183AA File Offset: 0x001167AA
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000324 RID: 804
	// (get) Token: 0x0600274A RID: 10058 RVA: 0x001183B2 File Offset: 0x001167B2
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600274B RID: 10059 RVA: 0x001183BC File Offset: 0x001167BC
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

	// Token: 0x0600274C RID: 10060 RVA: 0x001183FC File Offset: 0x001167FC
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		double mean = 0.4;
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

	// Token: 0x04002192 RID: 8594
	private ResourceType _itemType = ResourceType.DragonSealFive;

	// Token: 0x04002193 RID: 8595
	private int _itemTierNumber = 37;
}
