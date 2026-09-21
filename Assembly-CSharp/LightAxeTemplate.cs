using System;
using System.Collections.Generic;

// Token: 0x020005FD RID: 1533
public class LightAxeTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A2D RID: 10797 RVA: 0x0011EDAB File Offset: 0x0011D1AB
	public LightAxeTemplate()
	{
	}

	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x06002A2E RID: 10798 RVA: 0x0011EDB3 File Offset: 0x0011D1B3
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.LightAxe;
		}
	}

	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x06002A2F RID: 10799 RVA: 0x0011EDBA File Offset: 0x0011D1BA
	public override int ItemTierNumber
	{
		get
		{
			return 7;
		}
	}

	// Token: 0x06002A30 RID: 10800 RVA: 0x0011EDC0 File Offset: 0x0011D1C0
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealLightningDamageEffectivenessChangeRate
		};
	}
}
