using System;
using System.Collections.Generic;

// Token: 0x02000554 RID: 1364
public class FameThreeTemplate : AccessoryTemplateBase
{
	// Token: 0x0600277E RID: 10110 RVA: 0x00118C02 File Offset: 0x00117002
	public FameThreeTemplate()
	{
	}

	// Token: 0x1700033B RID: 827
	// (get) Token: 0x0600277F RID: 10111 RVA: 0x00118C0A File Offset: 0x0011700A
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FameThree;
		}
	}

	// Token: 0x06002780 RID: 10112 RVA: 0x00118C14 File Offset: 0x00117014
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Strength, 150.0),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Intelligience, 150.0)
		};
	}

	// Token: 0x1700033C RID: 828
	// (get) Token: 0x06002781 RID: 10113 RVA: 0x00118C52 File Offset: 0x00117052
	public override int ItemTierNumber
	{
		get
		{
			return 14;
		}
	}
}
