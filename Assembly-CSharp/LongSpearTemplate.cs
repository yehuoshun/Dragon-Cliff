using System;
using System.Collections.Generic;

// Token: 0x0200062B RID: 1579
public class LongSpearTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AF9 RID: 11001 RVA: 0x0011FF3F File Offset: 0x0011E33F
	public LongSpearTemplate()
	{
	}

	// Token: 0x170004EB RID: 1259
	// (get) Token: 0x06002AFA RID: 11002 RVA: 0x0011FF47 File Offset: 0x0011E347
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.LongSpear;
		}
	}

	// Token: 0x170004EC RID: 1260
	// (get) Token: 0x06002AFB RID: 11003 RVA: 0x0011FF4E File Offset: 0x0011E34E
	public override int ItemTierNumber
	{
		get
		{
			return 9;
		}
	}

	// Token: 0x06002AFC RID: 11004 RVA: 0x0011FF54 File Offset: 0x0011E354
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealIceDamageEffectivenessChangeRate
		};
	}
}
