using System;

// Token: 0x0200066F RID: 1647
public class OathKeeperTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BFC RID: 11260 RVA: 0x0012142A File Offset: 0x0011F82A
	public OathKeeperTemplate()
	{
	}

	// Token: 0x17000573 RID: 1395
	// (get) Token: 0x06002BFD RID: 11261 RVA: 0x00121445 File Offset: 0x0011F845
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000574 RID: 1396
	// (get) Token: 0x06002BFE RID: 11262 RVA: 0x0012144D File Offset: 0x0011F84D
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x040022BA RID: 8890
	private ResourceType _itemType = ResourceType.Oathkeeper;

	// Token: 0x040022BB RID: 8891
	private int _itemTierNumber = 18;
}
