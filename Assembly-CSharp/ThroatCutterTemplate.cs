using System;
using System.Collections.Generic;

// Token: 0x02000620 RID: 1568
public class ThroatCutterTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002ACB RID: 10955 RVA: 0x0011FB57 File Offset: 0x0011DF57
	public ThroatCutterTemplate()
	{
	}

	// Token: 0x170004D5 RID: 1237
	// (get) Token: 0x06002ACC RID: 10956 RVA: 0x0011FB5F File Offset: 0x0011DF5F
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.ThroatCutter;
		}
	}

	// Token: 0x170004D6 RID: 1238
	// (get) Token: 0x06002ACD RID: 10957 RVA: 0x0011FB66 File Offset: 0x0011DF66
	public override int ItemTierNumber
	{
		get
		{
			return 17;
		}
	}

	// Token: 0x06002ACE RID: 10958 RVA: 0x0011FB6C File Offset: 0x0011DF6C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.EffectMastery
		};
	}
}
