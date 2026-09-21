using System;
using System.Collections.Generic;

// Token: 0x0200055E RID: 1374
public class LighteningRunnerOneTemplate : AccessoryTemplateBase
{
	// Token: 0x060027B0 RID: 10160 RVA: 0x0011920D File Offset: 0x0011760D
	public LighteningRunnerOneTemplate()
	{
	}

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x060027B1 RID: 10161 RVA: 0x00119227 File Offset: 0x00117627
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x060027B2 RID: 10162 RVA: 0x0011922F File Offset: 0x0011762F
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027B3 RID: 10163 RVA: 0x00119238 File Offset: 0x00117638
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Agility, 80.0)
		};
	}

	// Token: 0x040021B1 RID: 8625
	private ResourceType _itemType = ResourceType.LighteningRunnerOne;

	// Token: 0x040021B2 RID: 8626
	private int _itemTierNumber = 3;
}
