using System;

// Token: 0x02000661 RID: 1633
public class MingSwordTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002BC6 RID: 11206 RVA: 0x00120F77 File Offset: 0x0011F377
	public MingSwordTemplate()
	{
	}

	// Token: 0x17000557 RID: 1367
	// (get) Token: 0x06002BC7 RID: 11207 RVA: 0x00120F7F File Offset: 0x0011F37F
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.MingSword;
		}
	}

	// Token: 0x17000558 RID: 1368
	// (get) Token: 0x06002BC8 RID: 11208 RVA: 0x00120F86 File Offset: 0x0011F386
	public override int ItemTierNumber
	{
		get
		{
			return 2;
		}
	}
}
