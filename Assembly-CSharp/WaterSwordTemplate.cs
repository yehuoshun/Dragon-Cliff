using System;
using System.Collections.Generic;

// Token: 0x02000665 RID: 1637
public class WaterSwordTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002BD5 RID: 11221 RVA: 0x001210EE File Offset: 0x0011F4EE
	public WaterSwordTemplate()
	{
	}

	// Token: 0x1700055F RID: 1375
	// (get) Token: 0x06002BD6 RID: 11222 RVA: 0x001210F6 File Offset: 0x0011F4F6
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.WaterSword;
		}
	}

	// Token: 0x17000560 RID: 1376
	// (get) Token: 0x06002BD7 RID: 11223 RVA: 0x001210FD File Offset: 0x0011F4FD
	public override int ItemTierNumber
	{
		get
		{
			return 8;
		}
	}

	// Token: 0x06002BD8 RID: 11224 RVA: 0x00121100 File Offset: 0x0011F500
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.EffectHitRating
		};
	}
}
