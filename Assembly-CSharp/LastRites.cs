using System;
using System.Collections.Generic;

// Token: 0x0200061A RID: 1562
public class LastRites : RecipeProducedGearTemplateBase
{
	// Token: 0x06002AB4 RID: 10932 RVA: 0x0011FA12 File Offset: 0x0011DE12
	public LastRites()
	{
	}

	// Token: 0x170004C9 RID: 1225
	// (get) Token: 0x06002AB5 RID: 10933 RVA: 0x0011FA2D File Offset: 0x0011DE2D
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170004CA RID: 1226
	// (get) Token: 0x06002AB6 RID: 10934 RVA: 0x0011FA35 File Offset: 0x0011DE35
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002AB7 RID: 10935 RVA: 0x0011FA40 File Offset: 0x0011DE40
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.LifeOnHit
		};
	}

	// Token: 0x04002287 RID: 8839
	private ResourceType _itemType = ResourceType.LastRites;

	// Token: 0x04002288 RID: 8840
	private int _itemTierNumber = 18;
}
