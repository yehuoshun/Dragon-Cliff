using System;
using System.Collections.Generic;

// Token: 0x0200064C RID: 1612
public class ExorcistsWandTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B79 RID: 11129 RVA: 0x00120A5F File Offset: 0x0011EE5F
	public ExorcistsWandTemplate()
	{
	}

	// Token: 0x1700052D RID: 1325
	// (get) Token: 0x06002B7A RID: 11130 RVA: 0x00120A67 File Offset: 0x0011EE67
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.ExorcistsWand;
		}
	}

	// Token: 0x1700052E RID: 1326
	// (get) Token: 0x06002B7B RID: 11131 RVA: 0x00120A6E File Offset: 0x0011EE6E
	public override int ItemTierNumber
	{
		get
		{
			return 11;
		}
	}

	// Token: 0x06002B7C RID: 11132 RVA: 0x00120A72 File Offset: 0x0011EE72
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}
}
