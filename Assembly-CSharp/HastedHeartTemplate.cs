using System;
using System.Collections.Generic;

// Token: 0x02000652 RID: 1618
public class HastedHeartTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B91 RID: 11153 RVA: 0x00120C59 File Offset: 0x0011F059
	public HastedHeartTemplate()
	{
	}

	// Token: 0x17000539 RID: 1337
	// (get) Token: 0x06002B92 RID: 11154 RVA: 0x00120C61 File Offset: 0x0011F061
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.HastedHeart;
		}
	}

	// Token: 0x1700053A RID: 1338
	// (get) Token: 0x06002B93 RID: 11155 RVA: 0x00120C68 File Offset: 0x0011F068
	public override int ItemTierNumber
	{
		get
		{
			return 27;
		}
	}

	// Token: 0x06002B94 RID: 11156 RVA: 0x00120C6C File Offset: 0x0011F06C
	public override List<AttributeType> AdditionalGuarranteedPrimaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.BattleStartHeal
		};
	}
}
