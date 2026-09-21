using System;
using System.Collections.Generic;

// Token: 0x02000644 RID: 1604
public class BarrenTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B59 RID: 11097 RVA: 0x001207FA File Offset: 0x0011EBFA
	public BarrenTemplate()
	{
	}

	// Token: 0x1700051D RID: 1309
	// (get) Token: 0x06002B5A RID: 11098 RVA: 0x00120802 File Offset: 0x0011EC02
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Barren;
		}
	}

	// Token: 0x1700051E RID: 1310
	// (get) Token: 0x06002B5B RID: 11099 RVA: 0x00120809 File Offset: 0x0011EC09
	public override int ItemTierNumber
	{
		get
		{
			return 32;
		}
	}

	// Token: 0x06002B5C RID: 11100 RVA: 0x00120810 File Offset: 0x0011EC10
	public override List<AttributeType> AdditionalGuarranteedPrimaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Agility
		};
	}
}
