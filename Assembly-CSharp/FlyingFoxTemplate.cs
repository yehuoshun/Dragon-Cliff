using System;
using System.Collections.Generic;

// Token: 0x02000617 RID: 1559
public class FlyingFoxTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AA8 RID: 10920 RVA: 0x0011F956 File Offset: 0x0011DD56
	public FlyingFoxTemplate()
	{
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06002AA9 RID: 10921 RVA: 0x0011F95E File Offset: 0x0011DD5E
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.FlyingFox;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06002AAA RID: 10922 RVA: 0x0011F965 File Offset: 0x0011DD65
	public override int ItemTierNumber
	{
		get
		{
			return 32;
		}
	}

	// Token: 0x06002AAB RID: 10923 RVA: 0x0011F96C File Offset: 0x0011DD6C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealPhysicalDamageEffectivenessChangeRate
		};
	}
}
