using System;
using System.Collections.Generic;

// Token: 0x0200058B RID: 1419
public class LeatherOfTraitorsTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600287A RID: 10362 RVA: 0x0011AD79 File Offset: 0x00119179
	public LeatherOfTraitorsTemplate()
	{
	}

	// Token: 0x170003AA RID: 938
	// (get) Token: 0x0600287B RID: 10363 RVA: 0x0011AD94 File Offset: 0x00119194
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003AB RID: 939
	// (get) Token: 0x0600287C RID: 10364 RVA: 0x0011AD9C File Offset: 0x0011919C
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600287D RID: 10365 RVA: 0x0011ADA4 File Offset: 0x001191A4
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.LifeOnHit
		};
	}

	// Token: 0x040021F9 RID: 8697
	private ResourceType _itemType = ResourceType.LeatherOfTraitors;

	// Token: 0x040021FA RID: 8698
	private int _itemTierNumber = 14;
}
