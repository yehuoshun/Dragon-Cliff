using System;
using System.Collections.Generic;

// Token: 0x02000668 RID: 1640
public class GiantSwordTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BE1 RID: 11233 RVA: 0x001211EB File Offset: 0x0011F5EB
	public GiantSwordTemplate()
	{
	}

	// Token: 0x17000565 RID: 1381
	// (get) Token: 0x06002BE2 RID: 11234 RVA: 0x001211F3 File Offset: 0x0011F5F3
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.GiantSword;
		}
	}

	// Token: 0x17000566 RID: 1382
	// (get) Token: 0x06002BE3 RID: 11235 RVA: 0x001211FA File Offset: 0x0011F5FA
	public override int ItemTierNumber
	{
		get
		{
			return 30;
		}
	}

	// Token: 0x06002BE4 RID: 11236 RVA: 0x00121200 File Offset: 0x0011F600
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Resilience
		};
	}
}
