using System;
using System.Collections.Generic;

// Token: 0x02000601 RID: 1537
public class DeadEndAxeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A3E RID: 10814 RVA: 0x0011EF32 File Offset: 0x0011D332
	public DeadEndAxeTemplate()
	{
	}

	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x06002A3F RID: 10815 RVA: 0x0011EF3A File Offset: 0x0011D33A
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DeadEndAxe;
		}
	}

	// Token: 0x17000494 RID: 1172
	// (get) Token: 0x06002A40 RID: 10816 RVA: 0x0011EF41 File Offset: 0x0011D341
	public override int ItemTierNumber
	{
		get
		{
			return 11;
		}
	}

	// Token: 0x06002A41 RID: 10817 RVA: 0x0011EF48 File Offset: 0x0011D348
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.StunOnHit
		};
	}
}
