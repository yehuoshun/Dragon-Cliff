using System;

// Token: 0x020005A1 RID: 1441
public class DivineSoulsTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028C7 RID: 10439 RVA: 0x0011B1C8 File Offset: 0x001195C8
	public DivineSoulsTemplate()
	{
	}

	// Token: 0x170003D6 RID: 982
	// (get) Token: 0x060028C8 RID: 10440 RVA: 0x0011B1D0 File Offset: 0x001195D0
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DivineSouls;
		}
	}

	// Token: 0x170003D7 RID: 983
	// (get) Token: 0x060028C9 RID: 10441 RVA: 0x0011B1D7 File Offset: 0x001195D7
	public override int ItemTierNumber
	{
		get
		{
			return 29;
		}
	}
}
