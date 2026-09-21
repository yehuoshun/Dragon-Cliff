using System;
using System.Collections.Generic;

// Token: 0x0200055F RID: 1375
public class LighteningRunnerThreeTemplate : AccessoryTemplateBase
{
	// Token: 0x060027B4 RID: 10164 RVA: 0x00119261 File Offset: 0x00117661
	public LighteningRunnerThreeTemplate()
	{
	}

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x060027B5 RID: 10165 RVA: 0x0011927C File Offset: 0x0011767C
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x060027B6 RID: 10166 RVA: 0x00119284 File Offset: 0x00117684
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027B7 RID: 10167 RVA: 0x0011928C File Offset: 0x0011768C
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Agility, 180.0)
		};
	}

	// Token: 0x040021B3 RID: 8627
	private ResourceType _itemType = ResourceType.LighteningRunnerThree;

	// Token: 0x040021B4 RID: 8628
	private int _itemTierNumber = 15;
}
