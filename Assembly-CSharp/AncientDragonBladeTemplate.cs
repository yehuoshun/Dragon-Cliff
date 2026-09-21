using System;
using System.Collections.Generic;

// Token: 0x02000612 RID: 1554
public class AncientDragonBladeTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A94 RID: 10900 RVA: 0x0011F7BF File Offset: 0x0011DBBF
	public AncientDragonBladeTemplate()
	{
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06002A95 RID: 10901 RVA: 0x0011F7DA File Offset: 0x0011DBDA
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06002A96 RID: 10902 RVA: 0x0011F7E2 File Offset: 0x0011DBE2
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002A97 RID: 10903 RVA: 0x0011F7EC File Offset: 0x0011DBEC
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.StunOnHit
		};
	}

	// Token: 0x04002281 RID: 8833
	private ResourceType _itemType = ResourceType.AncientDragonBlade;

	// Token: 0x04002282 RID: 8834
	private int _itemTierNumber = 23;
}
