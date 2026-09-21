using System;
using System.Collections.Generic;

// Token: 0x02000619 RID: 1561
public class HuntersBladeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AB0 RID: 10928 RVA: 0x0011F9D3 File Offset: 0x0011DDD3
	public HuntersBladeTemplate()
	{
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06002AB1 RID: 10929 RVA: 0x0011F9DB File Offset: 0x0011DDDB
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.HuntersBlade;
		}
	}

	// Token: 0x170004C8 RID: 1224
	// (get) Token: 0x06002AB2 RID: 10930 RVA: 0x0011F9E2 File Offset: 0x0011DDE2
	public override int ItemTierNumber
	{
		get
		{
			return 4;
		}
	}

	// Token: 0x06002AB3 RID: 10931 RVA: 0x0011F9E8 File Offset: 0x0011DDE8
	public override List<AttributeType> AdditionalGuarranteedPrimaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Hunting,
			AttributeType.Mining
		};
	}
}
