using System;
using System.Collections.Generic;

// Token: 0x02000636 RID: 1590
public class GoldenFairyTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B27 RID: 11047 RVA: 0x00120319 File Offset: 0x0011E719
	public GoldenFairyTemplate()
	{
	}

	// Token: 0x17000501 RID: 1281
	// (get) Token: 0x06002B28 RID: 11048 RVA: 0x00120321 File Offset: 0x0011E721
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.GoldenFairy;
		}
	}

	// Token: 0x17000502 RID: 1282
	// (get) Token: 0x06002B29 RID: 11049 RVA: 0x00120328 File Offset: 0x0011E728
	public override int ItemTierNumber
	{
		get
		{
			return 22;
		}
	}

	// Token: 0x06002B2A RID: 11050 RVA: 0x0012032C File Offset: 0x0011E72C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.HealingAbsorbRate
		};
	}
}
