using System;
using System.Collections.Generic;

// Token: 0x02000543 RID: 1347
public class CollectorTwoTemplate : AccessoryTemplateBase
{
	// Token: 0x06002734 RID: 10036 RVA: 0x00118046 File Offset: 0x00116446
	public CollectorTwoTemplate()
	{
	}

	// Token: 0x17000319 RID: 793
	// (get) Token: 0x06002735 RID: 10037 RVA: 0x00118060 File Offset: 0x00116460
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700031A RID: 794
	// (get) Token: 0x06002736 RID: 10038 RVA: 0x00118068 File Offset: 0x00116468
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002737 RID: 10039 RVA: 0x00118070 File Offset: 0x00116470
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Mining, 0.2),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Hunting, 0.2)
		};
	}

	// Token: 0x04002187 RID: 8583
	private ResourceType _itemType = ResourceType.CollectorTwo;

	// Token: 0x04002188 RID: 8584
	private int _itemTierNumber = 8;
}
