using System;

// Token: 0x0200057E RID: 1406
public class DefusedLeatherTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600284D RID: 10317 RVA: 0x0011AA28 File Offset: 0x00118E28
	public DefusedLeatherTemplate()
	{
	}

	// Token: 0x17000390 RID: 912
	// (get) Token: 0x0600284E RID: 10318 RVA: 0x0011AA30 File Offset: 0x00118E30
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DefusedLeather;
		}
	}

	// Token: 0x17000391 RID: 913
	// (get) Token: 0x0600284F RID: 10319 RVA: 0x0011AA37 File Offset: 0x00118E37
	public override int ItemTierNumber
	{
		get
		{
			return 21;
		}
	}
}
