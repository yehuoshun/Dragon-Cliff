using System;
using System.Collections.Generic;

// Token: 0x0200062E RID: 1582
public class CurvedWandTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B05 RID: 11013 RVA: 0x00120005 File Offset: 0x0011E405
	public CurvedWandTemplate()
	{
	}

	// Token: 0x170004F1 RID: 1265
	// (get) Token: 0x06002B06 RID: 11014 RVA: 0x0012000D File Offset: 0x0011E40D
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.CurvedWand;
		}
	}

	// Token: 0x170004F2 RID: 1266
	// (get) Token: 0x06002B07 RID: 11015 RVA: 0x00120014 File Offset: 0x0011E414
	public override int ItemTierNumber
	{
		get
		{
			return 2;
		}
	}

	// Token: 0x06002B08 RID: 11016 RVA: 0x00120018 File Offset: 0x0011E418
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.TurnStartHeal
		};
	}
}
