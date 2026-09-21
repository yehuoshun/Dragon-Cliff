using System;
using System.Collections.Generic;

// Token: 0x0200061B RID: 1563
public class MonkeyBladeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AB8 RID: 10936 RVA: 0x0011FA5F File Offset: 0x0011DE5F
	public MonkeyBladeTemplate()
	{
	}

	// Token: 0x170004CB RID: 1227
	// (get) Token: 0x06002AB9 RID: 10937 RVA: 0x0011FA67 File Offset: 0x0011DE67
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.MonkeyBlade;
		}
	}

	// Token: 0x170004CC RID: 1228
	// (get) Token: 0x06002ABA RID: 10938 RVA: 0x0011FA6E File Offset: 0x0011DE6E
	public override int ItemTierNumber
	{
		get
		{
			return 30;
		}
	}

	// Token: 0x06002ABB RID: 10939 RVA: 0x0011FA74 File Offset: 0x0011DE74
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DodgeRateAdjustment
		};
	}
}
