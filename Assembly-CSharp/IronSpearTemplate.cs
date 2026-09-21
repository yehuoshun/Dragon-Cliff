using System;
using System.Collections.Generic;

// Token: 0x0200062A RID: 1578
public class IronSpearTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AF5 RID: 10997 RVA: 0x0011FF0B File Offset: 0x0011E30B
	public IronSpearTemplate()
	{
	}

	// Token: 0x170004E9 RID: 1257
	// (get) Token: 0x06002AF6 RID: 10998 RVA: 0x0011FF13 File Offset: 0x0011E313
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.IronSpear;
		}
	}

	// Token: 0x170004EA RID: 1258
	// (get) Token: 0x06002AF7 RID: 10999 RVA: 0x0011FF1A File Offset: 0x0011E31A
	public override int ItemTierNumber
	{
		get
		{
			return 7;
		}
	}

	// Token: 0x06002AF8 RID: 11000 RVA: 0x0011FF20 File Offset: 0x0011E320
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.StunOnHit
		};
	}
}
