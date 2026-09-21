using System;

// Token: 0x02000614 RID: 1556
public class BlackBladeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A9C RID: 10908 RVA: 0x0011F83F File Offset: 0x0011DC3F
	public BlackBladeTemplate()
	{
	}

	// Token: 0x170004BD RID: 1213
	// (get) Token: 0x06002A9D RID: 10909 RVA: 0x0011F847 File Offset: 0x0011DC47
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.BlackBlade;
		}
	}

	// Token: 0x170004BE RID: 1214
	// (get) Token: 0x06002A9E RID: 10910 RVA: 0x0011F84E File Offset: 0x0011DC4E
	public override int ItemTierNumber
	{
		get
		{
			return 3;
		}
	}
}
