using System;
using System.Collections.Generic;

// Token: 0x02000679 RID: 1657
public class SwordOfSpringTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002C20 RID: 11296 RVA: 0x001216F2 File Offset: 0x0011FAF2
	public SwordOfSpringTemplate()
	{
	}

	// Token: 0x17000587 RID: 1415
	// (get) Token: 0x06002C21 RID: 11297 RVA: 0x001216FA File Offset: 0x0011FAFA
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.SwordOfSpring;
		}
	}

	// Token: 0x17000588 RID: 1416
	// (get) Token: 0x06002C22 RID: 11298 RVA: 0x00121701 File Offset: 0x0011FB01
	public override int ItemTierNumber
	{
		get
		{
			return 13;
		}
	}

	// Token: 0x06002C23 RID: 11299 RVA: 0x00121708 File Offset: 0x0011FB08
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealLightningDamageEffectivenessChangeRate,
			AttributeType.DealShadowDamageEffectivenessChangeRate,
			AttributeType.DealDivineDamageEffectivenessChangeRate
		};
	}
}
