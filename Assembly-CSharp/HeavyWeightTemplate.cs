using System;
using System.Collections.Generic;

// Token: 0x0200065E RID: 1630
public class HeavyWeightTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002BBA RID: 11194 RVA: 0x00120EDD File Offset: 0x0011F2DD
	public HeavyWeightTemplate()
	{
	}

	// Token: 0x17000551 RID: 1361
	// (get) Token: 0x06002BBB RID: 11195 RVA: 0x00120EE5 File Offset: 0x0011F2E5
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.HeavyWeight;
		}
	}

	// Token: 0x17000552 RID: 1362
	// (get) Token: 0x06002BBC RID: 11196 RVA: 0x00120EEC File Offset: 0x0011F2EC
	public override int ItemTierNumber
	{
		get
		{
			return 26;
		}
	}

	// Token: 0x06002BBD RID: 11197 RVA: 0x00120EF0 File Offset: 0x0011F2F0
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.TauntOnHit
		};
	}
}
