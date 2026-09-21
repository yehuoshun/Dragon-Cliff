using System;
using System.Collections.Generic;

// Token: 0x0200060C RID: 1548
public class DesperationTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002A7B RID: 10875 RVA: 0x0011F562 File Offset: 0x0011D962
	public DesperationTemplate()
	{
	}

	// Token: 0x170004AD RID: 1197
	// (get) Token: 0x06002A7C RID: 10876 RVA: 0x0011F56A File Offset: 0x0011D96A
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Desperation;
		}
	}

	// Token: 0x170004AE RID: 1198
	// (get) Token: 0x06002A7D RID: 10877 RVA: 0x0011F571 File Offset: 0x0011D971
	public override int ItemTierNumber
	{
		get
		{
			return 17;
		}
	}

	// Token: 0x06002A7E RID: 10878 RVA: 0x0011F578 File Offset: 0x0011D978
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealLightningDamageEffectivenessChangeRate
		};
	}
}
