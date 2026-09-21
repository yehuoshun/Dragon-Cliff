using System;
using System.Collections.Generic;

// Token: 0x02000648 RID: 1608
public class CollectorsReliefTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B69 RID: 11113 RVA: 0x001208E2 File Offset: 0x0011ECE2
	public CollectorsReliefTemplate()
	{
	}

	// Token: 0x17000525 RID: 1317
	// (get) Token: 0x06002B6A RID: 11114 RVA: 0x001208FD File Offset: 0x0011ECFD
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000526 RID: 1318
	// (get) Token: 0x06002B6B RID: 11115 RVA: 0x00120905 File Offset: 0x0011ED05
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002B6C RID: 11116 RVA: 0x0012090D File Offset: 0x0011ED0D
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}

	// Token: 0x040022A0 RID: 8864
	private ResourceType _itemType = ResourceType.CollectorsRelief;

	// Token: 0x040022A1 RID: 8865
	private int _itemTierNumber = 24;
}
