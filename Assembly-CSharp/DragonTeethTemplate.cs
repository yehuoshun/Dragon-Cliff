using System;
using System.Collections.Generic;

// Token: 0x02000631 RID: 1585
public class DragonTeethTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002B12 RID: 11026 RVA: 0x0012010D File Offset: 0x0011E50D
	public DragonTeethTemplate()
	{
	}

	// Token: 0x170004F7 RID: 1271
	// (get) Token: 0x06002B13 RID: 11027 RVA: 0x00120115 File Offset: 0x0011E515
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DragonTeeth;
		}
	}

	// Token: 0x170004F8 RID: 1272
	// (get) Token: 0x06002B14 RID: 11028 RVA: 0x0012011C File Offset: 0x0011E51C
	public override int ItemTierNumber
	{
		get
		{
			return 13;
		}
	}

	// Token: 0x06002B15 RID: 11029 RVA: 0x00120120 File Offset: 0x0011E520
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealPhysicalDamageEffectivenessChangeRate,
			AttributeType.DealIceDamageEffectivenessChangeRate,
			AttributeType.DealPoisonDamageEffectivenessChangeRate
		};
	}
}
