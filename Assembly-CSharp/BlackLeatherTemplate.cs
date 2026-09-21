using System;
using System.Collections.Generic;

// Token: 0x0200057A RID: 1402
public class BlackLeatherTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600283F RID: 10303 RVA: 0x0011A99F File Offset: 0x00118D9F
	public BlackLeatherTemplate()
	{
	}

	// Token: 0x17000388 RID: 904
	// (get) Token: 0x06002840 RID: 10304 RVA: 0x0011A9A7 File Offset: 0x00118DA7
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.BlackLeather;
		}
	}

	// Token: 0x17000389 RID: 905
	// (get) Token: 0x06002841 RID: 10305 RVA: 0x0011A9AE File Offset: 0x00118DAE
	public override int ItemTierNumber
	{
		get
		{
			return 11;
		}
	}

	// Token: 0x06002842 RID: 10306 RVA: 0x0011A9B2 File Offset: 0x00118DB2
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}
}
