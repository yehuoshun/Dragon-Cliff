using System;
using System.Collections.Generic;

// Token: 0x02000549 RID: 1353
public class DragonSealFourTemplate : AccessoryTemplateBase
{
	// Token: 0x0600274D RID: 10061 RVA: 0x00118491 File Offset: 0x00116891
	public DragonSealFourTemplate()
	{
	}

	// Token: 0x17000325 RID: 805
	// (get) Token: 0x0600274E RID: 10062 RVA: 0x001184AC File Offset: 0x001168AC
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000326 RID: 806
	// (get) Token: 0x0600274F RID: 10063 RVA: 0x001184B4 File Offset: 0x001168B4
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002750 RID: 10064 RVA: 0x001184BC File Offset: 0x001168BC
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		double mean = 0.32;
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

	// Token: 0x04002194 RID: 8596
	private ResourceType _itemType = ResourceType.DragonSealFour;

	// Token: 0x04002195 RID: 8597
	private int _itemTierNumber = 21;
}
