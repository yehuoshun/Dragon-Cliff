using System;

// Token: 0x02000642 RID: 1602
public class WandOfFireTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B52 RID: 11090 RVA: 0x0012079E File Offset: 0x0011EB9E
	public WandOfFireTemplate()
	{
	}

	// Token: 0x17000519 RID: 1305
	// (get) Token: 0x06002B53 RID: 11091 RVA: 0x001207A6 File Offset: 0x0011EBA6
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.WandOfFire;
		}
	}

	// Token: 0x1700051A RID: 1306
	// (get) Token: 0x06002B54 RID: 11092 RVA: 0x001207AD File Offset: 0x0011EBAD
	public override int ItemTierNumber
	{
		get
		{
			return 4;
		}
	}
}
