using System;
using System.Collections.Generic;

// Token: 0x020005AA RID: 1450
public class PlateOfBrokenBonesTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x060028E4 RID: 10468 RVA: 0x0011B2FB File Offset: 0x001196FB
	public PlateOfBrokenBonesTemplate()
	{
	}

	// Token: 0x170003E8 RID: 1000
	// (get) Token: 0x060028E5 RID: 10469 RVA: 0x0011B316 File Offset: 0x00119716
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003E9 RID: 1001
	// (get) Token: 0x060028E6 RID: 10470 RVA: 0x0011B31E File Offset: 0x0011971E
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060028E7 RID: 10471 RVA: 0x0011B328 File Offset: 0x00119728
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.BattleStartHeal
		};
	}

	// Token: 0x04002212 RID: 8722
	private ResourceType _itemType = ResourceType.PlateOfBrokenBones;

	// Token: 0x04002213 RID: 8723
	private int _itemTierNumber = 28;
}
