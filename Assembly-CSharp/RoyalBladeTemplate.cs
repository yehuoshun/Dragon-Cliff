using System;
using System.Collections.Generic;

// Token: 0x0200061D RID: 1565
public class RoyalBladeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AC0 RID: 10944 RVA: 0x0011FAC7 File Offset: 0x0011DEC7
	public RoyalBladeTemplate()
	{
	}

	// Token: 0x170004CF RID: 1231
	// (get) Token: 0x06002AC1 RID: 10945 RVA: 0x0011FACF File Offset: 0x0011DECF
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.RoyalBlade;
		}
	}

	// Token: 0x170004D0 RID: 1232
	// (get) Token: 0x06002AC2 RID: 10946 RVA: 0x0011FAD6 File Offset: 0x0011DED6
	public override int ItemTierNumber
	{
		get
		{
			return 26;
		}
	}

	// Token: 0x06002AC3 RID: 10947 RVA: 0x0011FADC File Offset: 0x0011DEDC
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealDivineDamageEffectivenessChangeRate
		};
	}
}
