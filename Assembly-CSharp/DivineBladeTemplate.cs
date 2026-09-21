using System;
using System.Collections.Generic;

// Token: 0x0200060E RID: 1550
public class DivineBladeTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A84 RID: 10884 RVA: 0x0011F61F File Offset: 0x0011DA1F
	public DivineBladeTemplate()
	{
	}

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06002A85 RID: 10885 RVA: 0x0011F627 File Offset: 0x0011DA27
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.DivineBlade;
		}
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06002A86 RID: 10886 RVA: 0x0011F62E File Offset: 0x0011DA2E
	public override int ItemTierNumber
	{
		get
		{
			return 22;
		}
	}

	// Token: 0x06002A87 RID: 10887 RVA: 0x0011F634 File Offset: 0x0011DA34
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealDivineDamageEffectivenessChangeRate
		};
	}
}
