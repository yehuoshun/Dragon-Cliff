using System;
using System.Collections.Generic;

// Token: 0x02000540 RID: 1344
public class CollectorFourTemplate : AccessoryTemplateBase
{
	// Token: 0x06002728 RID: 10024 RVA: 0x00117EEE File Offset: 0x001162EE
	public CollectorFourTemplate()
	{
	}

	// Token: 0x17000313 RID: 787
	// (get) Token: 0x06002729 RID: 10025 RVA: 0x00117F09 File Offset: 0x00116309
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000314 RID: 788
	// (get) Token: 0x0600272A RID: 10026 RVA: 0x00117F11 File Offset: 0x00116311
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600272B RID: 10027 RVA: 0x00117F1C File Offset: 0x0011631C
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Mining, 0.4),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Hunting, 0.4)
		};
	}

	// Token: 0x04002181 RID: 8577
	private ResourceType _itemType = ResourceType.CollectorFour;

	// Token: 0x04002182 RID: 8578
	private int _itemTierNumber = 19;
}
