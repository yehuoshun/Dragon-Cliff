using System;
using System.Collections.Generic;

// Token: 0x020005FF RID: 1535
public class ChampionsHammerTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A36 RID: 10806 RVA: 0x0011EE93 File Offset: 0x0011D293
	public ChampionsHammerTemplate()
	{
	}

	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x06002A37 RID: 10807 RVA: 0x0011EEAE File Offset: 0x0011D2AE
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000490 RID: 1168
	// (get) Token: 0x06002A38 RID: 10808 RVA: 0x0011EEB6 File Offset: 0x0011D2B6
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002A39 RID: 10809 RVA: 0x0011EEC0 File Offset: 0x0011D2C0
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.CritDamage
		};
	}

	// Token: 0x04002267 RID: 8807
	private ResourceType _itemType = ResourceType.ChampionsHammer;

	// Token: 0x04002268 RID: 8808
	private int _itemTierNumber = 10;
}
