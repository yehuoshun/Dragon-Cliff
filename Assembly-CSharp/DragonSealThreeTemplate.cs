using System;
using System.Collections.Generic;

// Token: 0x0200054D RID: 1357
public class DragonSealThreeTemplate : AccessoryTemplateBase
{
	// Token: 0x0600275F RID: 10079 RVA: 0x00118819 File Offset: 0x00116C19
	public DragonSealThreeTemplate()
	{
	}

	// Token: 0x1700032D RID: 813
	// (get) Token: 0x06002760 RID: 10080 RVA: 0x00118834 File Offset: 0x00116C34
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700032E RID: 814
	// (get) Token: 0x06002761 RID: 10081 RVA: 0x0011883C File Offset: 0x00116C3C
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002762 RID: 10082 RVA: 0x00118844 File Offset: 0x00116C44
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		double mean = 0.24;
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

	// Token: 0x0400219D RID: 8605
	private ResourceType _itemType = ResourceType.DragonSealThree;

	// Token: 0x0400219E RID: 8606
	private int _itemTierNumber = 16;
}
