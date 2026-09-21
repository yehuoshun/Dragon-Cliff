using System;
using System.Collections.Generic;

// Token: 0x020005B7 RID: 1463
public class WildnessTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x0600290F RID: 10511 RVA: 0x0011B554 File Offset: 0x00119954
	public WildnessTemplate()
	{
	}

	// Token: 0x17000402 RID: 1026
	// (get) Token: 0x06002910 RID: 10512 RVA: 0x0011B55C File Offset: 0x0011995C
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Wildness;
		}
	}

	// Token: 0x17000403 RID: 1027
	// (get) Token: 0x06002911 RID: 10513 RVA: 0x0011B563 File Offset: 0x00119963
	public override int ItemTierNumber
	{
		get
		{
			return 21;
		}
	}

	// Token: 0x06002912 RID: 10514 RVA: 0x0011B568 File Offset: 0x00119968
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.ReflectiveDamage
		};
	}
}
