using System;
using System.Collections.Generic;

// Token: 0x0200055D RID: 1373
public class LighteningRunnerFourTemplate : AccessoryTemplateBase
{
	// Token: 0x060027AC RID: 10156 RVA: 0x001191B6 File Offset: 0x001175B6
	public LighteningRunnerFourTemplate()
	{
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x060027AD RID: 10157 RVA: 0x001191D1 File Offset: 0x001175D1
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700034E RID: 846
	// (get) Token: 0x060027AE RID: 10158 RVA: 0x001191D9 File Offset: 0x001175D9
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027AF RID: 10159 RVA: 0x001191E4 File Offset: 0x001175E4
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Agility, 280.0)
		};
	}

	// Token: 0x040021AF RID: 8623
	private ResourceType _itemType = ResourceType.LighteningRunnerFour;

	// Token: 0x040021B0 RID: 8624
	private int _itemTierNumber = 20;
}
