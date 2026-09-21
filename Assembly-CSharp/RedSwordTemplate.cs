using System;
using System.Collections.Generic;

// Token: 0x02000672 RID: 1650
public class RedSwordTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002C05 RID: 11269 RVA: 0x0012149A File Offset: 0x0011F89A
	public RedSwordTemplate()
	{
	}

	// Token: 0x17000579 RID: 1401
	// (get) Token: 0x06002C06 RID: 11270 RVA: 0x001214A2 File Offset: 0x0011F8A2
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.RedSword;
		}
	}

	// Token: 0x1700057A RID: 1402
	// (get) Token: 0x06002C07 RID: 11271 RVA: 0x001214A9 File Offset: 0x0011F8A9
	public override int ItemTierNumber
	{
		get
		{
			return 7;
		}
	}

	// Token: 0x06002C08 RID: 11272 RVA: 0x001214AC File Offset: 0x0011F8AC
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.Hunting,
			AttributeType.Mining
		};
	}
}
