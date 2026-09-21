using System;
using System.Collections.Generic;

// Token: 0x0200059F RID: 1439
public class DescerationTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028BF RID: 10431 RVA: 0x0011B16F File Offset: 0x0011956F
	public DescerationTemplate()
	{
	}

	// Token: 0x170003D2 RID: 978
	// (get) Token: 0x060028C0 RID: 10432 RVA: 0x0011B177 File Offset: 0x00119577
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Desceration;
		}
	}

	// Token: 0x170003D3 RID: 979
	// (get) Token: 0x060028C1 RID: 10433 RVA: 0x0011B17E File Offset: 0x0011957E
	public override int ItemTierNumber
	{
		get
		{
			return 27;
		}
	}

	// Token: 0x060028C2 RID: 10434 RVA: 0x0011B184 File Offset: 0x00119584
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Hunting,
			AttributeType.Mining
		};
	}
}
