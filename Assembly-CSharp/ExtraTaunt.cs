using System;
using System.Collections.Generic;

// Token: 0x02000A38 RID: 2616
public class ExtraTaunt : AffixAttachmentRuleBase
{
	// Token: 0x06004745 RID: 18245 RVA: 0x001D1994 File Offset: 0x001CFD94
	public ExtraTaunt()
	{
	}

	// Token: 0x17000DE0 RID: 3552
	// (get) Token: 0x06004746 RID: 18246 RVA: 0x001D199C File Offset: 0x001CFD9C
	public override AffixType CorrespondingAffixType
	{
		get
		{
			return AffixType.ExtraTaunt;
		}
	}

	// Token: 0x06004747 RID: 18247 RVA: 0x001D19A0 File Offset: 0x001CFDA0
	public override List<AttributeAffix> GetAffixAdditionalAttributes(int monsterHiddenLevel)
	{
		return new List<AttributeAffix>
		{
			new AttributeAffix
			{
				AttributeType = AttributeType.TauntOnHit,
				Value = 0.30000001192092896
			}
		};
	}
}
