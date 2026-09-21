using System;
using System.Collections.Generic;

// Token: 0x020005FC RID: 1532
public class FleshrenderTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A29 RID: 10793 RVA: 0x0011ED5F File Offset: 0x0011D15F
	public FleshrenderTemplate()
	{
	}

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x06002A2A RID: 10794 RVA: 0x0011ED7A File Offset: 0x0011D17A
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x06002A2B RID: 10795 RVA: 0x0011ED82 File Offset: 0x0011D182
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002A2C RID: 10796 RVA: 0x0011ED8C File Offset: 0x0011D18C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.LifeOnHit
		};
	}

	// Token: 0x04002263 RID: 8803
	private ResourceType _itemType = ResourceType.Fleshrender;

	// Token: 0x04002264 RID: 8804
	private int _itemTierNumber = 19;
}
