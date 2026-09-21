using System;

// Token: 0x0200063E RID: 1598
public class SeaTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B45 RID: 11077 RVA: 0x00120699 File Offset: 0x0011EA99
	public SeaTemplate()
	{
	}

	// Token: 0x17000511 RID: 1297
	// (get) Token: 0x06002B46 RID: 11078 RVA: 0x001206A1 File Offset: 0x0011EAA1
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Sea;
		}
	}

	// Token: 0x17000512 RID: 1298
	// (get) Token: 0x06002B47 RID: 11079 RVA: 0x001206A8 File Offset: 0x0011EAA8
	public override int ItemTierNumber
	{
		get
		{
			return 14;
		}
	}
}
