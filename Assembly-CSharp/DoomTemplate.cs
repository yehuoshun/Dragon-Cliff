using System;
using System.Collections.Generic;

// Token: 0x02000622 RID: 1570
public class DoomTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002AD3 RID: 10963 RVA: 0x0011FBE5 File Offset: 0x0011DFE5
	public DoomTemplate()
	{
	}

	// Token: 0x170004D9 RID: 1241
	// (get) Token: 0x06002AD4 RID: 10964 RVA: 0x0011FBED File Offset: 0x0011DFED
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Doom;
		}
	}

	// Token: 0x170004DA RID: 1242
	// (get) Token: 0x06002AD5 RID: 10965 RVA: 0x0011FBF4 File Offset: 0x0011DFF4
	public override int ItemTierNumber
	{
		get
		{
			return 32;
		}
	}

	// Token: 0x06002AD6 RID: 10966 RVA: 0x0011FBF8 File Offset: 0x0011DFF8
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealShadowDamageEffectivenessChangeRate
		};
	}
}
