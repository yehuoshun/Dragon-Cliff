using System;
using System.Collections.Generic;

// Token: 0x02000663 RID: 1635
public class SmallSwordTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002BCD RID: 11213 RVA: 0x00121000 File Offset: 0x0011F400
	public SmallSwordTemplate()
	{
	}

	// Token: 0x1700055B RID: 1371
	// (get) Token: 0x06002BCE RID: 11214 RVA: 0x00121008 File Offset: 0x0011F408
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.SmallSword;
		}
	}

	// Token: 0x1700055C RID: 1372
	// (get) Token: 0x06002BCF RID: 11215 RVA: 0x0012100F File Offset: 0x0011F40F
	public override int ItemTierNumber
	{
		get
		{
			return 4;
		}
	}

	// Token: 0x06002BD0 RID: 11216 RVA: 0x00121014 File Offset: 0x0011F414
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.HitRateAdjustment
		};
	}
}
