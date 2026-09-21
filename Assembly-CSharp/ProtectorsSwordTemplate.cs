using System;

// Token: 0x02000671 RID: 1649
public class ProtectorsSwordTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002C02 RID: 11266 RVA: 0x00121487 File Offset: 0x0011F887
	public ProtectorsSwordTemplate()
	{
	}

	// Token: 0x17000577 RID: 1399
	// (get) Token: 0x06002C03 RID: 11267 RVA: 0x0012148F File Offset: 0x0011F88F
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.ProtectorsSword;
		}
	}

	// Token: 0x17000578 RID: 1400
	// (get) Token: 0x06002C04 RID: 11268 RVA: 0x00121496 File Offset: 0x0011F896
	public override int ItemTierNumber
	{
		get
		{
			return 29;
		}
	}
}
