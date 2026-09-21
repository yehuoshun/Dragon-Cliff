using System;
using System.Collections.Generic;

// Token: 0x02000647 RID: 1607
public class CandyWandTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B65 RID: 11109 RVA: 0x001208C9 File Offset: 0x0011ECC9
	public CandyWandTemplate()
	{
	}

	// Token: 0x17000523 RID: 1315
	// (get) Token: 0x06002B66 RID: 11110 RVA: 0x001208D1 File Offset: 0x0011ECD1
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.CandyWand;
		}
	}

	// Token: 0x17000524 RID: 1316
	// (get) Token: 0x06002B67 RID: 11111 RVA: 0x001208D8 File Offset: 0x0011ECD8
	public override int ItemTierNumber
	{
		get
		{
			return 7;
		}
	}

	// Token: 0x06002B68 RID: 11112 RVA: 0x001208DB File Offset: 0x0011ECDB
	public override List<AttributeType> AdditionalGuarranteedPrimaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}
}
