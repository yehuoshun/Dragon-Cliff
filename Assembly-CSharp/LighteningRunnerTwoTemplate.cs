using System;
using System.Collections.Generic;

// Token: 0x02000560 RID: 1376
public class LighteningRunnerTwoTemplate : AccessoryTemplateBase
{
	// Token: 0x060027B8 RID: 10168 RVA: 0x001192B5 File Offset: 0x001176B5
	public LighteningRunnerTwoTemplate()
	{
	}

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x060027B9 RID: 10169 RVA: 0x001192D7 File Offset: 0x001176D7
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x060027BA RID: 10170 RVA: 0x001192DF File Offset: 0x001176DF
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027BB RID: 10171 RVA: 0x001192E8 File Offset: 0x001176E8
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Agility, 110.0)
		};
	}

	// Token: 0x040021B5 RID: 8629
	private ResourceType _itemType = ResourceType.LighteningRunnerTwo;

	// Token: 0x040021B6 RID: 8630
	private int _itemLevel = 2;

	// Token: 0x040021B7 RID: 8631
	private int _itemTierNumber = 9;
}
