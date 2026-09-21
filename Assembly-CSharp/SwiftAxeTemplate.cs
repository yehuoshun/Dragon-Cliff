using System;
using System.Collections.Generic;

// Token: 0x02000607 RID: 1543
public class SwiftAxeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A56 RID: 10838 RVA: 0x0011F10F File Offset: 0x0011D50F
	public SwiftAxeTemplate()
	{
	}

	// Token: 0x1700049F RID: 1183
	// (get) Token: 0x06002A57 RID: 10839 RVA: 0x0011F117 File Offset: 0x0011D517
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.SwiftAxe;
		}
	}

	// Token: 0x170004A0 RID: 1184
	// (get) Token: 0x06002A58 RID: 10840 RVA: 0x0011F11E File Offset: 0x0011D51E
	public override int ItemTierNumber
	{
		get
		{
			return 31;
		}
	}

	// Token: 0x06002A59 RID: 10841 RVA: 0x0011F124 File Offset: 0x0011D524
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.HitRateAdjustment
		};
	}
}
