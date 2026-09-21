using System;
using System.Collections.Generic;

// Token: 0x0200064D RID: 1613
public class FallenRainTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B7D RID: 11133 RVA: 0x00120A79 File Offset: 0x0011EE79
	public FallenRainTemplate()
	{
	}

	// Token: 0x1700052F RID: 1327
	// (get) Token: 0x06002B7E RID: 11134 RVA: 0x00120A81 File Offset: 0x0011EE81
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FallenRain;
		}
	}

	// Token: 0x17000530 RID: 1328
	// (get) Token: 0x06002B7F RID: 11135 RVA: 0x00120A88 File Offset: 0x0011EE88
	public override int ItemTierNumber
	{
		get
		{
			return 12;
		}
	}

	// Token: 0x06002B80 RID: 11136 RVA: 0x00120A8C File Offset: 0x0011EE8C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}
}
