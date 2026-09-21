using System;
using System.Collections.Generic;

// Token: 0x020005A0 RID: 1440
public class DivinePlateTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028C3 RID: 10435 RVA: 0x0011B1AE File Offset: 0x001195AE
	public DivinePlateTemplate()
	{
	}

	// Token: 0x170003D4 RID: 980
	// (get) Token: 0x060028C4 RID: 10436 RVA: 0x0011B1B6 File Offset: 0x001195B6
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DivinePlate;
		}
	}

	// Token: 0x170003D5 RID: 981
	// (get) Token: 0x060028C5 RID: 10437 RVA: 0x0011B1BD File Offset: 0x001195BD
	public override int ItemTierNumber
	{
		get
		{
			return 17;
		}
	}

	// Token: 0x060028C6 RID: 10438 RVA: 0x0011B1C1 File Offset: 0x001195C1
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>();
	}
}
