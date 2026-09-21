using System;
using System.Collections.Generic;

// Token: 0x02000555 RID: 1365
public class FameTwoTemplate : AccessoryTemplateBase
{
	// Token: 0x06002782 RID: 10114 RVA: 0x00118C56 File Offset: 0x00117056
	public FameTwoTemplate()
	{
	}

	// Token: 0x1700033D RID: 829
	// (get) Token: 0x06002783 RID: 10115 RVA: 0x00118C5E File Offset: 0x0011705E
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FameTwo;
		}
	}

	// Token: 0x06002784 RID: 10116 RVA: 0x00118C68 File Offset: 0x00117068
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Strength, 100.0),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Intelligience, 100.0)
		};
	}

	// Token: 0x1700033E RID: 830
	// (get) Token: 0x06002785 RID: 10117 RVA: 0x00118CA6 File Offset: 0x001170A6
	public override int ItemTierNumber
	{
		get
		{
			return 9;
		}
	}
}
