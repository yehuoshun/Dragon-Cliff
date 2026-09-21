using System;
using System.Collections.Generic;

// Token: 0x02000625 RID: 1573
public class LighteningSpearTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002AE0 RID: 10976 RVA: 0x0011FD3F File Offset: 0x0011E13F
	public LighteningSpearTemplate()
	{
	}

	// Token: 0x170004DF RID: 1247
	// (get) Token: 0x06002AE1 RID: 10977 RVA: 0x0011FD47 File Offset: 0x0011E147
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.LighteningSpear;
		}
	}

	// Token: 0x170004E0 RID: 1248
	// (get) Token: 0x06002AE2 RID: 10978 RVA: 0x0011FD4E File Offset: 0x0011E14E
	public override int ItemTierNumber
	{
		get
		{
			return 9;
		}
	}

	// Token: 0x06002AE3 RID: 10979 RVA: 0x0011FD54 File Offset: 0x0011E154
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.EffectHitRating
		};
	}
}
