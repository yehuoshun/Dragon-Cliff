using System;
using System.Collections.Generic;

// Token: 0x02000593 RID: 1427
public class SilkVestTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002895 RID: 10389 RVA: 0x0011AECE File Offset: 0x001192CE
	public SilkVestTemplate()
	{
	}

	// Token: 0x170003BA RID: 954
	// (get) Token: 0x06002896 RID: 10390 RVA: 0x0011AEE8 File Offset: 0x001192E8
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003BB RID: 955
	// (get) Token: 0x06002897 RID: 10391 RVA: 0x0011AEF0 File Offset: 0x001192F0
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002898 RID: 10392 RVA: 0x0011AEF8 File Offset: 0x001192F8
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.BattleStartHeal
		};
	}

	// Token: 0x040021FF RID: 8703
	private ResourceType _itemType = ResourceType.SilkVest;

	// Token: 0x04002200 RID: 8704
	private int _itemTierNumber = 4;
}
