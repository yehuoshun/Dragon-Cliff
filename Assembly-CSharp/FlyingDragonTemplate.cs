using System;
using System.Collections.Generic;

// Token: 0x0200064F RID: 1615
public class FlyingDragonTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B85 RID: 11141 RVA: 0x00120B92 File Offset: 0x0011EF92
	public FlyingDragonTemplate()
	{
	}

	// Token: 0x17000533 RID: 1331
	// (get) Token: 0x06002B86 RID: 11142 RVA: 0x00120B9A File Offset: 0x0011EF9A
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FlyingDragon;
		}
	}

	// Token: 0x17000534 RID: 1332
	// (get) Token: 0x06002B87 RID: 11143 RVA: 0x00120BA1 File Offset: 0x0011EFA1
	public override int ItemTierNumber
	{
		get
		{
			return 31;
		}
	}

	// Token: 0x06002B88 RID: 11144 RVA: 0x00120BA8 File Offset: 0x0011EFA8
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.ReflectiveDamage,
			AttributeType.EffectResistanceRating
		};
	}
}
