using System;
using System.Collections.Generic;

// Token: 0x02000613 RID: 1555
public class AshTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A98 RID: 10904 RVA: 0x0011F80B File Offset: 0x0011DC0B
	public AshTemplate()
	{
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06002A99 RID: 10905 RVA: 0x0011F813 File Offset: 0x0011DC13
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Ash;
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06002A9A RID: 10906 RVA: 0x0011F81A File Offset: 0x0011DC1A
	public override int ItemTierNumber
	{
		get
		{
			return 16;
		}
	}

	// Token: 0x06002A9B RID: 10907 RVA: 0x0011F820 File Offset: 0x0011DC20
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealShadowDamageEffectivenessChangeRate
		};
	}
}
