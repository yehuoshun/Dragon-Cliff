using System;
using System.Collections.Generic;

// Token: 0x02000A35 RID: 2613
public class ExtraOutput : AffixAttachmentRuleBase
{
	// Token: 0x0600473C RID: 18236 RVA: 0x001D1897 File Offset: 0x001CFC97
	public ExtraOutput()
	{
	}

	// Token: 0x17000DDD RID: 3549
	// (get) Token: 0x0600473D RID: 18237 RVA: 0x001D189F File Offset: 0x001CFC9F
	public override AffixType CorrespondingAffixType
	{
		get
		{
			return AffixType.ExtraOutput;
		}
	}

	// Token: 0x0600473E RID: 18238 RVA: 0x001D18A4 File Offset: 0x001CFCA4
	public override List<AttributeAffix> GetAffixAdditionalAttributes(int monsterHiddenLevel)
	{
		return new List<AttributeAffix>
		{
			new AttributeAffix
			{
				AttributeType = AttributeType.Intelligience,
				Value = (double)AffixAttachmentRuleBase.AffixCoreAttributeValueBase * 0.2
			},
			new AttributeAffix
			{
				AttributeType = AttributeType.Strength,
				Value = (double)AffixAttachmentRuleBase.AffixCoreAttributeValueBase * 0.2
			}
		};
	}
}
