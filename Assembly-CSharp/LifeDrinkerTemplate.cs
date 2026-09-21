using System;
using System.Collections.Generic;

// Token: 0x02000605 RID: 1541
public class LifeDrinkerTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002A4E RID: 10830 RVA: 0x0011F06F File Offset: 0x0011D46F
	public LifeDrinkerTemplate()
	{
	}

	// Token: 0x1700049B RID: 1179
	// (get) Token: 0x06002A4F RID: 10831 RVA: 0x0011F08A File Offset: 0x0011D48A
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700049C RID: 1180
	// (get) Token: 0x06002A50 RID: 10832 RVA: 0x0011F092 File Offset: 0x0011D492
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x06002A51 RID: 10833 RVA: 0x0011F09C File Offset: 0x0011D49C
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.DealPhysicalDamageEffectivenessChangeRate
		};
	}

	// Token: 0x04002272 RID: 8818
	private ResourceType _itemType = ResourceType.LifeDrinker;

	// Token: 0x04002273 RID: 8819
	private int _itemTierNumber = 12;
}
