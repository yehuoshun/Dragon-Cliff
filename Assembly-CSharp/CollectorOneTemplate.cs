using System;
using System.Collections.Generic;

// Token: 0x02000541 RID: 1345
public class CollectorOneTemplate : AccessoryTemplateBase
{
	// Token: 0x0600272C RID: 10028 RVA: 0x00117F62 File Offset: 0x00116362
	public CollectorOneTemplate()
	{
	}

	// Token: 0x17000315 RID: 789
	// (get) Token: 0x0600272D RID: 10029 RVA: 0x00117F7C File Offset: 0x0011637C
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000316 RID: 790
	// (get) Token: 0x0600272E RID: 10030 RVA: 0x00117F84 File Offset: 0x00116384
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600272F RID: 10031 RVA: 0x00117F8C File Offset: 0x0011638C
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Mining, 0.1),
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Hunting, 0.1)
		};
	}

	// Token: 0x04002183 RID: 8579
	private ResourceType _itemType = ResourceType.CollectorOne;

	// Token: 0x04002184 RID: 8580
	private int _itemTierNumber = 4;
}
