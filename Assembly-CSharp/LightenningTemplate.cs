using System;
using System.Collections.Generic;

// Token: 0x02000660 RID: 1632
public class LightenningTemplate : DungeonDropedGearTemplateBase
{
	// Token: 0x06002BC2 RID: 11202 RVA: 0x00120F43 File Offset: 0x0011F343
	public LightenningTemplate()
	{
	}

	// Token: 0x17000555 RID: 1365
	// (get) Token: 0x06002BC3 RID: 11203 RVA: 0x00120F4B File Offset: 0x0011F34B
	public override ResourceType ItemType
	{
		get
		{
			return ResourceType.Lightenning;
		}
	}

	// Token: 0x17000556 RID: 1366
	// (get) Token: 0x06002BC4 RID: 11204 RVA: 0x00120F52 File Offset: 0x0011F352
	public override int ItemTierNumber
	{
		get
		{
			return 21;
		}
	}

	// Token: 0x06002BC5 RID: 11205 RVA: 0x00120F58 File Offset: 0x0011F358
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.SkillRageEfficiencyRate
		};
	}
}
