using System;
using System.Collections.Generic;

// Token: 0x02000580 RID: 1408
public class FadeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002854 RID: 10324 RVA: 0x0011AAE4 File Offset: 0x00118EE4
	public FadeTemplate()
	{
	}

	// Token: 0x17000394 RID: 916
	// (get) Token: 0x06002855 RID: 10325 RVA: 0x0011AAEC File Offset: 0x00118EEC
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Fade;
		}
	}

	// Token: 0x17000395 RID: 917
	// (get) Token: 0x06002856 RID: 10326 RVA: 0x0011AAF3 File Offset: 0x00118EF3
	public override int ItemTierNumber
	{
		get
		{
			return 31;
		}
	}

	// Token: 0x06002857 RID: 10327 RVA: 0x0011AAF8 File Offset: 0x00118EF8
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Resilience
		};
	}
}
