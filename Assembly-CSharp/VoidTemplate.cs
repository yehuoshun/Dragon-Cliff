using System;

// Token: 0x020005DA RID: 1498
public class VoidTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002989 RID: 10633 RVA: 0x0011BE2E File Offset: 0x0011A22E
	public VoidTemplate()
	{
	}

	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x0600298A RID: 10634 RVA: 0x0011BE36 File Offset: 0x0011A236
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Void;
		}
	}

	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x0600298B RID: 10635 RVA: 0x0011BE3D File Offset: 0x0011A23D
	public override int ItemTierNumber
	{
		get
		{
			return 22;
		}
	}
}
