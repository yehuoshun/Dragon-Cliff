using System;
using System.Collections.Generic;

// Token: 0x0200065F RID: 1631
public class IronSwordTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002BBE RID: 11198 RVA: 0x00120F0F File Offset: 0x0011F30F
	public IronSwordTemplate()
	{
	}

	// Token: 0x17000553 RID: 1363
	// (get) Token: 0x06002BBF RID: 11199 RVA: 0x00120F17 File Offset: 0x0011F317
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.IronSword;
		}
	}

	// Token: 0x17000554 RID: 1364
	// (get) Token: 0x06002BC0 RID: 11200 RVA: 0x00120F1E File Offset: 0x0011F31E
	public override int ItemTierNumber
	{
		get
		{
			return 6;
		}
	}

	// Token: 0x06002BC1 RID: 11201 RVA: 0x00120F24 File Offset: 0x0011F324
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.LifeOnHit
		};
	}
}
