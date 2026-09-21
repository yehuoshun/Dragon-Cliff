using System;
using System.Collections.Generic;

// Token: 0x02000551 RID: 1361
public class FameOneTemplate : AccessoryTemplateBase
{
	// Token: 0x06002770 RID: 10096 RVA: 0x00118A82 File Offset: 0x00116E82
	public FameOneTemplate()
	{
	}

	// Token: 0x17000335 RID: 821
	// (get) Token: 0x06002771 RID: 10097 RVA: 0x00118A8A File Offset: 0x00116E8A
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FameOne;
		}
	}

	// Token: 0x06002772 RID: 10098 RVA: 0x00118A94 File Offset: 0x00116E94
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Strength, 60.0),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Intelligience, 60.0)
		};
	}

	// Token: 0x17000336 RID: 822
	// (get) Token: 0x06002773 RID: 10099 RVA: 0x00118AD2 File Offset: 0x00116ED2
	public override int ItemTierNumber
	{
		get
		{
			return 4;
		}
	}
}
