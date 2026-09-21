using System;
using System.Collections.Generic;

// Token: 0x02000542 RID: 1346
public class CollectorThreeTemplate : AccessoryTemplateBase
{
	// Token: 0x06002730 RID: 10032 RVA: 0x00117FD2 File Offset: 0x001163D2
	public CollectorThreeTemplate()
	{
	}

	// Token: 0x17000317 RID: 791
	// (get) Token: 0x06002731 RID: 10033 RVA: 0x00117FED File Offset: 0x001163ED
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000318 RID: 792
	// (get) Token: 0x06002732 RID: 10034 RVA: 0x00117FF5 File Offset: 0x001163F5
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002733 RID: 10035 RVA: 0x00118000 File Offset: 0x00116400
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Mining, 0.3),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Hunting, 0.3)
		};
	}

	// Token: 0x04002185 RID: 8581
	private ResourceType _itemType = ResourceType.CollectorThree;

	// Token: 0x04002186 RID: 8582
	private int _itemTierNumber = 15;
}
