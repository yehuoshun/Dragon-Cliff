using System;
using System.Collections.Generic;

// Token: 0x0200064B RID: 1611
public class EpilogueTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002B75 RID: 11125 RVA: 0x00120A12 File Offset: 0x0011EE12
	public EpilogueTemplate()
	{
	}

	// Token: 0x1700052B RID: 1323
	// (get) Token: 0x06002B76 RID: 11126 RVA: 0x00120A2D File Offset: 0x0011EE2D
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700052C RID: 1324
	// (get) Token: 0x06002B77 RID: 11127 RVA: 0x00120A35 File Offset: 0x0011EE35
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002B78 RID: 11128 RVA: 0x00120A40 File Offset: 0x0011EE40
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.EffectMastery
		};
	}

	// Token: 0x040022A4 RID: 8868
	private ResourceType _itemType = ResourceType.Epilogue;

	// Token: 0x040022A5 RID: 8869
	private int _itemTierNumber = 13;
}
