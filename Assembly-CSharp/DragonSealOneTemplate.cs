using System;
using System.Collections.Generic;

// Token: 0x0200054A RID: 1354
public class DragonSealOneTemplate : AccessoryTemplateBase
{
	// Token: 0x06002751 RID: 10065 RVA: 0x00118551 File Offset: 0x00116951
	public DragonSealOneTemplate()
	{
	}

	// Token: 0x17000327 RID: 807
	// (get) Token: 0x06002752 RID: 10066 RVA: 0x00118572 File Offset: 0x00116972
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000328 RID: 808
	// (get) Token: 0x06002753 RID: 10067 RVA: 0x0011857A File Offset: 0x0011697A
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002754 RID: 10068 RVA: 0x00118584 File Offset: 0x00116984
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		double mean = 0.12;
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

	// Token: 0x04002196 RID: 8598
	private ResourceType _itemType = ResourceType.DragonSealOne;

	// Token: 0x04002197 RID: 8599
	private int _itemLevel = 1;

	// Token: 0x04002198 RID: 8600
	private int _itemTierNumber = 5;
}
