using System;

// Token: 0x020005A7 RID: 1447
public class HellishMailTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028DA RID: 10458 RVA: 0x0011B272 File Offset: 0x00119672
	public HellishMailTemplate()
	{
	}

	// Token: 0x170003E2 RID: 994
	// (get) Token: 0x060028DB RID: 10459 RVA: 0x0011B27A File Offset: 0x0011967A
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.HellishMail;
		}
	}

	// Token: 0x170003E3 RID: 995
	// (get) Token: 0x060028DC RID: 10460 RVA: 0x0011B281 File Offset: 0x00119681
	public override int ItemTierNumber
	{
		get
		{
			return 28;
		}
	}
}
