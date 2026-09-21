using System;
using System.Collections.Generic;

// Token: 0x0200060F RID: 1551
public class GoldenBladeTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A88 RID: 10888 RVA: 0x0011F653 File Offset: 0x0011DA53
	public GoldenBladeTemplate()
	{
	}

	// Token: 0x170004B3 RID: 1203
	// (get) Token: 0x06002A89 RID: 10889 RVA: 0x0011F65B File Offset: 0x0011DA5B
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.GoldenBlade;
		}
	}

	// Token: 0x170004B4 RID: 1204
	// (get) Token: 0x06002A8A RID: 10890 RVA: 0x0011F662 File Offset: 0x0011DA62
	public override int ItemTierNumber
	{
		get
		{
			return 12;
		}
	}

	// Token: 0x06002A8B RID: 10891 RVA: 0x0011F668 File Offset: 0x0011DA68
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealPhysicalDamageEffectivenessChangeRate
		};
	}
}
