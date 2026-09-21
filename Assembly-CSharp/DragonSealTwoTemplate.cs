using System;
using System.Collections.Generic;

// Token: 0x0200054E RID: 1358
public class DragonSealTwoTemplate : AccessoryTemplateBase
{
	// Token: 0x06002763 RID: 10083 RVA: 0x001188D9 File Offset: 0x00116CD9
	public DragonSealTwoTemplate()
	{
	}

	// Token: 0x1700032F RID: 815
	// (get) Token: 0x06002764 RID: 10084 RVA: 0x001188F4 File Offset: 0x00116CF4
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000330 RID: 816
	// (get) Token: 0x06002765 RID: 10085 RVA: 0x001188FC File Offset: 0x00116CFC
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002766 RID: 10086 RVA: 0x00118904 File Offset: 0x00116D04
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		double mean = 0.18;
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

	// Token: 0x0400219F RID: 8607
	private ResourceType _itemType = ResourceType.DragonSealTwo;

	// Token: 0x040021A0 RID: 8608
	private int _itemTierNumber = 9;
}
