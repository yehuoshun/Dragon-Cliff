using System;
using System.Collections.Generic;

// Token: 0x02000600 RID: 1536
public class CollectorsFameTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A3A RID: 10810 RVA: 0x0011EEDB File Offset: 0x0011D2DB
	public CollectorsFameTemplate()
	{
	}

	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x06002A3B RID: 10811 RVA: 0x0011EEF6 File Offset: 0x0011D2F6
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x06002A3C RID: 10812 RVA: 0x0011EEFE File Offset: 0x0011D2FE
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002A3D RID: 10813 RVA: 0x0011EF08 File Offset: 0x0011D308
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Hunting,
			AttributeType.Mining
		};
	}

	// Token: 0x04002269 RID: 8809
	private ResourceType _itemType = ResourceType.CollectorsFame;

	// Token: 0x0400226A RID: 8810
	private int _itemTierNumber = 34;
}
