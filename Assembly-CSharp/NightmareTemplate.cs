using System;

// Token: 0x0200063D RID: 1597
public class NightmareTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B42 RID: 11074 RVA: 0x00120686 File Offset: 0x0011EA86
	public NightmareTemplate()
	{
	}

	// Token: 0x1700050F RID: 1295
	// (get) Token: 0x06002B43 RID: 11075 RVA: 0x0012068E File Offset: 0x0011EA8E
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Nightmare;
		}
	}

	// Token: 0x17000510 RID: 1296
	// (get) Token: 0x06002B44 RID: 11076 RVA: 0x00120695 File Offset: 0x0011EA95
	public override int ItemTierNumber
	{
		get
		{
			return 27;
		}
	}
}
