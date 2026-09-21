using System;
using System.Collections.Generic;

// Token: 0x02000630 RID: 1584
public class DecoratedWandTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B0E RID: 11022 RVA: 0x001200C3 File Offset: 0x0011E4C3
	public DecoratedWandTemplate()
	{
	}

	// Token: 0x170004F5 RID: 1269
	// (get) Token: 0x06002B0F RID: 11023 RVA: 0x001200CB File Offset: 0x0011E4CB
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DecoratedWand;
		}
	}

	// Token: 0x170004F6 RID: 1270
	// (get) Token: 0x06002B10 RID: 11024 RVA: 0x001200D2 File Offset: 0x0011E4D2
	public override int ItemTierNumber
	{
		get
		{
			return 3;
		}
	}

	// Token: 0x06002B11 RID: 11025 RVA: 0x001200D8 File Offset: 0x0011E4D8
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealShadowDamageEffectivenessChangeRate,
			AttributeType.DealFireDamageEffectivenessChangeRate,
			AttributeType.DealLightningDamageEffectivenessChangeRate
		};
	}
}
