using System;
using System.Collections.Generic;

// Token: 0x02000603 RID: 1539
public class HeartSeekerTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A46 RID: 10822 RVA: 0x0011EFD5 File Offset: 0x0011D3D5
	public HeartSeekerTemplate()
	{
	}

	// Token: 0x17000497 RID: 1175
	// (get) Token: 0x06002A47 RID: 10823 RVA: 0x0011EFF0 File Offset: 0x0011D3F0
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000498 RID: 1176
	// (get) Token: 0x06002A48 RID: 10824 RVA: 0x0011EFF8 File Offset: 0x0011D3F8
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002A49 RID: 10825 RVA: 0x0011F000 File Offset: 0x0011D400
	public override List<AttributeType> AdditionalGuarranteedPrimaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.TauntOnHit
		};
	}

	// Token: 0x0400226D RID: 8813
	private ResourceType _itemType = ResourceType.Heartseeker;

	// Token: 0x0400226E RID: 8814
	private int _itemTierNumber = 17;
}
