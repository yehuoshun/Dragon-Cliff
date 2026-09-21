using System;
using System.Collections.Generic;

// Token: 0x02000628 RID: 1576
public class DesolationSpearTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AED RID: 10989 RVA: 0x0011FE83 File Offset: 0x0011E283
	public DesolationSpearTemplate()
	{
	}

	// Token: 0x170004E5 RID: 1253
	// (get) Token: 0x06002AEE RID: 10990 RVA: 0x0011FE8B File Offset: 0x0011E28B
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DesolationSpear;
		}
	}

	// Token: 0x170004E6 RID: 1254
	// (get) Token: 0x06002AEF RID: 10991 RVA: 0x0011FE92 File Offset: 0x0011E292
	public override int ItemTierNumber
	{
		get
		{
			return 33;
		}
	}

	// Token: 0x06002AF0 RID: 10992 RVA: 0x0011FE98 File Offset: 0x0011E298
	public override List<AttributeType> AdditionalGuarranteedPrimaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealPoisonDamageEffectivenessChangeRate
		};
	}
}
