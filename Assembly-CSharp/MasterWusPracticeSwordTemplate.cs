using System;
using System.Collections.Generic;

// Token: 0x0200066C RID: 1644
public class MasterWusPracticeSwordTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002BF0 RID: 11248 RVA: 0x00121329 File Offset: 0x0011F729
	public MasterWusPracticeSwordTemplate()
	{
	}

	// Token: 0x1700056D RID: 1389
	// (get) Token: 0x06002BF1 RID: 11249 RVA: 0x00121331 File Offset: 0x0011F731
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.MasterWusPracticeSword;
		}
	}

	// Token: 0x1700056E RID: 1390
	// (get) Token: 0x06002BF2 RID: 11250 RVA: 0x00121338 File Offset: 0x0011F738
	public override int ItemTierNumber
	{
		get
		{
			return 4;
		}
	}

	// Token: 0x06002BF3 RID: 11251 RVA: 0x0012133B File Offset: 0x0011F73B
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}
}
