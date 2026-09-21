using System;
using System.Collections.Generic;

// Token: 0x02000550 RID: 1360
public class FameFourTemplate : AccessoryTemplateBase
{
	// Token: 0x0600276C RID: 10092 RVA: 0x00118A30 File Offset: 0x00116E30
	public FameFourTemplate()
	{
	}

	// Token: 0x17000333 RID: 819
	// (get) Token: 0x0600276D RID: 10093 RVA: 0x00118A38 File Offset: 0x00116E38
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FameFour;
		}
	}

	// Token: 0x0600276E RID: 10094 RVA: 0x00118A40 File Offset: 0x00116E40
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Strength, 250.0),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Intelligience, 250.0)
		};
	}

	// Token: 0x17000334 RID: 820
	// (get) Token: 0x0600276F RID: 10095 RVA: 0x00118A7E File Offset: 0x00116E7E
	public override int ItemTierNumber
	{
		get
		{
			return 19;
		}
	}
}
