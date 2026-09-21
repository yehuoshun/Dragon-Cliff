using System;
using System.Collections.Generic;

// Token: 0x02000650 RID: 1616
public class GoldenWoodTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B89 RID: 11145 RVA: 0x00120BD2 File Offset: 0x0011EFD2
	public GoldenWoodTemplate()
	{
	}

	// Token: 0x17000535 RID: 1333
	// (get) Token: 0x06002B8A RID: 11146 RVA: 0x00120BDA File Offset: 0x0011EFDA
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.GoldenWood;
		}
	}

	// Token: 0x17000536 RID: 1334
	// (get) Token: 0x06002B8B RID: 11147 RVA: 0x00120BE1 File Offset: 0x0011EFE1
	public override int ItemTierNumber
	{
		get
		{
			return 22;
		}
	}

	// Token: 0x06002B8C RID: 11148 RVA: 0x00120BE5 File Offset: 0x0011EFE5
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}
}
