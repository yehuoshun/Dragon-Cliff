using System;

// Token: 0x020005D3 RID: 1491
public class RobeOfDemonicSorrowTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002972 RID: 10610 RVA: 0x0011BD04 File Offset: 0x0011A104
	public RobeOfDemonicSorrowTemplate()
	{
	}

	// Token: 0x1700043A RID: 1082
	// (get) Token: 0x06002973 RID: 10611 RVA: 0x0011BD1E File Offset: 0x0011A11E
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700043B RID: 1083
	// (get) Token: 0x06002974 RID: 10612 RVA: 0x0011BD26 File Offset: 0x0011A126
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x04002236 RID: 8758
	private ResourceType _itemType = ResourceType.RobeOfDemonicSorrow;

	// Token: 0x04002237 RID: 8759
	private int _itemTierNumber = 5;
}
