using System;
using System.Collections.Generic;

// Token: 0x0200062C RID: 1580
public class YellowRiverTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AFD RID: 11005 RVA: 0x0011FF73 File Offset: 0x0011E373
	public YellowRiverTemplate()
	{
	}

	// Token: 0x170004ED RID: 1261
	// (get) Token: 0x06002AFE RID: 11006 RVA: 0x0011FF7B File Offset: 0x0011E37B
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.YellowRiver;
		}
	}

	// Token: 0x170004EE RID: 1262
	// (get) Token: 0x06002AFF RID: 11007 RVA: 0x0011FF82 File Offset: 0x0011E382
	public override int ItemTierNumber
	{
		get
		{
			return 20;
		}
	}

	// Token: 0x06002B00 RID: 11008 RVA: 0x0011FF88 File Offset: 0x0011E388
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.TauntOnHit
		};
	}
}
