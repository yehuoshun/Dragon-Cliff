using System;

// Token: 0x02000655 RID: 1621
public class RedWandTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B9D RID: 11165 RVA: 0x00120D6E File Offset: 0x0011F16E
	public RedWandTemplate()
	{
	}

	// Token: 0x1700053F RID: 1343
	// (get) Token: 0x06002B9E RID: 11166 RVA: 0x00120D76 File Offset: 0x0011F176
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.RedWand;
		}
	}

	// Token: 0x17000540 RID: 1344
	// (get) Token: 0x06002B9F RID: 11167 RVA: 0x00120D7D File Offset: 0x0011F17D
	public override int ItemTierNumber
	{
		get
		{
			return 8;
		}
	}
}
